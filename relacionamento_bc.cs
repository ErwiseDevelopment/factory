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
   public class relacionamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public relacionamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public relacionamento_bc( IGxContext context )
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
         ReadRow33107( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey33107( ) ;
         standaloneModal( ) ;
         AddRow33107( ) ;
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
               Z1032RelacionamentoId = A1032RelacionamentoId;
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

      protected void CONFIRM_330( )
      {
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls33107( ) ;
            }
            else
            {
               CheckExtendedTable33107( ) ;
               if ( AnyError == 0 )
               {
                  ZM33107( 3) ;
               }
               CloseExtendedTableCursors33107( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM33107( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z1033RelacionamentoTipo = A1033RelacionamentoTipo;
            Z168ClienteId = A168ClienteId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z1032RelacionamentoId = A1032RelacionamentoId;
            Z1033RelacionamentoTipo = A1033RelacionamentoTipo;
            Z168ClienteId = A168ClienteId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load33107( )
      {
         /* Using cursor BC00335 */
         pr_default.execute(3, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound107 = 1;
            A1033RelacionamentoTipo = BC00335_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = BC00335_n1033RelacionamentoTipo[0];
            A168ClienteId = BC00335_A168ClienteId[0];
            n168ClienteId = BC00335_n168ClienteId[0];
            ZM33107( -2) ;
         }
         pr_default.close(3);
         OnLoadActions33107( ) ;
      }

      protected void OnLoadActions33107( )
      {
      }

      protected void CheckExtendedTable33107( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00334 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Cliente") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Paciente") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Clinica") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Sacado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1033RelacionamentoTipo)) ) )
         {
            GX_msglist.addItem("Campo Relacionamento Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors33107( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey33107( )
      {
         /* Using cursor BC00336 */
         pr_default.execute(4, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00333 */
         pr_default.execute(1, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM33107( 2) ;
            RcdFound107 = 1;
            A1032RelacionamentoId = BC00333_A1032RelacionamentoId[0];
            A1033RelacionamentoTipo = BC00333_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = BC00333_n1033RelacionamentoTipo[0];
            A168ClienteId = BC00333_A168ClienteId[0];
            n168ClienteId = BC00333_n168ClienteId[0];
            Z1032RelacionamentoId = A1032RelacionamentoId;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load33107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey33107( ) ;
            }
            Gx_mode = sMode107;
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey33107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode107;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey33107( ) ;
         if ( RcdFound107 == 0 )
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
         CONFIRM_330( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency33107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00332 */
            pr_default.execute(0, new Object[] {A1032RelacionamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relacionamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1033RelacionamentoTipo, BC00332_A1033RelacionamentoTipo[0]) != 0 ) || ( Z168ClienteId != BC00332_A168ClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Relacionamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert33107( )
      {
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM33107( 0) ;
            CheckOptimisticConcurrency33107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert33107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00337 */
                     pr_default.execute(5, new Object[] {n1033RelacionamentoTipo, A1033RelacionamentoTipo, n168ClienteId, A168ClienteId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00338 */
                     pr_default.execute(6);
                     A1032RelacionamentoId = BC00338_A1032RelacionamentoId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
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
               Load33107( ) ;
            }
            EndLevel33107( ) ;
         }
         CloseExtendedTableCursors33107( ) ;
      }

      protected void Update33107( )
      {
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate33107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00339 */
                     pr_default.execute(7, new Object[] {n1033RelacionamentoTipo, A1033RelacionamentoTipo, n168ClienteId, A168ClienteId, A1032RelacionamentoId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relacionamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate33107( ) ;
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
            EndLevel33107( ) ;
         }
         CloseExtendedTableCursors33107( ) ;
      }

      protected void DeferredUpdate33107( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls33107( ) ;
            AfterConfirm33107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete33107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003310 */
                  pr_default.execute(8, new Object[] {A1032RelacionamentoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
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
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel33107( ) ;
         Gx_mode = sMode107;
      }

      protected void OnDeleteControls33107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel33107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete33107( ) ;
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

      public void ScanKeyStart33107( )
      {
         /* Using cursor BC003311 */
         pr_default.execute(9, new Object[] {A1032RelacionamentoId});
         RcdFound107 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound107 = 1;
            A1032RelacionamentoId = BC003311_A1032RelacionamentoId[0];
            A1033RelacionamentoTipo = BC003311_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = BC003311_n1033RelacionamentoTipo[0];
            A168ClienteId = BC003311_A168ClienteId[0];
            n168ClienteId = BC003311_n168ClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext33107( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound107 = 0;
         ScanKeyLoad33107( ) ;
      }

      protected void ScanKeyLoad33107( )
      {
         sMode107 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound107 = 1;
            A1032RelacionamentoId = BC003311_A1032RelacionamentoId[0];
            A1033RelacionamentoTipo = BC003311_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = BC003311_n1033RelacionamentoTipo[0];
            A168ClienteId = BC003311_A168ClienteId[0];
            n168ClienteId = BC003311_n168ClienteId[0];
         }
         Gx_mode = sMode107;
      }

      protected void ScanKeyEnd33107( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm33107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert33107( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate33107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete33107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete33107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate33107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes33107( )
      {
      }

      protected void send_integrity_lvl_hashes33107( )
      {
      }

      protected void AddRow33107( )
      {
         VarsToRow107( bcRelacionamento) ;
      }

      protected void ReadRow33107( )
      {
         RowToVars107( bcRelacionamento, 1) ;
      }

      protected void InitializeNonKey33107( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         A1033RelacionamentoTipo = "";
         n1033RelacionamentoTipo = false;
         Z1033RelacionamentoTipo = "";
         Z168ClienteId = 0;
      }

      protected void InitAll33107( )
      {
         A1032RelacionamentoId = 0;
         InitializeNonKey33107( ) ;
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

      public void VarsToRow107( SdtRelacionamento obj107 )
      {
         obj107.gxTpr_Mode = Gx_mode;
         obj107.gxTpr_Clienteid = A168ClienteId;
         obj107.gxTpr_Relacionamentotipo = A1033RelacionamentoTipo;
         obj107.gxTpr_Relacionamentoid = A1032RelacionamentoId;
         obj107.gxTpr_Relacionamentoid_Z = Z1032RelacionamentoId;
         obj107.gxTpr_Clienteid_Z = Z168ClienteId;
         obj107.gxTpr_Relacionamentotipo_Z = Z1033RelacionamentoTipo;
         obj107.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj107.gxTpr_Relacionamentotipo_N = (short)(Convert.ToInt16(n1033RelacionamentoTipo));
         obj107.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow107( SdtRelacionamento obj107 )
      {
         obj107.gxTpr_Relacionamentoid = A1032RelacionamentoId;
         return  ;
      }

      public void RowToVars107( SdtRelacionamento obj107 ,
                                int forceLoad )
      {
         Gx_mode = obj107.gxTpr_Mode;
         A168ClienteId = obj107.gxTpr_Clienteid;
         n168ClienteId = false;
         A1033RelacionamentoTipo = obj107.gxTpr_Relacionamentotipo;
         n1033RelacionamentoTipo = false;
         A1032RelacionamentoId = obj107.gxTpr_Relacionamentoid;
         Z1032RelacionamentoId = obj107.gxTpr_Relacionamentoid_Z;
         Z168ClienteId = obj107.gxTpr_Clienteid_Z;
         Z1033RelacionamentoTipo = obj107.gxTpr_Relacionamentotipo_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj107.gxTpr_Clienteid_N));
         n1033RelacionamentoTipo = (bool)(Convert.ToBoolean(obj107.gxTpr_Relacionamentotipo_N));
         Gx_mode = obj107.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1032RelacionamentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey33107( ) ;
         ScanKeyStart33107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1032RelacionamentoId = A1032RelacionamentoId;
         }
         ZM33107( -2) ;
         OnLoadActions33107( ) ;
         AddRow33107( ) ;
         ScanKeyEnd33107( ) ;
         if ( RcdFound107 == 0 )
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
         RowToVars107( bcRelacionamento, 0) ;
         ScanKeyStart33107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1032RelacionamentoId = A1032RelacionamentoId;
         }
         ZM33107( -2) ;
         OnLoadActions33107( ) ;
         AddRow33107( ) ;
         ScanKeyEnd33107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey33107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert33107( ) ;
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( A1032RelacionamentoId != Z1032RelacionamentoId )
               {
                  A1032RelacionamentoId = Z1032RelacionamentoId;
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
                  Update33107( ) ;
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
                  if ( A1032RelacionamentoId != Z1032RelacionamentoId )
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
                        Insert33107( ) ;
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
                        Insert33107( ) ;
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
         RowToVars107( bcRelacionamento, 1) ;
         SaveImpl( ) ;
         VarsToRow107( bcRelacionamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars107( bcRelacionamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert33107( ) ;
         AfterTrn( ) ;
         VarsToRow107( bcRelacionamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow107( bcRelacionamento) ;
         }
         else
         {
            SdtRelacionamento auxBC = new SdtRelacionamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1032RelacionamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRelacionamento);
               auxBC.Save();
               bcRelacionamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars107( bcRelacionamento, 1) ;
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
         RowToVars107( bcRelacionamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert33107( ) ;
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
               VarsToRow107( bcRelacionamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow107( bcRelacionamento) ;
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
         RowToVars107( bcRelacionamento, 0) ;
         GetKey33107( ) ;
         if ( RcdFound107 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1032RelacionamentoId != Z1032RelacionamentoId )
            {
               A1032RelacionamentoId = Z1032RelacionamentoId;
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
            if ( A1032RelacionamentoId != Z1032RelacionamentoId )
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
         context.RollbackDataStores("relacionamento_bc",pr_default);
         VarsToRow107( bcRelacionamento) ;
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
         Gx_mode = bcRelacionamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRelacionamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRelacionamento )
         {
            bcRelacionamento = (SdtRelacionamento)(sdt);
            if ( StringUtil.StrCmp(bcRelacionamento.gxTpr_Mode, "") == 0 )
            {
               bcRelacionamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow107( bcRelacionamento) ;
            }
            else
            {
               RowToVars107( bcRelacionamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRelacionamento.gxTpr_Mode, "") == 0 )
            {
               bcRelacionamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars107( bcRelacionamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtRelacionamento Relacionamento_BC
      {
         get {
            return bcRelacionamento ;
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
         Z1033RelacionamentoTipo = "";
         A1033RelacionamentoTipo = "";
         BC00335_A1032RelacionamentoId = new int[1] ;
         BC00335_A1033RelacionamentoTipo = new string[] {""} ;
         BC00335_n1033RelacionamentoTipo = new bool[] {false} ;
         BC00335_A168ClienteId = new int[1] ;
         BC00335_n168ClienteId = new bool[] {false} ;
         BC00334_A168ClienteId = new int[1] ;
         BC00334_n168ClienteId = new bool[] {false} ;
         BC00336_A1032RelacionamentoId = new int[1] ;
         BC00333_A1032RelacionamentoId = new int[1] ;
         BC00333_A1033RelacionamentoTipo = new string[] {""} ;
         BC00333_n1033RelacionamentoTipo = new bool[] {false} ;
         BC00333_A168ClienteId = new int[1] ;
         BC00333_n168ClienteId = new bool[] {false} ;
         sMode107 = "";
         BC00332_A1032RelacionamentoId = new int[1] ;
         BC00332_A1033RelacionamentoTipo = new string[] {""} ;
         BC00332_n1033RelacionamentoTipo = new bool[] {false} ;
         BC00332_A168ClienteId = new int[1] ;
         BC00332_n168ClienteId = new bool[] {false} ;
         BC00338_A1032RelacionamentoId = new int[1] ;
         BC003311_A1032RelacionamentoId = new int[1] ;
         BC003311_A1033RelacionamentoTipo = new string[] {""} ;
         BC003311_n1033RelacionamentoTipo = new bool[] {false} ;
         BC003311_A168ClienteId = new int[1] ;
         BC003311_n168ClienteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relacionamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00332_A1032RelacionamentoId, BC00332_A1033RelacionamentoTipo, BC00332_n1033RelacionamentoTipo, BC00332_A168ClienteId, BC00332_n168ClienteId
               }
               , new Object[] {
               BC00333_A1032RelacionamentoId, BC00333_A1033RelacionamentoTipo, BC00333_n1033RelacionamentoTipo, BC00333_A168ClienteId, BC00333_n168ClienteId
               }
               , new Object[] {
               BC00334_A168ClienteId
               }
               , new Object[] {
               BC00335_A1032RelacionamentoId, BC00335_A1033RelacionamentoTipo, BC00335_n1033RelacionamentoTipo, BC00335_A168ClienteId, BC00335_n168ClienteId
               }
               , new Object[] {
               BC00336_A1032RelacionamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00338_A1032RelacionamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003311_A1032RelacionamentoId, BC003311_A1033RelacionamentoTipo, BC003311_n1033RelacionamentoTipo, BC003311_A168ClienteId, BC003311_n168ClienteId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound107 ;
      private int trnEnded ;
      private int Z1032RelacionamentoId ;
      private int A1032RelacionamentoId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode107 ;
      private bool n1033RelacionamentoTipo ;
      private bool n168ClienteId ;
      private string Z1033RelacionamentoTipo ;
      private string A1033RelacionamentoTipo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00335_A1032RelacionamentoId ;
      private string[] BC00335_A1033RelacionamentoTipo ;
      private bool[] BC00335_n1033RelacionamentoTipo ;
      private int[] BC00335_A168ClienteId ;
      private bool[] BC00335_n168ClienteId ;
      private int[] BC00334_A168ClienteId ;
      private bool[] BC00334_n168ClienteId ;
      private int[] BC00336_A1032RelacionamentoId ;
      private int[] BC00333_A1032RelacionamentoId ;
      private string[] BC00333_A1033RelacionamentoTipo ;
      private bool[] BC00333_n1033RelacionamentoTipo ;
      private int[] BC00333_A168ClienteId ;
      private bool[] BC00333_n168ClienteId ;
      private int[] BC00332_A1032RelacionamentoId ;
      private string[] BC00332_A1033RelacionamentoTipo ;
      private bool[] BC00332_n1033RelacionamentoTipo ;
      private int[] BC00332_A168ClienteId ;
      private bool[] BC00332_n168ClienteId ;
      private int[] BC00338_A1032RelacionamentoId ;
      private int[] BC003311_A1032RelacionamentoId ;
      private string[] BC003311_A1033RelacionamentoTipo ;
      private bool[] BC003311_n1033RelacionamentoTipo ;
      private int[] BC003311_A168ClienteId ;
      private bool[] BC003311_n168ClienteId ;
      private SdtRelacionamento bcRelacionamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class relacionamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00332;
          prmBC00332 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00333;
          prmBC00333 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00334;
          prmBC00334 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00335;
          prmBC00335 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00336;
          prmBC00336 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00337;
          prmBC00337 = new Object[] {
          new ParDef("RelacionamentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00338;
          prmBC00338 = new Object[] {
          };
          Object[] prmBC00339;
          prmBC00339 = new Object[] {
          new ParDef("RelacionamentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC003310;
          prmBC003310 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC003311;
          prmBC003311 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00332", "SELECT RelacionamentoId, RelacionamentoTipo, ClienteId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId  FOR UPDATE OF Relacionamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00332,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00333", "SELECT RelacionamentoId, RelacionamentoTipo, ClienteId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00333,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00334", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00334,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00335", "SELECT TM1.RelacionamentoId, TM1.RelacionamentoTipo, TM1.ClienteId FROM Relacionamento TM1 WHERE TM1.RelacionamentoId = :RelacionamentoId ORDER BY TM1.RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00335,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00336", "SELECT RelacionamentoId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00336,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00337", "SAVEPOINT gxupdate;INSERT INTO Relacionamento(RelacionamentoTipo, ClienteId) VALUES(:RelacionamentoTipo, :ClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00337)
             ,new CursorDef("BC00338", "SELECT currval('RelacionamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00338,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00339", "SAVEPOINT gxupdate;UPDATE Relacionamento SET RelacionamentoTipo=:RelacionamentoTipo, ClienteId=:ClienteId  WHERE RelacionamentoId = :RelacionamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00339)
             ,new CursorDef("BC003310", "SAVEPOINT gxupdate;DELETE FROM Relacionamento  WHERE RelacionamentoId = :RelacionamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003310)
             ,new CursorDef("BC003311", "SELECT TM1.RelacionamentoId, TM1.RelacionamentoTipo, TM1.ClienteId FROM Relacionamento TM1 WHERE TM1.RelacionamentoId = :RelacionamentoId ORDER BY TM1.RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003311,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
