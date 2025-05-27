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
   public class municipio_bc : GxSilentTrn, IGxSilentTrn
   {
      public municipio_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipio_bc( IGxContext context )
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
         ReadRow0R31( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0R31( ) ;
         standaloneModal( ) ;
         AddRow0R31( ) ;
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
               Z186MunicipioCodigo = A186MunicipioCodigo;
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

      protected void CONFIRM_0R0( )
      {
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0R31( ) ;
            }
            else
            {
               CheckExtendedTable0R31( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0R31( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0R31( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z187MunicipioNome = A187MunicipioNome;
            Z188MunicipioDDD = A188MunicipioDDD;
            Z189MunicipioUF = A189MunicipioUF;
         }
         if ( GX_JID == -1 )
         {
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z187MunicipioNome = A187MunicipioNome;
            Z188MunicipioDDD = A188MunicipioDDD;
            Z189MunicipioUF = A189MunicipioUF;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0R31( )
      {
         /* Using cursor BC000R4 */
         pr_default.execute(2, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound31 = 1;
            A187MunicipioNome = BC000R4_A187MunicipioNome[0];
            n187MunicipioNome = BC000R4_n187MunicipioNome[0];
            A188MunicipioDDD = BC000R4_A188MunicipioDDD[0];
            n188MunicipioDDD = BC000R4_n188MunicipioDDD[0];
            A189MunicipioUF = BC000R4_A189MunicipioUF[0];
            n189MunicipioUF = BC000R4_n189MunicipioUF[0];
            ZM0R31( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0R31( ) ;
      }

      protected void OnLoadActions0R31( )
      {
      }

      protected void CheckExtendedTable0R31( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R31( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R31( )
      {
         /* Using cursor BC000R5 */
         pr_default.execute(3, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000R3 */
         pr_default.execute(1, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R31( 1) ;
            RcdFound31 = 1;
            A186MunicipioCodigo = BC000R3_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000R3_n186MunicipioCodigo[0];
            A187MunicipioNome = BC000R3_A187MunicipioNome[0];
            n187MunicipioNome = BC000R3_n187MunicipioNome[0];
            A188MunicipioDDD = BC000R3_A188MunicipioDDD[0];
            n188MunicipioDDD = BC000R3_n188MunicipioDDD[0];
            A189MunicipioUF = BC000R3_A189MunicipioUF[0];
            n189MunicipioUF = BC000R3_n189MunicipioUF[0];
            Z186MunicipioCodigo = A186MunicipioCodigo;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0R31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0R31( ) ;
            }
            Gx_mode = sMode31;
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0R31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode31;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R31( ) ;
         if ( RcdFound31 == 0 )
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
         CONFIRM_0R0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0R31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000R2 */
            pr_default.execute(0, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Municipio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z187MunicipioNome, BC000R2_A187MunicipioNome[0]) != 0 ) || ( StringUtil.StrCmp(Z188MunicipioDDD, BC000R2_A188MunicipioDDD[0]) != 0 ) || ( StringUtil.StrCmp(Z189MunicipioUF, BC000R2_A189MunicipioUF[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Municipio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R31( )
      {
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R31( 0) ;
            CheckOptimisticConcurrency0R31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R6 */
                     pr_default.execute(4, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo, n187MunicipioNome, A187MunicipioNome, n188MunicipioDDD, A188MunicipioDDD, n189MunicipioUF, A189MunicipioUF});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Municipio");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0R31( ) ;
            }
            EndLevel0R31( ) ;
         }
         CloseExtendedTableCursors0R31( ) ;
      }

      protected void Update0R31( )
      {
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R7 */
                     pr_default.execute(5, new Object[] {n187MunicipioNome, A187MunicipioNome, n188MunicipioDDD, A188MunicipioDDD, n189MunicipioUF, A189MunicipioUF, n186MunicipioCodigo, A186MunicipioCodigo});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Municipio");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Municipio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R31( ) ;
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
            EndLevel0R31( ) ;
         }
         CloseExtendedTableCursors0R31( ) ;
      }

      protected void DeferredUpdate0R31( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0R31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R31( ) ;
            AfterConfirm0R31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000R8 */
                  pr_default.execute(6, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Municipio");
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0R31( ) ;
         Gx_mode = sMode31;
      }

      protected void OnDeleteControls0R31( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000R9 */
            pr_default.execute(7, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
            /* Using cursor BC000R10 */
            pr_default.execute(8, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"+" ("+"Sb Empresa Representante Municipio"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000R11 */
            pr_default.execute(9, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000R12 */
            pr_default.execute(10, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Sd Reponsavel Municipio"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000R13 */
            pr_default.execute(11, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0R31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R31( ) ;
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

      public void ScanKeyStart0R31( )
      {
         /* Using cursor BC000R14 */
         pr_default.execute(12, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         RcdFound31 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A186MunicipioCodigo = BC000R14_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000R14_n186MunicipioCodigo[0];
            A187MunicipioNome = BC000R14_A187MunicipioNome[0];
            n187MunicipioNome = BC000R14_n187MunicipioNome[0];
            A188MunicipioDDD = BC000R14_A188MunicipioDDD[0];
            n188MunicipioDDD = BC000R14_n188MunicipioDDD[0];
            A189MunicipioUF = BC000R14_A189MunicipioUF[0];
            n189MunicipioUF = BC000R14_n189MunicipioUF[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0R31( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound31 = 0;
         ScanKeyLoad0R31( ) ;
      }

      protected void ScanKeyLoad0R31( )
      {
         sMode31 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A186MunicipioCodigo = BC000R14_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000R14_n186MunicipioCodigo[0];
            A187MunicipioNome = BC000R14_A187MunicipioNome[0];
            n187MunicipioNome = BC000R14_n187MunicipioNome[0];
            A188MunicipioDDD = BC000R14_A188MunicipioDDD[0];
            n188MunicipioDDD = BC000R14_n188MunicipioDDD[0];
            A189MunicipioUF = BC000R14_A189MunicipioUF[0];
            n189MunicipioUF = BC000R14_n189MunicipioUF[0];
         }
         Gx_mode = sMode31;
      }

      protected void ScanKeyEnd0R31( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0R31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0R31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R31( )
      {
      }

      protected void send_integrity_lvl_hashes0R31( )
      {
      }

      protected void AddRow0R31( )
      {
         VarsToRow31( bcMunicipio) ;
      }

      protected void ReadRow0R31( )
      {
         RowToVars31( bcMunicipio, 1) ;
      }

      protected void InitializeNonKey0R31( )
      {
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         A188MunicipioDDD = "";
         n188MunicipioDDD = false;
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         Z187MunicipioNome = "";
         Z188MunicipioDDD = "";
         Z189MunicipioUF = "";
      }

      protected void InitAll0R31( )
      {
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         InitializeNonKey0R31( ) ;
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

      public void VarsToRow31( SdtMunicipio obj31 )
      {
         obj31.gxTpr_Mode = Gx_mode;
         obj31.gxTpr_Municipionome = A187MunicipioNome;
         obj31.gxTpr_Municipioddd = A188MunicipioDDD;
         obj31.gxTpr_Municipiouf = A189MunicipioUF;
         obj31.gxTpr_Municipiocodigo = A186MunicipioCodigo;
         obj31.gxTpr_Municipiocodigo_Z = Z186MunicipioCodigo;
         obj31.gxTpr_Municipionome_Z = Z187MunicipioNome;
         obj31.gxTpr_Municipioddd_Z = Z188MunicipioDDD;
         obj31.gxTpr_Municipiouf_Z = Z189MunicipioUF;
         obj31.gxTpr_Municipiocodigo_N = (short)(Convert.ToInt16(n186MunicipioCodigo));
         obj31.gxTpr_Municipionome_N = (short)(Convert.ToInt16(n187MunicipioNome));
         obj31.gxTpr_Municipioddd_N = (short)(Convert.ToInt16(n188MunicipioDDD));
         obj31.gxTpr_Municipiouf_N = (short)(Convert.ToInt16(n189MunicipioUF));
         obj31.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow31( SdtMunicipio obj31 )
      {
         obj31.gxTpr_Municipiocodigo = A186MunicipioCodigo;
         return  ;
      }

      public void RowToVars31( SdtMunicipio obj31 ,
                               int forceLoad )
      {
         Gx_mode = obj31.gxTpr_Mode;
         A187MunicipioNome = obj31.gxTpr_Municipionome;
         n187MunicipioNome = false;
         A188MunicipioDDD = obj31.gxTpr_Municipioddd;
         n188MunicipioDDD = false;
         A189MunicipioUF = obj31.gxTpr_Municipiouf;
         n189MunicipioUF = false;
         A186MunicipioCodigo = obj31.gxTpr_Municipiocodigo;
         n186MunicipioCodigo = false;
         Z186MunicipioCodigo = obj31.gxTpr_Municipiocodigo_Z;
         Z187MunicipioNome = obj31.gxTpr_Municipionome_Z;
         Z188MunicipioDDD = obj31.gxTpr_Municipioddd_Z;
         Z189MunicipioUF = obj31.gxTpr_Municipiouf_Z;
         n186MunicipioCodigo = (bool)(Convert.ToBoolean(obj31.gxTpr_Municipiocodigo_N));
         n187MunicipioNome = (bool)(Convert.ToBoolean(obj31.gxTpr_Municipionome_N));
         n188MunicipioDDD = (bool)(Convert.ToBoolean(obj31.gxTpr_Municipioddd_N));
         n189MunicipioUF = (bool)(Convert.ToBoolean(obj31.gxTpr_Municipiouf_N));
         Gx_mode = obj31.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A186MunicipioCodigo = (string)getParm(obj,0);
         n186MunicipioCodigo = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0R31( ) ;
         ScanKeyStart0R31( ) ;
         if ( RcdFound31 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z186MunicipioCodigo = A186MunicipioCodigo;
         }
         ZM0R31( -1) ;
         OnLoadActions0R31( ) ;
         AddRow0R31( ) ;
         ScanKeyEnd0R31( ) ;
         if ( RcdFound31 == 0 )
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
         RowToVars31( bcMunicipio, 0) ;
         ScanKeyStart0R31( ) ;
         if ( RcdFound31 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z186MunicipioCodigo = A186MunicipioCodigo;
         }
         ZM0R31( -1) ;
         OnLoadActions0R31( ) ;
         AddRow0R31( ) ;
         ScanKeyEnd0R31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0R31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0R31( ) ;
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
               {
                  A186MunicipioCodigo = Z186MunicipioCodigo;
                  n186MunicipioCodigo = false;
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
                  Update0R31( ) ;
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
                  if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
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
                        Insert0R31( ) ;
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
                        Insert0R31( ) ;
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
         RowToVars31( bcMunicipio, 1) ;
         SaveImpl( ) ;
         VarsToRow31( bcMunicipio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars31( bcMunicipio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R31( ) ;
         AfterTrn( ) ;
         VarsToRow31( bcMunicipio) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow31( bcMunicipio) ;
         }
         else
         {
            SdtMunicipio auxBC = new SdtMunicipio(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A186MunicipioCodigo);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMunicipio);
               auxBC.Save();
               bcMunicipio.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars31( bcMunicipio, 1) ;
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
         RowToVars31( bcMunicipio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R31( ) ;
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
               VarsToRow31( bcMunicipio) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow31( bcMunicipio) ;
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
         RowToVars31( bcMunicipio, 0) ;
         GetKey0R31( ) ;
         if ( RcdFound31 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
            {
               A186MunicipioCodigo = Z186MunicipioCodigo;
               n186MunicipioCodigo = false;
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
            if ( StringUtil.StrCmp(A186MunicipioCodigo, Z186MunicipioCodigo) != 0 )
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
         context.RollbackDataStores("municipio_bc",pr_default);
         VarsToRow31( bcMunicipio) ;
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
         Gx_mode = bcMunicipio.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMunicipio.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMunicipio )
         {
            bcMunicipio = (SdtMunicipio)(sdt);
            if ( StringUtil.StrCmp(bcMunicipio.gxTpr_Mode, "") == 0 )
            {
               bcMunicipio.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow31( bcMunicipio) ;
            }
            else
            {
               RowToVars31( bcMunicipio, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMunicipio.gxTpr_Mode, "") == 0 )
            {
               bcMunicipio.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars31( bcMunicipio, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtMunicipio Municipio_BC
      {
         get {
            return bcMunicipio ;
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
         Z186MunicipioCodigo = "";
         A186MunicipioCodigo = "";
         Z187MunicipioNome = "";
         A187MunicipioNome = "";
         Z188MunicipioDDD = "";
         A188MunicipioDDD = "";
         Z189MunicipioUF = "";
         A189MunicipioUF = "";
         BC000R4_A186MunicipioCodigo = new string[] {""} ;
         BC000R4_n186MunicipioCodigo = new bool[] {false} ;
         BC000R4_A187MunicipioNome = new string[] {""} ;
         BC000R4_n187MunicipioNome = new bool[] {false} ;
         BC000R4_A188MunicipioDDD = new string[] {""} ;
         BC000R4_n188MunicipioDDD = new bool[] {false} ;
         BC000R4_A189MunicipioUF = new string[] {""} ;
         BC000R4_n189MunicipioUF = new bool[] {false} ;
         BC000R5_A186MunicipioCodigo = new string[] {""} ;
         BC000R5_n186MunicipioCodigo = new bool[] {false} ;
         BC000R3_A186MunicipioCodigo = new string[] {""} ;
         BC000R3_n186MunicipioCodigo = new bool[] {false} ;
         BC000R3_A187MunicipioNome = new string[] {""} ;
         BC000R3_n187MunicipioNome = new bool[] {false} ;
         BC000R3_A188MunicipioDDD = new string[] {""} ;
         BC000R3_n188MunicipioDDD = new bool[] {false} ;
         BC000R3_A189MunicipioUF = new string[] {""} ;
         BC000R3_n189MunicipioUF = new bool[] {false} ;
         sMode31 = "";
         BC000R2_A186MunicipioCodigo = new string[] {""} ;
         BC000R2_n186MunicipioCodigo = new bool[] {false} ;
         BC000R2_A187MunicipioNome = new string[] {""} ;
         BC000R2_n187MunicipioNome = new bool[] {false} ;
         BC000R2_A188MunicipioDDD = new string[] {""} ;
         BC000R2_n188MunicipioDDD = new bool[] {false} ;
         BC000R2_A189MunicipioUF = new string[] {""} ;
         BC000R2_n189MunicipioUF = new bool[] {false} ;
         BC000R9_A978RepresentanteId = new int[1] ;
         BC000R10_A249EmpresaId = new int[1] ;
         BC000R11_A249EmpresaId = new int[1] ;
         BC000R12_A168ClienteId = new int[1] ;
         BC000R13_A168ClienteId = new int[1] ;
         BC000R14_A186MunicipioCodigo = new string[] {""} ;
         BC000R14_n186MunicipioCodigo = new bool[] {false} ;
         BC000R14_A187MunicipioNome = new string[] {""} ;
         BC000R14_n187MunicipioNome = new bool[] {false} ;
         BC000R14_A188MunicipioDDD = new string[] {""} ;
         BC000R14_n188MunicipioDDD = new bool[] {false} ;
         BC000R14_A189MunicipioUF = new string[] {""} ;
         BC000R14_n189MunicipioUF = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.municipio_bc__default(),
            new Object[][] {
                new Object[] {
               BC000R2_A186MunicipioCodigo, BC000R2_A187MunicipioNome, BC000R2_n187MunicipioNome, BC000R2_A188MunicipioDDD, BC000R2_n188MunicipioDDD, BC000R2_A189MunicipioUF, BC000R2_n189MunicipioUF
               }
               , new Object[] {
               BC000R3_A186MunicipioCodigo, BC000R3_A187MunicipioNome, BC000R3_n187MunicipioNome, BC000R3_A188MunicipioDDD, BC000R3_n188MunicipioDDD, BC000R3_A189MunicipioUF, BC000R3_n189MunicipioUF
               }
               , new Object[] {
               BC000R4_A186MunicipioCodigo, BC000R4_A187MunicipioNome, BC000R4_n187MunicipioNome, BC000R4_A188MunicipioDDD, BC000R4_n188MunicipioDDD, BC000R4_A189MunicipioUF, BC000R4_n189MunicipioUF
               }
               , new Object[] {
               BC000R5_A186MunicipioCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000R9_A978RepresentanteId
               }
               , new Object[] {
               BC000R10_A249EmpresaId
               }
               , new Object[] {
               BC000R11_A249EmpresaId
               }
               , new Object[] {
               BC000R12_A168ClienteId
               }
               , new Object[] {
               BC000R13_A168ClienteId
               }
               , new Object[] {
               BC000R14_A186MunicipioCodigo, BC000R14_A187MunicipioNome, BC000R14_n187MunicipioNome, BC000R14_A188MunicipioDDD, BC000R14_n188MunicipioDDD, BC000R14_A189MunicipioUF, BC000R14_n189MunicipioUF
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound31 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode31 ;
      private bool n186MunicipioCodigo ;
      private bool n187MunicipioNome ;
      private bool n188MunicipioDDD ;
      private bool n189MunicipioUF ;
      private string Z186MunicipioCodigo ;
      private string A186MunicipioCodigo ;
      private string Z187MunicipioNome ;
      private string A187MunicipioNome ;
      private string Z188MunicipioDDD ;
      private string A188MunicipioDDD ;
      private string Z189MunicipioUF ;
      private string A189MunicipioUF ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000R4_A186MunicipioCodigo ;
      private bool[] BC000R4_n186MunicipioCodigo ;
      private string[] BC000R4_A187MunicipioNome ;
      private bool[] BC000R4_n187MunicipioNome ;
      private string[] BC000R4_A188MunicipioDDD ;
      private bool[] BC000R4_n188MunicipioDDD ;
      private string[] BC000R4_A189MunicipioUF ;
      private bool[] BC000R4_n189MunicipioUF ;
      private string[] BC000R5_A186MunicipioCodigo ;
      private bool[] BC000R5_n186MunicipioCodigo ;
      private string[] BC000R3_A186MunicipioCodigo ;
      private bool[] BC000R3_n186MunicipioCodigo ;
      private string[] BC000R3_A187MunicipioNome ;
      private bool[] BC000R3_n187MunicipioNome ;
      private string[] BC000R3_A188MunicipioDDD ;
      private bool[] BC000R3_n188MunicipioDDD ;
      private string[] BC000R3_A189MunicipioUF ;
      private bool[] BC000R3_n189MunicipioUF ;
      private string[] BC000R2_A186MunicipioCodigo ;
      private bool[] BC000R2_n186MunicipioCodigo ;
      private string[] BC000R2_A187MunicipioNome ;
      private bool[] BC000R2_n187MunicipioNome ;
      private string[] BC000R2_A188MunicipioDDD ;
      private bool[] BC000R2_n188MunicipioDDD ;
      private string[] BC000R2_A189MunicipioUF ;
      private bool[] BC000R2_n189MunicipioUF ;
      private int[] BC000R9_A978RepresentanteId ;
      private int[] BC000R10_A249EmpresaId ;
      private int[] BC000R11_A249EmpresaId ;
      private int[] BC000R12_A168ClienteId ;
      private int[] BC000R13_A168ClienteId ;
      private string[] BC000R14_A186MunicipioCodigo ;
      private bool[] BC000R14_n186MunicipioCodigo ;
      private string[] BC000R14_A187MunicipioNome ;
      private bool[] BC000R14_n187MunicipioNome ;
      private string[] BC000R14_A188MunicipioDDD ;
      private bool[] BC000R14_n188MunicipioDDD ;
      private string[] BC000R14_A189MunicipioUF ;
      private bool[] BC000R14_n189MunicipioUF ;
      private SdtMunicipio bcMunicipio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class municipio_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000R2;
          prmBC000R2 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R3;
          prmBC000R3 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R4;
          prmBC000R4 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R5;
          prmBC000R5 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R6;
          prmBC000R6 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("MunicipioNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("MunicipioDDD",GXType.VarChar,3,0){Nullable=true} ,
          new ParDef("MunicipioUF",GXType.VarChar,10,0){Nullable=true}
          };
          Object[] prmBC000R7;
          prmBC000R7 = new Object[] {
          new ParDef("MunicipioNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("MunicipioDDD",GXType.VarChar,3,0){Nullable=true} ,
          new ParDef("MunicipioUF",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R8;
          prmBC000R8 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R9;
          prmBC000R9 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R10;
          prmBC000R10 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R11;
          prmBC000R11 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R12;
          prmBC000R12 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R13;
          prmBC000R13 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000R14;
          prmBC000R14 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000R2", "SELECT MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo  FOR UPDATE OF Municipio",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000R3", "SELECT MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000R4", "SELECT TM1.MunicipioCodigo, TM1.MunicipioNome, TM1.MunicipioDDD, TM1.MunicipioUF FROM Municipio TM1 WHERE TM1.MunicipioCodigo = ( :MunicipioCodigo) ORDER BY TM1.MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000R5", "SELECT MunicipioCodigo FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000R6", "SAVEPOINT gxupdate;INSERT INTO Municipio(MunicipioCodigo, MunicipioNome, MunicipioDDD, MunicipioUF) VALUES(:MunicipioCodigo, :MunicipioNome, :MunicipioDDD, :MunicipioUF);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000R6)
             ,new CursorDef("BC000R7", "SAVEPOINT gxupdate;UPDATE Municipio SET MunicipioNome=:MunicipioNome, MunicipioDDD=:MunicipioDDD, MunicipioUF=:MunicipioUF  WHERE MunicipioCodigo = :MunicipioCodigo;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R7)
             ,new CursorDef("BC000R8", "SAVEPOINT gxupdate;DELETE FROM Municipio  WHERE MunicipioCodigo = :MunicipioCodigo;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R8)
             ,new CursorDef("BC000R9", "SELECT RepresentanteId FROM Representante WHERE RepresentanteMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000R10", "SELECT EmpresaId FROM Empresa WHERE EmpresaRepresentanteMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000R11", "SELECT EmpresaId FROM Empresa WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000R12", "SELECT ClienteId FROM Cliente WHERE ResponsavelMunicipio = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000R13", "SELECT ClienteId FROM Cliente WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000R14", "SELECT TM1.MunicipioCodigo, TM1.MunicipioNome, TM1.MunicipioDDD, TM1.MunicipioUF FROM Municipio TM1 WHERE TM1.MunicipioCodigo = ( :MunicipioCodigo) ORDER BY TM1.MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
