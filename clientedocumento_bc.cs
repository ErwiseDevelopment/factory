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
   public class clientedocumento_bc : GxSilentTrn, IGxSilentTrn
   {
      public clientedocumento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientedocumento_bc( IGxContext context )
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
         ReadRow2879( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2879( ) ;
         standaloneModal( ) ;
         AddRow2879( ) ;
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
            E11282 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z599ClienteDocumentoId = A599ClienteDocumentoId;
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

      protected void CONFIRM_280( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2879( ) ;
            }
            else
            {
               CheckExtendedTable2879( ) ;
               if ( AnyError == 0 )
               {
                  ZM2879( 16) ;
                  ZM2879( 17) ;
                  ZM2879( 18) ;
               }
               CloseExtendedTableCursors2879( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12282( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "DocumentosId") == 0 )
               {
                  AV23Insert_DocumentosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteDocumentoCreatedBy") == 0 )
               {
                  AV12Insert_ClienteDocumentoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
      }

      protected void E11282( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E13282( )
      {
         /* ClienteDocumentoBlob_Controlvaluechanged Routine */
         returnInSub = false;
         AV26Nome = A601ClienteDocumentoBlob_Filename;
         AV28index = (short)(StringUtil.StringSearch( AV26Nome, ".", 1));
         AV27Ext = StringUtil.Substring( AV26Nome, AV28index+1, 3);
         AV26Nome = StringUtil.Substring( AV26Nome, 1, AV28index-1);
         AV25NomeDoArquivo = A601ClienteDocumentoBlob_Filename;
      }

      protected void ZM2879( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z604ClienteDocumentoCreatedAt = A604ClienteDocumentoCreatedAt;
            Z605ClienteDocumentoUpdatedAt = A605ClienteDocumentoUpdatedAt;
            Z603ClienteDocumentoExtensao = A603ClienteDocumentoExtensao;
            Z602ClienteDocumentoNome = A602ClienteDocumentoNome;
            Z168ClienteId = A168ClienteId;
            Z405DocumentosId = A405DocumentosId;
            Z606ClienteDocumentoCreatedBy = A606ClienteDocumentoCreatedBy;
            Z607ClienteNomeDoArquivo_F = A607ClienteNomeDoArquivo_F;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z607ClienteNomeDoArquivo_F = A607ClienteNomeDoArquivo_F;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z607ClienteNomeDoArquivo_F = A607ClienteNomeDoArquivo_F;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z607ClienteNomeDoArquivo_F = A607ClienteNomeDoArquivo_F;
         }
         if ( GX_JID == -15 )
         {
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
            Z604ClienteDocumentoCreatedAt = A604ClienteDocumentoCreatedAt;
            Z605ClienteDocumentoUpdatedAt = A605ClienteDocumentoUpdatedAt;
            Z603ClienteDocumentoExtensao = A603ClienteDocumentoExtensao;
            Z601ClienteDocumentoBlob = A601ClienteDocumentoBlob;
            Z602ClienteDocumentoNome = A602ClienteDocumentoNome;
            Z168ClienteId = A168ClienteId;
            Z405DocumentosId = A405DocumentosId;
            Z606ClienteDocumentoCreatedBy = A606ClienteDocumentoCreatedBy;
            Z406DocumentosDescricao = A406DocumentosDescricao;
         }
      }

      protected void standaloneNotModal( )
      {
         AV32Pgmname = "ClienteDocumento_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A605ClienteDocumentoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n605ClienteDocumentoUpdatedAt = false;
         }
         if ( IsIns( )  )
         {
            A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n604ClienteDocumentoCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A604ClienteDocumentoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n604ClienteDocumentoCreatedAt = false;
            }
         }
      }

      protected void Load2879( )
      {
         /* Using cursor BC00287 */
         pr_default.execute(5, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
            A604ClienteDocumentoCreatedAt = BC00287_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = BC00287_n604ClienteDocumentoCreatedAt[0];
            A605ClienteDocumentoUpdatedAt = BC00287_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = BC00287_n605ClienteDocumentoUpdatedAt[0];
            A603ClienteDocumentoExtensao = BC00287_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = BC00287_n603ClienteDocumentoExtensao[0];
            A406DocumentosDescricao = BC00287_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC00287_n406DocumentosDescricao[0];
            A602ClienteDocumentoNome = BC00287_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = BC00287_n602ClienteDocumentoNome[0];
            A168ClienteId = BC00287_A168ClienteId[0];
            n168ClienteId = BC00287_n168ClienteId[0];
            A405DocumentosId = BC00287_A405DocumentosId[0];
            n405DocumentosId = BC00287_n405DocumentosId[0];
            A606ClienteDocumentoCreatedBy = BC00287_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = BC00287_n606ClienteDocumentoCreatedBy[0];
            A601ClienteDocumentoBlob = BC00287_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = BC00287_n601ClienteDocumentoBlob[0];
            ZM2879( -15) ;
         }
         pr_default.close(5);
         OnLoadActions2879( ) ;
      }

      protected void OnLoadActions2879( )
      {
         GXt_SdtWWPContext1 = AV8WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV8WWPContext = GXt_SdtWWPContext1;
         if ( IsIns( )  )
         {
            A606ClienteDocumentoCreatedBy = AV8WWPContext.gxTpr_Userid;
            n606ClienteDocumentoCreatedBy = false;
         }
         else
         {
            if ( (0==A606ClienteDocumentoCreatedBy) )
            {
               A606ClienteDocumentoCreatedBy = 0;
               n606ClienteDocumentoCreatedBy = false;
               n606ClienteDocumentoCreatedBy = true;
               n606ClienteDocumentoCreatedBy = true;
            }
         }
         if ( (0==A405DocumentosId) )
         {
            A405DocumentosId = 0;
            n405DocumentosId = false;
            n405DocumentosId = true;
            n405DocumentosId = true;
         }
         AV25NomeDoArquivo = A601ClienteDocumentoBlob_Filename;
         AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
         A602ClienteDocumentoNome = StringUtil.Substring( AV25NomeDoArquivo, 1, AV28index-1);
         n602ClienteDocumentoNome = false;
         A603ClienteDocumentoExtensao = A601ClienteDocumentoBlob_Filetype;
         n603ClienteDocumentoExtensao = false;
         A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
      }

      protected void CheckExtendedTable2879( )
      {
         standaloneModal( ) ;
         GXt_SdtWWPContext1 = AV8WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV8WWPContext = GXt_SdtWWPContext1;
         if ( IsIns( )  )
         {
            A606ClienteDocumentoCreatedBy = AV8WWPContext.gxTpr_Userid;
            n606ClienteDocumentoCreatedBy = false;
         }
         else
         {
            if ( (0==A606ClienteDocumentoCreatedBy) )
            {
               A606ClienteDocumentoCreatedBy = 0;
               n606ClienteDocumentoCreatedBy = false;
               n606ClienteDocumentoCreatedBy = true;
               n606ClienteDocumentoCreatedBy = true;
            }
         }
         /* Using cursor BC00284 */
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
         if ( (0==A405DocumentosId) )
         {
            A405DocumentosId = 0;
            n405DocumentosId = false;
            n405DocumentosId = true;
            n405DocumentosId = true;
         }
         /* Using cursor BC00285 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
            }
         }
         A406DocumentosDescricao = BC00285_A406DocumentosDescricao[0];
         n406DocumentosDescricao = BC00285_n406DocumentosDescricao[0];
         pr_default.close(3);
         if ( (0==A405DocumentosId) )
         {
            GX_msglist.addItem("Tipo de documento é obrigatório", 1, "");
            AnyError = 1;
         }
         AV25NomeDoArquivo = A601ClienteDocumentoBlob_Filename;
         AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
         A602ClienteDocumentoNome = StringUtil.Substring( AV25NomeDoArquivo, 1, AV28index-1);
         n602ClienteDocumentoNome = false;
         A603ClienteDocumentoExtensao = A601ClienteDocumentoBlob_Filetype;
         n603ClienteDocumentoExtensao = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A601ClienteDocumentoBlob)) )
         {
            GX_msglist.addItem("Selecione um arquivo", 1, "");
            AnyError = 1;
         }
         A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
         /* Using cursor BC00286 */
         pr_default.execute(4, new Object[] {n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A606ClienteDocumentoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Documento Created By'.", "ForeignKeyNotFound", 1, "CLIENTEDOCUMENTOCREATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2879( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2879( )
      {
         /* Using cursor BC00288 */
         pr_default.execute(6, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00283 */
         pr_default.execute(1, new Object[] {A599ClienteDocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2879( 15) ;
            RcdFound79 = 1;
            A599ClienteDocumentoId = BC00283_A599ClienteDocumentoId[0];
            A604ClienteDocumentoCreatedAt = BC00283_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = BC00283_n604ClienteDocumentoCreatedAt[0];
            A605ClienteDocumentoUpdatedAt = BC00283_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = BC00283_n605ClienteDocumentoUpdatedAt[0];
            A603ClienteDocumentoExtensao = BC00283_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = BC00283_n603ClienteDocumentoExtensao[0];
            A602ClienteDocumentoNome = BC00283_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = BC00283_n602ClienteDocumentoNome[0];
            A168ClienteId = BC00283_A168ClienteId[0];
            n168ClienteId = BC00283_n168ClienteId[0];
            A405DocumentosId = BC00283_A405DocumentosId[0];
            n405DocumentosId = BC00283_n405DocumentosId[0];
            A606ClienteDocumentoCreatedBy = BC00283_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = BC00283_n606ClienteDocumentoCreatedBy[0];
            A601ClienteDocumentoBlob = BC00283_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = BC00283_n601ClienteDocumentoBlob[0];
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2879( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey2879( ) ;
            }
            Gx_mode = sMode79;
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey2879( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode79;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2879( ) ;
         if ( RcdFound79 == 0 )
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
         CONFIRM_280( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2879( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00282 */
            pr_default.execute(0, new Object[] {A599ClienteDocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z604ClienteDocumentoCreatedAt != BC00282_A604ClienteDocumentoCreatedAt[0] ) || ( Z605ClienteDocumentoUpdatedAt != BC00282_A605ClienteDocumentoUpdatedAt[0] ) || ( StringUtil.StrCmp(Z603ClienteDocumentoExtensao, BC00282_A603ClienteDocumentoExtensao[0]) != 0 ) || ( StringUtil.StrCmp(Z602ClienteDocumentoNome, BC00282_A602ClienteDocumentoNome[0]) != 0 ) || ( Z168ClienteId != BC00282_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != BC00282_A405DocumentosId[0] ) || ( Z606ClienteDocumentoCreatedBy != BC00282_A606ClienteDocumentoCreatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2879( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2879( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2879( 0) ;
            CheckOptimisticConcurrency2879( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2879( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2879( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00289 */
                     pr_default.execute(7, new Object[] {n604ClienteDocumentoCreatedAt, A604ClienteDocumentoCreatedAt, n605ClienteDocumentoUpdatedAt, A605ClienteDocumentoUpdatedAt, n603ClienteDocumentoExtensao, A603ClienteDocumentoExtensao, n601ClienteDocumentoBlob, A601ClienteDocumentoBlob, n602ClienteDocumentoNome, A602ClienteDocumentoNome, n168ClienteId, A168ClienteId, n405DocumentosId, A405DocumentosId, n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002810 */
                     pr_default.execute(8);
                     A599ClienteDocumentoId = BC002810_A599ClienteDocumentoId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
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
               Load2879( ) ;
            }
            EndLevel2879( ) ;
         }
         CloseExtendedTableCursors2879( ) ;
      }

      protected void Update2879( )
      {
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2879( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2879( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2879( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2879( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002811 */
                     pr_default.execute(9, new Object[] {n604ClienteDocumentoCreatedAt, A604ClienteDocumentoCreatedAt, n605ClienteDocumentoUpdatedAt, A605ClienteDocumentoUpdatedAt, n603ClienteDocumentoExtensao, A603ClienteDocumentoExtensao, n602ClienteDocumentoNome, A602ClienteDocumentoNome, n168ClienteId, A168ClienteId, n405DocumentosId, A405DocumentosId, n606ClienteDocumentoCreatedBy, A606ClienteDocumentoCreatedBy, A599ClienteDocumentoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteDocumento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2879( ) ;
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
            EndLevel2879( ) ;
         }
         CloseExtendedTableCursors2879( ) ;
      }

      protected void DeferredUpdate2879( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC002812 */
            pr_default.execute(10, new Object[] {n601ClienteDocumentoBlob, A601ClienteDocumentoBlob, A599ClienteDocumentoId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2879( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2879( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2879( ) ;
            AfterConfirm2879( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2879( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002813 */
                  pr_default.execute(11, new Object[] {A599ClienteDocumentoId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteDocumento");
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2879( ) ;
         Gx_mode = sMode79;
      }

      protected void OnDeleteControls2879( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_SdtWWPContext1 = AV8WWPContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
            AV8WWPContext = GXt_SdtWWPContext1;
            /* Using cursor BC002814 */
            pr_default.execute(12, new Object[] {n405DocumentosId, A405DocumentosId});
            A406DocumentosDescricao = BC002814_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC002814_n406DocumentosDescricao[0];
            pr_default.close(12);
            AV25NomeDoArquivo = A601ClienteDocumentoBlob_Filename;
            AV28index = (short)(StringUtil.StringSearch( AV25NomeDoArquivo, ".", 1));
            A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
         }
      }

      protected void EndLevel2879( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2879( ) ;
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

      public void ScanKeyStart2879( )
      {
         /* Scan By routine */
         /* Using cursor BC002815 */
         pr_default.execute(13, new Object[] {A599ClienteDocumentoId});
         RcdFound79 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound79 = 1;
            A599ClienteDocumentoId = BC002815_A599ClienteDocumentoId[0];
            A604ClienteDocumentoCreatedAt = BC002815_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = BC002815_n604ClienteDocumentoCreatedAt[0];
            A605ClienteDocumentoUpdatedAt = BC002815_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = BC002815_n605ClienteDocumentoUpdatedAt[0];
            A603ClienteDocumentoExtensao = BC002815_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = BC002815_n603ClienteDocumentoExtensao[0];
            A406DocumentosDescricao = BC002815_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC002815_n406DocumentosDescricao[0];
            A602ClienteDocumentoNome = BC002815_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = BC002815_n602ClienteDocumentoNome[0];
            A168ClienteId = BC002815_A168ClienteId[0];
            n168ClienteId = BC002815_n168ClienteId[0];
            A405DocumentosId = BC002815_A405DocumentosId[0];
            n405DocumentosId = BC002815_n405DocumentosId[0];
            A606ClienteDocumentoCreatedBy = BC002815_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = BC002815_n606ClienteDocumentoCreatedBy[0];
            A601ClienteDocumentoBlob = BC002815_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = BC002815_n601ClienteDocumentoBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2879( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound79 = 0;
         ScanKeyLoad2879( ) ;
      }

      protected void ScanKeyLoad2879( )
      {
         sMode79 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound79 = 1;
            A599ClienteDocumentoId = BC002815_A599ClienteDocumentoId[0];
            A604ClienteDocumentoCreatedAt = BC002815_A604ClienteDocumentoCreatedAt[0];
            n604ClienteDocumentoCreatedAt = BC002815_n604ClienteDocumentoCreatedAt[0];
            A605ClienteDocumentoUpdatedAt = BC002815_A605ClienteDocumentoUpdatedAt[0];
            n605ClienteDocumentoUpdatedAt = BC002815_n605ClienteDocumentoUpdatedAt[0];
            A603ClienteDocumentoExtensao = BC002815_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = BC002815_n603ClienteDocumentoExtensao[0];
            A406DocumentosDescricao = BC002815_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC002815_n406DocumentosDescricao[0];
            A602ClienteDocumentoNome = BC002815_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = BC002815_n602ClienteDocumentoNome[0];
            A168ClienteId = BC002815_A168ClienteId[0];
            n168ClienteId = BC002815_n168ClienteId[0];
            A405DocumentosId = BC002815_A405DocumentosId[0];
            n405DocumentosId = BC002815_n405DocumentosId[0];
            A606ClienteDocumentoCreatedBy = BC002815_A606ClienteDocumentoCreatedBy[0];
            n606ClienteDocumentoCreatedBy = BC002815_n606ClienteDocumentoCreatedBy[0];
            A601ClienteDocumentoBlob = BC002815_A601ClienteDocumentoBlob[0];
            n601ClienteDocumentoBlob = BC002815_n601ClienteDocumentoBlob[0];
         }
         Gx_mode = sMode79;
      }

      protected void ScanKeyEnd2879( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2879( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2879( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2879( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2879( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2879( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2879( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2879( )
      {
      }

      protected void send_integrity_lvl_hashes2879( )
      {
      }

      protected void AddRow2879( )
      {
         VarsToRow79( bcClienteDocumento) ;
      }

      protected void ReadRow2879( )
      {
         RowToVars79( bcClienteDocumento, 1) ;
      }

      protected void InitializeNonKey2879( )
      {
         A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         A605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         n605ClienteDocumentoUpdatedAt = false;
         AV25NomeDoArquivo = "";
         A603ClienteDocumentoExtensao = "";
         n603ClienteDocumentoExtensao = false;
         A606ClienteDocumentoCreatedBy = 0;
         n606ClienteDocumentoCreatedBy = false;
         A607ClienteNomeDoArquivo_F = "";
         A168ClienteId = 0;
         n168ClienteId = false;
         A405DocumentosId = 0;
         n405DocumentosId = false;
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         A601ClienteDocumentoBlob = "";
         n601ClienteDocumentoBlob = false;
         A602ClienteDocumentoNome = "";
         n602ClienteDocumentoNome = false;
         AV28index = 0;
         Z604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z603ClienteDocumentoExtensao = "";
         Z602ClienteDocumentoNome = "";
         Z168ClienteId = 0;
         Z405DocumentosId = 0;
         Z606ClienteDocumentoCreatedBy = 0;
      }

      protected void InitAll2879( )
      {
         A599ClienteDocumentoId = 0;
         InitializeNonKey2879( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A604ClienteDocumentoCreatedAt = i604ClienteDocumentoCreatedAt;
         n604ClienteDocumentoCreatedAt = false;
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

      public void VarsToRow79( SdtClienteDocumento obj79 )
      {
         obj79.gxTpr_Mode = Gx_mode;
         obj79.gxTpr_Clientedocumentocreatedat = A604ClienteDocumentoCreatedAt;
         obj79.gxTpr_Clientedocumentoupdatedat = A605ClienteDocumentoUpdatedAt;
         obj79.gxTpr_Clientedocumentoextensao = A603ClienteDocumentoExtensao;
         obj79.gxTpr_Clientedocumentocreatedby = A606ClienteDocumentoCreatedBy;
         obj79.gxTpr_Clientenomedoarquivo_f = A607ClienteNomeDoArquivo_F;
         obj79.gxTpr_Clienteid = A168ClienteId;
         obj79.gxTpr_Documentosid = A405DocumentosId;
         obj79.gxTpr_Documentosdescricao = A406DocumentosDescricao;
         obj79.gxTpr_Clientedocumentoblob = A601ClienteDocumentoBlob;
         obj79.gxTpr_Clientedocumentonome = A602ClienteDocumentoNome;
         obj79.gxTpr_Clientedocumentoid = A599ClienteDocumentoId;
         obj79.gxTpr_Clientedocumentoid_Z = Z599ClienteDocumentoId;
         obj79.gxTpr_Clienteid_Z = Z168ClienteId;
         obj79.gxTpr_Documentosid_Z = Z405DocumentosId;
         obj79.gxTpr_Documentosdescricao_Z = Z406DocumentosDescricao;
         obj79.gxTpr_Clientedocumentonome_Z = Z602ClienteDocumentoNome;
         obj79.gxTpr_Clientedocumentoextensao_Z = Z603ClienteDocumentoExtensao;
         obj79.gxTpr_Clientedocumentocreatedat_Z = Z604ClienteDocumentoCreatedAt;
         obj79.gxTpr_Clientedocumentocreatedby_Z = Z606ClienteDocumentoCreatedBy;
         obj79.gxTpr_Clientedocumentoupdatedat_Z = Z605ClienteDocumentoUpdatedAt;
         obj79.gxTpr_Clientenomedoarquivo_f_Z = Z607ClienteNomeDoArquivo_F;
         obj79.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj79.gxTpr_Documentosid_N = (short)(Convert.ToInt16(n405DocumentosId));
         obj79.gxTpr_Documentosdescricao_N = (short)(Convert.ToInt16(n406DocumentosDescricao));
         obj79.gxTpr_Clientedocumentoblob_N = (short)(Convert.ToInt16(n601ClienteDocumentoBlob));
         obj79.gxTpr_Clientedocumentonome_N = (short)(Convert.ToInt16(n602ClienteDocumentoNome));
         obj79.gxTpr_Clientedocumentoextensao_N = (short)(Convert.ToInt16(n603ClienteDocumentoExtensao));
         obj79.gxTpr_Clientedocumentocreatedat_N = (short)(Convert.ToInt16(n604ClienteDocumentoCreatedAt));
         obj79.gxTpr_Clientedocumentocreatedby_N = (short)(Convert.ToInt16(n606ClienteDocumentoCreatedBy));
         obj79.gxTpr_Clientedocumentoupdatedat_N = (short)(Convert.ToInt16(n605ClienteDocumentoUpdatedAt));
         obj79.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow79( SdtClienteDocumento obj79 )
      {
         obj79.gxTpr_Clientedocumentoid = A599ClienteDocumentoId;
         return  ;
      }

      public void RowToVars79( SdtClienteDocumento obj79 ,
                               int forceLoad )
      {
         Gx_mode = obj79.gxTpr_Mode;
         A604ClienteDocumentoCreatedAt = obj79.gxTpr_Clientedocumentocreatedat;
         n604ClienteDocumentoCreatedAt = false;
         A605ClienteDocumentoUpdatedAt = obj79.gxTpr_Clientedocumentoupdatedat;
         n605ClienteDocumentoUpdatedAt = false;
         A603ClienteDocumentoExtensao = obj79.gxTpr_Clientedocumentoextensao;
         n603ClienteDocumentoExtensao = false;
         A606ClienteDocumentoCreatedBy = obj79.gxTpr_Clientedocumentocreatedby;
         n606ClienteDocumentoCreatedBy = false;
         A607ClienteNomeDoArquivo_F = obj79.gxTpr_Clientenomedoarquivo_f;
         A168ClienteId = obj79.gxTpr_Clienteid;
         n168ClienteId = false;
         A405DocumentosId = obj79.gxTpr_Documentosid;
         n405DocumentosId = false;
         A406DocumentosDescricao = obj79.gxTpr_Documentosdescricao;
         n406DocumentosDescricao = false;
         A601ClienteDocumentoBlob = obj79.gxTpr_Clientedocumentoblob;
         n601ClienteDocumentoBlob = false;
         A602ClienteDocumentoNome = obj79.gxTpr_Clientedocumentonome;
         n602ClienteDocumentoNome = false;
         A599ClienteDocumentoId = obj79.gxTpr_Clientedocumentoid;
         Z599ClienteDocumentoId = obj79.gxTpr_Clientedocumentoid_Z;
         Z168ClienteId = obj79.gxTpr_Clienteid_Z;
         Z405DocumentosId = obj79.gxTpr_Documentosid_Z;
         Z406DocumentosDescricao = obj79.gxTpr_Documentosdescricao_Z;
         Z602ClienteDocumentoNome = obj79.gxTpr_Clientedocumentonome_Z;
         Z603ClienteDocumentoExtensao = obj79.gxTpr_Clientedocumentoextensao_Z;
         Z604ClienteDocumentoCreatedAt = obj79.gxTpr_Clientedocumentocreatedat_Z;
         Z606ClienteDocumentoCreatedBy = obj79.gxTpr_Clientedocumentocreatedby_Z;
         Z605ClienteDocumentoUpdatedAt = obj79.gxTpr_Clientedocumentoupdatedat_Z;
         Z607ClienteNomeDoArquivo_F = obj79.gxTpr_Clientenomedoarquivo_f_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj79.gxTpr_Clienteid_N));
         n405DocumentosId = (bool)(Convert.ToBoolean(obj79.gxTpr_Documentosid_N));
         n406DocumentosDescricao = (bool)(Convert.ToBoolean(obj79.gxTpr_Documentosdescricao_N));
         n601ClienteDocumentoBlob = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentoblob_N));
         n602ClienteDocumentoNome = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentonome_N));
         n603ClienteDocumentoExtensao = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentoextensao_N));
         n604ClienteDocumentoCreatedAt = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentocreatedat_N));
         n606ClienteDocumentoCreatedBy = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentocreatedby_N));
         n605ClienteDocumentoUpdatedAt = (bool)(Convert.ToBoolean(obj79.gxTpr_Clientedocumentoupdatedat_N));
         Gx_mode = obj79.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A599ClienteDocumentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2879( ) ;
         ScanKeyStart2879( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
         }
         ZM2879( -15) ;
         OnLoadActions2879( ) ;
         AddRow2879( ) ;
         ScanKeyEnd2879( ) ;
         if ( RcdFound79 == 0 )
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
         RowToVars79( bcClienteDocumento, 0) ;
         ScanKeyStart2879( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z599ClienteDocumentoId = A599ClienteDocumentoId;
         }
         ZM2879( -15) ;
         OnLoadActions2879( ) ;
         AddRow2879( ) ;
         ScanKeyEnd2879( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2879( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2879( ) ;
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
               {
                  A599ClienteDocumentoId = Z599ClienteDocumentoId;
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
                  Update2879( ) ;
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
                  if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
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
                        Insert2879( ) ;
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
                        Insert2879( ) ;
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
         RowToVars79( bcClienteDocumento, 1) ;
         SaveImpl( ) ;
         VarsToRow79( bcClienteDocumento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars79( bcClienteDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2879( ) ;
         AfterTrn( ) ;
         VarsToRow79( bcClienteDocumento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow79( bcClienteDocumento) ;
         }
         else
         {
            SdtClienteDocumento auxBC = new SdtClienteDocumento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A599ClienteDocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcClienteDocumento);
               auxBC.Save();
               bcClienteDocumento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars79( bcClienteDocumento, 1) ;
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
         RowToVars79( bcClienteDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2879( ) ;
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
               VarsToRow79( bcClienteDocumento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow79( bcClienteDocumento) ;
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
         RowToVars79( bcClienteDocumento, 0) ;
         GetKey2879( ) ;
         if ( RcdFound79 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
            {
               A599ClienteDocumentoId = Z599ClienteDocumentoId;
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
            if ( A599ClienteDocumentoId != Z599ClienteDocumentoId )
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
         context.RollbackDataStores("clientedocumento_bc",pr_default);
         VarsToRow79( bcClienteDocumento) ;
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
         Gx_mode = bcClienteDocumento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcClienteDocumento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcClienteDocumento )
         {
            bcClienteDocumento = (SdtClienteDocumento)(sdt);
            if ( StringUtil.StrCmp(bcClienteDocumento.gxTpr_Mode, "") == 0 )
            {
               bcClienteDocumento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow79( bcClienteDocumento) ;
            }
            else
            {
               RowToVars79( bcClienteDocumento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcClienteDocumento.gxTpr_Mode, "") == 0 )
            {
               bcClienteDocumento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars79( bcClienteDocumento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtClienteDocumento ClienteDocumento_BC
      {
         get {
            return bcClienteDocumento ;
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV32Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV26Nome = "";
         A601ClienteDocumentoBlob = "";
         A601ClienteDocumentoBlob_Filename = "";
         AV27Ext = "";
         AV25NomeDoArquivo = "";
         Z604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         A604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         A605ClienteDocumentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z603ClienteDocumentoExtensao = "";
         A603ClienteDocumentoExtensao = "";
         Z602ClienteDocumentoNome = "";
         A602ClienteDocumentoNome = "";
         Z607ClienteNomeDoArquivo_F = "";
         A607ClienteNomeDoArquivo_F = "";
         Z406DocumentosDescricao = "";
         A406DocumentosDescricao = "";
         Z601ClienteDocumentoBlob = "";
         BC00287_A599ClienteDocumentoId = new int[1] ;
         BC00287_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00287_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         BC00287_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00287_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         BC00287_A603ClienteDocumentoExtensao = new string[] {""} ;
         BC00287_n603ClienteDocumentoExtensao = new bool[] {false} ;
         BC00287_A406DocumentosDescricao = new string[] {""} ;
         BC00287_n406DocumentosDescricao = new bool[] {false} ;
         BC00287_A602ClienteDocumentoNome = new string[] {""} ;
         BC00287_n602ClienteDocumentoNome = new bool[] {false} ;
         BC00287_A168ClienteId = new int[1] ;
         BC00287_n168ClienteId = new bool[] {false} ;
         BC00287_A405DocumentosId = new int[1] ;
         BC00287_n405DocumentosId = new bool[] {false} ;
         BC00287_A606ClienteDocumentoCreatedBy = new short[1] ;
         BC00287_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         BC00287_A601ClienteDocumentoBlob = new string[] {""} ;
         BC00287_n601ClienteDocumentoBlob = new bool[] {false} ;
         A601ClienteDocumentoBlob_Filetype = "";
         BC00284_A168ClienteId = new int[1] ;
         BC00284_n168ClienteId = new bool[] {false} ;
         BC00285_A406DocumentosDescricao = new string[] {""} ;
         BC00285_n406DocumentosDescricao = new bool[] {false} ;
         BC00286_A606ClienteDocumentoCreatedBy = new short[1] ;
         BC00286_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         BC00288_A599ClienteDocumentoId = new int[1] ;
         BC00283_A599ClienteDocumentoId = new int[1] ;
         BC00283_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00283_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         BC00283_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00283_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         BC00283_A603ClienteDocumentoExtensao = new string[] {""} ;
         BC00283_n603ClienteDocumentoExtensao = new bool[] {false} ;
         BC00283_A602ClienteDocumentoNome = new string[] {""} ;
         BC00283_n602ClienteDocumentoNome = new bool[] {false} ;
         BC00283_A168ClienteId = new int[1] ;
         BC00283_n168ClienteId = new bool[] {false} ;
         BC00283_A405DocumentosId = new int[1] ;
         BC00283_n405DocumentosId = new bool[] {false} ;
         BC00283_A606ClienteDocumentoCreatedBy = new short[1] ;
         BC00283_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         BC00283_A601ClienteDocumentoBlob = new string[] {""} ;
         BC00283_n601ClienteDocumentoBlob = new bool[] {false} ;
         sMode79 = "";
         BC00282_A599ClienteDocumentoId = new int[1] ;
         BC00282_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00282_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         BC00282_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00282_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         BC00282_A603ClienteDocumentoExtensao = new string[] {""} ;
         BC00282_n603ClienteDocumentoExtensao = new bool[] {false} ;
         BC00282_A602ClienteDocumentoNome = new string[] {""} ;
         BC00282_n602ClienteDocumentoNome = new bool[] {false} ;
         BC00282_A168ClienteId = new int[1] ;
         BC00282_n168ClienteId = new bool[] {false} ;
         BC00282_A405DocumentosId = new int[1] ;
         BC00282_n405DocumentosId = new bool[] {false} ;
         BC00282_A606ClienteDocumentoCreatedBy = new short[1] ;
         BC00282_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         BC00282_A601ClienteDocumentoBlob = new string[] {""} ;
         BC00282_n601ClienteDocumentoBlob = new bool[] {false} ;
         BC002810_A599ClienteDocumentoId = new int[1] ;
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         BC002814_A406DocumentosDescricao = new string[] {""} ;
         BC002814_n406DocumentosDescricao = new bool[] {false} ;
         BC002815_A599ClienteDocumentoId = new int[1] ;
         BC002815_A604ClienteDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002815_n604ClienteDocumentoCreatedAt = new bool[] {false} ;
         BC002815_A605ClienteDocumentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002815_n605ClienteDocumentoUpdatedAt = new bool[] {false} ;
         BC002815_A603ClienteDocumentoExtensao = new string[] {""} ;
         BC002815_n603ClienteDocumentoExtensao = new bool[] {false} ;
         BC002815_A406DocumentosDescricao = new string[] {""} ;
         BC002815_n406DocumentosDescricao = new bool[] {false} ;
         BC002815_A602ClienteDocumentoNome = new string[] {""} ;
         BC002815_n602ClienteDocumentoNome = new bool[] {false} ;
         BC002815_A168ClienteId = new int[1] ;
         BC002815_n168ClienteId = new bool[] {false} ;
         BC002815_A405DocumentosId = new int[1] ;
         BC002815_n405DocumentosId = new bool[] {false} ;
         BC002815_A606ClienteDocumentoCreatedBy = new short[1] ;
         BC002815_n606ClienteDocumentoCreatedBy = new bool[] {false} ;
         BC002815_A601ClienteDocumentoBlob = new string[] {""} ;
         BC002815_n601ClienteDocumentoBlob = new bool[] {false} ;
         i604ClienteDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientedocumento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00282_A599ClienteDocumentoId, BC00282_A604ClienteDocumentoCreatedAt, BC00282_n604ClienteDocumentoCreatedAt, BC00282_A605ClienteDocumentoUpdatedAt, BC00282_n605ClienteDocumentoUpdatedAt, BC00282_A603ClienteDocumentoExtensao, BC00282_n603ClienteDocumentoExtensao, BC00282_A602ClienteDocumentoNome, BC00282_n602ClienteDocumentoNome, BC00282_A168ClienteId,
               BC00282_n168ClienteId, BC00282_A405DocumentosId, BC00282_n405DocumentosId, BC00282_A606ClienteDocumentoCreatedBy, BC00282_n606ClienteDocumentoCreatedBy, BC00282_A601ClienteDocumentoBlob, BC00282_n601ClienteDocumentoBlob
               }
               , new Object[] {
               BC00283_A599ClienteDocumentoId, BC00283_A604ClienteDocumentoCreatedAt, BC00283_n604ClienteDocumentoCreatedAt, BC00283_A605ClienteDocumentoUpdatedAt, BC00283_n605ClienteDocumentoUpdatedAt, BC00283_A603ClienteDocumentoExtensao, BC00283_n603ClienteDocumentoExtensao, BC00283_A602ClienteDocumentoNome, BC00283_n602ClienteDocumentoNome, BC00283_A168ClienteId,
               BC00283_n168ClienteId, BC00283_A405DocumentosId, BC00283_n405DocumentosId, BC00283_A606ClienteDocumentoCreatedBy, BC00283_n606ClienteDocumentoCreatedBy, BC00283_A601ClienteDocumentoBlob, BC00283_n601ClienteDocumentoBlob
               }
               , new Object[] {
               BC00284_A168ClienteId
               }
               , new Object[] {
               BC00285_A406DocumentosDescricao, BC00285_n406DocumentosDescricao
               }
               , new Object[] {
               BC00286_A606ClienteDocumentoCreatedBy
               }
               , new Object[] {
               BC00287_A599ClienteDocumentoId, BC00287_A604ClienteDocumentoCreatedAt, BC00287_n604ClienteDocumentoCreatedAt, BC00287_A605ClienteDocumentoUpdatedAt, BC00287_n605ClienteDocumentoUpdatedAt, BC00287_A603ClienteDocumentoExtensao, BC00287_n603ClienteDocumentoExtensao, BC00287_A406DocumentosDescricao, BC00287_n406DocumentosDescricao, BC00287_A602ClienteDocumentoNome,
               BC00287_n602ClienteDocumentoNome, BC00287_A168ClienteId, BC00287_n168ClienteId, BC00287_A405DocumentosId, BC00287_n405DocumentosId, BC00287_A606ClienteDocumentoCreatedBy, BC00287_n606ClienteDocumentoCreatedBy, BC00287_A601ClienteDocumentoBlob, BC00287_n601ClienteDocumentoBlob
               }
               , new Object[] {
               BC00288_A599ClienteDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002810_A599ClienteDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002814_A406DocumentosDescricao, BC002814_n406DocumentosDescricao
               }
               , new Object[] {
               BC002815_A599ClienteDocumentoId, BC002815_A604ClienteDocumentoCreatedAt, BC002815_n604ClienteDocumentoCreatedAt, BC002815_A605ClienteDocumentoUpdatedAt, BC002815_n605ClienteDocumentoUpdatedAt, BC002815_A603ClienteDocumentoExtensao, BC002815_n603ClienteDocumentoExtensao, BC002815_A406DocumentosDescricao, BC002815_n406DocumentosDescricao, BC002815_A602ClienteDocumentoNome,
               BC002815_n602ClienteDocumentoNome, BC002815_A168ClienteId, BC002815_n168ClienteId, BC002815_A405DocumentosId, BC002815_n405DocumentosId, BC002815_A606ClienteDocumentoCreatedBy, BC002815_n606ClienteDocumentoCreatedBy, BC002815_A601ClienteDocumentoBlob, BC002815_n601ClienteDocumentoBlob
               }
            }
         );
         AV32Pgmname = "ClienteDocumento_BC";
         Z604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         A604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         i604ClienteDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n604ClienteDocumentoCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12282 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_ClienteDocumentoCreatedBy ;
      private short AV28index ;
      private short Z606ClienteDocumentoCreatedBy ;
      private short A606ClienteDocumentoCreatedBy ;
      private short Gx_BScreen ;
      private short RcdFound79 ;
      private int trnEnded ;
      private int Z599ClienteDocumentoId ;
      private int A599ClienteDocumentoId ;
      private int AV33GXV1 ;
      private int AV11Insert_ClienteId ;
      private int AV23Insert_DocumentosId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z405DocumentosId ;
      private int A405DocumentosId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV32Pgmname ;
      private string A601ClienteDocumentoBlob_Filename ;
      private string A601ClienteDocumentoBlob_Filetype ;
      private string sMode79 ;
      private DateTime Z604ClienteDocumentoCreatedAt ;
      private DateTime A604ClienteDocumentoCreatedAt ;
      private DateTime Z605ClienteDocumentoUpdatedAt ;
      private DateTime A605ClienteDocumentoUpdatedAt ;
      private DateTime i604ClienteDocumentoCreatedAt ;
      private bool returnInSub ;
      private bool n605ClienteDocumentoUpdatedAt ;
      private bool n604ClienteDocumentoCreatedAt ;
      private bool n603ClienteDocumentoExtensao ;
      private bool n406DocumentosDescricao ;
      private bool n602ClienteDocumentoNome ;
      private bool n168ClienteId ;
      private bool n405DocumentosId ;
      private bool n606ClienteDocumentoCreatedBy ;
      private bool n601ClienteDocumentoBlob ;
      private bool Gx_longc ;
      private string AV26Nome ;
      private string AV27Ext ;
      private string AV25NomeDoArquivo ;
      private string Z603ClienteDocumentoExtensao ;
      private string A603ClienteDocumentoExtensao ;
      private string Z602ClienteDocumentoNome ;
      private string A602ClienteDocumentoNome ;
      private string Z607ClienteNomeDoArquivo_F ;
      private string A607ClienteNomeDoArquivo_F ;
      private string Z406DocumentosDescricao ;
      private string A406DocumentosDescricao ;
      private string A601ClienteDocumentoBlob ;
      private string Z601ClienteDocumentoBlob ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00287_A599ClienteDocumentoId ;
      private DateTime[] BC00287_A604ClienteDocumentoCreatedAt ;
      private bool[] BC00287_n604ClienteDocumentoCreatedAt ;
      private DateTime[] BC00287_A605ClienteDocumentoUpdatedAt ;
      private bool[] BC00287_n605ClienteDocumentoUpdatedAt ;
      private string[] BC00287_A603ClienteDocumentoExtensao ;
      private bool[] BC00287_n603ClienteDocumentoExtensao ;
      private string[] BC00287_A406DocumentosDescricao ;
      private bool[] BC00287_n406DocumentosDescricao ;
      private string[] BC00287_A602ClienteDocumentoNome ;
      private bool[] BC00287_n602ClienteDocumentoNome ;
      private int[] BC00287_A168ClienteId ;
      private bool[] BC00287_n168ClienteId ;
      private int[] BC00287_A405DocumentosId ;
      private bool[] BC00287_n405DocumentosId ;
      private short[] BC00287_A606ClienteDocumentoCreatedBy ;
      private bool[] BC00287_n606ClienteDocumentoCreatedBy ;
      private string[] BC00287_A601ClienteDocumentoBlob ;
      private bool[] BC00287_n601ClienteDocumentoBlob ;
      private int[] BC00284_A168ClienteId ;
      private bool[] BC00284_n168ClienteId ;
      private string[] BC00285_A406DocumentosDescricao ;
      private bool[] BC00285_n406DocumentosDescricao ;
      private short[] BC00286_A606ClienteDocumentoCreatedBy ;
      private bool[] BC00286_n606ClienteDocumentoCreatedBy ;
      private int[] BC00288_A599ClienteDocumentoId ;
      private int[] BC00283_A599ClienteDocumentoId ;
      private DateTime[] BC00283_A604ClienteDocumentoCreatedAt ;
      private bool[] BC00283_n604ClienteDocumentoCreatedAt ;
      private DateTime[] BC00283_A605ClienteDocumentoUpdatedAt ;
      private bool[] BC00283_n605ClienteDocumentoUpdatedAt ;
      private string[] BC00283_A603ClienteDocumentoExtensao ;
      private bool[] BC00283_n603ClienteDocumentoExtensao ;
      private string[] BC00283_A602ClienteDocumentoNome ;
      private bool[] BC00283_n602ClienteDocumentoNome ;
      private int[] BC00283_A168ClienteId ;
      private bool[] BC00283_n168ClienteId ;
      private int[] BC00283_A405DocumentosId ;
      private bool[] BC00283_n405DocumentosId ;
      private short[] BC00283_A606ClienteDocumentoCreatedBy ;
      private bool[] BC00283_n606ClienteDocumentoCreatedBy ;
      private string[] BC00283_A601ClienteDocumentoBlob ;
      private bool[] BC00283_n601ClienteDocumentoBlob ;
      private int[] BC00282_A599ClienteDocumentoId ;
      private DateTime[] BC00282_A604ClienteDocumentoCreatedAt ;
      private bool[] BC00282_n604ClienteDocumentoCreatedAt ;
      private DateTime[] BC00282_A605ClienteDocumentoUpdatedAt ;
      private bool[] BC00282_n605ClienteDocumentoUpdatedAt ;
      private string[] BC00282_A603ClienteDocumentoExtensao ;
      private bool[] BC00282_n603ClienteDocumentoExtensao ;
      private string[] BC00282_A602ClienteDocumentoNome ;
      private bool[] BC00282_n602ClienteDocumentoNome ;
      private int[] BC00282_A168ClienteId ;
      private bool[] BC00282_n168ClienteId ;
      private int[] BC00282_A405DocumentosId ;
      private bool[] BC00282_n405DocumentosId ;
      private short[] BC00282_A606ClienteDocumentoCreatedBy ;
      private bool[] BC00282_n606ClienteDocumentoCreatedBy ;
      private string[] BC00282_A601ClienteDocumentoBlob ;
      private bool[] BC00282_n601ClienteDocumentoBlob ;
      private int[] BC002810_A599ClienteDocumentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private string[] BC002814_A406DocumentosDescricao ;
      private bool[] BC002814_n406DocumentosDescricao ;
      private int[] BC002815_A599ClienteDocumentoId ;
      private DateTime[] BC002815_A604ClienteDocumentoCreatedAt ;
      private bool[] BC002815_n604ClienteDocumentoCreatedAt ;
      private DateTime[] BC002815_A605ClienteDocumentoUpdatedAt ;
      private bool[] BC002815_n605ClienteDocumentoUpdatedAt ;
      private string[] BC002815_A603ClienteDocumentoExtensao ;
      private bool[] BC002815_n603ClienteDocumentoExtensao ;
      private string[] BC002815_A406DocumentosDescricao ;
      private bool[] BC002815_n406DocumentosDescricao ;
      private string[] BC002815_A602ClienteDocumentoNome ;
      private bool[] BC002815_n602ClienteDocumentoNome ;
      private int[] BC002815_A168ClienteId ;
      private bool[] BC002815_n168ClienteId ;
      private int[] BC002815_A405DocumentosId ;
      private bool[] BC002815_n405DocumentosId ;
      private short[] BC002815_A606ClienteDocumentoCreatedBy ;
      private bool[] BC002815_n606ClienteDocumentoCreatedBy ;
      private string[] BC002815_A601ClienteDocumentoBlob ;
      private bool[] BC002815_n601ClienteDocumentoBlob ;
      private SdtClienteDocumento bcClienteDocumento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clientedocumento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00282;
          prmBC00282 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00283;
          prmBC00283 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00284;
          prmBC00284 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00285;
          prmBC00285 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00286;
          prmBC00286 = new Object[] {
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00287;
          prmBC00287 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00288;
          prmBC00288 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00289;
          prmBC00289 = new Object[] {
          new ParDef("ClienteDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoExtensao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ClienteDocumentoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002810;
          prmBC002810 = new Object[] {
          };
          Object[] prmBC002811;
          prmBC002811 = new Object[] {
          new ParDef("ClienteDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumentoExtensao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteDocumentoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteDocumentoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002812;
          prmBC002812 = new Object[] {
          new ParDef("ClienteDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002813;
          prmBC002813 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002814;
          prmBC002814 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002815;
          prmBC002815 = new Object[] {
          new ParDef("ClienteDocumentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00282", "SELECT ClienteDocumentoId, ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy, ClienteDocumentoBlob FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId  FOR UPDATE OF ClienteDocumento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00282,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00283", "SELECT ClienteDocumentoId, ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy, ClienteDocumentoBlob FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00283,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00284", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00284,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00285", "SELECT DocumentosDescricao FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00285,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00286", "SELECT SecUserId AS ClienteDocumentoCreatedBy FROM SecUser WHERE SecUserId = :ClienteDocumentoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00286,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00287", "SELECT TM1.ClienteDocumentoId, TM1.ClienteDocumentoCreatedAt, TM1.ClienteDocumentoUpdatedAt, TM1.ClienteDocumentoExtensao, T2.DocumentosDescricao, TM1.ClienteDocumentoNome, TM1.ClienteId, TM1.DocumentosId, TM1.ClienteDocumentoCreatedBy AS ClienteDocumentoCreatedBy, TM1.ClienteDocumentoBlob FROM (ClienteDocumento TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.ClienteDocumentoId = :ClienteDocumentoId ORDER BY TM1.ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00287,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00288", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoId = :ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00288,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00289", "SAVEPOINT gxupdate;INSERT INTO ClienteDocumento(ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao, ClienteDocumentoBlob, ClienteDocumentoNome, ClienteId, DocumentosId, ClienteDocumentoCreatedBy) VALUES(:ClienteDocumentoCreatedAt, :ClienteDocumentoUpdatedAt, :ClienteDocumentoExtensao, :ClienteDocumentoBlob, :ClienteDocumentoNome, :ClienteId, :DocumentosId, :ClienteDocumentoCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00289)
             ,new CursorDef("BC002810", "SELECT currval('ClienteDocumentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002810,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002811", "SAVEPOINT gxupdate;UPDATE ClienteDocumento SET ClienteDocumentoCreatedAt=:ClienteDocumentoCreatedAt, ClienteDocumentoUpdatedAt=:ClienteDocumentoUpdatedAt, ClienteDocumentoExtensao=:ClienteDocumentoExtensao, ClienteDocumentoNome=:ClienteDocumentoNome, ClienteId=:ClienteId, DocumentosId=:DocumentosId, ClienteDocumentoCreatedBy=:ClienteDocumentoCreatedBy  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002811)
             ,new CursorDef("BC002812", "SAVEPOINT gxupdate;UPDATE ClienteDocumento SET ClienteDocumentoBlob=:ClienteDocumentoBlob  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002812)
             ,new CursorDef("BC002813", "SAVEPOINT gxupdate;DELETE FROM ClienteDocumento  WHERE ClienteDocumentoId = :ClienteDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002813)
             ,new CursorDef("BC002814", "SELECT DocumentosDescricao FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002814,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002815", "SELECT TM1.ClienteDocumentoId, TM1.ClienteDocumentoCreatedAt, TM1.ClienteDocumentoUpdatedAt, TM1.ClienteDocumentoExtensao, T2.DocumentosDescricao, TM1.ClienteDocumentoNome, TM1.ClienteId, TM1.DocumentosId, TM1.ClienteDocumentoCreatedBy AS ClienteDocumentoCreatedBy, TM1.ClienteDocumentoBlob FROM (ClienteDocumento TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.ClienteDocumentoId = :ClienteDocumentoId ORDER BY TM1.ClienteDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002815,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(9, "tmp", "");
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(9, "tmp", "");
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
