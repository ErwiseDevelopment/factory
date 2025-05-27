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
   public class contratoparticipante_bc : GxSilentTrn, IGxSilentTrn
   {
      public contratoparticipante_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratoparticipante_bc( IGxContext context )
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
         ReadRow1039( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1039( ) ;
         standaloneModal( ) ;
         AddRow1039( ) ;
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
               Z237ContratoParticipanteId = A237ContratoParticipanteId;
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

      protected void CONFIRM_100( )
      {
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1039( ) ;
            }
            else
            {
               CheckExtendedTable1039( ) ;
               if ( AnyError == 0 )
               {
                  ZM1039( 2) ;
                  ZM1039( 3) ;
               }
               CloseExtendedTableCursors1039( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1039( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z227ContratoId = A227ContratoId;
            Z233ParticipanteId = A233ParticipanteId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
            Z227ContratoId = A227ContratoId;
            Z233ParticipanteId = A233ParticipanteId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1039( )
      {
         /* Using cursor BC00106 */
         pr_default.execute(4, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound39 = 1;
            A227ContratoId = BC00106_A227ContratoId[0];
            n227ContratoId = BC00106_n227ContratoId[0];
            A233ParticipanteId = BC00106_A233ParticipanteId[0];
            n233ParticipanteId = BC00106_n233ParticipanteId[0];
            ZM1039( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1039( ) ;
      }

      protected void OnLoadActions1039( )
      {
      }

      protected void CheckExtendedTable1039( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00104 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC00105 */
         pr_default.execute(3, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A233ParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'Participante'.", "ForeignKeyNotFound", 1, "PARTICIPANTEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1039( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1039( )
      {
         /* Using cursor BC00107 */
         pr_default.execute(5, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00103 */
         pr_default.execute(1, new Object[] {A237ContratoParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1039( 1) ;
            RcdFound39 = 1;
            A237ContratoParticipanteId = BC00103_A237ContratoParticipanteId[0];
            A227ContratoId = BC00103_A227ContratoId[0];
            n227ContratoId = BC00103_n227ContratoId[0];
            A233ParticipanteId = BC00103_A233ParticipanteId[0];
            n233ParticipanteId = BC00103_n233ParticipanteId[0];
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1039( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey1039( ) ;
            }
            Gx_mode = sMode39;
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey1039( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode39;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1039( ) ;
         if ( RcdFound39 == 0 )
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
         CONFIRM_100( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1039( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00102 */
            pr_default.execute(0, new Object[] {A237ContratoParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContratoParticipante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z227ContratoId != BC00102_A227ContratoId[0] ) || ( Z233ParticipanteId != BC00102_A233ParticipanteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ContratoParticipante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1039( )
      {
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1039( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1039( 0) ;
            CheckOptimisticConcurrency1039( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1039( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1039( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00108 */
                     pr_default.execute(6, new Object[] {n227ContratoId, A227ContratoId, n233ParticipanteId, A233ParticipanteId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00109 */
                     pr_default.execute(7);
                     A237ContratoParticipanteId = BC00109_A237ContratoParticipanteId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
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
               Load1039( ) ;
            }
            EndLevel1039( ) ;
         }
         CloseExtendedTableCursors1039( ) ;
      }

      protected void Update1039( )
      {
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1039( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1039( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1039( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1039( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001010 */
                     pr_default.execute(8, new Object[] {n227ContratoId, A227ContratoId, n233ParticipanteId, A233ParticipanteId, A237ContratoParticipanteId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContratoParticipante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1039( ) ;
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
            EndLevel1039( ) ;
         }
         CloseExtendedTableCursors1039( ) ;
      }

      protected void DeferredUpdate1039( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1039( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1039( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1039( ) ;
            AfterConfirm1039( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1039( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001011 */
                  pr_default.execute(9, new Object[] {A237ContratoParticipanteId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ContratoParticipante");
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
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1039( ) ;
         Gx_mode = sMode39;
      }

      protected void OnDeleteControls1039( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1039( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1039( ) ;
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

      public void ScanKeyStart1039( )
      {
         /* Using cursor BC001012 */
         pr_default.execute(10, new Object[] {A237ContratoParticipanteId});
         RcdFound39 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound39 = 1;
            A237ContratoParticipanteId = BC001012_A237ContratoParticipanteId[0];
            A227ContratoId = BC001012_A227ContratoId[0];
            n227ContratoId = BC001012_n227ContratoId[0];
            A233ParticipanteId = BC001012_A233ParticipanteId[0];
            n233ParticipanteId = BC001012_n233ParticipanteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1039( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound39 = 0;
         ScanKeyLoad1039( ) ;
      }

      protected void ScanKeyLoad1039( )
      {
         sMode39 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound39 = 1;
            A237ContratoParticipanteId = BC001012_A237ContratoParticipanteId[0];
            A227ContratoId = BC001012_A227ContratoId[0];
            n227ContratoId = BC001012_n227ContratoId[0];
            A233ParticipanteId = BC001012_A233ParticipanteId[0];
            n233ParticipanteId = BC001012_n233ParticipanteId[0];
         }
         Gx_mode = sMode39;
      }

      protected void ScanKeyEnd1039( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1039( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1039( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1039( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1039( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1039( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1039( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1039( )
      {
      }

      protected void send_integrity_lvl_hashes1039( )
      {
      }

      protected void AddRow1039( )
      {
         VarsToRow39( bcContratoParticipante) ;
      }

      protected void ReadRow1039( )
      {
         RowToVars39( bcContratoParticipante, 1) ;
      }

      protected void InitializeNonKey1039( )
      {
         A227ContratoId = 0;
         n227ContratoId = false;
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         Z227ContratoId = 0;
         Z233ParticipanteId = 0;
      }

      protected void InitAll1039( )
      {
         A237ContratoParticipanteId = 0;
         InitializeNonKey1039( ) ;
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

      public void VarsToRow39( SdtContratoParticipante obj39 )
      {
         obj39.gxTpr_Mode = Gx_mode;
         obj39.gxTpr_Contratoid = A227ContratoId;
         obj39.gxTpr_Participanteid = A233ParticipanteId;
         obj39.gxTpr_Contratoparticipanteid = A237ContratoParticipanteId;
         obj39.gxTpr_Contratoparticipanteid_Z = Z237ContratoParticipanteId;
         obj39.gxTpr_Contratoid_Z = Z227ContratoId;
         obj39.gxTpr_Participanteid_Z = Z233ParticipanteId;
         obj39.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj39.gxTpr_Participanteid_N = (short)(Convert.ToInt16(n233ParticipanteId));
         obj39.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow39( SdtContratoParticipante obj39 )
      {
         obj39.gxTpr_Contratoparticipanteid = A237ContratoParticipanteId;
         return  ;
      }

      public void RowToVars39( SdtContratoParticipante obj39 ,
                               int forceLoad )
      {
         Gx_mode = obj39.gxTpr_Mode;
         A227ContratoId = obj39.gxTpr_Contratoid;
         n227ContratoId = false;
         A233ParticipanteId = obj39.gxTpr_Participanteid;
         n233ParticipanteId = false;
         A237ContratoParticipanteId = obj39.gxTpr_Contratoparticipanteid;
         Z237ContratoParticipanteId = obj39.gxTpr_Contratoparticipanteid_Z;
         Z227ContratoId = obj39.gxTpr_Contratoid_Z;
         Z233ParticipanteId = obj39.gxTpr_Participanteid_Z;
         n227ContratoId = (bool)(Convert.ToBoolean(obj39.gxTpr_Contratoid_N));
         n233ParticipanteId = (bool)(Convert.ToBoolean(obj39.gxTpr_Participanteid_N));
         Gx_mode = obj39.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A237ContratoParticipanteId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1039( ) ;
         ScanKeyStart1039( ) ;
         if ( RcdFound39 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
         }
         ZM1039( -1) ;
         OnLoadActions1039( ) ;
         AddRow1039( ) ;
         ScanKeyEnd1039( ) ;
         if ( RcdFound39 == 0 )
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
         RowToVars39( bcContratoParticipante, 0) ;
         ScanKeyStart1039( ) ;
         if ( RcdFound39 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z237ContratoParticipanteId = A237ContratoParticipanteId;
         }
         ZM1039( -1) ;
         OnLoadActions1039( ) ;
         AddRow1039( ) ;
         ScanKeyEnd1039( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1039( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1039( ) ;
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
               {
                  A237ContratoParticipanteId = Z237ContratoParticipanteId;
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
                  Update1039( ) ;
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
                  if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
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
                        Insert1039( ) ;
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
                        Insert1039( ) ;
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
         RowToVars39( bcContratoParticipante, 1) ;
         SaveImpl( ) ;
         VarsToRow39( bcContratoParticipante) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars39( bcContratoParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1039( ) ;
         AfterTrn( ) ;
         VarsToRow39( bcContratoParticipante) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow39( bcContratoParticipante) ;
         }
         else
         {
            SdtContratoParticipante auxBC = new SdtContratoParticipante(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A237ContratoParticipanteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcContratoParticipante);
               auxBC.Save();
               bcContratoParticipante.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars39( bcContratoParticipante, 1) ;
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
         RowToVars39( bcContratoParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1039( ) ;
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
               VarsToRow39( bcContratoParticipante) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow39( bcContratoParticipante) ;
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
         RowToVars39( bcContratoParticipante, 0) ;
         GetKey1039( ) ;
         if ( RcdFound39 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
            {
               A237ContratoParticipanteId = Z237ContratoParticipanteId;
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
            if ( A237ContratoParticipanteId != Z237ContratoParticipanteId )
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
         context.RollbackDataStores("contratoparticipante_bc",pr_default);
         VarsToRow39( bcContratoParticipante) ;
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
         Gx_mode = bcContratoParticipante.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcContratoParticipante.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcContratoParticipante )
         {
            bcContratoParticipante = (SdtContratoParticipante)(sdt);
            if ( StringUtil.StrCmp(bcContratoParticipante.gxTpr_Mode, "") == 0 )
            {
               bcContratoParticipante.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow39( bcContratoParticipante) ;
            }
            else
            {
               RowToVars39( bcContratoParticipante, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcContratoParticipante.gxTpr_Mode, "") == 0 )
            {
               bcContratoParticipante.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars39( bcContratoParticipante, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtContratoParticipante ContratoParticipante_BC
      {
         get {
            return bcContratoParticipante ;
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
         BC00106_A237ContratoParticipanteId = new int[1] ;
         BC00106_A227ContratoId = new int[1] ;
         BC00106_n227ContratoId = new bool[] {false} ;
         BC00106_A233ParticipanteId = new int[1] ;
         BC00106_n233ParticipanteId = new bool[] {false} ;
         BC00104_A227ContratoId = new int[1] ;
         BC00104_n227ContratoId = new bool[] {false} ;
         BC00105_A233ParticipanteId = new int[1] ;
         BC00105_n233ParticipanteId = new bool[] {false} ;
         BC00107_A237ContratoParticipanteId = new int[1] ;
         BC00103_A237ContratoParticipanteId = new int[1] ;
         BC00103_A227ContratoId = new int[1] ;
         BC00103_n227ContratoId = new bool[] {false} ;
         BC00103_A233ParticipanteId = new int[1] ;
         BC00103_n233ParticipanteId = new bool[] {false} ;
         sMode39 = "";
         BC00102_A237ContratoParticipanteId = new int[1] ;
         BC00102_A227ContratoId = new int[1] ;
         BC00102_n227ContratoId = new bool[] {false} ;
         BC00102_A233ParticipanteId = new int[1] ;
         BC00102_n233ParticipanteId = new bool[] {false} ;
         BC00109_A237ContratoParticipanteId = new int[1] ;
         BC001012_A237ContratoParticipanteId = new int[1] ;
         BC001012_A227ContratoId = new int[1] ;
         BC001012_n227ContratoId = new bool[] {false} ;
         BC001012_A233ParticipanteId = new int[1] ;
         BC001012_n233ParticipanteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratoparticipante_bc__default(),
            new Object[][] {
                new Object[] {
               BC00102_A237ContratoParticipanteId, BC00102_A227ContratoId, BC00102_n227ContratoId, BC00102_A233ParticipanteId, BC00102_n233ParticipanteId
               }
               , new Object[] {
               BC00103_A237ContratoParticipanteId, BC00103_A227ContratoId, BC00103_n227ContratoId, BC00103_A233ParticipanteId, BC00103_n233ParticipanteId
               }
               , new Object[] {
               BC00104_A227ContratoId
               }
               , new Object[] {
               BC00105_A233ParticipanteId
               }
               , new Object[] {
               BC00106_A237ContratoParticipanteId, BC00106_A227ContratoId, BC00106_n227ContratoId, BC00106_A233ParticipanteId, BC00106_n233ParticipanteId
               }
               , new Object[] {
               BC00107_A237ContratoParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00109_A237ContratoParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001012_A237ContratoParticipanteId, BC001012_A227ContratoId, BC001012_n227ContratoId, BC001012_A233ParticipanteId, BC001012_n233ParticipanteId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound39 ;
      private int trnEnded ;
      private int Z237ContratoParticipanteId ;
      private int A237ContratoParticipanteId ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private int Z233ParticipanteId ;
      private int A233ParticipanteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode39 ;
      private bool n227ContratoId ;
      private bool n233ParticipanteId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00106_A237ContratoParticipanteId ;
      private int[] BC00106_A227ContratoId ;
      private bool[] BC00106_n227ContratoId ;
      private int[] BC00106_A233ParticipanteId ;
      private bool[] BC00106_n233ParticipanteId ;
      private int[] BC00104_A227ContratoId ;
      private bool[] BC00104_n227ContratoId ;
      private int[] BC00105_A233ParticipanteId ;
      private bool[] BC00105_n233ParticipanteId ;
      private int[] BC00107_A237ContratoParticipanteId ;
      private int[] BC00103_A237ContratoParticipanteId ;
      private int[] BC00103_A227ContratoId ;
      private bool[] BC00103_n227ContratoId ;
      private int[] BC00103_A233ParticipanteId ;
      private bool[] BC00103_n233ParticipanteId ;
      private int[] BC00102_A237ContratoParticipanteId ;
      private int[] BC00102_A227ContratoId ;
      private bool[] BC00102_n227ContratoId ;
      private int[] BC00102_A233ParticipanteId ;
      private bool[] BC00102_n233ParticipanteId ;
      private int[] BC00109_A237ContratoParticipanteId ;
      private int[] BC001012_A237ContratoParticipanteId ;
      private int[] BC001012_A227ContratoId ;
      private bool[] BC001012_n227ContratoId ;
      private int[] BC001012_A233ParticipanteId ;
      private bool[] BC001012_n233ParticipanteId ;
      private SdtContratoParticipante bcContratoParticipante ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class contratoparticipante_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00102;
          prmBC00102 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00103;
          prmBC00103 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00104;
          prmBC00104 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00105;
          prmBC00105 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC00106;
          prmBC00106 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00107;
          prmBC00107 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00108;
          prmBC00108 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC00109;
          prmBC00109 = new Object[] {
          };
          Object[] prmBC001010;
          prmBC001010 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC001011;
          prmBC001011 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmBC001012;
          prmBC001012 = new Object[] {
          new ParDef("ContratoParticipanteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00102", "SELECT ContratoParticipanteId, ContratoId, ParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId  FOR UPDATE OF ContratoParticipante",true, GxErrorMask.GX_NOMASK, false, this,prmBC00102,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00103", "SELECT ContratoParticipanteId, ContratoId, ParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00103,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00104", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00104,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00105", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00105,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00106", "SELECT TM1.ContratoParticipanteId, TM1.ContratoId, TM1.ParticipanteId FROM ContratoParticipante TM1 WHERE TM1.ContratoParticipanteId = :ContratoParticipanteId ORDER BY TM1.ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00106,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00107", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ContratoParticipanteId = :ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00107,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00108", "SAVEPOINT gxupdate;INSERT INTO ContratoParticipante(ContratoId, ParticipanteId) VALUES(:ContratoId, :ParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00108)
             ,new CursorDef("BC00109", "SELECT currval('ContratoParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00109,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001010", "SAVEPOINT gxupdate;UPDATE ContratoParticipante SET ContratoId=:ContratoId, ParticipanteId=:ParticipanteId  WHERE ContratoParticipanteId = :ContratoParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001010)
             ,new CursorDef("BC001011", "SAVEPOINT gxupdate;DELETE FROM ContratoParticipante  WHERE ContratoParticipanteId = :ContratoParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001011)
             ,new CursorDef("BC001012", "SELECT TM1.ContratoParticipanteId, TM1.ContratoId, TM1.ParticipanteId FROM ContratoParticipante TM1 WHERE TM1.ContratoParticipanteId = :ContratoParticipanteId ORDER BY TM1.ContratoParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001012,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
