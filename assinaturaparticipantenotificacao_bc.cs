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
   public class assinaturaparticipantenotificacao_bc : GxSilentTrn, IGxSilentTrn
   {
      public assinaturaparticipantenotificacao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipantenotificacao_bc( IGxContext context )
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
         ReadRow1443( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1443( ) ;
         standaloneModal( ) ;
         AddRow1443( ) ;
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
               Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1443( ) ;
            }
            else
            {
               CheckExtendedTable1443( ) ;
               if ( AnyError == 0 )
               {
                  ZM1443( 3) ;
               }
               CloseExtendedTableCursors1443( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1443( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z259AssinaturaParticipanteNotificacaoData = A259AssinaturaParticipanteNotificacaoData;
            Z260AssinaturaParticipanteNotificacaoStatus = A260AssinaturaParticipanteNotificacaoStatus;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
            Z259AssinaturaParticipanteNotificacaoData = A259AssinaturaParticipanteNotificacaoData;
            Z260AssinaturaParticipanteNotificacaoStatus = A260AssinaturaParticipanteNotificacaoStatus;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1443( )
      {
         /* Using cursor BC00145 */
         pr_default.execute(3, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
            A259AssinaturaParticipanteNotificacaoData = BC00145_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = BC00145_n259AssinaturaParticipanteNotificacaoData[0];
            A260AssinaturaParticipanteNotificacaoStatus = BC00145_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = BC00145_n260AssinaturaParticipanteNotificacaoStatus[0];
            A242AssinaturaParticipanteId = BC00145_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC00145_n242AssinaturaParticipanteId[0];
            ZM1443( -2) ;
         }
         pr_default.close(3);
         OnLoadActions1443( ) ;
      }

      protected void OnLoadActions1443( )
      {
      }

      protected void CheckExtendedTable1443( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00144 */
         pr_default.execute(2, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Enviado") == 0 ) || ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Enviando") == 0 ) || ( StringUtil.StrCmp(A260AssinaturaParticipanteNotificacaoStatus, "Erro") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A260AssinaturaParticipanteNotificacaoStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Participante Notificacao Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1443( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1443( )
      {
         /* Using cursor BC00146 */
         pr_default.execute(4, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00143 */
         pr_default.execute(1, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1443( 2) ;
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = BC00143_A258AssinaturaParticipanteNotificacaoId[0];
            A259AssinaturaParticipanteNotificacaoData = BC00143_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = BC00143_n259AssinaturaParticipanteNotificacaoData[0];
            A260AssinaturaParticipanteNotificacaoStatus = BC00143_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = BC00143_n260AssinaturaParticipanteNotificacaoStatus[0];
            A242AssinaturaParticipanteId = BC00143_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC00143_n242AssinaturaParticipanteId[0];
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1443( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1443( ) ;
            }
            Gx_mode = sMode43;
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1443( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode43;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1443( ) ;
         if ( RcdFound43 == 0 )
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
         CONFIRM_140( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1443( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00142 */
            pr_default.execute(0, new Object[] {A258AssinaturaParticipanteNotificacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z259AssinaturaParticipanteNotificacaoData != BC00142_A259AssinaturaParticipanteNotificacaoData[0] ) || ( StringUtil.StrCmp(Z260AssinaturaParticipanteNotificacaoStatus, BC00142_A260AssinaturaParticipanteNotificacaoStatus[0]) != 0 ) || ( Z242AssinaturaParticipanteId != BC00142_A242AssinaturaParticipanteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1443( )
      {
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1443( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1443( 0) ;
            CheckOptimisticConcurrency1443( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1443( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1443( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00147 */
                     pr_default.execute(5, new Object[] {n259AssinaturaParticipanteNotificacaoData, A259AssinaturaParticipanteNotificacaoData, n260AssinaturaParticipanteNotificacaoStatus, A260AssinaturaParticipanteNotificacaoStatus, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00148 */
                     pr_default.execute(6);
                     A258AssinaturaParticipanteNotificacaoId = BC00148_A258AssinaturaParticipanteNotificacaoId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
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
               Load1443( ) ;
            }
            EndLevel1443( ) ;
         }
         CloseExtendedTableCursors1443( ) ;
      }

      protected void Update1443( )
      {
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1443( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1443( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1443( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1443( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00149 */
                     pr_default.execute(7, new Object[] {n259AssinaturaParticipanteNotificacaoData, A259AssinaturaParticipanteNotificacaoData, n260AssinaturaParticipanteNotificacaoStatus, A260AssinaturaParticipanteNotificacaoStatus, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId, A258AssinaturaParticipanteNotificacaoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteNotificacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1443( ) ;
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
            EndLevel1443( ) ;
         }
         CloseExtendedTableCursors1443( ) ;
      }

      protected void DeferredUpdate1443( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1443( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1443( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1443( ) ;
            AfterConfirm1443( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1443( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001410 */
                  pr_default.execute(8, new Object[] {A258AssinaturaParticipanteNotificacaoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteNotificacao");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1443( ) ;
         Gx_mode = sMode43;
      }

      protected void OnDeleteControls1443( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1443( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1443( ) ;
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

      public void ScanKeyStart1443( )
      {
         /* Using cursor BC001411 */
         pr_default.execute(9, new Object[] {A258AssinaturaParticipanteNotificacaoId});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = BC001411_A258AssinaturaParticipanteNotificacaoId[0];
            A259AssinaturaParticipanteNotificacaoData = BC001411_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = BC001411_n259AssinaturaParticipanteNotificacaoData[0];
            A260AssinaturaParticipanteNotificacaoStatus = BC001411_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = BC001411_n260AssinaturaParticipanteNotificacaoStatus[0];
            A242AssinaturaParticipanteId = BC001411_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC001411_n242AssinaturaParticipanteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1443( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound43 = 0;
         ScanKeyLoad1443( ) ;
      }

      protected void ScanKeyLoad1443( )
      {
         sMode43 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound43 = 1;
            A258AssinaturaParticipanteNotificacaoId = BC001411_A258AssinaturaParticipanteNotificacaoId[0];
            A259AssinaturaParticipanteNotificacaoData = BC001411_A259AssinaturaParticipanteNotificacaoData[0];
            n259AssinaturaParticipanteNotificacaoData = BC001411_n259AssinaturaParticipanteNotificacaoData[0];
            A260AssinaturaParticipanteNotificacaoStatus = BC001411_A260AssinaturaParticipanteNotificacaoStatus[0];
            n260AssinaturaParticipanteNotificacaoStatus = BC001411_n260AssinaturaParticipanteNotificacaoStatus[0];
            A242AssinaturaParticipanteId = BC001411_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC001411_n242AssinaturaParticipanteId[0];
         }
         Gx_mode = sMode43;
      }

      protected void ScanKeyEnd1443( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1443( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1443( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1443( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1443( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1443( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1443( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1443( )
      {
      }

      protected void send_integrity_lvl_hashes1443( )
      {
      }

      protected void AddRow1443( )
      {
         VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
      }

      protected void ReadRow1443( )
      {
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
      }

      protected void InitializeNonKey1443( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         A259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         n259AssinaturaParticipanteNotificacaoData = false;
         A260AssinaturaParticipanteNotificacaoStatus = "";
         n260AssinaturaParticipanteNotificacaoStatus = false;
         Z259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         Z260AssinaturaParticipanteNotificacaoStatus = "";
         Z242AssinaturaParticipanteId = 0;
      }

      protected void InitAll1443( )
      {
         A258AssinaturaParticipanteNotificacaoId = 0;
         InitializeNonKey1443( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow43( SdtAssinaturaParticipanteNotificacao obj43 )
      {
         obj43.gxTpr_Mode = Gx_mode;
         obj43.gxTpr_Assinaturaparticipanteid = A242AssinaturaParticipanteId;
         obj43.gxTpr_Assinaturaparticipantenotificacaodata = A259AssinaturaParticipanteNotificacaoData;
         obj43.gxTpr_Assinaturaparticipantenotificacaostatus = A260AssinaturaParticipanteNotificacaoStatus;
         obj43.gxTpr_Assinaturaparticipantenotificacaoid = A258AssinaturaParticipanteNotificacaoId;
         obj43.gxTpr_Assinaturaparticipantenotificacaoid_Z = Z258AssinaturaParticipanteNotificacaoId;
         obj43.gxTpr_Assinaturaparticipanteid_Z = Z242AssinaturaParticipanteId;
         obj43.gxTpr_Assinaturaparticipantenotificacaodata_Z = Z259AssinaturaParticipanteNotificacaoData;
         obj43.gxTpr_Assinaturaparticipantenotificacaostatus_Z = Z260AssinaturaParticipanteNotificacaoStatus;
         obj43.gxTpr_Assinaturaparticipanteid_N = (short)(Convert.ToInt16(n242AssinaturaParticipanteId));
         obj43.gxTpr_Assinaturaparticipantenotificacaodata_N = (short)(Convert.ToInt16(n259AssinaturaParticipanteNotificacaoData));
         obj43.gxTpr_Assinaturaparticipantenotificacaostatus_N = (short)(Convert.ToInt16(n260AssinaturaParticipanteNotificacaoStatus));
         obj43.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow43( SdtAssinaturaParticipanteNotificacao obj43 )
      {
         obj43.gxTpr_Assinaturaparticipantenotificacaoid = A258AssinaturaParticipanteNotificacaoId;
         return  ;
      }

      public void RowToVars43( SdtAssinaturaParticipanteNotificacao obj43 ,
                               int forceLoad )
      {
         Gx_mode = obj43.gxTpr_Mode;
         A242AssinaturaParticipanteId = obj43.gxTpr_Assinaturaparticipanteid;
         n242AssinaturaParticipanteId = false;
         A259AssinaturaParticipanteNotificacaoData = obj43.gxTpr_Assinaturaparticipantenotificacaodata;
         n259AssinaturaParticipanteNotificacaoData = false;
         A260AssinaturaParticipanteNotificacaoStatus = obj43.gxTpr_Assinaturaparticipantenotificacaostatus;
         n260AssinaturaParticipanteNotificacaoStatus = false;
         A258AssinaturaParticipanteNotificacaoId = obj43.gxTpr_Assinaturaparticipantenotificacaoid;
         Z258AssinaturaParticipanteNotificacaoId = obj43.gxTpr_Assinaturaparticipantenotificacaoid_Z;
         Z242AssinaturaParticipanteId = obj43.gxTpr_Assinaturaparticipanteid_Z;
         Z259AssinaturaParticipanteNotificacaoData = obj43.gxTpr_Assinaturaparticipantenotificacaodata_Z;
         Z260AssinaturaParticipanteNotificacaoStatus = obj43.gxTpr_Assinaturaparticipantenotificacaostatus_Z;
         n242AssinaturaParticipanteId = (bool)(Convert.ToBoolean(obj43.gxTpr_Assinaturaparticipanteid_N));
         n259AssinaturaParticipanteNotificacaoData = (bool)(Convert.ToBoolean(obj43.gxTpr_Assinaturaparticipantenotificacaodata_N));
         n260AssinaturaParticipanteNotificacaoStatus = (bool)(Convert.ToBoolean(obj43.gxTpr_Assinaturaparticipantenotificacaostatus_N));
         Gx_mode = obj43.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A258AssinaturaParticipanteNotificacaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1443( ) ;
         ScanKeyStart1443( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
         }
         ZM1443( -2) ;
         OnLoadActions1443( ) ;
         AddRow1443( ) ;
         ScanKeyEnd1443( ) ;
         if ( RcdFound43 == 0 )
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
         RowToVars43( bcAssinaturaParticipanteNotificacao, 0) ;
         ScanKeyStart1443( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z258AssinaturaParticipanteNotificacaoId = A258AssinaturaParticipanteNotificacaoId;
         }
         ZM1443( -2) ;
         OnLoadActions1443( ) ;
         AddRow1443( ) ;
         ScanKeyEnd1443( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1443( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1443( ) ;
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
               {
                  A258AssinaturaParticipanteNotificacaoId = Z258AssinaturaParticipanteNotificacaoId;
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
                  Update1443( ) ;
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
                  if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
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
                        Insert1443( ) ;
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
                        Insert1443( ) ;
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
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
         SaveImpl( ) ;
         VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1443( ) ;
         AfterTrn( ) ;
         VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
         }
         else
         {
            SdtAssinaturaParticipanteNotificacao auxBC = new SdtAssinaturaParticipanteNotificacao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A258AssinaturaParticipanteNotificacaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAssinaturaParticipanteNotificacao);
               auxBC.Save();
               bcAssinaturaParticipanteNotificacao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
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
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1443( ) ;
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
               VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
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
         RowToVars43( bcAssinaturaParticipanteNotificacao, 0) ;
         GetKey1443( ) ;
         if ( RcdFound43 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
            {
               A258AssinaturaParticipanteNotificacaoId = Z258AssinaturaParticipanteNotificacaoId;
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
            if ( A258AssinaturaParticipanteNotificacaoId != Z258AssinaturaParticipanteNotificacaoId )
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
         context.RollbackDataStores("assinaturaparticipantenotificacao_bc",pr_default);
         VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
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
         Gx_mode = bcAssinaturaParticipanteNotificacao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAssinaturaParticipanteNotificacao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAssinaturaParticipanteNotificacao )
         {
            bcAssinaturaParticipanteNotificacao = (SdtAssinaturaParticipanteNotificacao)(sdt);
            if ( StringUtil.StrCmp(bcAssinaturaParticipanteNotificacao.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipanteNotificacao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow43( bcAssinaturaParticipanteNotificacao) ;
            }
            else
            {
               RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAssinaturaParticipanteNotificacao.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipanteNotificacao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars43( bcAssinaturaParticipanteNotificacao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAssinaturaParticipanteNotificacao AssinaturaParticipanteNotificacao_BC
      {
         get {
            return bcAssinaturaParticipanteNotificacao ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         A259AssinaturaParticipanteNotificacaoData = (DateTime)(DateTime.MinValue);
         Z260AssinaturaParticipanteNotificacaoStatus = "";
         A260AssinaturaParticipanteNotificacaoStatus = "";
         BC00145_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC00145_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         BC00145_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         BC00145_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         BC00145_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         BC00145_A242AssinaturaParticipanteId = new int[1] ;
         BC00145_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00144_A242AssinaturaParticipanteId = new int[1] ;
         BC00144_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00146_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC00143_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC00143_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         BC00143_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         BC00143_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         BC00143_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         BC00143_A242AssinaturaParticipanteId = new int[1] ;
         BC00143_n242AssinaturaParticipanteId = new bool[] {false} ;
         sMode43 = "";
         BC00142_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC00142_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         BC00142_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         BC00142_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         BC00142_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         BC00142_A242AssinaturaParticipanteId = new int[1] ;
         BC00142_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00148_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC001411_A258AssinaturaParticipanteNotificacaoId = new int[1] ;
         BC001411_A259AssinaturaParticipanteNotificacaoData = new DateTime[] {DateTime.MinValue} ;
         BC001411_n259AssinaturaParticipanteNotificacaoData = new bool[] {false} ;
         BC001411_A260AssinaturaParticipanteNotificacaoStatus = new string[] {""} ;
         BC001411_n260AssinaturaParticipanteNotificacaoStatus = new bool[] {false} ;
         BC001411_A242AssinaturaParticipanteId = new int[1] ;
         BC001411_n242AssinaturaParticipanteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipantenotificacao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00142_A258AssinaturaParticipanteNotificacaoId, BC00142_A259AssinaturaParticipanteNotificacaoData, BC00142_n259AssinaturaParticipanteNotificacaoData, BC00142_A260AssinaturaParticipanteNotificacaoStatus, BC00142_n260AssinaturaParticipanteNotificacaoStatus, BC00142_A242AssinaturaParticipanteId, BC00142_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00143_A258AssinaturaParticipanteNotificacaoId, BC00143_A259AssinaturaParticipanteNotificacaoData, BC00143_n259AssinaturaParticipanteNotificacaoData, BC00143_A260AssinaturaParticipanteNotificacaoStatus, BC00143_n260AssinaturaParticipanteNotificacaoStatus, BC00143_A242AssinaturaParticipanteId, BC00143_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00144_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00145_A258AssinaturaParticipanteNotificacaoId, BC00145_A259AssinaturaParticipanteNotificacaoData, BC00145_n259AssinaturaParticipanteNotificacaoData, BC00145_A260AssinaturaParticipanteNotificacaoStatus, BC00145_n260AssinaturaParticipanteNotificacaoStatus, BC00145_A242AssinaturaParticipanteId, BC00145_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00146_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00148_A258AssinaturaParticipanteNotificacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001411_A258AssinaturaParticipanteNotificacaoId, BC001411_A259AssinaturaParticipanteNotificacaoData, BC001411_n259AssinaturaParticipanteNotificacaoData, BC001411_A260AssinaturaParticipanteNotificacaoStatus, BC001411_n260AssinaturaParticipanteNotificacaoStatus, BC001411_A242AssinaturaParticipanteId, BC001411_n242AssinaturaParticipanteId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound43 ;
      private int trnEnded ;
      private int Z258AssinaturaParticipanteNotificacaoId ;
      private int A258AssinaturaParticipanteNotificacaoId ;
      private int Z242AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode43 ;
      private DateTime Z259AssinaturaParticipanteNotificacaoData ;
      private DateTime A259AssinaturaParticipanteNotificacaoData ;
      private bool n259AssinaturaParticipanteNotificacaoData ;
      private bool n260AssinaturaParticipanteNotificacaoStatus ;
      private bool n242AssinaturaParticipanteId ;
      private string Z260AssinaturaParticipanteNotificacaoStatus ;
      private string A260AssinaturaParticipanteNotificacaoStatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00145_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] BC00145_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] BC00145_n259AssinaturaParticipanteNotificacaoData ;
      private string[] BC00145_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] BC00145_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] BC00145_A242AssinaturaParticipanteId ;
      private bool[] BC00145_n242AssinaturaParticipanteId ;
      private int[] BC00144_A242AssinaturaParticipanteId ;
      private bool[] BC00144_n242AssinaturaParticipanteId ;
      private int[] BC00146_A258AssinaturaParticipanteNotificacaoId ;
      private int[] BC00143_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] BC00143_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] BC00143_n259AssinaturaParticipanteNotificacaoData ;
      private string[] BC00143_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] BC00143_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] BC00143_A242AssinaturaParticipanteId ;
      private bool[] BC00143_n242AssinaturaParticipanteId ;
      private int[] BC00142_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] BC00142_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] BC00142_n259AssinaturaParticipanteNotificacaoData ;
      private string[] BC00142_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] BC00142_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] BC00142_A242AssinaturaParticipanteId ;
      private bool[] BC00142_n242AssinaturaParticipanteId ;
      private int[] BC00148_A258AssinaturaParticipanteNotificacaoId ;
      private int[] BC001411_A258AssinaturaParticipanteNotificacaoId ;
      private DateTime[] BC001411_A259AssinaturaParticipanteNotificacaoData ;
      private bool[] BC001411_n259AssinaturaParticipanteNotificacaoData ;
      private string[] BC001411_A260AssinaturaParticipanteNotificacaoStatus ;
      private bool[] BC001411_n260AssinaturaParticipanteNotificacaoStatus ;
      private int[] BC001411_A242AssinaturaParticipanteId ;
      private bool[] BC001411_n242AssinaturaParticipanteId ;
      private SdtAssinaturaParticipanteNotificacao bcAssinaturaParticipanteNotificacao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinaturaparticipantenotificacao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00142;
          prmBC00142 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC00143;
          prmBC00143 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC00144;
          prmBC00144 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00145;
          prmBC00145 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC00146;
          prmBC00146 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC00147;
          prmBC00147 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoData",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00148;
          prmBC00148 = new Object[] {
          };
          Object[] prmBC00149;
          prmBC00149 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoData",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001410;
          prmBC001410 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001411;
          prmBC001411 = new Object[] {
          new ParDef("AssinaturaParticipanteNotificacaoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00142", "SELECT AssinaturaParticipanteNotificacaoId, AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId  FOR UPDATE OF AssinaturaParticipanteNotificacao",true, GxErrorMask.GX_NOMASK, false, this,prmBC00142,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00143", "SELECT AssinaturaParticipanteNotificacaoId, AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00143,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00144", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00144,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00145", "SELECT TM1.AssinaturaParticipanteNotificacaoId, TM1.AssinaturaParticipanteNotificacaoData, TM1.AssinaturaParticipanteNotificacaoStatus, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao TM1 WHERE TM1.AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ORDER BY TM1.AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00145,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00146", "SELECT AssinaturaParticipanteNotificacaoId FROM AssinaturaParticipanteNotificacao WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00146,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00147", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipanteNotificacao(AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId) VALUES(:AssinaturaParticipanteNotificacaoData, :AssinaturaParticipanteNotificacaoStatus, :AssinaturaParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00147)
             ,new CursorDef("BC00148", "SELECT currval('AssinaturaParticipanteNotificacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00148,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00149", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipanteNotificacao SET AssinaturaParticipanteNotificacaoData=:AssinaturaParticipanteNotificacaoData, AssinaturaParticipanteNotificacaoStatus=:AssinaturaParticipanteNotificacaoStatus, AssinaturaParticipanteId=:AssinaturaParticipanteId  WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00149)
             ,new CursorDef("BC001410", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipanteNotificacao  WHERE AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001410)
             ,new CursorDef("BC001411", "SELECT TM1.AssinaturaParticipanteNotificacaoId, TM1.AssinaturaParticipanteNotificacaoData, TM1.AssinaturaParticipanteNotificacaoStatus, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteNotificacao TM1 WHERE TM1.AssinaturaParticipanteNotificacaoId = :AssinaturaParticipanteNotificacaoId ORDER BY TM1.AssinaturaParticipanteNotificacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001411,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
