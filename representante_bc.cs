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
   public class representante_bc : GxSilentTrn, IGxSilentTrn
   {
      public representante_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representante_bc( IGxContext context )
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
         ReadRow30104( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey30104( ) ;
         standaloneModal( ) ;
         AddRow30104( ) ;
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
            E11302 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z978RepresentanteId = A978RepresentanteId;
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

      protected void CONFIRM_300( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls30104( ) ;
            }
            else
            {
               CheckExtendedTable30104( ) ;
               if ( AnyError == 0 )
               {
                  ZM30104( 7) ;
                  ZM30104( 8) ;
                  ZM30104( 9) ;
               }
               CloseExtendedTableCursors30104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12302( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            while ( AV28GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RepresentanteProfissao") == 0 )
               {
                  AV11Insert_RepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RepresentanteMunicipio") == 0 )
               {
                  AV12Insert_RepresentanteMunicipio = AV14TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV13Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
         }
      }

      protected void E11302( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM30104( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z979RepresentanteNome = A979RepresentanteNome;
            Z980RepresentanteRG = A980RepresentanteRG;
            Z981RepresentanteOrgaoExpedidor = A981RepresentanteOrgaoExpedidor;
            Z982RepresentanteRGUF = A982RepresentanteRGUF;
            Z983RepresentanteCPF = A983RepresentanteCPF;
            Z984RepresentanteEstadoCivil = A984RepresentanteEstadoCivil;
            Z985RepresentanteNacionalidade = A985RepresentanteNacionalidade;
            Z986RepresentanteEmail = A986RepresentanteEmail;
            Z987RepresentanteCEP = A987RepresentanteCEP;
            Z988RepresentanteLogradouro = A988RepresentanteLogradouro;
            Z989RepresentanteBairro = A989RepresentanteBairro;
            Z990RepresentanteCidade = A990RepresentanteCidade;
            Z992RepresentanteLogradouroNumero = A992RepresentanteLogradouroNumero;
            Z993RepresentanteComplemento = A993RepresentanteComplemento;
            Z994RepresentanteDDD = A994RepresentanteDDD;
            Z995RepresentanteNumero = A995RepresentanteNumero;
            Z998RepresentanteTipo = A998RepresentanteTipo;
            Z168ClienteId = A168ClienteId;
            Z977RepresentanteProfissao = A977RepresentanteProfissao;
            Z991RepresentanteMunicipio = A991RepresentanteMunicipio;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z999RepresentanteProfissaoDescricao = A999RepresentanteProfissaoDescricao;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z996RepresentanteMunicipioUF = A996RepresentanteMunicipioUF;
            Z997RepresentanteMunicipioNome = A997RepresentanteMunicipioNome;
         }
         if ( GX_JID == -6 )
         {
            Z978RepresentanteId = A978RepresentanteId;
            Z979RepresentanteNome = A979RepresentanteNome;
            Z980RepresentanteRG = A980RepresentanteRG;
            Z981RepresentanteOrgaoExpedidor = A981RepresentanteOrgaoExpedidor;
            Z982RepresentanteRGUF = A982RepresentanteRGUF;
            Z983RepresentanteCPF = A983RepresentanteCPF;
            Z984RepresentanteEstadoCivil = A984RepresentanteEstadoCivil;
            Z985RepresentanteNacionalidade = A985RepresentanteNacionalidade;
            Z986RepresentanteEmail = A986RepresentanteEmail;
            Z987RepresentanteCEP = A987RepresentanteCEP;
            Z988RepresentanteLogradouro = A988RepresentanteLogradouro;
            Z989RepresentanteBairro = A989RepresentanteBairro;
            Z990RepresentanteCidade = A990RepresentanteCidade;
            Z992RepresentanteLogradouroNumero = A992RepresentanteLogradouroNumero;
            Z993RepresentanteComplemento = A993RepresentanteComplemento;
            Z994RepresentanteDDD = A994RepresentanteDDD;
            Z995RepresentanteNumero = A995RepresentanteNumero;
            Z998RepresentanteTipo = A998RepresentanteTipo;
            Z168ClienteId = A168ClienteId;
            Z977RepresentanteProfissao = A977RepresentanteProfissao;
            Z991RepresentanteMunicipio = A991RepresentanteMunicipio;
            Z999RepresentanteProfissaoDescricao = A999RepresentanteProfissaoDescricao;
            Z996RepresentanteMunicipioUF = A996RepresentanteMunicipioUF;
            Z997RepresentanteMunicipioNome = A997RepresentanteMunicipioNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV27Pgmname = "Representante_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load30104( )
      {
         /* Using cursor BC00307 */
         pr_default.execute(5, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound104 = 1;
            A979RepresentanteNome = BC00307_A979RepresentanteNome[0];
            n979RepresentanteNome = BC00307_n979RepresentanteNome[0];
            A980RepresentanteRG = BC00307_A980RepresentanteRG[0];
            n980RepresentanteRG = BC00307_n980RepresentanteRG[0];
            A981RepresentanteOrgaoExpedidor = BC00307_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = BC00307_n981RepresentanteOrgaoExpedidor[0];
            A982RepresentanteRGUF = BC00307_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = BC00307_n982RepresentanteRGUF[0];
            A983RepresentanteCPF = BC00307_A983RepresentanteCPF[0];
            n983RepresentanteCPF = BC00307_n983RepresentanteCPF[0];
            A984RepresentanteEstadoCivil = BC00307_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = BC00307_n984RepresentanteEstadoCivil[0];
            A985RepresentanteNacionalidade = BC00307_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = BC00307_n985RepresentanteNacionalidade[0];
            A999RepresentanteProfissaoDescricao = BC00307_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = BC00307_n999RepresentanteProfissaoDescricao[0];
            A986RepresentanteEmail = BC00307_A986RepresentanteEmail[0];
            n986RepresentanteEmail = BC00307_n986RepresentanteEmail[0];
            A987RepresentanteCEP = BC00307_A987RepresentanteCEP[0];
            n987RepresentanteCEP = BC00307_n987RepresentanteCEP[0];
            A988RepresentanteLogradouro = BC00307_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = BC00307_n988RepresentanteLogradouro[0];
            A989RepresentanteBairro = BC00307_A989RepresentanteBairro[0];
            n989RepresentanteBairro = BC00307_n989RepresentanteBairro[0];
            A990RepresentanteCidade = BC00307_A990RepresentanteCidade[0];
            n990RepresentanteCidade = BC00307_n990RepresentanteCidade[0];
            A992RepresentanteLogradouroNumero = BC00307_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = BC00307_n992RepresentanteLogradouroNumero[0];
            A993RepresentanteComplemento = BC00307_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = BC00307_n993RepresentanteComplemento[0];
            A994RepresentanteDDD = BC00307_A994RepresentanteDDD[0];
            n994RepresentanteDDD = BC00307_n994RepresentanteDDD[0];
            A995RepresentanteNumero = BC00307_A995RepresentanteNumero[0];
            n995RepresentanteNumero = BC00307_n995RepresentanteNumero[0];
            A996RepresentanteMunicipioUF = BC00307_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = BC00307_n996RepresentanteMunicipioUF[0];
            A997RepresentanteMunicipioNome = BC00307_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = BC00307_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = BC00307_A998RepresentanteTipo[0];
            n998RepresentanteTipo = BC00307_n998RepresentanteTipo[0];
            A168ClienteId = BC00307_A168ClienteId[0];
            n168ClienteId = BC00307_n168ClienteId[0];
            A977RepresentanteProfissao = BC00307_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = BC00307_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = BC00307_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = BC00307_n991RepresentanteMunicipio[0];
            ZM30104( -6) ;
         }
         pr_default.close(5);
         OnLoadActions30104( ) ;
      }

      protected void OnLoadActions30104( )
      {
      }

      protected void CheckExtendedTable30104( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "SOLTEIRO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "CASADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "DIVORCIADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "VIUVO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "SEPARADO") == 0 ) || ( StringUtil.StrCmp(A984RepresentanteEstadoCivil, "UNIAO_ESTAVEL") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A984RepresentanteEstadoCivil)) ) )
         {
            GX_msglist.addItem("Campo Representante Estado Civil fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00305 */
         pr_default.execute(3, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A977RepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representante Profissao'.", "ForeignKeyNotFound", 1, "REPRESENTANTEPROFISSAO");
               AnyError = 1;
            }
         }
         A999RepresentanteProfissaoDescricao = BC00305_A999RepresentanteProfissaoDescricao[0];
         n999RepresentanteProfissaoDescricao = BC00305_n999RepresentanteProfissaoDescricao[0];
         pr_default.close(3);
         if ( ! ( GxRegex.IsMatch(A986RepresentanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Representante Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00306 */
         pr_default.execute(4, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A991RepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Representantel Municipio'.", "ForeignKeyNotFound", 1, "REPRESENTANTEMUNICIPIO");
               AnyError = 1;
            }
         }
         A996RepresentanteMunicipioUF = BC00306_A996RepresentanteMunicipioUF[0];
         n996RepresentanteMunicipioUF = BC00306_n996RepresentanteMunicipioUF[0];
         A997RepresentanteMunicipioNome = BC00306_A997RepresentanteMunicipioNome[0];
         n997RepresentanteMunicipioNome = BC00306_n997RepresentanteMunicipioNome[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A998RepresentanteTipo, "Representante") == 0 ) || ( StringUtil.StrCmp(A998RepresentanteTipo, "Responsavel_solidario") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A998RepresentanteTipo)) ) )
         {
            GX_msglist.addItem("Campo Representante Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00304 */
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
      }

      protected void CloseExtendedTableCursors30104( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey30104( )
      {
         /* Using cursor BC00308 */
         pr_default.execute(6, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00303 */
         pr_default.execute(1, new Object[] {A978RepresentanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM30104( 6) ;
            RcdFound104 = 1;
            A978RepresentanteId = BC00303_A978RepresentanteId[0];
            A979RepresentanteNome = BC00303_A979RepresentanteNome[0];
            n979RepresentanteNome = BC00303_n979RepresentanteNome[0];
            A980RepresentanteRG = BC00303_A980RepresentanteRG[0];
            n980RepresentanteRG = BC00303_n980RepresentanteRG[0];
            A981RepresentanteOrgaoExpedidor = BC00303_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = BC00303_n981RepresentanteOrgaoExpedidor[0];
            A982RepresentanteRGUF = BC00303_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = BC00303_n982RepresentanteRGUF[0];
            A983RepresentanteCPF = BC00303_A983RepresentanteCPF[0];
            n983RepresentanteCPF = BC00303_n983RepresentanteCPF[0];
            A984RepresentanteEstadoCivil = BC00303_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = BC00303_n984RepresentanteEstadoCivil[0];
            A985RepresentanteNacionalidade = BC00303_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = BC00303_n985RepresentanteNacionalidade[0];
            A986RepresentanteEmail = BC00303_A986RepresentanteEmail[0];
            n986RepresentanteEmail = BC00303_n986RepresentanteEmail[0];
            A987RepresentanteCEP = BC00303_A987RepresentanteCEP[0];
            n987RepresentanteCEP = BC00303_n987RepresentanteCEP[0];
            A988RepresentanteLogradouro = BC00303_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = BC00303_n988RepresentanteLogradouro[0];
            A989RepresentanteBairro = BC00303_A989RepresentanteBairro[0];
            n989RepresentanteBairro = BC00303_n989RepresentanteBairro[0];
            A990RepresentanteCidade = BC00303_A990RepresentanteCidade[0];
            n990RepresentanteCidade = BC00303_n990RepresentanteCidade[0];
            A992RepresentanteLogradouroNumero = BC00303_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = BC00303_n992RepresentanteLogradouroNumero[0];
            A993RepresentanteComplemento = BC00303_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = BC00303_n993RepresentanteComplemento[0];
            A994RepresentanteDDD = BC00303_A994RepresentanteDDD[0];
            n994RepresentanteDDD = BC00303_n994RepresentanteDDD[0];
            A995RepresentanteNumero = BC00303_A995RepresentanteNumero[0];
            n995RepresentanteNumero = BC00303_n995RepresentanteNumero[0];
            A998RepresentanteTipo = BC00303_A998RepresentanteTipo[0];
            n998RepresentanteTipo = BC00303_n998RepresentanteTipo[0];
            A168ClienteId = BC00303_A168ClienteId[0];
            n168ClienteId = BC00303_n168ClienteId[0];
            A977RepresentanteProfissao = BC00303_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = BC00303_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = BC00303_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = BC00303_n991RepresentanteMunicipio[0];
            Z978RepresentanteId = A978RepresentanteId;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load30104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey30104( ) ;
            }
            Gx_mode = sMode104;
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey30104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode104;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey30104( ) ;
         if ( RcdFound104 == 0 )
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
         CONFIRM_300( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency30104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00302 */
            pr_default.execute(0, new Object[] {A978RepresentanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Representante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z979RepresentanteNome, BC00302_A979RepresentanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z980RepresentanteRG, BC00302_A980RepresentanteRG[0]) != 0 ) || ( StringUtil.StrCmp(Z981RepresentanteOrgaoExpedidor, BC00302_A981RepresentanteOrgaoExpedidor[0]) != 0 ) || ( StringUtil.StrCmp(Z982RepresentanteRGUF, BC00302_A982RepresentanteRGUF[0]) != 0 ) || ( StringUtil.StrCmp(Z983RepresentanteCPF, BC00302_A983RepresentanteCPF[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z984RepresentanteEstadoCivil, BC00302_A984RepresentanteEstadoCivil[0]) != 0 ) || ( StringUtil.StrCmp(Z985RepresentanteNacionalidade, BC00302_A985RepresentanteNacionalidade[0]) != 0 ) || ( StringUtil.StrCmp(Z986RepresentanteEmail, BC00302_A986RepresentanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z987RepresentanteCEP, BC00302_A987RepresentanteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z988RepresentanteLogradouro, BC00302_A988RepresentanteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z989RepresentanteBairro, BC00302_A989RepresentanteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z990RepresentanteCidade, BC00302_A990RepresentanteCidade[0]) != 0 ) || ( Z992RepresentanteLogradouroNumero != BC00302_A992RepresentanteLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z993RepresentanteComplemento, BC00302_A993RepresentanteComplemento[0]) != 0 ) || ( Z994RepresentanteDDD != BC00302_A994RepresentanteDDD[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z995RepresentanteNumero != BC00302_A995RepresentanteNumero[0] ) || ( StringUtil.StrCmp(Z998RepresentanteTipo, BC00302_A998RepresentanteTipo[0]) != 0 ) || ( Z168ClienteId != BC00302_A168ClienteId[0] ) || ( Z977RepresentanteProfissao != BC00302_A977RepresentanteProfissao[0] ) || ( StringUtil.StrCmp(Z991RepresentanteMunicipio, BC00302_A991RepresentanteMunicipio[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Representante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert30104( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM30104( 0) ;
            CheckOptimisticConcurrency30104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert30104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00309 */
                     pr_default.execute(7, new Object[] {n979RepresentanteNome, A979RepresentanteNome, n980RepresentanteRG, A980RepresentanteRG, n981RepresentanteOrgaoExpedidor, A981RepresentanteOrgaoExpedidor, n982RepresentanteRGUF, A982RepresentanteRGUF, n983RepresentanteCPF, A983RepresentanteCPF, n984RepresentanteEstadoCivil, A984RepresentanteEstadoCivil, n985RepresentanteNacionalidade, A985RepresentanteNacionalidade, n986RepresentanteEmail, A986RepresentanteEmail, n987RepresentanteCEP, A987RepresentanteCEP, n988RepresentanteLogradouro, A988RepresentanteLogradouro, n989RepresentanteBairro, A989RepresentanteBairro, n990RepresentanteCidade, A990RepresentanteCidade, n992RepresentanteLogradouroNumero, A992RepresentanteLogradouroNumero, n993RepresentanteComplemento, A993RepresentanteComplemento, n994RepresentanteDDD, A994RepresentanteDDD, n995RepresentanteNumero, A995RepresentanteNumero, n998RepresentanteTipo, A998RepresentanteTipo, n168ClienteId, A168ClienteId, n977RepresentanteProfissao, A977RepresentanteProfissao, n991RepresentanteMunicipio, A991RepresentanteMunicipio});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC003010 */
                     pr_default.execute(8);
                     A978RepresentanteId = BC003010_A978RepresentanteId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Representante");
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
               Load30104( ) ;
            }
            EndLevel30104( ) ;
         }
         CloseExtendedTableCursors30104( ) ;
      }

      protected void Update30104( )
      {
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate30104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003011 */
                     pr_default.execute(9, new Object[] {n979RepresentanteNome, A979RepresentanteNome, n980RepresentanteRG, A980RepresentanteRG, n981RepresentanteOrgaoExpedidor, A981RepresentanteOrgaoExpedidor, n982RepresentanteRGUF, A982RepresentanteRGUF, n983RepresentanteCPF, A983RepresentanteCPF, n984RepresentanteEstadoCivil, A984RepresentanteEstadoCivil, n985RepresentanteNacionalidade, A985RepresentanteNacionalidade, n986RepresentanteEmail, A986RepresentanteEmail, n987RepresentanteCEP, A987RepresentanteCEP, n988RepresentanteLogradouro, A988RepresentanteLogradouro, n989RepresentanteBairro, A989RepresentanteBairro, n990RepresentanteCidade, A990RepresentanteCidade, n992RepresentanteLogradouroNumero, A992RepresentanteLogradouroNumero, n993RepresentanteComplemento, A993RepresentanteComplemento, n994RepresentanteDDD, A994RepresentanteDDD, n995RepresentanteNumero, A995RepresentanteNumero, n998RepresentanteTipo, A998RepresentanteTipo, n168ClienteId, A168ClienteId, n977RepresentanteProfissao, A977RepresentanteProfissao, n991RepresentanteMunicipio, A991RepresentanteMunicipio, A978RepresentanteId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Representante");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Representante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate30104( ) ;
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
            EndLevel30104( ) ;
         }
         CloseExtendedTableCursors30104( ) ;
      }

      protected void DeferredUpdate30104( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate30104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls30104( ) ;
            AfterConfirm30104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete30104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003012 */
                  pr_default.execute(10, new Object[] {A978RepresentanteId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Representante");
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel30104( ) ;
         Gx_mode = sMode104;
      }

      protected void OnDeleteControls30104( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003013 */
            pr_default.execute(11, new Object[] {n977RepresentanteProfissao, A977RepresentanteProfissao});
            A999RepresentanteProfissaoDescricao = BC003013_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = BC003013_n999RepresentanteProfissaoDescricao[0];
            pr_default.close(11);
            /* Using cursor BC003014 */
            pr_default.execute(12, new Object[] {n991RepresentanteMunicipio, A991RepresentanteMunicipio});
            A996RepresentanteMunicipioUF = BC003014_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = BC003014_n996RepresentanteMunicipioUF[0];
            A997RepresentanteMunicipioNome = BC003014_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = BC003014_n997RepresentanteMunicipioNome[0];
            pr_default.close(12);
         }
      }

      protected void EndLevel30104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete30104( ) ;
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

      public void ScanKeyStart30104( )
      {
         /* Scan By routine */
         /* Using cursor BC003015 */
         pr_default.execute(13, new Object[] {A978RepresentanteId});
         RcdFound104 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound104 = 1;
            A978RepresentanteId = BC003015_A978RepresentanteId[0];
            A979RepresentanteNome = BC003015_A979RepresentanteNome[0];
            n979RepresentanteNome = BC003015_n979RepresentanteNome[0];
            A980RepresentanteRG = BC003015_A980RepresentanteRG[0];
            n980RepresentanteRG = BC003015_n980RepresentanteRG[0];
            A981RepresentanteOrgaoExpedidor = BC003015_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = BC003015_n981RepresentanteOrgaoExpedidor[0];
            A982RepresentanteRGUF = BC003015_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = BC003015_n982RepresentanteRGUF[0];
            A983RepresentanteCPF = BC003015_A983RepresentanteCPF[0];
            n983RepresentanteCPF = BC003015_n983RepresentanteCPF[0];
            A984RepresentanteEstadoCivil = BC003015_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = BC003015_n984RepresentanteEstadoCivil[0];
            A985RepresentanteNacionalidade = BC003015_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = BC003015_n985RepresentanteNacionalidade[0];
            A999RepresentanteProfissaoDescricao = BC003015_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = BC003015_n999RepresentanteProfissaoDescricao[0];
            A986RepresentanteEmail = BC003015_A986RepresentanteEmail[0];
            n986RepresentanteEmail = BC003015_n986RepresentanteEmail[0];
            A987RepresentanteCEP = BC003015_A987RepresentanteCEP[0];
            n987RepresentanteCEP = BC003015_n987RepresentanteCEP[0];
            A988RepresentanteLogradouro = BC003015_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = BC003015_n988RepresentanteLogradouro[0];
            A989RepresentanteBairro = BC003015_A989RepresentanteBairro[0];
            n989RepresentanteBairro = BC003015_n989RepresentanteBairro[0];
            A990RepresentanteCidade = BC003015_A990RepresentanteCidade[0];
            n990RepresentanteCidade = BC003015_n990RepresentanteCidade[0];
            A992RepresentanteLogradouroNumero = BC003015_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = BC003015_n992RepresentanteLogradouroNumero[0];
            A993RepresentanteComplemento = BC003015_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = BC003015_n993RepresentanteComplemento[0];
            A994RepresentanteDDD = BC003015_A994RepresentanteDDD[0];
            n994RepresentanteDDD = BC003015_n994RepresentanteDDD[0];
            A995RepresentanteNumero = BC003015_A995RepresentanteNumero[0];
            n995RepresentanteNumero = BC003015_n995RepresentanteNumero[0];
            A996RepresentanteMunicipioUF = BC003015_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = BC003015_n996RepresentanteMunicipioUF[0];
            A997RepresentanteMunicipioNome = BC003015_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = BC003015_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = BC003015_A998RepresentanteTipo[0];
            n998RepresentanteTipo = BC003015_n998RepresentanteTipo[0];
            A168ClienteId = BC003015_A168ClienteId[0];
            n168ClienteId = BC003015_n168ClienteId[0];
            A977RepresentanteProfissao = BC003015_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = BC003015_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = BC003015_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = BC003015_n991RepresentanteMunicipio[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext30104( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound104 = 0;
         ScanKeyLoad30104( ) ;
      }

      protected void ScanKeyLoad30104( )
      {
         sMode104 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound104 = 1;
            A978RepresentanteId = BC003015_A978RepresentanteId[0];
            A979RepresentanteNome = BC003015_A979RepresentanteNome[0];
            n979RepresentanteNome = BC003015_n979RepresentanteNome[0];
            A980RepresentanteRG = BC003015_A980RepresentanteRG[0];
            n980RepresentanteRG = BC003015_n980RepresentanteRG[0];
            A981RepresentanteOrgaoExpedidor = BC003015_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = BC003015_n981RepresentanteOrgaoExpedidor[0];
            A982RepresentanteRGUF = BC003015_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = BC003015_n982RepresentanteRGUF[0];
            A983RepresentanteCPF = BC003015_A983RepresentanteCPF[0];
            n983RepresentanteCPF = BC003015_n983RepresentanteCPF[0];
            A984RepresentanteEstadoCivil = BC003015_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = BC003015_n984RepresentanteEstadoCivil[0];
            A985RepresentanteNacionalidade = BC003015_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = BC003015_n985RepresentanteNacionalidade[0];
            A999RepresentanteProfissaoDescricao = BC003015_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = BC003015_n999RepresentanteProfissaoDescricao[0];
            A986RepresentanteEmail = BC003015_A986RepresentanteEmail[0];
            n986RepresentanteEmail = BC003015_n986RepresentanteEmail[0];
            A987RepresentanteCEP = BC003015_A987RepresentanteCEP[0];
            n987RepresentanteCEP = BC003015_n987RepresentanteCEP[0];
            A988RepresentanteLogradouro = BC003015_A988RepresentanteLogradouro[0];
            n988RepresentanteLogradouro = BC003015_n988RepresentanteLogradouro[0];
            A989RepresentanteBairro = BC003015_A989RepresentanteBairro[0];
            n989RepresentanteBairro = BC003015_n989RepresentanteBairro[0];
            A990RepresentanteCidade = BC003015_A990RepresentanteCidade[0];
            n990RepresentanteCidade = BC003015_n990RepresentanteCidade[0];
            A992RepresentanteLogradouroNumero = BC003015_A992RepresentanteLogradouroNumero[0];
            n992RepresentanteLogradouroNumero = BC003015_n992RepresentanteLogradouroNumero[0];
            A993RepresentanteComplemento = BC003015_A993RepresentanteComplemento[0];
            n993RepresentanteComplemento = BC003015_n993RepresentanteComplemento[0];
            A994RepresentanteDDD = BC003015_A994RepresentanteDDD[0];
            n994RepresentanteDDD = BC003015_n994RepresentanteDDD[0];
            A995RepresentanteNumero = BC003015_A995RepresentanteNumero[0];
            n995RepresentanteNumero = BC003015_n995RepresentanteNumero[0];
            A996RepresentanteMunicipioUF = BC003015_A996RepresentanteMunicipioUF[0];
            n996RepresentanteMunicipioUF = BC003015_n996RepresentanteMunicipioUF[0];
            A997RepresentanteMunicipioNome = BC003015_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = BC003015_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = BC003015_A998RepresentanteTipo[0];
            n998RepresentanteTipo = BC003015_n998RepresentanteTipo[0];
            A168ClienteId = BC003015_A168ClienteId[0];
            n168ClienteId = BC003015_n168ClienteId[0];
            A977RepresentanteProfissao = BC003015_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = BC003015_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = BC003015_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = BC003015_n991RepresentanteMunicipio[0];
         }
         Gx_mode = sMode104;
      }

      protected void ScanKeyEnd30104( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm30104( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert30104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate30104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete30104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete30104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate30104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes30104( )
      {
      }

      protected void send_integrity_lvl_hashes30104( )
      {
      }

      protected void AddRow30104( )
      {
         VarsToRow104( bcRepresentante) ;
      }

      protected void ReadRow30104( )
      {
         RowToVars104( bcRepresentante, 1) ;
      }

      protected void InitializeNonKey30104( )
      {
         A979RepresentanteNome = "";
         n979RepresentanteNome = false;
         A980RepresentanteRG = "";
         n980RepresentanteRG = false;
         A981RepresentanteOrgaoExpedidor = "";
         n981RepresentanteOrgaoExpedidor = false;
         A982RepresentanteRGUF = "";
         n982RepresentanteRGUF = false;
         A983RepresentanteCPF = "";
         n983RepresentanteCPF = false;
         A984RepresentanteEstadoCivil = "";
         n984RepresentanteEstadoCivil = false;
         A985RepresentanteNacionalidade = "";
         n985RepresentanteNacionalidade = false;
         A977RepresentanteProfissao = 0;
         n977RepresentanteProfissao = false;
         A999RepresentanteProfissaoDescricao = "";
         n999RepresentanteProfissaoDescricao = false;
         A986RepresentanteEmail = "";
         n986RepresentanteEmail = false;
         A987RepresentanteCEP = "";
         n987RepresentanteCEP = false;
         A988RepresentanteLogradouro = "";
         n988RepresentanteLogradouro = false;
         A989RepresentanteBairro = "";
         n989RepresentanteBairro = false;
         A990RepresentanteCidade = "";
         n990RepresentanteCidade = false;
         A991RepresentanteMunicipio = "";
         n991RepresentanteMunicipio = false;
         A992RepresentanteLogradouroNumero = 0;
         n992RepresentanteLogradouroNumero = false;
         A993RepresentanteComplemento = "";
         n993RepresentanteComplemento = false;
         A994RepresentanteDDD = 0;
         n994RepresentanteDDD = false;
         A995RepresentanteNumero = 0;
         n995RepresentanteNumero = false;
         A996RepresentanteMunicipioUF = "";
         n996RepresentanteMunicipioUF = false;
         A997RepresentanteMunicipioNome = "";
         n997RepresentanteMunicipioNome = false;
         A998RepresentanteTipo = "";
         n998RepresentanteTipo = false;
         A168ClienteId = 0;
         n168ClienteId = false;
         Z979RepresentanteNome = "";
         Z980RepresentanteRG = "";
         Z981RepresentanteOrgaoExpedidor = "";
         Z982RepresentanteRGUF = "";
         Z983RepresentanteCPF = "";
         Z984RepresentanteEstadoCivil = "";
         Z985RepresentanteNacionalidade = "";
         Z986RepresentanteEmail = "";
         Z987RepresentanteCEP = "";
         Z988RepresentanteLogradouro = "";
         Z989RepresentanteBairro = "";
         Z990RepresentanteCidade = "";
         Z992RepresentanteLogradouroNumero = 0;
         Z993RepresentanteComplemento = "";
         Z994RepresentanteDDD = 0;
         Z995RepresentanteNumero = 0;
         Z998RepresentanteTipo = "";
         Z168ClienteId = 0;
         Z977RepresentanteProfissao = 0;
         Z991RepresentanteMunicipio = "";
      }

      protected void InitAll30104( )
      {
         A978RepresentanteId = 0;
         InitializeNonKey30104( ) ;
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

      public void VarsToRow104( SdtRepresentante obj104 )
      {
         obj104.gxTpr_Mode = Gx_mode;
         obj104.gxTpr_Representantenome = A979RepresentanteNome;
         obj104.gxTpr_Representanterg = A980RepresentanteRG;
         obj104.gxTpr_Representanteorgaoexpedidor = A981RepresentanteOrgaoExpedidor;
         obj104.gxTpr_Representanterguf = A982RepresentanteRGUF;
         obj104.gxTpr_Representantecpf = A983RepresentanteCPF;
         obj104.gxTpr_Representanteestadocivil = A984RepresentanteEstadoCivil;
         obj104.gxTpr_Representantenacionalidade = A985RepresentanteNacionalidade;
         obj104.gxTpr_Representanteprofissao = A977RepresentanteProfissao;
         obj104.gxTpr_Representanteprofissaodescricao = A999RepresentanteProfissaoDescricao;
         obj104.gxTpr_Representanteemail = A986RepresentanteEmail;
         obj104.gxTpr_Representantecep = A987RepresentanteCEP;
         obj104.gxTpr_Representantelogradouro = A988RepresentanteLogradouro;
         obj104.gxTpr_Representantebairro = A989RepresentanteBairro;
         obj104.gxTpr_Representantecidade = A990RepresentanteCidade;
         obj104.gxTpr_Representantemunicipio = A991RepresentanteMunicipio;
         obj104.gxTpr_Representantelogradouronumero = A992RepresentanteLogradouroNumero;
         obj104.gxTpr_Representantecomplemento = A993RepresentanteComplemento;
         obj104.gxTpr_Representanteddd = A994RepresentanteDDD;
         obj104.gxTpr_Representantenumero = A995RepresentanteNumero;
         obj104.gxTpr_Representantemunicipiouf = A996RepresentanteMunicipioUF;
         obj104.gxTpr_Representantemunicipionome = A997RepresentanteMunicipioNome;
         obj104.gxTpr_Representantetipo = A998RepresentanteTipo;
         obj104.gxTpr_Clienteid = A168ClienteId;
         obj104.gxTpr_Representanteid = A978RepresentanteId;
         obj104.gxTpr_Representanteid_Z = Z978RepresentanteId;
         obj104.gxTpr_Representantenome_Z = Z979RepresentanteNome;
         obj104.gxTpr_Representanterg_Z = Z980RepresentanteRG;
         obj104.gxTpr_Representanteorgaoexpedidor_Z = Z981RepresentanteOrgaoExpedidor;
         obj104.gxTpr_Representanterguf_Z = Z982RepresentanteRGUF;
         obj104.gxTpr_Representantecpf_Z = Z983RepresentanteCPF;
         obj104.gxTpr_Representanteestadocivil_Z = Z984RepresentanteEstadoCivil;
         obj104.gxTpr_Representantenacionalidade_Z = Z985RepresentanteNacionalidade;
         obj104.gxTpr_Representanteprofissao_Z = Z977RepresentanteProfissao;
         obj104.gxTpr_Representanteprofissaodescricao_Z = Z999RepresentanteProfissaoDescricao;
         obj104.gxTpr_Representanteemail_Z = Z986RepresentanteEmail;
         obj104.gxTpr_Representantecep_Z = Z987RepresentanteCEP;
         obj104.gxTpr_Representantelogradouro_Z = Z988RepresentanteLogradouro;
         obj104.gxTpr_Representantebairro_Z = Z989RepresentanteBairro;
         obj104.gxTpr_Representantecidade_Z = Z990RepresentanteCidade;
         obj104.gxTpr_Representantemunicipio_Z = Z991RepresentanteMunicipio;
         obj104.gxTpr_Representantelogradouronumero_Z = Z992RepresentanteLogradouroNumero;
         obj104.gxTpr_Representantecomplemento_Z = Z993RepresentanteComplemento;
         obj104.gxTpr_Representanteddd_Z = Z994RepresentanteDDD;
         obj104.gxTpr_Representantenumero_Z = Z995RepresentanteNumero;
         obj104.gxTpr_Representantemunicipiouf_Z = Z996RepresentanteMunicipioUF;
         obj104.gxTpr_Representantemunicipionome_Z = Z997RepresentanteMunicipioNome;
         obj104.gxTpr_Representantetipo_Z = Z998RepresentanteTipo;
         obj104.gxTpr_Clienteid_Z = Z168ClienteId;
         obj104.gxTpr_Representantenome_N = (short)(Convert.ToInt16(n979RepresentanteNome));
         obj104.gxTpr_Representanterg_N = (short)(Convert.ToInt16(n980RepresentanteRG));
         obj104.gxTpr_Representanteorgaoexpedidor_N = (short)(Convert.ToInt16(n981RepresentanteOrgaoExpedidor));
         obj104.gxTpr_Representanterguf_N = (short)(Convert.ToInt16(n982RepresentanteRGUF));
         obj104.gxTpr_Representantecpf_N = (short)(Convert.ToInt16(n983RepresentanteCPF));
         obj104.gxTpr_Representanteestadocivil_N = (short)(Convert.ToInt16(n984RepresentanteEstadoCivil));
         obj104.gxTpr_Representantenacionalidade_N = (short)(Convert.ToInt16(n985RepresentanteNacionalidade));
         obj104.gxTpr_Representanteprofissao_N = (short)(Convert.ToInt16(n977RepresentanteProfissao));
         obj104.gxTpr_Representanteprofissaodescricao_N = (short)(Convert.ToInt16(n999RepresentanteProfissaoDescricao));
         obj104.gxTpr_Representanteemail_N = (short)(Convert.ToInt16(n986RepresentanteEmail));
         obj104.gxTpr_Representantecep_N = (short)(Convert.ToInt16(n987RepresentanteCEP));
         obj104.gxTpr_Representantelogradouro_N = (short)(Convert.ToInt16(n988RepresentanteLogradouro));
         obj104.gxTpr_Representantebairro_N = (short)(Convert.ToInt16(n989RepresentanteBairro));
         obj104.gxTpr_Representantecidade_N = (short)(Convert.ToInt16(n990RepresentanteCidade));
         obj104.gxTpr_Representantemunicipio_N = (short)(Convert.ToInt16(n991RepresentanteMunicipio));
         obj104.gxTpr_Representantelogradouronumero_N = (short)(Convert.ToInt16(n992RepresentanteLogradouroNumero));
         obj104.gxTpr_Representantecomplemento_N = (short)(Convert.ToInt16(n993RepresentanteComplemento));
         obj104.gxTpr_Representanteddd_N = (short)(Convert.ToInt16(n994RepresentanteDDD));
         obj104.gxTpr_Representantenumero_N = (short)(Convert.ToInt16(n995RepresentanteNumero));
         obj104.gxTpr_Representantemunicipiouf_N = (short)(Convert.ToInt16(n996RepresentanteMunicipioUF));
         obj104.gxTpr_Representantemunicipionome_N = (short)(Convert.ToInt16(n997RepresentanteMunicipioNome));
         obj104.gxTpr_Representantetipo_N = (short)(Convert.ToInt16(n998RepresentanteTipo));
         obj104.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj104.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow104( SdtRepresentante obj104 )
      {
         obj104.gxTpr_Representanteid = A978RepresentanteId;
         return  ;
      }

      public void RowToVars104( SdtRepresentante obj104 ,
                                int forceLoad )
      {
         Gx_mode = obj104.gxTpr_Mode;
         A979RepresentanteNome = obj104.gxTpr_Representantenome;
         n979RepresentanteNome = false;
         A980RepresentanteRG = obj104.gxTpr_Representanterg;
         n980RepresentanteRG = false;
         A981RepresentanteOrgaoExpedidor = obj104.gxTpr_Representanteorgaoexpedidor;
         n981RepresentanteOrgaoExpedidor = false;
         A982RepresentanteRGUF = obj104.gxTpr_Representanterguf;
         n982RepresentanteRGUF = false;
         A983RepresentanteCPF = obj104.gxTpr_Representantecpf;
         n983RepresentanteCPF = false;
         A984RepresentanteEstadoCivil = obj104.gxTpr_Representanteestadocivil;
         n984RepresentanteEstadoCivil = false;
         A985RepresentanteNacionalidade = obj104.gxTpr_Representantenacionalidade;
         n985RepresentanteNacionalidade = false;
         A977RepresentanteProfissao = obj104.gxTpr_Representanteprofissao;
         n977RepresentanteProfissao = false;
         A999RepresentanteProfissaoDescricao = obj104.gxTpr_Representanteprofissaodescricao;
         n999RepresentanteProfissaoDescricao = false;
         A986RepresentanteEmail = obj104.gxTpr_Representanteemail;
         n986RepresentanteEmail = false;
         A987RepresentanteCEP = obj104.gxTpr_Representantecep;
         n987RepresentanteCEP = false;
         A988RepresentanteLogradouro = obj104.gxTpr_Representantelogradouro;
         n988RepresentanteLogradouro = false;
         A989RepresentanteBairro = obj104.gxTpr_Representantebairro;
         n989RepresentanteBairro = false;
         A990RepresentanteCidade = obj104.gxTpr_Representantecidade;
         n990RepresentanteCidade = false;
         A991RepresentanteMunicipio = obj104.gxTpr_Representantemunicipio;
         n991RepresentanteMunicipio = false;
         A992RepresentanteLogradouroNumero = obj104.gxTpr_Representantelogradouronumero;
         n992RepresentanteLogradouroNumero = false;
         A993RepresentanteComplemento = obj104.gxTpr_Representantecomplemento;
         n993RepresentanteComplemento = false;
         A994RepresentanteDDD = obj104.gxTpr_Representanteddd;
         n994RepresentanteDDD = false;
         A995RepresentanteNumero = obj104.gxTpr_Representantenumero;
         n995RepresentanteNumero = false;
         A996RepresentanteMunicipioUF = obj104.gxTpr_Representantemunicipiouf;
         n996RepresentanteMunicipioUF = false;
         A997RepresentanteMunicipioNome = obj104.gxTpr_Representantemunicipionome;
         n997RepresentanteMunicipioNome = false;
         A998RepresentanteTipo = obj104.gxTpr_Representantetipo;
         n998RepresentanteTipo = false;
         A168ClienteId = obj104.gxTpr_Clienteid;
         n168ClienteId = false;
         A978RepresentanteId = obj104.gxTpr_Representanteid;
         Z978RepresentanteId = obj104.gxTpr_Representanteid_Z;
         Z979RepresentanteNome = obj104.gxTpr_Representantenome_Z;
         Z980RepresentanteRG = obj104.gxTpr_Representanterg_Z;
         Z981RepresentanteOrgaoExpedidor = obj104.gxTpr_Representanteorgaoexpedidor_Z;
         Z982RepresentanteRGUF = obj104.gxTpr_Representanterguf_Z;
         Z983RepresentanteCPF = obj104.gxTpr_Representantecpf_Z;
         Z984RepresentanteEstadoCivil = obj104.gxTpr_Representanteestadocivil_Z;
         Z985RepresentanteNacionalidade = obj104.gxTpr_Representantenacionalidade_Z;
         Z977RepresentanteProfissao = obj104.gxTpr_Representanteprofissao_Z;
         Z999RepresentanteProfissaoDescricao = obj104.gxTpr_Representanteprofissaodescricao_Z;
         Z986RepresentanteEmail = obj104.gxTpr_Representanteemail_Z;
         Z987RepresentanteCEP = obj104.gxTpr_Representantecep_Z;
         Z988RepresentanteLogradouro = obj104.gxTpr_Representantelogradouro_Z;
         Z989RepresentanteBairro = obj104.gxTpr_Representantebairro_Z;
         Z990RepresentanteCidade = obj104.gxTpr_Representantecidade_Z;
         Z991RepresentanteMunicipio = obj104.gxTpr_Representantemunicipio_Z;
         Z992RepresentanteLogradouroNumero = obj104.gxTpr_Representantelogradouronumero_Z;
         Z993RepresentanteComplemento = obj104.gxTpr_Representantecomplemento_Z;
         Z994RepresentanteDDD = obj104.gxTpr_Representanteddd_Z;
         Z995RepresentanteNumero = obj104.gxTpr_Representantenumero_Z;
         Z996RepresentanteMunicipioUF = obj104.gxTpr_Representantemunicipiouf_Z;
         Z997RepresentanteMunicipioNome = obj104.gxTpr_Representantemunicipionome_Z;
         Z998RepresentanteTipo = obj104.gxTpr_Representantetipo_Z;
         Z168ClienteId = obj104.gxTpr_Clienteid_Z;
         n979RepresentanteNome = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantenome_N));
         n980RepresentanteRG = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanterg_N));
         n981RepresentanteOrgaoExpedidor = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteorgaoexpedidor_N));
         n982RepresentanteRGUF = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanterguf_N));
         n983RepresentanteCPF = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantecpf_N));
         n984RepresentanteEstadoCivil = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteestadocivil_N));
         n985RepresentanteNacionalidade = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantenacionalidade_N));
         n977RepresentanteProfissao = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteprofissao_N));
         n999RepresentanteProfissaoDescricao = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteprofissaodescricao_N));
         n986RepresentanteEmail = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteemail_N));
         n987RepresentanteCEP = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantecep_N));
         n988RepresentanteLogradouro = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantelogradouro_N));
         n989RepresentanteBairro = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantebairro_N));
         n990RepresentanteCidade = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantecidade_N));
         n991RepresentanteMunicipio = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantemunicipio_N));
         n992RepresentanteLogradouroNumero = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantelogradouronumero_N));
         n993RepresentanteComplemento = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantecomplemento_N));
         n994RepresentanteDDD = (bool)(Convert.ToBoolean(obj104.gxTpr_Representanteddd_N));
         n995RepresentanteNumero = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantenumero_N));
         n996RepresentanteMunicipioUF = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantemunicipiouf_N));
         n997RepresentanteMunicipioNome = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantemunicipionome_N));
         n998RepresentanteTipo = (bool)(Convert.ToBoolean(obj104.gxTpr_Representantetipo_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj104.gxTpr_Clienteid_N));
         Gx_mode = obj104.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A978RepresentanteId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey30104( ) ;
         ScanKeyStart30104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z978RepresentanteId = A978RepresentanteId;
         }
         ZM30104( -6) ;
         OnLoadActions30104( ) ;
         AddRow30104( ) ;
         ScanKeyEnd30104( ) ;
         if ( RcdFound104 == 0 )
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
         RowToVars104( bcRepresentante, 0) ;
         ScanKeyStart30104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z978RepresentanteId = A978RepresentanteId;
         }
         ZM30104( -6) ;
         OnLoadActions30104( ) ;
         AddRow30104( ) ;
         ScanKeyEnd30104( ) ;
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey30104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert30104( ) ;
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( A978RepresentanteId != Z978RepresentanteId )
               {
                  A978RepresentanteId = Z978RepresentanteId;
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
                  Update30104( ) ;
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
                  if ( A978RepresentanteId != Z978RepresentanteId )
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
                        Insert30104( ) ;
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
                        Insert30104( ) ;
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
         RowToVars104( bcRepresentante, 1) ;
         SaveImpl( ) ;
         VarsToRow104( bcRepresentante) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars104( bcRepresentante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert30104( ) ;
         AfterTrn( ) ;
         VarsToRow104( bcRepresentante) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow104( bcRepresentante) ;
         }
         else
         {
            SdtRepresentante auxBC = new SdtRepresentante(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A978RepresentanteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRepresentante);
               auxBC.Save();
               bcRepresentante.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars104( bcRepresentante, 1) ;
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
         RowToVars104( bcRepresentante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert30104( ) ;
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
               VarsToRow104( bcRepresentante) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow104( bcRepresentante) ;
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
         RowToVars104( bcRepresentante, 0) ;
         GetKey30104( ) ;
         if ( RcdFound104 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A978RepresentanteId != Z978RepresentanteId )
            {
               A978RepresentanteId = Z978RepresentanteId;
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
            if ( A978RepresentanteId != Z978RepresentanteId )
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
         context.RollbackDataStores("representante_bc",pr_default);
         VarsToRow104( bcRepresentante) ;
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
         Gx_mode = bcRepresentante.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRepresentante.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRepresentante )
         {
            bcRepresentante = (SdtRepresentante)(sdt);
            if ( StringUtil.StrCmp(bcRepresentante.gxTpr_Mode, "") == 0 )
            {
               bcRepresentante.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow104( bcRepresentante) ;
            }
            else
            {
               RowToVars104( bcRepresentante, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRepresentante.gxTpr_Mode, "") == 0 )
            {
               bcRepresentante.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars104( bcRepresentante, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtRepresentante Representante_BC
      {
         get {
            return bcRepresentante ;
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
         AV27Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV12Insert_RepresentanteMunicipio = "";
         Z979RepresentanteNome = "";
         A979RepresentanteNome = "";
         Z980RepresentanteRG = "";
         A980RepresentanteRG = "";
         Z981RepresentanteOrgaoExpedidor = "";
         A981RepresentanteOrgaoExpedidor = "";
         Z982RepresentanteRGUF = "";
         A982RepresentanteRGUF = "";
         Z983RepresentanteCPF = "";
         A983RepresentanteCPF = "";
         Z984RepresentanteEstadoCivil = "";
         A984RepresentanteEstadoCivil = "";
         Z985RepresentanteNacionalidade = "";
         A985RepresentanteNacionalidade = "";
         Z986RepresentanteEmail = "";
         A986RepresentanteEmail = "";
         Z987RepresentanteCEP = "";
         A987RepresentanteCEP = "";
         Z988RepresentanteLogradouro = "";
         A988RepresentanteLogradouro = "";
         Z989RepresentanteBairro = "";
         A989RepresentanteBairro = "";
         Z990RepresentanteCidade = "";
         A990RepresentanteCidade = "";
         Z993RepresentanteComplemento = "";
         A993RepresentanteComplemento = "";
         Z998RepresentanteTipo = "";
         A998RepresentanteTipo = "";
         Z991RepresentanteMunicipio = "";
         A991RepresentanteMunicipio = "";
         Z999RepresentanteProfissaoDescricao = "";
         A999RepresentanteProfissaoDescricao = "";
         Z996RepresentanteMunicipioUF = "";
         A996RepresentanteMunicipioUF = "";
         Z997RepresentanteMunicipioNome = "";
         A997RepresentanteMunicipioNome = "";
         BC00307_A978RepresentanteId = new int[1] ;
         BC00307_A979RepresentanteNome = new string[] {""} ;
         BC00307_n979RepresentanteNome = new bool[] {false} ;
         BC00307_A980RepresentanteRG = new string[] {""} ;
         BC00307_n980RepresentanteRG = new bool[] {false} ;
         BC00307_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         BC00307_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         BC00307_A982RepresentanteRGUF = new string[] {""} ;
         BC00307_n982RepresentanteRGUF = new bool[] {false} ;
         BC00307_A983RepresentanteCPF = new string[] {""} ;
         BC00307_n983RepresentanteCPF = new bool[] {false} ;
         BC00307_A984RepresentanteEstadoCivil = new string[] {""} ;
         BC00307_n984RepresentanteEstadoCivil = new bool[] {false} ;
         BC00307_A985RepresentanteNacionalidade = new string[] {""} ;
         BC00307_n985RepresentanteNacionalidade = new bool[] {false} ;
         BC00307_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         BC00307_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         BC00307_A986RepresentanteEmail = new string[] {""} ;
         BC00307_n986RepresentanteEmail = new bool[] {false} ;
         BC00307_A987RepresentanteCEP = new string[] {""} ;
         BC00307_n987RepresentanteCEP = new bool[] {false} ;
         BC00307_A988RepresentanteLogradouro = new string[] {""} ;
         BC00307_n988RepresentanteLogradouro = new bool[] {false} ;
         BC00307_A989RepresentanteBairro = new string[] {""} ;
         BC00307_n989RepresentanteBairro = new bool[] {false} ;
         BC00307_A990RepresentanteCidade = new string[] {""} ;
         BC00307_n990RepresentanteCidade = new bool[] {false} ;
         BC00307_A992RepresentanteLogradouroNumero = new long[1] ;
         BC00307_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         BC00307_A993RepresentanteComplemento = new string[] {""} ;
         BC00307_n993RepresentanteComplemento = new bool[] {false} ;
         BC00307_A994RepresentanteDDD = new short[1] ;
         BC00307_n994RepresentanteDDD = new bool[] {false} ;
         BC00307_A995RepresentanteNumero = new int[1] ;
         BC00307_n995RepresentanteNumero = new bool[] {false} ;
         BC00307_A996RepresentanteMunicipioUF = new string[] {""} ;
         BC00307_n996RepresentanteMunicipioUF = new bool[] {false} ;
         BC00307_A997RepresentanteMunicipioNome = new string[] {""} ;
         BC00307_n997RepresentanteMunicipioNome = new bool[] {false} ;
         BC00307_A998RepresentanteTipo = new string[] {""} ;
         BC00307_n998RepresentanteTipo = new bool[] {false} ;
         BC00307_A168ClienteId = new int[1] ;
         BC00307_n168ClienteId = new bool[] {false} ;
         BC00307_A977RepresentanteProfissao = new int[1] ;
         BC00307_n977RepresentanteProfissao = new bool[] {false} ;
         BC00307_A991RepresentanteMunicipio = new string[] {""} ;
         BC00307_n991RepresentanteMunicipio = new bool[] {false} ;
         BC00305_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         BC00305_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         BC00306_A996RepresentanteMunicipioUF = new string[] {""} ;
         BC00306_n996RepresentanteMunicipioUF = new bool[] {false} ;
         BC00306_A997RepresentanteMunicipioNome = new string[] {""} ;
         BC00306_n997RepresentanteMunicipioNome = new bool[] {false} ;
         BC00304_A168ClienteId = new int[1] ;
         BC00304_n168ClienteId = new bool[] {false} ;
         BC00308_A978RepresentanteId = new int[1] ;
         BC00303_A978RepresentanteId = new int[1] ;
         BC00303_A979RepresentanteNome = new string[] {""} ;
         BC00303_n979RepresentanteNome = new bool[] {false} ;
         BC00303_A980RepresentanteRG = new string[] {""} ;
         BC00303_n980RepresentanteRG = new bool[] {false} ;
         BC00303_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         BC00303_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         BC00303_A982RepresentanteRGUF = new string[] {""} ;
         BC00303_n982RepresentanteRGUF = new bool[] {false} ;
         BC00303_A983RepresentanteCPF = new string[] {""} ;
         BC00303_n983RepresentanteCPF = new bool[] {false} ;
         BC00303_A984RepresentanteEstadoCivil = new string[] {""} ;
         BC00303_n984RepresentanteEstadoCivil = new bool[] {false} ;
         BC00303_A985RepresentanteNacionalidade = new string[] {""} ;
         BC00303_n985RepresentanteNacionalidade = new bool[] {false} ;
         BC00303_A986RepresentanteEmail = new string[] {""} ;
         BC00303_n986RepresentanteEmail = new bool[] {false} ;
         BC00303_A987RepresentanteCEP = new string[] {""} ;
         BC00303_n987RepresentanteCEP = new bool[] {false} ;
         BC00303_A988RepresentanteLogradouro = new string[] {""} ;
         BC00303_n988RepresentanteLogradouro = new bool[] {false} ;
         BC00303_A989RepresentanteBairro = new string[] {""} ;
         BC00303_n989RepresentanteBairro = new bool[] {false} ;
         BC00303_A990RepresentanteCidade = new string[] {""} ;
         BC00303_n990RepresentanteCidade = new bool[] {false} ;
         BC00303_A992RepresentanteLogradouroNumero = new long[1] ;
         BC00303_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         BC00303_A993RepresentanteComplemento = new string[] {""} ;
         BC00303_n993RepresentanteComplemento = new bool[] {false} ;
         BC00303_A994RepresentanteDDD = new short[1] ;
         BC00303_n994RepresentanteDDD = new bool[] {false} ;
         BC00303_A995RepresentanteNumero = new int[1] ;
         BC00303_n995RepresentanteNumero = new bool[] {false} ;
         BC00303_A998RepresentanteTipo = new string[] {""} ;
         BC00303_n998RepresentanteTipo = new bool[] {false} ;
         BC00303_A168ClienteId = new int[1] ;
         BC00303_n168ClienteId = new bool[] {false} ;
         BC00303_A977RepresentanteProfissao = new int[1] ;
         BC00303_n977RepresentanteProfissao = new bool[] {false} ;
         BC00303_A991RepresentanteMunicipio = new string[] {""} ;
         BC00303_n991RepresentanteMunicipio = new bool[] {false} ;
         sMode104 = "";
         BC00302_A978RepresentanteId = new int[1] ;
         BC00302_A979RepresentanteNome = new string[] {""} ;
         BC00302_n979RepresentanteNome = new bool[] {false} ;
         BC00302_A980RepresentanteRG = new string[] {""} ;
         BC00302_n980RepresentanteRG = new bool[] {false} ;
         BC00302_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         BC00302_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         BC00302_A982RepresentanteRGUF = new string[] {""} ;
         BC00302_n982RepresentanteRGUF = new bool[] {false} ;
         BC00302_A983RepresentanteCPF = new string[] {""} ;
         BC00302_n983RepresentanteCPF = new bool[] {false} ;
         BC00302_A984RepresentanteEstadoCivil = new string[] {""} ;
         BC00302_n984RepresentanteEstadoCivil = new bool[] {false} ;
         BC00302_A985RepresentanteNacionalidade = new string[] {""} ;
         BC00302_n985RepresentanteNacionalidade = new bool[] {false} ;
         BC00302_A986RepresentanteEmail = new string[] {""} ;
         BC00302_n986RepresentanteEmail = new bool[] {false} ;
         BC00302_A987RepresentanteCEP = new string[] {""} ;
         BC00302_n987RepresentanteCEP = new bool[] {false} ;
         BC00302_A988RepresentanteLogradouro = new string[] {""} ;
         BC00302_n988RepresentanteLogradouro = new bool[] {false} ;
         BC00302_A989RepresentanteBairro = new string[] {""} ;
         BC00302_n989RepresentanteBairro = new bool[] {false} ;
         BC00302_A990RepresentanteCidade = new string[] {""} ;
         BC00302_n990RepresentanteCidade = new bool[] {false} ;
         BC00302_A992RepresentanteLogradouroNumero = new long[1] ;
         BC00302_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         BC00302_A993RepresentanteComplemento = new string[] {""} ;
         BC00302_n993RepresentanteComplemento = new bool[] {false} ;
         BC00302_A994RepresentanteDDD = new short[1] ;
         BC00302_n994RepresentanteDDD = new bool[] {false} ;
         BC00302_A995RepresentanteNumero = new int[1] ;
         BC00302_n995RepresentanteNumero = new bool[] {false} ;
         BC00302_A998RepresentanteTipo = new string[] {""} ;
         BC00302_n998RepresentanteTipo = new bool[] {false} ;
         BC00302_A168ClienteId = new int[1] ;
         BC00302_n168ClienteId = new bool[] {false} ;
         BC00302_A977RepresentanteProfissao = new int[1] ;
         BC00302_n977RepresentanteProfissao = new bool[] {false} ;
         BC00302_A991RepresentanteMunicipio = new string[] {""} ;
         BC00302_n991RepresentanteMunicipio = new bool[] {false} ;
         BC003010_A978RepresentanteId = new int[1] ;
         BC003013_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         BC003013_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         BC003014_A996RepresentanteMunicipioUF = new string[] {""} ;
         BC003014_n996RepresentanteMunicipioUF = new bool[] {false} ;
         BC003014_A997RepresentanteMunicipioNome = new string[] {""} ;
         BC003014_n997RepresentanteMunicipioNome = new bool[] {false} ;
         BC003015_A978RepresentanteId = new int[1] ;
         BC003015_A979RepresentanteNome = new string[] {""} ;
         BC003015_n979RepresentanteNome = new bool[] {false} ;
         BC003015_A980RepresentanteRG = new string[] {""} ;
         BC003015_n980RepresentanteRG = new bool[] {false} ;
         BC003015_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         BC003015_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         BC003015_A982RepresentanteRGUF = new string[] {""} ;
         BC003015_n982RepresentanteRGUF = new bool[] {false} ;
         BC003015_A983RepresentanteCPF = new string[] {""} ;
         BC003015_n983RepresentanteCPF = new bool[] {false} ;
         BC003015_A984RepresentanteEstadoCivil = new string[] {""} ;
         BC003015_n984RepresentanteEstadoCivil = new bool[] {false} ;
         BC003015_A985RepresentanteNacionalidade = new string[] {""} ;
         BC003015_n985RepresentanteNacionalidade = new bool[] {false} ;
         BC003015_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         BC003015_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         BC003015_A986RepresentanteEmail = new string[] {""} ;
         BC003015_n986RepresentanteEmail = new bool[] {false} ;
         BC003015_A987RepresentanteCEP = new string[] {""} ;
         BC003015_n987RepresentanteCEP = new bool[] {false} ;
         BC003015_A988RepresentanteLogradouro = new string[] {""} ;
         BC003015_n988RepresentanteLogradouro = new bool[] {false} ;
         BC003015_A989RepresentanteBairro = new string[] {""} ;
         BC003015_n989RepresentanteBairro = new bool[] {false} ;
         BC003015_A990RepresentanteCidade = new string[] {""} ;
         BC003015_n990RepresentanteCidade = new bool[] {false} ;
         BC003015_A992RepresentanteLogradouroNumero = new long[1] ;
         BC003015_n992RepresentanteLogradouroNumero = new bool[] {false} ;
         BC003015_A993RepresentanteComplemento = new string[] {""} ;
         BC003015_n993RepresentanteComplemento = new bool[] {false} ;
         BC003015_A994RepresentanteDDD = new short[1] ;
         BC003015_n994RepresentanteDDD = new bool[] {false} ;
         BC003015_A995RepresentanteNumero = new int[1] ;
         BC003015_n995RepresentanteNumero = new bool[] {false} ;
         BC003015_A996RepresentanteMunicipioUF = new string[] {""} ;
         BC003015_n996RepresentanteMunicipioUF = new bool[] {false} ;
         BC003015_A997RepresentanteMunicipioNome = new string[] {""} ;
         BC003015_n997RepresentanteMunicipioNome = new bool[] {false} ;
         BC003015_A998RepresentanteTipo = new string[] {""} ;
         BC003015_n998RepresentanteTipo = new bool[] {false} ;
         BC003015_A168ClienteId = new int[1] ;
         BC003015_n168ClienteId = new bool[] {false} ;
         BC003015_A977RepresentanteProfissao = new int[1] ;
         BC003015_n977RepresentanteProfissao = new bool[] {false} ;
         BC003015_A991RepresentanteMunicipio = new string[] {""} ;
         BC003015_n991RepresentanteMunicipio = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representante_bc__default(),
            new Object[][] {
                new Object[] {
               BC00302_A978RepresentanteId, BC00302_A979RepresentanteNome, BC00302_n979RepresentanteNome, BC00302_A980RepresentanteRG, BC00302_n980RepresentanteRG, BC00302_A981RepresentanteOrgaoExpedidor, BC00302_n981RepresentanteOrgaoExpedidor, BC00302_A982RepresentanteRGUF, BC00302_n982RepresentanteRGUF, BC00302_A983RepresentanteCPF,
               BC00302_n983RepresentanteCPF, BC00302_A984RepresentanteEstadoCivil, BC00302_n984RepresentanteEstadoCivil, BC00302_A985RepresentanteNacionalidade, BC00302_n985RepresentanteNacionalidade, BC00302_A986RepresentanteEmail, BC00302_n986RepresentanteEmail, BC00302_A987RepresentanteCEP, BC00302_n987RepresentanteCEP, BC00302_A988RepresentanteLogradouro,
               BC00302_n988RepresentanteLogradouro, BC00302_A989RepresentanteBairro, BC00302_n989RepresentanteBairro, BC00302_A990RepresentanteCidade, BC00302_n990RepresentanteCidade, BC00302_A992RepresentanteLogradouroNumero, BC00302_n992RepresentanteLogradouroNumero, BC00302_A993RepresentanteComplemento, BC00302_n993RepresentanteComplemento, BC00302_A994RepresentanteDDD,
               BC00302_n994RepresentanteDDD, BC00302_A995RepresentanteNumero, BC00302_n995RepresentanteNumero, BC00302_A998RepresentanteTipo, BC00302_n998RepresentanteTipo, BC00302_A168ClienteId, BC00302_n168ClienteId, BC00302_A977RepresentanteProfissao, BC00302_n977RepresentanteProfissao, BC00302_A991RepresentanteMunicipio,
               BC00302_n991RepresentanteMunicipio
               }
               , new Object[] {
               BC00303_A978RepresentanteId, BC00303_A979RepresentanteNome, BC00303_n979RepresentanteNome, BC00303_A980RepresentanteRG, BC00303_n980RepresentanteRG, BC00303_A981RepresentanteOrgaoExpedidor, BC00303_n981RepresentanteOrgaoExpedidor, BC00303_A982RepresentanteRGUF, BC00303_n982RepresentanteRGUF, BC00303_A983RepresentanteCPF,
               BC00303_n983RepresentanteCPF, BC00303_A984RepresentanteEstadoCivil, BC00303_n984RepresentanteEstadoCivil, BC00303_A985RepresentanteNacionalidade, BC00303_n985RepresentanteNacionalidade, BC00303_A986RepresentanteEmail, BC00303_n986RepresentanteEmail, BC00303_A987RepresentanteCEP, BC00303_n987RepresentanteCEP, BC00303_A988RepresentanteLogradouro,
               BC00303_n988RepresentanteLogradouro, BC00303_A989RepresentanteBairro, BC00303_n989RepresentanteBairro, BC00303_A990RepresentanteCidade, BC00303_n990RepresentanteCidade, BC00303_A992RepresentanteLogradouroNumero, BC00303_n992RepresentanteLogradouroNumero, BC00303_A993RepresentanteComplemento, BC00303_n993RepresentanteComplemento, BC00303_A994RepresentanteDDD,
               BC00303_n994RepresentanteDDD, BC00303_A995RepresentanteNumero, BC00303_n995RepresentanteNumero, BC00303_A998RepresentanteTipo, BC00303_n998RepresentanteTipo, BC00303_A168ClienteId, BC00303_n168ClienteId, BC00303_A977RepresentanteProfissao, BC00303_n977RepresentanteProfissao, BC00303_A991RepresentanteMunicipio,
               BC00303_n991RepresentanteMunicipio
               }
               , new Object[] {
               BC00304_A168ClienteId
               }
               , new Object[] {
               BC00305_A999RepresentanteProfissaoDescricao, BC00305_n999RepresentanteProfissaoDescricao
               }
               , new Object[] {
               BC00306_A996RepresentanteMunicipioUF, BC00306_n996RepresentanteMunicipioUF, BC00306_A997RepresentanteMunicipioNome, BC00306_n997RepresentanteMunicipioNome
               }
               , new Object[] {
               BC00307_A978RepresentanteId, BC00307_A979RepresentanteNome, BC00307_n979RepresentanteNome, BC00307_A980RepresentanteRG, BC00307_n980RepresentanteRG, BC00307_A981RepresentanteOrgaoExpedidor, BC00307_n981RepresentanteOrgaoExpedidor, BC00307_A982RepresentanteRGUF, BC00307_n982RepresentanteRGUF, BC00307_A983RepresentanteCPF,
               BC00307_n983RepresentanteCPF, BC00307_A984RepresentanteEstadoCivil, BC00307_n984RepresentanteEstadoCivil, BC00307_A985RepresentanteNacionalidade, BC00307_n985RepresentanteNacionalidade, BC00307_A999RepresentanteProfissaoDescricao, BC00307_n999RepresentanteProfissaoDescricao, BC00307_A986RepresentanteEmail, BC00307_n986RepresentanteEmail, BC00307_A987RepresentanteCEP,
               BC00307_n987RepresentanteCEP, BC00307_A988RepresentanteLogradouro, BC00307_n988RepresentanteLogradouro, BC00307_A989RepresentanteBairro, BC00307_n989RepresentanteBairro, BC00307_A990RepresentanteCidade, BC00307_n990RepresentanteCidade, BC00307_A992RepresentanteLogradouroNumero, BC00307_n992RepresentanteLogradouroNumero, BC00307_A993RepresentanteComplemento,
               BC00307_n993RepresentanteComplemento, BC00307_A994RepresentanteDDD, BC00307_n994RepresentanteDDD, BC00307_A995RepresentanteNumero, BC00307_n995RepresentanteNumero, BC00307_A996RepresentanteMunicipioUF, BC00307_n996RepresentanteMunicipioUF, BC00307_A997RepresentanteMunicipioNome, BC00307_n997RepresentanteMunicipioNome, BC00307_A998RepresentanteTipo,
               BC00307_n998RepresentanteTipo, BC00307_A168ClienteId, BC00307_n168ClienteId, BC00307_A977RepresentanteProfissao, BC00307_n977RepresentanteProfissao, BC00307_A991RepresentanteMunicipio, BC00307_n991RepresentanteMunicipio
               }
               , new Object[] {
               BC00308_A978RepresentanteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC003010_A978RepresentanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003013_A999RepresentanteProfissaoDescricao, BC003013_n999RepresentanteProfissaoDescricao
               }
               , new Object[] {
               BC003014_A996RepresentanteMunicipioUF, BC003014_n996RepresentanteMunicipioUF, BC003014_A997RepresentanteMunicipioNome, BC003014_n997RepresentanteMunicipioNome
               }
               , new Object[] {
               BC003015_A978RepresentanteId, BC003015_A979RepresentanteNome, BC003015_n979RepresentanteNome, BC003015_A980RepresentanteRG, BC003015_n980RepresentanteRG, BC003015_A981RepresentanteOrgaoExpedidor, BC003015_n981RepresentanteOrgaoExpedidor, BC003015_A982RepresentanteRGUF, BC003015_n982RepresentanteRGUF, BC003015_A983RepresentanteCPF,
               BC003015_n983RepresentanteCPF, BC003015_A984RepresentanteEstadoCivil, BC003015_n984RepresentanteEstadoCivil, BC003015_A985RepresentanteNacionalidade, BC003015_n985RepresentanteNacionalidade, BC003015_A999RepresentanteProfissaoDescricao, BC003015_n999RepresentanteProfissaoDescricao, BC003015_A986RepresentanteEmail, BC003015_n986RepresentanteEmail, BC003015_A987RepresentanteCEP,
               BC003015_n987RepresentanteCEP, BC003015_A988RepresentanteLogradouro, BC003015_n988RepresentanteLogradouro, BC003015_A989RepresentanteBairro, BC003015_n989RepresentanteBairro, BC003015_A990RepresentanteCidade, BC003015_n990RepresentanteCidade, BC003015_A992RepresentanteLogradouroNumero, BC003015_n992RepresentanteLogradouroNumero, BC003015_A993RepresentanteComplemento,
               BC003015_n993RepresentanteComplemento, BC003015_A994RepresentanteDDD, BC003015_n994RepresentanteDDD, BC003015_A995RepresentanteNumero, BC003015_n995RepresentanteNumero, BC003015_A996RepresentanteMunicipioUF, BC003015_n996RepresentanteMunicipioUF, BC003015_A997RepresentanteMunicipioNome, BC003015_n997RepresentanteMunicipioNome, BC003015_A998RepresentanteTipo,
               BC003015_n998RepresentanteTipo, BC003015_A168ClienteId, BC003015_n168ClienteId, BC003015_A977RepresentanteProfissao, BC003015_n977RepresentanteProfissao, BC003015_A991RepresentanteMunicipio, BC003015_n991RepresentanteMunicipio
               }
            }
         );
         AV27Pgmname = "Representante_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12302 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z994RepresentanteDDD ;
      private short A994RepresentanteDDD ;
      private short RcdFound104 ;
      private int trnEnded ;
      private int Z978RepresentanteId ;
      private int A978RepresentanteId ;
      private int AV28GXV1 ;
      private int AV11Insert_RepresentanteProfissao ;
      private int AV13Insert_ClienteId ;
      private int Z995RepresentanteNumero ;
      private int A995RepresentanteNumero ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z977RepresentanteProfissao ;
      private int A977RepresentanteProfissao ;
      private long Z992RepresentanteLogradouroNumero ;
      private long A992RepresentanteLogradouroNumero ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV27Pgmname ;
      private string sMode104 ;
      private bool returnInSub ;
      private bool n979RepresentanteNome ;
      private bool n980RepresentanteRG ;
      private bool n981RepresentanteOrgaoExpedidor ;
      private bool n982RepresentanteRGUF ;
      private bool n983RepresentanteCPF ;
      private bool n984RepresentanteEstadoCivil ;
      private bool n985RepresentanteNacionalidade ;
      private bool n999RepresentanteProfissaoDescricao ;
      private bool n986RepresentanteEmail ;
      private bool n987RepresentanteCEP ;
      private bool n988RepresentanteLogradouro ;
      private bool n989RepresentanteBairro ;
      private bool n990RepresentanteCidade ;
      private bool n992RepresentanteLogradouroNumero ;
      private bool n993RepresentanteComplemento ;
      private bool n994RepresentanteDDD ;
      private bool n995RepresentanteNumero ;
      private bool n996RepresentanteMunicipioUF ;
      private bool n997RepresentanteMunicipioNome ;
      private bool n998RepresentanteTipo ;
      private bool n168ClienteId ;
      private bool n977RepresentanteProfissao ;
      private bool n991RepresentanteMunicipio ;
      private bool Gx_longc ;
      private string AV12Insert_RepresentanteMunicipio ;
      private string Z979RepresentanteNome ;
      private string A979RepresentanteNome ;
      private string Z980RepresentanteRG ;
      private string A980RepresentanteRG ;
      private string Z981RepresentanteOrgaoExpedidor ;
      private string A981RepresentanteOrgaoExpedidor ;
      private string Z982RepresentanteRGUF ;
      private string A982RepresentanteRGUF ;
      private string Z983RepresentanteCPF ;
      private string A983RepresentanteCPF ;
      private string Z984RepresentanteEstadoCivil ;
      private string A984RepresentanteEstadoCivil ;
      private string Z985RepresentanteNacionalidade ;
      private string A985RepresentanteNacionalidade ;
      private string Z986RepresentanteEmail ;
      private string A986RepresentanteEmail ;
      private string Z987RepresentanteCEP ;
      private string A987RepresentanteCEP ;
      private string Z988RepresentanteLogradouro ;
      private string A988RepresentanteLogradouro ;
      private string Z989RepresentanteBairro ;
      private string A989RepresentanteBairro ;
      private string Z990RepresentanteCidade ;
      private string A990RepresentanteCidade ;
      private string Z993RepresentanteComplemento ;
      private string A993RepresentanteComplemento ;
      private string Z998RepresentanteTipo ;
      private string A998RepresentanteTipo ;
      private string Z991RepresentanteMunicipio ;
      private string A991RepresentanteMunicipio ;
      private string Z999RepresentanteProfissaoDescricao ;
      private string A999RepresentanteProfissaoDescricao ;
      private string Z996RepresentanteMunicipioUF ;
      private string A996RepresentanteMunicipioUF ;
      private string Z997RepresentanteMunicipioNome ;
      private string A997RepresentanteMunicipioNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00307_A978RepresentanteId ;
      private string[] BC00307_A979RepresentanteNome ;
      private bool[] BC00307_n979RepresentanteNome ;
      private string[] BC00307_A980RepresentanteRG ;
      private bool[] BC00307_n980RepresentanteRG ;
      private string[] BC00307_A981RepresentanteOrgaoExpedidor ;
      private bool[] BC00307_n981RepresentanteOrgaoExpedidor ;
      private string[] BC00307_A982RepresentanteRGUF ;
      private bool[] BC00307_n982RepresentanteRGUF ;
      private string[] BC00307_A983RepresentanteCPF ;
      private bool[] BC00307_n983RepresentanteCPF ;
      private string[] BC00307_A984RepresentanteEstadoCivil ;
      private bool[] BC00307_n984RepresentanteEstadoCivil ;
      private string[] BC00307_A985RepresentanteNacionalidade ;
      private bool[] BC00307_n985RepresentanteNacionalidade ;
      private string[] BC00307_A999RepresentanteProfissaoDescricao ;
      private bool[] BC00307_n999RepresentanteProfissaoDescricao ;
      private string[] BC00307_A986RepresentanteEmail ;
      private bool[] BC00307_n986RepresentanteEmail ;
      private string[] BC00307_A987RepresentanteCEP ;
      private bool[] BC00307_n987RepresentanteCEP ;
      private string[] BC00307_A988RepresentanteLogradouro ;
      private bool[] BC00307_n988RepresentanteLogradouro ;
      private string[] BC00307_A989RepresentanteBairro ;
      private bool[] BC00307_n989RepresentanteBairro ;
      private string[] BC00307_A990RepresentanteCidade ;
      private bool[] BC00307_n990RepresentanteCidade ;
      private long[] BC00307_A992RepresentanteLogradouroNumero ;
      private bool[] BC00307_n992RepresentanteLogradouroNumero ;
      private string[] BC00307_A993RepresentanteComplemento ;
      private bool[] BC00307_n993RepresentanteComplemento ;
      private short[] BC00307_A994RepresentanteDDD ;
      private bool[] BC00307_n994RepresentanteDDD ;
      private int[] BC00307_A995RepresentanteNumero ;
      private bool[] BC00307_n995RepresentanteNumero ;
      private string[] BC00307_A996RepresentanteMunicipioUF ;
      private bool[] BC00307_n996RepresentanteMunicipioUF ;
      private string[] BC00307_A997RepresentanteMunicipioNome ;
      private bool[] BC00307_n997RepresentanteMunicipioNome ;
      private string[] BC00307_A998RepresentanteTipo ;
      private bool[] BC00307_n998RepresentanteTipo ;
      private int[] BC00307_A168ClienteId ;
      private bool[] BC00307_n168ClienteId ;
      private int[] BC00307_A977RepresentanteProfissao ;
      private bool[] BC00307_n977RepresentanteProfissao ;
      private string[] BC00307_A991RepresentanteMunicipio ;
      private bool[] BC00307_n991RepresentanteMunicipio ;
      private string[] BC00305_A999RepresentanteProfissaoDescricao ;
      private bool[] BC00305_n999RepresentanteProfissaoDescricao ;
      private string[] BC00306_A996RepresentanteMunicipioUF ;
      private bool[] BC00306_n996RepresentanteMunicipioUF ;
      private string[] BC00306_A997RepresentanteMunicipioNome ;
      private bool[] BC00306_n997RepresentanteMunicipioNome ;
      private int[] BC00304_A168ClienteId ;
      private bool[] BC00304_n168ClienteId ;
      private int[] BC00308_A978RepresentanteId ;
      private int[] BC00303_A978RepresentanteId ;
      private string[] BC00303_A979RepresentanteNome ;
      private bool[] BC00303_n979RepresentanteNome ;
      private string[] BC00303_A980RepresentanteRG ;
      private bool[] BC00303_n980RepresentanteRG ;
      private string[] BC00303_A981RepresentanteOrgaoExpedidor ;
      private bool[] BC00303_n981RepresentanteOrgaoExpedidor ;
      private string[] BC00303_A982RepresentanteRGUF ;
      private bool[] BC00303_n982RepresentanteRGUF ;
      private string[] BC00303_A983RepresentanteCPF ;
      private bool[] BC00303_n983RepresentanteCPF ;
      private string[] BC00303_A984RepresentanteEstadoCivil ;
      private bool[] BC00303_n984RepresentanteEstadoCivil ;
      private string[] BC00303_A985RepresentanteNacionalidade ;
      private bool[] BC00303_n985RepresentanteNacionalidade ;
      private string[] BC00303_A986RepresentanteEmail ;
      private bool[] BC00303_n986RepresentanteEmail ;
      private string[] BC00303_A987RepresentanteCEP ;
      private bool[] BC00303_n987RepresentanteCEP ;
      private string[] BC00303_A988RepresentanteLogradouro ;
      private bool[] BC00303_n988RepresentanteLogradouro ;
      private string[] BC00303_A989RepresentanteBairro ;
      private bool[] BC00303_n989RepresentanteBairro ;
      private string[] BC00303_A990RepresentanteCidade ;
      private bool[] BC00303_n990RepresentanteCidade ;
      private long[] BC00303_A992RepresentanteLogradouroNumero ;
      private bool[] BC00303_n992RepresentanteLogradouroNumero ;
      private string[] BC00303_A993RepresentanteComplemento ;
      private bool[] BC00303_n993RepresentanteComplemento ;
      private short[] BC00303_A994RepresentanteDDD ;
      private bool[] BC00303_n994RepresentanteDDD ;
      private int[] BC00303_A995RepresentanteNumero ;
      private bool[] BC00303_n995RepresentanteNumero ;
      private string[] BC00303_A998RepresentanteTipo ;
      private bool[] BC00303_n998RepresentanteTipo ;
      private int[] BC00303_A168ClienteId ;
      private bool[] BC00303_n168ClienteId ;
      private int[] BC00303_A977RepresentanteProfissao ;
      private bool[] BC00303_n977RepresentanteProfissao ;
      private string[] BC00303_A991RepresentanteMunicipio ;
      private bool[] BC00303_n991RepresentanteMunicipio ;
      private int[] BC00302_A978RepresentanteId ;
      private string[] BC00302_A979RepresentanteNome ;
      private bool[] BC00302_n979RepresentanteNome ;
      private string[] BC00302_A980RepresentanteRG ;
      private bool[] BC00302_n980RepresentanteRG ;
      private string[] BC00302_A981RepresentanteOrgaoExpedidor ;
      private bool[] BC00302_n981RepresentanteOrgaoExpedidor ;
      private string[] BC00302_A982RepresentanteRGUF ;
      private bool[] BC00302_n982RepresentanteRGUF ;
      private string[] BC00302_A983RepresentanteCPF ;
      private bool[] BC00302_n983RepresentanteCPF ;
      private string[] BC00302_A984RepresentanteEstadoCivil ;
      private bool[] BC00302_n984RepresentanteEstadoCivil ;
      private string[] BC00302_A985RepresentanteNacionalidade ;
      private bool[] BC00302_n985RepresentanteNacionalidade ;
      private string[] BC00302_A986RepresentanteEmail ;
      private bool[] BC00302_n986RepresentanteEmail ;
      private string[] BC00302_A987RepresentanteCEP ;
      private bool[] BC00302_n987RepresentanteCEP ;
      private string[] BC00302_A988RepresentanteLogradouro ;
      private bool[] BC00302_n988RepresentanteLogradouro ;
      private string[] BC00302_A989RepresentanteBairro ;
      private bool[] BC00302_n989RepresentanteBairro ;
      private string[] BC00302_A990RepresentanteCidade ;
      private bool[] BC00302_n990RepresentanteCidade ;
      private long[] BC00302_A992RepresentanteLogradouroNumero ;
      private bool[] BC00302_n992RepresentanteLogradouroNumero ;
      private string[] BC00302_A993RepresentanteComplemento ;
      private bool[] BC00302_n993RepresentanteComplemento ;
      private short[] BC00302_A994RepresentanteDDD ;
      private bool[] BC00302_n994RepresentanteDDD ;
      private int[] BC00302_A995RepresentanteNumero ;
      private bool[] BC00302_n995RepresentanteNumero ;
      private string[] BC00302_A998RepresentanteTipo ;
      private bool[] BC00302_n998RepresentanteTipo ;
      private int[] BC00302_A168ClienteId ;
      private bool[] BC00302_n168ClienteId ;
      private int[] BC00302_A977RepresentanteProfissao ;
      private bool[] BC00302_n977RepresentanteProfissao ;
      private string[] BC00302_A991RepresentanteMunicipio ;
      private bool[] BC00302_n991RepresentanteMunicipio ;
      private int[] BC003010_A978RepresentanteId ;
      private string[] BC003013_A999RepresentanteProfissaoDescricao ;
      private bool[] BC003013_n999RepresentanteProfissaoDescricao ;
      private string[] BC003014_A996RepresentanteMunicipioUF ;
      private bool[] BC003014_n996RepresentanteMunicipioUF ;
      private string[] BC003014_A997RepresentanteMunicipioNome ;
      private bool[] BC003014_n997RepresentanteMunicipioNome ;
      private int[] BC003015_A978RepresentanteId ;
      private string[] BC003015_A979RepresentanteNome ;
      private bool[] BC003015_n979RepresentanteNome ;
      private string[] BC003015_A980RepresentanteRG ;
      private bool[] BC003015_n980RepresentanteRG ;
      private string[] BC003015_A981RepresentanteOrgaoExpedidor ;
      private bool[] BC003015_n981RepresentanteOrgaoExpedidor ;
      private string[] BC003015_A982RepresentanteRGUF ;
      private bool[] BC003015_n982RepresentanteRGUF ;
      private string[] BC003015_A983RepresentanteCPF ;
      private bool[] BC003015_n983RepresentanteCPF ;
      private string[] BC003015_A984RepresentanteEstadoCivil ;
      private bool[] BC003015_n984RepresentanteEstadoCivil ;
      private string[] BC003015_A985RepresentanteNacionalidade ;
      private bool[] BC003015_n985RepresentanteNacionalidade ;
      private string[] BC003015_A999RepresentanteProfissaoDescricao ;
      private bool[] BC003015_n999RepresentanteProfissaoDescricao ;
      private string[] BC003015_A986RepresentanteEmail ;
      private bool[] BC003015_n986RepresentanteEmail ;
      private string[] BC003015_A987RepresentanteCEP ;
      private bool[] BC003015_n987RepresentanteCEP ;
      private string[] BC003015_A988RepresentanteLogradouro ;
      private bool[] BC003015_n988RepresentanteLogradouro ;
      private string[] BC003015_A989RepresentanteBairro ;
      private bool[] BC003015_n989RepresentanteBairro ;
      private string[] BC003015_A990RepresentanteCidade ;
      private bool[] BC003015_n990RepresentanteCidade ;
      private long[] BC003015_A992RepresentanteLogradouroNumero ;
      private bool[] BC003015_n992RepresentanteLogradouroNumero ;
      private string[] BC003015_A993RepresentanteComplemento ;
      private bool[] BC003015_n993RepresentanteComplemento ;
      private short[] BC003015_A994RepresentanteDDD ;
      private bool[] BC003015_n994RepresentanteDDD ;
      private int[] BC003015_A995RepresentanteNumero ;
      private bool[] BC003015_n995RepresentanteNumero ;
      private string[] BC003015_A996RepresentanteMunicipioUF ;
      private bool[] BC003015_n996RepresentanteMunicipioUF ;
      private string[] BC003015_A997RepresentanteMunicipioNome ;
      private bool[] BC003015_n997RepresentanteMunicipioNome ;
      private string[] BC003015_A998RepresentanteTipo ;
      private bool[] BC003015_n998RepresentanteTipo ;
      private int[] BC003015_A168ClienteId ;
      private bool[] BC003015_n168ClienteId ;
      private int[] BC003015_A977RepresentanteProfissao ;
      private bool[] BC003015_n977RepresentanteProfissao ;
      private string[] BC003015_A991RepresentanteMunicipio ;
      private bool[] BC003015_n991RepresentanteMunicipio ;
      private SdtRepresentante bcRepresentante ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class representante_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00302;
          prmBC00302 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00303;
          prmBC00303 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00304;
          prmBC00304 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00305;
          prmBC00305 = new Object[] {
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00306;
          prmBC00306 = new Object[] {
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC00307;
          prmBC00307 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00308;
          prmBC00308 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC00309;
          prmBC00309 = new Object[] {
          new ParDef("RepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteRG",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteOrgaoExpedidor",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteRGUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteNacionalidade",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("RepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("RepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("RepresentanteNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC003010;
          prmBC003010 = new Object[] {
          };
          Object[] prmBC003011;
          prmBC003011 = new Object[] {
          new ParDef("RepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteRG",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteOrgaoExpedidor",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteRGUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteNacionalidade",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("RepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("RepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("RepresentanteDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("RepresentanteNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC003012;
          prmBC003012 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmBC003013;
          prmBC003013 = new Object[] {
          new ParDef("RepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003014;
          prmBC003014 = new Object[] {
          new ParDef("RepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC003015;
          prmBC003015 = new Object[] {
          new ParDef("RepresentanteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00302", "SELECT RepresentanteId, RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio FROM Representante WHERE RepresentanteId = :RepresentanteId  FOR UPDATE OF Representante",true, GxErrorMask.GX_NOMASK, false, this,prmBC00302,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00303", "SELECT RepresentanteId, RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio FROM Representante WHERE RepresentanteId = :RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00303,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00304", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00304,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00305", "SELECT ProfissaoNome AS RepresentanteProfissaoDescricao FROM Profissao WHERE ProfissaoId = :RepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00305,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00306", "SELECT MunicipioUF AS RepresentanteMunicipioUF, MunicipioNome AS RepresentanteMunicipioNome FROM Municipio WHERE MunicipioCodigo = :RepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00306,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00307", "SELECT TM1.RepresentanteId, TM1.RepresentanteNome, TM1.RepresentanteRG, TM1.RepresentanteOrgaoExpedidor, TM1.RepresentanteRGUF, TM1.RepresentanteCPF, TM1.RepresentanteEstadoCivil, TM1.RepresentanteNacionalidade, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, TM1.RepresentanteEmail, TM1.RepresentanteCEP, TM1.RepresentanteLogradouro, TM1.RepresentanteBairro, TM1.RepresentanteCidade, TM1.RepresentanteLogradouroNumero, TM1.RepresentanteComplemento, TM1.RepresentanteDDD, TM1.RepresentanteNumero, T3.MunicipioUF AS RepresentanteMunicipioUF, T3.MunicipioNome AS RepresentanteMunicipioNome, TM1.RepresentanteTipo, TM1.ClienteId, TM1.RepresentanteProfissao AS RepresentanteProfissao, TM1.RepresentanteMunicipio AS RepresentanteMunicipio FROM ((Representante TM1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = TM1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.RepresentanteMunicipio) WHERE TM1.RepresentanteId = :RepresentanteId ORDER BY TM1.RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00307,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00308", "SELECT RepresentanteId FROM Representante WHERE RepresentanteId = :RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00308,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00309", "SAVEPOINT gxupdate;INSERT INTO Representante(RepresentanteNome, RepresentanteRG, RepresentanteOrgaoExpedidor, RepresentanteRGUF, RepresentanteCPF, RepresentanteEstadoCivil, RepresentanteNacionalidade, RepresentanteEmail, RepresentanteCEP, RepresentanteLogradouro, RepresentanteBairro, RepresentanteCidade, RepresentanteLogradouroNumero, RepresentanteComplemento, RepresentanteDDD, RepresentanteNumero, RepresentanteTipo, ClienteId, RepresentanteProfissao, RepresentanteMunicipio) VALUES(:RepresentanteNome, :RepresentanteRG, :RepresentanteOrgaoExpedidor, :RepresentanteRGUF, :RepresentanteCPF, :RepresentanteEstadoCivil, :RepresentanteNacionalidade, :RepresentanteEmail, :RepresentanteCEP, :RepresentanteLogradouro, :RepresentanteBairro, :RepresentanteCidade, :RepresentanteLogradouroNumero, :RepresentanteComplemento, :RepresentanteDDD, :RepresentanteNumero, :RepresentanteTipo, :ClienteId, :RepresentanteProfissao, :RepresentanteMunicipio);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00309)
             ,new CursorDef("BC003010", "SELECT currval('RepresentanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003010,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003011", "SAVEPOINT gxupdate;UPDATE Representante SET RepresentanteNome=:RepresentanteNome, RepresentanteRG=:RepresentanteRG, RepresentanteOrgaoExpedidor=:RepresentanteOrgaoExpedidor, RepresentanteRGUF=:RepresentanteRGUF, RepresentanteCPF=:RepresentanteCPF, RepresentanteEstadoCivil=:RepresentanteEstadoCivil, RepresentanteNacionalidade=:RepresentanteNacionalidade, RepresentanteEmail=:RepresentanteEmail, RepresentanteCEP=:RepresentanteCEP, RepresentanteLogradouro=:RepresentanteLogradouro, RepresentanteBairro=:RepresentanteBairro, RepresentanteCidade=:RepresentanteCidade, RepresentanteLogradouroNumero=:RepresentanteLogradouroNumero, RepresentanteComplemento=:RepresentanteComplemento, RepresentanteDDD=:RepresentanteDDD, RepresentanteNumero=:RepresentanteNumero, RepresentanteTipo=:RepresentanteTipo, ClienteId=:ClienteId, RepresentanteProfissao=:RepresentanteProfissao, RepresentanteMunicipio=:RepresentanteMunicipio  WHERE RepresentanteId = :RepresentanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003011)
             ,new CursorDef("BC003012", "SAVEPOINT gxupdate;DELETE FROM Representante  WHERE RepresentanteId = :RepresentanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003012)
             ,new CursorDef("BC003013", "SELECT ProfissaoNome AS RepresentanteProfissaoDescricao FROM Profissao WHERE ProfissaoId = :RepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003014", "SELECT MunicipioUF AS RepresentanteMunicipioUF, MunicipioNome AS RepresentanteMunicipioNome FROM Municipio WHERE MunicipioCodigo = :RepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003015", "SELECT TM1.RepresentanteId, TM1.RepresentanteNome, TM1.RepresentanteRG, TM1.RepresentanteOrgaoExpedidor, TM1.RepresentanteRGUF, TM1.RepresentanteCPF, TM1.RepresentanteEstadoCivil, TM1.RepresentanteNacionalidade, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, TM1.RepresentanteEmail, TM1.RepresentanteCEP, TM1.RepresentanteLogradouro, TM1.RepresentanteBairro, TM1.RepresentanteCidade, TM1.RepresentanteLogradouroNumero, TM1.RepresentanteComplemento, TM1.RepresentanteDDD, TM1.RepresentanteNumero, T3.MunicipioUF AS RepresentanteMunicipioUF, T3.MunicipioNome AS RepresentanteMunicipioNome, TM1.RepresentanteTipo, TM1.ClienteId, TM1.RepresentanteProfissao AS RepresentanteProfissao, TM1.RepresentanteMunicipio AS RepresentanteMunicipio FROM ((Representante TM1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = TM1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.RepresentanteMunicipio) WHERE TM1.RepresentanteId = :RepresentanteId ORDER BY TM1.RepresentanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003015,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((long[]) buf[27])[0] = rslt.getLong(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
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
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((long[]) buf[27])[0] = rslt.getLong(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                return;
       }
    }

 }

}
