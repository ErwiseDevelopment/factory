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
   public class empresa_bc : GxSilentTrn, IGxSilentTrn
   {
      public empresa_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public empresa_bc( IGxContext context )
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
         ReadRow1342( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1342( ) ;
         standaloneModal( ) ;
         AddRow1342( ) ;
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
            E11132 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z249EmpresaId = A249EmpresaId;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1342( ) ;
            }
            else
            {
               CheckExtendedTable1342( ) ;
               if ( AnyError == 0 )
               {
                  ZM1342( 7) ;
                  ZM1342( 8) ;
                  ZM1342( 9) ;
                  ZM1342( 10) ;
               }
               CloseExtendedTableCursors1342( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12132( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaBancoId") == 0 )
               {
                  AV11Insert_EmpresaBancoId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "MunicipioCodigo") == 0 )
               {
                  AV13Insert_MunicipioCodigo = AV12TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaRepresentanteMunicipio") == 0 )
               {
                  AV14Insert_EmpresaRepresentanteMunicipio = AV12TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmpresaRepresentanteProfissao") == 0 )
               {
                  AV15Insert_EmpresaRepresentanteProfissao = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
         }
      }

      protected void E11132( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1342( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z250EmpresaNomeFantasia = A250EmpresaNomeFantasia;
            Z251EmpresaRazaoSocial = A251EmpresaRazaoSocial;
            Z252EmpresaCNPJ = A252EmpresaCNPJ;
            Z253EmpresaSede = A253EmpresaSede;
            Z465EmpresaAgencia = A465EmpresaAgencia;
            Z466EmpresaAgenciaDigito = A466EmpresaAgenciaDigito;
            Z467EmpresaConta = A467EmpresaConta;
            Z468EmpresaPix = A468EmpresaPix;
            Z469EmpresaPixTipo = A469EmpresaPixTipo;
            Z470EmpresaEmail = A470EmpresaEmail;
            Z610EmpresaLogradouro = A610EmpresaLogradouro;
            Z611EmpresaLogradouroNumero = A611EmpresaLogradouroNumero;
            Z609EmpresaCEP = A609EmpresaCEP;
            Z612EmpresaBairro = A612EmpresaBairro;
            Z613EmpresaComplemento = A613EmpresaComplemento;
            Z770EmpresaRepresentanteCPF = A770EmpresaRepresentanteCPF;
            Z771EmpresaRepresentanteNome = A771EmpresaRepresentanteNome;
            Z772EmpresaRepresentanteEmail = A772EmpresaRepresentanteEmail;
            Z773EmpresaUtilizaRepresentanteAssinatura = A773EmpresaUtilizaRepresentanteAssinatura;
            Z928EmpresaRepresentanteLogradouro = A928EmpresaRepresentanteLogradouro;
            Z929EmpresaRepresentanteNumero = A929EmpresaRepresentanteNumero;
            Z930EmpresaRepresentanteCEP = A930EmpresaRepresentanteCEP;
            Z931EmpresaRepresentanteBairro = A931EmpresaRepresentanteBairro;
            Z932EmpresaRepresentanteComplemento = A932EmpresaRepresentanteComplemento;
            Z933EmpresaRepresentanteNacionalidade = A933EmpresaRepresentanteNacionalidade;
            Z934EmpresaRepresentanteTelefone = A934EmpresaRepresentanteTelefone;
            Z935EmpresaRepresentanteTelefoneDDD = A935EmpresaRepresentanteTelefoneDDD;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z925EmpresaRepresentanteMunicipio = A925EmpresaRepresentanteMunicipio;
            Z464EmpresaBancoId = A464EmpresaBancoId;
            Z924EmpresaRepresentanteProfissao = A924EmpresaRepresentanteProfissao;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z926EmpresaRepresentanteMunicipioNome = A926EmpresaRepresentanteMunicipioNome;
            Z927EmpresaRepresentanteMunicipioUF = A927EmpresaRepresentanteMunicipioUF;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z403BancoNome = A403BancoNome;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -6 )
         {
            Z249EmpresaId = A249EmpresaId;
            Z250EmpresaNomeFantasia = A250EmpresaNomeFantasia;
            Z251EmpresaRazaoSocial = A251EmpresaRazaoSocial;
            Z252EmpresaCNPJ = A252EmpresaCNPJ;
            Z253EmpresaSede = A253EmpresaSede;
            Z465EmpresaAgencia = A465EmpresaAgencia;
            Z466EmpresaAgenciaDigito = A466EmpresaAgenciaDigito;
            Z467EmpresaConta = A467EmpresaConta;
            Z468EmpresaPix = A468EmpresaPix;
            Z469EmpresaPixTipo = A469EmpresaPixTipo;
            Z470EmpresaEmail = A470EmpresaEmail;
            Z610EmpresaLogradouro = A610EmpresaLogradouro;
            Z611EmpresaLogradouroNumero = A611EmpresaLogradouroNumero;
            Z609EmpresaCEP = A609EmpresaCEP;
            Z612EmpresaBairro = A612EmpresaBairro;
            Z613EmpresaComplemento = A613EmpresaComplemento;
            Z770EmpresaRepresentanteCPF = A770EmpresaRepresentanteCPF;
            Z771EmpresaRepresentanteNome = A771EmpresaRepresentanteNome;
            Z772EmpresaRepresentanteEmail = A772EmpresaRepresentanteEmail;
            Z773EmpresaUtilizaRepresentanteAssinatura = A773EmpresaUtilizaRepresentanteAssinatura;
            Z928EmpresaRepresentanteLogradouro = A928EmpresaRepresentanteLogradouro;
            Z929EmpresaRepresentanteNumero = A929EmpresaRepresentanteNumero;
            Z930EmpresaRepresentanteCEP = A930EmpresaRepresentanteCEP;
            Z931EmpresaRepresentanteBairro = A931EmpresaRepresentanteBairro;
            Z932EmpresaRepresentanteComplemento = A932EmpresaRepresentanteComplemento;
            Z933EmpresaRepresentanteNacionalidade = A933EmpresaRepresentanteNacionalidade;
            Z934EmpresaRepresentanteTelefone = A934EmpresaRepresentanteTelefone;
            Z935EmpresaRepresentanteTelefoneDDD = A935EmpresaRepresentanteTelefoneDDD;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z925EmpresaRepresentanteMunicipio = A925EmpresaRepresentanteMunicipio;
            Z464EmpresaBancoId = A464EmpresaBancoId;
            Z924EmpresaRepresentanteProfissao = A924EmpresaRepresentanteProfissao;
            Z403BancoNome = A403BancoNome;
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
            Z926EmpresaRepresentanteMunicipioNome = A926EmpresaRepresentanteMunicipioNome;
            Z927EmpresaRepresentanteMunicipioUF = A927EmpresaRepresentanteMunicipioUF;
         }
      }

      protected void standaloneNotModal( )
      {
         AV16Pgmname = "Empresa_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1342( )
      {
         /* Using cursor BC00138 */
         pr_default.execute(6, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound42 = 1;
            A250EmpresaNomeFantasia = BC00138_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = BC00138_n250EmpresaNomeFantasia[0];
            A251EmpresaRazaoSocial = BC00138_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = BC00138_n251EmpresaRazaoSocial[0];
            A252EmpresaCNPJ = BC00138_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = BC00138_n252EmpresaCNPJ[0];
            A253EmpresaSede = BC00138_A253EmpresaSede[0];
            n253EmpresaSede = BC00138_n253EmpresaSede[0];
            A403BancoNome = BC00138_A403BancoNome[0];
            n403BancoNome = BC00138_n403BancoNome[0];
            A465EmpresaAgencia = BC00138_A465EmpresaAgencia[0];
            n465EmpresaAgencia = BC00138_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = BC00138_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = BC00138_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = BC00138_A467EmpresaConta[0];
            n467EmpresaConta = BC00138_n467EmpresaConta[0];
            A468EmpresaPix = BC00138_A468EmpresaPix[0];
            n468EmpresaPix = BC00138_n468EmpresaPix[0];
            A469EmpresaPixTipo = BC00138_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = BC00138_n469EmpresaPixTipo[0];
            A470EmpresaEmail = BC00138_A470EmpresaEmail[0];
            n470EmpresaEmail = BC00138_n470EmpresaEmail[0];
            A610EmpresaLogradouro = BC00138_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = BC00138_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = BC00138_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = BC00138_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = BC00138_A609EmpresaCEP[0];
            n609EmpresaCEP = BC00138_n609EmpresaCEP[0];
            A612EmpresaBairro = BC00138_A612EmpresaBairro[0];
            n612EmpresaBairro = BC00138_n612EmpresaBairro[0];
            A613EmpresaComplemento = BC00138_A613EmpresaComplemento[0];
            n613EmpresaComplemento = BC00138_n613EmpresaComplemento[0];
            A187MunicipioNome = BC00138_A187MunicipioNome[0];
            n187MunicipioNome = BC00138_n187MunicipioNome[0];
            A189MunicipioUF = BC00138_A189MunicipioUF[0];
            n189MunicipioUF = BC00138_n189MunicipioUF[0];
            A770EmpresaRepresentanteCPF = BC00138_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = BC00138_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = BC00138_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = BC00138_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = BC00138_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = BC00138_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = BC00138_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = BC00138_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = BC00138_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = BC00138_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = BC00138_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = BC00138_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = BC00138_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = BC00138_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = BC00138_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = BC00138_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = BC00138_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = BC00138_n932EmpresaRepresentanteComplemento[0];
            A926EmpresaRepresentanteMunicipioNome = BC00138_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = BC00138_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = BC00138_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = BC00138_n927EmpresaRepresentanteMunicipioUF[0];
            A933EmpresaRepresentanteNacionalidade = BC00138_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = BC00138_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = BC00138_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = BC00138_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = BC00138_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = BC00138_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = BC00138_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC00138_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = BC00138_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = BC00138_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = BC00138_A464EmpresaBancoId[0];
            n464EmpresaBancoId = BC00138_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = BC00138_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = BC00138_n924EmpresaRepresentanteProfissao[0];
            ZM1342( -6) ;
         }
         pr_default.close(6);
         OnLoadActions1342( ) ;
      }

      protected void OnLoadActions1342( )
      {
      }

      protected void CheckExtendedTable1342( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00136 */
         pr_default.execute(4, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A464EmpresaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Banco'.", "ForeignKeyNotFound", 1, "EMPRESABANCOID");
               AnyError = 1;
            }
         }
         A403BancoNome = BC00136_A403BancoNome[0];
         n403BancoNome = BC00136_n403BancoNome[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A469EmpresaPixTipo, "CPF") == 0 ) || ( StringUtil.StrCmp(A469EmpresaPixTipo, "CNPJ") == 0 ) || ( StringUtil.StrCmp(A469EmpresaPixTipo, "Telefone") == 0 ) || ( StringUtil.StrCmp(A469EmpresaPixTipo, "Email") == 0 ) || ( StringUtil.StrCmp(A469EmpresaPixTipo, "ChaveAleatoria") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A469EmpresaPixTipo)) ) )
         {
            GX_msglist.addItem("Campo Empresa Pix Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A470EmpresaEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A470EmpresaEmail)) ) )
         {
            GX_msglist.addItem("O valor de Empresa Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00134 */
         pr_default.execute(2, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
            }
         }
         A187MunicipioNome = BC00134_A187MunicipioNome[0];
         n187MunicipioNome = BC00134_n187MunicipioNome[0];
         A189MunicipioUF = BC00134_A189MunicipioUF[0];
         n189MunicipioUF = BC00134_n189MunicipioUF[0];
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A772EmpresaRepresentanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A772EmpresaRepresentanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Empresa Representante Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00135 */
         pr_default.execute(3, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A925EmpresaRepresentanteMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Municipio'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEMUNICIPIO");
               AnyError = 1;
            }
         }
         A926EmpresaRepresentanteMunicipioNome = BC00135_A926EmpresaRepresentanteMunicipioNome[0];
         n926EmpresaRepresentanteMunicipioNome = BC00135_n926EmpresaRepresentanteMunicipioNome[0];
         A927EmpresaRepresentanteMunicipioUF = BC00135_A927EmpresaRepresentanteMunicipioUF[0];
         n927EmpresaRepresentanteMunicipioUF = BC00135_n927EmpresaRepresentanteMunicipioUF[0];
         pr_default.close(3);
         /* Using cursor BC00137 */
         pr_default.execute(5, new Object[] {n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A924EmpresaRepresentanteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Empresa Representante Profissao'.", "ForeignKeyNotFound", 1, "EMPRESAREPRESENTANTEPROFISSAO");
               AnyError = 1;
            }
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1342( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1342( )
      {
         /* Using cursor BC00139 */
         pr_default.execute(7, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00133 */
         pr_default.execute(1, new Object[] {A249EmpresaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1342( 6) ;
            RcdFound42 = 1;
            A249EmpresaId = BC00133_A249EmpresaId[0];
            A250EmpresaNomeFantasia = BC00133_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = BC00133_n250EmpresaNomeFantasia[0];
            A251EmpresaRazaoSocial = BC00133_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = BC00133_n251EmpresaRazaoSocial[0];
            A252EmpresaCNPJ = BC00133_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = BC00133_n252EmpresaCNPJ[0];
            A253EmpresaSede = BC00133_A253EmpresaSede[0];
            n253EmpresaSede = BC00133_n253EmpresaSede[0];
            A465EmpresaAgencia = BC00133_A465EmpresaAgencia[0];
            n465EmpresaAgencia = BC00133_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = BC00133_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = BC00133_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = BC00133_A467EmpresaConta[0];
            n467EmpresaConta = BC00133_n467EmpresaConta[0];
            A468EmpresaPix = BC00133_A468EmpresaPix[0];
            n468EmpresaPix = BC00133_n468EmpresaPix[0];
            A469EmpresaPixTipo = BC00133_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = BC00133_n469EmpresaPixTipo[0];
            A470EmpresaEmail = BC00133_A470EmpresaEmail[0];
            n470EmpresaEmail = BC00133_n470EmpresaEmail[0];
            A610EmpresaLogradouro = BC00133_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = BC00133_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = BC00133_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = BC00133_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = BC00133_A609EmpresaCEP[0];
            n609EmpresaCEP = BC00133_n609EmpresaCEP[0];
            A612EmpresaBairro = BC00133_A612EmpresaBairro[0];
            n612EmpresaBairro = BC00133_n612EmpresaBairro[0];
            A613EmpresaComplemento = BC00133_A613EmpresaComplemento[0];
            n613EmpresaComplemento = BC00133_n613EmpresaComplemento[0];
            A770EmpresaRepresentanteCPF = BC00133_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = BC00133_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = BC00133_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = BC00133_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = BC00133_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = BC00133_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = BC00133_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = BC00133_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = BC00133_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = BC00133_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = BC00133_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = BC00133_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = BC00133_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = BC00133_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = BC00133_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = BC00133_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = BC00133_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = BC00133_n932EmpresaRepresentanteComplemento[0];
            A933EmpresaRepresentanteNacionalidade = BC00133_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = BC00133_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = BC00133_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = BC00133_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = BC00133_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = BC00133_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = BC00133_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC00133_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = BC00133_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = BC00133_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = BC00133_A464EmpresaBancoId[0];
            n464EmpresaBancoId = BC00133_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = BC00133_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = BC00133_n924EmpresaRepresentanteProfissao[0];
            Z249EmpresaId = A249EmpresaId;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1342( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1342( ) ;
            }
            Gx_mode = sMode42;
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1342( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode42;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1342( ) ;
         if ( RcdFound42 == 0 )
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
         CONFIRM_130( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1342( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00132 */
            pr_default.execute(0, new Object[] {A249EmpresaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empresa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250EmpresaNomeFantasia, BC00132_A250EmpresaNomeFantasia[0]) != 0 ) || ( StringUtil.StrCmp(Z251EmpresaRazaoSocial, BC00132_A251EmpresaRazaoSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z252EmpresaCNPJ, BC00132_A252EmpresaCNPJ[0]) != 0 ) || ( Z253EmpresaSede != BC00132_A253EmpresaSede[0] ) || ( Z465EmpresaAgencia != BC00132_A465EmpresaAgencia[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z466EmpresaAgenciaDigito != BC00132_A466EmpresaAgenciaDigito[0] ) || ( Z467EmpresaConta != BC00132_A467EmpresaConta[0] ) || ( StringUtil.StrCmp(Z468EmpresaPix, BC00132_A468EmpresaPix[0]) != 0 ) || ( StringUtil.StrCmp(Z469EmpresaPixTipo, BC00132_A469EmpresaPixTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z470EmpresaEmail, BC00132_A470EmpresaEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z610EmpresaLogradouro, BC00132_A610EmpresaLogradouro[0]) != 0 ) || ( Z611EmpresaLogradouroNumero != BC00132_A611EmpresaLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z609EmpresaCEP, BC00132_A609EmpresaCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z612EmpresaBairro, BC00132_A612EmpresaBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z613EmpresaComplemento, BC00132_A613EmpresaComplemento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z770EmpresaRepresentanteCPF, BC00132_A770EmpresaRepresentanteCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z771EmpresaRepresentanteNome, BC00132_A771EmpresaRepresentanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z772EmpresaRepresentanteEmail, BC00132_A772EmpresaRepresentanteEmail[0]) != 0 ) || ( Z773EmpresaUtilizaRepresentanteAssinatura != BC00132_A773EmpresaUtilizaRepresentanteAssinatura[0] ) || ( StringUtil.StrCmp(Z928EmpresaRepresentanteLogradouro, BC00132_A928EmpresaRepresentanteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z929EmpresaRepresentanteNumero != BC00132_A929EmpresaRepresentanteNumero[0] ) || ( StringUtil.StrCmp(Z930EmpresaRepresentanteCEP, BC00132_A930EmpresaRepresentanteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z931EmpresaRepresentanteBairro, BC00132_A931EmpresaRepresentanteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z932EmpresaRepresentanteComplemento, BC00132_A932EmpresaRepresentanteComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z933EmpresaRepresentanteNacionalidade, BC00132_A933EmpresaRepresentanteNacionalidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z934EmpresaRepresentanteTelefone != BC00132_A934EmpresaRepresentanteTelefone[0] ) || ( Z935EmpresaRepresentanteTelefoneDDD != BC00132_A935EmpresaRepresentanteTelefoneDDD[0] ) || ( StringUtil.StrCmp(Z186MunicipioCodigo, BC00132_A186MunicipioCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z925EmpresaRepresentanteMunicipio, BC00132_A925EmpresaRepresentanteMunicipio[0]) != 0 ) || ( Z464EmpresaBancoId != BC00132_A464EmpresaBancoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z924EmpresaRepresentanteProfissao != BC00132_A924EmpresaRepresentanteProfissao[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Empresa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1342( 0) ;
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001310 */
                     pr_default.execute(8, new Object[] {n250EmpresaNomeFantasia, A250EmpresaNomeFantasia, n251EmpresaRazaoSocial, A251EmpresaRazaoSocial, n252EmpresaCNPJ, A252EmpresaCNPJ, n253EmpresaSede, A253EmpresaSede, n465EmpresaAgencia, A465EmpresaAgencia, n466EmpresaAgenciaDigito, A466EmpresaAgenciaDigito, n467EmpresaConta, A467EmpresaConta, n468EmpresaPix, A468EmpresaPix, n469EmpresaPixTipo, A469EmpresaPixTipo, n470EmpresaEmail, A470EmpresaEmail, n610EmpresaLogradouro, A610EmpresaLogradouro, n611EmpresaLogradouroNumero, A611EmpresaLogradouroNumero, n609EmpresaCEP, A609EmpresaCEP, n612EmpresaBairro, A612EmpresaBairro, n613EmpresaComplemento, A613EmpresaComplemento, n770EmpresaRepresentanteCPF, A770EmpresaRepresentanteCPF, n771EmpresaRepresentanteNome, A771EmpresaRepresentanteNome, n772EmpresaRepresentanteEmail, A772EmpresaRepresentanteEmail, n773EmpresaUtilizaRepresentanteAssinatura, A773EmpresaUtilizaRepresentanteAssinatura, n928EmpresaRepresentanteLogradouro, A928EmpresaRepresentanteLogradouro, n929EmpresaRepresentanteNumero, A929EmpresaRepresentanteNumero, n930EmpresaRepresentanteCEP, A930EmpresaRepresentanteCEP, n931EmpresaRepresentanteBairro, A931EmpresaRepresentanteBairro, n932EmpresaRepresentanteComplemento, A932EmpresaRepresentanteComplemento, n933EmpresaRepresentanteNacionalidade, A933EmpresaRepresentanteNacionalidade, n934EmpresaRepresentanteTelefone, A934EmpresaRepresentanteTelefone, n935EmpresaRepresentanteTelefoneDDD, A935EmpresaRepresentanteTelefoneDDD, n186MunicipioCodigo, A186MunicipioCodigo, n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio, n464EmpresaBancoId, A464EmpresaBancoId, n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001311 */
                     pr_default.execute(9);
                     A249EmpresaId = BC001311_A249EmpresaId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Empresa");
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
               Load1342( ) ;
            }
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void Update1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001312 */
                     pr_default.execute(10, new Object[] {n250EmpresaNomeFantasia, A250EmpresaNomeFantasia, n251EmpresaRazaoSocial, A251EmpresaRazaoSocial, n252EmpresaCNPJ, A252EmpresaCNPJ, n253EmpresaSede, A253EmpresaSede, n465EmpresaAgencia, A465EmpresaAgencia, n466EmpresaAgenciaDigito, A466EmpresaAgenciaDigito, n467EmpresaConta, A467EmpresaConta, n468EmpresaPix, A468EmpresaPix, n469EmpresaPixTipo, A469EmpresaPixTipo, n470EmpresaEmail, A470EmpresaEmail, n610EmpresaLogradouro, A610EmpresaLogradouro, n611EmpresaLogradouroNumero, A611EmpresaLogradouroNumero, n609EmpresaCEP, A609EmpresaCEP, n612EmpresaBairro, A612EmpresaBairro, n613EmpresaComplemento, A613EmpresaComplemento, n770EmpresaRepresentanteCPF, A770EmpresaRepresentanteCPF, n771EmpresaRepresentanteNome, A771EmpresaRepresentanteNome, n772EmpresaRepresentanteEmail, A772EmpresaRepresentanteEmail, n773EmpresaUtilizaRepresentanteAssinatura, A773EmpresaUtilizaRepresentanteAssinatura, n928EmpresaRepresentanteLogradouro, A928EmpresaRepresentanteLogradouro, n929EmpresaRepresentanteNumero, A929EmpresaRepresentanteNumero, n930EmpresaRepresentanteCEP, A930EmpresaRepresentanteCEP, n931EmpresaRepresentanteBairro, A931EmpresaRepresentanteBairro, n932EmpresaRepresentanteComplemento, A932EmpresaRepresentanteComplemento, n933EmpresaRepresentanteNacionalidade, A933EmpresaRepresentanteNacionalidade, n934EmpresaRepresentanteTelefone, A934EmpresaRepresentanteTelefone, n935EmpresaRepresentanteTelefoneDDD, A935EmpresaRepresentanteTelefoneDDD, n186MunicipioCodigo, A186MunicipioCodigo, n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio, n464EmpresaBancoId, A464EmpresaBancoId, n924EmpresaRepresentanteProfissao, A924EmpresaRepresentanteProfissao, A249EmpresaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Empresa");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empresa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1342( ) ;
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
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void DeferredUpdate1342( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1342( ) ;
            AfterConfirm1342( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1342( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001313 */
                  pr_default.execute(11, new Object[] {A249EmpresaId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Empresa");
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1342( ) ;
         Gx_mode = sMode42;
      }

      protected void OnDeleteControls1342( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001314 */
            pr_default.execute(12, new Object[] {n464EmpresaBancoId, A464EmpresaBancoId});
            A403BancoNome = BC001314_A403BancoNome[0];
            n403BancoNome = BC001314_n403BancoNome[0];
            pr_default.close(12);
            /* Using cursor BC001315 */
            pr_default.execute(13, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            A187MunicipioNome = BC001315_A187MunicipioNome[0];
            n187MunicipioNome = BC001315_n187MunicipioNome[0];
            A189MunicipioUF = BC001315_A189MunicipioUF[0];
            n189MunicipioUF = BC001315_n189MunicipioUF[0];
            pr_default.close(13);
            /* Using cursor BC001316 */
            pr_default.execute(14, new Object[] {n925EmpresaRepresentanteMunicipio, A925EmpresaRepresentanteMunicipio});
            A926EmpresaRepresentanteMunicipioNome = BC001316_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = BC001316_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = BC001316_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = BC001316_n927EmpresaRepresentanteMunicipioUF[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel1342( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1342( ) ;
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

      public void ScanKeyStart1342( )
      {
         /* Scan By routine */
         /* Using cursor BC001317 */
         pr_default.execute(15, new Object[] {A249EmpresaId});
         RcdFound42 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound42 = 1;
            A249EmpresaId = BC001317_A249EmpresaId[0];
            A250EmpresaNomeFantasia = BC001317_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = BC001317_n250EmpresaNomeFantasia[0];
            A251EmpresaRazaoSocial = BC001317_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = BC001317_n251EmpresaRazaoSocial[0];
            A252EmpresaCNPJ = BC001317_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = BC001317_n252EmpresaCNPJ[0];
            A253EmpresaSede = BC001317_A253EmpresaSede[0];
            n253EmpresaSede = BC001317_n253EmpresaSede[0];
            A403BancoNome = BC001317_A403BancoNome[0];
            n403BancoNome = BC001317_n403BancoNome[0];
            A465EmpresaAgencia = BC001317_A465EmpresaAgencia[0];
            n465EmpresaAgencia = BC001317_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = BC001317_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = BC001317_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = BC001317_A467EmpresaConta[0];
            n467EmpresaConta = BC001317_n467EmpresaConta[0];
            A468EmpresaPix = BC001317_A468EmpresaPix[0];
            n468EmpresaPix = BC001317_n468EmpresaPix[0];
            A469EmpresaPixTipo = BC001317_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = BC001317_n469EmpresaPixTipo[0];
            A470EmpresaEmail = BC001317_A470EmpresaEmail[0];
            n470EmpresaEmail = BC001317_n470EmpresaEmail[0];
            A610EmpresaLogradouro = BC001317_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = BC001317_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = BC001317_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = BC001317_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = BC001317_A609EmpresaCEP[0];
            n609EmpresaCEP = BC001317_n609EmpresaCEP[0];
            A612EmpresaBairro = BC001317_A612EmpresaBairro[0];
            n612EmpresaBairro = BC001317_n612EmpresaBairro[0];
            A613EmpresaComplemento = BC001317_A613EmpresaComplemento[0];
            n613EmpresaComplemento = BC001317_n613EmpresaComplemento[0];
            A187MunicipioNome = BC001317_A187MunicipioNome[0];
            n187MunicipioNome = BC001317_n187MunicipioNome[0];
            A189MunicipioUF = BC001317_A189MunicipioUF[0];
            n189MunicipioUF = BC001317_n189MunicipioUF[0];
            A770EmpresaRepresentanteCPF = BC001317_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = BC001317_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = BC001317_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = BC001317_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = BC001317_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = BC001317_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = BC001317_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = BC001317_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = BC001317_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = BC001317_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = BC001317_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = BC001317_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = BC001317_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = BC001317_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = BC001317_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = BC001317_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = BC001317_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = BC001317_n932EmpresaRepresentanteComplemento[0];
            A926EmpresaRepresentanteMunicipioNome = BC001317_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = BC001317_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = BC001317_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = BC001317_n927EmpresaRepresentanteMunicipioUF[0];
            A933EmpresaRepresentanteNacionalidade = BC001317_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = BC001317_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = BC001317_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = BC001317_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = BC001317_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = BC001317_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = BC001317_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC001317_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = BC001317_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = BC001317_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = BC001317_A464EmpresaBancoId[0];
            n464EmpresaBancoId = BC001317_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = BC001317_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = BC001317_n924EmpresaRepresentanteProfissao[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1342( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound42 = 0;
         ScanKeyLoad1342( ) ;
      }

      protected void ScanKeyLoad1342( )
      {
         sMode42 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound42 = 1;
            A249EmpresaId = BC001317_A249EmpresaId[0];
            A250EmpresaNomeFantasia = BC001317_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = BC001317_n250EmpresaNomeFantasia[0];
            A251EmpresaRazaoSocial = BC001317_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = BC001317_n251EmpresaRazaoSocial[0];
            A252EmpresaCNPJ = BC001317_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = BC001317_n252EmpresaCNPJ[0];
            A253EmpresaSede = BC001317_A253EmpresaSede[0];
            n253EmpresaSede = BC001317_n253EmpresaSede[0];
            A403BancoNome = BC001317_A403BancoNome[0];
            n403BancoNome = BC001317_n403BancoNome[0];
            A465EmpresaAgencia = BC001317_A465EmpresaAgencia[0];
            n465EmpresaAgencia = BC001317_n465EmpresaAgencia[0];
            A466EmpresaAgenciaDigito = BC001317_A466EmpresaAgenciaDigito[0];
            n466EmpresaAgenciaDigito = BC001317_n466EmpresaAgenciaDigito[0];
            A467EmpresaConta = BC001317_A467EmpresaConta[0];
            n467EmpresaConta = BC001317_n467EmpresaConta[0];
            A468EmpresaPix = BC001317_A468EmpresaPix[0];
            n468EmpresaPix = BC001317_n468EmpresaPix[0];
            A469EmpresaPixTipo = BC001317_A469EmpresaPixTipo[0];
            n469EmpresaPixTipo = BC001317_n469EmpresaPixTipo[0];
            A470EmpresaEmail = BC001317_A470EmpresaEmail[0];
            n470EmpresaEmail = BC001317_n470EmpresaEmail[0];
            A610EmpresaLogradouro = BC001317_A610EmpresaLogradouro[0];
            n610EmpresaLogradouro = BC001317_n610EmpresaLogradouro[0];
            A611EmpresaLogradouroNumero = BC001317_A611EmpresaLogradouroNumero[0];
            n611EmpresaLogradouroNumero = BC001317_n611EmpresaLogradouroNumero[0];
            A609EmpresaCEP = BC001317_A609EmpresaCEP[0];
            n609EmpresaCEP = BC001317_n609EmpresaCEP[0];
            A612EmpresaBairro = BC001317_A612EmpresaBairro[0];
            n612EmpresaBairro = BC001317_n612EmpresaBairro[0];
            A613EmpresaComplemento = BC001317_A613EmpresaComplemento[0];
            n613EmpresaComplemento = BC001317_n613EmpresaComplemento[0];
            A187MunicipioNome = BC001317_A187MunicipioNome[0];
            n187MunicipioNome = BC001317_n187MunicipioNome[0];
            A189MunicipioUF = BC001317_A189MunicipioUF[0];
            n189MunicipioUF = BC001317_n189MunicipioUF[0];
            A770EmpresaRepresentanteCPF = BC001317_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = BC001317_n770EmpresaRepresentanteCPF[0];
            A771EmpresaRepresentanteNome = BC001317_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = BC001317_n771EmpresaRepresentanteNome[0];
            A772EmpresaRepresentanteEmail = BC001317_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = BC001317_n772EmpresaRepresentanteEmail[0];
            A773EmpresaUtilizaRepresentanteAssinatura = BC001317_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = BC001317_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A928EmpresaRepresentanteLogradouro = BC001317_A928EmpresaRepresentanteLogradouro[0];
            n928EmpresaRepresentanteLogradouro = BC001317_n928EmpresaRepresentanteLogradouro[0];
            A929EmpresaRepresentanteNumero = BC001317_A929EmpresaRepresentanteNumero[0];
            n929EmpresaRepresentanteNumero = BC001317_n929EmpresaRepresentanteNumero[0];
            A930EmpresaRepresentanteCEP = BC001317_A930EmpresaRepresentanteCEP[0];
            n930EmpresaRepresentanteCEP = BC001317_n930EmpresaRepresentanteCEP[0];
            A931EmpresaRepresentanteBairro = BC001317_A931EmpresaRepresentanteBairro[0];
            n931EmpresaRepresentanteBairro = BC001317_n931EmpresaRepresentanteBairro[0];
            A932EmpresaRepresentanteComplemento = BC001317_A932EmpresaRepresentanteComplemento[0];
            n932EmpresaRepresentanteComplemento = BC001317_n932EmpresaRepresentanteComplemento[0];
            A926EmpresaRepresentanteMunicipioNome = BC001317_A926EmpresaRepresentanteMunicipioNome[0];
            n926EmpresaRepresentanteMunicipioNome = BC001317_n926EmpresaRepresentanteMunicipioNome[0];
            A927EmpresaRepresentanteMunicipioUF = BC001317_A927EmpresaRepresentanteMunicipioUF[0];
            n927EmpresaRepresentanteMunicipioUF = BC001317_n927EmpresaRepresentanteMunicipioUF[0];
            A933EmpresaRepresentanteNacionalidade = BC001317_A933EmpresaRepresentanteNacionalidade[0];
            n933EmpresaRepresentanteNacionalidade = BC001317_n933EmpresaRepresentanteNacionalidade[0];
            A934EmpresaRepresentanteTelefone = BC001317_A934EmpresaRepresentanteTelefone[0];
            n934EmpresaRepresentanteTelefone = BC001317_n934EmpresaRepresentanteTelefone[0];
            A935EmpresaRepresentanteTelefoneDDD = BC001317_A935EmpresaRepresentanteTelefoneDDD[0];
            n935EmpresaRepresentanteTelefoneDDD = BC001317_n935EmpresaRepresentanteTelefoneDDD[0];
            A186MunicipioCodigo = BC001317_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC001317_n186MunicipioCodigo[0];
            A925EmpresaRepresentanteMunicipio = BC001317_A925EmpresaRepresentanteMunicipio[0];
            n925EmpresaRepresentanteMunicipio = BC001317_n925EmpresaRepresentanteMunicipio[0];
            A464EmpresaBancoId = BC001317_A464EmpresaBancoId[0];
            n464EmpresaBancoId = BC001317_n464EmpresaBancoId[0];
            A924EmpresaRepresentanteProfissao = BC001317_A924EmpresaRepresentanteProfissao[0];
            n924EmpresaRepresentanteProfissao = BC001317_n924EmpresaRepresentanteProfissao[0];
         }
         Gx_mode = sMode42;
      }

      protected void ScanKeyEnd1342( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1342( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1342( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1342( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1342( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1342( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1342( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1342( )
      {
      }

      protected void send_integrity_lvl_hashes1342( )
      {
      }

      protected void AddRow1342( )
      {
         VarsToRow42( bcEmpresa) ;
      }

      protected void ReadRow1342( )
      {
         RowToVars42( bcEmpresa, 1) ;
      }

      protected void InitializeNonKey1342( )
      {
         A250EmpresaNomeFantasia = "";
         n250EmpresaNomeFantasia = false;
         A251EmpresaRazaoSocial = "";
         n251EmpresaRazaoSocial = false;
         A252EmpresaCNPJ = "";
         n252EmpresaCNPJ = false;
         A253EmpresaSede = false;
         n253EmpresaSede = false;
         A464EmpresaBancoId = 0;
         n464EmpresaBancoId = false;
         A403BancoNome = "";
         n403BancoNome = false;
         A465EmpresaAgencia = 0;
         n465EmpresaAgencia = false;
         A466EmpresaAgenciaDigito = 0;
         n466EmpresaAgenciaDigito = false;
         A467EmpresaConta = 0;
         n467EmpresaConta = false;
         A468EmpresaPix = "";
         n468EmpresaPix = false;
         A469EmpresaPixTipo = "";
         n469EmpresaPixTipo = false;
         A470EmpresaEmail = "";
         n470EmpresaEmail = false;
         A610EmpresaLogradouro = "";
         n610EmpresaLogradouro = false;
         A611EmpresaLogradouroNumero = 0;
         n611EmpresaLogradouroNumero = false;
         A609EmpresaCEP = "";
         n609EmpresaCEP = false;
         A612EmpresaBairro = "";
         n612EmpresaBairro = false;
         A613EmpresaComplemento = "";
         n613EmpresaComplemento = false;
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         A770EmpresaRepresentanteCPF = "";
         n770EmpresaRepresentanteCPF = false;
         A771EmpresaRepresentanteNome = "";
         n771EmpresaRepresentanteNome = false;
         A772EmpresaRepresentanteEmail = "";
         n772EmpresaRepresentanteEmail = false;
         A773EmpresaUtilizaRepresentanteAssinatura = false;
         n773EmpresaUtilizaRepresentanteAssinatura = false;
         A928EmpresaRepresentanteLogradouro = "";
         n928EmpresaRepresentanteLogradouro = false;
         A929EmpresaRepresentanteNumero = 0;
         n929EmpresaRepresentanteNumero = false;
         A930EmpresaRepresentanteCEP = "";
         n930EmpresaRepresentanteCEP = false;
         A931EmpresaRepresentanteBairro = "";
         n931EmpresaRepresentanteBairro = false;
         A932EmpresaRepresentanteComplemento = "";
         n932EmpresaRepresentanteComplemento = false;
         A925EmpresaRepresentanteMunicipio = "";
         n925EmpresaRepresentanteMunicipio = false;
         A926EmpresaRepresentanteMunicipioNome = "";
         n926EmpresaRepresentanteMunicipioNome = false;
         A927EmpresaRepresentanteMunicipioUF = "";
         n927EmpresaRepresentanteMunicipioUF = false;
         A933EmpresaRepresentanteNacionalidade = "";
         n933EmpresaRepresentanteNacionalidade = false;
         A924EmpresaRepresentanteProfissao = 0;
         n924EmpresaRepresentanteProfissao = false;
         A934EmpresaRepresentanteTelefone = 0;
         n934EmpresaRepresentanteTelefone = false;
         A935EmpresaRepresentanteTelefoneDDD = 0;
         n935EmpresaRepresentanteTelefoneDDD = false;
         Z250EmpresaNomeFantasia = "";
         Z251EmpresaRazaoSocial = "";
         Z252EmpresaCNPJ = "";
         Z253EmpresaSede = false;
         Z465EmpresaAgencia = 0;
         Z466EmpresaAgenciaDigito = 0;
         Z467EmpresaConta = 0;
         Z468EmpresaPix = "";
         Z469EmpresaPixTipo = "";
         Z470EmpresaEmail = "";
         Z610EmpresaLogradouro = "";
         Z611EmpresaLogradouroNumero = 0;
         Z609EmpresaCEP = "";
         Z612EmpresaBairro = "";
         Z613EmpresaComplemento = "";
         Z770EmpresaRepresentanteCPF = "";
         Z771EmpresaRepresentanteNome = "";
         Z772EmpresaRepresentanteEmail = "";
         Z773EmpresaUtilizaRepresentanteAssinatura = false;
         Z928EmpresaRepresentanteLogradouro = "";
         Z929EmpresaRepresentanteNumero = 0;
         Z930EmpresaRepresentanteCEP = "";
         Z931EmpresaRepresentanteBairro = "";
         Z932EmpresaRepresentanteComplemento = "";
         Z933EmpresaRepresentanteNacionalidade = "";
         Z934EmpresaRepresentanteTelefone = 0;
         Z935EmpresaRepresentanteTelefoneDDD = 0;
         Z186MunicipioCodigo = "";
         Z925EmpresaRepresentanteMunicipio = "";
         Z464EmpresaBancoId = 0;
         Z924EmpresaRepresentanteProfissao = 0;
      }

      protected void InitAll1342( )
      {
         A249EmpresaId = 0;
         InitializeNonKey1342( ) ;
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

      public void VarsToRow42( SdtEmpresa obj42 )
      {
         obj42.gxTpr_Mode = Gx_mode;
         obj42.gxTpr_Empresanomefantasia = A250EmpresaNomeFantasia;
         obj42.gxTpr_Empresarazaosocial = A251EmpresaRazaoSocial;
         obj42.gxTpr_Empresacnpj = A252EmpresaCNPJ;
         obj42.gxTpr_Empresasede = A253EmpresaSede;
         obj42.gxTpr_Empresabancoid = A464EmpresaBancoId;
         obj42.gxTpr_Banconome = A403BancoNome;
         obj42.gxTpr_Empresaagencia = A465EmpresaAgencia;
         obj42.gxTpr_Empresaagenciadigito = A466EmpresaAgenciaDigito;
         obj42.gxTpr_Empresaconta = A467EmpresaConta;
         obj42.gxTpr_Empresapix = A468EmpresaPix;
         obj42.gxTpr_Empresapixtipo = A469EmpresaPixTipo;
         obj42.gxTpr_Empresaemail = A470EmpresaEmail;
         obj42.gxTpr_Empresalogradouro = A610EmpresaLogradouro;
         obj42.gxTpr_Empresalogradouronumero = A611EmpresaLogradouroNumero;
         obj42.gxTpr_Empresacep = A609EmpresaCEP;
         obj42.gxTpr_Empresabairro = A612EmpresaBairro;
         obj42.gxTpr_Empresacomplemento = A613EmpresaComplemento;
         obj42.gxTpr_Municipiocodigo = A186MunicipioCodigo;
         obj42.gxTpr_Municipionome = A187MunicipioNome;
         obj42.gxTpr_Municipiouf = A189MunicipioUF;
         obj42.gxTpr_Empresarepresentantecpf = A770EmpresaRepresentanteCPF;
         obj42.gxTpr_Empresarepresentantenome = A771EmpresaRepresentanteNome;
         obj42.gxTpr_Empresarepresentanteemail = A772EmpresaRepresentanteEmail;
         obj42.gxTpr_Empresautilizarepresentanteassinatura = A773EmpresaUtilizaRepresentanteAssinatura;
         obj42.gxTpr_Empresarepresentantelogradouro = A928EmpresaRepresentanteLogradouro;
         obj42.gxTpr_Empresarepresentantenumero = A929EmpresaRepresentanteNumero;
         obj42.gxTpr_Empresarepresentantecep = A930EmpresaRepresentanteCEP;
         obj42.gxTpr_Empresarepresentantebairro = A931EmpresaRepresentanteBairro;
         obj42.gxTpr_Empresarepresentantecomplemento = A932EmpresaRepresentanteComplemento;
         obj42.gxTpr_Empresarepresentantemunicipio = A925EmpresaRepresentanteMunicipio;
         obj42.gxTpr_Empresarepresentantemunicipionome = A926EmpresaRepresentanteMunicipioNome;
         obj42.gxTpr_Empresarepresentantemunicipiouf = A927EmpresaRepresentanteMunicipioUF;
         obj42.gxTpr_Empresarepresentantenacionalidade = A933EmpresaRepresentanteNacionalidade;
         obj42.gxTpr_Empresarepresentanteprofissao = A924EmpresaRepresentanteProfissao;
         obj42.gxTpr_Empresarepresentantetelefone = A934EmpresaRepresentanteTelefone;
         obj42.gxTpr_Empresarepresentantetelefoneddd = A935EmpresaRepresentanteTelefoneDDD;
         obj42.gxTpr_Empresaid = A249EmpresaId;
         obj42.gxTpr_Empresaid_Z = Z249EmpresaId;
         obj42.gxTpr_Empresanomefantasia_Z = Z250EmpresaNomeFantasia;
         obj42.gxTpr_Empresarazaosocial_Z = Z251EmpresaRazaoSocial;
         obj42.gxTpr_Empresacnpj_Z = Z252EmpresaCNPJ;
         obj42.gxTpr_Empresasede_Z = Z253EmpresaSede;
         obj42.gxTpr_Empresabancoid_Z = Z464EmpresaBancoId;
         obj42.gxTpr_Banconome_Z = Z403BancoNome;
         obj42.gxTpr_Empresaagencia_Z = Z465EmpresaAgencia;
         obj42.gxTpr_Empresaagenciadigito_Z = Z466EmpresaAgenciaDigito;
         obj42.gxTpr_Empresaconta_Z = Z467EmpresaConta;
         obj42.gxTpr_Empresapix_Z = Z468EmpresaPix;
         obj42.gxTpr_Empresapixtipo_Z = Z469EmpresaPixTipo;
         obj42.gxTpr_Empresaemail_Z = Z470EmpresaEmail;
         obj42.gxTpr_Empresalogradouro_Z = Z610EmpresaLogradouro;
         obj42.gxTpr_Empresalogradouronumero_Z = Z611EmpresaLogradouroNumero;
         obj42.gxTpr_Empresacep_Z = Z609EmpresaCEP;
         obj42.gxTpr_Empresabairro_Z = Z612EmpresaBairro;
         obj42.gxTpr_Empresacomplemento_Z = Z613EmpresaComplemento;
         obj42.gxTpr_Municipiocodigo_Z = Z186MunicipioCodigo;
         obj42.gxTpr_Municipionome_Z = Z187MunicipioNome;
         obj42.gxTpr_Municipiouf_Z = Z189MunicipioUF;
         obj42.gxTpr_Empresarepresentantecpf_Z = Z770EmpresaRepresentanteCPF;
         obj42.gxTpr_Empresarepresentantenome_Z = Z771EmpresaRepresentanteNome;
         obj42.gxTpr_Empresarepresentanteemail_Z = Z772EmpresaRepresentanteEmail;
         obj42.gxTpr_Empresautilizarepresentanteassinatura_Z = Z773EmpresaUtilizaRepresentanteAssinatura;
         obj42.gxTpr_Empresarepresentantelogradouro_Z = Z928EmpresaRepresentanteLogradouro;
         obj42.gxTpr_Empresarepresentantenumero_Z = Z929EmpresaRepresentanteNumero;
         obj42.gxTpr_Empresarepresentantecep_Z = Z930EmpresaRepresentanteCEP;
         obj42.gxTpr_Empresarepresentantebairro_Z = Z931EmpresaRepresentanteBairro;
         obj42.gxTpr_Empresarepresentantecomplemento_Z = Z932EmpresaRepresentanteComplemento;
         obj42.gxTpr_Empresarepresentantemunicipio_Z = Z925EmpresaRepresentanteMunicipio;
         obj42.gxTpr_Empresarepresentantemunicipionome_Z = Z926EmpresaRepresentanteMunicipioNome;
         obj42.gxTpr_Empresarepresentantemunicipiouf_Z = Z927EmpresaRepresentanteMunicipioUF;
         obj42.gxTpr_Empresarepresentantenacionalidade_Z = Z933EmpresaRepresentanteNacionalidade;
         obj42.gxTpr_Empresarepresentanteprofissao_Z = Z924EmpresaRepresentanteProfissao;
         obj42.gxTpr_Empresarepresentantetelefone_Z = Z934EmpresaRepresentanteTelefone;
         obj42.gxTpr_Empresarepresentantetelefoneddd_Z = Z935EmpresaRepresentanteTelefoneDDD;
         obj42.gxTpr_Empresanomefantasia_N = (short)(Convert.ToInt16(n250EmpresaNomeFantasia));
         obj42.gxTpr_Empresarazaosocial_N = (short)(Convert.ToInt16(n251EmpresaRazaoSocial));
         obj42.gxTpr_Empresacnpj_N = (short)(Convert.ToInt16(n252EmpresaCNPJ));
         obj42.gxTpr_Empresasede_N = (short)(Convert.ToInt16(n253EmpresaSede));
         obj42.gxTpr_Empresabancoid_N = (short)(Convert.ToInt16(n464EmpresaBancoId));
         obj42.gxTpr_Banconome_N = (short)(Convert.ToInt16(n403BancoNome));
         obj42.gxTpr_Empresaagencia_N = (short)(Convert.ToInt16(n465EmpresaAgencia));
         obj42.gxTpr_Empresaagenciadigito_N = (short)(Convert.ToInt16(n466EmpresaAgenciaDigito));
         obj42.gxTpr_Empresaconta_N = (short)(Convert.ToInt16(n467EmpresaConta));
         obj42.gxTpr_Empresapix_N = (short)(Convert.ToInt16(n468EmpresaPix));
         obj42.gxTpr_Empresapixtipo_N = (short)(Convert.ToInt16(n469EmpresaPixTipo));
         obj42.gxTpr_Empresaemail_N = (short)(Convert.ToInt16(n470EmpresaEmail));
         obj42.gxTpr_Empresalogradouro_N = (short)(Convert.ToInt16(n610EmpresaLogradouro));
         obj42.gxTpr_Empresalogradouronumero_N = (short)(Convert.ToInt16(n611EmpresaLogradouroNumero));
         obj42.gxTpr_Empresacep_N = (short)(Convert.ToInt16(n609EmpresaCEP));
         obj42.gxTpr_Empresabairro_N = (short)(Convert.ToInt16(n612EmpresaBairro));
         obj42.gxTpr_Empresacomplemento_N = (short)(Convert.ToInt16(n613EmpresaComplemento));
         obj42.gxTpr_Municipiocodigo_N = (short)(Convert.ToInt16(n186MunicipioCodigo));
         obj42.gxTpr_Municipionome_N = (short)(Convert.ToInt16(n187MunicipioNome));
         obj42.gxTpr_Municipiouf_N = (short)(Convert.ToInt16(n189MunicipioUF));
         obj42.gxTpr_Empresarepresentantecpf_N = (short)(Convert.ToInt16(n770EmpresaRepresentanteCPF));
         obj42.gxTpr_Empresarepresentantenome_N = (short)(Convert.ToInt16(n771EmpresaRepresentanteNome));
         obj42.gxTpr_Empresarepresentanteemail_N = (short)(Convert.ToInt16(n772EmpresaRepresentanteEmail));
         obj42.gxTpr_Empresautilizarepresentanteassinatura_N = (short)(Convert.ToInt16(n773EmpresaUtilizaRepresentanteAssinatura));
         obj42.gxTpr_Empresarepresentantelogradouro_N = (short)(Convert.ToInt16(n928EmpresaRepresentanteLogradouro));
         obj42.gxTpr_Empresarepresentantenumero_N = (short)(Convert.ToInt16(n929EmpresaRepresentanteNumero));
         obj42.gxTpr_Empresarepresentantecep_N = (short)(Convert.ToInt16(n930EmpresaRepresentanteCEP));
         obj42.gxTpr_Empresarepresentantebairro_N = (short)(Convert.ToInt16(n931EmpresaRepresentanteBairro));
         obj42.gxTpr_Empresarepresentantecomplemento_N = (short)(Convert.ToInt16(n932EmpresaRepresentanteComplemento));
         obj42.gxTpr_Empresarepresentantemunicipio_N = (short)(Convert.ToInt16(n925EmpresaRepresentanteMunicipio));
         obj42.gxTpr_Empresarepresentantemunicipionome_N = (short)(Convert.ToInt16(n926EmpresaRepresentanteMunicipioNome));
         obj42.gxTpr_Empresarepresentantemunicipiouf_N = (short)(Convert.ToInt16(n927EmpresaRepresentanteMunicipioUF));
         obj42.gxTpr_Empresarepresentantenacionalidade_N = (short)(Convert.ToInt16(n933EmpresaRepresentanteNacionalidade));
         obj42.gxTpr_Empresarepresentanteprofissao_N = (short)(Convert.ToInt16(n924EmpresaRepresentanteProfissao));
         obj42.gxTpr_Empresarepresentantetelefone_N = (short)(Convert.ToInt16(n934EmpresaRepresentanteTelefone));
         obj42.gxTpr_Empresarepresentantetelefoneddd_N = (short)(Convert.ToInt16(n935EmpresaRepresentanteTelefoneDDD));
         obj42.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow42( SdtEmpresa obj42 )
      {
         obj42.gxTpr_Empresaid = A249EmpresaId;
         return  ;
      }

      public void RowToVars42( SdtEmpresa obj42 ,
                               int forceLoad )
      {
         Gx_mode = obj42.gxTpr_Mode;
         A250EmpresaNomeFantasia = obj42.gxTpr_Empresanomefantasia;
         n250EmpresaNomeFantasia = false;
         A251EmpresaRazaoSocial = obj42.gxTpr_Empresarazaosocial;
         n251EmpresaRazaoSocial = false;
         A252EmpresaCNPJ = obj42.gxTpr_Empresacnpj;
         n252EmpresaCNPJ = false;
         A253EmpresaSede = obj42.gxTpr_Empresasede;
         n253EmpresaSede = false;
         A464EmpresaBancoId = obj42.gxTpr_Empresabancoid;
         n464EmpresaBancoId = false;
         A403BancoNome = obj42.gxTpr_Banconome;
         n403BancoNome = false;
         A465EmpresaAgencia = obj42.gxTpr_Empresaagencia;
         n465EmpresaAgencia = false;
         A466EmpresaAgenciaDigito = obj42.gxTpr_Empresaagenciadigito;
         n466EmpresaAgenciaDigito = false;
         A467EmpresaConta = obj42.gxTpr_Empresaconta;
         n467EmpresaConta = false;
         A468EmpresaPix = obj42.gxTpr_Empresapix;
         n468EmpresaPix = false;
         A469EmpresaPixTipo = obj42.gxTpr_Empresapixtipo;
         n469EmpresaPixTipo = false;
         A470EmpresaEmail = obj42.gxTpr_Empresaemail;
         n470EmpresaEmail = false;
         A610EmpresaLogradouro = obj42.gxTpr_Empresalogradouro;
         n610EmpresaLogradouro = false;
         A611EmpresaLogradouroNumero = obj42.gxTpr_Empresalogradouronumero;
         n611EmpresaLogradouroNumero = false;
         A609EmpresaCEP = obj42.gxTpr_Empresacep;
         n609EmpresaCEP = false;
         A612EmpresaBairro = obj42.gxTpr_Empresabairro;
         n612EmpresaBairro = false;
         A613EmpresaComplemento = obj42.gxTpr_Empresacomplemento;
         n613EmpresaComplemento = false;
         A186MunicipioCodigo = obj42.gxTpr_Municipiocodigo;
         n186MunicipioCodigo = false;
         A187MunicipioNome = obj42.gxTpr_Municipionome;
         n187MunicipioNome = false;
         A189MunicipioUF = obj42.gxTpr_Municipiouf;
         n189MunicipioUF = false;
         A770EmpresaRepresentanteCPF = obj42.gxTpr_Empresarepresentantecpf;
         n770EmpresaRepresentanteCPF = false;
         A771EmpresaRepresentanteNome = obj42.gxTpr_Empresarepresentantenome;
         n771EmpresaRepresentanteNome = false;
         A772EmpresaRepresentanteEmail = obj42.gxTpr_Empresarepresentanteemail;
         n772EmpresaRepresentanteEmail = false;
         A773EmpresaUtilizaRepresentanteAssinatura = obj42.gxTpr_Empresautilizarepresentanteassinatura;
         n773EmpresaUtilizaRepresentanteAssinatura = false;
         A928EmpresaRepresentanteLogradouro = obj42.gxTpr_Empresarepresentantelogradouro;
         n928EmpresaRepresentanteLogradouro = false;
         A929EmpresaRepresentanteNumero = obj42.gxTpr_Empresarepresentantenumero;
         n929EmpresaRepresentanteNumero = false;
         A930EmpresaRepresentanteCEP = obj42.gxTpr_Empresarepresentantecep;
         n930EmpresaRepresentanteCEP = false;
         A931EmpresaRepresentanteBairro = obj42.gxTpr_Empresarepresentantebairro;
         n931EmpresaRepresentanteBairro = false;
         A932EmpresaRepresentanteComplemento = obj42.gxTpr_Empresarepresentantecomplemento;
         n932EmpresaRepresentanteComplemento = false;
         A925EmpresaRepresentanteMunicipio = obj42.gxTpr_Empresarepresentantemunicipio;
         n925EmpresaRepresentanteMunicipio = false;
         A926EmpresaRepresentanteMunicipioNome = obj42.gxTpr_Empresarepresentantemunicipionome;
         n926EmpresaRepresentanteMunicipioNome = false;
         A927EmpresaRepresentanteMunicipioUF = obj42.gxTpr_Empresarepresentantemunicipiouf;
         n927EmpresaRepresentanteMunicipioUF = false;
         A933EmpresaRepresentanteNacionalidade = obj42.gxTpr_Empresarepresentantenacionalidade;
         n933EmpresaRepresentanteNacionalidade = false;
         A924EmpresaRepresentanteProfissao = obj42.gxTpr_Empresarepresentanteprofissao;
         n924EmpresaRepresentanteProfissao = false;
         A934EmpresaRepresentanteTelefone = obj42.gxTpr_Empresarepresentantetelefone;
         n934EmpresaRepresentanteTelefone = false;
         A935EmpresaRepresentanteTelefoneDDD = obj42.gxTpr_Empresarepresentantetelefoneddd;
         n935EmpresaRepresentanteTelefoneDDD = false;
         A249EmpresaId = obj42.gxTpr_Empresaid;
         Z249EmpresaId = obj42.gxTpr_Empresaid_Z;
         Z250EmpresaNomeFantasia = obj42.gxTpr_Empresanomefantasia_Z;
         Z251EmpresaRazaoSocial = obj42.gxTpr_Empresarazaosocial_Z;
         Z252EmpresaCNPJ = obj42.gxTpr_Empresacnpj_Z;
         Z253EmpresaSede = obj42.gxTpr_Empresasede_Z;
         Z464EmpresaBancoId = obj42.gxTpr_Empresabancoid_Z;
         Z403BancoNome = obj42.gxTpr_Banconome_Z;
         Z465EmpresaAgencia = obj42.gxTpr_Empresaagencia_Z;
         Z466EmpresaAgenciaDigito = obj42.gxTpr_Empresaagenciadigito_Z;
         Z467EmpresaConta = obj42.gxTpr_Empresaconta_Z;
         Z468EmpresaPix = obj42.gxTpr_Empresapix_Z;
         Z469EmpresaPixTipo = obj42.gxTpr_Empresapixtipo_Z;
         Z470EmpresaEmail = obj42.gxTpr_Empresaemail_Z;
         Z610EmpresaLogradouro = obj42.gxTpr_Empresalogradouro_Z;
         Z611EmpresaLogradouroNumero = obj42.gxTpr_Empresalogradouronumero_Z;
         Z609EmpresaCEP = obj42.gxTpr_Empresacep_Z;
         Z612EmpresaBairro = obj42.gxTpr_Empresabairro_Z;
         Z613EmpresaComplemento = obj42.gxTpr_Empresacomplemento_Z;
         Z186MunicipioCodigo = obj42.gxTpr_Municipiocodigo_Z;
         Z187MunicipioNome = obj42.gxTpr_Municipionome_Z;
         Z189MunicipioUF = obj42.gxTpr_Municipiouf_Z;
         Z770EmpresaRepresentanteCPF = obj42.gxTpr_Empresarepresentantecpf_Z;
         Z771EmpresaRepresentanteNome = obj42.gxTpr_Empresarepresentantenome_Z;
         Z772EmpresaRepresentanteEmail = obj42.gxTpr_Empresarepresentanteemail_Z;
         Z773EmpresaUtilizaRepresentanteAssinatura = obj42.gxTpr_Empresautilizarepresentanteassinatura_Z;
         Z928EmpresaRepresentanteLogradouro = obj42.gxTpr_Empresarepresentantelogradouro_Z;
         Z929EmpresaRepresentanteNumero = obj42.gxTpr_Empresarepresentantenumero_Z;
         Z930EmpresaRepresentanteCEP = obj42.gxTpr_Empresarepresentantecep_Z;
         Z931EmpresaRepresentanteBairro = obj42.gxTpr_Empresarepresentantebairro_Z;
         Z932EmpresaRepresentanteComplemento = obj42.gxTpr_Empresarepresentantecomplemento_Z;
         Z925EmpresaRepresentanteMunicipio = obj42.gxTpr_Empresarepresentantemunicipio_Z;
         Z926EmpresaRepresentanteMunicipioNome = obj42.gxTpr_Empresarepresentantemunicipionome_Z;
         Z927EmpresaRepresentanteMunicipioUF = obj42.gxTpr_Empresarepresentantemunicipiouf_Z;
         Z933EmpresaRepresentanteNacionalidade = obj42.gxTpr_Empresarepresentantenacionalidade_Z;
         Z924EmpresaRepresentanteProfissao = obj42.gxTpr_Empresarepresentanteprofissao_Z;
         Z934EmpresaRepresentanteTelefone = obj42.gxTpr_Empresarepresentantetelefone_Z;
         Z935EmpresaRepresentanteTelefoneDDD = obj42.gxTpr_Empresarepresentantetelefoneddd_Z;
         n250EmpresaNomeFantasia = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresanomefantasia_N));
         n251EmpresaRazaoSocial = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarazaosocial_N));
         n252EmpresaCNPJ = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresacnpj_N));
         n253EmpresaSede = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresasede_N));
         n464EmpresaBancoId = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresabancoid_N));
         n403BancoNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Banconome_N));
         n465EmpresaAgencia = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresaagencia_N));
         n466EmpresaAgenciaDigito = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresaagenciadigito_N));
         n467EmpresaConta = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresaconta_N));
         n468EmpresaPix = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresapix_N));
         n469EmpresaPixTipo = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresapixtipo_N));
         n470EmpresaEmail = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresaemail_N));
         n610EmpresaLogradouro = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresalogradouro_N));
         n611EmpresaLogradouroNumero = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresalogradouronumero_N));
         n609EmpresaCEP = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresacep_N));
         n612EmpresaBairro = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresabairro_N));
         n613EmpresaComplemento = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresacomplemento_N));
         n186MunicipioCodigo = (bool)(Convert.ToBoolean(obj42.gxTpr_Municipiocodigo_N));
         n187MunicipioNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Municipionome_N));
         n189MunicipioUF = (bool)(Convert.ToBoolean(obj42.gxTpr_Municipiouf_N));
         n770EmpresaRepresentanteCPF = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantecpf_N));
         n771EmpresaRepresentanteNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantenome_N));
         n772EmpresaRepresentanteEmail = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentanteemail_N));
         n773EmpresaUtilizaRepresentanteAssinatura = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresautilizarepresentanteassinatura_N));
         n928EmpresaRepresentanteLogradouro = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantelogradouro_N));
         n929EmpresaRepresentanteNumero = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantenumero_N));
         n930EmpresaRepresentanteCEP = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantecep_N));
         n931EmpresaRepresentanteBairro = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantebairro_N));
         n932EmpresaRepresentanteComplemento = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantecomplemento_N));
         n925EmpresaRepresentanteMunicipio = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantemunicipio_N));
         n926EmpresaRepresentanteMunicipioNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantemunicipionome_N));
         n927EmpresaRepresentanteMunicipioUF = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantemunicipiouf_N));
         n933EmpresaRepresentanteNacionalidade = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantenacionalidade_N));
         n924EmpresaRepresentanteProfissao = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentanteprofissao_N));
         n934EmpresaRepresentanteTelefone = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantetelefone_N));
         n935EmpresaRepresentanteTelefoneDDD = (bool)(Convert.ToBoolean(obj42.gxTpr_Empresarepresentantetelefoneddd_N));
         Gx_mode = obj42.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A249EmpresaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1342( ) ;
         ScanKeyStart1342( ) ;
         if ( RcdFound42 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z249EmpresaId = A249EmpresaId;
         }
         ZM1342( -6) ;
         OnLoadActions1342( ) ;
         AddRow1342( ) ;
         ScanKeyEnd1342( ) ;
         if ( RcdFound42 == 0 )
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
         RowToVars42( bcEmpresa, 0) ;
         ScanKeyStart1342( ) ;
         if ( RcdFound42 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z249EmpresaId = A249EmpresaId;
         }
         ZM1342( -6) ;
         OnLoadActions1342( ) ;
         AddRow1342( ) ;
         ScanKeyEnd1342( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1342( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1342( ) ;
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A249EmpresaId != Z249EmpresaId )
               {
                  A249EmpresaId = Z249EmpresaId;
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
                  Update1342( ) ;
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
                  if ( A249EmpresaId != Z249EmpresaId )
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
                        Insert1342( ) ;
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
                        Insert1342( ) ;
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
         RowToVars42( bcEmpresa, 1) ;
         SaveImpl( ) ;
         VarsToRow42( bcEmpresa) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars42( bcEmpresa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1342( ) ;
         AfterTrn( ) ;
         VarsToRow42( bcEmpresa) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow42( bcEmpresa) ;
         }
         else
         {
            SdtEmpresa auxBC = new SdtEmpresa(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A249EmpresaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmpresa);
               auxBC.Save();
               bcEmpresa.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars42( bcEmpresa, 1) ;
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
         RowToVars42( bcEmpresa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1342( ) ;
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
               VarsToRow42( bcEmpresa) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow42( bcEmpresa) ;
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
         RowToVars42( bcEmpresa, 0) ;
         GetKey1342( ) ;
         if ( RcdFound42 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A249EmpresaId != Z249EmpresaId )
            {
               A249EmpresaId = Z249EmpresaId;
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
            if ( A249EmpresaId != Z249EmpresaId )
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
         context.RollbackDataStores("empresa_bc",pr_default);
         VarsToRow42( bcEmpresa) ;
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
         Gx_mode = bcEmpresa.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmpresa.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmpresa )
         {
            bcEmpresa = (SdtEmpresa)(sdt);
            if ( StringUtil.StrCmp(bcEmpresa.gxTpr_Mode, "") == 0 )
            {
               bcEmpresa.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow42( bcEmpresa) ;
            }
            else
            {
               RowToVars42( bcEmpresa, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmpresa.gxTpr_Mode, "") == 0 )
            {
               bcEmpresa.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars42( bcEmpresa, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEmpresa Empresa_BC
      {
         get {
            return bcEmpresa ;
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
         pr_default.close(13);
         pr_default.close(14);
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
         AV16Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_MunicipioCodigo = "";
         AV14Insert_EmpresaRepresentanteMunicipio = "";
         Z250EmpresaNomeFantasia = "";
         A250EmpresaNomeFantasia = "";
         Z251EmpresaRazaoSocial = "";
         A251EmpresaRazaoSocial = "";
         Z252EmpresaCNPJ = "";
         A252EmpresaCNPJ = "";
         Z468EmpresaPix = "";
         A468EmpresaPix = "";
         Z469EmpresaPixTipo = "";
         A469EmpresaPixTipo = "";
         Z470EmpresaEmail = "";
         A470EmpresaEmail = "";
         Z610EmpresaLogradouro = "";
         A610EmpresaLogradouro = "";
         Z609EmpresaCEP = "";
         A609EmpresaCEP = "";
         Z612EmpresaBairro = "";
         A612EmpresaBairro = "";
         Z613EmpresaComplemento = "";
         A613EmpresaComplemento = "";
         Z770EmpresaRepresentanteCPF = "";
         A770EmpresaRepresentanteCPF = "";
         Z771EmpresaRepresentanteNome = "";
         A771EmpresaRepresentanteNome = "";
         Z772EmpresaRepresentanteEmail = "";
         A772EmpresaRepresentanteEmail = "";
         Z928EmpresaRepresentanteLogradouro = "";
         A928EmpresaRepresentanteLogradouro = "";
         Z930EmpresaRepresentanteCEP = "";
         A930EmpresaRepresentanteCEP = "";
         Z931EmpresaRepresentanteBairro = "";
         A931EmpresaRepresentanteBairro = "";
         Z932EmpresaRepresentanteComplemento = "";
         A932EmpresaRepresentanteComplemento = "";
         Z933EmpresaRepresentanteNacionalidade = "";
         A933EmpresaRepresentanteNacionalidade = "";
         Z186MunicipioCodigo = "";
         A186MunicipioCodigo = "";
         Z925EmpresaRepresentanteMunicipio = "";
         A925EmpresaRepresentanteMunicipio = "";
         Z187MunicipioNome = "";
         A187MunicipioNome = "";
         Z189MunicipioUF = "";
         A189MunicipioUF = "";
         Z926EmpresaRepresentanteMunicipioNome = "";
         A926EmpresaRepresentanteMunicipioNome = "";
         Z927EmpresaRepresentanteMunicipioUF = "";
         A927EmpresaRepresentanteMunicipioUF = "";
         Z403BancoNome = "";
         A403BancoNome = "";
         BC00138_A249EmpresaId = new int[1] ;
         BC00138_A250EmpresaNomeFantasia = new string[] {""} ;
         BC00138_n250EmpresaNomeFantasia = new bool[] {false} ;
         BC00138_A251EmpresaRazaoSocial = new string[] {""} ;
         BC00138_n251EmpresaRazaoSocial = new bool[] {false} ;
         BC00138_A252EmpresaCNPJ = new string[] {""} ;
         BC00138_n252EmpresaCNPJ = new bool[] {false} ;
         BC00138_A253EmpresaSede = new bool[] {false} ;
         BC00138_n253EmpresaSede = new bool[] {false} ;
         BC00138_A403BancoNome = new string[] {""} ;
         BC00138_n403BancoNome = new bool[] {false} ;
         BC00138_A465EmpresaAgencia = new int[1] ;
         BC00138_n465EmpresaAgencia = new bool[] {false} ;
         BC00138_A466EmpresaAgenciaDigito = new int[1] ;
         BC00138_n466EmpresaAgenciaDigito = new bool[] {false} ;
         BC00138_A467EmpresaConta = new int[1] ;
         BC00138_n467EmpresaConta = new bool[] {false} ;
         BC00138_A468EmpresaPix = new string[] {""} ;
         BC00138_n468EmpresaPix = new bool[] {false} ;
         BC00138_A469EmpresaPixTipo = new string[] {""} ;
         BC00138_n469EmpresaPixTipo = new bool[] {false} ;
         BC00138_A470EmpresaEmail = new string[] {""} ;
         BC00138_n470EmpresaEmail = new bool[] {false} ;
         BC00138_A610EmpresaLogradouro = new string[] {""} ;
         BC00138_n610EmpresaLogradouro = new bool[] {false} ;
         BC00138_A611EmpresaLogradouroNumero = new long[1] ;
         BC00138_n611EmpresaLogradouroNumero = new bool[] {false} ;
         BC00138_A609EmpresaCEP = new string[] {""} ;
         BC00138_n609EmpresaCEP = new bool[] {false} ;
         BC00138_A612EmpresaBairro = new string[] {""} ;
         BC00138_n612EmpresaBairro = new bool[] {false} ;
         BC00138_A613EmpresaComplemento = new string[] {""} ;
         BC00138_n613EmpresaComplemento = new bool[] {false} ;
         BC00138_A187MunicipioNome = new string[] {""} ;
         BC00138_n187MunicipioNome = new bool[] {false} ;
         BC00138_A189MunicipioUF = new string[] {""} ;
         BC00138_n189MunicipioUF = new bool[] {false} ;
         BC00138_A770EmpresaRepresentanteCPF = new string[] {""} ;
         BC00138_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         BC00138_A771EmpresaRepresentanteNome = new string[] {""} ;
         BC00138_n771EmpresaRepresentanteNome = new bool[] {false} ;
         BC00138_A772EmpresaRepresentanteEmail = new string[] {""} ;
         BC00138_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         BC00138_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00138_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00138_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         BC00138_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         BC00138_A929EmpresaRepresentanteNumero = new long[1] ;
         BC00138_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         BC00138_A930EmpresaRepresentanteCEP = new string[] {""} ;
         BC00138_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         BC00138_A931EmpresaRepresentanteBairro = new string[] {""} ;
         BC00138_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         BC00138_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         BC00138_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         BC00138_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         BC00138_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         BC00138_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         BC00138_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         BC00138_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         BC00138_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         BC00138_A934EmpresaRepresentanteTelefone = new int[1] ;
         BC00138_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         BC00138_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         BC00138_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         BC00138_A186MunicipioCodigo = new string[] {""} ;
         BC00138_n186MunicipioCodigo = new bool[] {false} ;
         BC00138_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         BC00138_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         BC00138_A464EmpresaBancoId = new int[1] ;
         BC00138_n464EmpresaBancoId = new bool[] {false} ;
         BC00138_A924EmpresaRepresentanteProfissao = new int[1] ;
         BC00138_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         BC00136_A403BancoNome = new string[] {""} ;
         BC00136_n403BancoNome = new bool[] {false} ;
         BC00134_A187MunicipioNome = new string[] {""} ;
         BC00134_n187MunicipioNome = new bool[] {false} ;
         BC00134_A189MunicipioUF = new string[] {""} ;
         BC00134_n189MunicipioUF = new bool[] {false} ;
         BC00135_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         BC00135_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         BC00135_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         BC00135_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         BC00137_A924EmpresaRepresentanteProfissao = new int[1] ;
         BC00137_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         BC00139_A249EmpresaId = new int[1] ;
         BC00133_A249EmpresaId = new int[1] ;
         BC00133_A250EmpresaNomeFantasia = new string[] {""} ;
         BC00133_n250EmpresaNomeFantasia = new bool[] {false} ;
         BC00133_A251EmpresaRazaoSocial = new string[] {""} ;
         BC00133_n251EmpresaRazaoSocial = new bool[] {false} ;
         BC00133_A252EmpresaCNPJ = new string[] {""} ;
         BC00133_n252EmpresaCNPJ = new bool[] {false} ;
         BC00133_A253EmpresaSede = new bool[] {false} ;
         BC00133_n253EmpresaSede = new bool[] {false} ;
         BC00133_A465EmpresaAgencia = new int[1] ;
         BC00133_n465EmpresaAgencia = new bool[] {false} ;
         BC00133_A466EmpresaAgenciaDigito = new int[1] ;
         BC00133_n466EmpresaAgenciaDigito = new bool[] {false} ;
         BC00133_A467EmpresaConta = new int[1] ;
         BC00133_n467EmpresaConta = new bool[] {false} ;
         BC00133_A468EmpresaPix = new string[] {""} ;
         BC00133_n468EmpresaPix = new bool[] {false} ;
         BC00133_A469EmpresaPixTipo = new string[] {""} ;
         BC00133_n469EmpresaPixTipo = new bool[] {false} ;
         BC00133_A470EmpresaEmail = new string[] {""} ;
         BC00133_n470EmpresaEmail = new bool[] {false} ;
         BC00133_A610EmpresaLogradouro = new string[] {""} ;
         BC00133_n610EmpresaLogradouro = new bool[] {false} ;
         BC00133_A611EmpresaLogradouroNumero = new long[1] ;
         BC00133_n611EmpresaLogradouroNumero = new bool[] {false} ;
         BC00133_A609EmpresaCEP = new string[] {""} ;
         BC00133_n609EmpresaCEP = new bool[] {false} ;
         BC00133_A612EmpresaBairro = new string[] {""} ;
         BC00133_n612EmpresaBairro = new bool[] {false} ;
         BC00133_A613EmpresaComplemento = new string[] {""} ;
         BC00133_n613EmpresaComplemento = new bool[] {false} ;
         BC00133_A770EmpresaRepresentanteCPF = new string[] {""} ;
         BC00133_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         BC00133_A771EmpresaRepresentanteNome = new string[] {""} ;
         BC00133_n771EmpresaRepresentanteNome = new bool[] {false} ;
         BC00133_A772EmpresaRepresentanteEmail = new string[] {""} ;
         BC00133_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         BC00133_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00133_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00133_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         BC00133_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         BC00133_A929EmpresaRepresentanteNumero = new long[1] ;
         BC00133_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         BC00133_A930EmpresaRepresentanteCEP = new string[] {""} ;
         BC00133_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         BC00133_A931EmpresaRepresentanteBairro = new string[] {""} ;
         BC00133_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         BC00133_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         BC00133_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         BC00133_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         BC00133_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         BC00133_A934EmpresaRepresentanteTelefone = new int[1] ;
         BC00133_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         BC00133_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         BC00133_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         BC00133_A186MunicipioCodigo = new string[] {""} ;
         BC00133_n186MunicipioCodigo = new bool[] {false} ;
         BC00133_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         BC00133_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         BC00133_A464EmpresaBancoId = new int[1] ;
         BC00133_n464EmpresaBancoId = new bool[] {false} ;
         BC00133_A924EmpresaRepresentanteProfissao = new int[1] ;
         BC00133_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         sMode42 = "";
         BC00132_A249EmpresaId = new int[1] ;
         BC00132_A250EmpresaNomeFantasia = new string[] {""} ;
         BC00132_n250EmpresaNomeFantasia = new bool[] {false} ;
         BC00132_A251EmpresaRazaoSocial = new string[] {""} ;
         BC00132_n251EmpresaRazaoSocial = new bool[] {false} ;
         BC00132_A252EmpresaCNPJ = new string[] {""} ;
         BC00132_n252EmpresaCNPJ = new bool[] {false} ;
         BC00132_A253EmpresaSede = new bool[] {false} ;
         BC00132_n253EmpresaSede = new bool[] {false} ;
         BC00132_A465EmpresaAgencia = new int[1] ;
         BC00132_n465EmpresaAgencia = new bool[] {false} ;
         BC00132_A466EmpresaAgenciaDigito = new int[1] ;
         BC00132_n466EmpresaAgenciaDigito = new bool[] {false} ;
         BC00132_A467EmpresaConta = new int[1] ;
         BC00132_n467EmpresaConta = new bool[] {false} ;
         BC00132_A468EmpresaPix = new string[] {""} ;
         BC00132_n468EmpresaPix = new bool[] {false} ;
         BC00132_A469EmpresaPixTipo = new string[] {""} ;
         BC00132_n469EmpresaPixTipo = new bool[] {false} ;
         BC00132_A470EmpresaEmail = new string[] {""} ;
         BC00132_n470EmpresaEmail = new bool[] {false} ;
         BC00132_A610EmpresaLogradouro = new string[] {""} ;
         BC00132_n610EmpresaLogradouro = new bool[] {false} ;
         BC00132_A611EmpresaLogradouroNumero = new long[1] ;
         BC00132_n611EmpresaLogradouroNumero = new bool[] {false} ;
         BC00132_A609EmpresaCEP = new string[] {""} ;
         BC00132_n609EmpresaCEP = new bool[] {false} ;
         BC00132_A612EmpresaBairro = new string[] {""} ;
         BC00132_n612EmpresaBairro = new bool[] {false} ;
         BC00132_A613EmpresaComplemento = new string[] {""} ;
         BC00132_n613EmpresaComplemento = new bool[] {false} ;
         BC00132_A770EmpresaRepresentanteCPF = new string[] {""} ;
         BC00132_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         BC00132_A771EmpresaRepresentanteNome = new string[] {""} ;
         BC00132_n771EmpresaRepresentanteNome = new bool[] {false} ;
         BC00132_A772EmpresaRepresentanteEmail = new string[] {""} ;
         BC00132_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         BC00132_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00132_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC00132_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         BC00132_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         BC00132_A929EmpresaRepresentanteNumero = new long[1] ;
         BC00132_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         BC00132_A930EmpresaRepresentanteCEP = new string[] {""} ;
         BC00132_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         BC00132_A931EmpresaRepresentanteBairro = new string[] {""} ;
         BC00132_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         BC00132_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         BC00132_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         BC00132_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         BC00132_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         BC00132_A934EmpresaRepresentanteTelefone = new int[1] ;
         BC00132_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         BC00132_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         BC00132_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         BC00132_A186MunicipioCodigo = new string[] {""} ;
         BC00132_n186MunicipioCodigo = new bool[] {false} ;
         BC00132_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         BC00132_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         BC00132_A464EmpresaBancoId = new int[1] ;
         BC00132_n464EmpresaBancoId = new bool[] {false} ;
         BC00132_A924EmpresaRepresentanteProfissao = new int[1] ;
         BC00132_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         BC001311_A249EmpresaId = new int[1] ;
         BC001314_A403BancoNome = new string[] {""} ;
         BC001314_n403BancoNome = new bool[] {false} ;
         BC001315_A187MunicipioNome = new string[] {""} ;
         BC001315_n187MunicipioNome = new bool[] {false} ;
         BC001315_A189MunicipioUF = new string[] {""} ;
         BC001315_n189MunicipioUF = new bool[] {false} ;
         BC001316_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         BC001316_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         BC001316_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         BC001316_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         BC001317_A249EmpresaId = new int[1] ;
         BC001317_A250EmpresaNomeFantasia = new string[] {""} ;
         BC001317_n250EmpresaNomeFantasia = new bool[] {false} ;
         BC001317_A251EmpresaRazaoSocial = new string[] {""} ;
         BC001317_n251EmpresaRazaoSocial = new bool[] {false} ;
         BC001317_A252EmpresaCNPJ = new string[] {""} ;
         BC001317_n252EmpresaCNPJ = new bool[] {false} ;
         BC001317_A253EmpresaSede = new bool[] {false} ;
         BC001317_n253EmpresaSede = new bool[] {false} ;
         BC001317_A403BancoNome = new string[] {""} ;
         BC001317_n403BancoNome = new bool[] {false} ;
         BC001317_A465EmpresaAgencia = new int[1] ;
         BC001317_n465EmpresaAgencia = new bool[] {false} ;
         BC001317_A466EmpresaAgenciaDigito = new int[1] ;
         BC001317_n466EmpresaAgenciaDigito = new bool[] {false} ;
         BC001317_A467EmpresaConta = new int[1] ;
         BC001317_n467EmpresaConta = new bool[] {false} ;
         BC001317_A468EmpresaPix = new string[] {""} ;
         BC001317_n468EmpresaPix = new bool[] {false} ;
         BC001317_A469EmpresaPixTipo = new string[] {""} ;
         BC001317_n469EmpresaPixTipo = new bool[] {false} ;
         BC001317_A470EmpresaEmail = new string[] {""} ;
         BC001317_n470EmpresaEmail = new bool[] {false} ;
         BC001317_A610EmpresaLogradouro = new string[] {""} ;
         BC001317_n610EmpresaLogradouro = new bool[] {false} ;
         BC001317_A611EmpresaLogradouroNumero = new long[1] ;
         BC001317_n611EmpresaLogradouroNumero = new bool[] {false} ;
         BC001317_A609EmpresaCEP = new string[] {""} ;
         BC001317_n609EmpresaCEP = new bool[] {false} ;
         BC001317_A612EmpresaBairro = new string[] {""} ;
         BC001317_n612EmpresaBairro = new bool[] {false} ;
         BC001317_A613EmpresaComplemento = new string[] {""} ;
         BC001317_n613EmpresaComplemento = new bool[] {false} ;
         BC001317_A187MunicipioNome = new string[] {""} ;
         BC001317_n187MunicipioNome = new bool[] {false} ;
         BC001317_A189MunicipioUF = new string[] {""} ;
         BC001317_n189MunicipioUF = new bool[] {false} ;
         BC001317_A770EmpresaRepresentanteCPF = new string[] {""} ;
         BC001317_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         BC001317_A771EmpresaRepresentanteNome = new string[] {""} ;
         BC001317_n771EmpresaRepresentanteNome = new bool[] {false} ;
         BC001317_A772EmpresaRepresentanteEmail = new string[] {""} ;
         BC001317_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         BC001317_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC001317_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         BC001317_A928EmpresaRepresentanteLogradouro = new string[] {""} ;
         BC001317_n928EmpresaRepresentanteLogradouro = new bool[] {false} ;
         BC001317_A929EmpresaRepresentanteNumero = new long[1] ;
         BC001317_n929EmpresaRepresentanteNumero = new bool[] {false} ;
         BC001317_A930EmpresaRepresentanteCEP = new string[] {""} ;
         BC001317_n930EmpresaRepresentanteCEP = new bool[] {false} ;
         BC001317_A931EmpresaRepresentanteBairro = new string[] {""} ;
         BC001317_n931EmpresaRepresentanteBairro = new bool[] {false} ;
         BC001317_A932EmpresaRepresentanteComplemento = new string[] {""} ;
         BC001317_n932EmpresaRepresentanteComplemento = new bool[] {false} ;
         BC001317_A926EmpresaRepresentanteMunicipioNome = new string[] {""} ;
         BC001317_n926EmpresaRepresentanteMunicipioNome = new bool[] {false} ;
         BC001317_A927EmpresaRepresentanteMunicipioUF = new string[] {""} ;
         BC001317_n927EmpresaRepresentanteMunicipioUF = new bool[] {false} ;
         BC001317_A933EmpresaRepresentanteNacionalidade = new string[] {""} ;
         BC001317_n933EmpresaRepresentanteNacionalidade = new bool[] {false} ;
         BC001317_A934EmpresaRepresentanteTelefone = new int[1] ;
         BC001317_n934EmpresaRepresentanteTelefone = new bool[] {false} ;
         BC001317_A935EmpresaRepresentanteTelefoneDDD = new short[1] ;
         BC001317_n935EmpresaRepresentanteTelefoneDDD = new bool[] {false} ;
         BC001317_A186MunicipioCodigo = new string[] {""} ;
         BC001317_n186MunicipioCodigo = new bool[] {false} ;
         BC001317_A925EmpresaRepresentanteMunicipio = new string[] {""} ;
         BC001317_n925EmpresaRepresentanteMunicipio = new bool[] {false} ;
         BC001317_A464EmpresaBancoId = new int[1] ;
         BC001317_n464EmpresaBancoId = new bool[] {false} ;
         BC001317_A924EmpresaRepresentanteProfissao = new int[1] ;
         BC001317_n924EmpresaRepresentanteProfissao = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empresa_bc__default(),
            new Object[][] {
                new Object[] {
               BC00132_A249EmpresaId, BC00132_A250EmpresaNomeFantasia, BC00132_n250EmpresaNomeFantasia, BC00132_A251EmpresaRazaoSocial, BC00132_n251EmpresaRazaoSocial, BC00132_A252EmpresaCNPJ, BC00132_n252EmpresaCNPJ, BC00132_A253EmpresaSede, BC00132_n253EmpresaSede, BC00132_A465EmpresaAgencia,
               BC00132_n465EmpresaAgencia, BC00132_A466EmpresaAgenciaDigito, BC00132_n466EmpresaAgenciaDigito, BC00132_A467EmpresaConta, BC00132_n467EmpresaConta, BC00132_A468EmpresaPix, BC00132_n468EmpresaPix, BC00132_A469EmpresaPixTipo, BC00132_n469EmpresaPixTipo, BC00132_A470EmpresaEmail,
               BC00132_n470EmpresaEmail, BC00132_A610EmpresaLogradouro, BC00132_n610EmpresaLogradouro, BC00132_A611EmpresaLogradouroNumero, BC00132_n611EmpresaLogradouroNumero, BC00132_A609EmpresaCEP, BC00132_n609EmpresaCEP, BC00132_A612EmpresaBairro, BC00132_n612EmpresaBairro, BC00132_A613EmpresaComplemento,
               BC00132_n613EmpresaComplemento, BC00132_A770EmpresaRepresentanteCPF, BC00132_n770EmpresaRepresentanteCPF, BC00132_A771EmpresaRepresentanteNome, BC00132_n771EmpresaRepresentanteNome, BC00132_A772EmpresaRepresentanteEmail, BC00132_n772EmpresaRepresentanteEmail, BC00132_A773EmpresaUtilizaRepresentanteAssinatura, BC00132_n773EmpresaUtilizaRepresentanteAssinatura, BC00132_A928EmpresaRepresentanteLogradouro,
               BC00132_n928EmpresaRepresentanteLogradouro, BC00132_A929EmpresaRepresentanteNumero, BC00132_n929EmpresaRepresentanteNumero, BC00132_A930EmpresaRepresentanteCEP, BC00132_n930EmpresaRepresentanteCEP, BC00132_A931EmpresaRepresentanteBairro, BC00132_n931EmpresaRepresentanteBairro, BC00132_A932EmpresaRepresentanteComplemento, BC00132_n932EmpresaRepresentanteComplemento, BC00132_A933EmpresaRepresentanteNacionalidade,
               BC00132_n933EmpresaRepresentanteNacionalidade, BC00132_A934EmpresaRepresentanteTelefone, BC00132_n934EmpresaRepresentanteTelefone, BC00132_A935EmpresaRepresentanteTelefoneDDD, BC00132_n935EmpresaRepresentanteTelefoneDDD, BC00132_A186MunicipioCodigo, BC00132_n186MunicipioCodigo, BC00132_A925EmpresaRepresentanteMunicipio, BC00132_n925EmpresaRepresentanteMunicipio, BC00132_A464EmpresaBancoId,
               BC00132_n464EmpresaBancoId, BC00132_A924EmpresaRepresentanteProfissao, BC00132_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               BC00133_A249EmpresaId, BC00133_A250EmpresaNomeFantasia, BC00133_n250EmpresaNomeFantasia, BC00133_A251EmpresaRazaoSocial, BC00133_n251EmpresaRazaoSocial, BC00133_A252EmpresaCNPJ, BC00133_n252EmpresaCNPJ, BC00133_A253EmpresaSede, BC00133_n253EmpresaSede, BC00133_A465EmpresaAgencia,
               BC00133_n465EmpresaAgencia, BC00133_A466EmpresaAgenciaDigito, BC00133_n466EmpresaAgenciaDigito, BC00133_A467EmpresaConta, BC00133_n467EmpresaConta, BC00133_A468EmpresaPix, BC00133_n468EmpresaPix, BC00133_A469EmpresaPixTipo, BC00133_n469EmpresaPixTipo, BC00133_A470EmpresaEmail,
               BC00133_n470EmpresaEmail, BC00133_A610EmpresaLogradouro, BC00133_n610EmpresaLogradouro, BC00133_A611EmpresaLogradouroNumero, BC00133_n611EmpresaLogradouroNumero, BC00133_A609EmpresaCEP, BC00133_n609EmpresaCEP, BC00133_A612EmpresaBairro, BC00133_n612EmpresaBairro, BC00133_A613EmpresaComplemento,
               BC00133_n613EmpresaComplemento, BC00133_A770EmpresaRepresentanteCPF, BC00133_n770EmpresaRepresentanteCPF, BC00133_A771EmpresaRepresentanteNome, BC00133_n771EmpresaRepresentanteNome, BC00133_A772EmpresaRepresentanteEmail, BC00133_n772EmpresaRepresentanteEmail, BC00133_A773EmpresaUtilizaRepresentanteAssinatura, BC00133_n773EmpresaUtilizaRepresentanteAssinatura, BC00133_A928EmpresaRepresentanteLogradouro,
               BC00133_n928EmpresaRepresentanteLogradouro, BC00133_A929EmpresaRepresentanteNumero, BC00133_n929EmpresaRepresentanteNumero, BC00133_A930EmpresaRepresentanteCEP, BC00133_n930EmpresaRepresentanteCEP, BC00133_A931EmpresaRepresentanteBairro, BC00133_n931EmpresaRepresentanteBairro, BC00133_A932EmpresaRepresentanteComplemento, BC00133_n932EmpresaRepresentanteComplemento, BC00133_A933EmpresaRepresentanteNacionalidade,
               BC00133_n933EmpresaRepresentanteNacionalidade, BC00133_A934EmpresaRepresentanteTelefone, BC00133_n934EmpresaRepresentanteTelefone, BC00133_A935EmpresaRepresentanteTelefoneDDD, BC00133_n935EmpresaRepresentanteTelefoneDDD, BC00133_A186MunicipioCodigo, BC00133_n186MunicipioCodigo, BC00133_A925EmpresaRepresentanteMunicipio, BC00133_n925EmpresaRepresentanteMunicipio, BC00133_A464EmpresaBancoId,
               BC00133_n464EmpresaBancoId, BC00133_A924EmpresaRepresentanteProfissao, BC00133_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               BC00134_A187MunicipioNome, BC00134_n187MunicipioNome, BC00134_A189MunicipioUF, BC00134_n189MunicipioUF
               }
               , new Object[] {
               BC00135_A926EmpresaRepresentanteMunicipioNome, BC00135_n926EmpresaRepresentanteMunicipioNome, BC00135_A927EmpresaRepresentanteMunicipioUF, BC00135_n927EmpresaRepresentanteMunicipioUF
               }
               , new Object[] {
               BC00136_A403BancoNome, BC00136_n403BancoNome
               }
               , new Object[] {
               BC00137_A924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               BC00138_A249EmpresaId, BC00138_A250EmpresaNomeFantasia, BC00138_n250EmpresaNomeFantasia, BC00138_A251EmpresaRazaoSocial, BC00138_n251EmpresaRazaoSocial, BC00138_A252EmpresaCNPJ, BC00138_n252EmpresaCNPJ, BC00138_A253EmpresaSede, BC00138_n253EmpresaSede, BC00138_A403BancoNome,
               BC00138_n403BancoNome, BC00138_A465EmpresaAgencia, BC00138_n465EmpresaAgencia, BC00138_A466EmpresaAgenciaDigito, BC00138_n466EmpresaAgenciaDigito, BC00138_A467EmpresaConta, BC00138_n467EmpresaConta, BC00138_A468EmpresaPix, BC00138_n468EmpresaPix, BC00138_A469EmpresaPixTipo,
               BC00138_n469EmpresaPixTipo, BC00138_A470EmpresaEmail, BC00138_n470EmpresaEmail, BC00138_A610EmpresaLogradouro, BC00138_n610EmpresaLogradouro, BC00138_A611EmpresaLogradouroNumero, BC00138_n611EmpresaLogradouroNumero, BC00138_A609EmpresaCEP, BC00138_n609EmpresaCEP, BC00138_A612EmpresaBairro,
               BC00138_n612EmpresaBairro, BC00138_A613EmpresaComplemento, BC00138_n613EmpresaComplemento, BC00138_A187MunicipioNome, BC00138_n187MunicipioNome, BC00138_A189MunicipioUF, BC00138_n189MunicipioUF, BC00138_A770EmpresaRepresentanteCPF, BC00138_n770EmpresaRepresentanteCPF, BC00138_A771EmpresaRepresentanteNome,
               BC00138_n771EmpresaRepresentanteNome, BC00138_A772EmpresaRepresentanteEmail, BC00138_n772EmpresaRepresentanteEmail, BC00138_A773EmpresaUtilizaRepresentanteAssinatura, BC00138_n773EmpresaUtilizaRepresentanteAssinatura, BC00138_A928EmpresaRepresentanteLogradouro, BC00138_n928EmpresaRepresentanteLogradouro, BC00138_A929EmpresaRepresentanteNumero, BC00138_n929EmpresaRepresentanteNumero, BC00138_A930EmpresaRepresentanteCEP,
               BC00138_n930EmpresaRepresentanteCEP, BC00138_A931EmpresaRepresentanteBairro, BC00138_n931EmpresaRepresentanteBairro, BC00138_A932EmpresaRepresentanteComplemento, BC00138_n932EmpresaRepresentanteComplemento, BC00138_A926EmpresaRepresentanteMunicipioNome, BC00138_n926EmpresaRepresentanteMunicipioNome, BC00138_A927EmpresaRepresentanteMunicipioUF, BC00138_n927EmpresaRepresentanteMunicipioUF, BC00138_A933EmpresaRepresentanteNacionalidade,
               BC00138_n933EmpresaRepresentanteNacionalidade, BC00138_A934EmpresaRepresentanteTelefone, BC00138_n934EmpresaRepresentanteTelefone, BC00138_A935EmpresaRepresentanteTelefoneDDD, BC00138_n935EmpresaRepresentanteTelefoneDDD, BC00138_A186MunicipioCodigo, BC00138_n186MunicipioCodigo, BC00138_A925EmpresaRepresentanteMunicipio, BC00138_n925EmpresaRepresentanteMunicipio, BC00138_A464EmpresaBancoId,
               BC00138_n464EmpresaBancoId, BC00138_A924EmpresaRepresentanteProfissao, BC00138_n924EmpresaRepresentanteProfissao
               }
               , new Object[] {
               BC00139_A249EmpresaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001311_A249EmpresaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001314_A403BancoNome, BC001314_n403BancoNome
               }
               , new Object[] {
               BC001315_A187MunicipioNome, BC001315_n187MunicipioNome, BC001315_A189MunicipioUF, BC001315_n189MunicipioUF
               }
               , new Object[] {
               BC001316_A926EmpresaRepresentanteMunicipioNome, BC001316_n926EmpresaRepresentanteMunicipioNome, BC001316_A927EmpresaRepresentanteMunicipioUF, BC001316_n927EmpresaRepresentanteMunicipioUF
               }
               , new Object[] {
               BC001317_A249EmpresaId, BC001317_A250EmpresaNomeFantasia, BC001317_n250EmpresaNomeFantasia, BC001317_A251EmpresaRazaoSocial, BC001317_n251EmpresaRazaoSocial, BC001317_A252EmpresaCNPJ, BC001317_n252EmpresaCNPJ, BC001317_A253EmpresaSede, BC001317_n253EmpresaSede, BC001317_A403BancoNome,
               BC001317_n403BancoNome, BC001317_A465EmpresaAgencia, BC001317_n465EmpresaAgencia, BC001317_A466EmpresaAgenciaDigito, BC001317_n466EmpresaAgenciaDigito, BC001317_A467EmpresaConta, BC001317_n467EmpresaConta, BC001317_A468EmpresaPix, BC001317_n468EmpresaPix, BC001317_A469EmpresaPixTipo,
               BC001317_n469EmpresaPixTipo, BC001317_A470EmpresaEmail, BC001317_n470EmpresaEmail, BC001317_A610EmpresaLogradouro, BC001317_n610EmpresaLogradouro, BC001317_A611EmpresaLogradouroNumero, BC001317_n611EmpresaLogradouroNumero, BC001317_A609EmpresaCEP, BC001317_n609EmpresaCEP, BC001317_A612EmpresaBairro,
               BC001317_n612EmpresaBairro, BC001317_A613EmpresaComplemento, BC001317_n613EmpresaComplemento, BC001317_A187MunicipioNome, BC001317_n187MunicipioNome, BC001317_A189MunicipioUF, BC001317_n189MunicipioUF, BC001317_A770EmpresaRepresentanteCPF, BC001317_n770EmpresaRepresentanteCPF, BC001317_A771EmpresaRepresentanteNome,
               BC001317_n771EmpresaRepresentanteNome, BC001317_A772EmpresaRepresentanteEmail, BC001317_n772EmpresaRepresentanteEmail, BC001317_A773EmpresaUtilizaRepresentanteAssinatura, BC001317_n773EmpresaUtilizaRepresentanteAssinatura, BC001317_A928EmpresaRepresentanteLogradouro, BC001317_n928EmpresaRepresentanteLogradouro, BC001317_A929EmpresaRepresentanteNumero, BC001317_n929EmpresaRepresentanteNumero, BC001317_A930EmpresaRepresentanteCEP,
               BC001317_n930EmpresaRepresentanteCEP, BC001317_A931EmpresaRepresentanteBairro, BC001317_n931EmpresaRepresentanteBairro, BC001317_A932EmpresaRepresentanteComplemento, BC001317_n932EmpresaRepresentanteComplemento, BC001317_A926EmpresaRepresentanteMunicipioNome, BC001317_n926EmpresaRepresentanteMunicipioNome, BC001317_A927EmpresaRepresentanteMunicipioUF, BC001317_n927EmpresaRepresentanteMunicipioUF, BC001317_A933EmpresaRepresentanteNacionalidade,
               BC001317_n933EmpresaRepresentanteNacionalidade, BC001317_A934EmpresaRepresentanteTelefone, BC001317_n934EmpresaRepresentanteTelefone, BC001317_A935EmpresaRepresentanteTelefoneDDD, BC001317_n935EmpresaRepresentanteTelefoneDDD, BC001317_A186MunicipioCodigo, BC001317_n186MunicipioCodigo, BC001317_A925EmpresaRepresentanteMunicipio, BC001317_n925EmpresaRepresentanteMunicipio, BC001317_A464EmpresaBancoId,
               BC001317_n464EmpresaBancoId, BC001317_A924EmpresaRepresentanteProfissao, BC001317_n924EmpresaRepresentanteProfissao
               }
            }
         );
         AV16Pgmname = "Empresa_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12132 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z935EmpresaRepresentanteTelefoneDDD ;
      private short A935EmpresaRepresentanteTelefoneDDD ;
      private short RcdFound42 ;
      private int trnEnded ;
      private int Z249EmpresaId ;
      private int A249EmpresaId ;
      private int AV17GXV1 ;
      private int AV11Insert_EmpresaBancoId ;
      private int AV15Insert_EmpresaRepresentanteProfissao ;
      private int Z465EmpresaAgencia ;
      private int A465EmpresaAgencia ;
      private int Z466EmpresaAgenciaDigito ;
      private int A466EmpresaAgenciaDigito ;
      private int Z467EmpresaConta ;
      private int A467EmpresaConta ;
      private int Z934EmpresaRepresentanteTelefone ;
      private int A934EmpresaRepresentanteTelefone ;
      private int Z464EmpresaBancoId ;
      private int A464EmpresaBancoId ;
      private int Z924EmpresaRepresentanteProfissao ;
      private int A924EmpresaRepresentanteProfissao ;
      private long Z611EmpresaLogradouroNumero ;
      private long A611EmpresaLogradouroNumero ;
      private long Z929EmpresaRepresentanteNumero ;
      private long A929EmpresaRepresentanteNumero ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV16Pgmname ;
      private string sMode42 ;
      private bool returnInSub ;
      private bool Z253EmpresaSede ;
      private bool A253EmpresaSede ;
      private bool Z773EmpresaUtilizaRepresentanteAssinatura ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n250EmpresaNomeFantasia ;
      private bool n251EmpresaRazaoSocial ;
      private bool n252EmpresaCNPJ ;
      private bool n253EmpresaSede ;
      private bool n403BancoNome ;
      private bool n465EmpresaAgencia ;
      private bool n466EmpresaAgenciaDigito ;
      private bool n467EmpresaConta ;
      private bool n468EmpresaPix ;
      private bool n469EmpresaPixTipo ;
      private bool n470EmpresaEmail ;
      private bool n610EmpresaLogradouro ;
      private bool n611EmpresaLogradouroNumero ;
      private bool n609EmpresaCEP ;
      private bool n612EmpresaBairro ;
      private bool n613EmpresaComplemento ;
      private bool n187MunicipioNome ;
      private bool n189MunicipioUF ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n928EmpresaRepresentanteLogradouro ;
      private bool n929EmpresaRepresentanteNumero ;
      private bool n930EmpresaRepresentanteCEP ;
      private bool n931EmpresaRepresentanteBairro ;
      private bool n932EmpresaRepresentanteComplemento ;
      private bool n926EmpresaRepresentanteMunicipioNome ;
      private bool n927EmpresaRepresentanteMunicipioUF ;
      private bool n933EmpresaRepresentanteNacionalidade ;
      private bool n934EmpresaRepresentanteTelefone ;
      private bool n935EmpresaRepresentanteTelefoneDDD ;
      private bool n186MunicipioCodigo ;
      private bool n925EmpresaRepresentanteMunicipio ;
      private bool n464EmpresaBancoId ;
      private bool n924EmpresaRepresentanteProfissao ;
      private bool Gx_longc ;
      private string AV13Insert_MunicipioCodigo ;
      private string AV14Insert_EmpresaRepresentanteMunicipio ;
      private string Z250EmpresaNomeFantasia ;
      private string A250EmpresaNomeFantasia ;
      private string Z251EmpresaRazaoSocial ;
      private string A251EmpresaRazaoSocial ;
      private string Z252EmpresaCNPJ ;
      private string A252EmpresaCNPJ ;
      private string Z468EmpresaPix ;
      private string A468EmpresaPix ;
      private string Z469EmpresaPixTipo ;
      private string A469EmpresaPixTipo ;
      private string Z470EmpresaEmail ;
      private string A470EmpresaEmail ;
      private string Z610EmpresaLogradouro ;
      private string A610EmpresaLogradouro ;
      private string Z609EmpresaCEP ;
      private string A609EmpresaCEP ;
      private string Z612EmpresaBairro ;
      private string A612EmpresaBairro ;
      private string Z613EmpresaComplemento ;
      private string A613EmpresaComplemento ;
      private string Z770EmpresaRepresentanteCPF ;
      private string A770EmpresaRepresentanteCPF ;
      private string Z771EmpresaRepresentanteNome ;
      private string A771EmpresaRepresentanteNome ;
      private string Z772EmpresaRepresentanteEmail ;
      private string A772EmpresaRepresentanteEmail ;
      private string Z928EmpresaRepresentanteLogradouro ;
      private string A928EmpresaRepresentanteLogradouro ;
      private string Z930EmpresaRepresentanteCEP ;
      private string A930EmpresaRepresentanteCEP ;
      private string Z931EmpresaRepresentanteBairro ;
      private string A931EmpresaRepresentanteBairro ;
      private string Z932EmpresaRepresentanteComplemento ;
      private string A932EmpresaRepresentanteComplemento ;
      private string Z933EmpresaRepresentanteNacionalidade ;
      private string A933EmpresaRepresentanteNacionalidade ;
      private string Z186MunicipioCodigo ;
      private string A186MunicipioCodigo ;
      private string Z925EmpresaRepresentanteMunicipio ;
      private string A925EmpresaRepresentanteMunicipio ;
      private string Z187MunicipioNome ;
      private string A187MunicipioNome ;
      private string Z189MunicipioUF ;
      private string A189MunicipioUF ;
      private string Z926EmpresaRepresentanteMunicipioNome ;
      private string A926EmpresaRepresentanteMunicipioNome ;
      private string Z927EmpresaRepresentanteMunicipioUF ;
      private string A927EmpresaRepresentanteMunicipioUF ;
      private string Z403BancoNome ;
      private string A403BancoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00138_A249EmpresaId ;
      private string[] BC00138_A250EmpresaNomeFantasia ;
      private bool[] BC00138_n250EmpresaNomeFantasia ;
      private string[] BC00138_A251EmpresaRazaoSocial ;
      private bool[] BC00138_n251EmpresaRazaoSocial ;
      private string[] BC00138_A252EmpresaCNPJ ;
      private bool[] BC00138_n252EmpresaCNPJ ;
      private bool[] BC00138_A253EmpresaSede ;
      private bool[] BC00138_n253EmpresaSede ;
      private string[] BC00138_A403BancoNome ;
      private bool[] BC00138_n403BancoNome ;
      private int[] BC00138_A465EmpresaAgencia ;
      private bool[] BC00138_n465EmpresaAgencia ;
      private int[] BC00138_A466EmpresaAgenciaDigito ;
      private bool[] BC00138_n466EmpresaAgenciaDigito ;
      private int[] BC00138_A467EmpresaConta ;
      private bool[] BC00138_n467EmpresaConta ;
      private string[] BC00138_A468EmpresaPix ;
      private bool[] BC00138_n468EmpresaPix ;
      private string[] BC00138_A469EmpresaPixTipo ;
      private bool[] BC00138_n469EmpresaPixTipo ;
      private string[] BC00138_A470EmpresaEmail ;
      private bool[] BC00138_n470EmpresaEmail ;
      private string[] BC00138_A610EmpresaLogradouro ;
      private bool[] BC00138_n610EmpresaLogradouro ;
      private long[] BC00138_A611EmpresaLogradouroNumero ;
      private bool[] BC00138_n611EmpresaLogradouroNumero ;
      private string[] BC00138_A609EmpresaCEP ;
      private bool[] BC00138_n609EmpresaCEP ;
      private string[] BC00138_A612EmpresaBairro ;
      private bool[] BC00138_n612EmpresaBairro ;
      private string[] BC00138_A613EmpresaComplemento ;
      private bool[] BC00138_n613EmpresaComplemento ;
      private string[] BC00138_A187MunicipioNome ;
      private bool[] BC00138_n187MunicipioNome ;
      private string[] BC00138_A189MunicipioUF ;
      private bool[] BC00138_n189MunicipioUF ;
      private string[] BC00138_A770EmpresaRepresentanteCPF ;
      private bool[] BC00138_n770EmpresaRepresentanteCPF ;
      private string[] BC00138_A771EmpresaRepresentanteNome ;
      private bool[] BC00138_n771EmpresaRepresentanteNome ;
      private string[] BC00138_A772EmpresaRepresentanteEmail ;
      private bool[] BC00138_n772EmpresaRepresentanteEmail ;
      private bool[] BC00138_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] BC00138_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] BC00138_A928EmpresaRepresentanteLogradouro ;
      private bool[] BC00138_n928EmpresaRepresentanteLogradouro ;
      private long[] BC00138_A929EmpresaRepresentanteNumero ;
      private bool[] BC00138_n929EmpresaRepresentanteNumero ;
      private string[] BC00138_A930EmpresaRepresentanteCEP ;
      private bool[] BC00138_n930EmpresaRepresentanteCEP ;
      private string[] BC00138_A931EmpresaRepresentanteBairro ;
      private bool[] BC00138_n931EmpresaRepresentanteBairro ;
      private string[] BC00138_A932EmpresaRepresentanteComplemento ;
      private bool[] BC00138_n932EmpresaRepresentanteComplemento ;
      private string[] BC00138_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] BC00138_n926EmpresaRepresentanteMunicipioNome ;
      private string[] BC00138_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] BC00138_n927EmpresaRepresentanteMunicipioUF ;
      private string[] BC00138_A933EmpresaRepresentanteNacionalidade ;
      private bool[] BC00138_n933EmpresaRepresentanteNacionalidade ;
      private int[] BC00138_A934EmpresaRepresentanteTelefone ;
      private bool[] BC00138_n934EmpresaRepresentanteTelefone ;
      private short[] BC00138_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] BC00138_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] BC00138_A186MunicipioCodigo ;
      private bool[] BC00138_n186MunicipioCodigo ;
      private string[] BC00138_A925EmpresaRepresentanteMunicipio ;
      private bool[] BC00138_n925EmpresaRepresentanteMunicipio ;
      private int[] BC00138_A464EmpresaBancoId ;
      private bool[] BC00138_n464EmpresaBancoId ;
      private int[] BC00138_A924EmpresaRepresentanteProfissao ;
      private bool[] BC00138_n924EmpresaRepresentanteProfissao ;
      private string[] BC00136_A403BancoNome ;
      private bool[] BC00136_n403BancoNome ;
      private string[] BC00134_A187MunicipioNome ;
      private bool[] BC00134_n187MunicipioNome ;
      private string[] BC00134_A189MunicipioUF ;
      private bool[] BC00134_n189MunicipioUF ;
      private string[] BC00135_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] BC00135_n926EmpresaRepresentanteMunicipioNome ;
      private string[] BC00135_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] BC00135_n927EmpresaRepresentanteMunicipioUF ;
      private int[] BC00137_A924EmpresaRepresentanteProfissao ;
      private bool[] BC00137_n924EmpresaRepresentanteProfissao ;
      private int[] BC00139_A249EmpresaId ;
      private int[] BC00133_A249EmpresaId ;
      private string[] BC00133_A250EmpresaNomeFantasia ;
      private bool[] BC00133_n250EmpresaNomeFantasia ;
      private string[] BC00133_A251EmpresaRazaoSocial ;
      private bool[] BC00133_n251EmpresaRazaoSocial ;
      private string[] BC00133_A252EmpresaCNPJ ;
      private bool[] BC00133_n252EmpresaCNPJ ;
      private bool[] BC00133_A253EmpresaSede ;
      private bool[] BC00133_n253EmpresaSede ;
      private int[] BC00133_A465EmpresaAgencia ;
      private bool[] BC00133_n465EmpresaAgencia ;
      private int[] BC00133_A466EmpresaAgenciaDigito ;
      private bool[] BC00133_n466EmpresaAgenciaDigito ;
      private int[] BC00133_A467EmpresaConta ;
      private bool[] BC00133_n467EmpresaConta ;
      private string[] BC00133_A468EmpresaPix ;
      private bool[] BC00133_n468EmpresaPix ;
      private string[] BC00133_A469EmpresaPixTipo ;
      private bool[] BC00133_n469EmpresaPixTipo ;
      private string[] BC00133_A470EmpresaEmail ;
      private bool[] BC00133_n470EmpresaEmail ;
      private string[] BC00133_A610EmpresaLogradouro ;
      private bool[] BC00133_n610EmpresaLogradouro ;
      private long[] BC00133_A611EmpresaLogradouroNumero ;
      private bool[] BC00133_n611EmpresaLogradouroNumero ;
      private string[] BC00133_A609EmpresaCEP ;
      private bool[] BC00133_n609EmpresaCEP ;
      private string[] BC00133_A612EmpresaBairro ;
      private bool[] BC00133_n612EmpresaBairro ;
      private string[] BC00133_A613EmpresaComplemento ;
      private bool[] BC00133_n613EmpresaComplemento ;
      private string[] BC00133_A770EmpresaRepresentanteCPF ;
      private bool[] BC00133_n770EmpresaRepresentanteCPF ;
      private string[] BC00133_A771EmpresaRepresentanteNome ;
      private bool[] BC00133_n771EmpresaRepresentanteNome ;
      private string[] BC00133_A772EmpresaRepresentanteEmail ;
      private bool[] BC00133_n772EmpresaRepresentanteEmail ;
      private bool[] BC00133_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] BC00133_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] BC00133_A928EmpresaRepresentanteLogradouro ;
      private bool[] BC00133_n928EmpresaRepresentanteLogradouro ;
      private long[] BC00133_A929EmpresaRepresentanteNumero ;
      private bool[] BC00133_n929EmpresaRepresentanteNumero ;
      private string[] BC00133_A930EmpresaRepresentanteCEP ;
      private bool[] BC00133_n930EmpresaRepresentanteCEP ;
      private string[] BC00133_A931EmpresaRepresentanteBairro ;
      private bool[] BC00133_n931EmpresaRepresentanteBairro ;
      private string[] BC00133_A932EmpresaRepresentanteComplemento ;
      private bool[] BC00133_n932EmpresaRepresentanteComplemento ;
      private string[] BC00133_A933EmpresaRepresentanteNacionalidade ;
      private bool[] BC00133_n933EmpresaRepresentanteNacionalidade ;
      private int[] BC00133_A934EmpresaRepresentanteTelefone ;
      private bool[] BC00133_n934EmpresaRepresentanteTelefone ;
      private short[] BC00133_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] BC00133_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] BC00133_A186MunicipioCodigo ;
      private bool[] BC00133_n186MunicipioCodigo ;
      private string[] BC00133_A925EmpresaRepresentanteMunicipio ;
      private bool[] BC00133_n925EmpresaRepresentanteMunicipio ;
      private int[] BC00133_A464EmpresaBancoId ;
      private bool[] BC00133_n464EmpresaBancoId ;
      private int[] BC00133_A924EmpresaRepresentanteProfissao ;
      private bool[] BC00133_n924EmpresaRepresentanteProfissao ;
      private int[] BC00132_A249EmpresaId ;
      private string[] BC00132_A250EmpresaNomeFantasia ;
      private bool[] BC00132_n250EmpresaNomeFantasia ;
      private string[] BC00132_A251EmpresaRazaoSocial ;
      private bool[] BC00132_n251EmpresaRazaoSocial ;
      private string[] BC00132_A252EmpresaCNPJ ;
      private bool[] BC00132_n252EmpresaCNPJ ;
      private bool[] BC00132_A253EmpresaSede ;
      private bool[] BC00132_n253EmpresaSede ;
      private int[] BC00132_A465EmpresaAgencia ;
      private bool[] BC00132_n465EmpresaAgencia ;
      private int[] BC00132_A466EmpresaAgenciaDigito ;
      private bool[] BC00132_n466EmpresaAgenciaDigito ;
      private int[] BC00132_A467EmpresaConta ;
      private bool[] BC00132_n467EmpresaConta ;
      private string[] BC00132_A468EmpresaPix ;
      private bool[] BC00132_n468EmpresaPix ;
      private string[] BC00132_A469EmpresaPixTipo ;
      private bool[] BC00132_n469EmpresaPixTipo ;
      private string[] BC00132_A470EmpresaEmail ;
      private bool[] BC00132_n470EmpresaEmail ;
      private string[] BC00132_A610EmpresaLogradouro ;
      private bool[] BC00132_n610EmpresaLogradouro ;
      private long[] BC00132_A611EmpresaLogradouroNumero ;
      private bool[] BC00132_n611EmpresaLogradouroNumero ;
      private string[] BC00132_A609EmpresaCEP ;
      private bool[] BC00132_n609EmpresaCEP ;
      private string[] BC00132_A612EmpresaBairro ;
      private bool[] BC00132_n612EmpresaBairro ;
      private string[] BC00132_A613EmpresaComplemento ;
      private bool[] BC00132_n613EmpresaComplemento ;
      private string[] BC00132_A770EmpresaRepresentanteCPF ;
      private bool[] BC00132_n770EmpresaRepresentanteCPF ;
      private string[] BC00132_A771EmpresaRepresentanteNome ;
      private bool[] BC00132_n771EmpresaRepresentanteNome ;
      private string[] BC00132_A772EmpresaRepresentanteEmail ;
      private bool[] BC00132_n772EmpresaRepresentanteEmail ;
      private bool[] BC00132_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] BC00132_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] BC00132_A928EmpresaRepresentanteLogradouro ;
      private bool[] BC00132_n928EmpresaRepresentanteLogradouro ;
      private long[] BC00132_A929EmpresaRepresentanteNumero ;
      private bool[] BC00132_n929EmpresaRepresentanteNumero ;
      private string[] BC00132_A930EmpresaRepresentanteCEP ;
      private bool[] BC00132_n930EmpresaRepresentanteCEP ;
      private string[] BC00132_A931EmpresaRepresentanteBairro ;
      private bool[] BC00132_n931EmpresaRepresentanteBairro ;
      private string[] BC00132_A932EmpresaRepresentanteComplemento ;
      private bool[] BC00132_n932EmpresaRepresentanteComplemento ;
      private string[] BC00132_A933EmpresaRepresentanteNacionalidade ;
      private bool[] BC00132_n933EmpresaRepresentanteNacionalidade ;
      private int[] BC00132_A934EmpresaRepresentanteTelefone ;
      private bool[] BC00132_n934EmpresaRepresentanteTelefone ;
      private short[] BC00132_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] BC00132_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] BC00132_A186MunicipioCodigo ;
      private bool[] BC00132_n186MunicipioCodigo ;
      private string[] BC00132_A925EmpresaRepresentanteMunicipio ;
      private bool[] BC00132_n925EmpresaRepresentanteMunicipio ;
      private int[] BC00132_A464EmpresaBancoId ;
      private bool[] BC00132_n464EmpresaBancoId ;
      private int[] BC00132_A924EmpresaRepresentanteProfissao ;
      private bool[] BC00132_n924EmpresaRepresentanteProfissao ;
      private int[] BC001311_A249EmpresaId ;
      private string[] BC001314_A403BancoNome ;
      private bool[] BC001314_n403BancoNome ;
      private string[] BC001315_A187MunicipioNome ;
      private bool[] BC001315_n187MunicipioNome ;
      private string[] BC001315_A189MunicipioUF ;
      private bool[] BC001315_n189MunicipioUF ;
      private string[] BC001316_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] BC001316_n926EmpresaRepresentanteMunicipioNome ;
      private string[] BC001316_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] BC001316_n927EmpresaRepresentanteMunicipioUF ;
      private int[] BC001317_A249EmpresaId ;
      private string[] BC001317_A250EmpresaNomeFantasia ;
      private bool[] BC001317_n250EmpresaNomeFantasia ;
      private string[] BC001317_A251EmpresaRazaoSocial ;
      private bool[] BC001317_n251EmpresaRazaoSocial ;
      private string[] BC001317_A252EmpresaCNPJ ;
      private bool[] BC001317_n252EmpresaCNPJ ;
      private bool[] BC001317_A253EmpresaSede ;
      private bool[] BC001317_n253EmpresaSede ;
      private string[] BC001317_A403BancoNome ;
      private bool[] BC001317_n403BancoNome ;
      private int[] BC001317_A465EmpresaAgencia ;
      private bool[] BC001317_n465EmpresaAgencia ;
      private int[] BC001317_A466EmpresaAgenciaDigito ;
      private bool[] BC001317_n466EmpresaAgenciaDigito ;
      private int[] BC001317_A467EmpresaConta ;
      private bool[] BC001317_n467EmpresaConta ;
      private string[] BC001317_A468EmpresaPix ;
      private bool[] BC001317_n468EmpresaPix ;
      private string[] BC001317_A469EmpresaPixTipo ;
      private bool[] BC001317_n469EmpresaPixTipo ;
      private string[] BC001317_A470EmpresaEmail ;
      private bool[] BC001317_n470EmpresaEmail ;
      private string[] BC001317_A610EmpresaLogradouro ;
      private bool[] BC001317_n610EmpresaLogradouro ;
      private long[] BC001317_A611EmpresaLogradouroNumero ;
      private bool[] BC001317_n611EmpresaLogradouroNumero ;
      private string[] BC001317_A609EmpresaCEP ;
      private bool[] BC001317_n609EmpresaCEP ;
      private string[] BC001317_A612EmpresaBairro ;
      private bool[] BC001317_n612EmpresaBairro ;
      private string[] BC001317_A613EmpresaComplemento ;
      private bool[] BC001317_n613EmpresaComplemento ;
      private string[] BC001317_A187MunicipioNome ;
      private bool[] BC001317_n187MunicipioNome ;
      private string[] BC001317_A189MunicipioUF ;
      private bool[] BC001317_n189MunicipioUF ;
      private string[] BC001317_A770EmpresaRepresentanteCPF ;
      private bool[] BC001317_n770EmpresaRepresentanteCPF ;
      private string[] BC001317_A771EmpresaRepresentanteNome ;
      private bool[] BC001317_n771EmpresaRepresentanteNome ;
      private string[] BC001317_A772EmpresaRepresentanteEmail ;
      private bool[] BC001317_n772EmpresaRepresentanteEmail ;
      private bool[] BC001317_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] BC001317_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] BC001317_A928EmpresaRepresentanteLogradouro ;
      private bool[] BC001317_n928EmpresaRepresentanteLogradouro ;
      private long[] BC001317_A929EmpresaRepresentanteNumero ;
      private bool[] BC001317_n929EmpresaRepresentanteNumero ;
      private string[] BC001317_A930EmpresaRepresentanteCEP ;
      private bool[] BC001317_n930EmpresaRepresentanteCEP ;
      private string[] BC001317_A931EmpresaRepresentanteBairro ;
      private bool[] BC001317_n931EmpresaRepresentanteBairro ;
      private string[] BC001317_A932EmpresaRepresentanteComplemento ;
      private bool[] BC001317_n932EmpresaRepresentanteComplemento ;
      private string[] BC001317_A926EmpresaRepresentanteMunicipioNome ;
      private bool[] BC001317_n926EmpresaRepresentanteMunicipioNome ;
      private string[] BC001317_A927EmpresaRepresentanteMunicipioUF ;
      private bool[] BC001317_n927EmpresaRepresentanteMunicipioUF ;
      private string[] BC001317_A933EmpresaRepresentanteNacionalidade ;
      private bool[] BC001317_n933EmpresaRepresentanteNacionalidade ;
      private int[] BC001317_A934EmpresaRepresentanteTelefone ;
      private bool[] BC001317_n934EmpresaRepresentanteTelefone ;
      private short[] BC001317_A935EmpresaRepresentanteTelefoneDDD ;
      private bool[] BC001317_n935EmpresaRepresentanteTelefoneDDD ;
      private string[] BC001317_A186MunicipioCodigo ;
      private bool[] BC001317_n186MunicipioCodigo ;
      private string[] BC001317_A925EmpresaRepresentanteMunicipio ;
      private bool[] BC001317_n925EmpresaRepresentanteMunicipio ;
      private int[] BC001317_A464EmpresaBancoId ;
      private bool[] BC001317_n464EmpresaBancoId ;
      private int[] BC001317_A924EmpresaRepresentanteProfissao ;
      private bool[] BC001317_n924EmpresaRepresentanteProfissao ;
      private SdtEmpresa bcEmpresa ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class empresa_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00132;
          prmBC00132 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC00133;
          prmBC00133 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC00134;
          prmBC00134 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC00135;
          prmBC00135 = new Object[] {
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC00136;
          prmBC00136 = new Object[] {
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00137;
          prmBC00137 = new Object[] {
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00138;
          prmBC00138 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC00139;
          prmBC00139 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC001310;
          prmBC001310 = new Object[] {
          new ParDef("EmpresaNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaCNPJ",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaSede",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaAgencia",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaAgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaConta",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("EmpresaPix",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("EmpresaPixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaUtilizaRepresentanteAssinatura",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCEP",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNacionalidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefone",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001311;
          prmBC001311 = new Object[] {
          };
          Object[] prmBC001312;
          prmBC001312 = new Object[] {
          new ParDef("EmpresaNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EmpresaCNPJ",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaSede",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaAgencia",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaAgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaConta",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("EmpresaPix",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("EmpresaPixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaLogradouroNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaUtilizaRepresentanteAssinatura",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNumero",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteCEP",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteNacionalidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefone",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaRepresentanteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC001313;
          prmBC001313 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          Object[] prmBC001314;
          prmBC001314 = new Object[] {
          new ParDef("EmpresaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001315;
          prmBC001315 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC001316;
          prmBC001316 = new Object[] {
          new ParDef("EmpresaRepresentanteMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC001317;
          prmBC001317 = new Object[] {
          new ParDef("EmpresaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00132", "SELECT EmpresaId, EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao FROM Empresa WHERE EmpresaId = :EmpresaId  FOR UPDATE OF Empresa",true, GxErrorMask.GX_NOMASK, false, this,prmBC00132,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00133", "SELECT EmpresaId, EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao FROM Empresa WHERE EmpresaId = :EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00133,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00134", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00134,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00135", "SELECT MunicipioNome AS EmpresaRepresentanteMunicipioNome, MunicipioUF AS EmpresaRepresentanteMunicipioUF FROM Municipio WHERE MunicipioCodigo = :EmpresaRepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00135,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00136", "SELECT BancoNome FROM Banco WHERE BancoId = :EmpresaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00136,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00137", "SELECT ProfissaoId AS EmpresaRepresentanteProfissao FROM Profissao WHERE ProfissaoId = :EmpresaRepresentanteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00137,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00138", "SELECT TM1.EmpresaId, TM1.EmpresaNomeFantasia, TM1.EmpresaRazaoSocial, TM1.EmpresaCNPJ, TM1.EmpresaSede, T2.BancoNome, TM1.EmpresaAgencia, TM1.EmpresaAgenciaDigito, TM1.EmpresaConta, TM1.EmpresaPix, TM1.EmpresaPixTipo, TM1.EmpresaEmail, TM1.EmpresaLogradouro, TM1.EmpresaLogradouroNumero, TM1.EmpresaCEP, TM1.EmpresaBairro, TM1.EmpresaComplemento, T3.MunicipioNome, T3.MunicipioUF, TM1.EmpresaRepresentanteCPF, TM1.EmpresaRepresentanteNome, TM1.EmpresaRepresentanteEmail, TM1.EmpresaUtilizaRepresentanteAssinatura, TM1.EmpresaRepresentanteLogradouro, TM1.EmpresaRepresentanteNumero, TM1.EmpresaRepresentanteCEP, TM1.EmpresaRepresentanteBairro, TM1.EmpresaRepresentanteComplemento, T4.MunicipioNome AS EmpresaRepresentanteMunicipioNome, T4.MunicipioUF AS EmpresaRepresentanteMunicipioUF, TM1.EmpresaRepresentanteNacionalidade, TM1.EmpresaRepresentanteTelefone, TM1.EmpresaRepresentanteTelefoneDDD, TM1.MunicipioCodigo, TM1.EmpresaRepresentanteMunicipio AS EmpresaRepresentanteMunicipio, TM1.EmpresaBancoId AS EmpresaBancoId, TM1.EmpresaRepresentanteProfissao AS EmpresaRepresentanteProfissao FROM (((Empresa TM1 LEFT JOIN Banco T2 ON T2.BancoId = TM1.EmpresaBancoId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = TM1.EmpresaRepresentanteMunicipio) WHERE TM1.EmpresaId = :EmpresaId ORDER BY TM1.EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00138,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00139", "SELECT EmpresaId FROM Empresa WHERE EmpresaId = :EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00139,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001310", "SAVEPOINT gxupdate;INSERT INTO Empresa(EmpresaNomeFantasia, EmpresaRazaoSocial, EmpresaCNPJ, EmpresaSede, EmpresaAgencia, EmpresaAgenciaDigito, EmpresaConta, EmpresaPix, EmpresaPixTipo, EmpresaEmail, EmpresaLogradouro, EmpresaLogradouroNumero, EmpresaCEP, EmpresaBairro, EmpresaComplemento, EmpresaRepresentanteCPF, EmpresaRepresentanteNome, EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero, EmpresaRepresentanteCEP, EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD, MunicipioCodigo, EmpresaRepresentanteMunicipio, EmpresaBancoId, EmpresaRepresentanteProfissao) VALUES(:EmpresaNomeFantasia, :EmpresaRazaoSocial, :EmpresaCNPJ, :EmpresaSede, :EmpresaAgencia, :EmpresaAgenciaDigito, :EmpresaConta, :EmpresaPix, :EmpresaPixTipo, :EmpresaEmail, :EmpresaLogradouro, :EmpresaLogradouroNumero, :EmpresaCEP, :EmpresaBairro, :EmpresaComplemento, :EmpresaRepresentanteCPF, :EmpresaRepresentanteNome, :EmpresaRepresentanteEmail, :EmpresaUtilizaRepresentanteAssinatura, :EmpresaRepresentanteLogradouro, :EmpresaRepresentanteNumero, :EmpresaRepresentanteCEP, :EmpresaRepresentanteBairro, :EmpresaRepresentanteComplemento, :EmpresaRepresentanteNacionalidade, :EmpresaRepresentanteTelefone, :EmpresaRepresentanteTelefoneDDD, :MunicipioCodigo, :EmpresaRepresentanteMunicipio, :EmpresaBancoId, :EmpresaRepresentanteProfissao);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001310)
             ,new CursorDef("BC001311", "SELECT currval('EmpresaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001311,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001312", "SAVEPOINT gxupdate;UPDATE Empresa SET EmpresaNomeFantasia=:EmpresaNomeFantasia, EmpresaRazaoSocial=:EmpresaRazaoSocial, EmpresaCNPJ=:EmpresaCNPJ, EmpresaSede=:EmpresaSede, EmpresaAgencia=:EmpresaAgencia, EmpresaAgenciaDigito=:EmpresaAgenciaDigito, EmpresaConta=:EmpresaConta, EmpresaPix=:EmpresaPix, EmpresaPixTipo=:EmpresaPixTipo, EmpresaEmail=:EmpresaEmail, EmpresaLogradouro=:EmpresaLogradouro, EmpresaLogradouroNumero=:EmpresaLogradouroNumero, EmpresaCEP=:EmpresaCEP, EmpresaBairro=:EmpresaBairro, EmpresaComplemento=:EmpresaComplemento, EmpresaRepresentanteCPF=:EmpresaRepresentanteCPF, EmpresaRepresentanteNome=:EmpresaRepresentanteNome, EmpresaRepresentanteEmail=:EmpresaRepresentanteEmail, EmpresaUtilizaRepresentanteAssinatura=:EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteLogradouro=:EmpresaRepresentanteLogradouro, EmpresaRepresentanteNumero=:EmpresaRepresentanteNumero, EmpresaRepresentanteCEP=:EmpresaRepresentanteCEP, EmpresaRepresentanteBairro=:EmpresaRepresentanteBairro, EmpresaRepresentanteComplemento=:EmpresaRepresentanteComplemento, EmpresaRepresentanteNacionalidade=:EmpresaRepresentanteNacionalidade, EmpresaRepresentanteTelefone=:EmpresaRepresentanteTelefone, EmpresaRepresentanteTelefoneDDD=:EmpresaRepresentanteTelefoneDDD, MunicipioCodigo=:MunicipioCodigo, EmpresaRepresentanteMunicipio=:EmpresaRepresentanteMunicipio, EmpresaBancoId=:EmpresaBancoId, EmpresaRepresentanteProfissao=:EmpresaRepresentanteProfissao  WHERE EmpresaId = :EmpresaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001312)
             ,new CursorDef("BC001313", "SAVEPOINT gxupdate;DELETE FROM Empresa  WHERE EmpresaId = :EmpresaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001313)
             ,new CursorDef("BC001314", "SELECT BancoNome FROM Banco WHERE BancoId = :EmpresaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001315", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001315,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001316", "SELECT MunicipioNome AS EmpresaRepresentanteMunicipioNome, MunicipioUF AS EmpresaRepresentanteMunicipioUF FROM Municipio WHERE MunicipioCodigo = :EmpresaRepresentanteMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001316,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001317", "SELECT TM1.EmpresaId, TM1.EmpresaNomeFantasia, TM1.EmpresaRazaoSocial, TM1.EmpresaCNPJ, TM1.EmpresaSede, T2.BancoNome, TM1.EmpresaAgencia, TM1.EmpresaAgenciaDigito, TM1.EmpresaConta, TM1.EmpresaPix, TM1.EmpresaPixTipo, TM1.EmpresaEmail, TM1.EmpresaLogradouro, TM1.EmpresaLogradouroNumero, TM1.EmpresaCEP, TM1.EmpresaBairro, TM1.EmpresaComplemento, T3.MunicipioNome, T3.MunicipioUF, TM1.EmpresaRepresentanteCPF, TM1.EmpresaRepresentanteNome, TM1.EmpresaRepresentanteEmail, TM1.EmpresaUtilizaRepresentanteAssinatura, TM1.EmpresaRepresentanteLogradouro, TM1.EmpresaRepresentanteNumero, TM1.EmpresaRepresentanteCEP, TM1.EmpresaRepresentanteBairro, TM1.EmpresaRepresentanteComplemento, T4.MunicipioNome AS EmpresaRepresentanteMunicipioNome, T4.MunicipioUF AS EmpresaRepresentanteMunicipioUF, TM1.EmpresaRepresentanteNacionalidade, TM1.EmpresaRepresentanteTelefone, TM1.EmpresaRepresentanteTelefoneDDD, TM1.MunicipioCodigo, TM1.EmpresaRepresentanteMunicipio AS EmpresaRepresentanteMunicipio, TM1.EmpresaBancoId AS EmpresaBancoId, TM1.EmpresaRepresentanteProfissao AS EmpresaRepresentanteProfissao FROM (((Empresa TM1 LEFT JOIN Banco T2 ON T2.BancoId = TM1.EmpresaBancoId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = TM1.EmpresaRepresentanteMunicipio) WHERE TM1.EmpresaId = :EmpresaId ORDER BY TM1.EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001317,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((long[]) buf[47])[0] = rslt.getLong(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((short[]) buf[63])[0] = rslt.getShort(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((long[]) buf[47])[0] = rslt.getLong(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((short[]) buf[63])[0] = rslt.getShort(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                return;
       }
    }

 }

}
