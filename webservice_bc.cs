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
   public class webservice_bc : GxSilentTrn, IGxSilentTrn
   {
      public webservice_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webservice_bc( IGxContext context )
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
         ReadRow2D83( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2D83( ) ;
         standaloneModal( ) ;
         AddRow2D83( ) ;
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
            E112D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z656WebServiceId = A656WebServiceId;
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

      protected void CONFIRM_2D0( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2D83( ) ;
            }
            else
            {
               CheckExtendedTable2D83( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2D83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E112D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2D83( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
         }
         if ( GX_JID == -10 )
         {
            Z656WebServiceId = A656WebServiceId;
            Z657WebServiceTipoDmWS = A657WebServiceTipoDmWS;
            Z658WebServiceEndPoint = A658WebServiceEndPoint;
            Z659WebServiceAuthTipo = A659WebServiceAuthTipo;
            Z660WebServiceUsuario = A660WebServiceUsuario;
            Z661WebServiceSenha = A661WebServiceSenha;
            Z1054WebServiceSalt = A1054WebServiceSalt;
            Z1055WebServiceCertificadoBase64 = A1055WebServiceCertificadoBase64;
            Z1056WebServiceCertificadoPass = A1056WebServiceCertificadoPass;
            Z1059WebServiceClientid = A1059WebServiceClientid;
            Z1060WebServiceClientSecret = A1060WebServiceClientSecret;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2D83( )
      {
         /* Using cursor BC002D4 */
         pr_default.execute(2, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound83 = 1;
            A657WebServiceTipoDmWS = BC002D4_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = BC002D4_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = BC002D4_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = BC002D4_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = BC002D4_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = BC002D4_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = BC002D4_A660WebServiceUsuario[0];
            n660WebServiceUsuario = BC002D4_n660WebServiceUsuario[0];
            A661WebServiceSenha = BC002D4_A661WebServiceSenha[0];
            n661WebServiceSenha = BC002D4_n661WebServiceSenha[0];
            A1054WebServiceSalt = BC002D4_A1054WebServiceSalt[0];
            n1054WebServiceSalt = BC002D4_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = BC002D4_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = BC002D4_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = BC002D4_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = BC002D4_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = BC002D4_A1059WebServiceClientid[0];
            n1059WebServiceClientid = BC002D4_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = BC002D4_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = BC002D4_n1060WebServiceClientSecret[0];
            ZM2D83( -10) ;
         }
         pr_default.close(2);
         OnLoadActions2D83( ) ;
      }

      protected void OnLoadActions2D83( )
      {
         GXt_char1 = A1061WebServiceEndPointDecrypted;
         new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
         A1061WebServiceEndPointDecrypted = GXt_char1;
         GXt_char1 = A1062WebServiceAuthTipoDecrypted;
         new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
         A1062WebServiceAuthTipoDecrypted = GXt_char1;
         GXt_char1 = A1063WebServiceUsuarioDecrypted;
         new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
         A1063WebServiceUsuarioDecrypted = GXt_char1;
         GXt_char1 = A1064WebServiceSenhaDecrypted;
         new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
         A1064WebServiceSenhaDecrypted = GXt_char1;
         GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
         new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
         A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
         GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
         new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
         A1066WebServiceCertificadoPassDecrypted = GXt_char1;
         GXt_char1 = A1067WebServiceClientidDecrypted;
         new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
         A1067WebServiceClientidDecrypted = GXt_char1;
         GXt_char1 = A1068WebServiceClientSecretDecrypted;
         new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
         A1068WebServiceClientSecretDecrypted = GXt_char1;
      }

      protected void CheckExtendedTable2D83( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) || ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) || ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A657WebServiceTipoDmWS)) ) )
         {
            GX_msglist.addItem("Campo Tipo WS fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         GXt_char1 = A1061WebServiceEndPointDecrypted;
         new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
         A1061WebServiceEndPointDecrypted = GXt_char1;
         GXt_char1 = A1062WebServiceAuthTipoDecrypted;
         new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
         A1062WebServiceAuthTipoDecrypted = GXt_char1;
         GXt_char1 = A1063WebServiceUsuarioDecrypted;
         new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
         A1063WebServiceUsuarioDecrypted = GXt_char1;
         GXt_char1 = A1064WebServiceSenhaDecrypted;
         new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
         A1064WebServiceSenhaDecrypted = GXt_char1;
         GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
         new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
         A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
         GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
         new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
         A1066WebServiceCertificadoPassDecrypted = GXt_char1;
         GXt_char1 = A1067WebServiceClientidDecrypted;
         new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
         A1067WebServiceClientidDecrypted = GXt_char1;
         GXt_char1 = A1068WebServiceClientSecretDecrypted;
         new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
         A1068WebServiceClientSecretDecrypted = GXt_char1;
      }

      protected void CloseExtendedTableCursors2D83( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2D83( )
      {
         /* Using cursor BC002D5 */
         pr_default.execute(3, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002D3 */
         pr_default.execute(1, new Object[] {A656WebServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2D83( 10) ;
            RcdFound83 = 1;
            A656WebServiceId = BC002D3_A656WebServiceId[0];
            A657WebServiceTipoDmWS = BC002D3_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = BC002D3_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = BC002D3_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = BC002D3_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = BC002D3_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = BC002D3_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = BC002D3_A660WebServiceUsuario[0];
            n660WebServiceUsuario = BC002D3_n660WebServiceUsuario[0];
            A661WebServiceSenha = BC002D3_A661WebServiceSenha[0];
            n661WebServiceSenha = BC002D3_n661WebServiceSenha[0];
            A1054WebServiceSalt = BC002D3_A1054WebServiceSalt[0];
            n1054WebServiceSalt = BC002D3_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = BC002D3_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = BC002D3_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = BC002D3_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = BC002D3_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = BC002D3_A1059WebServiceClientid[0];
            n1059WebServiceClientid = BC002D3_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = BC002D3_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = BC002D3_n1060WebServiceClientSecret[0];
            Z656WebServiceId = A656WebServiceId;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2D83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey2D83( ) ;
            }
            Gx_mode = sMode83;
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey2D83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode83;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2D83( ) ;
         if ( RcdFound83 == 0 )
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
         CONFIRM_2D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2D83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002D2 */
            pr_default.execute(0, new Object[] {A656WebServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z657WebServiceTipoDmWS, BC002D2_A657WebServiceTipoDmWS[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WebService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2D83( 0) ;
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002D6 */
                     pr_default.execute(4, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha, n1054WebServiceSalt, A1054WebServiceSalt, n1055WebServiceCertificadoBase64, A1055WebServiceCertificadoBase64, n1056WebServiceCertificadoPass, A1056WebServiceCertificadoPass, n1059WebServiceClientid, A1059WebServiceClientid, n1060WebServiceClientSecret, A1060WebServiceClientSecret});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002D7 */
                     pr_default.execute(5);
                     A656WebServiceId = BC002D7_A656WebServiceId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
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
               Load2D83( ) ;
            }
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void Update2D83( )
      {
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2D83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002D8 */
                     pr_default.execute(6, new Object[] {n657WebServiceTipoDmWS, A657WebServiceTipoDmWS, n658WebServiceEndPoint, A658WebServiceEndPoint, n659WebServiceAuthTipo, A659WebServiceAuthTipo, n660WebServiceUsuario, A660WebServiceUsuario, n661WebServiceSenha, A661WebServiceSenha, n1054WebServiceSalt, A1054WebServiceSalt, n1055WebServiceCertificadoBase64, A1055WebServiceCertificadoBase64, n1056WebServiceCertificadoPass, A1056WebServiceCertificadoPass, n1059WebServiceClientid, A1059WebServiceClientid, n1060WebServiceClientSecret, A1060WebServiceClientSecret, A656WebServiceId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WebService");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WebService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2D83( ) ;
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
            EndLevel2D83( ) ;
         }
         CloseExtendedTableCursors2D83( ) ;
      }

      protected void DeferredUpdate2D83( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2D83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2D83( ) ;
            AfterConfirm2D83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2D83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002D9 */
                  pr_default.execute(7, new Object[] {A656WebServiceId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WebService");
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2D83( ) ;
         Gx_mode = sMode83;
      }

      protected void OnDeleteControls2D83( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char1 = A1061WebServiceEndPointDecrypted;
            new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
            A1061WebServiceEndPointDecrypted = GXt_char1;
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            GXt_char1 = A1063WebServiceUsuarioDecrypted;
            new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
            A1063WebServiceUsuarioDecrypted = GXt_char1;
            GXt_char1 = A1064WebServiceSenhaDecrypted;
            new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
            A1064WebServiceSenhaDecrypted = GXt_char1;
            GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
            new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
            A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
            GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
            new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
            A1066WebServiceCertificadoPassDecrypted = GXt_char1;
            GXt_char1 = A1067WebServiceClientidDecrypted;
            new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
            A1067WebServiceClientidDecrypted = GXt_char1;
            GXt_char1 = A1068WebServiceClientSecretDecrypted;
            new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
            A1068WebServiceClientSecretDecrypted = GXt_char1;
         }
      }

      protected void EndLevel2D83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2D83( ) ;
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

      public void ScanKeyStart2D83( )
      {
         /* Scan By routine */
         /* Using cursor BC002D10 */
         pr_default.execute(8, new Object[] {A656WebServiceId});
         RcdFound83 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = BC002D10_A656WebServiceId[0];
            A657WebServiceTipoDmWS = BC002D10_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = BC002D10_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = BC002D10_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = BC002D10_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = BC002D10_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = BC002D10_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = BC002D10_A660WebServiceUsuario[0];
            n660WebServiceUsuario = BC002D10_n660WebServiceUsuario[0];
            A661WebServiceSenha = BC002D10_A661WebServiceSenha[0];
            n661WebServiceSenha = BC002D10_n661WebServiceSenha[0];
            A1054WebServiceSalt = BC002D10_A1054WebServiceSalt[0];
            n1054WebServiceSalt = BC002D10_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = BC002D10_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = BC002D10_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = BC002D10_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = BC002D10_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = BC002D10_A1059WebServiceClientid[0];
            n1059WebServiceClientid = BC002D10_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = BC002D10_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = BC002D10_n1060WebServiceClientSecret[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2D83( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound83 = 0;
         ScanKeyLoad2D83( ) ;
      }

      protected void ScanKeyLoad2D83( )
      {
         sMode83 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound83 = 1;
            A656WebServiceId = BC002D10_A656WebServiceId[0];
            A657WebServiceTipoDmWS = BC002D10_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = BC002D10_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = BC002D10_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = BC002D10_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = BC002D10_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = BC002D10_n659WebServiceAuthTipo[0];
            A660WebServiceUsuario = BC002D10_A660WebServiceUsuario[0];
            n660WebServiceUsuario = BC002D10_n660WebServiceUsuario[0];
            A661WebServiceSenha = BC002D10_A661WebServiceSenha[0];
            n661WebServiceSenha = BC002D10_n661WebServiceSenha[0];
            A1054WebServiceSalt = BC002D10_A1054WebServiceSalt[0];
            n1054WebServiceSalt = BC002D10_n1054WebServiceSalt[0];
            A1055WebServiceCertificadoBase64 = BC002D10_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = BC002D10_n1055WebServiceCertificadoBase64[0];
            A1056WebServiceCertificadoPass = BC002D10_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = BC002D10_n1056WebServiceCertificadoPass[0];
            A1059WebServiceClientid = BC002D10_A1059WebServiceClientid[0];
            n1059WebServiceClientid = BC002D10_n1059WebServiceClientid[0];
            A1060WebServiceClientSecret = BC002D10_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = BC002D10_n1060WebServiceClientSecret[0];
         }
         Gx_mode = sMode83;
      }

      protected void ScanKeyEnd2D83( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2D83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2D83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2D83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2D83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2D83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2D83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2D83( )
      {
      }

      protected void send_integrity_lvl_hashes2D83( )
      {
      }

      protected void AddRow2D83( )
      {
         VarsToRow83( bcWebService) ;
      }

      protected void ReadRow2D83( )
      {
         RowToVars83( bcWebService, 1) ;
      }

      protected void InitializeNonKey2D83( )
      {
         A1068WebServiceClientSecretDecrypted = "";
         A1067WebServiceClientidDecrypted = "";
         A1066WebServiceCertificadoPassDecrypted = "";
         A1065WebServiceCertificadoBase64Decrypted = "";
         A1064WebServiceSenhaDecrypted = "";
         A1063WebServiceUsuarioDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         A1061WebServiceEndPointDecrypted = "";
         A657WebServiceTipoDmWS = "";
         n657WebServiceTipoDmWS = false;
         A658WebServiceEndPoint = "";
         n658WebServiceEndPoint = false;
         A659WebServiceAuthTipo = "";
         n659WebServiceAuthTipo = false;
         A660WebServiceUsuario = "";
         n660WebServiceUsuario = false;
         A661WebServiceSenha = "";
         n661WebServiceSenha = false;
         A1054WebServiceSalt = "";
         n1054WebServiceSalt = false;
         A1055WebServiceCertificadoBase64 = "";
         n1055WebServiceCertificadoBase64 = false;
         A1056WebServiceCertificadoPass = "";
         n1056WebServiceCertificadoPass = false;
         A1059WebServiceClientid = "";
         n1059WebServiceClientid = false;
         A1060WebServiceClientSecret = "";
         n1060WebServiceClientSecret = false;
         Z657WebServiceTipoDmWS = "";
      }

      protected void InitAll2D83( )
      {
         A656WebServiceId = 0;
         InitializeNonKey2D83( ) ;
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

      public void VarsToRow83( SdtWebService obj83 )
      {
         obj83.gxTpr_Mode = Gx_mode;
         obj83.gxTpr_Webserviceclientsecretdecrypted = A1068WebServiceClientSecretDecrypted;
         obj83.gxTpr_Webserviceclientiddecrypted = A1067WebServiceClientidDecrypted;
         obj83.gxTpr_Webservicecertificadopassdecrypted = A1066WebServiceCertificadoPassDecrypted;
         obj83.gxTpr_Webservicecertificadobase64decrypted = A1065WebServiceCertificadoBase64Decrypted;
         obj83.gxTpr_Webservicesenhadecrypted = A1064WebServiceSenhaDecrypted;
         obj83.gxTpr_Webserviceusuariodecrypted = A1063WebServiceUsuarioDecrypted;
         obj83.gxTpr_Webserviceauthtipodecrypted = A1062WebServiceAuthTipoDecrypted;
         obj83.gxTpr_Webserviceendpointdecrypted = A1061WebServiceEndPointDecrypted;
         obj83.gxTpr_Webservicetipodmws = A657WebServiceTipoDmWS;
         obj83.gxTpr_Webserviceendpoint = A658WebServiceEndPoint;
         obj83.gxTpr_Webserviceauthtipo = A659WebServiceAuthTipo;
         obj83.gxTpr_Webserviceusuario = A660WebServiceUsuario;
         obj83.gxTpr_Webservicesenha = A661WebServiceSenha;
         obj83.gxTpr_Webservicesalt = A1054WebServiceSalt;
         obj83.gxTpr_Webservicecertificadobase64 = A1055WebServiceCertificadoBase64;
         obj83.gxTpr_Webservicecertificadopass = A1056WebServiceCertificadoPass;
         obj83.gxTpr_Webserviceclientid = A1059WebServiceClientid;
         obj83.gxTpr_Webserviceclientsecret = A1060WebServiceClientSecret;
         obj83.gxTpr_Webserviceid = A656WebServiceId;
         obj83.gxTpr_Webserviceid_Z = Z656WebServiceId;
         obj83.gxTpr_Webservicetipodmws_Z = Z657WebServiceTipoDmWS;
         obj83.gxTpr_Webservicetipodmws_N = (short)(Convert.ToInt16(n657WebServiceTipoDmWS));
         obj83.gxTpr_Webserviceendpoint_N = (short)(Convert.ToInt16(n658WebServiceEndPoint));
         obj83.gxTpr_Webserviceauthtipo_N = (short)(Convert.ToInt16(n659WebServiceAuthTipo));
         obj83.gxTpr_Webserviceusuario_N = (short)(Convert.ToInt16(n660WebServiceUsuario));
         obj83.gxTpr_Webservicesenha_N = (short)(Convert.ToInt16(n661WebServiceSenha));
         obj83.gxTpr_Webservicesalt_N = (short)(Convert.ToInt16(n1054WebServiceSalt));
         obj83.gxTpr_Webservicecertificadobase64_N = (short)(Convert.ToInt16(n1055WebServiceCertificadoBase64));
         obj83.gxTpr_Webservicecertificadopass_N = (short)(Convert.ToInt16(n1056WebServiceCertificadoPass));
         obj83.gxTpr_Webserviceclientid_N = (short)(Convert.ToInt16(n1059WebServiceClientid));
         obj83.gxTpr_Webserviceclientsecret_N = (short)(Convert.ToInt16(n1060WebServiceClientSecret));
         obj83.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow83( SdtWebService obj83 )
      {
         obj83.gxTpr_Webserviceid = A656WebServiceId;
         return  ;
      }

      public void RowToVars83( SdtWebService obj83 ,
                               int forceLoad )
      {
         Gx_mode = obj83.gxTpr_Mode;
         A1068WebServiceClientSecretDecrypted = obj83.gxTpr_Webserviceclientsecretdecrypted;
         A1067WebServiceClientidDecrypted = obj83.gxTpr_Webserviceclientiddecrypted;
         A1066WebServiceCertificadoPassDecrypted = obj83.gxTpr_Webservicecertificadopassdecrypted;
         A1065WebServiceCertificadoBase64Decrypted = obj83.gxTpr_Webservicecertificadobase64decrypted;
         A1064WebServiceSenhaDecrypted = obj83.gxTpr_Webservicesenhadecrypted;
         A1063WebServiceUsuarioDecrypted = obj83.gxTpr_Webserviceusuariodecrypted;
         A1062WebServiceAuthTipoDecrypted = obj83.gxTpr_Webserviceauthtipodecrypted;
         A1061WebServiceEndPointDecrypted = obj83.gxTpr_Webserviceendpointdecrypted;
         A657WebServiceTipoDmWS = obj83.gxTpr_Webservicetipodmws;
         n657WebServiceTipoDmWS = false;
         A658WebServiceEndPoint = obj83.gxTpr_Webserviceendpoint;
         n658WebServiceEndPoint = false;
         A659WebServiceAuthTipo = obj83.gxTpr_Webserviceauthtipo;
         n659WebServiceAuthTipo = false;
         A660WebServiceUsuario = obj83.gxTpr_Webserviceusuario;
         n660WebServiceUsuario = false;
         A661WebServiceSenha = obj83.gxTpr_Webservicesenha;
         n661WebServiceSenha = false;
         A1054WebServiceSalt = obj83.gxTpr_Webservicesalt;
         n1054WebServiceSalt = false;
         A1055WebServiceCertificadoBase64 = obj83.gxTpr_Webservicecertificadobase64;
         n1055WebServiceCertificadoBase64 = false;
         A1056WebServiceCertificadoPass = obj83.gxTpr_Webservicecertificadopass;
         n1056WebServiceCertificadoPass = false;
         A1059WebServiceClientid = obj83.gxTpr_Webserviceclientid;
         n1059WebServiceClientid = false;
         A1060WebServiceClientSecret = obj83.gxTpr_Webserviceclientsecret;
         n1060WebServiceClientSecret = false;
         A656WebServiceId = obj83.gxTpr_Webserviceid;
         Z656WebServiceId = obj83.gxTpr_Webserviceid_Z;
         Z657WebServiceTipoDmWS = obj83.gxTpr_Webservicetipodmws_Z;
         n657WebServiceTipoDmWS = (bool)(Convert.ToBoolean(obj83.gxTpr_Webservicetipodmws_N));
         n658WebServiceEndPoint = (bool)(Convert.ToBoolean(obj83.gxTpr_Webserviceendpoint_N));
         n659WebServiceAuthTipo = (bool)(Convert.ToBoolean(obj83.gxTpr_Webserviceauthtipo_N));
         n660WebServiceUsuario = (bool)(Convert.ToBoolean(obj83.gxTpr_Webserviceusuario_N));
         n661WebServiceSenha = (bool)(Convert.ToBoolean(obj83.gxTpr_Webservicesenha_N));
         n1054WebServiceSalt = (bool)(Convert.ToBoolean(obj83.gxTpr_Webservicesalt_N));
         n1055WebServiceCertificadoBase64 = (bool)(Convert.ToBoolean(obj83.gxTpr_Webservicecertificadobase64_N));
         n1056WebServiceCertificadoPass = (bool)(Convert.ToBoolean(obj83.gxTpr_Webservicecertificadopass_N));
         n1059WebServiceClientid = (bool)(Convert.ToBoolean(obj83.gxTpr_Webserviceclientid_N));
         n1060WebServiceClientSecret = (bool)(Convert.ToBoolean(obj83.gxTpr_Webserviceclientsecret_N));
         Gx_mode = obj83.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A656WebServiceId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2D83( ) ;
         ScanKeyStart2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z656WebServiceId = A656WebServiceId;
         }
         ZM2D83( -10) ;
         OnLoadActions2D83( ) ;
         AddRow2D83( ) ;
         ScanKeyEnd2D83( ) ;
         if ( RcdFound83 == 0 )
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
         RowToVars83( bcWebService, 0) ;
         ScanKeyStart2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z656WebServiceId = A656WebServiceId;
         }
         ZM2D83( -10) ;
         OnLoadActions2D83( ) ;
         AddRow2D83( ) ;
         ScanKeyEnd2D83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2D83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2D83( ) ;
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( A656WebServiceId != Z656WebServiceId )
               {
                  A656WebServiceId = Z656WebServiceId;
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
                  Update2D83( ) ;
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
                  if ( A656WebServiceId != Z656WebServiceId )
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
                        Insert2D83( ) ;
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
                        Insert2D83( ) ;
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
         RowToVars83( bcWebService, 1) ;
         SaveImpl( ) ;
         VarsToRow83( bcWebService) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars83( bcWebService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2D83( ) ;
         AfterTrn( ) ;
         VarsToRow83( bcWebService) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow83( bcWebService) ;
         }
         else
         {
            SdtWebService auxBC = new SdtWebService(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A656WebServiceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcWebService);
               auxBC.Save();
               bcWebService.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars83( bcWebService, 1) ;
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
         RowToVars83( bcWebService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2D83( ) ;
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
               VarsToRow83( bcWebService) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow83( bcWebService) ;
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
         RowToVars83( bcWebService, 0) ;
         GetKey2D83( ) ;
         if ( RcdFound83 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A656WebServiceId != Z656WebServiceId )
            {
               A656WebServiceId = Z656WebServiceId;
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
            if ( A656WebServiceId != Z656WebServiceId )
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
         context.RollbackDataStores("webservice_bc",pr_default);
         VarsToRow83( bcWebService) ;
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
         Gx_mode = bcWebService.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcWebService.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcWebService )
         {
            bcWebService = (SdtWebService)(sdt);
            if ( StringUtil.StrCmp(bcWebService.gxTpr_Mode, "") == 0 )
            {
               bcWebService.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow83( bcWebService) ;
            }
            else
            {
               RowToVars83( bcWebService, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcWebService.gxTpr_Mode, "") == 0 )
            {
               bcWebService.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars83( bcWebService, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWebService WebService_BC
      {
         get {
            return bcWebService ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z657WebServiceTipoDmWS = "";
         A657WebServiceTipoDmWS = "";
         Z658WebServiceEndPoint = "";
         A658WebServiceEndPoint = "";
         Z659WebServiceAuthTipo = "";
         A659WebServiceAuthTipo = "";
         Z660WebServiceUsuario = "";
         A660WebServiceUsuario = "";
         Z661WebServiceSenha = "";
         A661WebServiceSenha = "";
         Z1054WebServiceSalt = "";
         A1054WebServiceSalt = "";
         Z1055WebServiceCertificadoBase64 = "";
         A1055WebServiceCertificadoBase64 = "";
         Z1056WebServiceCertificadoPass = "";
         A1056WebServiceCertificadoPass = "";
         Z1059WebServiceClientid = "";
         A1059WebServiceClientid = "";
         Z1060WebServiceClientSecret = "";
         A1060WebServiceClientSecret = "";
         BC002D4_A656WebServiceId = new int[1] ;
         BC002D4_A657WebServiceTipoDmWS = new string[] {""} ;
         BC002D4_n657WebServiceTipoDmWS = new bool[] {false} ;
         BC002D4_A658WebServiceEndPoint = new string[] {""} ;
         BC002D4_n658WebServiceEndPoint = new bool[] {false} ;
         BC002D4_A659WebServiceAuthTipo = new string[] {""} ;
         BC002D4_n659WebServiceAuthTipo = new bool[] {false} ;
         BC002D4_A660WebServiceUsuario = new string[] {""} ;
         BC002D4_n660WebServiceUsuario = new bool[] {false} ;
         BC002D4_A661WebServiceSenha = new string[] {""} ;
         BC002D4_n661WebServiceSenha = new bool[] {false} ;
         BC002D4_A1054WebServiceSalt = new string[] {""} ;
         BC002D4_n1054WebServiceSalt = new bool[] {false} ;
         BC002D4_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         BC002D4_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         BC002D4_A1056WebServiceCertificadoPass = new string[] {""} ;
         BC002D4_n1056WebServiceCertificadoPass = new bool[] {false} ;
         BC002D4_A1059WebServiceClientid = new string[] {""} ;
         BC002D4_n1059WebServiceClientid = new bool[] {false} ;
         BC002D4_A1060WebServiceClientSecret = new string[] {""} ;
         BC002D4_n1060WebServiceClientSecret = new bool[] {false} ;
         A1061WebServiceEndPointDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         A1063WebServiceUsuarioDecrypted = "";
         A1064WebServiceSenhaDecrypted = "";
         A1065WebServiceCertificadoBase64Decrypted = "";
         A1066WebServiceCertificadoPassDecrypted = "";
         A1067WebServiceClientidDecrypted = "";
         A1068WebServiceClientSecretDecrypted = "";
         BC002D5_A656WebServiceId = new int[1] ;
         BC002D3_A656WebServiceId = new int[1] ;
         BC002D3_A657WebServiceTipoDmWS = new string[] {""} ;
         BC002D3_n657WebServiceTipoDmWS = new bool[] {false} ;
         BC002D3_A658WebServiceEndPoint = new string[] {""} ;
         BC002D3_n658WebServiceEndPoint = new bool[] {false} ;
         BC002D3_A659WebServiceAuthTipo = new string[] {""} ;
         BC002D3_n659WebServiceAuthTipo = new bool[] {false} ;
         BC002D3_A660WebServiceUsuario = new string[] {""} ;
         BC002D3_n660WebServiceUsuario = new bool[] {false} ;
         BC002D3_A661WebServiceSenha = new string[] {""} ;
         BC002D3_n661WebServiceSenha = new bool[] {false} ;
         BC002D3_A1054WebServiceSalt = new string[] {""} ;
         BC002D3_n1054WebServiceSalt = new bool[] {false} ;
         BC002D3_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         BC002D3_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         BC002D3_A1056WebServiceCertificadoPass = new string[] {""} ;
         BC002D3_n1056WebServiceCertificadoPass = new bool[] {false} ;
         BC002D3_A1059WebServiceClientid = new string[] {""} ;
         BC002D3_n1059WebServiceClientid = new bool[] {false} ;
         BC002D3_A1060WebServiceClientSecret = new string[] {""} ;
         BC002D3_n1060WebServiceClientSecret = new bool[] {false} ;
         sMode83 = "";
         BC002D2_A656WebServiceId = new int[1] ;
         BC002D2_A657WebServiceTipoDmWS = new string[] {""} ;
         BC002D2_n657WebServiceTipoDmWS = new bool[] {false} ;
         BC002D2_A658WebServiceEndPoint = new string[] {""} ;
         BC002D2_n658WebServiceEndPoint = new bool[] {false} ;
         BC002D2_A659WebServiceAuthTipo = new string[] {""} ;
         BC002D2_n659WebServiceAuthTipo = new bool[] {false} ;
         BC002D2_A660WebServiceUsuario = new string[] {""} ;
         BC002D2_n660WebServiceUsuario = new bool[] {false} ;
         BC002D2_A661WebServiceSenha = new string[] {""} ;
         BC002D2_n661WebServiceSenha = new bool[] {false} ;
         BC002D2_A1054WebServiceSalt = new string[] {""} ;
         BC002D2_n1054WebServiceSalt = new bool[] {false} ;
         BC002D2_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         BC002D2_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         BC002D2_A1056WebServiceCertificadoPass = new string[] {""} ;
         BC002D2_n1056WebServiceCertificadoPass = new bool[] {false} ;
         BC002D2_A1059WebServiceClientid = new string[] {""} ;
         BC002D2_n1059WebServiceClientid = new bool[] {false} ;
         BC002D2_A1060WebServiceClientSecret = new string[] {""} ;
         BC002D2_n1060WebServiceClientSecret = new bool[] {false} ;
         BC002D7_A656WebServiceId = new int[1] ;
         GXt_char1 = "";
         BC002D10_A656WebServiceId = new int[1] ;
         BC002D10_A657WebServiceTipoDmWS = new string[] {""} ;
         BC002D10_n657WebServiceTipoDmWS = new bool[] {false} ;
         BC002D10_A658WebServiceEndPoint = new string[] {""} ;
         BC002D10_n658WebServiceEndPoint = new bool[] {false} ;
         BC002D10_A659WebServiceAuthTipo = new string[] {""} ;
         BC002D10_n659WebServiceAuthTipo = new bool[] {false} ;
         BC002D10_A660WebServiceUsuario = new string[] {""} ;
         BC002D10_n660WebServiceUsuario = new bool[] {false} ;
         BC002D10_A661WebServiceSenha = new string[] {""} ;
         BC002D10_n661WebServiceSenha = new bool[] {false} ;
         BC002D10_A1054WebServiceSalt = new string[] {""} ;
         BC002D10_n1054WebServiceSalt = new bool[] {false} ;
         BC002D10_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         BC002D10_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         BC002D10_A1056WebServiceCertificadoPass = new string[] {""} ;
         BC002D10_n1056WebServiceCertificadoPass = new bool[] {false} ;
         BC002D10_A1059WebServiceClientid = new string[] {""} ;
         BC002D10_n1059WebServiceClientid = new bool[] {false} ;
         BC002D10_A1060WebServiceClientSecret = new string[] {""} ;
         BC002D10_n1060WebServiceClientSecret = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webservice_bc__default(),
            new Object[][] {
                new Object[] {
               BC002D2_A656WebServiceId, BC002D2_A657WebServiceTipoDmWS, BC002D2_n657WebServiceTipoDmWS, BC002D2_A658WebServiceEndPoint, BC002D2_n658WebServiceEndPoint, BC002D2_A659WebServiceAuthTipo, BC002D2_n659WebServiceAuthTipo, BC002D2_A660WebServiceUsuario, BC002D2_n660WebServiceUsuario, BC002D2_A661WebServiceSenha,
               BC002D2_n661WebServiceSenha, BC002D2_A1054WebServiceSalt, BC002D2_n1054WebServiceSalt, BC002D2_A1055WebServiceCertificadoBase64, BC002D2_n1055WebServiceCertificadoBase64, BC002D2_A1056WebServiceCertificadoPass, BC002D2_n1056WebServiceCertificadoPass, BC002D2_A1059WebServiceClientid, BC002D2_n1059WebServiceClientid, BC002D2_A1060WebServiceClientSecret,
               BC002D2_n1060WebServiceClientSecret
               }
               , new Object[] {
               BC002D3_A656WebServiceId, BC002D3_A657WebServiceTipoDmWS, BC002D3_n657WebServiceTipoDmWS, BC002D3_A658WebServiceEndPoint, BC002D3_n658WebServiceEndPoint, BC002D3_A659WebServiceAuthTipo, BC002D3_n659WebServiceAuthTipo, BC002D3_A660WebServiceUsuario, BC002D3_n660WebServiceUsuario, BC002D3_A661WebServiceSenha,
               BC002D3_n661WebServiceSenha, BC002D3_A1054WebServiceSalt, BC002D3_n1054WebServiceSalt, BC002D3_A1055WebServiceCertificadoBase64, BC002D3_n1055WebServiceCertificadoBase64, BC002D3_A1056WebServiceCertificadoPass, BC002D3_n1056WebServiceCertificadoPass, BC002D3_A1059WebServiceClientid, BC002D3_n1059WebServiceClientid, BC002D3_A1060WebServiceClientSecret,
               BC002D3_n1060WebServiceClientSecret
               }
               , new Object[] {
               BC002D4_A656WebServiceId, BC002D4_A657WebServiceTipoDmWS, BC002D4_n657WebServiceTipoDmWS, BC002D4_A658WebServiceEndPoint, BC002D4_n658WebServiceEndPoint, BC002D4_A659WebServiceAuthTipo, BC002D4_n659WebServiceAuthTipo, BC002D4_A660WebServiceUsuario, BC002D4_n660WebServiceUsuario, BC002D4_A661WebServiceSenha,
               BC002D4_n661WebServiceSenha, BC002D4_A1054WebServiceSalt, BC002D4_n1054WebServiceSalt, BC002D4_A1055WebServiceCertificadoBase64, BC002D4_n1055WebServiceCertificadoBase64, BC002D4_A1056WebServiceCertificadoPass, BC002D4_n1056WebServiceCertificadoPass, BC002D4_A1059WebServiceClientid, BC002D4_n1059WebServiceClientid, BC002D4_A1060WebServiceClientSecret,
               BC002D4_n1060WebServiceClientSecret
               }
               , new Object[] {
               BC002D5_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002D7_A656WebServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002D10_A656WebServiceId, BC002D10_A657WebServiceTipoDmWS, BC002D10_n657WebServiceTipoDmWS, BC002D10_A658WebServiceEndPoint, BC002D10_n658WebServiceEndPoint, BC002D10_A659WebServiceAuthTipo, BC002D10_n659WebServiceAuthTipo, BC002D10_A660WebServiceUsuario, BC002D10_n660WebServiceUsuario, BC002D10_A661WebServiceSenha,
               BC002D10_n661WebServiceSenha, BC002D10_A1054WebServiceSalt, BC002D10_n1054WebServiceSalt, BC002D10_A1055WebServiceCertificadoBase64, BC002D10_n1055WebServiceCertificadoBase64, BC002D10_A1056WebServiceCertificadoPass, BC002D10_n1056WebServiceCertificadoPass, BC002D10_A1059WebServiceClientid, BC002D10_n1059WebServiceClientid, BC002D10_A1060WebServiceClientSecret,
               BC002D10_n1060WebServiceClientSecret
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122D2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound83 ;
      private int trnEnded ;
      private int Z656WebServiceId ;
      private int A656WebServiceId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode83 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool n657WebServiceTipoDmWS ;
      private bool n658WebServiceEndPoint ;
      private bool n659WebServiceAuthTipo ;
      private bool n660WebServiceUsuario ;
      private bool n661WebServiceSenha ;
      private bool n1054WebServiceSalt ;
      private bool n1055WebServiceCertificadoBase64 ;
      private bool n1056WebServiceCertificadoPass ;
      private bool n1059WebServiceClientid ;
      private bool n1060WebServiceClientSecret ;
      private string Z658WebServiceEndPoint ;
      private string A658WebServiceEndPoint ;
      private string Z659WebServiceAuthTipo ;
      private string A659WebServiceAuthTipo ;
      private string Z660WebServiceUsuario ;
      private string A660WebServiceUsuario ;
      private string Z661WebServiceSenha ;
      private string A661WebServiceSenha ;
      private string Z1054WebServiceSalt ;
      private string A1054WebServiceSalt ;
      private string Z1055WebServiceCertificadoBase64 ;
      private string A1055WebServiceCertificadoBase64 ;
      private string Z1056WebServiceCertificadoPass ;
      private string A1056WebServiceCertificadoPass ;
      private string Z1059WebServiceClientid ;
      private string A1059WebServiceClientid ;
      private string Z1060WebServiceClientSecret ;
      private string A1060WebServiceClientSecret ;
      private string A1061WebServiceEndPointDecrypted ;
      private string A1062WebServiceAuthTipoDecrypted ;
      private string A1063WebServiceUsuarioDecrypted ;
      private string A1064WebServiceSenhaDecrypted ;
      private string A1065WebServiceCertificadoBase64Decrypted ;
      private string A1066WebServiceCertificadoPassDecrypted ;
      private string A1067WebServiceClientidDecrypted ;
      private string A1068WebServiceClientSecretDecrypted ;
      private string Z657WebServiceTipoDmWS ;
      private string A657WebServiceTipoDmWS ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC002D4_A656WebServiceId ;
      private string[] BC002D4_A657WebServiceTipoDmWS ;
      private bool[] BC002D4_n657WebServiceTipoDmWS ;
      private string[] BC002D4_A658WebServiceEndPoint ;
      private bool[] BC002D4_n658WebServiceEndPoint ;
      private string[] BC002D4_A659WebServiceAuthTipo ;
      private bool[] BC002D4_n659WebServiceAuthTipo ;
      private string[] BC002D4_A660WebServiceUsuario ;
      private bool[] BC002D4_n660WebServiceUsuario ;
      private string[] BC002D4_A661WebServiceSenha ;
      private bool[] BC002D4_n661WebServiceSenha ;
      private string[] BC002D4_A1054WebServiceSalt ;
      private bool[] BC002D4_n1054WebServiceSalt ;
      private string[] BC002D4_A1055WebServiceCertificadoBase64 ;
      private bool[] BC002D4_n1055WebServiceCertificadoBase64 ;
      private string[] BC002D4_A1056WebServiceCertificadoPass ;
      private bool[] BC002D4_n1056WebServiceCertificadoPass ;
      private string[] BC002D4_A1059WebServiceClientid ;
      private bool[] BC002D4_n1059WebServiceClientid ;
      private string[] BC002D4_A1060WebServiceClientSecret ;
      private bool[] BC002D4_n1060WebServiceClientSecret ;
      private int[] BC002D5_A656WebServiceId ;
      private int[] BC002D3_A656WebServiceId ;
      private string[] BC002D3_A657WebServiceTipoDmWS ;
      private bool[] BC002D3_n657WebServiceTipoDmWS ;
      private string[] BC002D3_A658WebServiceEndPoint ;
      private bool[] BC002D3_n658WebServiceEndPoint ;
      private string[] BC002D3_A659WebServiceAuthTipo ;
      private bool[] BC002D3_n659WebServiceAuthTipo ;
      private string[] BC002D3_A660WebServiceUsuario ;
      private bool[] BC002D3_n660WebServiceUsuario ;
      private string[] BC002D3_A661WebServiceSenha ;
      private bool[] BC002D3_n661WebServiceSenha ;
      private string[] BC002D3_A1054WebServiceSalt ;
      private bool[] BC002D3_n1054WebServiceSalt ;
      private string[] BC002D3_A1055WebServiceCertificadoBase64 ;
      private bool[] BC002D3_n1055WebServiceCertificadoBase64 ;
      private string[] BC002D3_A1056WebServiceCertificadoPass ;
      private bool[] BC002D3_n1056WebServiceCertificadoPass ;
      private string[] BC002D3_A1059WebServiceClientid ;
      private bool[] BC002D3_n1059WebServiceClientid ;
      private string[] BC002D3_A1060WebServiceClientSecret ;
      private bool[] BC002D3_n1060WebServiceClientSecret ;
      private int[] BC002D2_A656WebServiceId ;
      private string[] BC002D2_A657WebServiceTipoDmWS ;
      private bool[] BC002D2_n657WebServiceTipoDmWS ;
      private string[] BC002D2_A658WebServiceEndPoint ;
      private bool[] BC002D2_n658WebServiceEndPoint ;
      private string[] BC002D2_A659WebServiceAuthTipo ;
      private bool[] BC002D2_n659WebServiceAuthTipo ;
      private string[] BC002D2_A660WebServiceUsuario ;
      private bool[] BC002D2_n660WebServiceUsuario ;
      private string[] BC002D2_A661WebServiceSenha ;
      private bool[] BC002D2_n661WebServiceSenha ;
      private string[] BC002D2_A1054WebServiceSalt ;
      private bool[] BC002D2_n1054WebServiceSalt ;
      private string[] BC002D2_A1055WebServiceCertificadoBase64 ;
      private bool[] BC002D2_n1055WebServiceCertificadoBase64 ;
      private string[] BC002D2_A1056WebServiceCertificadoPass ;
      private bool[] BC002D2_n1056WebServiceCertificadoPass ;
      private string[] BC002D2_A1059WebServiceClientid ;
      private bool[] BC002D2_n1059WebServiceClientid ;
      private string[] BC002D2_A1060WebServiceClientSecret ;
      private bool[] BC002D2_n1060WebServiceClientSecret ;
      private int[] BC002D7_A656WebServiceId ;
      private int[] BC002D10_A656WebServiceId ;
      private string[] BC002D10_A657WebServiceTipoDmWS ;
      private bool[] BC002D10_n657WebServiceTipoDmWS ;
      private string[] BC002D10_A658WebServiceEndPoint ;
      private bool[] BC002D10_n658WebServiceEndPoint ;
      private string[] BC002D10_A659WebServiceAuthTipo ;
      private bool[] BC002D10_n659WebServiceAuthTipo ;
      private string[] BC002D10_A660WebServiceUsuario ;
      private bool[] BC002D10_n660WebServiceUsuario ;
      private string[] BC002D10_A661WebServiceSenha ;
      private bool[] BC002D10_n661WebServiceSenha ;
      private string[] BC002D10_A1054WebServiceSalt ;
      private bool[] BC002D10_n1054WebServiceSalt ;
      private string[] BC002D10_A1055WebServiceCertificadoBase64 ;
      private bool[] BC002D10_n1055WebServiceCertificadoBase64 ;
      private string[] BC002D10_A1056WebServiceCertificadoPass ;
      private bool[] BC002D10_n1056WebServiceCertificadoPass ;
      private string[] BC002D10_A1059WebServiceClientid ;
      private bool[] BC002D10_n1059WebServiceClientid ;
      private string[] BC002D10_A1060WebServiceClientSecret ;
      private bool[] BC002D10_n1060WebServiceClientSecret ;
      private SdtWebService bcWebService ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class webservice_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002D2;
          prmBC002D2 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D3;
          prmBC002D3 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D4;
          prmBC002D4 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D5;
          prmBC002D5 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D6;
          prmBC002D6 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoBase64",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoPass",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientid",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientSecret",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmBC002D7;
          prmBC002D7 = new Object[] {
          };
          Object[] prmBC002D8;
          prmBC002D8 = new Object[] {
          new ParDef("WebServiceTipoDmWS",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("WebServiceEndPoint",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceAuthTipo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceUsuario",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSenha",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoBase64",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceCertificadoPass",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientid",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceClientSecret",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D9;
          prmBC002D9 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          Object[] prmBC002D10;
          prmBC002D10 = new Object[] {
          new ParDef("WebServiceId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002D2", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret FROM WebService WHERE WebServiceId = :WebServiceId  FOR UPDATE OF WebService",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002D3", "SELECT WebServiceId, WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002D4", "SELECT TM1.WebServiceId, TM1.WebServiceTipoDmWS, TM1.WebServiceEndPoint, TM1.WebServiceAuthTipo, TM1.WebServiceUsuario, TM1.WebServiceSenha, TM1.WebServiceSalt, TM1.WebServiceCertificadoBase64, TM1.WebServiceCertificadoPass, TM1.WebServiceClientid, TM1.WebServiceClientSecret FROM WebService TM1 WHERE TM1.WebServiceId = :WebServiceId ORDER BY TM1.WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002D5", "SELECT WebServiceId FROM WebService WHERE WebServiceId = :WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002D6", "SAVEPOINT gxupdate;INSERT INTO WebService(WebServiceTipoDmWS, WebServiceEndPoint, WebServiceAuthTipo, WebServiceUsuario, WebServiceSenha, WebServiceSalt, WebServiceCertificadoBase64, WebServiceCertificadoPass, WebServiceClientid, WebServiceClientSecret) VALUES(:WebServiceTipoDmWS, :WebServiceEndPoint, :WebServiceAuthTipo, :WebServiceUsuario, :WebServiceSenha, :WebServiceSalt, :WebServiceCertificadoBase64, :WebServiceCertificadoPass, :WebServiceClientid, :WebServiceClientSecret);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002D6)
             ,new CursorDef("BC002D7", "SELECT currval('WebServiceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002D8", "SAVEPOINT gxupdate;UPDATE WebService SET WebServiceTipoDmWS=:WebServiceTipoDmWS, WebServiceEndPoint=:WebServiceEndPoint, WebServiceAuthTipo=:WebServiceAuthTipo, WebServiceUsuario=:WebServiceUsuario, WebServiceSenha=:WebServiceSenha, WebServiceSalt=:WebServiceSalt, WebServiceCertificadoBase64=:WebServiceCertificadoBase64, WebServiceCertificadoPass=:WebServiceCertificadoPass, WebServiceClientid=:WebServiceClientid, WebServiceClientSecret=:WebServiceClientSecret  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002D8)
             ,new CursorDef("BC002D9", "SAVEPOINT gxupdate;DELETE FROM WebService  WHERE WebServiceId = :WebServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002D9)
             ,new CursorDef("BC002D10", "SELECT TM1.WebServiceId, TM1.WebServiceTipoDmWS, TM1.WebServiceEndPoint, TM1.WebServiceAuthTipo, TM1.WebServiceUsuario, TM1.WebServiceSenha, TM1.WebServiceSalt, TM1.WebServiceCertificadoBase64, TM1.WebServiceCertificadoPass, TM1.WebServiceClientid, TM1.WebServiceClientSecret FROM WebService TM1 WHERE TM1.WebServiceId = :WebServiceId ORDER BY TM1.WebServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002D10,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
