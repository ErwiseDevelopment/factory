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
   public class assinatura_bc : GxSilentTrn, IGxSilentTrn
   {
      public assinatura_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinatura_bc( IGxContext context )
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
         ReadRow1140( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1140( ) ;
         standaloneModal( ) ;
         AddRow1140( ) ;
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
            /* Execute user event: After Trn */
            E11112 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z238AssinaturaId = A238AssinaturaId;
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1140( ) ;
            }
            else
            {
               CheckExtendedTable1140( ) ;
               if ( AnyError == 0 )
               {
                  ZM1140( 9) ;
                  ZM1140( 10) ;
                  ZM1140( 11) ;
                  ZM1140( 12) ;
               }
               CloseExtendedTableCursors1140( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12112( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV11Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ArquivoId") == 0 )
               {
                  AV12Insert_ArquivoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ArquivoAssinadoId") == 0 )
               {
                  AV22Insert_ArquivoAssinadoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E11112( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1140( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z241AssinaturaPublicKey = A241AssinaturaPublicKey;
            Z239AssinaturaStatus = A239AssinaturaStatus;
            Z364AssinaturaPaginaConsulta = A364AssinaturaPaginaConsulta;
            Z365AssinaturaToken = A365AssinaturaToken;
            Z368AssinaturaMes = A368AssinaturaMes;
            Z371AssinaturaMesNome = A371AssinaturaMesNome;
            Z369AssinaturaAno = A369AssinaturaAno;
            Z366AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
            Z227ContratoId = A227ContratoId;
            Z231ArquivoId = A231ArquivoId;
            Z578ArquivoAssinadoId = A578ArquivoAssinadoId;
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
         }
         if ( GX_JID == -8 )
         {
            Z238AssinaturaId = A238AssinaturaId;
            Z241AssinaturaPublicKey = A241AssinaturaPublicKey;
            Z239AssinaturaStatus = A239AssinaturaStatus;
            Z240AssinaturaArquivoAssinado = A240AssinaturaArquivoAssinado;
            Z364AssinaturaPaginaConsulta = A364AssinaturaPaginaConsulta;
            Z365AssinaturaToken = A365AssinaturaToken;
            Z368AssinaturaMes = A368AssinaturaMes;
            Z371AssinaturaMesNome = A371AssinaturaMesNome;
            Z369AssinaturaAno = A369AssinaturaAno;
            Z366AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
            Z256AssinaturaArquivoAssinadoExtensao = A256AssinaturaArquivoAssinadoExtensao;
            Z257AssinaturaArquivoAssinadoNome = A257AssinaturaArquivoAssinadoNome;
            Z227ContratoId = A227ContratoId;
            Z231ArquivoId = A231ArquivoId;
            Z578ArquivoAssinadoId = A578ArquivoAssinadoId;
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
            Z228ContratoNome = A228ContratoNome;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Assinatura_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A241AssinaturaPublicKey) )
         {
            A241AssinaturaPublicKey = Guid.NewGuid( );
            n241AssinaturaPublicKey = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1140( )
      {
         /* Using cursor BC001110 */
         pr_default.execute(6, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound40 = 1;
            A241AssinaturaPublicKey = BC001110_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = BC001110_n241AssinaturaPublicKey[0];
            A239AssinaturaStatus = BC001110_A239AssinaturaStatus[0];
            n239AssinaturaStatus = BC001110_n239AssinaturaStatus[0];
            A228ContratoNome = BC001110_A228ContratoNome[0];
            n228ContratoNome = BC001110_n228ContratoNome[0];
            A362ContratoDataInicial = BC001110_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC001110_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC001110_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC001110_n363ContratoDataFinal[0];
            A364AssinaturaPaginaConsulta = BC001110_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = BC001110_n364AssinaturaPaginaConsulta[0];
            A365AssinaturaToken = BC001110_A365AssinaturaToken[0];
            n365AssinaturaToken = BC001110_n365AssinaturaToken[0];
            A368AssinaturaMes = BC001110_A368AssinaturaMes[0];
            n368AssinaturaMes = BC001110_n368AssinaturaMes[0];
            A371AssinaturaMesNome = BC001110_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = BC001110_n371AssinaturaMesNome[0];
            A369AssinaturaAno = BC001110_A369AssinaturaAno[0];
            n369AssinaturaAno = BC001110_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = BC001110_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = BC001110_n366AssinaturaFinalizadoData[0];
            A256AssinaturaArquivoAssinadoExtensao = BC001110_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = BC001110_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            A257AssinaturaArquivoAssinadoNome = BC001110_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = BC001110_n257AssinaturaArquivoAssinadoNome[0];
            A240AssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = BC001110_A227ContratoId[0];
            n227ContratoId = BC001110_n227ContratoId[0];
            A231ArquivoId = BC001110_A231ArquivoId[0];
            n231ArquivoId = BC001110_n231ArquivoId[0];
            A578ArquivoAssinadoId = BC001110_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = BC001110_n578ArquivoAssinadoId[0];
            A367AssinaturaParticipantes_F = BC001110_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = BC001110_n367AssinaturaParticipantes_F[0];
            A240AssinaturaArquivoAssinado = BC001110_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = BC001110_n240AssinaturaArquivoAssinado[0];
            ZM1140( -8) ;
         }
         pr_default.close(6);
         OnLoadActions1140( ) ;
      }

      protected void OnLoadActions1140( )
      {
         if ( (0==A231ArquivoId) )
         {
            A231ArquivoId = 0;
            n231ArquivoId = false;
            n231ArquivoId = true;
            n231ArquivoId = true;
         }
         if ( (0==A578ArquivoAssinadoId) )
         {
            A578ArquivoAssinadoId = 0;
            n578ArquivoAssinadoId = false;
            n578ArquivoAssinadoId = true;
            n578ArquivoAssinadoId = true;
         }
      }

      protected void CheckExtendedTable1140( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00118 */
         pr_default.execute(5, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A367AssinaturaParticipantes_F = BC00118_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = BC00118_n367AssinaturaParticipantes_F[0];
         }
         else
         {
            A367AssinaturaParticipantes_F = 0;
            n367AssinaturaParticipantes_F = false;
         }
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A239AssinaturaStatus, "ENVIADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "ASSINADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "AGUARDANDO_ENVIO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A239AssinaturaStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00114 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = BC00114_A228ContratoNome[0];
         n228ContratoNome = BC00114_n228ContratoNome[0];
         A362ContratoDataInicial = BC00114_A362ContratoDataInicial[0];
         n362ContratoDataInicial = BC00114_n362ContratoDataInicial[0];
         A363ContratoDataFinal = BC00114_A363ContratoDataFinal[0];
         n363ContratoDataFinal = BC00114_n363ContratoDataFinal[0];
         pr_default.close(2);
         if ( (0==A231ArquivoId) )
         {
            A231ArquivoId = 0;
            n231ArquivoId = false;
            n231ArquivoId = true;
            n231ArquivoId = true;
         }
         /* Using cursor BC00115 */
         pr_default.execute(3, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A231ArquivoId) ) )
            {
               GX_msglist.addItem("Não existe 'Arquivo'.", "ForeignKeyNotFound", 1, "ARQUIVOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( (0==A578ArquivoAssinadoId) )
         {
            A578ArquivoAssinadoId = 0;
            n578ArquivoAssinadoId = false;
            n578ArquivoAssinadoId = true;
            n578ArquivoAssinadoId = true;
         }
         /* Using cursor BC00116 */
         pr_default.execute(4, new Object[] {n578ArquivoAssinadoId, A578ArquivoAssinadoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A578ArquivoAssinadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Arquivo Assinado'.", "ForeignKeyNotFound", 1, "ARQUIVOASSINADOID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1140( )
      {
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1140( )
      {
         /* Using cursor BC001111 */
         pr_default.execute(7, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00113 */
         pr_default.execute(1, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1140( 8) ;
            RcdFound40 = 1;
            A238AssinaturaId = BC00113_A238AssinaturaId[0];
            n238AssinaturaId = BC00113_n238AssinaturaId[0];
            A241AssinaturaPublicKey = BC00113_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = BC00113_n241AssinaturaPublicKey[0];
            A239AssinaturaStatus = BC00113_A239AssinaturaStatus[0];
            n239AssinaturaStatus = BC00113_n239AssinaturaStatus[0];
            A364AssinaturaPaginaConsulta = BC00113_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = BC00113_n364AssinaturaPaginaConsulta[0];
            A365AssinaturaToken = BC00113_A365AssinaturaToken[0];
            n365AssinaturaToken = BC00113_n365AssinaturaToken[0];
            A368AssinaturaMes = BC00113_A368AssinaturaMes[0];
            n368AssinaturaMes = BC00113_n368AssinaturaMes[0];
            A371AssinaturaMesNome = BC00113_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = BC00113_n371AssinaturaMesNome[0];
            A369AssinaturaAno = BC00113_A369AssinaturaAno[0];
            n369AssinaturaAno = BC00113_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = BC00113_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = BC00113_n366AssinaturaFinalizadoData[0];
            A256AssinaturaArquivoAssinadoExtensao = BC00113_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = BC00113_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            A257AssinaturaArquivoAssinadoNome = BC00113_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = BC00113_n257AssinaturaArquivoAssinadoNome[0];
            A240AssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = BC00113_A227ContratoId[0];
            n227ContratoId = BC00113_n227ContratoId[0];
            A231ArquivoId = BC00113_A231ArquivoId[0];
            n231ArquivoId = BC00113_n231ArquivoId[0];
            A578ArquivoAssinadoId = BC00113_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = BC00113_n578ArquivoAssinadoId[0];
            A240AssinaturaArquivoAssinado = BC00113_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = BC00113_n240AssinaturaArquivoAssinado[0];
            Z238AssinaturaId = A238AssinaturaId;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1140( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1140( ) ;
            }
            Gx_mode = sMode40;
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1140( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode40;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1140( ) ;
         if ( RcdFound40 == 0 )
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
         CONFIRM_110( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1140( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00112 */
            pr_default.execute(0, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Assinatura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z241AssinaturaPublicKey != BC00112_A241AssinaturaPublicKey[0] ) || ( StringUtil.StrCmp(Z239AssinaturaStatus, BC00112_A239AssinaturaStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z364AssinaturaPaginaConsulta, BC00112_A364AssinaturaPaginaConsulta[0]) != 0 ) || ( StringUtil.StrCmp(Z365AssinaturaToken, BC00112_A365AssinaturaToken[0]) != 0 ) || ( Z368AssinaturaMes != BC00112_A368AssinaturaMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z371AssinaturaMesNome, BC00112_A371AssinaturaMesNome[0]) != 0 ) || ( Z369AssinaturaAno != BC00112_A369AssinaturaAno[0] ) || ( Z366AssinaturaFinalizadoData != BC00112_A366AssinaturaFinalizadoData[0] ) || ( Z227ContratoId != BC00112_A227ContratoId[0] ) || ( Z231ArquivoId != BC00112_A231ArquivoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z578ArquivoAssinadoId != BC00112_A578ArquivoAssinadoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Assinatura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1140( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1140( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1140( 0) ;
            CheckOptimisticConcurrency1140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001112 */
                     pr_default.execute(8, new Object[] {n241AssinaturaPublicKey, A241AssinaturaPublicKey, n239AssinaturaStatus, A239AssinaturaStatus, n240AssinaturaArquivoAssinado, A240AssinaturaArquivoAssinado, n364AssinaturaPaginaConsulta, A364AssinaturaPaginaConsulta, n365AssinaturaToken, A365AssinaturaToken, n368AssinaturaMes, A368AssinaturaMes, n371AssinaturaMesNome, A371AssinaturaMesNome, n369AssinaturaAno, A369AssinaturaAno, n366AssinaturaFinalizadoData, A366AssinaturaFinalizadoData, n256AssinaturaArquivoAssinadoExtensao, A256AssinaturaArquivoAssinadoExtensao, n257AssinaturaArquivoAssinadoNome, A257AssinaturaArquivoAssinadoNome, n227ContratoId, A227ContratoId, n231ArquivoId, A231ArquivoId, n578ArquivoAssinadoId, A578ArquivoAssinadoId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001113 */
                     pr_default.execute(9);
                     A238AssinaturaId = BC001113_A238AssinaturaId[0];
                     n238AssinaturaId = BC001113_n238AssinaturaId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Assinatura");
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
               Load1140( ) ;
            }
            EndLevel1140( ) ;
         }
         CloseExtendedTableCursors1140( ) ;
      }

      protected void Update1140( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1140( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001114 */
                     pr_default.execute(10, new Object[] {n241AssinaturaPublicKey, A241AssinaturaPublicKey, n239AssinaturaStatus, A239AssinaturaStatus, n364AssinaturaPaginaConsulta, A364AssinaturaPaginaConsulta, n365AssinaturaToken, A365AssinaturaToken, n368AssinaturaMes, A368AssinaturaMes, n371AssinaturaMesNome, A371AssinaturaMesNome, n369AssinaturaAno, A369AssinaturaAno, n366AssinaturaFinalizadoData, A366AssinaturaFinalizadoData, n256AssinaturaArquivoAssinadoExtensao, A256AssinaturaArquivoAssinadoExtensao, n257AssinaturaArquivoAssinadoNome, A257AssinaturaArquivoAssinadoNome, n227ContratoId, A227ContratoId, n231ArquivoId, A231ArquivoId, n578ArquivoAssinadoId, A578ArquivoAssinadoId, n238AssinaturaId, A238AssinaturaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Assinatura");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Assinatura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1140( ) ;
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
            EndLevel1140( ) ;
         }
         CloseExtendedTableCursors1140( ) ;
      }

      protected void DeferredUpdate1140( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001115 */
            pr_default.execute(11, new Object[] {n240AssinaturaArquivoAssinado, A240AssinaturaArquivoAssinado, n238AssinaturaId, A238AssinaturaId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Assinatura");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1140( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1140( ) ;
            AfterConfirm1140( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1140( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001116 */
                  pr_default.execute(12, new Object[] {n238AssinaturaId, A238AssinaturaId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Assinatura");
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
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1140( ) ;
         Gx_mode = sMode40;
      }

      protected void OnDeleteControls1140( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001118 */
            pr_default.execute(13, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A367AssinaturaParticipantes_F = BC001118_A367AssinaturaParticipantes_F[0];
               n367AssinaturaParticipantes_F = BC001118_n367AssinaturaParticipantes_F[0];
            }
            else
            {
               A367AssinaturaParticipantes_F = 0;
               n367AssinaturaParticipantes_F = false;
            }
            pr_default.close(13);
            /* Using cursor BC001119 */
            pr_default.execute(14, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = BC001119_A228ContratoNome[0];
            n228ContratoNome = BC001119_n228ContratoNome[0];
            A362ContratoDataInicial = BC001119_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC001119_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC001119_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC001119_n363ContratoDataFinal[0];
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001120 */
            pr_default.execute(15, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC001121 */
            pr_default.execute(16, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel1140( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1140( ) ;
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

      public void ScanKeyStart1140( )
      {
         /* Scan By routine */
         /* Using cursor BC001123 */
         pr_default.execute(17, new Object[] {n238AssinaturaId, A238AssinaturaId});
         RcdFound40 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A238AssinaturaId = BC001123_A238AssinaturaId[0];
            n238AssinaturaId = BC001123_n238AssinaturaId[0];
            A241AssinaturaPublicKey = BC001123_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = BC001123_n241AssinaturaPublicKey[0];
            A239AssinaturaStatus = BC001123_A239AssinaturaStatus[0];
            n239AssinaturaStatus = BC001123_n239AssinaturaStatus[0];
            A228ContratoNome = BC001123_A228ContratoNome[0];
            n228ContratoNome = BC001123_n228ContratoNome[0];
            A362ContratoDataInicial = BC001123_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC001123_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC001123_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC001123_n363ContratoDataFinal[0];
            A364AssinaturaPaginaConsulta = BC001123_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = BC001123_n364AssinaturaPaginaConsulta[0];
            A365AssinaturaToken = BC001123_A365AssinaturaToken[0];
            n365AssinaturaToken = BC001123_n365AssinaturaToken[0];
            A368AssinaturaMes = BC001123_A368AssinaturaMes[0];
            n368AssinaturaMes = BC001123_n368AssinaturaMes[0];
            A371AssinaturaMesNome = BC001123_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = BC001123_n371AssinaturaMesNome[0];
            A369AssinaturaAno = BC001123_A369AssinaturaAno[0];
            n369AssinaturaAno = BC001123_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = BC001123_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = BC001123_n366AssinaturaFinalizadoData[0];
            A256AssinaturaArquivoAssinadoExtensao = BC001123_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = BC001123_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            A257AssinaturaArquivoAssinadoNome = BC001123_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = BC001123_n257AssinaturaArquivoAssinadoNome[0];
            A240AssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = BC001123_A227ContratoId[0];
            n227ContratoId = BC001123_n227ContratoId[0];
            A231ArquivoId = BC001123_A231ArquivoId[0];
            n231ArquivoId = BC001123_n231ArquivoId[0];
            A578ArquivoAssinadoId = BC001123_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = BC001123_n578ArquivoAssinadoId[0];
            A367AssinaturaParticipantes_F = BC001123_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = BC001123_n367AssinaturaParticipantes_F[0];
            A240AssinaturaArquivoAssinado = BC001123_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = BC001123_n240AssinaturaArquivoAssinado[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1140( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound40 = 0;
         ScanKeyLoad1140( ) ;
      }

      protected void ScanKeyLoad1140( )
      {
         sMode40 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound40 = 1;
            A238AssinaturaId = BC001123_A238AssinaturaId[0];
            n238AssinaturaId = BC001123_n238AssinaturaId[0];
            A241AssinaturaPublicKey = BC001123_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = BC001123_n241AssinaturaPublicKey[0];
            A239AssinaturaStatus = BC001123_A239AssinaturaStatus[0];
            n239AssinaturaStatus = BC001123_n239AssinaturaStatus[0];
            A228ContratoNome = BC001123_A228ContratoNome[0];
            n228ContratoNome = BC001123_n228ContratoNome[0];
            A362ContratoDataInicial = BC001123_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC001123_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC001123_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC001123_n363ContratoDataFinal[0];
            A364AssinaturaPaginaConsulta = BC001123_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = BC001123_n364AssinaturaPaginaConsulta[0];
            A365AssinaturaToken = BC001123_A365AssinaturaToken[0];
            n365AssinaturaToken = BC001123_n365AssinaturaToken[0];
            A368AssinaturaMes = BC001123_A368AssinaturaMes[0];
            n368AssinaturaMes = BC001123_n368AssinaturaMes[0];
            A371AssinaturaMesNome = BC001123_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = BC001123_n371AssinaturaMesNome[0];
            A369AssinaturaAno = BC001123_A369AssinaturaAno[0];
            n369AssinaturaAno = BC001123_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = BC001123_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = BC001123_n366AssinaturaFinalizadoData[0];
            A256AssinaturaArquivoAssinadoExtensao = BC001123_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = BC001123_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            A257AssinaturaArquivoAssinadoNome = BC001123_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = BC001123_n257AssinaturaArquivoAssinadoNome[0];
            A240AssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = BC001123_A227ContratoId[0];
            n227ContratoId = BC001123_n227ContratoId[0];
            A231ArquivoId = BC001123_A231ArquivoId[0];
            n231ArquivoId = BC001123_n231ArquivoId[0];
            A578ArquivoAssinadoId = BC001123_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = BC001123_n578ArquivoAssinadoId[0];
            A367AssinaturaParticipantes_F = BC001123_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = BC001123_n367AssinaturaParticipantes_F[0];
            A240AssinaturaArquivoAssinado = BC001123_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = BC001123_n240AssinaturaArquivoAssinado[0];
         }
         Gx_mode = sMode40;
      }

      protected void ScanKeyEnd1140( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1140( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1140( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1140( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1140( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1140( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1140( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1140( )
      {
      }

      protected void send_integrity_lvl_hashes1140( )
      {
      }

      protected void AddRow1140( )
      {
         VarsToRow40( bcAssinatura) ;
      }

      protected void ReadRow1140( )
      {
         RowToVars40( bcAssinatura, 1) ;
      }

      protected void InitializeNonKey1140( )
      {
         A239AssinaturaStatus = "";
         n239AssinaturaStatus = false;
         A227ContratoId = 0;
         n227ContratoId = false;
         A228ContratoNome = "";
         n228ContratoNome = false;
         A362ContratoDataInicial = DateTime.MinValue;
         n362ContratoDataInicial = false;
         A363ContratoDataFinal = DateTime.MinValue;
         n363ContratoDataFinal = false;
         A231ArquivoId = 0;
         n231ArquivoId = false;
         A578ArquivoAssinadoId = 0;
         n578ArquivoAssinadoId = false;
         A240AssinaturaArquivoAssinado = "";
         n240AssinaturaArquivoAssinado = false;
         A364AssinaturaPaginaConsulta = "";
         n364AssinaturaPaginaConsulta = false;
         A365AssinaturaToken = "";
         n365AssinaturaToken = false;
         A368AssinaturaMes = 0;
         n368AssinaturaMes = false;
         A371AssinaturaMesNome = "";
         n371AssinaturaMesNome = false;
         A369AssinaturaAno = 0;
         n369AssinaturaAno = false;
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         n366AssinaturaFinalizadoData = false;
         A367AssinaturaParticipantes_F = 0;
         n367AssinaturaParticipantes_F = false;
         A256AssinaturaArquivoAssinadoExtensao = "";
         n256AssinaturaArquivoAssinadoExtensao = false;
         A257AssinaturaArquivoAssinadoNome = "";
         n257AssinaturaArquivoAssinadoNome = false;
         A241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         Z241AssinaturaPublicKey = Guid.Empty;
         Z239AssinaturaStatus = "";
         Z364AssinaturaPaginaConsulta = "";
         Z365AssinaturaToken = "";
         Z368AssinaturaMes = 0;
         Z371AssinaturaMesNome = "";
         Z369AssinaturaAno = 0;
         Z366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         Z227ContratoId = 0;
         Z231ArquivoId = 0;
         Z578ArquivoAssinadoId = 0;
      }

      protected void InitAll1140( )
      {
         A238AssinaturaId = 0;
         n238AssinaturaId = false;
         InitializeNonKey1140( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A241AssinaturaPublicKey = i241AssinaturaPublicKey;
         n241AssinaturaPublicKey = false;
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

      public void VarsToRow40( SdtAssinatura obj40 )
      {
         obj40.gxTpr_Mode = Gx_mode;
         obj40.gxTpr_Assinaturastatus = A239AssinaturaStatus;
         obj40.gxTpr_Contratoid = A227ContratoId;
         obj40.gxTpr_Contratonome = A228ContratoNome;
         obj40.gxTpr_Contratodatainicial = A362ContratoDataInicial;
         obj40.gxTpr_Contratodatafinal = A363ContratoDataFinal;
         obj40.gxTpr_Arquivoid = A231ArquivoId;
         obj40.gxTpr_Arquivoassinadoid = A578ArquivoAssinadoId;
         obj40.gxTpr_Assinaturaarquivoassinado = A240AssinaturaArquivoAssinado;
         obj40.gxTpr_Assinaturapaginaconsulta = A364AssinaturaPaginaConsulta;
         obj40.gxTpr_Assinaturatoken = A365AssinaturaToken;
         obj40.gxTpr_Assinaturames = A368AssinaturaMes;
         obj40.gxTpr_Assinaturamesnome = A371AssinaturaMesNome;
         obj40.gxTpr_Assinaturaano = A369AssinaturaAno;
         obj40.gxTpr_Assinaturafinalizadodata = A366AssinaturaFinalizadoData;
         obj40.gxTpr_Assinaturaparticipantes_f = A367AssinaturaParticipantes_F;
         obj40.gxTpr_Assinaturaarquivoassinadoextensao = A256AssinaturaArquivoAssinadoExtensao;
         obj40.gxTpr_Assinaturaarquivoassinadonome = A257AssinaturaArquivoAssinadoNome;
         obj40.gxTpr_Assinaturapublickey = A241AssinaturaPublicKey;
         obj40.gxTpr_Assinaturaid = A238AssinaturaId;
         obj40.gxTpr_Assinaturaid_Z = Z238AssinaturaId;
         obj40.gxTpr_Assinaturastatus_Z = Z239AssinaturaStatus;
         obj40.gxTpr_Contratoid_Z = Z227ContratoId;
         obj40.gxTpr_Contratonome_Z = Z228ContratoNome;
         obj40.gxTpr_Contratodatainicial_Z = Z362ContratoDataInicial;
         obj40.gxTpr_Contratodatafinal_Z = Z363ContratoDataFinal;
         obj40.gxTpr_Arquivoid_Z = Z231ArquivoId;
         obj40.gxTpr_Arquivoassinadoid_Z = Z578ArquivoAssinadoId;
         obj40.gxTpr_Assinaturaarquivoassinadonome_Z = Z257AssinaturaArquivoAssinadoNome;
         obj40.gxTpr_Assinaturaarquivoassinadoextensao_Z = Z256AssinaturaArquivoAssinadoExtensao;
         obj40.gxTpr_Assinaturapublickey_Z = Z241AssinaturaPublicKey;
         obj40.gxTpr_Assinaturapaginaconsulta_Z = Z364AssinaturaPaginaConsulta;
         obj40.gxTpr_Assinaturatoken_Z = Z365AssinaturaToken;
         obj40.gxTpr_Assinaturames_Z = Z368AssinaturaMes;
         obj40.gxTpr_Assinaturamesnome_Z = Z371AssinaturaMesNome;
         obj40.gxTpr_Assinaturaano_Z = Z369AssinaturaAno;
         obj40.gxTpr_Assinaturafinalizadodata_Z = Z366AssinaturaFinalizadoData;
         obj40.gxTpr_Assinaturaparticipantes_f_Z = Z367AssinaturaParticipantes_F;
         obj40.gxTpr_Assinaturaid_N = (short)(Convert.ToInt16(n238AssinaturaId));
         obj40.gxTpr_Assinaturastatus_N = (short)(Convert.ToInt16(n239AssinaturaStatus));
         obj40.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj40.gxTpr_Contratonome_N = (short)(Convert.ToInt16(n228ContratoNome));
         obj40.gxTpr_Contratodatainicial_N = (short)(Convert.ToInt16(n362ContratoDataInicial));
         obj40.gxTpr_Contratodatafinal_N = (short)(Convert.ToInt16(n363ContratoDataFinal));
         obj40.gxTpr_Arquivoid_N = (short)(Convert.ToInt16(n231ArquivoId));
         obj40.gxTpr_Arquivoassinadoid_N = (short)(Convert.ToInt16(n578ArquivoAssinadoId));
         obj40.gxTpr_Assinaturaarquivoassinado_N = (short)(Convert.ToInt16(n240AssinaturaArquivoAssinado));
         obj40.gxTpr_Assinaturaarquivoassinadonome_N = (short)(Convert.ToInt16(n257AssinaturaArquivoAssinadoNome));
         obj40.gxTpr_Assinaturaarquivoassinadoextensao_N = (short)(Convert.ToInt16(n256AssinaturaArquivoAssinadoExtensao));
         obj40.gxTpr_Assinaturapublickey_N = (short)(Convert.ToInt16(n241AssinaturaPublicKey));
         obj40.gxTpr_Assinaturapaginaconsulta_N = (short)(Convert.ToInt16(n364AssinaturaPaginaConsulta));
         obj40.gxTpr_Assinaturatoken_N = (short)(Convert.ToInt16(n365AssinaturaToken));
         obj40.gxTpr_Assinaturames_N = (short)(Convert.ToInt16(n368AssinaturaMes));
         obj40.gxTpr_Assinaturamesnome_N = (short)(Convert.ToInt16(n371AssinaturaMesNome));
         obj40.gxTpr_Assinaturaano_N = (short)(Convert.ToInt16(n369AssinaturaAno));
         obj40.gxTpr_Assinaturafinalizadodata_N = (short)(Convert.ToInt16(n366AssinaturaFinalizadoData));
         obj40.gxTpr_Assinaturaparticipantes_f_N = (short)(Convert.ToInt16(n367AssinaturaParticipantes_F));
         obj40.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow40( SdtAssinatura obj40 )
      {
         obj40.gxTpr_Assinaturaid = A238AssinaturaId;
         return  ;
      }

      public void RowToVars40( SdtAssinatura obj40 ,
                               int forceLoad )
      {
         Gx_mode = obj40.gxTpr_Mode;
         A239AssinaturaStatus = obj40.gxTpr_Assinaturastatus;
         n239AssinaturaStatus = false;
         A227ContratoId = obj40.gxTpr_Contratoid;
         n227ContratoId = false;
         A228ContratoNome = obj40.gxTpr_Contratonome;
         n228ContratoNome = false;
         A362ContratoDataInicial = obj40.gxTpr_Contratodatainicial;
         n362ContratoDataInicial = false;
         A363ContratoDataFinal = obj40.gxTpr_Contratodatafinal;
         n363ContratoDataFinal = false;
         A231ArquivoId = obj40.gxTpr_Arquivoid;
         n231ArquivoId = false;
         A578ArquivoAssinadoId = obj40.gxTpr_Arquivoassinadoid;
         n578ArquivoAssinadoId = false;
         A240AssinaturaArquivoAssinado = obj40.gxTpr_Assinaturaarquivoassinado;
         n240AssinaturaArquivoAssinado = false;
         A364AssinaturaPaginaConsulta = obj40.gxTpr_Assinaturapaginaconsulta;
         n364AssinaturaPaginaConsulta = false;
         A365AssinaturaToken = obj40.gxTpr_Assinaturatoken;
         n365AssinaturaToken = false;
         A368AssinaturaMes = obj40.gxTpr_Assinaturames;
         n368AssinaturaMes = false;
         A371AssinaturaMesNome = obj40.gxTpr_Assinaturamesnome;
         n371AssinaturaMesNome = false;
         A369AssinaturaAno = obj40.gxTpr_Assinaturaano;
         n369AssinaturaAno = false;
         A366AssinaturaFinalizadoData = obj40.gxTpr_Assinaturafinalizadodata;
         n366AssinaturaFinalizadoData = false;
         A367AssinaturaParticipantes_F = obj40.gxTpr_Assinaturaparticipantes_f;
         n367AssinaturaParticipantes_F = false;
         A256AssinaturaArquivoAssinadoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( obj40.gxTpr_Assinaturaarquivoassinadoextensao)) ? FileUtil.GetFileType( A240AssinaturaArquivoAssinado) : obj40.gxTpr_Assinaturaarquivoassinadoextensao);
         n256AssinaturaArquivoAssinadoExtensao = false;
         A257AssinaturaArquivoAssinadoNome = (String.IsNullOrEmpty(StringUtil.RTrim( obj40.gxTpr_Assinaturaarquivoassinadonome)) ? FileUtil.GetFileName( A240AssinaturaArquivoAssinado) : obj40.gxTpr_Assinaturaarquivoassinadonome);
         n257AssinaturaArquivoAssinadoNome = false;
         A241AssinaturaPublicKey = obj40.gxTpr_Assinaturapublickey;
         n241AssinaturaPublicKey = false;
         A238AssinaturaId = obj40.gxTpr_Assinaturaid;
         n238AssinaturaId = false;
         Z238AssinaturaId = obj40.gxTpr_Assinaturaid_Z;
         Z239AssinaturaStatus = obj40.gxTpr_Assinaturastatus_Z;
         Z227ContratoId = obj40.gxTpr_Contratoid_Z;
         Z228ContratoNome = obj40.gxTpr_Contratonome_Z;
         Z362ContratoDataInicial = obj40.gxTpr_Contratodatainicial_Z;
         Z363ContratoDataFinal = obj40.gxTpr_Contratodatafinal_Z;
         Z231ArquivoId = obj40.gxTpr_Arquivoid_Z;
         Z578ArquivoAssinadoId = obj40.gxTpr_Arquivoassinadoid_Z;
         Z257AssinaturaArquivoAssinadoNome = obj40.gxTpr_Assinaturaarquivoassinadonome_Z;
         Z256AssinaturaArquivoAssinadoExtensao = obj40.gxTpr_Assinaturaarquivoassinadoextensao_Z;
         Z241AssinaturaPublicKey = obj40.gxTpr_Assinaturapublickey_Z;
         Z364AssinaturaPaginaConsulta = obj40.gxTpr_Assinaturapaginaconsulta_Z;
         Z365AssinaturaToken = obj40.gxTpr_Assinaturatoken_Z;
         Z368AssinaturaMes = obj40.gxTpr_Assinaturames_Z;
         Z371AssinaturaMesNome = obj40.gxTpr_Assinaturamesnome_Z;
         Z369AssinaturaAno = obj40.gxTpr_Assinaturaano_Z;
         Z366AssinaturaFinalizadoData = obj40.gxTpr_Assinaturafinalizadodata_Z;
         Z367AssinaturaParticipantes_F = obj40.gxTpr_Assinaturaparticipantes_f_Z;
         n238AssinaturaId = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaid_N));
         n239AssinaturaStatus = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturastatus_N));
         n227ContratoId = (bool)(Convert.ToBoolean(obj40.gxTpr_Contratoid_N));
         n228ContratoNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Contratonome_N));
         n362ContratoDataInicial = (bool)(Convert.ToBoolean(obj40.gxTpr_Contratodatainicial_N));
         n363ContratoDataFinal = (bool)(Convert.ToBoolean(obj40.gxTpr_Contratodatafinal_N));
         n231ArquivoId = (bool)(Convert.ToBoolean(obj40.gxTpr_Arquivoid_N));
         n578ArquivoAssinadoId = (bool)(Convert.ToBoolean(obj40.gxTpr_Arquivoassinadoid_N));
         n240AssinaturaArquivoAssinado = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaarquivoassinado_N));
         n257AssinaturaArquivoAssinadoNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaarquivoassinadonome_N));
         n256AssinaturaArquivoAssinadoExtensao = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaarquivoassinadoextensao_N));
         n241AssinaturaPublicKey = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturapublickey_N));
         n364AssinaturaPaginaConsulta = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturapaginaconsulta_N));
         n365AssinaturaToken = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturatoken_N));
         n368AssinaturaMes = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturames_N));
         n371AssinaturaMesNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturamesnome_N));
         n369AssinaturaAno = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaano_N));
         n366AssinaturaFinalizadoData = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturafinalizadodata_N));
         n367AssinaturaParticipantes_F = (bool)(Convert.ToBoolean(obj40.gxTpr_Assinaturaparticipantes_f_N));
         Gx_mode = obj40.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A238AssinaturaId = (long)getParm(obj,0);
         n238AssinaturaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1140( ) ;
         ScanKeyStart1140( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z238AssinaturaId = A238AssinaturaId;
         }
         ZM1140( -8) ;
         OnLoadActions1140( ) ;
         AddRow1140( ) ;
         ScanKeyEnd1140( ) ;
         if ( RcdFound40 == 0 )
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
         RowToVars40( bcAssinatura, 0) ;
         ScanKeyStart1140( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z238AssinaturaId = A238AssinaturaId;
         }
         ZM1140( -8) ;
         OnLoadActions1140( ) ;
         AddRow1140( ) ;
         ScanKeyEnd1140( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1140( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1140( ) ;
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( A238AssinaturaId != Z238AssinaturaId )
               {
                  A238AssinaturaId = Z238AssinaturaId;
                  n238AssinaturaId = false;
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
                  Update1140( ) ;
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
                  if ( A238AssinaturaId != Z238AssinaturaId )
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
                        Insert1140( ) ;
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
                        Insert1140( ) ;
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
         RowToVars40( bcAssinatura, 1) ;
         SaveImpl( ) ;
         VarsToRow40( bcAssinatura) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars40( bcAssinatura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1140( ) ;
         AfterTrn( ) ;
         VarsToRow40( bcAssinatura) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow40( bcAssinatura) ;
         }
         else
         {
            SdtAssinatura auxBC = new SdtAssinatura(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A238AssinaturaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAssinatura);
               auxBC.Save();
               bcAssinatura.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars40( bcAssinatura, 1) ;
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
         RowToVars40( bcAssinatura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1140( ) ;
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
               VarsToRow40( bcAssinatura) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow40( bcAssinatura) ;
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
         RowToVars40( bcAssinatura, 0) ;
         GetKey1140( ) ;
         if ( RcdFound40 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A238AssinaturaId != Z238AssinaturaId )
            {
               A238AssinaturaId = Z238AssinaturaId;
               n238AssinaturaId = false;
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
            if ( A238AssinaturaId != Z238AssinaturaId )
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
         context.RollbackDataStores("assinatura_bc",pr_default);
         VarsToRow40( bcAssinatura) ;
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
         Gx_mode = bcAssinatura.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAssinatura.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAssinatura )
         {
            bcAssinatura = (SdtAssinatura)(sdt);
            if ( StringUtil.StrCmp(bcAssinatura.gxTpr_Mode, "") == 0 )
            {
               bcAssinatura.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow40( bcAssinatura) ;
            }
            else
            {
               RowToVars40( bcAssinatura, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAssinatura.gxTpr_Mode, "") == 0 )
            {
               bcAssinatura.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars40( bcAssinatura, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAssinatura Assinatura_BC
      {
         get {
            return bcAssinatura ;
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
         pr_default.close(14);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV23Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z241AssinaturaPublicKey = Guid.Empty;
         A241AssinaturaPublicKey = Guid.Empty;
         Z239AssinaturaStatus = "";
         A239AssinaturaStatus = "";
         Z364AssinaturaPaginaConsulta = "";
         A364AssinaturaPaginaConsulta = "";
         Z365AssinaturaToken = "";
         A365AssinaturaToken = "";
         Z371AssinaturaMesNome = "";
         A371AssinaturaMesNome = "";
         Z366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         Z228ContratoNome = "";
         A228ContratoNome = "";
         Z362ContratoDataInicial = DateTime.MinValue;
         A362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         Z240AssinaturaArquivoAssinado = "";
         A240AssinaturaArquivoAssinado = "";
         Z256AssinaturaArquivoAssinadoExtensao = "";
         A256AssinaturaArquivoAssinadoExtensao = "";
         Z257AssinaturaArquivoAssinadoNome = "";
         A257AssinaturaArquivoAssinadoNome = "";
         BC001110_A238AssinaturaId = new long[1] ;
         BC001110_n238AssinaturaId = new bool[] {false} ;
         BC001110_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         BC001110_n241AssinaturaPublicKey = new bool[] {false} ;
         BC001110_A239AssinaturaStatus = new string[] {""} ;
         BC001110_n239AssinaturaStatus = new bool[] {false} ;
         BC001110_A228ContratoNome = new string[] {""} ;
         BC001110_n228ContratoNome = new bool[] {false} ;
         BC001110_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC001110_n362ContratoDataInicial = new bool[] {false} ;
         BC001110_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC001110_n363ContratoDataFinal = new bool[] {false} ;
         BC001110_A364AssinaturaPaginaConsulta = new string[] {""} ;
         BC001110_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         BC001110_A365AssinaturaToken = new string[] {""} ;
         BC001110_n365AssinaturaToken = new bool[] {false} ;
         BC001110_A368AssinaturaMes = new short[1] ;
         BC001110_n368AssinaturaMes = new bool[] {false} ;
         BC001110_A371AssinaturaMesNome = new string[] {""} ;
         BC001110_n371AssinaturaMesNome = new bool[] {false} ;
         BC001110_A369AssinaturaAno = new short[1] ;
         BC001110_n369AssinaturaAno = new bool[] {false} ;
         BC001110_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         BC001110_n366AssinaturaFinalizadoData = new bool[] {false} ;
         BC001110_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         BC001110_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         BC001110_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         BC001110_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         BC001110_A227ContratoId = new int[1] ;
         BC001110_n227ContratoId = new bool[] {false} ;
         BC001110_A231ArquivoId = new int[1] ;
         BC001110_n231ArquivoId = new bool[] {false} ;
         BC001110_A578ArquivoAssinadoId = new int[1] ;
         BC001110_n578ArquivoAssinadoId = new bool[] {false} ;
         BC001110_A367AssinaturaParticipantes_F = new short[1] ;
         BC001110_n367AssinaturaParticipantes_F = new bool[] {false} ;
         BC001110_A240AssinaturaArquivoAssinado = new string[] {""} ;
         BC001110_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         A240AssinaturaArquivoAssinado_Filetype = "";
         A240AssinaturaArquivoAssinado_Filename = "";
         BC00118_A367AssinaturaParticipantes_F = new short[1] ;
         BC00118_n367AssinaturaParticipantes_F = new bool[] {false} ;
         BC00114_A228ContratoNome = new string[] {""} ;
         BC00114_n228ContratoNome = new bool[] {false} ;
         BC00114_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC00114_n362ContratoDataInicial = new bool[] {false} ;
         BC00114_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC00114_n363ContratoDataFinal = new bool[] {false} ;
         BC00115_A231ArquivoId = new int[1] ;
         BC00115_n231ArquivoId = new bool[] {false} ;
         BC00116_A578ArquivoAssinadoId = new int[1] ;
         BC00116_n578ArquivoAssinadoId = new bool[] {false} ;
         BC001111_A238AssinaturaId = new long[1] ;
         BC001111_n238AssinaturaId = new bool[] {false} ;
         BC00113_A238AssinaturaId = new long[1] ;
         BC00113_n238AssinaturaId = new bool[] {false} ;
         BC00113_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         BC00113_n241AssinaturaPublicKey = new bool[] {false} ;
         BC00113_A239AssinaturaStatus = new string[] {""} ;
         BC00113_n239AssinaturaStatus = new bool[] {false} ;
         BC00113_A364AssinaturaPaginaConsulta = new string[] {""} ;
         BC00113_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         BC00113_A365AssinaturaToken = new string[] {""} ;
         BC00113_n365AssinaturaToken = new bool[] {false} ;
         BC00113_A368AssinaturaMes = new short[1] ;
         BC00113_n368AssinaturaMes = new bool[] {false} ;
         BC00113_A371AssinaturaMesNome = new string[] {""} ;
         BC00113_n371AssinaturaMesNome = new bool[] {false} ;
         BC00113_A369AssinaturaAno = new short[1] ;
         BC00113_n369AssinaturaAno = new bool[] {false} ;
         BC00113_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         BC00113_n366AssinaturaFinalizadoData = new bool[] {false} ;
         BC00113_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         BC00113_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         BC00113_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         BC00113_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         BC00113_A227ContratoId = new int[1] ;
         BC00113_n227ContratoId = new bool[] {false} ;
         BC00113_A231ArquivoId = new int[1] ;
         BC00113_n231ArquivoId = new bool[] {false} ;
         BC00113_A578ArquivoAssinadoId = new int[1] ;
         BC00113_n578ArquivoAssinadoId = new bool[] {false} ;
         BC00113_A240AssinaturaArquivoAssinado = new string[] {""} ;
         BC00113_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         sMode40 = "";
         BC00112_A238AssinaturaId = new long[1] ;
         BC00112_n238AssinaturaId = new bool[] {false} ;
         BC00112_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         BC00112_n241AssinaturaPublicKey = new bool[] {false} ;
         BC00112_A239AssinaturaStatus = new string[] {""} ;
         BC00112_n239AssinaturaStatus = new bool[] {false} ;
         BC00112_A364AssinaturaPaginaConsulta = new string[] {""} ;
         BC00112_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         BC00112_A365AssinaturaToken = new string[] {""} ;
         BC00112_n365AssinaturaToken = new bool[] {false} ;
         BC00112_A368AssinaturaMes = new short[1] ;
         BC00112_n368AssinaturaMes = new bool[] {false} ;
         BC00112_A371AssinaturaMesNome = new string[] {""} ;
         BC00112_n371AssinaturaMesNome = new bool[] {false} ;
         BC00112_A369AssinaturaAno = new short[1] ;
         BC00112_n369AssinaturaAno = new bool[] {false} ;
         BC00112_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         BC00112_n366AssinaturaFinalizadoData = new bool[] {false} ;
         BC00112_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         BC00112_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         BC00112_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         BC00112_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         BC00112_A227ContratoId = new int[1] ;
         BC00112_n227ContratoId = new bool[] {false} ;
         BC00112_A231ArquivoId = new int[1] ;
         BC00112_n231ArquivoId = new bool[] {false} ;
         BC00112_A578ArquivoAssinadoId = new int[1] ;
         BC00112_n578ArquivoAssinadoId = new bool[] {false} ;
         BC00112_A240AssinaturaArquivoAssinado = new string[] {""} ;
         BC00112_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         BC001113_A238AssinaturaId = new long[1] ;
         BC001113_n238AssinaturaId = new bool[] {false} ;
         BC001118_A367AssinaturaParticipantes_F = new short[1] ;
         BC001118_n367AssinaturaParticipantes_F = new bool[] {false} ;
         BC001119_A228ContratoNome = new string[] {""} ;
         BC001119_n228ContratoNome = new bool[] {false} ;
         BC001119_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC001119_n362ContratoDataInicial = new bool[] {false} ;
         BC001119_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC001119_n363ContratoDataFinal = new bool[] {false} ;
         BC001120_A572PropostaContratoAssinaturaId = new int[1] ;
         BC001121_A242AssinaturaParticipanteId = new int[1] ;
         BC001123_A238AssinaturaId = new long[1] ;
         BC001123_n238AssinaturaId = new bool[] {false} ;
         BC001123_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         BC001123_n241AssinaturaPublicKey = new bool[] {false} ;
         BC001123_A239AssinaturaStatus = new string[] {""} ;
         BC001123_n239AssinaturaStatus = new bool[] {false} ;
         BC001123_A228ContratoNome = new string[] {""} ;
         BC001123_n228ContratoNome = new bool[] {false} ;
         BC001123_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC001123_n362ContratoDataInicial = new bool[] {false} ;
         BC001123_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC001123_n363ContratoDataFinal = new bool[] {false} ;
         BC001123_A364AssinaturaPaginaConsulta = new string[] {""} ;
         BC001123_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         BC001123_A365AssinaturaToken = new string[] {""} ;
         BC001123_n365AssinaturaToken = new bool[] {false} ;
         BC001123_A368AssinaturaMes = new short[1] ;
         BC001123_n368AssinaturaMes = new bool[] {false} ;
         BC001123_A371AssinaturaMesNome = new string[] {""} ;
         BC001123_n371AssinaturaMesNome = new bool[] {false} ;
         BC001123_A369AssinaturaAno = new short[1] ;
         BC001123_n369AssinaturaAno = new bool[] {false} ;
         BC001123_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         BC001123_n366AssinaturaFinalizadoData = new bool[] {false} ;
         BC001123_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         BC001123_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         BC001123_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         BC001123_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         BC001123_A227ContratoId = new int[1] ;
         BC001123_n227ContratoId = new bool[] {false} ;
         BC001123_A231ArquivoId = new int[1] ;
         BC001123_n231ArquivoId = new bool[] {false} ;
         BC001123_A578ArquivoAssinadoId = new int[1] ;
         BC001123_n578ArquivoAssinadoId = new bool[] {false} ;
         BC001123_A367AssinaturaParticipantes_F = new short[1] ;
         BC001123_n367AssinaturaParticipantes_F = new bool[] {false} ;
         BC001123_A240AssinaturaArquivoAssinado = new string[] {""} ;
         BC001123_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         i241AssinaturaPublicKey = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinatura_bc__default(),
            new Object[][] {
                new Object[] {
               BC00112_A238AssinaturaId, BC00112_A241AssinaturaPublicKey, BC00112_n241AssinaturaPublicKey, BC00112_A239AssinaturaStatus, BC00112_n239AssinaturaStatus, BC00112_A364AssinaturaPaginaConsulta, BC00112_n364AssinaturaPaginaConsulta, BC00112_A365AssinaturaToken, BC00112_n365AssinaturaToken, BC00112_A368AssinaturaMes,
               BC00112_n368AssinaturaMes, BC00112_A371AssinaturaMesNome, BC00112_n371AssinaturaMesNome, BC00112_A369AssinaturaAno, BC00112_n369AssinaturaAno, BC00112_A366AssinaturaFinalizadoData, BC00112_n366AssinaturaFinalizadoData, BC00112_A256AssinaturaArquivoAssinadoExtensao, BC00112_n256AssinaturaArquivoAssinadoExtensao, BC00112_A257AssinaturaArquivoAssinadoNome,
               BC00112_n257AssinaturaArquivoAssinadoNome, BC00112_A227ContratoId, BC00112_n227ContratoId, BC00112_A231ArquivoId, BC00112_n231ArquivoId, BC00112_A578ArquivoAssinadoId, BC00112_n578ArquivoAssinadoId, BC00112_A240AssinaturaArquivoAssinado, BC00112_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               BC00113_A238AssinaturaId, BC00113_A241AssinaturaPublicKey, BC00113_n241AssinaturaPublicKey, BC00113_A239AssinaturaStatus, BC00113_n239AssinaturaStatus, BC00113_A364AssinaturaPaginaConsulta, BC00113_n364AssinaturaPaginaConsulta, BC00113_A365AssinaturaToken, BC00113_n365AssinaturaToken, BC00113_A368AssinaturaMes,
               BC00113_n368AssinaturaMes, BC00113_A371AssinaturaMesNome, BC00113_n371AssinaturaMesNome, BC00113_A369AssinaturaAno, BC00113_n369AssinaturaAno, BC00113_A366AssinaturaFinalizadoData, BC00113_n366AssinaturaFinalizadoData, BC00113_A256AssinaturaArquivoAssinadoExtensao, BC00113_n256AssinaturaArquivoAssinadoExtensao, BC00113_A257AssinaturaArquivoAssinadoNome,
               BC00113_n257AssinaturaArquivoAssinadoNome, BC00113_A227ContratoId, BC00113_n227ContratoId, BC00113_A231ArquivoId, BC00113_n231ArquivoId, BC00113_A578ArquivoAssinadoId, BC00113_n578ArquivoAssinadoId, BC00113_A240AssinaturaArquivoAssinado, BC00113_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               BC00114_A228ContratoNome, BC00114_n228ContratoNome, BC00114_A362ContratoDataInicial, BC00114_n362ContratoDataInicial, BC00114_A363ContratoDataFinal, BC00114_n363ContratoDataFinal
               }
               , new Object[] {
               BC00115_A231ArquivoId
               }
               , new Object[] {
               BC00116_A578ArquivoAssinadoId
               }
               , new Object[] {
               BC00118_A367AssinaturaParticipantes_F, BC00118_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               BC001110_A238AssinaturaId, BC001110_A241AssinaturaPublicKey, BC001110_n241AssinaturaPublicKey, BC001110_A239AssinaturaStatus, BC001110_n239AssinaturaStatus, BC001110_A228ContratoNome, BC001110_n228ContratoNome, BC001110_A362ContratoDataInicial, BC001110_n362ContratoDataInicial, BC001110_A363ContratoDataFinal,
               BC001110_n363ContratoDataFinal, BC001110_A364AssinaturaPaginaConsulta, BC001110_n364AssinaturaPaginaConsulta, BC001110_A365AssinaturaToken, BC001110_n365AssinaturaToken, BC001110_A368AssinaturaMes, BC001110_n368AssinaturaMes, BC001110_A371AssinaturaMesNome, BC001110_n371AssinaturaMesNome, BC001110_A369AssinaturaAno,
               BC001110_n369AssinaturaAno, BC001110_A366AssinaturaFinalizadoData, BC001110_n366AssinaturaFinalizadoData, BC001110_A256AssinaturaArquivoAssinadoExtensao, BC001110_n256AssinaturaArquivoAssinadoExtensao, BC001110_A257AssinaturaArquivoAssinadoNome, BC001110_n257AssinaturaArquivoAssinadoNome, BC001110_A227ContratoId, BC001110_n227ContratoId, BC001110_A231ArquivoId,
               BC001110_n231ArquivoId, BC001110_A578ArquivoAssinadoId, BC001110_n578ArquivoAssinadoId, BC001110_A367AssinaturaParticipantes_F, BC001110_n367AssinaturaParticipantes_F, BC001110_A240AssinaturaArquivoAssinado, BC001110_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               BC001111_A238AssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001113_A238AssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001118_A367AssinaturaParticipantes_F, BC001118_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               BC001119_A228ContratoNome, BC001119_n228ContratoNome, BC001119_A362ContratoDataInicial, BC001119_n362ContratoDataInicial, BC001119_A363ContratoDataFinal, BC001119_n363ContratoDataFinal
               }
               , new Object[] {
               BC001120_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC001121_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC001123_A238AssinaturaId, BC001123_A241AssinaturaPublicKey, BC001123_n241AssinaturaPublicKey, BC001123_A239AssinaturaStatus, BC001123_n239AssinaturaStatus, BC001123_A228ContratoNome, BC001123_n228ContratoNome, BC001123_A362ContratoDataInicial, BC001123_n362ContratoDataInicial, BC001123_A363ContratoDataFinal,
               BC001123_n363ContratoDataFinal, BC001123_A364AssinaturaPaginaConsulta, BC001123_n364AssinaturaPaginaConsulta, BC001123_A365AssinaturaToken, BC001123_n365AssinaturaToken, BC001123_A368AssinaturaMes, BC001123_n368AssinaturaMes, BC001123_A371AssinaturaMesNome, BC001123_n371AssinaturaMesNome, BC001123_A369AssinaturaAno,
               BC001123_n369AssinaturaAno, BC001123_A366AssinaturaFinalizadoData, BC001123_n366AssinaturaFinalizadoData, BC001123_A256AssinaturaArquivoAssinadoExtensao, BC001123_n256AssinaturaArquivoAssinadoExtensao, BC001123_A257AssinaturaArquivoAssinadoNome, BC001123_n257AssinaturaArquivoAssinadoNome, BC001123_A227ContratoId, BC001123_n227ContratoId, BC001123_A231ArquivoId,
               BC001123_n231ArquivoId, BC001123_A578ArquivoAssinadoId, BC001123_n578ArquivoAssinadoId, BC001123_A367AssinaturaParticipantes_F, BC001123_n367AssinaturaParticipantes_F, BC001123_A240AssinaturaArquivoAssinado, BC001123_n240AssinaturaArquivoAssinado
               }
            }
         );
         Z241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         A241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         i241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         AV23Pgmname = "Assinatura_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12112 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z368AssinaturaMes ;
      private short A368AssinaturaMes ;
      private short Z369AssinaturaAno ;
      private short A369AssinaturaAno ;
      private short Z367AssinaturaParticipantes_F ;
      private short A367AssinaturaParticipantes_F ;
      private short Gx_BScreen ;
      private short RcdFound40 ;
      private int trnEnded ;
      private int AV24GXV1 ;
      private int AV11Insert_ContratoId ;
      private int AV12Insert_ArquivoId ;
      private int AV22Insert_ArquivoAssinadoId ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private int Z231ArquivoId ;
      private int A231ArquivoId ;
      private int Z578ArquivoAssinadoId ;
      private int A578ArquivoAssinadoId ;
      private long Z238AssinaturaId ;
      private long A238AssinaturaId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string A240AssinaturaArquivoAssinado_Filetype ;
      private string A240AssinaturaArquivoAssinado_Filename ;
      private string sMode40 ;
      private DateTime Z366AssinaturaFinalizadoData ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime Z362ContratoDataInicial ;
      private DateTime A362ContratoDataInicial ;
      private DateTime Z363ContratoDataFinal ;
      private DateTime A363ContratoDataFinal ;
      private bool returnInSub ;
      private bool n241AssinaturaPublicKey ;
      private bool n238AssinaturaId ;
      private bool n239AssinaturaStatus ;
      private bool n228ContratoNome ;
      private bool n362ContratoDataInicial ;
      private bool n363ContratoDataFinal ;
      private bool n364AssinaturaPaginaConsulta ;
      private bool n365AssinaturaToken ;
      private bool n368AssinaturaMes ;
      private bool n371AssinaturaMesNome ;
      private bool n369AssinaturaAno ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n256AssinaturaArquivoAssinadoExtensao ;
      private bool n257AssinaturaArquivoAssinadoNome ;
      private bool n227ContratoId ;
      private bool n231ArquivoId ;
      private bool n578ArquivoAssinadoId ;
      private bool n367AssinaturaParticipantes_F ;
      private bool n240AssinaturaArquivoAssinado ;
      private bool Gx_longc ;
      private string Z239AssinaturaStatus ;
      private string A239AssinaturaStatus ;
      private string Z364AssinaturaPaginaConsulta ;
      private string A364AssinaturaPaginaConsulta ;
      private string Z365AssinaturaToken ;
      private string A365AssinaturaToken ;
      private string Z371AssinaturaMesNome ;
      private string A371AssinaturaMesNome ;
      private string Z228ContratoNome ;
      private string A228ContratoNome ;
      private string Z256AssinaturaArquivoAssinadoExtensao ;
      private string A256AssinaturaArquivoAssinadoExtensao ;
      private string Z257AssinaturaArquivoAssinadoNome ;
      private string A257AssinaturaArquivoAssinadoNome ;
      private Guid Z241AssinaturaPublicKey ;
      private Guid A241AssinaturaPublicKey ;
      private Guid i241AssinaturaPublicKey ;
      private string Z240AssinaturaArquivoAssinado ;
      private string A240AssinaturaArquivoAssinado ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC001110_A238AssinaturaId ;
      private bool[] BC001110_n238AssinaturaId ;
      private Guid[] BC001110_A241AssinaturaPublicKey ;
      private bool[] BC001110_n241AssinaturaPublicKey ;
      private string[] BC001110_A239AssinaturaStatus ;
      private bool[] BC001110_n239AssinaturaStatus ;
      private string[] BC001110_A228ContratoNome ;
      private bool[] BC001110_n228ContratoNome ;
      private DateTime[] BC001110_A362ContratoDataInicial ;
      private bool[] BC001110_n362ContratoDataInicial ;
      private DateTime[] BC001110_A363ContratoDataFinal ;
      private bool[] BC001110_n363ContratoDataFinal ;
      private string[] BC001110_A364AssinaturaPaginaConsulta ;
      private bool[] BC001110_n364AssinaturaPaginaConsulta ;
      private string[] BC001110_A365AssinaturaToken ;
      private bool[] BC001110_n365AssinaturaToken ;
      private short[] BC001110_A368AssinaturaMes ;
      private bool[] BC001110_n368AssinaturaMes ;
      private string[] BC001110_A371AssinaturaMesNome ;
      private bool[] BC001110_n371AssinaturaMesNome ;
      private short[] BC001110_A369AssinaturaAno ;
      private bool[] BC001110_n369AssinaturaAno ;
      private DateTime[] BC001110_A366AssinaturaFinalizadoData ;
      private bool[] BC001110_n366AssinaturaFinalizadoData ;
      private string[] BC001110_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] BC001110_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] BC001110_A257AssinaturaArquivoAssinadoNome ;
      private bool[] BC001110_n257AssinaturaArquivoAssinadoNome ;
      private int[] BC001110_A227ContratoId ;
      private bool[] BC001110_n227ContratoId ;
      private int[] BC001110_A231ArquivoId ;
      private bool[] BC001110_n231ArquivoId ;
      private int[] BC001110_A578ArquivoAssinadoId ;
      private bool[] BC001110_n578ArquivoAssinadoId ;
      private short[] BC001110_A367AssinaturaParticipantes_F ;
      private bool[] BC001110_n367AssinaturaParticipantes_F ;
      private string[] BC001110_A240AssinaturaArquivoAssinado ;
      private bool[] BC001110_n240AssinaturaArquivoAssinado ;
      private short[] BC00118_A367AssinaturaParticipantes_F ;
      private bool[] BC00118_n367AssinaturaParticipantes_F ;
      private string[] BC00114_A228ContratoNome ;
      private bool[] BC00114_n228ContratoNome ;
      private DateTime[] BC00114_A362ContratoDataInicial ;
      private bool[] BC00114_n362ContratoDataInicial ;
      private DateTime[] BC00114_A363ContratoDataFinal ;
      private bool[] BC00114_n363ContratoDataFinal ;
      private int[] BC00115_A231ArquivoId ;
      private bool[] BC00115_n231ArquivoId ;
      private int[] BC00116_A578ArquivoAssinadoId ;
      private bool[] BC00116_n578ArquivoAssinadoId ;
      private long[] BC001111_A238AssinaturaId ;
      private bool[] BC001111_n238AssinaturaId ;
      private long[] BC00113_A238AssinaturaId ;
      private bool[] BC00113_n238AssinaturaId ;
      private Guid[] BC00113_A241AssinaturaPublicKey ;
      private bool[] BC00113_n241AssinaturaPublicKey ;
      private string[] BC00113_A239AssinaturaStatus ;
      private bool[] BC00113_n239AssinaturaStatus ;
      private string[] BC00113_A364AssinaturaPaginaConsulta ;
      private bool[] BC00113_n364AssinaturaPaginaConsulta ;
      private string[] BC00113_A365AssinaturaToken ;
      private bool[] BC00113_n365AssinaturaToken ;
      private short[] BC00113_A368AssinaturaMes ;
      private bool[] BC00113_n368AssinaturaMes ;
      private string[] BC00113_A371AssinaturaMesNome ;
      private bool[] BC00113_n371AssinaturaMesNome ;
      private short[] BC00113_A369AssinaturaAno ;
      private bool[] BC00113_n369AssinaturaAno ;
      private DateTime[] BC00113_A366AssinaturaFinalizadoData ;
      private bool[] BC00113_n366AssinaturaFinalizadoData ;
      private string[] BC00113_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] BC00113_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] BC00113_A257AssinaturaArquivoAssinadoNome ;
      private bool[] BC00113_n257AssinaturaArquivoAssinadoNome ;
      private int[] BC00113_A227ContratoId ;
      private bool[] BC00113_n227ContratoId ;
      private int[] BC00113_A231ArquivoId ;
      private bool[] BC00113_n231ArquivoId ;
      private int[] BC00113_A578ArquivoAssinadoId ;
      private bool[] BC00113_n578ArquivoAssinadoId ;
      private string[] BC00113_A240AssinaturaArquivoAssinado ;
      private bool[] BC00113_n240AssinaturaArquivoAssinado ;
      private long[] BC00112_A238AssinaturaId ;
      private bool[] BC00112_n238AssinaturaId ;
      private Guid[] BC00112_A241AssinaturaPublicKey ;
      private bool[] BC00112_n241AssinaturaPublicKey ;
      private string[] BC00112_A239AssinaturaStatus ;
      private bool[] BC00112_n239AssinaturaStatus ;
      private string[] BC00112_A364AssinaturaPaginaConsulta ;
      private bool[] BC00112_n364AssinaturaPaginaConsulta ;
      private string[] BC00112_A365AssinaturaToken ;
      private bool[] BC00112_n365AssinaturaToken ;
      private short[] BC00112_A368AssinaturaMes ;
      private bool[] BC00112_n368AssinaturaMes ;
      private string[] BC00112_A371AssinaturaMesNome ;
      private bool[] BC00112_n371AssinaturaMesNome ;
      private short[] BC00112_A369AssinaturaAno ;
      private bool[] BC00112_n369AssinaturaAno ;
      private DateTime[] BC00112_A366AssinaturaFinalizadoData ;
      private bool[] BC00112_n366AssinaturaFinalizadoData ;
      private string[] BC00112_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] BC00112_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] BC00112_A257AssinaturaArquivoAssinadoNome ;
      private bool[] BC00112_n257AssinaturaArquivoAssinadoNome ;
      private int[] BC00112_A227ContratoId ;
      private bool[] BC00112_n227ContratoId ;
      private int[] BC00112_A231ArquivoId ;
      private bool[] BC00112_n231ArquivoId ;
      private int[] BC00112_A578ArquivoAssinadoId ;
      private bool[] BC00112_n578ArquivoAssinadoId ;
      private string[] BC00112_A240AssinaturaArquivoAssinado ;
      private bool[] BC00112_n240AssinaturaArquivoAssinado ;
      private long[] BC001113_A238AssinaturaId ;
      private bool[] BC001113_n238AssinaturaId ;
      private short[] BC001118_A367AssinaturaParticipantes_F ;
      private bool[] BC001118_n367AssinaturaParticipantes_F ;
      private string[] BC001119_A228ContratoNome ;
      private bool[] BC001119_n228ContratoNome ;
      private DateTime[] BC001119_A362ContratoDataInicial ;
      private bool[] BC001119_n362ContratoDataInicial ;
      private DateTime[] BC001119_A363ContratoDataFinal ;
      private bool[] BC001119_n363ContratoDataFinal ;
      private int[] BC001120_A572PropostaContratoAssinaturaId ;
      private int[] BC001121_A242AssinaturaParticipanteId ;
      private long[] BC001123_A238AssinaturaId ;
      private bool[] BC001123_n238AssinaturaId ;
      private Guid[] BC001123_A241AssinaturaPublicKey ;
      private bool[] BC001123_n241AssinaturaPublicKey ;
      private string[] BC001123_A239AssinaturaStatus ;
      private bool[] BC001123_n239AssinaturaStatus ;
      private string[] BC001123_A228ContratoNome ;
      private bool[] BC001123_n228ContratoNome ;
      private DateTime[] BC001123_A362ContratoDataInicial ;
      private bool[] BC001123_n362ContratoDataInicial ;
      private DateTime[] BC001123_A363ContratoDataFinal ;
      private bool[] BC001123_n363ContratoDataFinal ;
      private string[] BC001123_A364AssinaturaPaginaConsulta ;
      private bool[] BC001123_n364AssinaturaPaginaConsulta ;
      private string[] BC001123_A365AssinaturaToken ;
      private bool[] BC001123_n365AssinaturaToken ;
      private short[] BC001123_A368AssinaturaMes ;
      private bool[] BC001123_n368AssinaturaMes ;
      private string[] BC001123_A371AssinaturaMesNome ;
      private bool[] BC001123_n371AssinaturaMesNome ;
      private short[] BC001123_A369AssinaturaAno ;
      private bool[] BC001123_n369AssinaturaAno ;
      private DateTime[] BC001123_A366AssinaturaFinalizadoData ;
      private bool[] BC001123_n366AssinaturaFinalizadoData ;
      private string[] BC001123_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] BC001123_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] BC001123_A257AssinaturaArquivoAssinadoNome ;
      private bool[] BC001123_n257AssinaturaArquivoAssinadoNome ;
      private int[] BC001123_A227ContratoId ;
      private bool[] BC001123_n227ContratoId ;
      private int[] BC001123_A231ArquivoId ;
      private bool[] BC001123_n231ArquivoId ;
      private int[] BC001123_A578ArquivoAssinadoId ;
      private bool[] BC001123_n578ArquivoAssinadoId ;
      private short[] BC001123_A367AssinaturaParticipantes_F ;
      private bool[] BC001123_n367AssinaturaParticipantes_F ;
      private string[] BC001123_A240AssinaturaArquivoAssinado ;
      private bool[] BC001123_n240AssinaturaArquivoAssinado ;
      private SdtAssinatura bcAssinatura ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinatura_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00112;
          prmBC00112 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC00113;
          prmBC00113 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC00114;
          prmBC00114 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00115;
          prmBC00115 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC00116;
          prmBC00116 = new Object[] {
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC00118;
          prmBC00118 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001110;
          prmBC001110 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001111;
          prmBC001111 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001112;
          prmBC001112 = new Object[] {
          new ParDef("AssinaturaPublicKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinado",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("AssinaturaPaginaConsulta",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("AssinaturaToken",GXType.VarChar,512,0){Nullable=true} ,
          new ParDef("AssinaturaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMesNome",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaFinalizadoData",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC001113;
          prmBC001113 = new Object[] {
          };
          Object[] prmBC001114;
          prmBC001114 = new Object[] {
          new ParDef("AssinaturaPublicKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaPaginaConsulta",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("AssinaturaToken",GXType.VarChar,512,0){Nullable=true} ,
          new ParDef("AssinaturaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMesNome",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaFinalizadoData",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001115;
          prmBC001115 = new Object[] {
          new ParDef("AssinaturaArquivoAssinado",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001116;
          prmBC001116 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001118;
          prmBC001118 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001119;
          prmBC001119 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC001120;
          prmBC001120 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001121;
          prmBC001121 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC001123;
          prmBC001123 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00112", "SELECT AssinaturaId, AssinaturaPublicKey, AssinaturaStatus, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId, AssinaturaArquivoAssinado FROM Assinatura WHERE AssinaturaId = :AssinaturaId  FOR UPDATE OF Assinatura",true, GxErrorMask.GX_NOMASK, false, this,prmBC00112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00113", "SELECT AssinaturaId, AssinaturaPublicKey, AssinaturaStatus, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId, AssinaturaArquivoAssinado FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00114", "SELECT ContratoNome, ContratoDataInicial, ContratoDataFinal FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00115", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00116", "SELECT ArquivoId AS ArquivoAssinadoId FROM Arquivo WHERE ArquivoId = :ArquivoAssinadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00118", "SELECT COALESCE( T1.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante GROUP BY AssinaturaId ) T1 WHERE T1.AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001110", "SELECT TM1.AssinaturaId, TM1.AssinaturaPublicKey, TM1.AssinaturaStatus, T3.ContratoNome, T3.ContratoDataInicial, T3.ContratoDataFinal, TM1.AssinaturaPaginaConsulta, TM1.AssinaturaToken, TM1.AssinaturaMes, TM1.AssinaturaMesNome, TM1.AssinaturaAno, TM1.AssinaturaFinalizadoData, TM1.AssinaturaArquivoAssinadoExtensao, TM1.AssinaturaArquivoAssinadoNome, TM1.ContratoId, TM1.ArquivoId, TM1.ArquivoAssinadoId AS ArquivoAssinadoId, COALESCE( T2.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F, TM1.AssinaturaArquivoAssinado FROM ((Assinatura TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE TM1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T2 ON T2.AssinaturaId = TM1.AssinaturaId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.AssinaturaId = :AssinaturaId ORDER BY TM1.AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001110,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001111", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001112", "SAVEPOINT gxupdate;INSERT INTO Assinatura(AssinaturaPublicKey, AssinaturaStatus, AssinaturaArquivoAssinado, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId) VALUES(:AssinaturaPublicKey, :AssinaturaStatus, :AssinaturaArquivoAssinado, :AssinaturaPaginaConsulta, :AssinaturaToken, :AssinaturaMes, :AssinaturaMesNome, :AssinaturaAno, :AssinaturaFinalizadoData, :AssinaturaArquivoAssinadoExtensao, :AssinaturaArquivoAssinadoNome, :ContratoId, :ArquivoId, :ArquivoAssinadoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001112)
             ,new CursorDef("BC001113", "SELECT currval('AssinaturaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001114", "SAVEPOINT gxupdate;UPDATE Assinatura SET AssinaturaPublicKey=:AssinaturaPublicKey, AssinaturaStatus=:AssinaturaStatus, AssinaturaPaginaConsulta=:AssinaturaPaginaConsulta, AssinaturaToken=:AssinaturaToken, AssinaturaMes=:AssinaturaMes, AssinaturaMesNome=:AssinaturaMesNome, AssinaturaAno=:AssinaturaAno, AssinaturaFinalizadoData=:AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao=:AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome=:AssinaturaArquivoAssinadoNome, ContratoId=:ContratoId, ArquivoId=:ArquivoId, ArquivoAssinadoId=:ArquivoAssinadoId  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001114)
             ,new CursorDef("BC001115", "SAVEPOINT gxupdate;UPDATE Assinatura SET AssinaturaArquivoAssinado=:AssinaturaArquivoAssinado  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001115)
             ,new CursorDef("BC001116", "SAVEPOINT gxupdate;DELETE FROM Assinatura  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001116)
             ,new CursorDef("BC001118", "SELECT COALESCE( T1.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante GROUP BY AssinaturaId ) T1 WHERE T1.AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001119", "SELECT ContratoNome, ContratoDataInicial, ContratoDataFinal FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001119,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001120", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaAssinatura = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001120,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001121", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001121,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001123", "SELECT TM1.AssinaturaId, TM1.AssinaturaPublicKey, TM1.AssinaturaStatus, T3.ContratoNome, T3.ContratoDataInicial, T3.ContratoDataFinal, TM1.AssinaturaPaginaConsulta, TM1.AssinaturaToken, TM1.AssinaturaMes, TM1.AssinaturaMesNome, TM1.AssinaturaAno, TM1.AssinaturaFinalizadoData, TM1.AssinaturaArquivoAssinadoExtensao, TM1.AssinaturaArquivoAssinadoNome, TM1.ContratoId, TM1.ArquivoId, TM1.ArquivoAssinadoId AS ArquivoAssinadoId, COALESCE( T2.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F, TM1.AssinaturaArquivoAssinado FROM ((Assinatura TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE TM1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T2 ON T2.AssinaturaId = TM1.AssinaturaId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.AssinaturaId = :AssinaturaId ORDER BY TM1.AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001123,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getBLOBFile(15, rslt.getVarchar(10), rslt.getVarchar(11));
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getBLOBFile(15, rslt.getVarchar(10), rslt.getVarchar(11));
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getBLOBFile(19, rslt.getVarchar(13), rslt.getVarchar(14));
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getBLOBFile(19, rslt.getVarchar(13), rslt.getVarchar(14));
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
       }
    }

 }

}
