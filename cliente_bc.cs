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
   public class cliente_bc : GxSilentTrn, IGxSilentTrn
   {
      public cliente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cliente_bc( IGxContext context )
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
         ReadRow0O28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0O28( ) ;
         standaloneModal( ) ;
         AddRow0O28( ) ;
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
            E110O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z168ClienteId = A168ClienteId;
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O28( ) ;
            }
            else
            {
               CheckExtendedTable0O28( ) ;
               if ( AnyError == 0 )
               {
                  ZM0O28( 36) ;
                  ZM0O28( 37) ;
                  ZM0O28( 38) ;
                  ZM0O28( 39) ;
                  ZM0O28( 40) ;
                  ZM0O28( 41) ;
                  ZM0O28( 42) ;
                  ZM0O28( 43) ;
                  ZM0O28( 44) ;
                  ZM0O28( 45) ;
                  ZM0O28( 46) ;
                  ZM0O28( 47) ;
                  ZM0O28( 48) ;
                  ZM0O28( 49) ;
                  ZM0O28( 50) ;
                  ZM0O28( 51) ;
                  ZM0O28( 52) ;
               }
               CloseExtendedTableCursors0O28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV35Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "EspecialidadeId") == 0 )
               {
                  AV29Insert_EspecialidadeId = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "TipoClienteId") == 0 )
               {
                  AV14Insert_TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteConvenio") == 0 )
               {
                  AV32Insert_ClienteConvenio = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteNacionalidade") == 0 )
               {
                  AV30Insert_ClienteNacionalidade = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteProfissao") == 0 )
               {
                  AV31Insert_ClienteProfissao = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "MunicipioCodigo") == 0 )
               {
                  AV17Insert_MunicipioCodigo = AV16TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV25Insert_BancoId = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelNacionalidade") == 0 )
               {
                  AV26Insert_ResponsavelNacionalidade = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelProfissao") == 0 )
               {
                  AV27Insert_ResponsavelProfissao = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelMunicipio") == 0 )
               {
                  AV28Insert_ResponsavelMunicipio = AV16TrnContextAtt.gxTpr_Attributevalue;
               }
               AV36GXV1 = (int)(AV36GXV1+1);
            }
         }
      }

      protected void E110O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0O28( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z175ClienteCreatedAt = A175ClienteCreatedAt;
            Z176ClienteUpdatedAt = A176ClienteUpdatedAt;
            Z169ClienteDocumento = A169ClienteDocumento;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z171ClienteNomeFantasia = A171ClienteNomeFantasia;
            Z459ClienteDataNascimento = A459ClienteDataNascimento;
            Z172ClienteTipoPessoa = A172ClienteTipoPessoa;
            Z174ClienteStatus = A174ClienteStatus;
            Z177ClienteLogUser = A177ClienteLogUser;
            Z486ClienteEstadoCivil = A486ClienteEstadoCivil;
            Z181EnderecoTipo = A181EnderecoTipo;
            Z182EnderecoCEP = A182EnderecoCEP;
            Z183EnderecoLogradouro = A183EnderecoLogradouro;
            Z184EnderecoBairro = A184EnderecoBairro;
            Z185EnderecoCidade = A185EnderecoCidade;
            Z190EnderecoNumero = A190EnderecoNumero;
            Z191EnderecoComplemento = A191EnderecoComplemento;
            Z201ContatoEmail = A201ContatoEmail;
            Z198ContatoDDD = A198ContatoDDD;
            Z199ContatoDDI = A199ContatoDDI;
            Z200ContatoNumero = A200ContatoNumero;
            Z202ContatoTelefoneNumero = A202ContatoTelefoneNumero;
            Z203ContatoTelefoneDDD = A203ContatoTelefoneDDD;
            Z204ContatoTelefoneDDI = A204ContatoTelefoneDDI;
            Z421ClienteRG = A421ClienteRG;
            Z537ClienteDepositoTipo = A537ClienteDepositoTipo;
            Z538ClientePixTipo = A538ClientePixTipo;
            Z539ClientePix = A539ClientePix;
            Z400ContaAgencia = A400ContaAgencia;
            Z401ContaNumero = A401ContaNumero;
            Z436ResponsavelNome = A436ResponsavelNome;
            Z439ResponsavelEstadoCivil = A439ResponsavelEstadoCivil;
            Z576ResponsavelRG = A576ResponsavelRG;
            Z447ResponsavelCPF = A447ResponsavelCPF;
            Z448ResponsavelCEP = A448ResponsavelCEP;
            Z449ResponsavelLogradouro = A449ResponsavelLogradouro;
            Z450ResponsavelBairro = A450ResponsavelBairro;
            Z451ResponsavelCidade = A451ResponsavelCidade;
            Z452ResponsavelLogradouroNumero = A452ResponsavelLogradouroNumero;
            Z453ResponsavelComplemento = A453ResponsavelComplemento;
            Z454ResponsavelDDD = A454ResponsavelDDD;
            Z455ResponsavelNumero = A455ResponsavelNumero;
            Z456ResponsavelEmail = A456ResponsavelEmail;
            Z884ClienteSituacao = A884ClienteSituacao;
            Z885ResponsavelCargo = A885ResponsavelCargo;
            Z1039ClienteTipoRisco = A1039ClienteTipoRisco;
            Z192TipoClienteId = A192TipoClienteId;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z444ResponsavelMunicipio = A444ResponsavelMunicipio;
            Z402BancoId = A402BancoId;
            Z457EspecialidadeId = A457EspecialidadeId;
            Z437ResponsavelNacionalidade = A437ResponsavelNacionalidade;
            Z484ClienteNacionalidade = A484ClienteNacionalidade;
            Z442ResponsavelProfissao = A442ResponsavelProfissao;
            Z487ClienteProfissao = A487ClienteProfissao;
            Z489ClienteConvenio = A489ClienteConvenio;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            Z446ResponsavelMunicipioUF = A446ResponsavelMunicipioUF;
            Z445ResponsavelMunicipioNome = A445ResponsavelMunicipioNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 40 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 41 ) || ( GX_JID == 0 ) )
         {
            Z438ResponsavelNacionalidadeNome = A438ResponsavelNacionalidadeNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            Z485ClienteNacionalidadeNome = A485ClienteNacionalidadeNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 43 ) || ( GX_JID == 0 ) )
         {
            Z443ResponsavelProfissaoNome = A443ResponsavelProfissaoNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 44 ) || ( GX_JID == 0 ) )
         {
            Z488ClienteProfissaoNome = A488ClienteProfissaoNome;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 45 ) || ( GX_JID == 0 ) )
         {
            Z490ClienteConvenioDescricao = A490ClienteConvenioDescricao;
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 46 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 47 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 48 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 50 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 51 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( ( GX_JID == 52 ) || ( GX_JID == 0 ) )
         {
            Z608SecUserId_F = A608SecUserId_F;
            Z205ClienteTelefone_F = A205ClienteTelefone_F;
            Z206ClienteCelular_F = A206ClienteCelular_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z577ResponsavelCelular_F = A577ResponsavelCelular_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z781SerasaScoreUltimaData_F = A781SerasaScoreUltimaData_F;
            Z785SerasaUltimoValorRecomendado_F = A785SerasaUltimoValorRecomendado_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z1030ClienteSacado = A1030ClienteSacado;
         }
         if ( GX_JID == -34 )
         {
            Z168ClienteId = A168ClienteId;
            Z175ClienteCreatedAt = A175ClienteCreatedAt;
            Z176ClienteUpdatedAt = A176ClienteUpdatedAt;
            Z169ClienteDocumento = A169ClienteDocumento;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z171ClienteNomeFantasia = A171ClienteNomeFantasia;
            Z459ClienteDataNascimento = A459ClienteDataNascimento;
            Z172ClienteTipoPessoa = A172ClienteTipoPessoa;
            Z174ClienteStatus = A174ClienteStatus;
            Z177ClienteLogUser = A177ClienteLogUser;
            Z486ClienteEstadoCivil = A486ClienteEstadoCivil;
            Z181EnderecoTipo = A181EnderecoTipo;
            Z182EnderecoCEP = A182EnderecoCEP;
            Z183EnderecoLogradouro = A183EnderecoLogradouro;
            Z184EnderecoBairro = A184EnderecoBairro;
            Z185EnderecoCidade = A185EnderecoCidade;
            Z190EnderecoNumero = A190EnderecoNumero;
            Z191EnderecoComplemento = A191EnderecoComplemento;
            Z201ContatoEmail = A201ContatoEmail;
            Z198ContatoDDD = A198ContatoDDD;
            Z199ContatoDDI = A199ContatoDDI;
            Z200ContatoNumero = A200ContatoNumero;
            Z202ContatoTelefoneNumero = A202ContatoTelefoneNumero;
            Z203ContatoTelefoneDDD = A203ContatoTelefoneDDD;
            Z204ContatoTelefoneDDI = A204ContatoTelefoneDDI;
            Z421ClienteRG = A421ClienteRG;
            Z537ClienteDepositoTipo = A537ClienteDepositoTipo;
            Z538ClientePixTipo = A538ClientePixTipo;
            Z539ClientePix = A539ClientePix;
            Z400ContaAgencia = A400ContaAgencia;
            Z401ContaNumero = A401ContaNumero;
            Z436ResponsavelNome = A436ResponsavelNome;
            Z439ResponsavelEstadoCivil = A439ResponsavelEstadoCivil;
            Z576ResponsavelRG = A576ResponsavelRG;
            Z447ResponsavelCPF = A447ResponsavelCPF;
            Z448ResponsavelCEP = A448ResponsavelCEP;
            Z449ResponsavelLogradouro = A449ResponsavelLogradouro;
            Z450ResponsavelBairro = A450ResponsavelBairro;
            Z451ResponsavelCidade = A451ResponsavelCidade;
            Z452ResponsavelLogradouroNumero = A452ResponsavelLogradouroNumero;
            Z453ResponsavelComplemento = A453ResponsavelComplemento;
            Z454ResponsavelDDD = A454ResponsavelDDD;
            Z455ResponsavelNumero = A455ResponsavelNumero;
            Z456ResponsavelEmail = A456ResponsavelEmail;
            Z884ClienteSituacao = A884ClienteSituacao;
            Z885ResponsavelCargo = A885ResponsavelCargo;
            Z1039ClienteTipoRisco = A1039ClienteTipoRisco;
            Z192TipoClienteId = A192TipoClienteId;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z444ResponsavelMunicipio = A444ResponsavelMunicipio;
            Z402BancoId = A402BancoId;
            Z457EspecialidadeId = A457EspecialidadeId;
            Z437ResponsavelNacionalidade = A437ResponsavelNacionalidade;
            Z484ClienteNacionalidade = A484ClienteNacionalidade;
            Z442ResponsavelProfissao = A442ResponsavelProfissao;
            Z487ClienteProfissao = A487ClienteProfissao;
            Z489ClienteConvenio = A489ClienteConvenio;
            Z608SecUserId_F = A608SecUserId_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z490ClienteConvenioDescricao = A490ClienteConvenioDescricao;
            Z485ClienteNacionalidadeNome = A485ClienteNacionalidadeNome;
            Z488ClienteProfissaoNome = A488ClienteProfissaoNome;
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z438ResponsavelNacionalidadeNome = A438ResponsavelNacionalidadeNome;
            Z443ResponsavelProfissaoNome = A443ResponsavelProfissaoNome;
            Z446ResponsavelMunicipioUF = A446ResponsavelMunicipioUF;
            Z445ResponsavelMunicipioNome = A445ResponsavelMunicipioNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV35Pgmname = "Cliente_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A175ClienteCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n175ClienteCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A176ClienteUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n176ClienteUpdatedAt = false;
         }
         if ( IsIns( )  && (false==A174ClienteStatus) && ( Gx_BScreen == 0 ) )
         {
            A174ClienteStatus = true;
            n174ClienteStatus = false;
         }
      }

      protected void Load0O28( )
      {
         /* Using cursor BC000O40 */
         pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound28 = 1;
            A175ClienteCreatedAt = BC000O40_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = BC000O40_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = BC000O40_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = BC000O40_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = BC000O40_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000O40_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = BC000O40_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000O40_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = BC000O40_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = BC000O40_n171ClienteNomeFantasia[0];
            A459ClienteDataNascimento = BC000O40_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = BC000O40_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = BC000O40_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = BC000O40_n172ClienteTipoPessoa[0];
            A193TipoClienteDescricao = BC000O40_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000O40_n193TipoClienteDescricao[0];
            A207TipoClientePortal = BC000O40_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000O40_n207TipoClientePortal[0];
            A174ClienteStatus = BC000O40_A174ClienteStatus[0];
            n174ClienteStatus = BC000O40_n174ClienteStatus[0];
            A490ClienteConvenioDescricao = BC000O40_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = BC000O40_n490ClienteConvenioDescricao[0];
            A177ClienteLogUser = BC000O40_A177ClienteLogUser[0];
            n177ClienteLogUser = BC000O40_n177ClienteLogUser[0];
            A485ClienteNacionalidadeNome = BC000O40_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = BC000O40_n485ClienteNacionalidadeNome[0];
            A488ClienteProfissaoNome = BC000O40_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = BC000O40_n488ClienteProfissaoNome[0];
            A486ClienteEstadoCivil = BC000O40_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = BC000O40_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = BC000O40_A181EnderecoTipo[0];
            n181EnderecoTipo = BC000O40_n181EnderecoTipo[0];
            A182EnderecoCEP = BC000O40_A182EnderecoCEP[0];
            n182EnderecoCEP = BC000O40_n182EnderecoCEP[0];
            A183EnderecoLogradouro = BC000O40_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = BC000O40_n183EnderecoLogradouro[0];
            A184EnderecoBairro = BC000O40_A184EnderecoBairro[0];
            n184EnderecoBairro = BC000O40_n184EnderecoBairro[0];
            A185EnderecoCidade = BC000O40_A185EnderecoCidade[0];
            n185EnderecoCidade = BC000O40_n185EnderecoCidade[0];
            A187MunicipioNome = BC000O40_A187MunicipioNome[0];
            n187MunicipioNome = BC000O40_n187MunicipioNome[0];
            A189MunicipioUF = BC000O40_A189MunicipioUF[0];
            n189MunicipioUF = BC000O40_n189MunicipioUF[0];
            A190EnderecoNumero = BC000O40_A190EnderecoNumero[0];
            n190EnderecoNumero = BC000O40_n190EnderecoNumero[0];
            A191EnderecoComplemento = BC000O40_A191EnderecoComplemento[0];
            n191EnderecoComplemento = BC000O40_n191EnderecoComplemento[0];
            A201ContatoEmail = BC000O40_A201ContatoEmail[0];
            n201ContatoEmail = BC000O40_n201ContatoEmail[0];
            A198ContatoDDD = BC000O40_A198ContatoDDD[0];
            n198ContatoDDD = BC000O40_n198ContatoDDD[0];
            A199ContatoDDI = BC000O40_A199ContatoDDI[0];
            n199ContatoDDI = BC000O40_n199ContatoDDI[0];
            A200ContatoNumero = BC000O40_A200ContatoNumero[0];
            n200ContatoNumero = BC000O40_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = BC000O40_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = BC000O40_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = BC000O40_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = BC000O40_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = BC000O40_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = BC000O40_n204ContatoTelefoneDDI[0];
            A421ClienteRG = BC000O40_A421ClienteRG[0];
            n421ClienteRG = BC000O40_n421ClienteRG[0];
            A537ClienteDepositoTipo = BC000O40_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = BC000O40_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = BC000O40_A538ClientePixTipo[0];
            n538ClientePixTipo = BC000O40_n538ClientePixTipo[0];
            A539ClientePix = BC000O40_A539ClientePix[0];
            n539ClientePix = BC000O40_n539ClientePix[0];
            A404BancoCodigo = BC000O40_A404BancoCodigo[0];
            n404BancoCodigo = BC000O40_n404BancoCodigo[0];
            A403BancoNome = BC000O40_A403BancoNome[0];
            n403BancoNome = BC000O40_n403BancoNome[0];
            A400ContaAgencia = BC000O40_A400ContaAgencia[0];
            n400ContaAgencia = BC000O40_n400ContaAgencia[0];
            A401ContaNumero = BC000O40_A401ContaNumero[0];
            n401ContaNumero = BC000O40_n401ContaNumero[0];
            A436ResponsavelNome = BC000O40_A436ResponsavelNome[0];
            n436ResponsavelNome = BC000O40_n436ResponsavelNome[0];
            A438ResponsavelNacionalidadeNome = BC000O40_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = BC000O40_n438ResponsavelNacionalidadeNome[0];
            A439ResponsavelEstadoCivil = BC000O40_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = BC000O40_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = BC000O40_A576ResponsavelRG[0];
            n576ResponsavelRG = BC000O40_n576ResponsavelRG[0];
            A443ResponsavelProfissaoNome = BC000O40_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = BC000O40_n443ResponsavelProfissaoNome[0];
            A447ResponsavelCPF = BC000O40_A447ResponsavelCPF[0];
            n447ResponsavelCPF = BC000O40_n447ResponsavelCPF[0];
            A448ResponsavelCEP = BC000O40_A448ResponsavelCEP[0];
            n448ResponsavelCEP = BC000O40_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = BC000O40_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = BC000O40_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = BC000O40_A450ResponsavelBairro[0];
            n450ResponsavelBairro = BC000O40_n450ResponsavelBairro[0];
            A451ResponsavelCidade = BC000O40_A451ResponsavelCidade[0];
            n451ResponsavelCidade = BC000O40_n451ResponsavelCidade[0];
            A446ResponsavelMunicipioUF = BC000O40_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = BC000O40_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = BC000O40_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = BC000O40_n445ResponsavelMunicipioNome[0];
            A452ResponsavelLogradouroNumero = BC000O40_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = BC000O40_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = BC000O40_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = BC000O40_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = BC000O40_A454ResponsavelDDD[0];
            n454ResponsavelDDD = BC000O40_n454ResponsavelDDD[0];
            A455ResponsavelNumero = BC000O40_A455ResponsavelNumero[0];
            n455ResponsavelNumero = BC000O40_n455ResponsavelNumero[0];
            A456ResponsavelEmail = BC000O40_A456ResponsavelEmail[0];
            n456ResponsavelEmail = BC000O40_n456ResponsavelEmail[0];
            A884ClienteSituacao = BC000O40_A884ClienteSituacao[0];
            n884ClienteSituacao = BC000O40_n884ClienteSituacao[0];
            A885ResponsavelCargo = BC000O40_A885ResponsavelCargo[0];
            n885ResponsavelCargo = BC000O40_n885ResponsavelCargo[0];
            A793TipoClientePortalPjPf = BC000O40_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000O40_n793TipoClientePortalPjPf[0];
            A1039ClienteTipoRisco = BC000O40_A1039ClienteTipoRisco[0];
            A192TipoClienteId = BC000O40_A192TipoClienteId[0];
            n192TipoClienteId = BC000O40_n192TipoClienteId[0];
            A186MunicipioCodigo = BC000O40_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000O40_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = BC000O40_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = BC000O40_n444ResponsavelMunicipio[0];
            A402BancoId = BC000O40_A402BancoId[0];
            n402BancoId = BC000O40_n402BancoId[0];
            A457EspecialidadeId = BC000O40_A457EspecialidadeId[0];
            n457EspecialidadeId = BC000O40_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = BC000O40_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = BC000O40_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = BC000O40_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = BC000O40_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = BC000O40_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = BC000O40_n442ResponsavelProfissao[0];
            A487ClienteProfissao = BC000O40_A487ClienteProfissao[0];
            n487ClienteProfissao = BC000O40_n487ClienteProfissao[0];
            A489ClienteConvenio = BC000O40_A489ClienteConvenio[0];
            n489ClienteConvenio = BC000O40_n489ClienteConvenio[0];
            A780SerasaUltimaData_F = BC000O40_A780SerasaUltimaData_F[0];
            A608SecUserId_F = BC000O40_A608SecUserId_F[0];
            n608SecUserId_F = BC000O40_n608SecUserId_F[0];
            A309ClienteQtdTitulos_F = BC000O40_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = BC000O40_n309ClienteQtdTitulos_F[0];
            A310ClienteValorAPagar_F = BC000O40_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = BC000O40_n310ClienteValorAPagar_F[0];
            A311ClienteValorAReceber_F = BC000O40_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = BC000O40_n311ClienteValorAReceber_F[0];
            A732SerasaConsultas_F = BC000O40_A732SerasaConsultas_F[0];
            A1031RelacionamentoSacado = BC000O40_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = BC000O40_n1031RelacionamentoSacado[0];
            ZM0O28( -34) ;
         }
         pr_default.close(19);
         OnLoadActions0O28( ) ;
      }

      protected void OnLoadActions0O28( )
      {
         /* Using cursor BC000O15 */
         pr_default.execute(12, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A781SerasaScoreUltimaData_F = BC000O15_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = BC000O15_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            A785SerasaUltimoValorRecomendado_F = 0;
         }
         pr_default.close(12);
         A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
         if ( (0==A457EspecialidadeId) )
         {
            A457EspecialidadeId = 0;
            n457EspecialidadeId = false;
            n457EspecialidadeId = true;
            n457EspecialidadeId = true;
         }
         if ( (0==A192TipoClienteId) )
         {
            A192TipoClienteId = 0;
            n192TipoClienteId = false;
            n192TipoClienteId = true;
            n192TipoClienteId = true;
         }
         if ( (0==A489ClienteConvenio) )
         {
            A489ClienteConvenio = 0;
            n489ClienteConvenio = false;
            n489ClienteConvenio = true;
            n489ClienteConvenio = true;
         }
         if ( (0==A484ClienteNacionalidade) )
         {
            A484ClienteNacionalidade = 0;
            n484ClienteNacionalidade = false;
            n484ClienteNacionalidade = true;
            n484ClienteNacionalidade = true;
         }
         if ( (0==A487ClienteProfissao) )
         {
            A487ClienteProfissao = 0;
            n487ClienteProfissao = false;
            n487ClienteProfissao = true;
            n487ClienteProfissao = true;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) )
         {
            A186MunicipioCodigo = "";
            n186MunicipioCodigo = false;
            n186MunicipioCodigo = true;
            n186MunicipioCodigo = true;
         }
         A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
         A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
         if ( (0==A402BancoId) )
         {
            A402BancoId = 0;
            n402BancoId = false;
            n402BancoId = true;
            n402BancoId = true;
         }
         if ( (0==A437ResponsavelNacionalidade) )
         {
            A437ResponsavelNacionalidade = 0;
            n437ResponsavelNacionalidade = false;
            n437ResponsavelNacionalidade = true;
            n437ResponsavelNacionalidade = true;
         }
         if ( (0==A442ResponsavelProfissao) )
         {
            A442ResponsavelProfissao = 0;
            n442ResponsavelProfissao = false;
            n442ResponsavelProfissao = true;
            n442ResponsavelProfissao = true;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) )
         {
            A444ResponsavelMunicipio = "";
            n444ResponsavelMunicipio = false;
            n444ResponsavelMunicipio = true;
            n444ResponsavelMunicipio = true;
         }
         GXt_char1 = A577ResponsavelCelular_F;
         new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
         n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
         A577ResponsavelCelular_F = GXt_char1;
      }

      protected void CheckExtendedTable0O28( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000O17 */
         pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A608SecUserId_F = BC000O17_A608SecUserId_F[0];
            n608SecUserId_F = BC000O17_n608SecUserId_F[0];
         }
         else
         {
            A608SecUserId_F = 0;
            n608SecUserId_F = false;
         }
         pr_default.close(13);
         /* Using cursor BC000O19 */
         pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A309ClienteQtdTitulos_F = BC000O19_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = BC000O19_n309ClienteQtdTitulos_F[0];
         }
         else
         {
            A309ClienteQtdTitulos_F = 0;
            n309ClienteQtdTitulos_F = false;
         }
         pr_default.close(14);
         /* Using cursor BC000O23 */
         pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A310ClienteValorAPagar_F = BC000O23_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = BC000O23_n310ClienteValorAPagar_F[0];
         }
         else
         {
            A310ClienteValorAPagar_F = 0;
            n310ClienteValorAPagar_F = false;
         }
         pr_default.close(15);
         if ( ( A310ClienteValorAPagar_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000O26 */
         pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A311ClienteValorAReceber_F = BC000O26_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = BC000O26_n311ClienteValorAReceber_F[0];
         }
         else
         {
            A311ClienteValorAReceber_F = 0;
            n311ClienteValorAReceber_F = false;
         }
         pr_default.close(16);
         if ( ( A311ClienteValorAReceber_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000O28 */
         pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A780SerasaUltimaData_F = BC000O28_A780SerasaUltimaData_F[0];
            A732SerasaConsultas_F = BC000O28_A732SerasaConsultas_F[0];
         }
         else
         {
            A732SerasaConsultas_F = 0;
            A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         }
         pr_default.close(17);
         /* Using cursor BC000O15 */
         pr_default.execute(12, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A781SerasaScoreUltimaData_F = BC000O15_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = BC000O15_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            A785SerasaUltimoValorRecomendado_F = 0;
         }
         pr_default.close(12);
         if ( ( A785SerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000O30 */
         pr_default.execute(18, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A1031RelacionamentoSacado = BC000O30_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = BC000O30_n1031RelacionamentoSacado[0];
         }
         else
         {
            A1031RelacionamentoSacado = 0;
            n1031RelacionamentoSacado = false;
         }
         pr_default.close(18);
         A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
         /* Using cursor BC000O41 */
         pr_default.execute(20, new Object[] {n169ClienteDocumento, A169ClienteDocumento, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            GX_msglist.addItem("Documento já está sendo utilizado", 1, "");
            AnyError = 1;
         }
         pr_default.close(20);
         if ( ! ( ( StringUtil.StrCmp(A172ClienteTipoPessoa, "FISICA") == 0 ) || ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A172ClienteTipoPessoa)) ) )
         {
            GX_msglist.addItem("Campo Tipo pessoa fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A457EspecialidadeId) )
         {
            A457EspecialidadeId = 0;
            n457EspecialidadeId = false;
            n457EspecialidadeId = true;
            n457EspecialidadeId = true;
         }
         /* Using cursor BC000O8 */
         pr_default.execute(6, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A457EspecialidadeId) ) )
            {
               GX_msglist.addItem("Não existe 'Especialidade'.", "ForeignKeyNotFound", 1, "ESPECIALIDADEID");
               AnyError = 1;
            }
         }
         pr_default.close(6);
         if ( (0==A192TipoClienteId) )
         {
            A192TipoClienteId = 0;
            n192TipoClienteId = false;
            n192TipoClienteId = true;
            n192TipoClienteId = true;
         }
         /* Using cursor BC000O4 */
         pr_default.execute(2, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A193TipoClienteDescricao = BC000O4_A193TipoClienteDescricao[0];
         n193TipoClienteDescricao = BC000O4_n193TipoClienteDescricao[0];
         A207TipoClientePortal = BC000O4_A207TipoClientePortal[0];
         n207TipoClientePortal = BC000O4_n207TipoClientePortal[0];
         A793TipoClientePortalPjPf = BC000O4_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = BC000O4_n793TipoClientePortalPjPf[0];
         pr_default.close(2);
         if ( (0==A489ClienteConvenio) )
         {
            A489ClienteConvenio = 0;
            n489ClienteConvenio = false;
            n489ClienteConvenio = true;
            n489ClienteConvenio = true;
         }
         /* Using cursor BC000O13 */
         pr_default.execute(11, new Object[] {n489ClienteConvenio, A489ClienteConvenio});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A489ClienteConvenio) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Convenio'.", "ForeignKeyNotFound", 1, "CLIENTECONVENIO");
               AnyError = 1;
            }
         }
         A490ClienteConvenioDescricao = BC000O13_A490ClienteConvenioDescricao[0];
         n490ClienteConvenioDescricao = BC000O13_n490ClienteConvenioDescricao[0];
         pr_default.close(11);
         if ( (0==A484ClienteNacionalidade) )
         {
            A484ClienteNacionalidade = 0;
            n484ClienteNacionalidade = false;
            n484ClienteNacionalidade = true;
            n484ClienteNacionalidade = true;
         }
         /* Using cursor BC000O10 */
         pr_default.execute(8, new Object[] {n484ClienteNacionalidade, A484ClienteNacionalidade});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A484ClienteNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Nacionalidade'.", "ForeignKeyNotFound", 1, "CLIENTENACIONALIDADE");
               AnyError = 1;
            }
         }
         A485ClienteNacionalidadeNome = BC000O10_A485ClienteNacionalidadeNome[0];
         n485ClienteNacionalidadeNome = BC000O10_n485ClienteNacionalidadeNome[0];
         pr_default.close(8);
         if ( (0==A487ClienteProfissao) )
         {
            A487ClienteProfissao = 0;
            n487ClienteProfissao = false;
            n487ClienteProfissao = true;
            n487ClienteProfissao = true;
         }
         /* Using cursor BC000O12 */
         pr_default.execute(10, new Object[] {n487ClienteProfissao, A487ClienteProfissao});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A487ClienteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Profissao'.", "ForeignKeyNotFound", 1, "CLIENTEPROFISSAO");
               AnyError = 1;
            }
         }
         A488ClienteProfissaoNome = BC000O12_A488ClienteProfissaoNome[0];
         n488ClienteProfissaoNome = BC000O12_n488ClienteProfissaoNome[0];
         pr_default.close(10);
         if ( ! ( ( StringUtil.StrCmp(A486ClienteEstadoCivil, "SOLTEIRO") == 0 ) || ( StringUtil.StrCmp(A486ClienteEstadoCivil, "CASADO") == 0 ) || ( StringUtil.StrCmp(A486ClienteEstadoCivil, "DIVORCIADO") == 0 ) || ( StringUtil.StrCmp(A486ClienteEstadoCivil, "VIUVO") == 0 ) || ( StringUtil.StrCmp(A486ClienteEstadoCivil, "SEPARADO") == 0 ) || ( StringUtil.StrCmp(A486ClienteEstadoCivil, "UNIAO_ESTAVEL") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A486ClienteEstadoCivil)) ) )
         {
            GX_msglist.addItem("Campo Cliente Estado Civil fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A181EnderecoTipo, "COBRANCA") == 0 ) || ( StringUtil.StrCmp(A181EnderecoTipo, "ENTREGA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A181EnderecoTipo)) ) )
         {
            GX_msglist.addItem("Campo Endereco Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) )
         {
            A186MunicipioCodigo = "";
            n186MunicipioCodigo = false;
            n186MunicipioCodigo = true;
            n186MunicipioCodigo = true;
         }
         /* Using cursor BC000O5 */
         pr_default.execute(3, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
            }
         }
         A187MunicipioNome = BC000O5_A187MunicipioNome[0];
         n187MunicipioNome = BC000O5_n187MunicipioNome[0];
         A189MunicipioUF = BC000O5_A189MunicipioUF[0];
         n189MunicipioUF = BC000O5_n189MunicipioUF[0];
         pr_default.close(3);
         if ( ! ( GxRegex.IsMatch(A201ContatoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A201ContatoEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
         A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
         if ( ! ( ( StringUtil.StrCmp(A537ClienteDepositoTipo, "Conta") == 0 ) || ( StringUtil.StrCmp(A537ClienteDepositoTipo, "Pix") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A537ClienteDepositoTipo)) ) )
         {
            GX_msglist.addItem("Campo Cliente Deposito Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A538ClientePixTipo, "CPF") == 0 ) || ( StringUtil.StrCmp(A538ClientePixTipo, "CNPJ") == 0 ) || ( StringUtil.StrCmp(A538ClientePixTipo, "Telefone") == 0 ) || ( StringUtil.StrCmp(A538ClientePixTipo, "Email") == 0 ) || ( StringUtil.StrCmp(A538ClientePixTipo, "ChaveAleatoria") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A538ClientePixTipo)) ) )
         {
            GX_msglist.addItem("Campo Cliente Pix Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A402BancoId) )
         {
            A402BancoId = 0;
            n402BancoId = false;
            n402BancoId = true;
            n402BancoId = true;
         }
         /* Using cursor BC000O7 */
         pr_default.execute(5, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A402BancoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A404BancoCodigo = BC000O7_A404BancoCodigo[0];
         n404BancoCodigo = BC000O7_n404BancoCodigo[0];
         A403BancoNome = BC000O7_A403BancoNome[0];
         n403BancoNome = BC000O7_n403BancoNome[0];
         pr_default.close(5);
         if ( (0==A437ResponsavelNacionalidade) )
         {
            A437ResponsavelNacionalidade = 0;
            n437ResponsavelNacionalidade = false;
            n437ResponsavelNacionalidade = true;
            n437ResponsavelNacionalidade = true;
         }
         /* Using cursor BC000O9 */
         pr_default.execute(7, new Object[] {n437ResponsavelNacionalidade, A437ResponsavelNacionalidade});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A437ResponsavelNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Responsavel Nacionalidade'.", "ForeignKeyNotFound", 1, "RESPONSAVELNACIONALIDADE");
               AnyError = 1;
            }
         }
         A438ResponsavelNacionalidadeNome = BC000O9_A438ResponsavelNacionalidadeNome[0];
         n438ResponsavelNacionalidadeNome = BC000O9_n438ResponsavelNacionalidadeNome[0];
         pr_default.close(7);
         if ( ! ( ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "SOLTEIRO") == 0 ) || ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "CASADO") == 0 ) || ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "DIVORCIADO") == 0 ) || ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "VIUVO") == 0 ) || ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "SEPARADO") == 0 ) || ( StringUtil.StrCmp(A439ResponsavelEstadoCivil, "UNIAO_ESTAVEL") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A439ResponsavelEstadoCivil)) ) )
         {
            GX_msglist.addItem("Campo Responsavel Estado Civil fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A442ResponsavelProfissao) )
         {
            A442ResponsavelProfissao = 0;
            n442ResponsavelProfissao = false;
            n442ResponsavelProfissao = true;
            n442ResponsavelProfissao = true;
         }
         /* Using cursor BC000O11 */
         pr_default.execute(9, new Object[] {n442ResponsavelProfissao, A442ResponsavelProfissao});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A442ResponsavelProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Db Responsavel Profissao'.", "ForeignKeyNotFound", 1, "RESPONSAVELPROFISSAO");
               AnyError = 1;
            }
         }
         A443ResponsavelProfissaoNome = BC000O11_A443ResponsavelProfissaoNome[0];
         n443ResponsavelProfissaoNome = BC000O11_n443ResponsavelProfissaoNome[0];
         pr_default.close(9);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) )
         {
            A444ResponsavelMunicipio = "";
            n444ResponsavelMunicipio = false;
            n444ResponsavelMunicipio = true;
            n444ResponsavelMunicipio = true;
         }
         /* Using cursor BC000O6 */
         pr_default.execute(4, new Object[] {n444ResponsavelMunicipio, A444ResponsavelMunicipio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reponsavel Municipio'.", "ForeignKeyNotFound", 1, "RESPONSAVELMUNICIPIO");
               AnyError = 1;
            }
         }
         A446ResponsavelMunicipioUF = BC000O6_A446ResponsavelMunicipioUF[0];
         n446ResponsavelMunicipioUF = BC000O6_n446ResponsavelMunicipioUF[0];
         A445ResponsavelMunicipioNome = BC000O6_A445ResponsavelMunicipioNome[0];
         n445ResponsavelMunicipioNome = BC000O6_n445ResponsavelMunicipioNome[0];
         pr_default.close(4);
         GXt_char1 = A577ResponsavelCelular_F;
         new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
         n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
         A577ResponsavelCelular_F = GXt_char1;
         if ( ! ( GxRegex.IsMatch(A456ResponsavelEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ) )
         {
            GX_msglist.addItem("O valor de Responsavel Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) || ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) || ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A884ClienteSituacao)) ) )
         {
            GX_msglist.addItem("Campo Situação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) || ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A885ResponsavelCargo)) ) )
         {
            GX_msglist.addItem("Campo Cargo do Responsável fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1039ClienteTipoRisco, "SEM_RISCO") == 0 ) || ( StringUtil.StrCmp(A1039ClienteTipoRisco, "BAIXO") == 0 ) || ( StringUtil.StrCmp(A1039ClienteTipoRisco, "ALTO") == 0 ) || ( StringUtil.StrCmp(A1039ClienteTipoRisco, "PREMIUM") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Cliente Tipo Risco fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0O28( )
      {
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(12);
         pr_default.close(18);
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(11);
         pr_default.close(8);
         pr_default.close(10);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O28( )
      {
         /* Using cursor BC000O42 */
         pr_default.execute(21, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000O3 */
         pr_default.execute(1, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O28( 34) ;
            RcdFound28 = 1;
            A168ClienteId = BC000O3_A168ClienteId[0];
            n168ClienteId = BC000O3_n168ClienteId[0];
            A175ClienteCreatedAt = BC000O3_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = BC000O3_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = BC000O3_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = BC000O3_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = BC000O3_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000O3_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = BC000O3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000O3_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = BC000O3_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = BC000O3_n171ClienteNomeFantasia[0];
            A459ClienteDataNascimento = BC000O3_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = BC000O3_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = BC000O3_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = BC000O3_n172ClienteTipoPessoa[0];
            A174ClienteStatus = BC000O3_A174ClienteStatus[0];
            n174ClienteStatus = BC000O3_n174ClienteStatus[0];
            A177ClienteLogUser = BC000O3_A177ClienteLogUser[0];
            n177ClienteLogUser = BC000O3_n177ClienteLogUser[0];
            A486ClienteEstadoCivil = BC000O3_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = BC000O3_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = BC000O3_A181EnderecoTipo[0];
            n181EnderecoTipo = BC000O3_n181EnderecoTipo[0];
            A182EnderecoCEP = BC000O3_A182EnderecoCEP[0];
            n182EnderecoCEP = BC000O3_n182EnderecoCEP[0];
            A183EnderecoLogradouro = BC000O3_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = BC000O3_n183EnderecoLogradouro[0];
            A184EnderecoBairro = BC000O3_A184EnderecoBairro[0];
            n184EnderecoBairro = BC000O3_n184EnderecoBairro[0];
            A185EnderecoCidade = BC000O3_A185EnderecoCidade[0];
            n185EnderecoCidade = BC000O3_n185EnderecoCidade[0];
            A190EnderecoNumero = BC000O3_A190EnderecoNumero[0];
            n190EnderecoNumero = BC000O3_n190EnderecoNumero[0];
            A191EnderecoComplemento = BC000O3_A191EnderecoComplemento[0];
            n191EnderecoComplemento = BC000O3_n191EnderecoComplemento[0];
            A201ContatoEmail = BC000O3_A201ContatoEmail[0];
            n201ContatoEmail = BC000O3_n201ContatoEmail[0];
            A198ContatoDDD = BC000O3_A198ContatoDDD[0];
            n198ContatoDDD = BC000O3_n198ContatoDDD[0];
            A199ContatoDDI = BC000O3_A199ContatoDDI[0];
            n199ContatoDDI = BC000O3_n199ContatoDDI[0];
            A200ContatoNumero = BC000O3_A200ContatoNumero[0];
            n200ContatoNumero = BC000O3_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = BC000O3_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = BC000O3_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = BC000O3_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = BC000O3_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = BC000O3_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = BC000O3_n204ContatoTelefoneDDI[0];
            A421ClienteRG = BC000O3_A421ClienteRG[0];
            n421ClienteRG = BC000O3_n421ClienteRG[0];
            A537ClienteDepositoTipo = BC000O3_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = BC000O3_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = BC000O3_A538ClientePixTipo[0];
            n538ClientePixTipo = BC000O3_n538ClientePixTipo[0];
            A539ClientePix = BC000O3_A539ClientePix[0];
            n539ClientePix = BC000O3_n539ClientePix[0];
            A400ContaAgencia = BC000O3_A400ContaAgencia[0];
            n400ContaAgencia = BC000O3_n400ContaAgencia[0];
            A401ContaNumero = BC000O3_A401ContaNumero[0];
            n401ContaNumero = BC000O3_n401ContaNumero[0];
            A436ResponsavelNome = BC000O3_A436ResponsavelNome[0];
            n436ResponsavelNome = BC000O3_n436ResponsavelNome[0];
            A439ResponsavelEstadoCivil = BC000O3_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = BC000O3_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = BC000O3_A576ResponsavelRG[0];
            n576ResponsavelRG = BC000O3_n576ResponsavelRG[0];
            A447ResponsavelCPF = BC000O3_A447ResponsavelCPF[0];
            n447ResponsavelCPF = BC000O3_n447ResponsavelCPF[0];
            A448ResponsavelCEP = BC000O3_A448ResponsavelCEP[0];
            n448ResponsavelCEP = BC000O3_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = BC000O3_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = BC000O3_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = BC000O3_A450ResponsavelBairro[0];
            n450ResponsavelBairro = BC000O3_n450ResponsavelBairro[0];
            A451ResponsavelCidade = BC000O3_A451ResponsavelCidade[0];
            n451ResponsavelCidade = BC000O3_n451ResponsavelCidade[0];
            A452ResponsavelLogradouroNumero = BC000O3_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = BC000O3_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = BC000O3_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = BC000O3_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = BC000O3_A454ResponsavelDDD[0];
            n454ResponsavelDDD = BC000O3_n454ResponsavelDDD[0];
            A455ResponsavelNumero = BC000O3_A455ResponsavelNumero[0];
            n455ResponsavelNumero = BC000O3_n455ResponsavelNumero[0];
            A456ResponsavelEmail = BC000O3_A456ResponsavelEmail[0];
            n456ResponsavelEmail = BC000O3_n456ResponsavelEmail[0];
            A884ClienteSituacao = BC000O3_A884ClienteSituacao[0];
            n884ClienteSituacao = BC000O3_n884ClienteSituacao[0];
            A885ResponsavelCargo = BC000O3_A885ResponsavelCargo[0];
            n885ResponsavelCargo = BC000O3_n885ResponsavelCargo[0];
            A1039ClienteTipoRisco = BC000O3_A1039ClienteTipoRisco[0];
            A192TipoClienteId = BC000O3_A192TipoClienteId[0];
            n192TipoClienteId = BC000O3_n192TipoClienteId[0];
            A186MunicipioCodigo = BC000O3_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000O3_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = BC000O3_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = BC000O3_n444ResponsavelMunicipio[0];
            A402BancoId = BC000O3_A402BancoId[0];
            n402BancoId = BC000O3_n402BancoId[0];
            A457EspecialidadeId = BC000O3_A457EspecialidadeId[0];
            n457EspecialidadeId = BC000O3_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = BC000O3_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = BC000O3_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = BC000O3_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = BC000O3_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = BC000O3_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = BC000O3_n442ResponsavelProfissao[0];
            A487ClienteProfissao = BC000O3_A487ClienteProfissao[0];
            n487ClienteProfissao = BC000O3_n487ClienteProfissao[0];
            A489ClienteConvenio = BC000O3_A489ClienteConvenio[0];
            n489ClienteConvenio = BC000O3_n489ClienteConvenio[0];
            Z168ClienteId = A168ClienteId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0O28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0O28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0O28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0O28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O2 */
            pr_default.execute(0, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z175ClienteCreatedAt != BC000O2_A175ClienteCreatedAt[0] ) || ( Z176ClienteUpdatedAt != BC000O2_A176ClienteUpdatedAt[0] ) || ( StringUtil.StrCmp(Z169ClienteDocumento, BC000O2_A169ClienteDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z170ClienteRazaoSocial, BC000O2_A170ClienteRazaoSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z171ClienteNomeFantasia, BC000O2_A171ClienteNomeFantasia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z459ClienteDataNascimento ) != DateTimeUtil.ResetTime ( BC000O2_A459ClienteDataNascimento[0] ) ) || ( StringUtil.StrCmp(Z172ClienteTipoPessoa, BC000O2_A172ClienteTipoPessoa[0]) != 0 ) || ( Z174ClienteStatus != BC000O2_A174ClienteStatus[0] ) || ( Z177ClienteLogUser != BC000O2_A177ClienteLogUser[0] ) || ( StringUtil.StrCmp(Z486ClienteEstadoCivil, BC000O2_A486ClienteEstadoCivil[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z181EnderecoTipo, BC000O2_A181EnderecoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z182EnderecoCEP, BC000O2_A182EnderecoCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z183EnderecoLogradouro, BC000O2_A183EnderecoLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z184EnderecoBairro, BC000O2_A184EnderecoBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z185EnderecoCidade, BC000O2_A185EnderecoCidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z190EnderecoNumero, BC000O2_A190EnderecoNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z191EnderecoComplemento, BC000O2_A191EnderecoComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z201ContatoEmail, BC000O2_A201ContatoEmail[0]) != 0 ) || ( Z198ContatoDDD != BC000O2_A198ContatoDDD[0] ) || ( Z199ContatoDDI != BC000O2_A199ContatoDDI[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z200ContatoNumero != BC000O2_A200ContatoNumero[0] ) || ( Z202ContatoTelefoneNumero != BC000O2_A202ContatoTelefoneNumero[0] ) || ( Z203ContatoTelefoneDDD != BC000O2_A203ContatoTelefoneDDD[0] ) || ( Z204ContatoTelefoneDDI != BC000O2_A204ContatoTelefoneDDI[0] ) || ( Z421ClienteRG != BC000O2_A421ClienteRG[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z537ClienteDepositoTipo, BC000O2_A537ClienteDepositoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z538ClientePixTipo, BC000O2_A538ClientePixTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z539ClientePix, BC000O2_A539ClientePix[0]) != 0 ) || ( StringUtil.StrCmp(Z400ContaAgencia, BC000O2_A400ContaAgencia[0]) != 0 ) || ( StringUtil.StrCmp(Z401ContaNumero, BC000O2_A401ContaNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z436ResponsavelNome, BC000O2_A436ResponsavelNome[0]) != 0 ) || ( StringUtil.StrCmp(Z439ResponsavelEstadoCivil, BC000O2_A439ResponsavelEstadoCivil[0]) != 0 ) || ( Z576ResponsavelRG != BC000O2_A576ResponsavelRG[0] ) || ( StringUtil.StrCmp(Z447ResponsavelCPF, BC000O2_A447ResponsavelCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z448ResponsavelCEP, BC000O2_A448ResponsavelCEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z449ResponsavelLogradouro, BC000O2_A449ResponsavelLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z450ResponsavelBairro, BC000O2_A450ResponsavelBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z451ResponsavelCidade, BC000O2_A451ResponsavelCidade[0]) != 0 ) || ( Z452ResponsavelLogradouroNumero != BC000O2_A452ResponsavelLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z453ResponsavelComplemento, BC000O2_A453ResponsavelComplemento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z454ResponsavelDDD != BC000O2_A454ResponsavelDDD[0] ) || ( Z455ResponsavelNumero != BC000O2_A455ResponsavelNumero[0] ) || ( StringUtil.StrCmp(Z456ResponsavelEmail, BC000O2_A456ResponsavelEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z884ClienteSituacao, BC000O2_A884ClienteSituacao[0]) != 0 ) || ( StringUtil.StrCmp(Z885ResponsavelCargo, BC000O2_A885ResponsavelCargo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1039ClienteTipoRisco, BC000O2_A1039ClienteTipoRisco[0]) != 0 ) || ( Z192TipoClienteId != BC000O2_A192TipoClienteId[0] ) || ( StringUtil.StrCmp(Z186MunicipioCodigo, BC000O2_A186MunicipioCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z444ResponsavelMunicipio, BC000O2_A444ResponsavelMunicipio[0]) != 0 ) || ( Z402BancoId != BC000O2_A402BancoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z457EspecialidadeId != BC000O2_A457EspecialidadeId[0] ) || ( Z437ResponsavelNacionalidade != BC000O2_A437ResponsavelNacionalidade[0] ) || ( Z484ClienteNacionalidade != BC000O2_A484ClienteNacionalidade[0] ) || ( Z442ResponsavelProfissao != BC000O2_A442ResponsavelProfissao[0] ) || ( Z487ClienteProfissao != BC000O2_A487ClienteProfissao[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z489ClienteConvenio != BC000O2_A489ClienteConvenio[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O28( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O28( 0) ;
            CheckOptimisticConcurrency0O28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O43 */
                     pr_default.execute(22, new Object[] {n175ClienteCreatedAt, A175ClienteCreatedAt, n176ClienteUpdatedAt, A176ClienteUpdatedAt, n169ClienteDocumento, A169ClienteDocumento, n170ClienteRazaoSocial, A170ClienteRazaoSocial, n171ClienteNomeFantasia, A171ClienteNomeFantasia, n459ClienteDataNascimento, A459ClienteDataNascimento, n172ClienteTipoPessoa, A172ClienteTipoPessoa, n174ClienteStatus, A174ClienteStatus, n177ClienteLogUser, A177ClienteLogUser, n486ClienteEstadoCivil, A486ClienteEstadoCivil, n181EnderecoTipo, A181EnderecoTipo, n182EnderecoCEP, A182EnderecoCEP, n183EnderecoLogradouro, A183EnderecoLogradouro, n184EnderecoBairro, A184EnderecoBairro, n185EnderecoCidade, A185EnderecoCidade, n190EnderecoNumero, A190EnderecoNumero, n191EnderecoComplemento, A191EnderecoComplemento, n201ContatoEmail, A201ContatoEmail, n198ContatoDDD, A198ContatoDDD, n199ContatoDDI, A199ContatoDDI, n200ContatoNumero, A200ContatoNumero, n202ContatoTelefoneNumero, A202ContatoTelefoneNumero, n203ContatoTelefoneDDD, A203ContatoTelefoneDDD, n204ContatoTelefoneDDI, A204ContatoTelefoneDDI, n421ClienteRG, A421ClienteRG, n537ClienteDepositoTipo, A537ClienteDepositoTipo, n538ClientePixTipo, A538ClientePixTipo, n539ClientePix, A539ClientePix, n400ContaAgencia, A400ContaAgencia, n401ContaNumero, A401ContaNumero, n436ResponsavelNome, A436ResponsavelNome, n439ResponsavelEstadoCivil, A439ResponsavelEstadoCivil, n576ResponsavelRG, A576ResponsavelRG, n447ResponsavelCPF, A447ResponsavelCPF, n448ResponsavelCEP, A448ResponsavelCEP, n449ResponsavelLogradouro, A449ResponsavelLogradouro, n450ResponsavelBairro, A450ResponsavelBairro, n451ResponsavelCidade, A451ResponsavelCidade, n452ResponsavelLogradouroNumero, A452ResponsavelLogradouroNumero, n453ResponsavelComplemento, A453ResponsavelComplemento, n454ResponsavelDDD, A454ResponsavelDDD, n455ResponsavelNumero, A455ResponsavelNumero, n456ResponsavelEmail, A456ResponsavelEmail, n884ClienteSituacao, A884ClienteSituacao, n885ResponsavelCargo, A885ResponsavelCargo, A1039ClienteTipoRisco, n192TipoClienteId, A192TipoClienteId, n186MunicipioCodigo, A186MunicipioCodigo, n444ResponsavelMunicipio, A444ResponsavelMunicipio, n402BancoId, A402BancoId, n457EspecialidadeId, A457EspecialidadeId, n437ResponsavelNacionalidade, A437ResponsavelNacionalidade, n484ClienteNacionalidade, A484ClienteNacionalidade, n442ResponsavelProfissao, A442ResponsavelProfissao, n487ClienteProfissao, A487ClienteProfissao, n489ClienteConvenio, A489ClienteConvenio});
                     pr_default.close(22);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000O44 */
                     pr_default.execute(23);
                     A168ClienteId = BC000O44_A168ClienteId[0];
                     n168ClienteId = BC000O44_n168ClienteId[0];
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
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
               Load0O28( ) ;
            }
            EndLevel0O28( ) ;
         }
         CloseExtendedTableCursors0O28( ) ;
      }

      protected void Update0O28( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O45 */
                     pr_default.execute(24, new Object[] {n175ClienteCreatedAt, A175ClienteCreatedAt, n176ClienteUpdatedAt, A176ClienteUpdatedAt, n169ClienteDocumento, A169ClienteDocumento, n170ClienteRazaoSocial, A170ClienteRazaoSocial, n171ClienteNomeFantasia, A171ClienteNomeFantasia, n459ClienteDataNascimento, A459ClienteDataNascimento, n172ClienteTipoPessoa, A172ClienteTipoPessoa, n174ClienteStatus, A174ClienteStatus, n177ClienteLogUser, A177ClienteLogUser, n486ClienteEstadoCivil, A486ClienteEstadoCivil, n181EnderecoTipo, A181EnderecoTipo, n182EnderecoCEP, A182EnderecoCEP, n183EnderecoLogradouro, A183EnderecoLogradouro, n184EnderecoBairro, A184EnderecoBairro, n185EnderecoCidade, A185EnderecoCidade, n190EnderecoNumero, A190EnderecoNumero, n191EnderecoComplemento, A191EnderecoComplemento, n201ContatoEmail, A201ContatoEmail, n198ContatoDDD, A198ContatoDDD, n199ContatoDDI, A199ContatoDDI, n200ContatoNumero, A200ContatoNumero, n202ContatoTelefoneNumero, A202ContatoTelefoneNumero, n203ContatoTelefoneDDD, A203ContatoTelefoneDDD, n204ContatoTelefoneDDI, A204ContatoTelefoneDDI, n421ClienteRG, A421ClienteRG, n537ClienteDepositoTipo, A537ClienteDepositoTipo, n538ClientePixTipo, A538ClientePixTipo, n539ClientePix, A539ClientePix, n400ContaAgencia, A400ContaAgencia, n401ContaNumero, A401ContaNumero, n436ResponsavelNome, A436ResponsavelNome, n439ResponsavelEstadoCivil, A439ResponsavelEstadoCivil, n576ResponsavelRG, A576ResponsavelRG, n447ResponsavelCPF, A447ResponsavelCPF, n448ResponsavelCEP, A448ResponsavelCEP, n449ResponsavelLogradouro, A449ResponsavelLogradouro, n450ResponsavelBairro, A450ResponsavelBairro, n451ResponsavelCidade, A451ResponsavelCidade, n452ResponsavelLogradouroNumero, A452ResponsavelLogradouroNumero, n453ResponsavelComplemento, A453ResponsavelComplemento, n454ResponsavelDDD, A454ResponsavelDDD, n455ResponsavelNumero, A455ResponsavelNumero, n456ResponsavelEmail, A456ResponsavelEmail, n884ClienteSituacao, A884ClienteSituacao, n885ResponsavelCargo, A885ResponsavelCargo, A1039ClienteTipoRisco, n192TipoClienteId, A192TipoClienteId, n186MunicipioCodigo, A186MunicipioCodigo, n444ResponsavelMunicipio, A444ResponsavelMunicipio, n402BancoId, A402BancoId, n457EspecialidadeId, A457EspecialidadeId, n437ResponsavelNacionalidade, A437ResponsavelNacionalidade, n484ClienteNacionalidade, A484ClienteNacionalidade, n442ResponsavelProfissao, A442ResponsavelProfissao, n487ClienteProfissao, A487ClienteProfissao, n489ClienteConvenio, A489ClienteConvenio, n168ClienteId, A168ClienteId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(24) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O28( ) ;
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
            EndLevel0O28( ) ;
         }
         CloseExtendedTableCursors0O28( ) ;
      }

      protected void DeferredUpdate0O28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O28( ) ;
            AfterConfirm0O28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000O46 */
                  pr_default.execute(25, new Object[] {n168ClienteId, A168ClienteId});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0O28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000O48 */
            pr_default.execute(26, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               A608SecUserId_F = BC000O48_A608SecUserId_F[0];
               n608SecUserId_F = BC000O48_n608SecUserId_F[0];
            }
            else
            {
               A608SecUserId_F = 0;
               n608SecUserId_F = false;
            }
            pr_default.close(26);
            /* Using cursor BC000O50 */
            pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A309ClienteQtdTitulos_F = BC000O50_A309ClienteQtdTitulos_F[0];
               n309ClienteQtdTitulos_F = BC000O50_n309ClienteQtdTitulos_F[0];
            }
            else
            {
               A309ClienteQtdTitulos_F = 0;
               n309ClienteQtdTitulos_F = false;
            }
            pr_default.close(27);
            /* Using cursor BC000O54 */
            pr_default.execute(28, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               A310ClienteValorAPagar_F = BC000O54_A310ClienteValorAPagar_F[0];
               n310ClienteValorAPagar_F = BC000O54_n310ClienteValorAPagar_F[0];
            }
            else
            {
               A310ClienteValorAPagar_F = 0;
               n310ClienteValorAPagar_F = false;
            }
            pr_default.close(28);
            /* Using cursor BC000O57 */
            pr_default.execute(29, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               A311ClienteValorAReceber_F = BC000O57_A311ClienteValorAReceber_F[0];
               n311ClienteValorAReceber_F = BC000O57_n311ClienteValorAReceber_F[0];
            }
            else
            {
               A311ClienteValorAReceber_F = 0;
               n311ClienteValorAReceber_F = false;
            }
            pr_default.close(29);
            /* Using cursor BC000O59 */
            pr_default.execute(30, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               A780SerasaUltimaData_F = BC000O59_A780SerasaUltimaData_F[0];
               A732SerasaConsultas_F = BC000O59_A732SerasaConsultas_F[0];
            }
            else
            {
               A732SerasaConsultas_F = 0;
               A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
            }
            pr_default.close(30);
            /* Using cursor BC000O61 */
            pr_default.execute(31, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               A781SerasaScoreUltimaData_F = BC000O61_A781SerasaScoreUltimaData_F[0];
               A785SerasaUltimoValorRecomendado_F = BC000O61_A785SerasaUltimoValorRecomendado_F[0];
            }
            else
            {
               A781SerasaScoreUltimaData_F = 0;
               A785SerasaUltimoValorRecomendado_F = 0;
            }
            pr_default.close(31);
            /* Using cursor BC000O63 */
            pr_default.execute(32, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               A1031RelacionamentoSacado = BC000O63_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = BC000O63_n1031RelacionamentoSacado[0];
            }
            else
            {
               A1031RelacionamentoSacado = 0;
               n1031RelacionamentoSacado = false;
            }
            pr_default.close(32);
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            /* Using cursor BC000O64 */
            pr_default.execute(33, new Object[] {n192TipoClienteId, A192TipoClienteId});
            A193TipoClienteDescricao = BC000O64_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000O64_n193TipoClienteDescricao[0];
            A207TipoClientePortal = BC000O64_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000O64_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = BC000O64_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000O64_n793TipoClientePortalPjPf[0];
            pr_default.close(33);
            /* Using cursor BC000O65 */
            pr_default.execute(34, new Object[] {n489ClienteConvenio, A489ClienteConvenio});
            A490ClienteConvenioDescricao = BC000O65_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = BC000O65_n490ClienteConvenioDescricao[0];
            pr_default.close(34);
            /* Using cursor BC000O66 */
            pr_default.execute(35, new Object[] {n484ClienteNacionalidade, A484ClienteNacionalidade});
            A485ClienteNacionalidadeNome = BC000O66_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = BC000O66_n485ClienteNacionalidadeNome[0];
            pr_default.close(35);
            /* Using cursor BC000O67 */
            pr_default.execute(36, new Object[] {n487ClienteProfissao, A487ClienteProfissao});
            A488ClienteProfissaoNome = BC000O67_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = BC000O67_n488ClienteProfissaoNome[0];
            pr_default.close(36);
            /* Using cursor BC000O68 */
            pr_default.execute(37, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            A187MunicipioNome = BC000O68_A187MunicipioNome[0];
            n187MunicipioNome = BC000O68_n187MunicipioNome[0];
            A189MunicipioUF = BC000O68_A189MunicipioUF[0];
            n189MunicipioUF = BC000O68_n189MunicipioUF[0];
            pr_default.close(37);
            A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
            A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
            /* Using cursor BC000O69 */
            pr_default.execute(38, new Object[] {n402BancoId, A402BancoId});
            A404BancoCodigo = BC000O69_A404BancoCodigo[0];
            n404BancoCodigo = BC000O69_n404BancoCodigo[0];
            A403BancoNome = BC000O69_A403BancoNome[0];
            n403BancoNome = BC000O69_n403BancoNome[0];
            pr_default.close(38);
            /* Using cursor BC000O70 */
            pr_default.execute(39, new Object[] {n437ResponsavelNacionalidade, A437ResponsavelNacionalidade});
            A438ResponsavelNacionalidadeNome = BC000O70_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = BC000O70_n438ResponsavelNacionalidadeNome[0];
            pr_default.close(39);
            /* Using cursor BC000O71 */
            pr_default.execute(40, new Object[] {n442ResponsavelProfissao, A442ResponsavelProfissao});
            A443ResponsavelProfissaoNome = BC000O71_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = BC000O71_n443ResponsavelProfissaoNome[0];
            pr_default.close(40);
            /* Using cursor BC000O72 */
            pr_default.execute(41, new Object[] {n444ResponsavelMunicipio, A444ResponsavelMunicipio});
            A446ResponsavelMunicipioUF = BC000O72_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = BC000O72_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = BC000O72_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = BC000O72_n445ResponsavelMunicipioNome[0];
            pr_default.close(41);
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
            A577ResponsavelCelular_F = GXt_char1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000O73 */
            pr_default.execute(42, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor BC000O74 */
            pr_default.execute(43, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sd Proposta Empresa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor BC000O75 */
            pr_default.execute(44, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sb Proposta Clinica"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor BC000O76 */
            pr_default.execute(45, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Responsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor BC000O77 */
            pr_default.execute(46, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor BC000O78 */
            pr_default.execute(47, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor BC000O79 */
            pr_default.execute(48, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor BC000O80 */
            pr_default.execute(49, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor BC000O81 */
            pr_default.execute(50, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Relacionamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor BC000O82 */
            pr_default.execute(51, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor BC000O83 */
            pr_default.execute(52, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor BC000O84 */
            pr_default.execute(53, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor BC000O85 */
            pr_default.execute(54, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"+" ("+"Sb Nota Destinatario Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
            /* Using cursor BC000O86 */
            pr_default.execute(55, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(55) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(55);
            /* Using cursor BC000O87 */
            pr_default.execute(56, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(56) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Serasa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(56);
            /* Using cursor BC000O88 */
            pr_default.execute(57, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(57) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(57);
            /* Using cursor BC000O89 */
            pr_default.execute(58, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(58) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"+" ("+"Sb Cliente Reponsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(58);
            /* Using cursor BC000O90 */
            pr_default.execute(59, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(59) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(59);
            /* Using cursor BC000O91 */
            pr_default.execute(60, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(60) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(60);
            /* Using cursor BC000O92 */
            pr_default.execute(61, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"+" ("+"SBFin Cli Int"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
            /* Using cursor BC000O93 */
            pr_default.execute(62, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(62) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(62);
         }
      }

      protected void EndLevel0O28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O28( ) ;
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

      public void ScanKeyStart0O28( )
      {
         /* Scan By routine */
         /* Using cursor BC000O103 */
         pr_default.execute(63, new Object[] {n168ClienteId, A168ClienteId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = BC000O103_A168ClienteId[0];
            n168ClienteId = BC000O103_n168ClienteId[0];
            A175ClienteCreatedAt = BC000O103_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = BC000O103_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = BC000O103_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = BC000O103_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = BC000O103_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000O103_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = BC000O103_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000O103_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = BC000O103_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = BC000O103_n171ClienteNomeFantasia[0];
            A459ClienteDataNascimento = BC000O103_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = BC000O103_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = BC000O103_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = BC000O103_n172ClienteTipoPessoa[0];
            A193TipoClienteDescricao = BC000O103_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000O103_n193TipoClienteDescricao[0];
            A207TipoClientePortal = BC000O103_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000O103_n207TipoClientePortal[0];
            A174ClienteStatus = BC000O103_A174ClienteStatus[0];
            n174ClienteStatus = BC000O103_n174ClienteStatus[0];
            A490ClienteConvenioDescricao = BC000O103_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = BC000O103_n490ClienteConvenioDescricao[0];
            A177ClienteLogUser = BC000O103_A177ClienteLogUser[0];
            n177ClienteLogUser = BC000O103_n177ClienteLogUser[0];
            A485ClienteNacionalidadeNome = BC000O103_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = BC000O103_n485ClienteNacionalidadeNome[0];
            A488ClienteProfissaoNome = BC000O103_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = BC000O103_n488ClienteProfissaoNome[0];
            A486ClienteEstadoCivil = BC000O103_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = BC000O103_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = BC000O103_A181EnderecoTipo[0];
            n181EnderecoTipo = BC000O103_n181EnderecoTipo[0];
            A182EnderecoCEP = BC000O103_A182EnderecoCEP[0];
            n182EnderecoCEP = BC000O103_n182EnderecoCEP[0];
            A183EnderecoLogradouro = BC000O103_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = BC000O103_n183EnderecoLogradouro[0];
            A184EnderecoBairro = BC000O103_A184EnderecoBairro[0];
            n184EnderecoBairro = BC000O103_n184EnderecoBairro[0];
            A185EnderecoCidade = BC000O103_A185EnderecoCidade[0];
            n185EnderecoCidade = BC000O103_n185EnderecoCidade[0];
            A187MunicipioNome = BC000O103_A187MunicipioNome[0];
            n187MunicipioNome = BC000O103_n187MunicipioNome[0];
            A189MunicipioUF = BC000O103_A189MunicipioUF[0];
            n189MunicipioUF = BC000O103_n189MunicipioUF[0];
            A190EnderecoNumero = BC000O103_A190EnderecoNumero[0];
            n190EnderecoNumero = BC000O103_n190EnderecoNumero[0];
            A191EnderecoComplemento = BC000O103_A191EnderecoComplemento[0];
            n191EnderecoComplemento = BC000O103_n191EnderecoComplemento[0];
            A201ContatoEmail = BC000O103_A201ContatoEmail[0];
            n201ContatoEmail = BC000O103_n201ContatoEmail[0];
            A198ContatoDDD = BC000O103_A198ContatoDDD[0];
            n198ContatoDDD = BC000O103_n198ContatoDDD[0];
            A199ContatoDDI = BC000O103_A199ContatoDDI[0];
            n199ContatoDDI = BC000O103_n199ContatoDDI[0];
            A200ContatoNumero = BC000O103_A200ContatoNumero[0];
            n200ContatoNumero = BC000O103_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = BC000O103_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = BC000O103_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = BC000O103_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = BC000O103_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = BC000O103_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = BC000O103_n204ContatoTelefoneDDI[0];
            A421ClienteRG = BC000O103_A421ClienteRG[0];
            n421ClienteRG = BC000O103_n421ClienteRG[0];
            A537ClienteDepositoTipo = BC000O103_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = BC000O103_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = BC000O103_A538ClientePixTipo[0];
            n538ClientePixTipo = BC000O103_n538ClientePixTipo[0];
            A539ClientePix = BC000O103_A539ClientePix[0];
            n539ClientePix = BC000O103_n539ClientePix[0];
            A404BancoCodigo = BC000O103_A404BancoCodigo[0];
            n404BancoCodigo = BC000O103_n404BancoCodigo[0];
            A403BancoNome = BC000O103_A403BancoNome[0];
            n403BancoNome = BC000O103_n403BancoNome[0];
            A400ContaAgencia = BC000O103_A400ContaAgencia[0];
            n400ContaAgencia = BC000O103_n400ContaAgencia[0];
            A401ContaNumero = BC000O103_A401ContaNumero[0];
            n401ContaNumero = BC000O103_n401ContaNumero[0];
            A436ResponsavelNome = BC000O103_A436ResponsavelNome[0];
            n436ResponsavelNome = BC000O103_n436ResponsavelNome[0];
            A438ResponsavelNacionalidadeNome = BC000O103_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = BC000O103_n438ResponsavelNacionalidadeNome[0];
            A439ResponsavelEstadoCivil = BC000O103_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = BC000O103_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = BC000O103_A576ResponsavelRG[0];
            n576ResponsavelRG = BC000O103_n576ResponsavelRG[0];
            A443ResponsavelProfissaoNome = BC000O103_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = BC000O103_n443ResponsavelProfissaoNome[0];
            A447ResponsavelCPF = BC000O103_A447ResponsavelCPF[0];
            n447ResponsavelCPF = BC000O103_n447ResponsavelCPF[0];
            A448ResponsavelCEP = BC000O103_A448ResponsavelCEP[0];
            n448ResponsavelCEP = BC000O103_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = BC000O103_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = BC000O103_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = BC000O103_A450ResponsavelBairro[0];
            n450ResponsavelBairro = BC000O103_n450ResponsavelBairro[0];
            A451ResponsavelCidade = BC000O103_A451ResponsavelCidade[0];
            n451ResponsavelCidade = BC000O103_n451ResponsavelCidade[0];
            A446ResponsavelMunicipioUF = BC000O103_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = BC000O103_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = BC000O103_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = BC000O103_n445ResponsavelMunicipioNome[0];
            A452ResponsavelLogradouroNumero = BC000O103_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = BC000O103_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = BC000O103_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = BC000O103_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = BC000O103_A454ResponsavelDDD[0];
            n454ResponsavelDDD = BC000O103_n454ResponsavelDDD[0];
            A455ResponsavelNumero = BC000O103_A455ResponsavelNumero[0];
            n455ResponsavelNumero = BC000O103_n455ResponsavelNumero[0];
            A456ResponsavelEmail = BC000O103_A456ResponsavelEmail[0];
            n456ResponsavelEmail = BC000O103_n456ResponsavelEmail[0];
            A884ClienteSituacao = BC000O103_A884ClienteSituacao[0];
            n884ClienteSituacao = BC000O103_n884ClienteSituacao[0];
            A885ResponsavelCargo = BC000O103_A885ResponsavelCargo[0];
            n885ResponsavelCargo = BC000O103_n885ResponsavelCargo[0];
            A793TipoClientePortalPjPf = BC000O103_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000O103_n793TipoClientePortalPjPf[0];
            A1039ClienteTipoRisco = BC000O103_A1039ClienteTipoRisco[0];
            A192TipoClienteId = BC000O103_A192TipoClienteId[0];
            n192TipoClienteId = BC000O103_n192TipoClienteId[0];
            A186MunicipioCodigo = BC000O103_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000O103_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = BC000O103_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = BC000O103_n444ResponsavelMunicipio[0];
            A402BancoId = BC000O103_A402BancoId[0];
            n402BancoId = BC000O103_n402BancoId[0];
            A457EspecialidadeId = BC000O103_A457EspecialidadeId[0];
            n457EspecialidadeId = BC000O103_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = BC000O103_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = BC000O103_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = BC000O103_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = BC000O103_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = BC000O103_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = BC000O103_n442ResponsavelProfissao[0];
            A487ClienteProfissao = BC000O103_A487ClienteProfissao[0];
            n487ClienteProfissao = BC000O103_n487ClienteProfissao[0];
            A489ClienteConvenio = BC000O103_A489ClienteConvenio[0];
            n489ClienteConvenio = BC000O103_n489ClienteConvenio[0];
            A780SerasaUltimaData_F = BC000O103_A780SerasaUltimaData_F[0];
            A608SecUserId_F = BC000O103_A608SecUserId_F[0];
            n608SecUserId_F = BC000O103_n608SecUserId_F[0];
            A309ClienteQtdTitulos_F = BC000O103_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = BC000O103_n309ClienteQtdTitulos_F[0];
            A310ClienteValorAPagar_F = BC000O103_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = BC000O103_n310ClienteValorAPagar_F[0];
            A311ClienteValorAReceber_F = BC000O103_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = BC000O103_n311ClienteValorAReceber_F[0];
            A732SerasaConsultas_F = BC000O103_A732SerasaConsultas_F[0];
            A1031RelacionamentoSacado = BC000O103_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = BC000O103_n1031RelacionamentoSacado[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O28( )
      {
         /* Scan next routine */
         pr_default.readNext(63);
         RcdFound28 = 0;
         ScanKeyLoad0O28( ) ;
      }

      protected void ScanKeyLoad0O28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = BC000O103_A168ClienteId[0];
            n168ClienteId = BC000O103_n168ClienteId[0];
            A175ClienteCreatedAt = BC000O103_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = BC000O103_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = BC000O103_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = BC000O103_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = BC000O103_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000O103_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = BC000O103_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000O103_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = BC000O103_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = BC000O103_n171ClienteNomeFantasia[0];
            A459ClienteDataNascimento = BC000O103_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = BC000O103_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = BC000O103_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = BC000O103_n172ClienteTipoPessoa[0];
            A193TipoClienteDescricao = BC000O103_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000O103_n193TipoClienteDescricao[0];
            A207TipoClientePortal = BC000O103_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000O103_n207TipoClientePortal[0];
            A174ClienteStatus = BC000O103_A174ClienteStatus[0];
            n174ClienteStatus = BC000O103_n174ClienteStatus[0];
            A490ClienteConvenioDescricao = BC000O103_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = BC000O103_n490ClienteConvenioDescricao[0];
            A177ClienteLogUser = BC000O103_A177ClienteLogUser[0];
            n177ClienteLogUser = BC000O103_n177ClienteLogUser[0];
            A485ClienteNacionalidadeNome = BC000O103_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = BC000O103_n485ClienteNacionalidadeNome[0];
            A488ClienteProfissaoNome = BC000O103_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = BC000O103_n488ClienteProfissaoNome[0];
            A486ClienteEstadoCivil = BC000O103_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = BC000O103_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = BC000O103_A181EnderecoTipo[0];
            n181EnderecoTipo = BC000O103_n181EnderecoTipo[0];
            A182EnderecoCEP = BC000O103_A182EnderecoCEP[0];
            n182EnderecoCEP = BC000O103_n182EnderecoCEP[0];
            A183EnderecoLogradouro = BC000O103_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = BC000O103_n183EnderecoLogradouro[0];
            A184EnderecoBairro = BC000O103_A184EnderecoBairro[0];
            n184EnderecoBairro = BC000O103_n184EnderecoBairro[0];
            A185EnderecoCidade = BC000O103_A185EnderecoCidade[0];
            n185EnderecoCidade = BC000O103_n185EnderecoCidade[0];
            A187MunicipioNome = BC000O103_A187MunicipioNome[0];
            n187MunicipioNome = BC000O103_n187MunicipioNome[0];
            A189MunicipioUF = BC000O103_A189MunicipioUF[0];
            n189MunicipioUF = BC000O103_n189MunicipioUF[0];
            A190EnderecoNumero = BC000O103_A190EnderecoNumero[0];
            n190EnderecoNumero = BC000O103_n190EnderecoNumero[0];
            A191EnderecoComplemento = BC000O103_A191EnderecoComplemento[0];
            n191EnderecoComplemento = BC000O103_n191EnderecoComplemento[0];
            A201ContatoEmail = BC000O103_A201ContatoEmail[0];
            n201ContatoEmail = BC000O103_n201ContatoEmail[0];
            A198ContatoDDD = BC000O103_A198ContatoDDD[0];
            n198ContatoDDD = BC000O103_n198ContatoDDD[0];
            A199ContatoDDI = BC000O103_A199ContatoDDI[0];
            n199ContatoDDI = BC000O103_n199ContatoDDI[0];
            A200ContatoNumero = BC000O103_A200ContatoNumero[0];
            n200ContatoNumero = BC000O103_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = BC000O103_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = BC000O103_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = BC000O103_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = BC000O103_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = BC000O103_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = BC000O103_n204ContatoTelefoneDDI[0];
            A421ClienteRG = BC000O103_A421ClienteRG[0];
            n421ClienteRG = BC000O103_n421ClienteRG[0];
            A537ClienteDepositoTipo = BC000O103_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = BC000O103_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = BC000O103_A538ClientePixTipo[0];
            n538ClientePixTipo = BC000O103_n538ClientePixTipo[0];
            A539ClientePix = BC000O103_A539ClientePix[0];
            n539ClientePix = BC000O103_n539ClientePix[0];
            A404BancoCodigo = BC000O103_A404BancoCodigo[0];
            n404BancoCodigo = BC000O103_n404BancoCodigo[0];
            A403BancoNome = BC000O103_A403BancoNome[0];
            n403BancoNome = BC000O103_n403BancoNome[0];
            A400ContaAgencia = BC000O103_A400ContaAgencia[0];
            n400ContaAgencia = BC000O103_n400ContaAgencia[0];
            A401ContaNumero = BC000O103_A401ContaNumero[0];
            n401ContaNumero = BC000O103_n401ContaNumero[0];
            A436ResponsavelNome = BC000O103_A436ResponsavelNome[0];
            n436ResponsavelNome = BC000O103_n436ResponsavelNome[0];
            A438ResponsavelNacionalidadeNome = BC000O103_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = BC000O103_n438ResponsavelNacionalidadeNome[0];
            A439ResponsavelEstadoCivil = BC000O103_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = BC000O103_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = BC000O103_A576ResponsavelRG[0];
            n576ResponsavelRG = BC000O103_n576ResponsavelRG[0];
            A443ResponsavelProfissaoNome = BC000O103_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = BC000O103_n443ResponsavelProfissaoNome[0];
            A447ResponsavelCPF = BC000O103_A447ResponsavelCPF[0];
            n447ResponsavelCPF = BC000O103_n447ResponsavelCPF[0];
            A448ResponsavelCEP = BC000O103_A448ResponsavelCEP[0];
            n448ResponsavelCEP = BC000O103_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = BC000O103_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = BC000O103_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = BC000O103_A450ResponsavelBairro[0];
            n450ResponsavelBairro = BC000O103_n450ResponsavelBairro[0];
            A451ResponsavelCidade = BC000O103_A451ResponsavelCidade[0];
            n451ResponsavelCidade = BC000O103_n451ResponsavelCidade[0];
            A446ResponsavelMunicipioUF = BC000O103_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = BC000O103_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = BC000O103_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = BC000O103_n445ResponsavelMunicipioNome[0];
            A452ResponsavelLogradouroNumero = BC000O103_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = BC000O103_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = BC000O103_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = BC000O103_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = BC000O103_A454ResponsavelDDD[0];
            n454ResponsavelDDD = BC000O103_n454ResponsavelDDD[0];
            A455ResponsavelNumero = BC000O103_A455ResponsavelNumero[0];
            n455ResponsavelNumero = BC000O103_n455ResponsavelNumero[0];
            A456ResponsavelEmail = BC000O103_A456ResponsavelEmail[0];
            n456ResponsavelEmail = BC000O103_n456ResponsavelEmail[0];
            A884ClienteSituacao = BC000O103_A884ClienteSituacao[0];
            n884ClienteSituacao = BC000O103_n884ClienteSituacao[0];
            A885ResponsavelCargo = BC000O103_A885ResponsavelCargo[0];
            n885ResponsavelCargo = BC000O103_n885ResponsavelCargo[0];
            A793TipoClientePortalPjPf = BC000O103_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000O103_n793TipoClientePortalPjPf[0];
            A1039ClienteTipoRisco = BC000O103_A1039ClienteTipoRisco[0];
            A192TipoClienteId = BC000O103_A192TipoClienteId[0];
            n192TipoClienteId = BC000O103_n192TipoClienteId[0];
            A186MunicipioCodigo = BC000O103_A186MunicipioCodigo[0];
            n186MunicipioCodigo = BC000O103_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = BC000O103_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = BC000O103_n444ResponsavelMunicipio[0];
            A402BancoId = BC000O103_A402BancoId[0];
            n402BancoId = BC000O103_n402BancoId[0];
            A457EspecialidadeId = BC000O103_A457EspecialidadeId[0];
            n457EspecialidadeId = BC000O103_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = BC000O103_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = BC000O103_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = BC000O103_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = BC000O103_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = BC000O103_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = BC000O103_n442ResponsavelProfissao[0];
            A487ClienteProfissao = BC000O103_A487ClienteProfissao[0];
            n487ClienteProfissao = BC000O103_n487ClienteProfissao[0];
            A489ClienteConvenio = BC000O103_A489ClienteConvenio[0];
            n489ClienteConvenio = BC000O103_n489ClienteConvenio[0];
            A780SerasaUltimaData_F = BC000O103_A780SerasaUltimaData_F[0];
            A608SecUserId_F = BC000O103_A608SecUserId_F[0];
            n608SecUserId_F = BC000O103_n608SecUserId_F[0];
            A309ClienteQtdTitulos_F = BC000O103_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = BC000O103_n309ClienteQtdTitulos_F[0];
            A310ClienteValorAPagar_F = BC000O103_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = BC000O103_n310ClienteValorAPagar_F[0];
            A311ClienteValorAReceber_F = BC000O103_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = BC000O103_n311ClienteValorAReceber_F[0];
            A732SerasaConsultas_F = BC000O103_A732SerasaConsultas_F[0];
            A1031RelacionamentoSacado = BC000O103_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = BC000O103_n1031RelacionamentoSacado[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0O28( )
      {
         pr_default.close(63);
      }

      protected void AfterConfirm0O28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O28( )
      {
      }

      protected void send_integrity_lvl_hashes0O28( )
      {
      }

      protected void AddRow0O28( )
      {
         VarsToRow28( bcCliente) ;
      }

      protected void ReadRow0O28( )
      {
         RowToVars28( bcCliente, 1) ;
      }

      protected void InitializeNonKey0O28( )
      {
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         n175ClienteCreatedAt = false;
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         n176ClienteUpdatedAt = false;
         A1030ClienteSacado = false;
         A781SerasaScoreUltimaData_F = 0;
         A785SerasaUltimoValorRecomendado_F = 0;
         A577ResponsavelCelular_F = "";
         A205ClienteTelefone_F = "";
         A206ClienteCelular_F = "";
         A608SecUserId_F = 0;
         n608SecUserId_F = false;
         A169ClienteDocumento = "";
         n169ClienteDocumento = false;
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         A171ClienteNomeFantasia = "";
         n171ClienteNomeFantasia = false;
         A459ClienteDataNascimento = DateTime.MinValue;
         n459ClienteDataNascimento = false;
         A172ClienteTipoPessoa = "";
         n172ClienteTipoPessoa = false;
         A457EspecialidadeId = 0;
         n457EspecialidadeId = false;
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         A193TipoClienteDescricao = "";
         n193TipoClienteDescricao = false;
         A207TipoClientePortal = false;
         n207TipoClientePortal = false;
         A489ClienteConvenio = 0;
         n489ClienteConvenio = false;
         A490ClienteConvenioDescricao = "";
         n490ClienteConvenioDescricao = false;
         A177ClienteLogUser = 0;
         n177ClienteLogUser = false;
         A484ClienteNacionalidade = 0;
         n484ClienteNacionalidade = false;
         A485ClienteNacionalidadeNome = "";
         n485ClienteNacionalidadeNome = false;
         A487ClienteProfissao = 0;
         n487ClienteProfissao = false;
         A488ClienteProfissaoNome = "";
         n488ClienteProfissaoNome = false;
         A486ClienteEstadoCivil = "";
         n486ClienteEstadoCivil = false;
         A181EnderecoTipo = "";
         n181EnderecoTipo = false;
         A182EnderecoCEP = "";
         n182EnderecoCEP = false;
         A183EnderecoLogradouro = "";
         n183EnderecoLogradouro = false;
         A184EnderecoBairro = "";
         n184EnderecoBairro = false;
         A185EnderecoCidade = "";
         n185EnderecoCidade = false;
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         A190EnderecoNumero = "";
         n190EnderecoNumero = false;
         A191EnderecoComplemento = "";
         n191EnderecoComplemento = false;
         A201ContatoEmail = "";
         n201ContatoEmail = false;
         A198ContatoDDD = 0;
         n198ContatoDDD = false;
         A199ContatoDDI = 0;
         n199ContatoDDI = false;
         A200ContatoNumero = 0;
         n200ContatoNumero = false;
         A202ContatoTelefoneNumero = 0;
         n202ContatoTelefoneNumero = false;
         A203ContatoTelefoneDDD = 0;
         n203ContatoTelefoneDDD = false;
         A204ContatoTelefoneDDI = 0;
         n204ContatoTelefoneDDI = false;
         A421ClienteRG = 0;
         n421ClienteRG = false;
         A309ClienteQtdTitulos_F = 0;
         n309ClienteQtdTitulos_F = false;
         A310ClienteValorAPagar_F = 0;
         n310ClienteValorAPagar_F = false;
         A311ClienteValorAReceber_F = 0;
         n311ClienteValorAReceber_F = false;
         A537ClienteDepositoTipo = "";
         n537ClienteDepositoTipo = false;
         A538ClientePixTipo = "";
         n538ClientePixTipo = false;
         A539ClientePix = "";
         n539ClientePix = false;
         A402BancoId = 0;
         n402BancoId = false;
         A404BancoCodigo = 0;
         n404BancoCodigo = false;
         A403BancoNome = "";
         n403BancoNome = false;
         A400ContaAgencia = "";
         n400ContaAgencia = false;
         A401ContaNumero = "";
         n401ContaNumero = false;
         A436ResponsavelNome = "";
         n436ResponsavelNome = false;
         A437ResponsavelNacionalidade = 0;
         n437ResponsavelNacionalidade = false;
         A438ResponsavelNacionalidadeNome = "";
         n438ResponsavelNacionalidadeNome = false;
         A439ResponsavelEstadoCivil = "";
         n439ResponsavelEstadoCivil = false;
         A442ResponsavelProfissao = 0;
         n442ResponsavelProfissao = false;
         A576ResponsavelRG = 0;
         n576ResponsavelRG = false;
         A443ResponsavelProfissaoNome = "";
         n443ResponsavelProfissaoNome = false;
         A447ResponsavelCPF = "";
         n447ResponsavelCPF = false;
         A448ResponsavelCEP = "";
         n448ResponsavelCEP = false;
         A449ResponsavelLogradouro = "";
         n449ResponsavelLogradouro = false;
         A450ResponsavelBairro = "";
         n450ResponsavelBairro = false;
         A451ResponsavelCidade = "";
         n451ResponsavelCidade = false;
         A444ResponsavelMunicipio = "";
         n444ResponsavelMunicipio = false;
         A446ResponsavelMunicipioUF = "";
         n446ResponsavelMunicipioUF = false;
         A445ResponsavelMunicipioNome = "";
         n445ResponsavelMunicipioNome = false;
         A452ResponsavelLogradouroNumero = 0;
         n452ResponsavelLogradouroNumero = false;
         A453ResponsavelComplemento = "";
         n453ResponsavelComplemento = false;
         A454ResponsavelDDD = 0;
         n454ResponsavelDDD = false;
         A455ResponsavelNumero = 0;
         n455ResponsavelNumero = false;
         A456ResponsavelEmail = "";
         n456ResponsavelEmail = false;
         A732SerasaConsultas_F = 0;
         A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         A884ClienteSituacao = "";
         n884ClienteSituacao = false;
         A885ResponsavelCargo = "";
         n885ResponsavelCargo = false;
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         A1031RelacionamentoSacado = 0;
         n1031RelacionamentoSacado = false;
         A1039ClienteTipoRisco = "";
         A174ClienteStatus = true;
         n174ClienteStatus = false;
         Z175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         Z169ClienteDocumento = "";
         Z170ClienteRazaoSocial = "";
         Z171ClienteNomeFantasia = "";
         Z459ClienteDataNascimento = DateTime.MinValue;
         Z172ClienteTipoPessoa = "";
         Z174ClienteStatus = false;
         Z177ClienteLogUser = 0;
         Z486ClienteEstadoCivil = "";
         Z181EnderecoTipo = "";
         Z182EnderecoCEP = "";
         Z183EnderecoLogradouro = "";
         Z184EnderecoBairro = "";
         Z185EnderecoCidade = "";
         Z190EnderecoNumero = "";
         Z191EnderecoComplemento = "";
         Z201ContatoEmail = "";
         Z198ContatoDDD = 0;
         Z199ContatoDDI = 0;
         Z200ContatoNumero = 0;
         Z202ContatoTelefoneNumero = 0;
         Z203ContatoTelefoneDDD = 0;
         Z204ContatoTelefoneDDI = 0;
         Z421ClienteRG = 0;
         Z537ClienteDepositoTipo = "";
         Z538ClientePixTipo = "";
         Z539ClientePix = "";
         Z400ContaAgencia = "";
         Z401ContaNumero = "";
         Z436ResponsavelNome = "";
         Z439ResponsavelEstadoCivil = "";
         Z576ResponsavelRG = 0;
         Z447ResponsavelCPF = "";
         Z448ResponsavelCEP = "";
         Z449ResponsavelLogradouro = "";
         Z450ResponsavelBairro = "";
         Z451ResponsavelCidade = "";
         Z452ResponsavelLogradouroNumero = 0;
         Z453ResponsavelComplemento = "";
         Z454ResponsavelDDD = 0;
         Z455ResponsavelNumero = 0;
         Z456ResponsavelEmail = "";
         Z884ClienteSituacao = "";
         Z885ResponsavelCargo = "";
         Z1039ClienteTipoRisco = "";
         Z192TipoClienteId = 0;
         Z186MunicipioCodigo = "";
         Z444ResponsavelMunicipio = "";
         Z402BancoId = 0;
         Z457EspecialidadeId = 0;
         Z437ResponsavelNacionalidade = 0;
         Z484ClienteNacionalidade = 0;
         Z442ResponsavelProfissao = 0;
         Z487ClienteProfissao = 0;
         Z489ClienteConvenio = 0;
      }

      protected void InitAll0O28( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         InitializeNonKey0O28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A175ClienteCreatedAt = i175ClienteCreatedAt;
         n175ClienteCreatedAt = false;
         A174ClienteStatus = i174ClienteStatus;
         n174ClienteStatus = false;
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

      public void VarsToRow28( SdtCliente obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Clientecreatedat = A175ClienteCreatedAt;
         obj28.gxTpr_Clienteupdatedat = A176ClienteUpdatedAt;
         obj28.gxTpr_Clientesacado = A1030ClienteSacado;
         obj28.gxTpr_Serasascoreultimadata_f = A781SerasaScoreUltimaData_F;
         obj28.gxTpr_Serasaultimovalorrecomendado_f = A785SerasaUltimoValorRecomendado_F;
         obj28.gxTpr_Responsavelcelular_f = A577ResponsavelCelular_F;
         obj28.gxTpr_Clientetelefone_f = A205ClienteTelefone_F;
         obj28.gxTpr_Clientecelular_f = A206ClienteCelular_F;
         obj28.gxTpr_Secuserid_f = A608SecUserId_F;
         obj28.gxTpr_Clientedocumento = A169ClienteDocumento;
         obj28.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
         obj28.gxTpr_Clientenomefantasia = A171ClienteNomeFantasia;
         obj28.gxTpr_Clientedatanascimento = A459ClienteDataNascimento;
         obj28.gxTpr_Clientetipopessoa = A172ClienteTipoPessoa;
         obj28.gxTpr_Especialidadeid = A457EspecialidadeId;
         obj28.gxTpr_Tipoclienteid = A192TipoClienteId;
         obj28.gxTpr_Tipoclientedescricao = A193TipoClienteDescricao;
         obj28.gxTpr_Tipoclienteportal = A207TipoClientePortal;
         obj28.gxTpr_Clienteconvenio = A489ClienteConvenio;
         obj28.gxTpr_Clienteconveniodescricao = A490ClienteConvenioDescricao;
         obj28.gxTpr_Clienteloguser = A177ClienteLogUser;
         obj28.gxTpr_Clientenacionalidade = A484ClienteNacionalidade;
         obj28.gxTpr_Clientenacionalidadenome = A485ClienteNacionalidadeNome;
         obj28.gxTpr_Clienteprofissao = A487ClienteProfissao;
         obj28.gxTpr_Clienteprofissaonome = A488ClienteProfissaoNome;
         obj28.gxTpr_Clienteestadocivil = A486ClienteEstadoCivil;
         obj28.gxTpr_Enderecotipo = A181EnderecoTipo;
         obj28.gxTpr_Enderecocep = A182EnderecoCEP;
         obj28.gxTpr_Enderecologradouro = A183EnderecoLogradouro;
         obj28.gxTpr_Enderecobairro = A184EnderecoBairro;
         obj28.gxTpr_Enderecocidade = A185EnderecoCidade;
         obj28.gxTpr_Municipiocodigo = A186MunicipioCodigo;
         obj28.gxTpr_Municipionome = A187MunicipioNome;
         obj28.gxTpr_Municipiouf = A189MunicipioUF;
         obj28.gxTpr_Endereconumero = A190EnderecoNumero;
         obj28.gxTpr_Enderecocomplemento = A191EnderecoComplemento;
         obj28.gxTpr_Contatoemail = A201ContatoEmail;
         obj28.gxTpr_Contatoddd = A198ContatoDDD;
         obj28.gxTpr_Contatoddi = A199ContatoDDI;
         obj28.gxTpr_Contatonumero = A200ContatoNumero;
         obj28.gxTpr_Contatotelefonenumero = A202ContatoTelefoneNumero;
         obj28.gxTpr_Contatotelefoneddd = A203ContatoTelefoneDDD;
         obj28.gxTpr_Contatotelefoneddi = A204ContatoTelefoneDDI;
         obj28.gxTpr_Clienterg = A421ClienteRG;
         obj28.gxTpr_Clienteqtdtitulos_f = A309ClienteQtdTitulos_F;
         obj28.gxTpr_Clientevalorapagar_f = A310ClienteValorAPagar_F;
         obj28.gxTpr_Clientevalorareceber_f = A311ClienteValorAReceber_F;
         obj28.gxTpr_Clientedepositotipo = A537ClienteDepositoTipo;
         obj28.gxTpr_Clientepixtipo = A538ClientePixTipo;
         obj28.gxTpr_Clientepix = A539ClientePix;
         obj28.gxTpr_Bancoid = A402BancoId;
         obj28.gxTpr_Bancocodigo = A404BancoCodigo;
         obj28.gxTpr_Banconome = A403BancoNome;
         obj28.gxTpr_Contaagencia = A400ContaAgencia;
         obj28.gxTpr_Contanumero = A401ContaNumero;
         obj28.gxTpr_Responsavelnome = A436ResponsavelNome;
         obj28.gxTpr_Responsavelnacionalidade = A437ResponsavelNacionalidade;
         obj28.gxTpr_Responsavelnacionalidadenome = A438ResponsavelNacionalidadeNome;
         obj28.gxTpr_Responsavelestadocivil = A439ResponsavelEstadoCivil;
         obj28.gxTpr_Responsavelprofissao = A442ResponsavelProfissao;
         obj28.gxTpr_Responsavelrg = A576ResponsavelRG;
         obj28.gxTpr_Responsavelprofissaonome = A443ResponsavelProfissaoNome;
         obj28.gxTpr_Responsavelcpf = A447ResponsavelCPF;
         obj28.gxTpr_Responsavelcep = A448ResponsavelCEP;
         obj28.gxTpr_Responsavellogradouro = A449ResponsavelLogradouro;
         obj28.gxTpr_Responsavelbairro = A450ResponsavelBairro;
         obj28.gxTpr_Responsavelcidade = A451ResponsavelCidade;
         obj28.gxTpr_Responsavelmunicipio = A444ResponsavelMunicipio;
         obj28.gxTpr_Responsavelmunicipiouf = A446ResponsavelMunicipioUF;
         obj28.gxTpr_Responsavelmunicipionome = A445ResponsavelMunicipioNome;
         obj28.gxTpr_Responsavellogradouronumero = A452ResponsavelLogradouroNumero;
         obj28.gxTpr_Responsavelcomplemento = A453ResponsavelComplemento;
         obj28.gxTpr_Responsavelddd = A454ResponsavelDDD;
         obj28.gxTpr_Responsavelnumero = A455ResponsavelNumero;
         obj28.gxTpr_Responsavelemail = A456ResponsavelEmail;
         obj28.gxTpr_Serasaconsultas_f = A732SerasaConsultas_F;
         obj28.gxTpr_Serasaultimadata_f = A780SerasaUltimaData_F;
         obj28.gxTpr_Clientesituacao = A884ClienteSituacao;
         obj28.gxTpr_Responsavelcargo = A885ResponsavelCargo;
         obj28.gxTpr_Tipoclienteportalpjpf = A793TipoClientePortalPjPf;
         obj28.gxTpr_Relacionamentosacado = A1031RelacionamentoSacado;
         obj28.gxTpr_Clientetiporisco = A1039ClienteTipoRisco;
         obj28.gxTpr_Clientestatus = A174ClienteStatus;
         obj28.gxTpr_Clienteid = A168ClienteId;
         obj28.gxTpr_Clienteid_Z = Z168ClienteId;
         obj28.gxTpr_Clientedocumento_Z = Z169ClienteDocumento;
         obj28.gxTpr_Clienterazaosocial_Z = Z170ClienteRazaoSocial;
         obj28.gxTpr_Clientenomefantasia_Z = Z171ClienteNomeFantasia;
         obj28.gxTpr_Clientedatanascimento_Z = Z459ClienteDataNascimento;
         obj28.gxTpr_Clientetipopessoa_Z = Z172ClienteTipoPessoa;
         obj28.gxTpr_Especialidadeid_Z = Z457EspecialidadeId;
         obj28.gxTpr_Tipoclienteid_Z = Z192TipoClienteId;
         obj28.gxTpr_Tipoclientedescricao_Z = Z193TipoClienteDescricao;
         obj28.gxTpr_Tipoclienteportal_Z = Z207TipoClientePortal;
         obj28.gxTpr_Clientestatus_Z = Z174ClienteStatus;
         obj28.gxTpr_Clienteconvenio_Z = Z489ClienteConvenio;
         obj28.gxTpr_Clienteconveniodescricao_Z = Z490ClienteConvenioDescricao;
         obj28.gxTpr_Clientecreatedat_Z = Z175ClienteCreatedAt;
         obj28.gxTpr_Clienteupdatedat_Z = Z176ClienteUpdatedAt;
         obj28.gxTpr_Clienteloguser_Z = Z177ClienteLogUser;
         obj28.gxTpr_Clientenacionalidade_Z = Z484ClienteNacionalidade;
         obj28.gxTpr_Clientenacionalidadenome_Z = Z485ClienteNacionalidadeNome;
         obj28.gxTpr_Clienteprofissao_Z = Z487ClienteProfissao;
         obj28.gxTpr_Clienteprofissaonome_Z = Z488ClienteProfissaoNome;
         obj28.gxTpr_Clienteestadocivil_Z = Z486ClienteEstadoCivil;
         obj28.gxTpr_Secuserid_f_Z = Z608SecUserId_F;
         obj28.gxTpr_Enderecotipo_Z = Z181EnderecoTipo;
         obj28.gxTpr_Enderecocep_Z = Z182EnderecoCEP;
         obj28.gxTpr_Enderecologradouro_Z = Z183EnderecoLogradouro;
         obj28.gxTpr_Enderecobairro_Z = Z184EnderecoBairro;
         obj28.gxTpr_Enderecocidade_Z = Z185EnderecoCidade;
         obj28.gxTpr_Municipiocodigo_Z = Z186MunicipioCodigo;
         obj28.gxTpr_Municipionome_Z = Z187MunicipioNome;
         obj28.gxTpr_Municipiouf_Z = Z189MunicipioUF;
         obj28.gxTpr_Endereconumero_Z = Z190EnderecoNumero;
         obj28.gxTpr_Enderecocomplemento_Z = Z191EnderecoComplemento;
         obj28.gxTpr_Contatoemail_Z = Z201ContatoEmail;
         obj28.gxTpr_Contatoddd_Z = Z198ContatoDDD;
         obj28.gxTpr_Contatoddi_Z = Z199ContatoDDI;
         obj28.gxTpr_Contatonumero_Z = Z200ContatoNumero;
         obj28.gxTpr_Contatotelefonenumero_Z = Z202ContatoTelefoneNumero;
         obj28.gxTpr_Contatotelefoneddd_Z = Z203ContatoTelefoneDDD;
         obj28.gxTpr_Contatotelefoneddi_Z = Z204ContatoTelefoneDDI;
         obj28.gxTpr_Clienterg_Z = Z421ClienteRG;
         obj28.gxTpr_Clientetelefone_f_Z = Z205ClienteTelefone_F;
         obj28.gxTpr_Clientecelular_f_Z = Z206ClienteCelular_F;
         obj28.gxTpr_Clienteqtdtitulos_f_Z = Z309ClienteQtdTitulos_F;
         obj28.gxTpr_Clientevalorapagar_f_Z = Z310ClienteValorAPagar_F;
         obj28.gxTpr_Clientevalorareceber_f_Z = Z311ClienteValorAReceber_F;
         obj28.gxTpr_Clientedepositotipo_Z = Z537ClienteDepositoTipo;
         obj28.gxTpr_Clientepixtipo_Z = Z538ClientePixTipo;
         obj28.gxTpr_Clientepix_Z = Z539ClientePix;
         obj28.gxTpr_Bancoid_Z = Z402BancoId;
         obj28.gxTpr_Bancocodigo_Z = Z404BancoCodigo;
         obj28.gxTpr_Banconome_Z = Z403BancoNome;
         obj28.gxTpr_Contaagencia_Z = Z400ContaAgencia;
         obj28.gxTpr_Contanumero_Z = Z401ContaNumero;
         obj28.gxTpr_Responsavelnome_Z = Z436ResponsavelNome;
         obj28.gxTpr_Responsavelnacionalidade_Z = Z437ResponsavelNacionalidade;
         obj28.gxTpr_Responsavelnacionalidadenome_Z = Z438ResponsavelNacionalidadeNome;
         obj28.gxTpr_Responsavelestadocivil_Z = Z439ResponsavelEstadoCivil;
         obj28.gxTpr_Responsavelprofissao_Z = Z442ResponsavelProfissao;
         obj28.gxTpr_Responsavelrg_Z = Z576ResponsavelRG;
         obj28.gxTpr_Responsavelprofissaonome_Z = Z443ResponsavelProfissaoNome;
         obj28.gxTpr_Responsavelcpf_Z = Z447ResponsavelCPF;
         obj28.gxTpr_Responsavelcep_Z = Z448ResponsavelCEP;
         obj28.gxTpr_Responsavellogradouro_Z = Z449ResponsavelLogradouro;
         obj28.gxTpr_Responsavelbairro_Z = Z450ResponsavelBairro;
         obj28.gxTpr_Responsavelcidade_Z = Z451ResponsavelCidade;
         obj28.gxTpr_Responsavelmunicipio_Z = Z444ResponsavelMunicipio;
         obj28.gxTpr_Responsavelmunicipiouf_Z = Z446ResponsavelMunicipioUF;
         obj28.gxTpr_Responsavelmunicipionome_Z = Z445ResponsavelMunicipioNome;
         obj28.gxTpr_Responsavellogradouronumero_Z = Z452ResponsavelLogradouroNumero;
         obj28.gxTpr_Responsavelcomplemento_Z = Z453ResponsavelComplemento;
         obj28.gxTpr_Responsavelddd_Z = Z454ResponsavelDDD;
         obj28.gxTpr_Responsavelnumero_Z = Z455ResponsavelNumero;
         obj28.gxTpr_Responsavelemail_Z = Z456ResponsavelEmail;
         obj28.gxTpr_Responsavelcelular_f_Z = Z577ResponsavelCelular_F;
         obj28.gxTpr_Serasaconsultas_f_Z = Z732SerasaConsultas_F;
         obj28.gxTpr_Serasaultimadata_f_Z = Z780SerasaUltimaData_F;
         obj28.gxTpr_Serasascoreultimadata_f_Z = Z781SerasaScoreUltimaData_F;
         obj28.gxTpr_Serasaultimovalorrecomendado_f_Z = Z785SerasaUltimoValorRecomendado_F;
         obj28.gxTpr_Clientesituacao_Z = Z884ClienteSituacao;
         obj28.gxTpr_Responsavelcargo_Z = Z885ResponsavelCargo;
         obj28.gxTpr_Tipoclienteportalpjpf_Z = Z793TipoClientePortalPjPf;
         obj28.gxTpr_Relacionamentosacado_Z = Z1031RelacionamentoSacado;
         obj28.gxTpr_Clientesacado_Z = Z1030ClienteSacado;
         obj28.gxTpr_Clientetiporisco_Z = Z1039ClienteTipoRisco;
         obj28.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj28.gxTpr_Clientedocumento_N = (short)(Convert.ToInt16(n169ClienteDocumento));
         obj28.gxTpr_Clienterazaosocial_N = (short)(Convert.ToInt16(n170ClienteRazaoSocial));
         obj28.gxTpr_Clientenomefantasia_N = (short)(Convert.ToInt16(n171ClienteNomeFantasia));
         obj28.gxTpr_Clientedatanascimento_N = (short)(Convert.ToInt16(n459ClienteDataNascimento));
         obj28.gxTpr_Clientetipopessoa_N = (short)(Convert.ToInt16(n172ClienteTipoPessoa));
         obj28.gxTpr_Especialidadeid_N = (short)(Convert.ToInt16(n457EspecialidadeId));
         obj28.gxTpr_Tipoclienteid_N = (short)(Convert.ToInt16(n192TipoClienteId));
         obj28.gxTpr_Tipoclientedescricao_N = (short)(Convert.ToInt16(n193TipoClienteDescricao));
         obj28.gxTpr_Tipoclienteportal_N = (short)(Convert.ToInt16(n207TipoClientePortal));
         obj28.gxTpr_Clientestatus_N = (short)(Convert.ToInt16(n174ClienteStatus));
         obj28.gxTpr_Clienteconvenio_N = (short)(Convert.ToInt16(n489ClienteConvenio));
         obj28.gxTpr_Clienteconveniodescricao_N = (short)(Convert.ToInt16(n490ClienteConvenioDescricao));
         obj28.gxTpr_Clientecreatedat_N = (short)(Convert.ToInt16(n175ClienteCreatedAt));
         obj28.gxTpr_Clienteupdatedat_N = (short)(Convert.ToInt16(n176ClienteUpdatedAt));
         obj28.gxTpr_Clienteloguser_N = (short)(Convert.ToInt16(n177ClienteLogUser));
         obj28.gxTpr_Clientenacionalidade_N = (short)(Convert.ToInt16(n484ClienteNacionalidade));
         obj28.gxTpr_Clientenacionalidadenome_N = (short)(Convert.ToInt16(n485ClienteNacionalidadeNome));
         obj28.gxTpr_Clienteprofissao_N = (short)(Convert.ToInt16(n487ClienteProfissao));
         obj28.gxTpr_Clienteprofissaonome_N = (short)(Convert.ToInt16(n488ClienteProfissaoNome));
         obj28.gxTpr_Clienteestadocivil_N = (short)(Convert.ToInt16(n486ClienteEstadoCivil));
         obj28.gxTpr_Secuserid_f_N = (short)(Convert.ToInt16(n608SecUserId_F));
         obj28.gxTpr_Enderecotipo_N = (short)(Convert.ToInt16(n181EnderecoTipo));
         obj28.gxTpr_Enderecocep_N = (short)(Convert.ToInt16(n182EnderecoCEP));
         obj28.gxTpr_Enderecologradouro_N = (short)(Convert.ToInt16(n183EnderecoLogradouro));
         obj28.gxTpr_Enderecobairro_N = (short)(Convert.ToInt16(n184EnderecoBairro));
         obj28.gxTpr_Enderecocidade_N = (short)(Convert.ToInt16(n185EnderecoCidade));
         obj28.gxTpr_Municipiocodigo_N = (short)(Convert.ToInt16(n186MunicipioCodigo));
         obj28.gxTpr_Municipionome_N = (short)(Convert.ToInt16(n187MunicipioNome));
         obj28.gxTpr_Municipiouf_N = (short)(Convert.ToInt16(n189MunicipioUF));
         obj28.gxTpr_Endereconumero_N = (short)(Convert.ToInt16(n190EnderecoNumero));
         obj28.gxTpr_Enderecocomplemento_N = (short)(Convert.ToInt16(n191EnderecoComplemento));
         obj28.gxTpr_Contatoemail_N = (short)(Convert.ToInt16(n201ContatoEmail));
         obj28.gxTpr_Contatoddd_N = (short)(Convert.ToInt16(n198ContatoDDD));
         obj28.gxTpr_Contatoddi_N = (short)(Convert.ToInt16(n199ContatoDDI));
         obj28.gxTpr_Contatonumero_N = (short)(Convert.ToInt16(n200ContatoNumero));
         obj28.gxTpr_Contatotelefonenumero_N = (short)(Convert.ToInt16(n202ContatoTelefoneNumero));
         obj28.gxTpr_Contatotelefoneddd_N = (short)(Convert.ToInt16(n203ContatoTelefoneDDD));
         obj28.gxTpr_Contatotelefoneddi_N = (short)(Convert.ToInt16(n204ContatoTelefoneDDI));
         obj28.gxTpr_Clienterg_N = (short)(Convert.ToInt16(n421ClienteRG));
         obj28.gxTpr_Clienteqtdtitulos_f_N = (short)(Convert.ToInt16(n309ClienteQtdTitulos_F));
         obj28.gxTpr_Clientevalorapagar_f_N = (short)(Convert.ToInt16(n310ClienteValorAPagar_F));
         obj28.gxTpr_Clientevalorareceber_f_N = (short)(Convert.ToInt16(n311ClienteValorAReceber_F));
         obj28.gxTpr_Clientedepositotipo_N = (short)(Convert.ToInt16(n537ClienteDepositoTipo));
         obj28.gxTpr_Clientepixtipo_N = (short)(Convert.ToInt16(n538ClientePixTipo));
         obj28.gxTpr_Clientepix_N = (short)(Convert.ToInt16(n539ClientePix));
         obj28.gxTpr_Bancoid_N = (short)(Convert.ToInt16(n402BancoId));
         obj28.gxTpr_Bancocodigo_N = (short)(Convert.ToInt16(n404BancoCodigo));
         obj28.gxTpr_Banconome_N = (short)(Convert.ToInt16(n403BancoNome));
         obj28.gxTpr_Contaagencia_N = (short)(Convert.ToInt16(n400ContaAgencia));
         obj28.gxTpr_Contanumero_N = (short)(Convert.ToInt16(n401ContaNumero));
         obj28.gxTpr_Responsavelnome_N = (short)(Convert.ToInt16(n436ResponsavelNome));
         obj28.gxTpr_Responsavelnacionalidade_N = (short)(Convert.ToInt16(n437ResponsavelNacionalidade));
         obj28.gxTpr_Responsavelnacionalidadenome_N = (short)(Convert.ToInt16(n438ResponsavelNacionalidadeNome));
         obj28.gxTpr_Responsavelestadocivil_N = (short)(Convert.ToInt16(n439ResponsavelEstadoCivil));
         obj28.gxTpr_Responsavelprofissao_N = (short)(Convert.ToInt16(n442ResponsavelProfissao));
         obj28.gxTpr_Responsavelrg_N = (short)(Convert.ToInt16(n576ResponsavelRG));
         obj28.gxTpr_Responsavelprofissaonome_N = (short)(Convert.ToInt16(n443ResponsavelProfissaoNome));
         obj28.gxTpr_Responsavelcpf_N = (short)(Convert.ToInt16(n447ResponsavelCPF));
         obj28.gxTpr_Responsavelcep_N = (short)(Convert.ToInt16(n448ResponsavelCEP));
         obj28.gxTpr_Responsavellogradouro_N = (short)(Convert.ToInt16(n449ResponsavelLogradouro));
         obj28.gxTpr_Responsavelbairro_N = (short)(Convert.ToInt16(n450ResponsavelBairro));
         obj28.gxTpr_Responsavelcidade_N = (short)(Convert.ToInt16(n451ResponsavelCidade));
         obj28.gxTpr_Responsavelmunicipio_N = (short)(Convert.ToInt16(n444ResponsavelMunicipio));
         obj28.gxTpr_Responsavelmunicipiouf_N = (short)(Convert.ToInt16(n446ResponsavelMunicipioUF));
         obj28.gxTpr_Responsavelmunicipionome_N = (short)(Convert.ToInt16(n445ResponsavelMunicipioNome));
         obj28.gxTpr_Responsavellogradouronumero_N = (short)(Convert.ToInt16(n452ResponsavelLogradouroNumero));
         obj28.gxTpr_Responsavelcomplemento_N = (short)(Convert.ToInt16(n453ResponsavelComplemento));
         obj28.gxTpr_Responsavelddd_N = (short)(Convert.ToInt16(n454ResponsavelDDD));
         obj28.gxTpr_Responsavelnumero_N = (short)(Convert.ToInt16(n455ResponsavelNumero));
         obj28.gxTpr_Responsavelemail_N = (short)(Convert.ToInt16(n456ResponsavelEmail));
         obj28.gxTpr_Clientesituacao_N = (short)(Convert.ToInt16(n884ClienteSituacao));
         obj28.gxTpr_Responsavelcargo_N = (short)(Convert.ToInt16(n885ResponsavelCargo));
         obj28.gxTpr_Tipoclienteportalpjpf_N = (short)(Convert.ToInt16(n793TipoClientePortalPjPf));
         obj28.gxTpr_Relacionamentosacado_N = (short)(Convert.ToInt16(n1031RelacionamentoSacado));
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtCliente obj28 )
      {
         obj28.gxTpr_Clienteid = A168ClienteId;
         return  ;
      }

      public void RowToVars28( SdtCliente obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A175ClienteCreatedAt = obj28.gxTpr_Clientecreatedat;
         n175ClienteCreatedAt = false;
         A176ClienteUpdatedAt = obj28.gxTpr_Clienteupdatedat;
         n176ClienteUpdatedAt = false;
         A1030ClienteSacado = obj28.gxTpr_Clientesacado;
         A781SerasaScoreUltimaData_F = obj28.gxTpr_Serasascoreultimadata_f;
         A785SerasaUltimoValorRecomendado_F = obj28.gxTpr_Serasaultimovalorrecomendado_f;
         A577ResponsavelCelular_F = obj28.gxTpr_Responsavelcelular_f;
         A205ClienteTelefone_F = obj28.gxTpr_Clientetelefone_f;
         A206ClienteCelular_F = obj28.gxTpr_Clientecelular_f;
         A608SecUserId_F = obj28.gxTpr_Secuserid_f;
         n608SecUserId_F = false;
         A169ClienteDocumento = obj28.gxTpr_Clientedocumento;
         n169ClienteDocumento = false;
         A170ClienteRazaoSocial = obj28.gxTpr_Clienterazaosocial;
         n170ClienteRazaoSocial = false;
         A171ClienteNomeFantasia = obj28.gxTpr_Clientenomefantasia;
         n171ClienteNomeFantasia = false;
         A459ClienteDataNascimento = obj28.gxTpr_Clientedatanascimento;
         n459ClienteDataNascimento = false;
         A172ClienteTipoPessoa = obj28.gxTpr_Clientetipopessoa;
         n172ClienteTipoPessoa = false;
         A457EspecialidadeId = obj28.gxTpr_Especialidadeid;
         n457EspecialidadeId = false;
         A192TipoClienteId = obj28.gxTpr_Tipoclienteid;
         n192TipoClienteId = false;
         A193TipoClienteDescricao = obj28.gxTpr_Tipoclientedescricao;
         n193TipoClienteDescricao = false;
         A207TipoClientePortal = obj28.gxTpr_Tipoclienteportal;
         n207TipoClientePortal = false;
         A489ClienteConvenio = obj28.gxTpr_Clienteconvenio;
         n489ClienteConvenio = false;
         A490ClienteConvenioDescricao = obj28.gxTpr_Clienteconveniodescricao;
         n490ClienteConvenioDescricao = false;
         A177ClienteLogUser = obj28.gxTpr_Clienteloguser;
         n177ClienteLogUser = false;
         A484ClienteNacionalidade = obj28.gxTpr_Clientenacionalidade;
         n484ClienteNacionalidade = false;
         A485ClienteNacionalidadeNome = obj28.gxTpr_Clientenacionalidadenome;
         n485ClienteNacionalidadeNome = false;
         A487ClienteProfissao = obj28.gxTpr_Clienteprofissao;
         n487ClienteProfissao = false;
         A488ClienteProfissaoNome = obj28.gxTpr_Clienteprofissaonome;
         n488ClienteProfissaoNome = false;
         A486ClienteEstadoCivil = obj28.gxTpr_Clienteestadocivil;
         n486ClienteEstadoCivil = false;
         A181EnderecoTipo = obj28.gxTpr_Enderecotipo;
         n181EnderecoTipo = false;
         A182EnderecoCEP = obj28.gxTpr_Enderecocep;
         n182EnderecoCEP = false;
         A183EnderecoLogradouro = obj28.gxTpr_Enderecologradouro;
         n183EnderecoLogradouro = false;
         A184EnderecoBairro = obj28.gxTpr_Enderecobairro;
         n184EnderecoBairro = false;
         A185EnderecoCidade = obj28.gxTpr_Enderecocidade;
         n185EnderecoCidade = false;
         A186MunicipioCodigo = obj28.gxTpr_Municipiocodigo;
         n186MunicipioCodigo = false;
         A187MunicipioNome = obj28.gxTpr_Municipionome;
         n187MunicipioNome = false;
         A189MunicipioUF = obj28.gxTpr_Municipiouf;
         n189MunicipioUF = false;
         A190EnderecoNumero = obj28.gxTpr_Endereconumero;
         n190EnderecoNumero = false;
         A191EnderecoComplemento = obj28.gxTpr_Enderecocomplemento;
         n191EnderecoComplemento = false;
         A201ContatoEmail = obj28.gxTpr_Contatoemail;
         n201ContatoEmail = false;
         A198ContatoDDD = obj28.gxTpr_Contatoddd;
         n198ContatoDDD = false;
         A199ContatoDDI = obj28.gxTpr_Contatoddi;
         n199ContatoDDI = false;
         A200ContatoNumero = obj28.gxTpr_Contatonumero;
         n200ContatoNumero = false;
         A202ContatoTelefoneNumero = obj28.gxTpr_Contatotelefonenumero;
         n202ContatoTelefoneNumero = false;
         A203ContatoTelefoneDDD = obj28.gxTpr_Contatotelefoneddd;
         n203ContatoTelefoneDDD = false;
         A204ContatoTelefoneDDI = obj28.gxTpr_Contatotelefoneddi;
         n204ContatoTelefoneDDI = false;
         A421ClienteRG = obj28.gxTpr_Clienterg;
         n421ClienteRG = false;
         A309ClienteQtdTitulos_F = obj28.gxTpr_Clienteqtdtitulos_f;
         n309ClienteQtdTitulos_F = false;
         A310ClienteValorAPagar_F = obj28.gxTpr_Clientevalorapagar_f;
         n310ClienteValorAPagar_F = false;
         A311ClienteValorAReceber_F = obj28.gxTpr_Clientevalorareceber_f;
         n311ClienteValorAReceber_F = false;
         A537ClienteDepositoTipo = obj28.gxTpr_Clientedepositotipo;
         n537ClienteDepositoTipo = false;
         A538ClientePixTipo = obj28.gxTpr_Clientepixtipo;
         n538ClientePixTipo = false;
         A539ClientePix = obj28.gxTpr_Clientepix;
         n539ClientePix = false;
         A402BancoId = obj28.gxTpr_Bancoid;
         n402BancoId = false;
         A404BancoCodigo = obj28.gxTpr_Bancocodigo;
         n404BancoCodigo = false;
         A403BancoNome = obj28.gxTpr_Banconome;
         n403BancoNome = false;
         A400ContaAgencia = obj28.gxTpr_Contaagencia;
         n400ContaAgencia = false;
         A401ContaNumero = obj28.gxTpr_Contanumero;
         n401ContaNumero = false;
         A436ResponsavelNome = obj28.gxTpr_Responsavelnome;
         n436ResponsavelNome = false;
         A437ResponsavelNacionalidade = obj28.gxTpr_Responsavelnacionalidade;
         n437ResponsavelNacionalidade = false;
         A438ResponsavelNacionalidadeNome = obj28.gxTpr_Responsavelnacionalidadenome;
         n438ResponsavelNacionalidadeNome = false;
         A439ResponsavelEstadoCivil = obj28.gxTpr_Responsavelestadocivil;
         n439ResponsavelEstadoCivil = false;
         A442ResponsavelProfissao = obj28.gxTpr_Responsavelprofissao;
         n442ResponsavelProfissao = false;
         A576ResponsavelRG = obj28.gxTpr_Responsavelrg;
         n576ResponsavelRG = false;
         A443ResponsavelProfissaoNome = obj28.gxTpr_Responsavelprofissaonome;
         n443ResponsavelProfissaoNome = false;
         A447ResponsavelCPF = obj28.gxTpr_Responsavelcpf;
         n447ResponsavelCPF = false;
         A448ResponsavelCEP = obj28.gxTpr_Responsavelcep;
         n448ResponsavelCEP = false;
         A449ResponsavelLogradouro = obj28.gxTpr_Responsavellogradouro;
         n449ResponsavelLogradouro = false;
         A450ResponsavelBairro = obj28.gxTpr_Responsavelbairro;
         n450ResponsavelBairro = false;
         A451ResponsavelCidade = obj28.gxTpr_Responsavelcidade;
         n451ResponsavelCidade = false;
         A444ResponsavelMunicipio = obj28.gxTpr_Responsavelmunicipio;
         n444ResponsavelMunicipio = false;
         A446ResponsavelMunicipioUF = obj28.gxTpr_Responsavelmunicipiouf;
         n446ResponsavelMunicipioUF = false;
         A445ResponsavelMunicipioNome = obj28.gxTpr_Responsavelmunicipionome;
         n445ResponsavelMunicipioNome = false;
         A452ResponsavelLogradouroNumero = obj28.gxTpr_Responsavellogradouronumero;
         n452ResponsavelLogradouroNumero = false;
         A453ResponsavelComplemento = obj28.gxTpr_Responsavelcomplemento;
         n453ResponsavelComplemento = false;
         A454ResponsavelDDD = obj28.gxTpr_Responsavelddd;
         n454ResponsavelDDD = false;
         A455ResponsavelNumero = obj28.gxTpr_Responsavelnumero;
         n455ResponsavelNumero = false;
         A456ResponsavelEmail = obj28.gxTpr_Responsavelemail;
         n456ResponsavelEmail = false;
         A732SerasaConsultas_F = obj28.gxTpr_Serasaconsultas_f;
         A780SerasaUltimaData_F = obj28.gxTpr_Serasaultimadata_f;
         A884ClienteSituacao = obj28.gxTpr_Clientesituacao;
         n884ClienteSituacao = false;
         A885ResponsavelCargo = obj28.gxTpr_Responsavelcargo;
         n885ResponsavelCargo = false;
         A793TipoClientePortalPjPf = obj28.gxTpr_Tipoclienteportalpjpf;
         n793TipoClientePortalPjPf = false;
         A1031RelacionamentoSacado = obj28.gxTpr_Relacionamentosacado;
         n1031RelacionamentoSacado = false;
         A1039ClienteTipoRisco = obj28.gxTpr_Clientetiporisco;
         A174ClienteStatus = obj28.gxTpr_Clientestatus;
         n174ClienteStatus = false;
         A168ClienteId = obj28.gxTpr_Clienteid;
         n168ClienteId = false;
         Z168ClienteId = obj28.gxTpr_Clienteid_Z;
         Z169ClienteDocumento = obj28.gxTpr_Clientedocumento_Z;
         Z170ClienteRazaoSocial = obj28.gxTpr_Clienterazaosocial_Z;
         Z171ClienteNomeFantasia = obj28.gxTpr_Clientenomefantasia_Z;
         Z459ClienteDataNascimento = obj28.gxTpr_Clientedatanascimento_Z;
         Z172ClienteTipoPessoa = obj28.gxTpr_Clientetipopessoa_Z;
         Z457EspecialidadeId = obj28.gxTpr_Especialidadeid_Z;
         Z192TipoClienteId = obj28.gxTpr_Tipoclienteid_Z;
         Z193TipoClienteDescricao = obj28.gxTpr_Tipoclientedescricao_Z;
         Z207TipoClientePortal = obj28.gxTpr_Tipoclienteportal_Z;
         Z174ClienteStatus = obj28.gxTpr_Clientestatus_Z;
         Z489ClienteConvenio = obj28.gxTpr_Clienteconvenio_Z;
         Z490ClienteConvenioDescricao = obj28.gxTpr_Clienteconveniodescricao_Z;
         Z175ClienteCreatedAt = obj28.gxTpr_Clientecreatedat_Z;
         Z176ClienteUpdatedAt = obj28.gxTpr_Clienteupdatedat_Z;
         Z177ClienteLogUser = obj28.gxTpr_Clienteloguser_Z;
         Z484ClienteNacionalidade = obj28.gxTpr_Clientenacionalidade_Z;
         Z485ClienteNacionalidadeNome = obj28.gxTpr_Clientenacionalidadenome_Z;
         Z487ClienteProfissao = obj28.gxTpr_Clienteprofissao_Z;
         Z488ClienteProfissaoNome = obj28.gxTpr_Clienteprofissaonome_Z;
         Z486ClienteEstadoCivil = obj28.gxTpr_Clienteestadocivil_Z;
         Z608SecUserId_F = obj28.gxTpr_Secuserid_f_Z;
         Z181EnderecoTipo = obj28.gxTpr_Enderecotipo_Z;
         Z182EnderecoCEP = obj28.gxTpr_Enderecocep_Z;
         Z183EnderecoLogradouro = obj28.gxTpr_Enderecologradouro_Z;
         Z184EnderecoBairro = obj28.gxTpr_Enderecobairro_Z;
         Z185EnderecoCidade = obj28.gxTpr_Enderecocidade_Z;
         Z186MunicipioCodigo = obj28.gxTpr_Municipiocodigo_Z;
         Z187MunicipioNome = obj28.gxTpr_Municipionome_Z;
         Z189MunicipioUF = obj28.gxTpr_Municipiouf_Z;
         Z190EnderecoNumero = obj28.gxTpr_Endereconumero_Z;
         Z191EnderecoComplemento = obj28.gxTpr_Enderecocomplemento_Z;
         Z201ContatoEmail = obj28.gxTpr_Contatoemail_Z;
         Z198ContatoDDD = obj28.gxTpr_Contatoddd_Z;
         Z199ContatoDDI = obj28.gxTpr_Contatoddi_Z;
         Z200ContatoNumero = obj28.gxTpr_Contatonumero_Z;
         Z202ContatoTelefoneNumero = obj28.gxTpr_Contatotelefonenumero_Z;
         Z203ContatoTelefoneDDD = obj28.gxTpr_Contatotelefoneddd_Z;
         Z204ContatoTelefoneDDI = obj28.gxTpr_Contatotelefoneddi_Z;
         Z421ClienteRG = obj28.gxTpr_Clienterg_Z;
         Z205ClienteTelefone_F = obj28.gxTpr_Clientetelefone_f_Z;
         Z206ClienteCelular_F = obj28.gxTpr_Clientecelular_f_Z;
         Z309ClienteQtdTitulos_F = obj28.gxTpr_Clienteqtdtitulos_f_Z;
         Z310ClienteValorAPagar_F = obj28.gxTpr_Clientevalorapagar_f_Z;
         Z311ClienteValorAReceber_F = obj28.gxTpr_Clientevalorareceber_f_Z;
         Z537ClienteDepositoTipo = obj28.gxTpr_Clientedepositotipo_Z;
         Z538ClientePixTipo = obj28.gxTpr_Clientepixtipo_Z;
         Z539ClientePix = obj28.gxTpr_Clientepix_Z;
         Z402BancoId = obj28.gxTpr_Bancoid_Z;
         Z404BancoCodigo = obj28.gxTpr_Bancocodigo_Z;
         Z403BancoNome = obj28.gxTpr_Banconome_Z;
         Z400ContaAgencia = obj28.gxTpr_Contaagencia_Z;
         Z401ContaNumero = obj28.gxTpr_Contanumero_Z;
         Z436ResponsavelNome = obj28.gxTpr_Responsavelnome_Z;
         Z437ResponsavelNacionalidade = obj28.gxTpr_Responsavelnacionalidade_Z;
         Z438ResponsavelNacionalidadeNome = obj28.gxTpr_Responsavelnacionalidadenome_Z;
         Z439ResponsavelEstadoCivil = obj28.gxTpr_Responsavelestadocivil_Z;
         Z442ResponsavelProfissao = obj28.gxTpr_Responsavelprofissao_Z;
         Z576ResponsavelRG = obj28.gxTpr_Responsavelrg_Z;
         Z443ResponsavelProfissaoNome = obj28.gxTpr_Responsavelprofissaonome_Z;
         Z447ResponsavelCPF = obj28.gxTpr_Responsavelcpf_Z;
         Z448ResponsavelCEP = obj28.gxTpr_Responsavelcep_Z;
         Z449ResponsavelLogradouro = obj28.gxTpr_Responsavellogradouro_Z;
         Z450ResponsavelBairro = obj28.gxTpr_Responsavelbairro_Z;
         Z451ResponsavelCidade = obj28.gxTpr_Responsavelcidade_Z;
         Z444ResponsavelMunicipio = obj28.gxTpr_Responsavelmunicipio_Z;
         Z446ResponsavelMunicipioUF = obj28.gxTpr_Responsavelmunicipiouf_Z;
         Z445ResponsavelMunicipioNome = obj28.gxTpr_Responsavelmunicipionome_Z;
         Z452ResponsavelLogradouroNumero = obj28.gxTpr_Responsavellogradouronumero_Z;
         Z453ResponsavelComplemento = obj28.gxTpr_Responsavelcomplemento_Z;
         Z454ResponsavelDDD = obj28.gxTpr_Responsavelddd_Z;
         Z455ResponsavelNumero = obj28.gxTpr_Responsavelnumero_Z;
         Z456ResponsavelEmail = obj28.gxTpr_Responsavelemail_Z;
         Z577ResponsavelCelular_F = obj28.gxTpr_Responsavelcelular_f_Z;
         Z732SerasaConsultas_F = obj28.gxTpr_Serasaconsultas_f_Z;
         Z780SerasaUltimaData_F = obj28.gxTpr_Serasaultimadata_f_Z;
         Z781SerasaScoreUltimaData_F = obj28.gxTpr_Serasascoreultimadata_f_Z;
         Z785SerasaUltimoValorRecomendado_F = obj28.gxTpr_Serasaultimovalorrecomendado_f_Z;
         Z884ClienteSituacao = obj28.gxTpr_Clientesituacao_Z;
         Z885ResponsavelCargo = obj28.gxTpr_Responsavelcargo_Z;
         Z793TipoClientePortalPjPf = obj28.gxTpr_Tipoclienteportalpjpf_Z;
         Z1031RelacionamentoSacado = obj28.gxTpr_Relacionamentosacado_Z;
         Z1030ClienteSacado = obj28.gxTpr_Clientesacado_Z;
         Z1039ClienteTipoRisco = obj28.gxTpr_Clientetiporisco_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteid_N));
         n169ClienteDocumento = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientedocumento_N));
         n170ClienteRazaoSocial = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienterazaosocial_N));
         n171ClienteNomeFantasia = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientenomefantasia_N));
         n459ClienteDataNascimento = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientedatanascimento_N));
         n172ClienteTipoPessoa = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientetipopessoa_N));
         n457EspecialidadeId = (bool)(Convert.ToBoolean(obj28.gxTpr_Especialidadeid_N));
         n192TipoClienteId = (bool)(Convert.ToBoolean(obj28.gxTpr_Tipoclienteid_N));
         n193TipoClienteDescricao = (bool)(Convert.ToBoolean(obj28.gxTpr_Tipoclientedescricao_N));
         n207TipoClientePortal = (bool)(Convert.ToBoolean(obj28.gxTpr_Tipoclienteportal_N));
         n174ClienteStatus = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientestatus_N));
         n489ClienteConvenio = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteconvenio_N));
         n490ClienteConvenioDescricao = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteconveniodescricao_N));
         n175ClienteCreatedAt = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientecreatedat_N));
         n176ClienteUpdatedAt = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteupdatedat_N));
         n177ClienteLogUser = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteloguser_N));
         n484ClienteNacionalidade = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientenacionalidade_N));
         n485ClienteNacionalidadeNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientenacionalidadenome_N));
         n487ClienteProfissao = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteprofissao_N));
         n488ClienteProfissaoNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteprofissaonome_N));
         n486ClienteEstadoCivil = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteestadocivil_N));
         n608SecUserId_F = (bool)(Convert.ToBoolean(obj28.gxTpr_Secuserid_f_N));
         n181EnderecoTipo = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecotipo_N));
         n182EnderecoCEP = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecocep_N));
         n183EnderecoLogradouro = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecologradouro_N));
         n184EnderecoBairro = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecobairro_N));
         n185EnderecoCidade = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecocidade_N));
         n186MunicipioCodigo = (bool)(Convert.ToBoolean(obj28.gxTpr_Municipiocodigo_N));
         n187MunicipioNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Municipionome_N));
         n189MunicipioUF = (bool)(Convert.ToBoolean(obj28.gxTpr_Municipiouf_N));
         n190EnderecoNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Endereconumero_N));
         n191EnderecoComplemento = (bool)(Convert.ToBoolean(obj28.gxTpr_Enderecocomplemento_N));
         n201ContatoEmail = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatoemail_N));
         n198ContatoDDD = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatoddd_N));
         n199ContatoDDI = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatoddi_N));
         n200ContatoNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatonumero_N));
         n202ContatoTelefoneNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatotelefonenumero_N));
         n203ContatoTelefoneDDD = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatotelefoneddd_N));
         n204ContatoTelefoneDDI = (bool)(Convert.ToBoolean(obj28.gxTpr_Contatotelefoneddi_N));
         n421ClienteRG = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienterg_N));
         n309ClienteQtdTitulos_F = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteqtdtitulos_f_N));
         n310ClienteValorAPagar_F = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientevalorapagar_f_N));
         n311ClienteValorAReceber_F = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientevalorareceber_f_N));
         n537ClienteDepositoTipo = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientedepositotipo_N));
         n538ClientePixTipo = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientepixtipo_N));
         n539ClientePix = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientepix_N));
         n402BancoId = (bool)(Convert.ToBoolean(obj28.gxTpr_Bancoid_N));
         n404BancoCodigo = (bool)(Convert.ToBoolean(obj28.gxTpr_Bancocodigo_N));
         n403BancoNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Banconome_N));
         n400ContaAgencia = (bool)(Convert.ToBoolean(obj28.gxTpr_Contaagencia_N));
         n401ContaNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Contanumero_N));
         n436ResponsavelNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelnome_N));
         n437ResponsavelNacionalidade = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelnacionalidade_N));
         n438ResponsavelNacionalidadeNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelnacionalidadenome_N));
         n439ResponsavelEstadoCivil = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelestadocivil_N));
         n442ResponsavelProfissao = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelprofissao_N));
         n576ResponsavelRG = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelrg_N));
         n443ResponsavelProfissaoNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelprofissaonome_N));
         n447ResponsavelCPF = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelcpf_N));
         n448ResponsavelCEP = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelcep_N));
         n449ResponsavelLogradouro = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavellogradouro_N));
         n450ResponsavelBairro = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelbairro_N));
         n451ResponsavelCidade = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelcidade_N));
         n444ResponsavelMunicipio = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelmunicipio_N));
         n446ResponsavelMunicipioUF = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelmunicipiouf_N));
         n445ResponsavelMunicipioNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelmunicipionome_N));
         n452ResponsavelLogradouroNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavellogradouronumero_N));
         n453ResponsavelComplemento = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelcomplemento_N));
         n454ResponsavelDDD = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelddd_N));
         n455ResponsavelNumero = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelnumero_N));
         n456ResponsavelEmail = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelemail_N));
         n884ClienteSituacao = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientesituacao_N));
         n885ResponsavelCargo = (bool)(Convert.ToBoolean(obj28.gxTpr_Responsavelcargo_N));
         n793TipoClientePortalPjPf = (bool)(Convert.ToBoolean(obj28.gxTpr_Tipoclienteportalpjpf_N));
         n1031RelacionamentoSacado = (bool)(Convert.ToBoolean(obj28.gxTpr_Relacionamentosacado_N));
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A168ClienteId = (int)getParm(obj,0);
         n168ClienteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0O28( ) ;
         ScanKeyStart0O28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z168ClienteId = A168ClienteId;
         }
         ZM0O28( -34) ;
         OnLoadActions0O28( ) ;
         AddRow0O28( ) ;
         ScanKeyEnd0O28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcCliente, 0) ;
         ScanKeyStart0O28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z168ClienteId = A168ClienteId;
         }
         ZM0O28( -34) ;
         OnLoadActions0O28( ) ;
         AddRow0O28( ) ;
         ScanKeyEnd0O28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0O28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0O28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  A168ClienteId = Z168ClienteId;
                  n168ClienteId = false;
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
                  Update0O28( ) ;
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
                  if ( A168ClienteId != Z168ClienteId )
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
                        Insert0O28( ) ;
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
                        Insert0O28( ) ;
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
         RowToVars28( bcCliente, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcCliente) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcCliente) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcCliente) ;
         }
         else
         {
            SdtCliente auxBC = new SdtCliente(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A168ClienteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCliente);
               auxBC.Save();
               bcCliente.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcCliente, 1) ;
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
         RowToVars28( bcCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O28( ) ;
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
               VarsToRow28( bcCliente) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcCliente) ;
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
         RowToVars28( bcCliente, 0) ;
         GetKey0O28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A168ClienteId != Z168ClienteId )
            {
               A168ClienteId = Z168ClienteId;
               n168ClienteId = false;
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
            if ( A168ClienteId != Z168ClienteId )
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
         context.RollbackDataStores("cliente_bc",pr_default);
         VarsToRow28( bcCliente) ;
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
         Gx_mode = bcCliente.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCliente.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCliente )
         {
            bcCliente = (SdtCliente)(sdt);
            if ( StringUtil.StrCmp(bcCliente.gxTpr_Mode, "") == 0 )
            {
               bcCliente.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcCliente) ;
            }
            else
            {
               RowToVars28( bcCliente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCliente.gxTpr_Mode, "") == 0 )
            {
               bcCliente.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcCliente, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCliente Cliente_BC
      {
         get {
            return bcCliente ;
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
         pr_default.close(33);
         pr_default.close(37);
         pr_default.close(41);
         pr_default.close(38);
         pr_default.close(39);
         pr_default.close(35);
         pr_default.close(40);
         pr_default.close(36);
         pr_default.close(34);
         pr_default.close(31);
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(28);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(32);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV35Pgmname = "";
         AV16TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Insert_MunicipioCodigo = "";
         AV28Insert_ResponsavelMunicipio = "";
         Z175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         Z169ClienteDocumento = "";
         A169ClienteDocumento = "";
         Z170ClienteRazaoSocial = "";
         A170ClienteRazaoSocial = "";
         Z171ClienteNomeFantasia = "";
         A171ClienteNomeFantasia = "";
         Z459ClienteDataNascimento = DateTime.MinValue;
         A459ClienteDataNascimento = DateTime.MinValue;
         Z172ClienteTipoPessoa = "";
         A172ClienteTipoPessoa = "";
         Z486ClienteEstadoCivil = "";
         A486ClienteEstadoCivil = "";
         Z181EnderecoTipo = "";
         A181EnderecoTipo = "";
         Z182EnderecoCEP = "";
         A182EnderecoCEP = "";
         Z183EnderecoLogradouro = "";
         A183EnderecoLogradouro = "";
         Z184EnderecoBairro = "";
         A184EnderecoBairro = "";
         Z185EnderecoCidade = "";
         A185EnderecoCidade = "";
         Z190EnderecoNumero = "";
         A190EnderecoNumero = "";
         Z191EnderecoComplemento = "";
         A191EnderecoComplemento = "";
         Z201ContatoEmail = "";
         A201ContatoEmail = "";
         Z537ClienteDepositoTipo = "";
         A537ClienteDepositoTipo = "";
         Z538ClientePixTipo = "";
         A538ClientePixTipo = "";
         Z539ClientePix = "";
         A539ClientePix = "";
         Z400ContaAgencia = "";
         A400ContaAgencia = "";
         Z401ContaNumero = "";
         A401ContaNumero = "";
         Z436ResponsavelNome = "";
         A436ResponsavelNome = "";
         Z439ResponsavelEstadoCivil = "";
         A439ResponsavelEstadoCivil = "";
         Z447ResponsavelCPF = "";
         A447ResponsavelCPF = "";
         Z448ResponsavelCEP = "";
         A448ResponsavelCEP = "";
         Z449ResponsavelLogradouro = "";
         A449ResponsavelLogradouro = "";
         Z450ResponsavelBairro = "";
         A450ResponsavelBairro = "";
         Z451ResponsavelCidade = "";
         A451ResponsavelCidade = "";
         Z453ResponsavelComplemento = "";
         A453ResponsavelComplemento = "";
         Z456ResponsavelEmail = "";
         A456ResponsavelEmail = "";
         Z884ClienteSituacao = "";
         A884ClienteSituacao = "";
         Z885ResponsavelCargo = "";
         A885ResponsavelCargo = "";
         Z1039ClienteTipoRisco = "";
         A1039ClienteTipoRisco = "";
         Z186MunicipioCodigo = "";
         A186MunicipioCodigo = "";
         Z444ResponsavelMunicipio = "";
         A444ResponsavelMunicipio = "";
         Z205ClienteTelefone_F = "";
         A205ClienteTelefone_F = "";
         Z206ClienteCelular_F = "";
         A206ClienteCelular_F = "";
         Z577ResponsavelCelular_F = "";
         A577ResponsavelCelular_F = "";
         Z780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         Z193TipoClienteDescricao = "";
         A193TipoClienteDescricao = "";
         Z187MunicipioNome = "";
         A187MunicipioNome = "";
         Z189MunicipioUF = "";
         A189MunicipioUF = "";
         Z446ResponsavelMunicipioUF = "";
         A446ResponsavelMunicipioUF = "";
         Z445ResponsavelMunicipioNome = "";
         A445ResponsavelMunicipioNome = "";
         Z403BancoNome = "";
         A403BancoNome = "";
         Z438ResponsavelNacionalidadeNome = "";
         A438ResponsavelNacionalidadeNome = "";
         Z485ClienteNacionalidadeNome = "";
         A485ClienteNacionalidadeNome = "";
         Z443ResponsavelProfissaoNome = "";
         A443ResponsavelProfissaoNome = "";
         Z488ClienteProfissaoNome = "";
         A488ClienteProfissaoNome = "";
         Z490ClienteConvenioDescricao = "";
         A490ClienteConvenioDescricao = "";
         BC000O40_A168ClienteId = new int[1] ;
         BC000O40_n168ClienteId = new bool[] {false} ;
         BC000O40_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O40_n175ClienteCreatedAt = new bool[] {false} ;
         BC000O40_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O40_n176ClienteUpdatedAt = new bool[] {false} ;
         BC000O40_A169ClienteDocumento = new string[] {""} ;
         BC000O40_n169ClienteDocumento = new bool[] {false} ;
         BC000O40_A170ClienteRazaoSocial = new string[] {""} ;
         BC000O40_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000O40_A171ClienteNomeFantasia = new string[] {""} ;
         BC000O40_n171ClienteNomeFantasia = new bool[] {false} ;
         BC000O40_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC000O40_n459ClienteDataNascimento = new bool[] {false} ;
         BC000O40_A172ClienteTipoPessoa = new string[] {""} ;
         BC000O40_n172ClienteTipoPessoa = new bool[] {false} ;
         BC000O40_A193TipoClienteDescricao = new string[] {""} ;
         BC000O40_n193TipoClienteDescricao = new bool[] {false} ;
         BC000O40_A207TipoClientePortal = new bool[] {false} ;
         BC000O40_n207TipoClientePortal = new bool[] {false} ;
         BC000O40_A174ClienteStatus = new bool[] {false} ;
         BC000O40_n174ClienteStatus = new bool[] {false} ;
         BC000O40_A490ClienteConvenioDescricao = new string[] {""} ;
         BC000O40_n490ClienteConvenioDescricao = new bool[] {false} ;
         BC000O40_A177ClienteLogUser = new short[1] ;
         BC000O40_n177ClienteLogUser = new bool[] {false} ;
         BC000O40_A485ClienteNacionalidadeNome = new string[] {""} ;
         BC000O40_n485ClienteNacionalidadeNome = new bool[] {false} ;
         BC000O40_A488ClienteProfissaoNome = new string[] {""} ;
         BC000O40_n488ClienteProfissaoNome = new bool[] {false} ;
         BC000O40_A486ClienteEstadoCivil = new string[] {""} ;
         BC000O40_n486ClienteEstadoCivil = new bool[] {false} ;
         BC000O40_A181EnderecoTipo = new string[] {""} ;
         BC000O40_n181EnderecoTipo = new bool[] {false} ;
         BC000O40_A182EnderecoCEP = new string[] {""} ;
         BC000O40_n182EnderecoCEP = new bool[] {false} ;
         BC000O40_A183EnderecoLogradouro = new string[] {""} ;
         BC000O40_n183EnderecoLogradouro = new bool[] {false} ;
         BC000O40_A184EnderecoBairro = new string[] {""} ;
         BC000O40_n184EnderecoBairro = new bool[] {false} ;
         BC000O40_A185EnderecoCidade = new string[] {""} ;
         BC000O40_n185EnderecoCidade = new bool[] {false} ;
         BC000O40_A187MunicipioNome = new string[] {""} ;
         BC000O40_n187MunicipioNome = new bool[] {false} ;
         BC000O40_A189MunicipioUF = new string[] {""} ;
         BC000O40_n189MunicipioUF = new bool[] {false} ;
         BC000O40_A190EnderecoNumero = new string[] {""} ;
         BC000O40_n190EnderecoNumero = new bool[] {false} ;
         BC000O40_A191EnderecoComplemento = new string[] {""} ;
         BC000O40_n191EnderecoComplemento = new bool[] {false} ;
         BC000O40_A201ContatoEmail = new string[] {""} ;
         BC000O40_n201ContatoEmail = new bool[] {false} ;
         BC000O40_A198ContatoDDD = new short[1] ;
         BC000O40_n198ContatoDDD = new bool[] {false} ;
         BC000O40_A199ContatoDDI = new short[1] ;
         BC000O40_n199ContatoDDI = new bool[] {false} ;
         BC000O40_A200ContatoNumero = new long[1] ;
         BC000O40_n200ContatoNumero = new bool[] {false} ;
         BC000O40_A202ContatoTelefoneNumero = new long[1] ;
         BC000O40_n202ContatoTelefoneNumero = new bool[] {false} ;
         BC000O40_A203ContatoTelefoneDDD = new short[1] ;
         BC000O40_n203ContatoTelefoneDDD = new bool[] {false} ;
         BC000O40_A204ContatoTelefoneDDI = new short[1] ;
         BC000O40_n204ContatoTelefoneDDI = new bool[] {false} ;
         BC000O40_A421ClienteRG = new long[1] ;
         BC000O40_n421ClienteRG = new bool[] {false} ;
         BC000O40_A537ClienteDepositoTipo = new string[] {""} ;
         BC000O40_n537ClienteDepositoTipo = new bool[] {false} ;
         BC000O40_A538ClientePixTipo = new string[] {""} ;
         BC000O40_n538ClientePixTipo = new bool[] {false} ;
         BC000O40_A539ClientePix = new string[] {""} ;
         BC000O40_n539ClientePix = new bool[] {false} ;
         BC000O40_A404BancoCodigo = new int[1] ;
         BC000O40_n404BancoCodigo = new bool[] {false} ;
         BC000O40_A403BancoNome = new string[] {""} ;
         BC000O40_n403BancoNome = new bool[] {false} ;
         BC000O40_A400ContaAgencia = new string[] {""} ;
         BC000O40_n400ContaAgencia = new bool[] {false} ;
         BC000O40_A401ContaNumero = new string[] {""} ;
         BC000O40_n401ContaNumero = new bool[] {false} ;
         BC000O40_A436ResponsavelNome = new string[] {""} ;
         BC000O40_n436ResponsavelNome = new bool[] {false} ;
         BC000O40_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         BC000O40_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         BC000O40_A439ResponsavelEstadoCivil = new string[] {""} ;
         BC000O40_n439ResponsavelEstadoCivil = new bool[] {false} ;
         BC000O40_A576ResponsavelRG = new long[1] ;
         BC000O40_n576ResponsavelRG = new bool[] {false} ;
         BC000O40_A443ResponsavelProfissaoNome = new string[] {""} ;
         BC000O40_n443ResponsavelProfissaoNome = new bool[] {false} ;
         BC000O40_A447ResponsavelCPF = new string[] {""} ;
         BC000O40_n447ResponsavelCPF = new bool[] {false} ;
         BC000O40_A448ResponsavelCEP = new string[] {""} ;
         BC000O40_n448ResponsavelCEP = new bool[] {false} ;
         BC000O40_A449ResponsavelLogradouro = new string[] {""} ;
         BC000O40_n449ResponsavelLogradouro = new bool[] {false} ;
         BC000O40_A450ResponsavelBairro = new string[] {""} ;
         BC000O40_n450ResponsavelBairro = new bool[] {false} ;
         BC000O40_A451ResponsavelCidade = new string[] {""} ;
         BC000O40_n451ResponsavelCidade = new bool[] {false} ;
         BC000O40_A446ResponsavelMunicipioUF = new string[] {""} ;
         BC000O40_n446ResponsavelMunicipioUF = new bool[] {false} ;
         BC000O40_A445ResponsavelMunicipioNome = new string[] {""} ;
         BC000O40_n445ResponsavelMunicipioNome = new bool[] {false} ;
         BC000O40_A452ResponsavelLogradouroNumero = new int[1] ;
         BC000O40_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         BC000O40_A453ResponsavelComplemento = new string[] {""} ;
         BC000O40_n453ResponsavelComplemento = new bool[] {false} ;
         BC000O40_A454ResponsavelDDD = new short[1] ;
         BC000O40_n454ResponsavelDDD = new bool[] {false} ;
         BC000O40_A455ResponsavelNumero = new int[1] ;
         BC000O40_n455ResponsavelNumero = new bool[] {false} ;
         BC000O40_A456ResponsavelEmail = new string[] {""} ;
         BC000O40_n456ResponsavelEmail = new bool[] {false} ;
         BC000O40_A884ClienteSituacao = new string[] {""} ;
         BC000O40_n884ClienteSituacao = new bool[] {false} ;
         BC000O40_A885ResponsavelCargo = new string[] {""} ;
         BC000O40_n885ResponsavelCargo = new bool[] {false} ;
         BC000O40_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O40_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O40_A1039ClienteTipoRisco = new string[] {""} ;
         BC000O40_A192TipoClienteId = new short[1] ;
         BC000O40_n192TipoClienteId = new bool[] {false} ;
         BC000O40_A186MunicipioCodigo = new string[] {""} ;
         BC000O40_n186MunicipioCodigo = new bool[] {false} ;
         BC000O40_A444ResponsavelMunicipio = new string[] {""} ;
         BC000O40_n444ResponsavelMunicipio = new bool[] {false} ;
         BC000O40_A402BancoId = new int[1] ;
         BC000O40_n402BancoId = new bool[] {false} ;
         BC000O40_A457EspecialidadeId = new int[1] ;
         BC000O40_n457EspecialidadeId = new bool[] {false} ;
         BC000O40_A437ResponsavelNacionalidade = new int[1] ;
         BC000O40_n437ResponsavelNacionalidade = new bool[] {false} ;
         BC000O40_A484ClienteNacionalidade = new int[1] ;
         BC000O40_n484ClienteNacionalidade = new bool[] {false} ;
         BC000O40_A442ResponsavelProfissao = new int[1] ;
         BC000O40_n442ResponsavelProfissao = new bool[] {false} ;
         BC000O40_A487ClienteProfissao = new int[1] ;
         BC000O40_n487ClienteProfissao = new bool[] {false} ;
         BC000O40_A489ClienteConvenio = new int[1] ;
         BC000O40_n489ClienteConvenio = new bool[] {false} ;
         BC000O40_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         BC000O40_A608SecUserId_F = new short[1] ;
         BC000O40_n608SecUserId_F = new bool[] {false} ;
         BC000O40_A309ClienteQtdTitulos_F = new int[1] ;
         BC000O40_n309ClienteQtdTitulos_F = new bool[] {false} ;
         BC000O40_A310ClienteValorAPagar_F = new decimal[1] ;
         BC000O40_n310ClienteValorAPagar_F = new bool[] {false} ;
         BC000O40_A311ClienteValorAReceber_F = new decimal[1] ;
         BC000O40_n311ClienteValorAReceber_F = new bool[] {false} ;
         BC000O40_A732SerasaConsultas_F = new short[1] ;
         BC000O40_A1031RelacionamentoSacado = new short[1] ;
         BC000O40_n1031RelacionamentoSacado = new bool[] {false} ;
         BC000O15_A781SerasaScoreUltimaData_F = new short[1] ;
         BC000O15_A785SerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC000O17_A608SecUserId_F = new short[1] ;
         BC000O17_n608SecUserId_F = new bool[] {false} ;
         BC000O19_A309ClienteQtdTitulos_F = new int[1] ;
         BC000O19_n309ClienteQtdTitulos_F = new bool[] {false} ;
         BC000O23_A310ClienteValorAPagar_F = new decimal[1] ;
         BC000O23_n310ClienteValorAPagar_F = new bool[] {false} ;
         BC000O26_A311ClienteValorAReceber_F = new decimal[1] ;
         BC000O26_n311ClienteValorAReceber_F = new bool[] {false} ;
         BC000O28_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         BC000O28_A732SerasaConsultas_F = new short[1] ;
         BC000O30_A1031RelacionamentoSacado = new short[1] ;
         BC000O30_n1031RelacionamentoSacado = new bool[] {false} ;
         BC000O41_A169ClienteDocumento = new string[] {""} ;
         BC000O41_n169ClienteDocumento = new bool[] {false} ;
         BC000O8_A457EspecialidadeId = new int[1] ;
         BC000O8_n457EspecialidadeId = new bool[] {false} ;
         BC000O4_A193TipoClienteDescricao = new string[] {""} ;
         BC000O4_n193TipoClienteDescricao = new bool[] {false} ;
         BC000O4_A207TipoClientePortal = new bool[] {false} ;
         BC000O4_n207TipoClientePortal = new bool[] {false} ;
         BC000O4_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O4_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O13_A490ClienteConvenioDescricao = new string[] {""} ;
         BC000O13_n490ClienteConvenioDescricao = new bool[] {false} ;
         BC000O10_A485ClienteNacionalidadeNome = new string[] {""} ;
         BC000O10_n485ClienteNacionalidadeNome = new bool[] {false} ;
         BC000O12_A488ClienteProfissaoNome = new string[] {""} ;
         BC000O12_n488ClienteProfissaoNome = new bool[] {false} ;
         BC000O5_A187MunicipioNome = new string[] {""} ;
         BC000O5_n187MunicipioNome = new bool[] {false} ;
         BC000O5_A189MunicipioUF = new string[] {""} ;
         BC000O5_n189MunicipioUF = new bool[] {false} ;
         BC000O7_A404BancoCodigo = new int[1] ;
         BC000O7_n404BancoCodigo = new bool[] {false} ;
         BC000O7_A403BancoNome = new string[] {""} ;
         BC000O7_n403BancoNome = new bool[] {false} ;
         BC000O9_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         BC000O9_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         BC000O11_A443ResponsavelProfissaoNome = new string[] {""} ;
         BC000O11_n443ResponsavelProfissaoNome = new bool[] {false} ;
         BC000O6_A446ResponsavelMunicipioUF = new string[] {""} ;
         BC000O6_n446ResponsavelMunicipioUF = new bool[] {false} ;
         BC000O6_A445ResponsavelMunicipioNome = new string[] {""} ;
         BC000O6_n445ResponsavelMunicipioNome = new bool[] {false} ;
         BC000O42_A168ClienteId = new int[1] ;
         BC000O42_n168ClienteId = new bool[] {false} ;
         BC000O3_A168ClienteId = new int[1] ;
         BC000O3_n168ClienteId = new bool[] {false} ;
         BC000O3_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O3_n175ClienteCreatedAt = new bool[] {false} ;
         BC000O3_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O3_n176ClienteUpdatedAt = new bool[] {false} ;
         BC000O3_A169ClienteDocumento = new string[] {""} ;
         BC000O3_n169ClienteDocumento = new bool[] {false} ;
         BC000O3_A170ClienteRazaoSocial = new string[] {""} ;
         BC000O3_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000O3_A171ClienteNomeFantasia = new string[] {""} ;
         BC000O3_n171ClienteNomeFantasia = new bool[] {false} ;
         BC000O3_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC000O3_n459ClienteDataNascimento = new bool[] {false} ;
         BC000O3_A172ClienteTipoPessoa = new string[] {""} ;
         BC000O3_n172ClienteTipoPessoa = new bool[] {false} ;
         BC000O3_A174ClienteStatus = new bool[] {false} ;
         BC000O3_n174ClienteStatus = new bool[] {false} ;
         BC000O3_A177ClienteLogUser = new short[1] ;
         BC000O3_n177ClienteLogUser = new bool[] {false} ;
         BC000O3_A486ClienteEstadoCivil = new string[] {""} ;
         BC000O3_n486ClienteEstadoCivil = new bool[] {false} ;
         BC000O3_A181EnderecoTipo = new string[] {""} ;
         BC000O3_n181EnderecoTipo = new bool[] {false} ;
         BC000O3_A182EnderecoCEP = new string[] {""} ;
         BC000O3_n182EnderecoCEP = new bool[] {false} ;
         BC000O3_A183EnderecoLogradouro = new string[] {""} ;
         BC000O3_n183EnderecoLogradouro = new bool[] {false} ;
         BC000O3_A184EnderecoBairro = new string[] {""} ;
         BC000O3_n184EnderecoBairro = new bool[] {false} ;
         BC000O3_A185EnderecoCidade = new string[] {""} ;
         BC000O3_n185EnderecoCidade = new bool[] {false} ;
         BC000O3_A190EnderecoNumero = new string[] {""} ;
         BC000O3_n190EnderecoNumero = new bool[] {false} ;
         BC000O3_A191EnderecoComplemento = new string[] {""} ;
         BC000O3_n191EnderecoComplemento = new bool[] {false} ;
         BC000O3_A201ContatoEmail = new string[] {""} ;
         BC000O3_n201ContatoEmail = new bool[] {false} ;
         BC000O3_A198ContatoDDD = new short[1] ;
         BC000O3_n198ContatoDDD = new bool[] {false} ;
         BC000O3_A199ContatoDDI = new short[1] ;
         BC000O3_n199ContatoDDI = new bool[] {false} ;
         BC000O3_A200ContatoNumero = new long[1] ;
         BC000O3_n200ContatoNumero = new bool[] {false} ;
         BC000O3_A202ContatoTelefoneNumero = new long[1] ;
         BC000O3_n202ContatoTelefoneNumero = new bool[] {false} ;
         BC000O3_A203ContatoTelefoneDDD = new short[1] ;
         BC000O3_n203ContatoTelefoneDDD = new bool[] {false} ;
         BC000O3_A204ContatoTelefoneDDI = new short[1] ;
         BC000O3_n204ContatoTelefoneDDI = new bool[] {false} ;
         BC000O3_A421ClienteRG = new long[1] ;
         BC000O3_n421ClienteRG = new bool[] {false} ;
         BC000O3_A537ClienteDepositoTipo = new string[] {""} ;
         BC000O3_n537ClienteDepositoTipo = new bool[] {false} ;
         BC000O3_A538ClientePixTipo = new string[] {""} ;
         BC000O3_n538ClientePixTipo = new bool[] {false} ;
         BC000O3_A539ClientePix = new string[] {""} ;
         BC000O3_n539ClientePix = new bool[] {false} ;
         BC000O3_A400ContaAgencia = new string[] {""} ;
         BC000O3_n400ContaAgencia = new bool[] {false} ;
         BC000O3_A401ContaNumero = new string[] {""} ;
         BC000O3_n401ContaNumero = new bool[] {false} ;
         BC000O3_A436ResponsavelNome = new string[] {""} ;
         BC000O3_n436ResponsavelNome = new bool[] {false} ;
         BC000O3_A439ResponsavelEstadoCivil = new string[] {""} ;
         BC000O3_n439ResponsavelEstadoCivil = new bool[] {false} ;
         BC000O3_A576ResponsavelRG = new long[1] ;
         BC000O3_n576ResponsavelRG = new bool[] {false} ;
         BC000O3_A447ResponsavelCPF = new string[] {""} ;
         BC000O3_n447ResponsavelCPF = new bool[] {false} ;
         BC000O3_A448ResponsavelCEP = new string[] {""} ;
         BC000O3_n448ResponsavelCEP = new bool[] {false} ;
         BC000O3_A449ResponsavelLogradouro = new string[] {""} ;
         BC000O3_n449ResponsavelLogradouro = new bool[] {false} ;
         BC000O3_A450ResponsavelBairro = new string[] {""} ;
         BC000O3_n450ResponsavelBairro = new bool[] {false} ;
         BC000O3_A451ResponsavelCidade = new string[] {""} ;
         BC000O3_n451ResponsavelCidade = new bool[] {false} ;
         BC000O3_A452ResponsavelLogradouroNumero = new int[1] ;
         BC000O3_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         BC000O3_A453ResponsavelComplemento = new string[] {""} ;
         BC000O3_n453ResponsavelComplemento = new bool[] {false} ;
         BC000O3_A454ResponsavelDDD = new short[1] ;
         BC000O3_n454ResponsavelDDD = new bool[] {false} ;
         BC000O3_A455ResponsavelNumero = new int[1] ;
         BC000O3_n455ResponsavelNumero = new bool[] {false} ;
         BC000O3_A456ResponsavelEmail = new string[] {""} ;
         BC000O3_n456ResponsavelEmail = new bool[] {false} ;
         BC000O3_A884ClienteSituacao = new string[] {""} ;
         BC000O3_n884ClienteSituacao = new bool[] {false} ;
         BC000O3_A885ResponsavelCargo = new string[] {""} ;
         BC000O3_n885ResponsavelCargo = new bool[] {false} ;
         BC000O3_A1039ClienteTipoRisco = new string[] {""} ;
         BC000O3_A192TipoClienteId = new short[1] ;
         BC000O3_n192TipoClienteId = new bool[] {false} ;
         BC000O3_A186MunicipioCodigo = new string[] {""} ;
         BC000O3_n186MunicipioCodigo = new bool[] {false} ;
         BC000O3_A444ResponsavelMunicipio = new string[] {""} ;
         BC000O3_n444ResponsavelMunicipio = new bool[] {false} ;
         BC000O3_A402BancoId = new int[1] ;
         BC000O3_n402BancoId = new bool[] {false} ;
         BC000O3_A457EspecialidadeId = new int[1] ;
         BC000O3_n457EspecialidadeId = new bool[] {false} ;
         BC000O3_A437ResponsavelNacionalidade = new int[1] ;
         BC000O3_n437ResponsavelNacionalidade = new bool[] {false} ;
         BC000O3_A484ClienteNacionalidade = new int[1] ;
         BC000O3_n484ClienteNacionalidade = new bool[] {false} ;
         BC000O3_A442ResponsavelProfissao = new int[1] ;
         BC000O3_n442ResponsavelProfissao = new bool[] {false} ;
         BC000O3_A487ClienteProfissao = new int[1] ;
         BC000O3_n487ClienteProfissao = new bool[] {false} ;
         BC000O3_A489ClienteConvenio = new int[1] ;
         BC000O3_n489ClienteConvenio = new bool[] {false} ;
         sMode28 = "";
         BC000O2_A168ClienteId = new int[1] ;
         BC000O2_n168ClienteId = new bool[] {false} ;
         BC000O2_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O2_n175ClienteCreatedAt = new bool[] {false} ;
         BC000O2_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O2_n176ClienteUpdatedAt = new bool[] {false} ;
         BC000O2_A169ClienteDocumento = new string[] {""} ;
         BC000O2_n169ClienteDocumento = new bool[] {false} ;
         BC000O2_A170ClienteRazaoSocial = new string[] {""} ;
         BC000O2_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000O2_A171ClienteNomeFantasia = new string[] {""} ;
         BC000O2_n171ClienteNomeFantasia = new bool[] {false} ;
         BC000O2_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC000O2_n459ClienteDataNascimento = new bool[] {false} ;
         BC000O2_A172ClienteTipoPessoa = new string[] {""} ;
         BC000O2_n172ClienteTipoPessoa = new bool[] {false} ;
         BC000O2_A174ClienteStatus = new bool[] {false} ;
         BC000O2_n174ClienteStatus = new bool[] {false} ;
         BC000O2_A177ClienteLogUser = new short[1] ;
         BC000O2_n177ClienteLogUser = new bool[] {false} ;
         BC000O2_A486ClienteEstadoCivil = new string[] {""} ;
         BC000O2_n486ClienteEstadoCivil = new bool[] {false} ;
         BC000O2_A181EnderecoTipo = new string[] {""} ;
         BC000O2_n181EnderecoTipo = new bool[] {false} ;
         BC000O2_A182EnderecoCEP = new string[] {""} ;
         BC000O2_n182EnderecoCEP = new bool[] {false} ;
         BC000O2_A183EnderecoLogradouro = new string[] {""} ;
         BC000O2_n183EnderecoLogradouro = new bool[] {false} ;
         BC000O2_A184EnderecoBairro = new string[] {""} ;
         BC000O2_n184EnderecoBairro = new bool[] {false} ;
         BC000O2_A185EnderecoCidade = new string[] {""} ;
         BC000O2_n185EnderecoCidade = new bool[] {false} ;
         BC000O2_A190EnderecoNumero = new string[] {""} ;
         BC000O2_n190EnderecoNumero = new bool[] {false} ;
         BC000O2_A191EnderecoComplemento = new string[] {""} ;
         BC000O2_n191EnderecoComplemento = new bool[] {false} ;
         BC000O2_A201ContatoEmail = new string[] {""} ;
         BC000O2_n201ContatoEmail = new bool[] {false} ;
         BC000O2_A198ContatoDDD = new short[1] ;
         BC000O2_n198ContatoDDD = new bool[] {false} ;
         BC000O2_A199ContatoDDI = new short[1] ;
         BC000O2_n199ContatoDDI = new bool[] {false} ;
         BC000O2_A200ContatoNumero = new long[1] ;
         BC000O2_n200ContatoNumero = new bool[] {false} ;
         BC000O2_A202ContatoTelefoneNumero = new long[1] ;
         BC000O2_n202ContatoTelefoneNumero = new bool[] {false} ;
         BC000O2_A203ContatoTelefoneDDD = new short[1] ;
         BC000O2_n203ContatoTelefoneDDD = new bool[] {false} ;
         BC000O2_A204ContatoTelefoneDDI = new short[1] ;
         BC000O2_n204ContatoTelefoneDDI = new bool[] {false} ;
         BC000O2_A421ClienteRG = new long[1] ;
         BC000O2_n421ClienteRG = new bool[] {false} ;
         BC000O2_A537ClienteDepositoTipo = new string[] {""} ;
         BC000O2_n537ClienteDepositoTipo = new bool[] {false} ;
         BC000O2_A538ClientePixTipo = new string[] {""} ;
         BC000O2_n538ClientePixTipo = new bool[] {false} ;
         BC000O2_A539ClientePix = new string[] {""} ;
         BC000O2_n539ClientePix = new bool[] {false} ;
         BC000O2_A400ContaAgencia = new string[] {""} ;
         BC000O2_n400ContaAgencia = new bool[] {false} ;
         BC000O2_A401ContaNumero = new string[] {""} ;
         BC000O2_n401ContaNumero = new bool[] {false} ;
         BC000O2_A436ResponsavelNome = new string[] {""} ;
         BC000O2_n436ResponsavelNome = new bool[] {false} ;
         BC000O2_A439ResponsavelEstadoCivil = new string[] {""} ;
         BC000O2_n439ResponsavelEstadoCivil = new bool[] {false} ;
         BC000O2_A576ResponsavelRG = new long[1] ;
         BC000O2_n576ResponsavelRG = new bool[] {false} ;
         BC000O2_A447ResponsavelCPF = new string[] {""} ;
         BC000O2_n447ResponsavelCPF = new bool[] {false} ;
         BC000O2_A448ResponsavelCEP = new string[] {""} ;
         BC000O2_n448ResponsavelCEP = new bool[] {false} ;
         BC000O2_A449ResponsavelLogradouro = new string[] {""} ;
         BC000O2_n449ResponsavelLogradouro = new bool[] {false} ;
         BC000O2_A450ResponsavelBairro = new string[] {""} ;
         BC000O2_n450ResponsavelBairro = new bool[] {false} ;
         BC000O2_A451ResponsavelCidade = new string[] {""} ;
         BC000O2_n451ResponsavelCidade = new bool[] {false} ;
         BC000O2_A452ResponsavelLogradouroNumero = new int[1] ;
         BC000O2_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         BC000O2_A453ResponsavelComplemento = new string[] {""} ;
         BC000O2_n453ResponsavelComplemento = new bool[] {false} ;
         BC000O2_A454ResponsavelDDD = new short[1] ;
         BC000O2_n454ResponsavelDDD = new bool[] {false} ;
         BC000O2_A455ResponsavelNumero = new int[1] ;
         BC000O2_n455ResponsavelNumero = new bool[] {false} ;
         BC000O2_A456ResponsavelEmail = new string[] {""} ;
         BC000O2_n456ResponsavelEmail = new bool[] {false} ;
         BC000O2_A884ClienteSituacao = new string[] {""} ;
         BC000O2_n884ClienteSituacao = new bool[] {false} ;
         BC000O2_A885ResponsavelCargo = new string[] {""} ;
         BC000O2_n885ResponsavelCargo = new bool[] {false} ;
         BC000O2_A1039ClienteTipoRisco = new string[] {""} ;
         BC000O2_A192TipoClienteId = new short[1] ;
         BC000O2_n192TipoClienteId = new bool[] {false} ;
         BC000O2_A186MunicipioCodigo = new string[] {""} ;
         BC000O2_n186MunicipioCodigo = new bool[] {false} ;
         BC000O2_A444ResponsavelMunicipio = new string[] {""} ;
         BC000O2_n444ResponsavelMunicipio = new bool[] {false} ;
         BC000O2_A402BancoId = new int[1] ;
         BC000O2_n402BancoId = new bool[] {false} ;
         BC000O2_A457EspecialidadeId = new int[1] ;
         BC000O2_n457EspecialidadeId = new bool[] {false} ;
         BC000O2_A437ResponsavelNacionalidade = new int[1] ;
         BC000O2_n437ResponsavelNacionalidade = new bool[] {false} ;
         BC000O2_A484ClienteNacionalidade = new int[1] ;
         BC000O2_n484ClienteNacionalidade = new bool[] {false} ;
         BC000O2_A442ResponsavelProfissao = new int[1] ;
         BC000O2_n442ResponsavelProfissao = new bool[] {false} ;
         BC000O2_A487ClienteProfissao = new int[1] ;
         BC000O2_n487ClienteProfissao = new bool[] {false} ;
         BC000O2_A489ClienteConvenio = new int[1] ;
         BC000O2_n489ClienteConvenio = new bool[] {false} ;
         BC000O44_A168ClienteId = new int[1] ;
         BC000O44_n168ClienteId = new bool[] {false} ;
         BC000O48_A608SecUserId_F = new short[1] ;
         BC000O48_n608SecUserId_F = new bool[] {false} ;
         BC000O50_A309ClienteQtdTitulos_F = new int[1] ;
         BC000O50_n309ClienteQtdTitulos_F = new bool[] {false} ;
         BC000O54_A310ClienteValorAPagar_F = new decimal[1] ;
         BC000O54_n310ClienteValorAPagar_F = new bool[] {false} ;
         BC000O57_A311ClienteValorAReceber_F = new decimal[1] ;
         BC000O57_n311ClienteValorAReceber_F = new bool[] {false} ;
         BC000O59_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         BC000O59_A732SerasaConsultas_F = new short[1] ;
         BC000O61_A781SerasaScoreUltimaData_F = new short[1] ;
         BC000O61_A785SerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC000O63_A1031RelacionamentoSacado = new short[1] ;
         BC000O63_n1031RelacionamentoSacado = new bool[] {false} ;
         BC000O64_A193TipoClienteDescricao = new string[] {""} ;
         BC000O64_n193TipoClienteDescricao = new bool[] {false} ;
         BC000O64_A207TipoClientePortal = new bool[] {false} ;
         BC000O64_n207TipoClientePortal = new bool[] {false} ;
         BC000O64_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O64_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O65_A490ClienteConvenioDescricao = new string[] {""} ;
         BC000O65_n490ClienteConvenioDescricao = new bool[] {false} ;
         BC000O66_A485ClienteNacionalidadeNome = new string[] {""} ;
         BC000O66_n485ClienteNacionalidadeNome = new bool[] {false} ;
         BC000O67_A488ClienteProfissaoNome = new string[] {""} ;
         BC000O67_n488ClienteProfissaoNome = new bool[] {false} ;
         BC000O68_A187MunicipioNome = new string[] {""} ;
         BC000O68_n187MunicipioNome = new bool[] {false} ;
         BC000O68_A189MunicipioUF = new string[] {""} ;
         BC000O68_n189MunicipioUF = new bool[] {false} ;
         BC000O69_A404BancoCodigo = new int[1] ;
         BC000O69_n404BancoCodigo = new bool[] {false} ;
         BC000O69_A403BancoNome = new string[] {""} ;
         BC000O69_n403BancoNome = new bool[] {false} ;
         BC000O70_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         BC000O70_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         BC000O71_A443ResponsavelProfissaoNome = new string[] {""} ;
         BC000O71_n443ResponsavelProfissaoNome = new bool[] {false} ;
         BC000O72_A446ResponsavelMunicipioUF = new string[] {""} ;
         BC000O72_n446ResponsavelMunicipioUF = new bool[] {false} ;
         BC000O72_A445ResponsavelMunicipioNome = new string[] {""} ;
         BC000O72_n445ResponsavelMunicipioNome = new bool[] {false} ;
         GXt_char1 = "";
         BC000O73_A1019OperacoesTitulosId = new int[1] ;
         BC000O74_A323PropostaId = new int[1] ;
         BC000O75_A323PropostaId = new int[1] ;
         BC000O76_A323PropostaId = new int[1] ;
         BC000O77_A323PropostaId = new int[1] ;
         BC000O78_A227ContratoId = new int[1] ;
         BC000O79_A261TituloId = new int[1] ;
         BC000O79_n261TituloId = new bool[] {false} ;
         BC000O80_A133SecUserId = new short[1] ;
         BC000O81_A1032RelacionamentoId = new int[1] ;
         BC000O82_A1010OperacoesId = new int[1] ;
         BC000O83_A978RepresentanteId = new int[1] ;
         BC000O84_A856CreditoId = new int[1] ;
         BC000O85_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC000O85_n794NotaFiscalId = new bool[] {false} ;
         BC000O86_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC000O86_n794NotaFiscalId = new bool[] {false} ;
         BC000O87_A662SerasaId = new int[1] ;
         BC000O88_A599ClienteDocumentoId = new int[1] ;
         BC000O89_A551ClienteReponsavelId = new int[1] ;
         BC000O90_A551ClienteReponsavelId = new int[1] ;
         BC000O91_A242AssinaturaParticipanteId = new int[1] ;
         BC000O92_A223FinanciamentoId = new int[1] ;
         BC000O93_A223FinanciamentoId = new int[1] ;
         BC000O103_A168ClienteId = new int[1] ;
         BC000O103_n168ClienteId = new bool[] {false} ;
         BC000O103_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O103_n175ClienteCreatedAt = new bool[] {false} ;
         BC000O103_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000O103_n176ClienteUpdatedAt = new bool[] {false} ;
         BC000O103_A169ClienteDocumento = new string[] {""} ;
         BC000O103_n169ClienteDocumento = new bool[] {false} ;
         BC000O103_A170ClienteRazaoSocial = new string[] {""} ;
         BC000O103_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000O103_A171ClienteNomeFantasia = new string[] {""} ;
         BC000O103_n171ClienteNomeFantasia = new bool[] {false} ;
         BC000O103_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC000O103_n459ClienteDataNascimento = new bool[] {false} ;
         BC000O103_A172ClienteTipoPessoa = new string[] {""} ;
         BC000O103_n172ClienteTipoPessoa = new bool[] {false} ;
         BC000O103_A193TipoClienteDescricao = new string[] {""} ;
         BC000O103_n193TipoClienteDescricao = new bool[] {false} ;
         BC000O103_A207TipoClientePortal = new bool[] {false} ;
         BC000O103_n207TipoClientePortal = new bool[] {false} ;
         BC000O103_A174ClienteStatus = new bool[] {false} ;
         BC000O103_n174ClienteStatus = new bool[] {false} ;
         BC000O103_A490ClienteConvenioDescricao = new string[] {""} ;
         BC000O103_n490ClienteConvenioDescricao = new bool[] {false} ;
         BC000O103_A177ClienteLogUser = new short[1] ;
         BC000O103_n177ClienteLogUser = new bool[] {false} ;
         BC000O103_A485ClienteNacionalidadeNome = new string[] {""} ;
         BC000O103_n485ClienteNacionalidadeNome = new bool[] {false} ;
         BC000O103_A488ClienteProfissaoNome = new string[] {""} ;
         BC000O103_n488ClienteProfissaoNome = new bool[] {false} ;
         BC000O103_A486ClienteEstadoCivil = new string[] {""} ;
         BC000O103_n486ClienteEstadoCivil = new bool[] {false} ;
         BC000O103_A181EnderecoTipo = new string[] {""} ;
         BC000O103_n181EnderecoTipo = new bool[] {false} ;
         BC000O103_A182EnderecoCEP = new string[] {""} ;
         BC000O103_n182EnderecoCEP = new bool[] {false} ;
         BC000O103_A183EnderecoLogradouro = new string[] {""} ;
         BC000O103_n183EnderecoLogradouro = new bool[] {false} ;
         BC000O103_A184EnderecoBairro = new string[] {""} ;
         BC000O103_n184EnderecoBairro = new bool[] {false} ;
         BC000O103_A185EnderecoCidade = new string[] {""} ;
         BC000O103_n185EnderecoCidade = new bool[] {false} ;
         BC000O103_A187MunicipioNome = new string[] {""} ;
         BC000O103_n187MunicipioNome = new bool[] {false} ;
         BC000O103_A189MunicipioUF = new string[] {""} ;
         BC000O103_n189MunicipioUF = new bool[] {false} ;
         BC000O103_A190EnderecoNumero = new string[] {""} ;
         BC000O103_n190EnderecoNumero = new bool[] {false} ;
         BC000O103_A191EnderecoComplemento = new string[] {""} ;
         BC000O103_n191EnderecoComplemento = new bool[] {false} ;
         BC000O103_A201ContatoEmail = new string[] {""} ;
         BC000O103_n201ContatoEmail = new bool[] {false} ;
         BC000O103_A198ContatoDDD = new short[1] ;
         BC000O103_n198ContatoDDD = new bool[] {false} ;
         BC000O103_A199ContatoDDI = new short[1] ;
         BC000O103_n199ContatoDDI = new bool[] {false} ;
         BC000O103_A200ContatoNumero = new long[1] ;
         BC000O103_n200ContatoNumero = new bool[] {false} ;
         BC000O103_A202ContatoTelefoneNumero = new long[1] ;
         BC000O103_n202ContatoTelefoneNumero = new bool[] {false} ;
         BC000O103_A203ContatoTelefoneDDD = new short[1] ;
         BC000O103_n203ContatoTelefoneDDD = new bool[] {false} ;
         BC000O103_A204ContatoTelefoneDDI = new short[1] ;
         BC000O103_n204ContatoTelefoneDDI = new bool[] {false} ;
         BC000O103_A421ClienteRG = new long[1] ;
         BC000O103_n421ClienteRG = new bool[] {false} ;
         BC000O103_A537ClienteDepositoTipo = new string[] {""} ;
         BC000O103_n537ClienteDepositoTipo = new bool[] {false} ;
         BC000O103_A538ClientePixTipo = new string[] {""} ;
         BC000O103_n538ClientePixTipo = new bool[] {false} ;
         BC000O103_A539ClientePix = new string[] {""} ;
         BC000O103_n539ClientePix = new bool[] {false} ;
         BC000O103_A404BancoCodigo = new int[1] ;
         BC000O103_n404BancoCodigo = new bool[] {false} ;
         BC000O103_A403BancoNome = new string[] {""} ;
         BC000O103_n403BancoNome = new bool[] {false} ;
         BC000O103_A400ContaAgencia = new string[] {""} ;
         BC000O103_n400ContaAgencia = new bool[] {false} ;
         BC000O103_A401ContaNumero = new string[] {""} ;
         BC000O103_n401ContaNumero = new bool[] {false} ;
         BC000O103_A436ResponsavelNome = new string[] {""} ;
         BC000O103_n436ResponsavelNome = new bool[] {false} ;
         BC000O103_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         BC000O103_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         BC000O103_A439ResponsavelEstadoCivil = new string[] {""} ;
         BC000O103_n439ResponsavelEstadoCivil = new bool[] {false} ;
         BC000O103_A576ResponsavelRG = new long[1] ;
         BC000O103_n576ResponsavelRG = new bool[] {false} ;
         BC000O103_A443ResponsavelProfissaoNome = new string[] {""} ;
         BC000O103_n443ResponsavelProfissaoNome = new bool[] {false} ;
         BC000O103_A447ResponsavelCPF = new string[] {""} ;
         BC000O103_n447ResponsavelCPF = new bool[] {false} ;
         BC000O103_A448ResponsavelCEP = new string[] {""} ;
         BC000O103_n448ResponsavelCEP = new bool[] {false} ;
         BC000O103_A449ResponsavelLogradouro = new string[] {""} ;
         BC000O103_n449ResponsavelLogradouro = new bool[] {false} ;
         BC000O103_A450ResponsavelBairro = new string[] {""} ;
         BC000O103_n450ResponsavelBairro = new bool[] {false} ;
         BC000O103_A451ResponsavelCidade = new string[] {""} ;
         BC000O103_n451ResponsavelCidade = new bool[] {false} ;
         BC000O103_A446ResponsavelMunicipioUF = new string[] {""} ;
         BC000O103_n446ResponsavelMunicipioUF = new bool[] {false} ;
         BC000O103_A445ResponsavelMunicipioNome = new string[] {""} ;
         BC000O103_n445ResponsavelMunicipioNome = new bool[] {false} ;
         BC000O103_A452ResponsavelLogradouroNumero = new int[1] ;
         BC000O103_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         BC000O103_A453ResponsavelComplemento = new string[] {""} ;
         BC000O103_n453ResponsavelComplemento = new bool[] {false} ;
         BC000O103_A454ResponsavelDDD = new short[1] ;
         BC000O103_n454ResponsavelDDD = new bool[] {false} ;
         BC000O103_A455ResponsavelNumero = new int[1] ;
         BC000O103_n455ResponsavelNumero = new bool[] {false} ;
         BC000O103_A456ResponsavelEmail = new string[] {""} ;
         BC000O103_n456ResponsavelEmail = new bool[] {false} ;
         BC000O103_A884ClienteSituacao = new string[] {""} ;
         BC000O103_n884ClienteSituacao = new bool[] {false} ;
         BC000O103_A885ResponsavelCargo = new string[] {""} ;
         BC000O103_n885ResponsavelCargo = new bool[] {false} ;
         BC000O103_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O103_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000O103_A1039ClienteTipoRisco = new string[] {""} ;
         BC000O103_A192TipoClienteId = new short[1] ;
         BC000O103_n192TipoClienteId = new bool[] {false} ;
         BC000O103_A186MunicipioCodigo = new string[] {""} ;
         BC000O103_n186MunicipioCodigo = new bool[] {false} ;
         BC000O103_A444ResponsavelMunicipio = new string[] {""} ;
         BC000O103_n444ResponsavelMunicipio = new bool[] {false} ;
         BC000O103_A402BancoId = new int[1] ;
         BC000O103_n402BancoId = new bool[] {false} ;
         BC000O103_A457EspecialidadeId = new int[1] ;
         BC000O103_n457EspecialidadeId = new bool[] {false} ;
         BC000O103_A437ResponsavelNacionalidade = new int[1] ;
         BC000O103_n437ResponsavelNacionalidade = new bool[] {false} ;
         BC000O103_A484ClienteNacionalidade = new int[1] ;
         BC000O103_n484ClienteNacionalidade = new bool[] {false} ;
         BC000O103_A442ResponsavelProfissao = new int[1] ;
         BC000O103_n442ResponsavelProfissao = new bool[] {false} ;
         BC000O103_A487ClienteProfissao = new int[1] ;
         BC000O103_n487ClienteProfissao = new bool[] {false} ;
         BC000O103_A489ClienteConvenio = new int[1] ;
         BC000O103_n489ClienteConvenio = new bool[] {false} ;
         BC000O103_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         BC000O103_A608SecUserId_F = new short[1] ;
         BC000O103_n608SecUserId_F = new bool[] {false} ;
         BC000O103_A309ClienteQtdTitulos_F = new int[1] ;
         BC000O103_n309ClienteQtdTitulos_F = new bool[] {false} ;
         BC000O103_A310ClienteValorAPagar_F = new decimal[1] ;
         BC000O103_n310ClienteValorAPagar_F = new bool[] {false} ;
         BC000O103_A311ClienteValorAReceber_F = new decimal[1] ;
         BC000O103_n311ClienteValorAReceber_F = new bool[] {false} ;
         BC000O103_A732SerasaConsultas_F = new short[1] ;
         BC000O103_A1031RelacionamentoSacado = new short[1] ;
         BC000O103_n1031RelacionamentoSacado = new bool[] {false} ;
         i175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente_bc__default(),
            new Object[][] {
                new Object[] {
               BC000O2_A168ClienteId, BC000O2_A175ClienteCreatedAt, BC000O2_n175ClienteCreatedAt, BC000O2_A176ClienteUpdatedAt, BC000O2_n176ClienteUpdatedAt, BC000O2_A169ClienteDocumento, BC000O2_n169ClienteDocumento, BC000O2_A170ClienteRazaoSocial, BC000O2_n170ClienteRazaoSocial, BC000O2_A171ClienteNomeFantasia,
               BC000O2_n171ClienteNomeFantasia, BC000O2_A459ClienteDataNascimento, BC000O2_n459ClienteDataNascimento, BC000O2_A172ClienteTipoPessoa, BC000O2_n172ClienteTipoPessoa, BC000O2_A174ClienteStatus, BC000O2_n174ClienteStatus, BC000O2_A177ClienteLogUser, BC000O2_n177ClienteLogUser, BC000O2_A486ClienteEstadoCivil,
               BC000O2_n486ClienteEstadoCivil, BC000O2_A181EnderecoTipo, BC000O2_n181EnderecoTipo, BC000O2_A182EnderecoCEP, BC000O2_n182EnderecoCEP, BC000O2_A183EnderecoLogradouro, BC000O2_n183EnderecoLogradouro, BC000O2_A184EnderecoBairro, BC000O2_n184EnderecoBairro, BC000O2_A185EnderecoCidade,
               BC000O2_n185EnderecoCidade, BC000O2_A190EnderecoNumero, BC000O2_n190EnderecoNumero, BC000O2_A191EnderecoComplemento, BC000O2_n191EnderecoComplemento, BC000O2_A201ContatoEmail, BC000O2_n201ContatoEmail, BC000O2_A198ContatoDDD, BC000O2_n198ContatoDDD, BC000O2_A199ContatoDDI,
               BC000O2_n199ContatoDDI, BC000O2_A200ContatoNumero, BC000O2_n200ContatoNumero, BC000O2_A202ContatoTelefoneNumero, BC000O2_n202ContatoTelefoneNumero, BC000O2_A203ContatoTelefoneDDD, BC000O2_n203ContatoTelefoneDDD, BC000O2_A204ContatoTelefoneDDI, BC000O2_n204ContatoTelefoneDDI, BC000O2_A421ClienteRG,
               BC000O2_n421ClienteRG, BC000O2_A537ClienteDepositoTipo, BC000O2_n537ClienteDepositoTipo, BC000O2_A538ClientePixTipo, BC000O2_n538ClientePixTipo, BC000O2_A539ClientePix, BC000O2_n539ClientePix, BC000O2_A400ContaAgencia, BC000O2_n400ContaAgencia, BC000O2_A401ContaNumero,
               BC000O2_n401ContaNumero, BC000O2_A436ResponsavelNome, BC000O2_n436ResponsavelNome, BC000O2_A439ResponsavelEstadoCivil, BC000O2_n439ResponsavelEstadoCivil, BC000O2_A576ResponsavelRG, BC000O2_n576ResponsavelRG, BC000O2_A447ResponsavelCPF, BC000O2_n447ResponsavelCPF, BC000O2_A448ResponsavelCEP,
               BC000O2_n448ResponsavelCEP, BC000O2_A449ResponsavelLogradouro, BC000O2_n449ResponsavelLogradouro, BC000O2_A450ResponsavelBairro, BC000O2_n450ResponsavelBairro, BC000O2_A451ResponsavelCidade, BC000O2_n451ResponsavelCidade, BC000O2_A452ResponsavelLogradouroNumero, BC000O2_n452ResponsavelLogradouroNumero, BC000O2_A453ResponsavelComplemento,
               BC000O2_n453ResponsavelComplemento, BC000O2_A454ResponsavelDDD, BC000O2_n454ResponsavelDDD, BC000O2_A455ResponsavelNumero, BC000O2_n455ResponsavelNumero, BC000O2_A456ResponsavelEmail, BC000O2_n456ResponsavelEmail, BC000O2_A884ClienteSituacao, BC000O2_n884ClienteSituacao, BC000O2_A885ResponsavelCargo,
               BC000O2_n885ResponsavelCargo, BC000O2_A1039ClienteTipoRisco, BC000O2_A192TipoClienteId, BC000O2_n192TipoClienteId, BC000O2_A186MunicipioCodigo, BC000O2_n186MunicipioCodigo, BC000O2_A444ResponsavelMunicipio, BC000O2_n444ResponsavelMunicipio, BC000O2_A402BancoId, BC000O2_n402BancoId,
               BC000O2_A457EspecialidadeId, BC000O2_n457EspecialidadeId, BC000O2_A437ResponsavelNacionalidade, BC000O2_n437ResponsavelNacionalidade, BC000O2_A484ClienteNacionalidade, BC000O2_n484ClienteNacionalidade, BC000O2_A442ResponsavelProfissao, BC000O2_n442ResponsavelProfissao, BC000O2_A487ClienteProfissao, BC000O2_n487ClienteProfissao,
               BC000O2_A489ClienteConvenio, BC000O2_n489ClienteConvenio
               }
               , new Object[] {
               BC000O3_A168ClienteId, BC000O3_A175ClienteCreatedAt, BC000O3_n175ClienteCreatedAt, BC000O3_A176ClienteUpdatedAt, BC000O3_n176ClienteUpdatedAt, BC000O3_A169ClienteDocumento, BC000O3_n169ClienteDocumento, BC000O3_A170ClienteRazaoSocial, BC000O3_n170ClienteRazaoSocial, BC000O3_A171ClienteNomeFantasia,
               BC000O3_n171ClienteNomeFantasia, BC000O3_A459ClienteDataNascimento, BC000O3_n459ClienteDataNascimento, BC000O3_A172ClienteTipoPessoa, BC000O3_n172ClienteTipoPessoa, BC000O3_A174ClienteStatus, BC000O3_n174ClienteStatus, BC000O3_A177ClienteLogUser, BC000O3_n177ClienteLogUser, BC000O3_A486ClienteEstadoCivil,
               BC000O3_n486ClienteEstadoCivil, BC000O3_A181EnderecoTipo, BC000O3_n181EnderecoTipo, BC000O3_A182EnderecoCEP, BC000O3_n182EnderecoCEP, BC000O3_A183EnderecoLogradouro, BC000O3_n183EnderecoLogradouro, BC000O3_A184EnderecoBairro, BC000O3_n184EnderecoBairro, BC000O3_A185EnderecoCidade,
               BC000O3_n185EnderecoCidade, BC000O3_A190EnderecoNumero, BC000O3_n190EnderecoNumero, BC000O3_A191EnderecoComplemento, BC000O3_n191EnderecoComplemento, BC000O3_A201ContatoEmail, BC000O3_n201ContatoEmail, BC000O3_A198ContatoDDD, BC000O3_n198ContatoDDD, BC000O3_A199ContatoDDI,
               BC000O3_n199ContatoDDI, BC000O3_A200ContatoNumero, BC000O3_n200ContatoNumero, BC000O3_A202ContatoTelefoneNumero, BC000O3_n202ContatoTelefoneNumero, BC000O3_A203ContatoTelefoneDDD, BC000O3_n203ContatoTelefoneDDD, BC000O3_A204ContatoTelefoneDDI, BC000O3_n204ContatoTelefoneDDI, BC000O3_A421ClienteRG,
               BC000O3_n421ClienteRG, BC000O3_A537ClienteDepositoTipo, BC000O3_n537ClienteDepositoTipo, BC000O3_A538ClientePixTipo, BC000O3_n538ClientePixTipo, BC000O3_A539ClientePix, BC000O3_n539ClientePix, BC000O3_A400ContaAgencia, BC000O3_n400ContaAgencia, BC000O3_A401ContaNumero,
               BC000O3_n401ContaNumero, BC000O3_A436ResponsavelNome, BC000O3_n436ResponsavelNome, BC000O3_A439ResponsavelEstadoCivil, BC000O3_n439ResponsavelEstadoCivil, BC000O3_A576ResponsavelRG, BC000O3_n576ResponsavelRG, BC000O3_A447ResponsavelCPF, BC000O3_n447ResponsavelCPF, BC000O3_A448ResponsavelCEP,
               BC000O3_n448ResponsavelCEP, BC000O3_A449ResponsavelLogradouro, BC000O3_n449ResponsavelLogradouro, BC000O3_A450ResponsavelBairro, BC000O3_n450ResponsavelBairro, BC000O3_A451ResponsavelCidade, BC000O3_n451ResponsavelCidade, BC000O3_A452ResponsavelLogradouroNumero, BC000O3_n452ResponsavelLogradouroNumero, BC000O3_A453ResponsavelComplemento,
               BC000O3_n453ResponsavelComplemento, BC000O3_A454ResponsavelDDD, BC000O3_n454ResponsavelDDD, BC000O3_A455ResponsavelNumero, BC000O3_n455ResponsavelNumero, BC000O3_A456ResponsavelEmail, BC000O3_n456ResponsavelEmail, BC000O3_A884ClienteSituacao, BC000O3_n884ClienteSituacao, BC000O3_A885ResponsavelCargo,
               BC000O3_n885ResponsavelCargo, BC000O3_A1039ClienteTipoRisco, BC000O3_A192TipoClienteId, BC000O3_n192TipoClienteId, BC000O3_A186MunicipioCodigo, BC000O3_n186MunicipioCodigo, BC000O3_A444ResponsavelMunicipio, BC000O3_n444ResponsavelMunicipio, BC000O3_A402BancoId, BC000O3_n402BancoId,
               BC000O3_A457EspecialidadeId, BC000O3_n457EspecialidadeId, BC000O3_A437ResponsavelNacionalidade, BC000O3_n437ResponsavelNacionalidade, BC000O3_A484ClienteNacionalidade, BC000O3_n484ClienteNacionalidade, BC000O3_A442ResponsavelProfissao, BC000O3_n442ResponsavelProfissao, BC000O3_A487ClienteProfissao, BC000O3_n487ClienteProfissao,
               BC000O3_A489ClienteConvenio, BC000O3_n489ClienteConvenio
               }
               , new Object[] {
               BC000O4_A193TipoClienteDescricao, BC000O4_n193TipoClienteDescricao, BC000O4_A207TipoClientePortal, BC000O4_n207TipoClientePortal, BC000O4_A793TipoClientePortalPjPf, BC000O4_n793TipoClientePortalPjPf
               }
               , new Object[] {
               BC000O5_A187MunicipioNome, BC000O5_n187MunicipioNome, BC000O5_A189MunicipioUF, BC000O5_n189MunicipioUF
               }
               , new Object[] {
               BC000O6_A446ResponsavelMunicipioUF, BC000O6_n446ResponsavelMunicipioUF, BC000O6_A445ResponsavelMunicipioNome, BC000O6_n445ResponsavelMunicipioNome
               }
               , new Object[] {
               BC000O7_A404BancoCodigo, BC000O7_n404BancoCodigo, BC000O7_A403BancoNome, BC000O7_n403BancoNome
               }
               , new Object[] {
               BC000O8_A457EspecialidadeId
               }
               , new Object[] {
               BC000O9_A438ResponsavelNacionalidadeNome, BC000O9_n438ResponsavelNacionalidadeNome
               }
               , new Object[] {
               BC000O10_A485ClienteNacionalidadeNome, BC000O10_n485ClienteNacionalidadeNome
               }
               , new Object[] {
               BC000O11_A443ResponsavelProfissaoNome, BC000O11_n443ResponsavelProfissaoNome
               }
               , new Object[] {
               BC000O12_A488ClienteProfissaoNome, BC000O12_n488ClienteProfissaoNome
               }
               , new Object[] {
               BC000O13_A490ClienteConvenioDescricao, BC000O13_n490ClienteConvenioDescricao
               }
               , new Object[] {
               BC000O15_A781SerasaScoreUltimaData_F, BC000O15_A785SerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               BC000O17_A608SecUserId_F, BC000O17_n608SecUserId_F
               }
               , new Object[] {
               BC000O19_A309ClienteQtdTitulos_F, BC000O19_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               BC000O23_A310ClienteValorAPagar_F, BC000O23_n310ClienteValorAPagar_F
               }
               , new Object[] {
               BC000O26_A311ClienteValorAReceber_F, BC000O26_n311ClienteValorAReceber_F
               }
               , new Object[] {
               BC000O28_A780SerasaUltimaData_F, BC000O28_A732SerasaConsultas_F
               }
               , new Object[] {
               BC000O30_A1031RelacionamentoSacado, BC000O30_n1031RelacionamentoSacado
               }
               , new Object[] {
               BC000O40_A168ClienteId, BC000O40_A175ClienteCreatedAt, BC000O40_n175ClienteCreatedAt, BC000O40_A176ClienteUpdatedAt, BC000O40_n176ClienteUpdatedAt, BC000O40_A169ClienteDocumento, BC000O40_n169ClienteDocumento, BC000O40_A170ClienteRazaoSocial, BC000O40_n170ClienteRazaoSocial, BC000O40_A171ClienteNomeFantasia,
               BC000O40_n171ClienteNomeFantasia, BC000O40_A459ClienteDataNascimento, BC000O40_n459ClienteDataNascimento, BC000O40_A172ClienteTipoPessoa, BC000O40_n172ClienteTipoPessoa, BC000O40_A193TipoClienteDescricao, BC000O40_n193TipoClienteDescricao, BC000O40_A207TipoClientePortal, BC000O40_n207TipoClientePortal, BC000O40_A174ClienteStatus,
               BC000O40_n174ClienteStatus, BC000O40_A490ClienteConvenioDescricao, BC000O40_n490ClienteConvenioDescricao, BC000O40_A177ClienteLogUser, BC000O40_n177ClienteLogUser, BC000O40_A485ClienteNacionalidadeNome, BC000O40_n485ClienteNacionalidadeNome, BC000O40_A488ClienteProfissaoNome, BC000O40_n488ClienteProfissaoNome, BC000O40_A486ClienteEstadoCivil,
               BC000O40_n486ClienteEstadoCivil, BC000O40_A181EnderecoTipo, BC000O40_n181EnderecoTipo, BC000O40_A182EnderecoCEP, BC000O40_n182EnderecoCEP, BC000O40_A183EnderecoLogradouro, BC000O40_n183EnderecoLogradouro, BC000O40_A184EnderecoBairro, BC000O40_n184EnderecoBairro, BC000O40_A185EnderecoCidade,
               BC000O40_n185EnderecoCidade, BC000O40_A187MunicipioNome, BC000O40_n187MunicipioNome, BC000O40_A189MunicipioUF, BC000O40_n189MunicipioUF, BC000O40_A190EnderecoNumero, BC000O40_n190EnderecoNumero, BC000O40_A191EnderecoComplemento, BC000O40_n191EnderecoComplemento, BC000O40_A201ContatoEmail,
               BC000O40_n201ContatoEmail, BC000O40_A198ContatoDDD, BC000O40_n198ContatoDDD, BC000O40_A199ContatoDDI, BC000O40_n199ContatoDDI, BC000O40_A200ContatoNumero, BC000O40_n200ContatoNumero, BC000O40_A202ContatoTelefoneNumero, BC000O40_n202ContatoTelefoneNumero, BC000O40_A203ContatoTelefoneDDD,
               BC000O40_n203ContatoTelefoneDDD, BC000O40_A204ContatoTelefoneDDI, BC000O40_n204ContatoTelefoneDDI, BC000O40_A421ClienteRG, BC000O40_n421ClienteRG, BC000O40_A537ClienteDepositoTipo, BC000O40_n537ClienteDepositoTipo, BC000O40_A538ClientePixTipo, BC000O40_n538ClientePixTipo, BC000O40_A539ClientePix,
               BC000O40_n539ClientePix, BC000O40_A404BancoCodigo, BC000O40_n404BancoCodigo, BC000O40_A403BancoNome, BC000O40_n403BancoNome, BC000O40_A400ContaAgencia, BC000O40_n400ContaAgencia, BC000O40_A401ContaNumero, BC000O40_n401ContaNumero, BC000O40_A436ResponsavelNome,
               BC000O40_n436ResponsavelNome, BC000O40_A438ResponsavelNacionalidadeNome, BC000O40_n438ResponsavelNacionalidadeNome, BC000O40_A439ResponsavelEstadoCivil, BC000O40_n439ResponsavelEstadoCivil, BC000O40_A576ResponsavelRG, BC000O40_n576ResponsavelRG, BC000O40_A443ResponsavelProfissaoNome, BC000O40_n443ResponsavelProfissaoNome, BC000O40_A447ResponsavelCPF,
               BC000O40_n447ResponsavelCPF, BC000O40_A448ResponsavelCEP, BC000O40_n448ResponsavelCEP, BC000O40_A449ResponsavelLogradouro, BC000O40_n449ResponsavelLogradouro, BC000O40_A450ResponsavelBairro, BC000O40_n450ResponsavelBairro, BC000O40_A451ResponsavelCidade, BC000O40_n451ResponsavelCidade, BC000O40_A446ResponsavelMunicipioUF,
               BC000O40_n446ResponsavelMunicipioUF, BC000O40_A445ResponsavelMunicipioNome, BC000O40_n445ResponsavelMunicipioNome, BC000O40_A452ResponsavelLogradouroNumero, BC000O40_n452ResponsavelLogradouroNumero, BC000O40_A453ResponsavelComplemento, BC000O40_n453ResponsavelComplemento, BC000O40_A454ResponsavelDDD, BC000O40_n454ResponsavelDDD, BC000O40_A455ResponsavelNumero,
               BC000O40_n455ResponsavelNumero, BC000O40_A456ResponsavelEmail, BC000O40_n456ResponsavelEmail, BC000O40_A884ClienteSituacao, BC000O40_n884ClienteSituacao, BC000O40_A885ResponsavelCargo, BC000O40_n885ResponsavelCargo, BC000O40_A793TipoClientePortalPjPf, BC000O40_n793TipoClientePortalPjPf, BC000O40_A1039ClienteTipoRisco,
               BC000O40_A192TipoClienteId, BC000O40_n192TipoClienteId, BC000O40_A186MunicipioCodigo, BC000O40_n186MunicipioCodigo, BC000O40_A444ResponsavelMunicipio, BC000O40_n444ResponsavelMunicipio, BC000O40_A402BancoId, BC000O40_n402BancoId, BC000O40_A457EspecialidadeId, BC000O40_n457EspecialidadeId,
               BC000O40_A437ResponsavelNacionalidade, BC000O40_n437ResponsavelNacionalidade, BC000O40_A484ClienteNacionalidade, BC000O40_n484ClienteNacionalidade, BC000O40_A442ResponsavelProfissao, BC000O40_n442ResponsavelProfissao, BC000O40_A487ClienteProfissao, BC000O40_n487ClienteProfissao, BC000O40_A489ClienteConvenio, BC000O40_n489ClienteConvenio,
               BC000O40_A780SerasaUltimaData_F, BC000O40_A608SecUserId_F, BC000O40_n608SecUserId_F, BC000O40_A309ClienteQtdTitulos_F, BC000O40_n309ClienteQtdTitulos_F, BC000O40_A310ClienteValorAPagar_F, BC000O40_n310ClienteValorAPagar_F, BC000O40_A311ClienteValorAReceber_F, BC000O40_n311ClienteValorAReceber_F, BC000O40_A732SerasaConsultas_F,
               BC000O40_A1031RelacionamentoSacado, BC000O40_n1031RelacionamentoSacado
               }
               , new Object[] {
               BC000O41_A169ClienteDocumento, BC000O41_n169ClienteDocumento
               }
               , new Object[] {
               BC000O42_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O44_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O48_A608SecUserId_F, BC000O48_n608SecUserId_F
               }
               , new Object[] {
               BC000O50_A309ClienteQtdTitulos_F, BC000O50_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               BC000O54_A310ClienteValorAPagar_F, BC000O54_n310ClienteValorAPagar_F
               }
               , new Object[] {
               BC000O57_A311ClienteValorAReceber_F, BC000O57_n311ClienteValorAReceber_F
               }
               , new Object[] {
               BC000O59_A780SerasaUltimaData_F, BC000O59_A732SerasaConsultas_F
               }
               , new Object[] {
               BC000O61_A781SerasaScoreUltimaData_F, BC000O61_A785SerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               BC000O63_A1031RelacionamentoSacado, BC000O63_n1031RelacionamentoSacado
               }
               , new Object[] {
               BC000O64_A193TipoClienteDescricao, BC000O64_n193TipoClienteDescricao, BC000O64_A207TipoClientePortal, BC000O64_n207TipoClientePortal, BC000O64_A793TipoClientePortalPjPf, BC000O64_n793TipoClientePortalPjPf
               }
               , new Object[] {
               BC000O65_A490ClienteConvenioDescricao, BC000O65_n490ClienteConvenioDescricao
               }
               , new Object[] {
               BC000O66_A485ClienteNacionalidadeNome, BC000O66_n485ClienteNacionalidadeNome
               }
               , new Object[] {
               BC000O67_A488ClienteProfissaoNome, BC000O67_n488ClienteProfissaoNome
               }
               , new Object[] {
               BC000O68_A187MunicipioNome, BC000O68_n187MunicipioNome, BC000O68_A189MunicipioUF, BC000O68_n189MunicipioUF
               }
               , new Object[] {
               BC000O69_A404BancoCodigo, BC000O69_n404BancoCodigo, BC000O69_A403BancoNome, BC000O69_n403BancoNome
               }
               , new Object[] {
               BC000O70_A438ResponsavelNacionalidadeNome, BC000O70_n438ResponsavelNacionalidadeNome
               }
               , new Object[] {
               BC000O71_A443ResponsavelProfissaoNome, BC000O71_n443ResponsavelProfissaoNome
               }
               , new Object[] {
               BC000O72_A446ResponsavelMunicipioUF, BC000O72_n446ResponsavelMunicipioUF, BC000O72_A445ResponsavelMunicipioNome, BC000O72_n445ResponsavelMunicipioNome
               }
               , new Object[] {
               BC000O73_A1019OperacoesTitulosId
               }
               , new Object[] {
               BC000O74_A323PropostaId
               }
               , new Object[] {
               BC000O75_A323PropostaId
               }
               , new Object[] {
               BC000O76_A323PropostaId
               }
               , new Object[] {
               BC000O77_A323PropostaId
               }
               , new Object[] {
               BC000O78_A227ContratoId
               }
               , new Object[] {
               BC000O79_A261TituloId
               }
               , new Object[] {
               BC000O80_A133SecUserId
               }
               , new Object[] {
               BC000O81_A1032RelacionamentoId
               }
               , new Object[] {
               BC000O82_A1010OperacoesId
               }
               , new Object[] {
               BC000O83_A978RepresentanteId
               }
               , new Object[] {
               BC000O84_A856CreditoId
               }
               , new Object[] {
               BC000O85_A794NotaFiscalId
               }
               , new Object[] {
               BC000O86_A794NotaFiscalId
               }
               , new Object[] {
               BC000O87_A662SerasaId
               }
               , new Object[] {
               BC000O88_A599ClienteDocumentoId
               }
               , new Object[] {
               BC000O89_A551ClienteReponsavelId
               }
               , new Object[] {
               BC000O90_A551ClienteReponsavelId
               }
               , new Object[] {
               BC000O91_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC000O92_A223FinanciamentoId
               }
               , new Object[] {
               BC000O93_A223FinanciamentoId
               }
               , new Object[] {
               BC000O103_A168ClienteId, BC000O103_A175ClienteCreatedAt, BC000O103_n175ClienteCreatedAt, BC000O103_A176ClienteUpdatedAt, BC000O103_n176ClienteUpdatedAt, BC000O103_A169ClienteDocumento, BC000O103_n169ClienteDocumento, BC000O103_A170ClienteRazaoSocial, BC000O103_n170ClienteRazaoSocial, BC000O103_A171ClienteNomeFantasia,
               BC000O103_n171ClienteNomeFantasia, BC000O103_A459ClienteDataNascimento, BC000O103_n459ClienteDataNascimento, BC000O103_A172ClienteTipoPessoa, BC000O103_n172ClienteTipoPessoa, BC000O103_A193TipoClienteDescricao, BC000O103_n193TipoClienteDescricao, BC000O103_A207TipoClientePortal, BC000O103_n207TipoClientePortal, BC000O103_A174ClienteStatus,
               BC000O103_n174ClienteStatus, BC000O103_A490ClienteConvenioDescricao, BC000O103_n490ClienteConvenioDescricao, BC000O103_A177ClienteLogUser, BC000O103_n177ClienteLogUser, BC000O103_A485ClienteNacionalidadeNome, BC000O103_n485ClienteNacionalidadeNome, BC000O103_A488ClienteProfissaoNome, BC000O103_n488ClienteProfissaoNome, BC000O103_A486ClienteEstadoCivil,
               BC000O103_n486ClienteEstadoCivil, BC000O103_A181EnderecoTipo, BC000O103_n181EnderecoTipo, BC000O103_A182EnderecoCEP, BC000O103_n182EnderecoCEP, BC000O103_A183EnderecoLogradouro, BC000O103_n183EnderecoLogradouro, BC000O103_A184EnderecoBairro, BC000O103_n184EnderecoBairro, BC000O103_A185EnderecoCidade,
               BC000O103_n185EnderecoCidade, BC000O103_A187MunicipioNome, BC000O103_n187MunicipioNome, BC000O103_A189MunicipioUF, BC000O103_n189MunicipioUF, BC000O103_A190EnderecoNumero, BC000O103_n190EnderecoNumero, BC000O103_A191EnderecoComplemento, BC000O103_n191EnderecoComplemento, BC000O103_A201ContatoEmail,
               BC000O103_n201ContatoEmail, BC000O103_A198ContatoDDD, BC000O103_n198ContatoDDD, BC000O103_A199ContatoDDI, BC000O103_n199ContatoDDI, BC000O103_A200ContatoNumero, BC000O103_n200ContatoNumero, BC000O103_A202ContatoTelefoneNumero, BC000O103_n202ContatoTelefoneNumero, BC000O103_A203ContatoTelefoneDDD,
               BC000O103_n203ContatoTelefoneDDD, BC000O103_A204ContatoTelefoneDDI, BC000O103_n204ContatoTelefoneDDI, BC000O103_A421ClienteRG, BC000O103_n421ClienteRG, BC000O103_A537ClienteDepositoTipo, BC000O103_n537ClienteDepositoTipo, BC000O103_A538ClientePixTipo, BC000O103_n538ClientePixTipo, BC000O103_A539ClientePix,
               BC000O103_n539ClientePix, BC000O103_A404BancoCodigo, BC000O103_n404BancoCodigo, BC000O103_A403BancoNome, BC000O103_n403BancoNome, BC000O103_A400ContaAgencia, BC000O103_n400ContaAgencia, BC000O103_A401ContaNumero, BC000O103_n401ContaNumero, BC000O103_A436ResponsavelNome,
               BC000O103_n436ResponsavelNome, BC000O103_A438ResponsavelNacionalidadeNome, BC000O103_n438ResponsavelNacionalidadeNome, BC000O103_A439ResponsavelEstadoCivil, BC000O103_n439ResponsavelEstadoCivil, BC000O103_A576ResponsavelRG, BC000O103_n576ResponsavelRG, BC000O103_A443ResponsavelProfissaoNome, BC000O103_n443ResponsavelProfissaoNome, BC000O103_A447ResponsavelCPF,
               BC000O103_n447ResponsavelCPF, BC000O103_A448ResponsavelCEP, BC000O103_n448ResponsavelCEP, BC000O103_A449ResponsavelLogradouro, BC000O103_n449ResponsavelLogradouro, BC000O103_A450ResponsavelBairro, BC000O103_n450ResponsavelBairro, BC000O103_A451ResponsavelCidade, BC000O103_n451ResponsavelCidade, BC000O103_A446ResponsavelMunicipioUF,
               BC000O103_n446ResponsavelMunicipioUF, BC000O103_A445ResponsavelMunicipioNome, BC000O103_n445ResponsavelMunicipioNome, BC000O103_A452ResponsavelLogradouroNumero, BC000O103_n452ResponsavelLogradouroNumero, BC000O103_A453ResponsavelComplemento, BC000O103_n453ResponsavelComplemento, BC000O103_A454ResponsavelDDD, BC000O103_n454ResponsavelDDD, BC000O103_A455ResponsavelNumero,
               BC000O103_n455ResponsavelNumero, BC000O103_A456ResponsavelEmail, BC000O103_n456ResponsavelEmail, BC000O103_A884ClienteSituacao, BC000O103_n884ClienteSituacao, BC000O103_A885ResponsavelCargo, BC000O103_n885ResponsavelCargo, BC000O103_A793TipoClientePortalPjPf, BC000O103_n793TipoClientePortalPjPf, BC000O103_A1039ClienteTipoRisco,
               BC000O103_A192TipoClienteId, BC000O103_n192TipoClienteId, BC000O103_A186MunicipioCodigo, BC000O103_n186MunicipioCodigo, BC000O103_A444ResponsavelMunicipio, BC000O103_n444ResponsavelMunicipio, BC000O103_A402BancoId, BC000O103_n402BancoId, BC000O103_A457EspecialidadeId, BC000O103_n457EspecialidadeId,
               BC000O103_A437ResponsavelNacionalidade, BC000O103_n437ResponsavelNacionalidade, BC000O103_A484ClienteNacionalidade, BC000O103_n484ClienteNacionalidade, BC000O103_A442ResponsavelProfissao, BC000O103_n442ResponsavelProfissao, BC000O103_A487ClienteProfissao, BC000O103_n487ClienteProfissao, BC000O103_A489ClienteConvenio, BC000O103_n489ClienteConvenio,
               BC000O103_A780SerasaUltimaData_F, BC000O103_A608SecUserId_F, BC000O103_n608SecUserId_F, BC000O103_A309ClienteQtdTitulos_F, BC000O103_n309ClienteQtdTitulos_F, BC000O103_A310ClienteValorAPagar_F, BC000O103_n310ClienteValorAPagar_F, BC000O103_A311ClienteValorAReceber_F, BC000O103_n311ClienteValorAReceber_F, BC000O103_A732SerasaConsultas_F,
               BC000O103_A1031RelacionamentoSacado, BC000O103_n1031RelacionamentoSacado
               }
            }
         );
         AV35Pgmname = "Cliente_BC";
         Z174ClienteStatus = true;
         n174ClienteStatus = false;
         A174ClienteStatus = true;
         n174ClienteStatus = false;
         i174ClienteStatus = true;
         n174ClienteStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120O2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV14Insert_TipoClienteId ;
      private short Z177ClienteLogUser ;
      private short A177ClienteLogUser ;
      private short Z198ContatoDDD ;
      private short A198ContatoDDD ;
      private short Z199ContatoDDI ;
      private short A199ContatoDDI ;
      private short Z203ContatoTelefoneDDD ;
      private short A203ContatoTelefoneDDD ;
      private short Z204ContatoTelefoneDDI ;
      private short A204ContatoTelefoneDDI ;
      private short Z454ResponsavelDDD ;
      private short A454ResponsavelDDD ;
      private short Z192TipoClienteId ;
      private short A192TipoClienteId ;
      private short Z608SecUserId_F ;
      private short A608SecUserId_F ;
      private short Z732SerasaConsultas_F ;
      private short A732SerasaConsultas_F ;
      private short Z781SerasaScoreUltimaData_F ;
      private short A781SerasaScoreUltimaData_F ;
      private short Z1031RelacionamentoSacado ;
      private short A1031RelacionamentoSacado ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private int trnEnded ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int AV36GXV1 ;
      private int AV29Insert_EspecialidadeId ;
      private int AV32Insert_ClienteConvenio ;
      private int AV30Insert_ClienteNacionalidade ;
      private int AV31Insert_ClienteProfissao ;
      private int AV25Insert_BancoId ;
      private int AV26Insert_ResponsavelNacionalidade ;
      private int AV27Insert_ResponsavelProfissao ;
      private int Z452ResponsavelLogradouroNumero ;
      private int A452ResponsavelLogradouroNumero ;
      private int Z455ResponsavelNumero ;
      private int A455ResponsavelNumero ;
      private int Z402BancoId ;
      private int A402BancoId ;
      private int Z457EspecialidadeId ;
      private int A457EspecialidadeId ;
      private int Z437ResponsavelNacionalidade ;
      private int A437ResponsavelNacionalidade ;
      private int Z484ClienteNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int Z442ResponsavelProfissao ;
      private int A442ResponsavelProfissao ;
      private int Z487ClienteProfissao ;
      private int A487ClienteProfissao ;
      private int Z489ClienteConvenio ;
      private int A489ClienteConvenio ;
      private int Z309ClienteQtdTitulos_F ;
      private int A309ClienteQtdTitulos_F ;
      private int Z404BancoCodigo ;
      private int A404BancoCodigo ;
      private long Z200ContatoNumero ;
      private long A200ContatoNumero ;
      private long Z202ContatoTelefoneNumero ;
      private long A202ContatoTelefoneNumero ;
      private long Z421ClienteRG ;
      private long A421ClienteRG ;
      private long Z576ResponsavelRG ;
      private long A576ResponsavelRG ;
      private decimal Z310ClienteValorAPagar_F ;
      private decimal A310ClienteValorAPagar_F ;
      private decimal Z311ClienteValorAReceber_F ;
      private decimal A311ClienteValorAReceber_F ;
      private decimal Z785SerasaUltimoValorRecomendado_F ;
      private decimal A785SerasaUltimoValorRecomendado_F ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV35Pgmname ;
      private string Z884ClienteSituacao ;
      private string A884ClienteSituacao ;
      private string sMode28 ;
      private string GXt_char1 ;
      private DateTime Z175ClienteCreatedAt ;
      private DateTime A175ClienteCreatedAt ;
      private DateTime Z176ClienteUpdatedAt ;
      private DateTime A176ClienteUpdatedAt ;
      private DateTime Z780SerasaUltimaData_F ;
      private DateTime A780SerasaUltimaData_F ;
      private DateTime i175ClienteCreatedAt ;
      private DateTime Z459ClienteDataNascimento ;
      private DateTime A459ClienteDataNascimento ;
      private bool returnInSub ;
      private bool Z174ClienteStatus ;
      private bool A174ClienteStatus ;
      private bool Z1030ClienteSacado ;
      private bool A1030ClienteSacado ;
      private bool Z207TipoClientePortal ;
      private bool A207TipoClientePortal ;
      private bool Z793TipoClientePortalPjPf ;
      private bool A793TipoClientePortalPjPf ;
      private bool n175ClienteCreatedAt ;
      private bool n176ClienteUpdatedAt ;
      private bool n174ClienteStatus ;
      private bool n168ClienteId ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n459ClienteDataNascimento ;
      private bool n172ClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private bool n207TipoClientePortal ;
      private bool n490ClienteConvenioDescricao ;
      private bool n177ClienteLogUser ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n486ClienteEstadoCivil ;
      private bool n181EnderecoTipo ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n184EnderecoBairro ;
      private bool n185EnderecoCidade ;
      private bool n187MunicipioNome ;
      private bool n189MunicipioUF ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private bool n201ContatoEmail ;
      private bool n198ContatoDDD ;
      private bool n199ContatoDDI ;
      private bool n200ContatoNumero ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n204ContatoTelefoneDDI ;
      private bool n421ClienteRG ;
      private bool n537ClienteDepositoTipo ;
      private bool n538ClientePixTipo ;
      private bool n539ClientePix ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private bool n400ContaAgencia ;
      private bool n401ContaNumero ;
      private bool n436ResponsavelNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n439ResponsavelEstadoCivil ;
      private bool n576ResponsavelRG ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n447ResponsavelCPF ;
      private bool n448ResponsavelCEP ;
      private bool n449ResponsavelLogradouro ;
      private bool n450ResponsavelBairro ;
      private bool n451ResponsavelCidade ;
      private bool n446ResponsavelMunicipioUF ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n452ResponsavelLogradouroNumero ;
      private bool n453ResponsavelComplemento ;
      private bool n454ResponsavelDDD ;
      private bool n455ResponsavelNumero ;
      private bool n456ResponsavelEmail ;
      private bool n884ClienteSituacao ;
      private bool n885ResponsavelCargo ;
      private bool n793TipoClientePortalPjPf ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n457EspecialidadeId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n608SecUserId_F ;
      private bool n309ClienteQtdTitulos_F ;
      private bool n310ClienteValorAPagar_F ;
      private bool n311ClienteValorAReceber_F ;
      private bool n1031RelacionamentoSacado ;
      private bool Gx_longc ;
      private bool i174ClienteStatus ;
      private string AV17Insert_MunicipioCodigo ;
      private string AV28Insert_ResponsavelMunicipio ;
      private string Z169ClienteDocumento ;
      private string A169ClienteDocumento ;
      private string Z170ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private string Z171ClienteNomeFantasia ;
      private string A171ClienteNomeFantasia ;
      private string Z172ClienteTipoPessoa ;
      private string A172ClienteTipoPessoa ;
      private string Z486ClienteEstadoCivil ;
      private string A486ClienteEstadoCivil ;
      private string Z181EnderecoTipo ;
      private string A181EnderecoTipo ;
      private string Z182EnderecoCEP ;
      private string A182EnderecoCEP ;
      private string Z183EnderecoLogradouro ;
      private string A183EnderecoLogradouro ;
      private string Z184EnderecoBairro ;
      private string A184EnderecoBairro ;
      private string Z185EnderecoCidade ;
      private string A185EnderecoCidade ;
      private string Z190EnderecoNumero ;
      private string A190EnderecoNumero ;
      private string Z191EnderecoComplemento ;
      private string A191EnderecoComplemento ;
      private string Z201ContatoEmail ;
      private string A201ContatoEmail ;
      private string Z537ClienteDepositoTipo ;
      private string A537ClienteDepositoTipo ;
      private string Z538ClientePixTipo ;
      private string A538ClientePixTipo ;
      private string Z539ClientePix ;
      private string A539ClientePix ;
      private string Z400ContaAgencia ;
      private string A400ContaAgencia ;
      private string Z401ContaNumero ;
      private string A401ContaNumero ;
      private string Z436ResponsavelNome ;
      private string A436ResponsavelNome ;
      private string Z439ResponsavelEstadoCivil ;
      private string A439ResponsavelEstadoCivil ;
      private string Z447ResponsavelCPF ;
      private string A447ResponsavelCPF ;
      private string Z448ResponsavelCEP ;
      private string A448ResponsavelCEP ;
      private string Z449ResponsavelLogradouro ;
      private string A449ResponsavelLogradouro ;
      private string Z450ResponsavelBairro ;
      private string A450ResponsavelBairro ;
      private string Z451ResponsavelCidade ;
      private string A451ResponsavelCidade ;
      private string Z453ResponsavelComplemento ;
      private string A453ResponsavelComplemento ;
      private string Z456ResponsavelEmail ;
      private string A456ResponsavelEmail ;
      private string Z885ResponsavelCargo ;
      private string A885ResponsavelCargo ;
      private string Z1039ClienteTipoRisco ;
      private string A1039ClienteTipoRisco ;
      private string Z186MunicipioCodigo ;
      private string A186MunicipioCodigo ;
      private string Z444ResponsavelMunicipio ;
      private string A444ResponsavelMunicipio ;
      private string Z205ClienteTelefone_F ;
      private string A205ClienteTelefone_F ;
      private string Z206ClienteCelular_F ;
      private string A206ClienteCelular_F ;
      private string Z577ResponsavelCelular_F ;
      private string A577ResponsavelCelular_F ;
      private string Z193TipoClienteDescricao ;
      private string A193TipoClienteDescricao ;
      private string Z187MunicipioNome ;
      private string A187MunicipioNome ;
      private string Z189MunicipioUF ;
      private string A189MunicipioUF ;
      private string Z446ResponsavelMunicipioUF ;
      private string A446ResponsavelMunicipioUF ;
      private string Z445ResponsavelMunicipioNome ;
      private string A445ResponsavelMunicipioNome ;
      private string Z403BancoNome ;
      private string A403BancoNome ;
      private string Z438ResponsavelNacionalidadeNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string Z485ClienteNacionalidadeNome ;
      private string A485ClienteNacionalidadeNome ;
      private string Z443ResponsavelProfissaoNome ;
      private string A443ResponsavelProfissaoNome ;
      private string Z488ClienteProfissaoNome ;
      private string A488ClienteProfissaoNome ;
      private string Z490ClienteConvenioDescricao ;
      private string A490ClienteConvenioDescricao ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC000O40_A168ClienteId ;
      private bool[] BC000O40_n168ClienteId ;
      private DateTime[] BC000O40_A175ClienteCreatedAt ;
      private bool[] BC000O40_n175ClienteCreatedAt ;
      private DateTime[] BC000O40_A176ClienteUpdatedAt ;
      private bool[] BC000O40_n176ClienteUpdatedAt ;
      private string[] BC000O40_A169ClienteDocumento ;
      private bool[] BC000O40_n169ClienteDocumento ;
      private string[] BC000O40_A170ClienteRazaoSocial ;
      private bool[] BC000O40_n170ClienteRazaoSocial ;
      private string[] BC000O40_A171ClienteNomeFantasia ;
      private bool[] BC000O40_n171ClienteNomeFantasia ;
      private DateTime[] BC000O40_A459ClienteDataNascimento ;
      private bool[] BC000O40_n459ClienteDataNascimento ;
      private string[] BC000O40_A172ClienteTipoPessoa ;
      private bool[] BC000O40_n172ClienteTipoPessoa ;
      private string[] BC000O40_A193TipoClienteDescricao ;
      private bool[] BC000O40_n193TipoClienteDescricao ;
      private bool[] BC000O40_A207TipoClientePortal ;
      private bool[] BC000O40_n207TipoClientePortal ;
      private bool[] BC000O40_A174ClienteStatus ;
      private bool[] BC000O40_n174ClienteStatus ;
      private string[] BC000O40_A490ClienteConvenioDescricao ;
      private bool[] BC000O40_n490ClienteConvenioDescricao ;
      private short[] BC000O40_A177ClienteLogUser ;
      private bool[] BC000O40_n177ClienteLogUser ;
      private string[] BC000O40_A485ClienteNacionalidadeNome ;
      private bool[] BC000O40_n485ClienteNacionalidadeNome ;
      private string[] BC000O40_A488ClienteProfissaoNome ;
      private bool[] BC000O40_n488ClienteProfissaoNome ;
      private string[] BC000O40_A486ClienteEstadoCivil ;
      private bool[] BC000O40_n486ClienteEstadoCivil ;
      private string[] BC000O40_A181EnderecoTipo ;
      private bool[] BC000O40_n181EnderecoTipo ;
      private string[] BC000O40_A182EnderecoCEP ;
      private bool[] BC000O40_n182EnderecoCEP ;
      private string[] BC000O40_A183EnderecoLogradouro ;
      private bool[] BC000O40_n183EnderecoLogradouro ;
      private string[] BC000O40_A184EnderecoBairro ;
      private bool[] BC000O40_n184EnderecoBairro ;
      private string[] BC000O40_A185EnderecoCidade ;
      private bool[] BC000O40_n185EnderecoCidade ;
      private string[] BC000O40_A187MunicipioNome ;
      private bool[] BC000O40_n187MunicipioNome ;
      private string[] BC000O40_A189MunicipioUF ;
      private bool[] BC000O40_n189MunicipioUF ;
      private string[] BC000O40_A190EnderecoNumero ;
      private bool[] BC000O40_n190EnderecoNumero ;
      private string[] BC000O40_A191EnderecoComplemento ;
      private bool[] BC000O40_n191EnderecoComplemento ;
      private string[] BC000O40_A201ContatoEmail ;
      private bool[] BC000O40_n201ContatoEmail ;
      private short[] BC000O40_A198ContatoDDD ;
      private bool[] BC000O40_n198ContatoDDD ;
      private short[] BC000O40_A199ContatoDDI ;
      private bool[] BC000O40_n199ContatoDDI ;
      private long[] BC000O40_A200ContatoNumero ;
      private bool[] BC000O40_n200ContatoNumero ;
      private long[] BC000O40_A202ContatoTelefoneNumero ;
      private bool[] BC000O40_n202ContatoTelefoneNumero ;
      private short[] BC000O40_A203ContatoTelefoneDDD ;
      private bool[] BC000O40_n203ContatoTelefoneDDD ;
      private short[] BC000O40_A204ContatoTelefoneDDI ;
      private bool[] BC000O40_n204ContatoTelefoneDDI ;
      private long[] BC000O40_A421ClienteRG ;
      private bool[] BC000O40_n421ClienteRG ;
      private string[] BC000O40_A537ClienteDepositoTipo ;
      private bool[] BC000O40_n537ClienteDepositoTipo ;
      private string[] BC000O40_A538ClientePixTipo ;
      private bool[] BC000O40_n538ClientePixTipo ;
      private string[] BC000O40_A539ClientePix ;
      private bool[] BC000O40_n539ClientePix ;
      private int[] BC000O40_A404BancoCodigo ;
      private bool[] BC000O40_n404BancoCodigo ;
      private string[] BC000O40_A403BancoNome ;
      private bool[] BC000O40_n403BancoNome ;
      private string[] BC000O40_A400ContaAgencia ;
      private bool[] BC000O40_n400ContaAgencia ;
      private string[] BC000O40_A401ContaNumero ;
      private bool[] BC000O40_n401ContaNumero ;
      private string[] BC000O40_A436ResponsavelNome ;
      private bool[] BC000O40_n436ResponsavelNome ;
      private string[] BC000O40_A438ResponsavelNacionalidadeNome ;
      private bool[] BC000O40_n438ResponsavelNacionalidadeNome ;
      private string[] BC000O40_A439ResponsavelEstadoCivil ;
      private bool[] BC000O40_n439ResponsavelEstadoCivil ;
      private long[] BC000O40_A576ResponsavelRG ;
      private bool[] BC000O40_n576ResponsavelRG ;
      private string[] BC000O40_A443ResponsavelProfissaoNome ;
      private bool[] BC000O40_n443ResponsavelProfissaoNome ;
      private string[] BC000O40_A447ResponsavelCPF ;
      private bool[] BC000O40_n447ResponsavelCPF ;
      private string[] BC000O40_A448ResponsavelCEP ;
      private bool[] BC000O40_n448ResponsavelCEP ;
      private string[] BC000O40_A449ResponsavelLogradouro ;
      private bool[] BC000O40_n449ResponsavelLogradouro ;
      private string[] BC000O40_A450ResponsavelBairro ;
      private bool[] BC000O40_n450ResponsavelBairro ;
      private string[] BC000O40_A451ResponsavelCidade ;
      private bool[] BC000O40_n451ResponsavelCidade ;
      private string[] BC000O40_A446ResponsavelMunicipioUF ;
      private bool[] BC000O40_n446ResponsavelMunicipioUF ;
      private string[] BC000O40_A445ResponsavelMunicipioNome ;
      private bool[] BC000O40_n445ResponsavelMunicipioNome ;
      private int[] BC000O40_A452ResponsavelLogradouroNumero ;
      private bool[] BC000O40_n452ResponsavelLogradouroNumero ;
      private string[] BC000O40_A453ResponsavelComplemento ;
      private bool[] BC000O40_n453ResponsavelComplemento ;
      private short[] BC000O40_A454ResponsavelDDD ;
      private bool[] BC000O40_n454ResponsavelDDD ;
      private int[] BC000O40_A455ResponsavelNumero ;
      private bool[] BC000O40_n455ResponsavelNumero ;
      private string[] BC000O40_A456ResponsavelEmail ;
      private bool[] BC000O40_n456ResponsavelEmail ;
      private string[] BC000O40_A884ClienteSituacao ;
      private bool[] BC000O40_n884ClienteSituacao ;
      private string[] BC000O40_A885ResponsavelCargo ;
      private bool[] BC000O40_n885ResponsavelCargo ;
      private bool[] BC000O40_A793TipoClientePortalPjPf ;
      private bool[] BC000O40_n793TipoClientePortalPjPf ;
      private string[] BC000O40_A1039ClienteTipoRisco ;
      private short[] BC000O40_A192TipoClienteId ;
      private bool[] BC000O40_n192TipoClienteId ;
      private string[] BC000O40_A186MunicipioCodigo ;
      private bool[] BC000O40_n186MunicipioCodigo ;
      private string[] BC000O40_A444ResponsavelMunicipio ;
      private bool[] BC000O40_n444ResponsavelMunicipio ;
      private int[] BC000O40_A402BancoId ;
      private bool[] BC000O40_n402BancoId ;
      private int[] BC000O40_A457EspecialidadeId ;
      private bool[] BC000O40_n457EspecialidadeId ;
      private int[] BC000O40_A437ResponsavelNacionalidade ;
      private bool[] BC000O40_n437ResponsavelNacionalidade ;
      private int[] BC000O40_A484ClienteNacionalidade ;
      private bool[] BC000O40_n484ClienteNacionalidade ;
      private int[] BC000O40_A442ResponsavelProfissao ;
      private bool[] BC000O40_n442ResponsavelProfissao ;
      private int[] BC000O40_A487ClienteProfissao ;
      private bool[] BC000O40_n487ClienteProfissao ;
      private int[] BC000O40_A489ClienteConvenio ;
      private bool[] BC000O40_n489ClienteConvenio ;
      private DateTime[] BC000O40_A780SerasaUltimaData_F ;
      private short[] BC000O40_A608SecUserId_F ;
      private bool[] BC000O40_n608SecUserId_F ;
      private int[] BC000O40_A309ClienteQtdTitulos_F ;
      private bool[] BC000O40_n309ClienteQtdTitulos_F ;
      private decimal[] BC000O40_A310ClienteValorAPagar_F ;
      private bool[] BC000O40_n310ClienteValorAPagar_F ;
      private decimal[] BC000O40_A311ClienteValorAReceber_F ;
      private bool[] BC000O40_n311ClienteValorAReceber_F ;
      private short[] BC000O40_A732SerasaConsultas_F ;
      private short[] BC000O40_A1031RelacionamentoSacado ;
      private bool[] BC000O40_n1031RelacionamentoSacado ;
      private short[] BC000O15_A781SerasaScoreUltimaData_F ;
      private decimal[] BC000O15_A785SerasaUltimoValorRecomendado_F ;
      private short[] BC000O17_A608SecUserId_F ;
      private bool[] BC000O17_n608SecUserId_F ;
      private int[] BC000O19_A309ClienteQtdTitulos_F ;
      private bool[] BC000O19_n309ClienteQtdTitulos_F ;
      private decimal[] BC000O23_A310ClienteValorAPagar_F ;
      private bool[] BC000O23_n310ClienteValorAPagar_F ;
      private decimal[] BC000O26_A311ClienteValorAReceber_F ;
      private bool[] BC000O26_n311ClienteValorAReceber_F ;
      private DateTime[] BC000O28_A780SerasaUltimaData_F ;
      private short[] BC000O28_A732SerasaConsultas_F ;
      private short[] BC000O30_A1031RelacionamentoSacado ;
      private bool[] BC000O30_n1031RelacionamentoSacado ;
      private string[] BC000O41_A169ClienteDocumento ;
      private bool[] BC000O41_n169ClienteDocumento ;
      private int[] BC000O8_A457EspecialidadeId ;
      private bool[] BC000O8_n457EspecialidadeId ;
      private string[] BC000O4_A193TipoClienteDescricao ;
      private bool[] BC000O4_n193TipoClienteDescricao ;
      private bool[] BC000O4_A207TipoClientePortal ;
      private bool[] BC000O4_n207TipoClientePortal ;
      private bool[] BC000O4_A793TipoClientePortalPjPf ;
      private bool[] BC000O4_n793TipoClientePortalPjPf ;
      private string[] BC000O13_A490ClienteConvenioDescricao ;
      private bool[] BC000O13_n490ClienteConvenioDescricao ;
      private string[] BC000O10_A485ClienteNacionalidadeNome ;
      private bool[] BC000O10_n485ClienteNacionalidadeNome ;
      private string[] BC000O12_A488ClienteProfissaoNome ;
      private bool[] BC000O12_n488ClienteProfissaoNome ;
      private string[] BC000O5_A187MunicipioNome ;
      private bool[] BC000O5_n187MunicipioNome ;
      private string[] BC000O5_A189MunicipioUF ;
      private bool[] BC000O5_n189MunicipioUF ;
      private int[] BC000O7_A404BancoCodigo ;
      private bool[] BC000O7_n404BancoCodigo ;
      private string[] BC000O7_A403BancoNome ;
      private bool[] BC000O7_n403BancoNome ;
      private string[] BC000O9_A438ResponsavelNacionalidadeNome ;
      private bool[] BC000O9_n438ResponsavelNacionalidadeNome ;
      private string[] BC000O11_A443ResponsavelProfissaoNome ;
      private bool[] BC000O11_n443ResponsavelProfissaoNome ;
      private string[] BC000O6_A446ResponsavelMunicipioUF ;
      private bool[] BC000O6_n446ResponsavelMunicipioUF ;
      private string[] BC000O6_A445ResponsavelMunicipioNome ;
      private bool[] BC000O6_n445ResponsavelMunicipioNome ;
      private int[] BC000O42_A168ClienteId ;
      private bool[] BC000O42_n168ClienteId ;
      private int[] BC000O3_A168ClienteId ;
      private bool[] BC000O3_n168ClienteId ;
      private DateTime[] BC000O3_A175ClienteCreatedAt ;
      private bool[] BC000O3_n175ClienteCreatedAt ;
      private DateTime[] BC000O3_A176ClienteUpdatedAt ;
      private bool[] BC000O3_n176ClienteUpdatedAt ;
      private string[] BC000O3_A169ClienteDocumento ;
      private bool[] BC000O3_n169ClienteDocumento ;
      private string[] BC000O3_A170ClienteRazaoSocial ;
      private bool[] BC000O3_n170ClienteRazaoSocial ;
      private string[] BC000O3_A171ClienteNomeFantasia ;
      private bool[] BC000O3_n171ClienteNomeFantasia ;
      private DateTime[] BC000O3_A459ClienteDataNascimento ;
      private bool[] BC000O3_n459ClienteDataNascimento ;
      private string[] BC000O3_A172ClienteTipoPessoa ;
      private bool[] BC000O3_n172ClienteTipoPessoa ;
      private bool[] BC000O3_A174ClienteStatus ;
      private bool[] BC000O3_n174ClienteStatus ;
      private short[] BC000O3_A177ClienteLogUser ;
      private bool[] BC000O3_n177ClienteLogUser ;
      private string[] BC000O3_A486ClienteEstadoCivil ;
      private bool[] BC000O3_n486ClienteEstadoCivil ;
      private string[] BC000O3_A181EnderecoTipo ;
      private bool[] BC000O3_n181EnderecoTipo ;
      private string[] BC000O3_A182EnderecoCEP ;
      private bool[] BC000O3_n182EnderecoCEP ;
      private string[] BC000O3_A183EnderecoLogradouro ;
      private bool[] BC000O3_n183EnderecoLogradouro ;
      private string[] BC000O3_A184EnderecoBairro ;
      private bool[] BC000O3_n184EnderecoBairro ;
      private string[] BC000O3_A185EnderecoCidade ;
      private bool[] BC000O3_n185EnderecoCidade ;
      private string[] BC000O3_A190EnderecoNumero ;
      private bool[] BC000O3_n190EnderecoNumero ;
      private string[] BC000O3_A191EnderecoComplemento ;
      private bool[] BC000O3_n191EnderecoComplemento ;
      private string[] BC000O3_A201ContatoEmail ;
      private bool[] BC000O3_n201ContatoEmail ;
      private short[] BC000O3_A198ContatoDDD ;
      private bool[] BC000O3_n198ContatoDDD ;
      private short[] BC000O3_A199ContatoDDI ;
      private bool[] BC000O3_n199ContatoDDI ;
      private long[] BC000O3_A200ContatoNumero ;
      private bool[] BC000O3_n200ContatoNumero ;
      private long[] BC000O3_A202ContatoTelefoneNumero ;
      private bool[] BC000O3_n202ContatoTelefoneNumero ;
      private short[] BC000O3_A203ContatoTelefoneDDD ;
      private bool[] BC000O3_n203ContatoTelefoneDDD ;
      private short[] BC000O3_A204ContatoTelefoneDDI ;
      private bool[] BC000O3_n204ContatoTelefoneDDI ;
      private long[] BC000O3_A421ClienteRG ;
      private bool[] BC000O3_n421ClienteRG ;
      private string[] BC000O3_A537ClienteDepositoTipo ;
      private bool[] BC000O3_n537ClienteDepositoTipo ;
      private string[] BC000O3_A538ClientePixTipo ;
      private bool[] BC000O3_n538ClientePixTipo ;
      private string[] BC000O3_A539ClientePix ;
      private bool[] BC000O3_n539ClientePix ;
      private string[] BC000O3_A400ContaAgencia ;
      private bool[] BC000O3_n400ContaAgencia ;
      private string[] BC000O3_A401ContaNumero ;
      private bool[] BC000O3_n401ContaNumero ;
      private string[] BC000O3_A436ResponsavelNome ;
      private bool[] BC000O3_n436ResponsavelNome ;
      private string[] BC000O3_A439ResponsavelEstadoCivil ;
      private bool[] BC000O3_n439ResponsavelEstadoCivil ;
      private long[] BC000O3_A576ResponsavelRG ;
      private bool[] BC000O3_n576ResponsavelRG ;
      private string[] BC000O3_A447ResponsavelCPF ;
      private bool[] BC000O3_n447ResponsavelCPF ;
      private string[] BC000O3_A448ResponsavelCEP ;
      private bool[] BC000O3_n448ResponsavelCEP ;
      private string[] BC000O3_A449ResponsavelLogradouro ;
      private bool[] BC000O3_n449ResponsavelLogradouro ;
      private string[] BC000O3_A450ResponsavelBairro ;
      private bool[] BC000O3_n450ResponsavelBairro ;
      private string[] BC000O3_A451ResponsavelCidade ;
      private bool[] BC000O3_n451ResponsavelCidade ;
      private int[] BC000O3_A452ResponsavelLogradouroNumero ;
      private bool[] BC000O3_n452ResponsavelLogradouroNumero ;
      private string[] BC000O3_A453ResponsavelComplemento ;
      private bool[] BC000O3_n453ResponsavelComplemento ;
      private short[] BC000O3_A454ResponsavelDDD ;
      private bool[] BC000O3_n454ResponsavelDDD ;
      private int[] BC000O3_A455ResponsavelNumero ;
      private bool[] BC000O3_n455ResponsavelNumero ;
      private string[] BC000O3_A456ResponsavelEmail ;
      private bool[] BC000O3_n456ResponsavelEmail ;
      private string[] BC000O3_A884ClienteSituacao ;
      private bool[] BC000O3_n884ClienteSituacao ;
      private string[] BC000O3_A885ResponsavelCargo ;
      private bool[] BC000O3_n885ResponsavelCargo ;
      private string[] BC000O3_A1039ClienteTipoRisco ;
      private short[] BC000O3_A192TipoClienteId ;
      private bool[] BC000O3_n192TipoClienteId ;
      private string[] BC000O3_A186MunicipioCodigo ;
      private bool[] BC000O3_n186MunicipioCodigo ;
      private string[] BC000O3_A444ResponsavelMunicipio ;
      private bool[] BC000O3_n444ResponsavelMunicipio ;
      private int[] BC000O3_A402BancoId ;
      private bool[] BC000O3_n402BancoId ;
      private int[] BC000O3_A457EspecialidadeId ;
      private bool[] BC000O3_n457EspecialidadeId ;
      private int[] BC000O3_A437ResponsavelNacionalidade ;
      private bool[] BC000O3_n437ResponsavelNacionalidade ;
      private int[] BC000O3_A484ClienteNacionalidade ;
      private bool[] BC000O3_n484ClienteNacionalidade ;
      private int[] BC000O3_A442ResponsavelProfissao ;
      private bool[] BC000O3_n442ResponsavelProfissao ;
      private int[] BC000O3_A487ClienteProfissao ;
      private bool[] BC000O3_n487ClienteProfissao ;
      private int[] BC000O3_A489ClienteConvenio ;
      private bool[] BC000O3_n489ClienteConvenio ;
      private int[] BC000O2_A168ClienteId ;
      private bool[] BC000O2_n168ClienteId ;
      private DateTime[] BC000O2_A175ClienteCreatedAt ;
      private bool[] BC000O2_n175ClienteCreatedAt ;
      private DateTime[] BC000O2_A176ClienteUpdatedAt ;
      private bool[] BC000O2_n176ClienteUpdatedAt ;
      private string[] BC000O2_A169ClienteDocumento ;
      private bool[] BC000O2_n169ClienteDocumento ;
      private string[] BC000O2_A170ClienteRazaoSocial ;
      private bool[] BC000O2_n170ClienteRazaoSocial ;
      private string[] BC000O2_A171ClienteNomeFantasia ;
      private bool[] BC000O2_n171ClienteNomeFantasia ;
      private DateTime[] BC000O2_A459ClienteDataNascimento ;
      private bool[] BC000O2_n459ClienteDataNascimento ;
      private string[] BC000O2_A172ClienteTipoPessoa ;
      private bool[] BC000O2_n172ClienteTipoPessoa ;
      private bool[] BC000O2_A174ClienteStatus ;
      private bool[] BC000O2_n174ClienteStatus ;
      private short[] BC000O2_A177ClienteLogUser ;
      private bool[] BC000O2_n177ClienteLogUser ;
      private string[] BC000O2_A486ClienteEstadoCivil ;
      private bool[] BC000O2_n486ClienteEstadoCivil ;
      private string[] BC000O2_A181EnderecoTipo ;
      private bool[] BC000O2_n181EnderecoTipo ;
      private string[] BC000O2_A182EnderecoCEP ;
      private bool[] BC000O2_n182EnderecoCEP ;
      private string[] BC000O2_A183EnderecoLogradouro ;
      private bool[] BC000O2_n183EnderecoLogradouro ;
      private string[] BC000O2_A184EnderecoBairro ;
      private bool[] BC000O2_n184EnderecoBairro ;
      private string[] BC000O2_A185EnderecoCidade ;
      private bool[] BC000O2_n185EnderecoCidade ;
      private string[] BC000O2_A190EnderecoNumero ;
      private bool[] BC000O2_n190EnderecoNumero ;
      private string[] BC000O2_A191EnderecoComplemento ;
      private bool[] BC000O2_n191EnderecoComplemento ;
      private string[] BC000O2_A201ContatoEmail ;
      private bool[] BC000O2_n201ContatoEmail ;
      private short[] BC000O2_A198ContatoDDD ;
      private bool[] BC000O2_n198ContatoDDD ;
      private short[] BC000O2_A199ContatoDDI ;
      private bool[] BC000O2_n199ContatoDDI ;
      private long[] BC000O2_A200ContatoNumero ;
      private bool[] BC000O2_n200ContatoNumero ;
      private long[] BC000O2_A202ContatoTelefoneNumero ;
      private bool[] BC000O2_n202ContatoTelefoneNumero ;
      private short[] BC000O2_A203ContatoTelefoneDDD ;
      private bool[] BC000O2_n203ContatoTelefoneDDD ;
      private short[] BC000O2_A204ContatoTelefoneDDI ;
      private bool[] BC000O2_n204ContatoTelefoneDDI ;
      private long[] BC000O2_A421ClienteRG ;
      private bool[] BC000O2_n421ClienteRG ;
      private string[] BC000O2_A537ClienteDepositoTipo ;
      private bool[] BC000O2_n537ClienteDepositoTipo ;
      private string[] BC000O2_A538ClientePixTipo ;
      private bool[] BC000O2_n538ClientePixTipo ;
      private string[] BC000O2_A539ClientePix ;
      private bool[] BC000O2_n539ClientePix ;
      private string[] BC000O2_A400ContaAgencia ;
      private bool[] BC000O2_n400ContaAgencia ;
      private string[] BC000O2_A401ContaNumero ;
      private bool[] BC000O2_n401ContaNumero ;
      private string[] BC000O2_A436ResponsavelNome ;
      private bool[] BC000O2_n436ResponsavelNome ;
      private string[] BC000O2_A439ResponsavelEstadoCivil ;
      private bool[] BC000O2_n439ResponsavelEstadoCivil ;
      private long[] BC000O2_A576ResponsavelRG ;
      private bool[] BC000O2_n576ResponsavelRG ;
      private string[] BC000O2_A447ResponsavelCPF ;
      private bool[] BC000O2_n447ResponsavelCPF ;
      private string[] BC000O2_A448ResponsavelCEP ;
      private bool[] BC000O2_n448ResponsavelCEP ;
      private string[] BC000O2_A449ResponsavelLogradouro ;
      private bool[] BC000O2_n449ResponsavelLogradouro ;
      private string[] BC000O2_A450ResponsavelBairro ;
      private bool[] BC000O2_n450ResponsavelBairro ;
      private string[] BC000O2_A451ResponsavelCidade ;
      private bool[] BC000O2_n451ResponsavelCidade ;
      private int[] BC000O2_A452ResponsavelLogradouroNumero ;
      private bool[] BC000O2_n452ResponsavelLogradouroNumero ;
      private string[] BC000O2_A453ResponsavelComplemento ;
      private bool[] BC000O2_n453ResponsavelComplemento ;
      private short[] BC000O2_A454ResponsavelDDD ;
      private bool[] BC000O2_n454ResponsavelDDD ;
      private int[] BC000O2_A455ResponsavelNumero ;
      private bool[] BC000O2_n455ResponsavelNumero ;
      private string[] BC000O2_A456ResponsavelEmail ;
      private bool[] BC000O2_n456ResponsavelEmail ;
      private string[] BC000O2_A884ClienteSituacao ;
      private bool[] BC000O2_n884ClienteSituacao ;
      private string[] BC000O2_A885ResponsavelCargo ;
      private bool[] BC000O2_n885ResponsavelCargo ;
      private string[] BC000O2_A1039ClienteTipoRisco ;
      private short[] BC000O2_A192TipoClienteId ;
      private bool[] BC000O2_n192TipoClienteId ;
      private string[] BC000O2_A186MunicipioCodigo ;
      private bool[] BC000O2_n186MunicipioCodigo ;
      private string[] BC000O2_A444ResponsavelMunicipio ;
      private bool[] BC000O2_n444ResponsavelMunicipio ;
      private int[] BC000O2_A402BancoId ;
      private bool[] BC000O2_n402BancoId ;
      private int[] BC000O2_A457EspecialidadeId ;
      private bool[] BC000O2_n457EspecialidadeId ;
      private int[] BC000O2_A437ResponsavelNacionalidade ;
      private bool[] BC000O2_n437ResponsavelNacionalidade ;
      private int[] BC000O2_A484ClienteNacionalidade ;
      private bool[] BC000O2_n484ClienteNacionalidade ;
      private int[] BC000O2_A442ResponsavelProfissao ;
      private bool[] BC000O2_n442ResponsavelProfissao ;
      private int[] BC000O2_A487ClienteProfissao ;
      private bool[] BC000O2_n487ClienteProfissao ;
      private int[] BC000O2_A489ClienteConvenio ;
      private bool[] BC000O2_n489ClienteConvenio ;
      private int[] BC000O44_A168ClienteId ;
      private bool[] BC000O44_n168ClienteId ;
      private short[] BC000O48_A608SecUserId_F ;
      private bool[] BC000O48_n608SecUserId_F ;
      private int[] BC000O50_A309ClienteQtdTitulos_F ;
      private bool[] BC000O50_n309ClienteQtdTitulos_F ;
      private decimal[] BC000O54_A310ClienteValorAPagar_F ;
      private bool[] BC000O54_n310ClienteValorAPagar_F ;
      private decimal[] BC000O57_A311ClienteValorAReceber_F ;
      private bool[] BC000O57_n311ClienteValorAReceber_F ;
      private DateTime[] BC000O59_A780SerasaUltimaData_F ;
      private short[] BC000O59_A732SerasaConsultas_F ;
      private short[] BC000O61_A781SerasaScoreUltimaData_F ;
      private decimal[] BC000O61_A785SerasaUltimoValorRecomendado_F ;
      private short[] BC000O63_A1031RelacionamentoSacado ;
      private bool[] BC000O63_n1031RelacionamentoSacado ;
      private string[] BC000O64_A193TipoClienteDescricao ;
      private bool[] BC000O64_n193TipoClienteDescricao ;
      private bool[] BC000O64_A207TipoClientePortal ;
      private bool[] BC000O64_n207TipoClientePortal ;
      private bool[] BC000O64_A793TipoClientePortalPjPf ;
      private bool[] BC000O64_n793TipoClientePortalPjPf ;
      private string[] BC000O65_A490ClienteConvenioDescricao ;
      private bool[] BC000O65_n490ClienteConvenioDescricao ;
      private string[] BC000O66_A485ClienteNacionalidadeNome ;
      private bool[] BC000O66_n485ClienteNacionalidadeNome ;
      private string[] BC000O67_A488ClienteProfissaoNome ;
      private bool[] BC000O67_n488ClienteProfissaoNome ;
      private string[] BC000O68_A187MunicipioNome ;
      private bool[] BC000O68_n187MunicipioNome ;
      private string[] BC000O68_A189MunicipioUF ;
      private bool[] BC000O68_n189MunicipioUF ;
      private int[] BC000O69_A404BancoCodigo ;
      private bool[] BC000O69_n404BancoCodigo ;
      private string[] BC000O69_A403BancoNome ;
      private bool[] BC000O69_n403BancoNome ;
      private string[] BC000O70_A438ResponsavelNacionalidadeNome ;
      private bool[] BC000O70_n438ResponsavelNacionalidadeNome ;
      private string[] BC000O71_A443ResponsavelProfissaoNome ;
      private bool[] BC000O71_n443ResponsavelProfissaoNome ;
      private string[] BC000O72_A446ResponsavelMunicipioUF ;
      private bool[] BC000O72_n446ResponsavelMunicipioUF ;
      private string[] BC000O72_A445ResponsavelMunicipioNome ;
      private bool[] BC000O72_n445ResponsavelMunicipioNome ;
      private int[] BC000O73_A1019OperacoesTitulosId ;
      private int[] BC000O74_A323PropostaId ;
      private int[] BC000O75_A323PropostaId ;
      private int[] BC000O76_A323PropostaId ;
      private int[] BC000O77_A323PropostaId ;
      private int[] BC000O78_A227ContratoId ;
      private int[] BC000O79_A261TituloId ;
      private bool[] BC000O79_n261TituloId ;
      private short[] BC000O80_A133SecUserId ;
      private int[] BC000O81_A1032RelacionamentoId ;
      private int[] BC000O82_A1010OperacoesId ;
      private int[] BC000O83_A978RepresentanteId ;
      private int[] BC000O84_A856CreditoId ;
      private Guid[] BC000O85_A794NotaFiscalId ;
      private bool[] BC000O85_n794NotaFiscalId ;
      private Guid[] BC000O86_A794NotaFiscalId ;
      private bool[] BC000O86_n794NotaFiscalId ;
      private int[] BC000O87_A662SerasaId ;
      private int[] BC000O88_A599ClienteDocumentoId ;
      private int[] BC000O89_A551ClienteReponsavelId ;
      private int[] BC000O90_A551ClienteReponsavelId ;
      private int[] BC000O91_A242AssinaturaParticipanteId ;
      private int[] BC000O92_A223FinanciamentoId ;
      private int[] BC000O93_A223FinanciamentoId ;
      private int[] BC000O103_A168ClienteId ;
      private bool[] BC000O103_n168ClienteId ;
      private DateTime[] BC000O103_A175ClienteCreatedAt ;
      private bool[] BC000O103_n175ClienteCreatedAt ;
      private DateTime[] BC000O103_A176ClienteUpdatedAt ;
      private bool[] BC000O103_n176ClienteUpdatedAt ;
      private string[] BC000O103_A169ClienteDocumento ;
      private bool[] BC000O103_n169ClienteDocumento ;
      private string[] BC000O103_A170ClienteRazaoSocial ;
      private bool[] BC000O103_n170ClienteRazaoSocial ;
      private string[] BC000O103_A171ClienteNomeFantasia ;
      private bool[] BC000O103_n171ClienteNomeFantasia ;
      private DateTime[] BC000O103_A459ClienteDataNascimento ;
      private bool[] BC000O103_n459ClienteDataNascimento ;
      private string[] BC000O103_A172ClienteTipoPessoa ;
      private bool[] BC000O103_n172ClienteTipoPessoa ;
      private string[] BC000O103_A193TipoClienteDescricao ;
      private bool[] BC000O103_n193TipoClienteDescricao ;
      private bool[] BC000O103_A207TipoClientePortal ;
      private bool[] BC000O103_n207TipoClientePortal ;
      private bool[] BC000O103_A174ClienteStatus ;
      private bool[] BC000O103_n174ClienteStatus ;
      private string[] BC000O103_A490ClienteConvenioDescricao ;
      private bool[] BC000O103_n490ClienteConvenioDescricao ;
      private short[] BC000O103_A177ClienteLogUser ;
      private bool[] BC000O103_n177ClienteLogUser ;
      private string[] BC000O103_A485ClienteNacionalidadeNome ;
      private bool[] BC000O103_n485ClienteNacionalidadeNome ;
      private string[] BC000O103_A488ClienteProfissaoNome ;
      private bool[] BC000O103_n488ClienteProfissaoNome ;
      private string[] BC000O103_A486ClienteEstadoCivil ;
      private bool[] BC000O103_n486ClienteEstadoCivil ;
      private string[] BC000O103_A181EnderecoTipo ;
      private bool[] BC000O103_n181EnderecoTipo ;
      private string[] BC000O103_A182EnderecoCEP ;
      private bool[] BC000O103_n182EnderecoCEP ;
      private string[] BC000O103_A183EnderecoLogradouro ;
      private bool[] BC000O103_n183EnderecoLogradouro ;
      private string[] BC000O103_A184EnderecoBairro ;
      private bool[] BC000O103_n184EnderecoBairro ;
      private string[] BC000O103_A185EnderecoCidade ;
      private bool[] BC000O103_n185EnderecoCidade ;
      private string[] BC000O103_A187MunicipioNome ;
      private bool[] BC000O103_n187MunicipioNome ;
      private string[] BC000O103_A189MunicipioUF ;
      private bool[] BC000O103_n189MunicipioUF ;
      private string[] BC000O103_A190EnderecoNumero ;
      private bool[] BC000O103_n190EnderecoNumero ;
      private string[] BC000O103_A191EnderecoComplemento ;
      private bool[] BC000O103_n191EnderecoComplemento ;
      private string[] BC000O103_A201ContatoEmail ;
      private bool[] BC000O103_n201ContatoEmail ;
      private short[] BC000O103_A198ContatoDDD ;
      private bool[] BC000O103_n198ContatoDDD ;
      private short[] BC000O103_A199ContatoDDI ;
      private bool[] BC000O103_n199ContatoDDI ;
      private long[] BC000O103_A200ContatoNumero ;
      private bool[] BC000O103_n200ContatoNumero ;
      private long[] BC000O103_A202ContatoTelefoneNumero ;
      private bool[] BC000O103_n202ContatoTelefoneNumero ;
      private short[] BC000O103_A203ContatoTelefoneDDD ;
      private bool[] BC000O103_n203ContatoTelefoneDDD ;
      private short[] BC000O103_A204ContatoTelefoneDDI ;
      private bool[] BC000O103_n204ContatoTelefoneDDI ;
      private long[] BC000O103_A421ClienteRG ;
      private bool[] BC000O103_n421ClienteRG ;
      private string[] BC000O103_A537ClienteDepositoTipo ;
      private bool[] BC000O103_n537ClienteDepositoTipo ;
      private string[] BC000O103_A538ClientePixTipo ;
      private bool[] BC000O103_n538ClientePixTipo ;
      private string[] BC000O103_A539ClientePix ;
      private bool[] BC000O103_n539ClientePix ;
      private int[] BC000O103_A404BancoCodigo ;
      private bool[] BC000O103_n404BancoCodigo ;
      private string[] BC000O103_A403BancoNome ;
      private bool[] BC000O103_n403BancoNome ;
      private string[] BC000O103_A400ContaAgencia ;
      private bool[] BC000O103_n400ContaAgencia ;
      private string[] BC000O103_A401ContaNumero ;
      private bool[] BC000O103_n401ContaNumero ;
      private string[] BC000O103_A436ResponsavelNome ;
      private bool[] BC000O103_n436ResponsavelNome ;
      private string[] BC000O103_A438ResponsavelNacionalidadeNome ;
      private bool[] BC000O103_n438ResponsavelNacionalidadeNome ;
      private string[] BC000O103_A439ResponsavelEstadoCivil ;
      private bool[] BC000O103_n439ResponsavelEstadoCivil ;
      private long[] BC000O103_A576ResponsavelRG ;
      private bool[] BC000O103_n576ResponsavelRG ;
      private string[] BC000O103_A443ResponsavelProfissaoNome ;
      private bool[] BC000O103_n443ResponsavelProfissaoNome ;
      private string[] BC000O103_A447ResponsavelCPF ;
      private bool[] BC000O103_n447ResponsavelCPF ;
      private string[] BC000O103_A448ResponsavelCEP ;
      private bool[] BC000O103_n448ResponsavelCEP ;
      private string[] BC000O103_A449ResponsavelLogradouro ;
      private bool[] BC000O103_n449ResponsavelLogradouro ;
      private string[] BC000O103_A450ResponsavelBairro ;
      private bool[] BC000O103_n450ResponsavelBairro ;
      private string[] BC000O103_A451ResponsavelCidade ;
      private bool[] BC000O103_n451ResponsavelCidade ;
      private string[] BC000O103_A446ResponsavelMunicipioUF ;
      private bool[] BC000O103_n446ResponsavelMunicipioUF ;
      private string[] BC000O103_A445ResponsavelMunicipioNome ;
      private bool[] BC000O103_n445ResponsavelMunicipioNome ;
      private int[] BC000O103_A452ResponsavelLogradouroNumero ;
      private bool[] BC000O103_n452ResponsavelLogradouroNumero ;
      private string[] BC000O103_A453ResponsavelComplemento ;
      private bool[] BC000O103_n453ResponsavelComplemento ;
      private short[] BC000O103_A454ResponsavelDDD ;
      private bool[] BC000O103_n454ResponsavelDDD ;
      private int[] BC000O103_A455ResponsavelNumero ;
      private bool[] BC000O103_n455ResponsavelNumero ;
      private string[] BC000O103_A456ResponsavelEmail ;
      private bool[] BC000O103_n456ResponsavelEmail ;
      private string[] BC000O103_A884ClienteSituacao ;
      private bool[] BC000O103_n884ClienteSituacao ;
      private string[] BC000O103_A885ResponsavelCargo ;
      private bool[] BC000O103_n885ResponsavelCargo ;
      private bool[] BC000O103_A793TipoClientePortalPjPf ;
      private bool[] BC000O103_n793TipoClientePortalPjPf ;
      private string[] BC000O103_A1039ClienteTipoRisco ;
      private short[] BC000O103_A192TipoClienteId ;
      private bool[] BC000O103_n192TipoClienteId ;
      private string[] BC000O103_A186MunicipioCodigo ;
      private bool[] BC000O103_n186MunicipioCodigo ;
      private string[] BC000O103_A444ResponsavelMunicipio ;
      private bool[] BC000O103_n444ResponsavelMunicipio ;
      private int[] BC000O103_A402BancoId ;
      private bool[] BC000O103_n402BancoId ;
      private int[] BC000O103_A457EspecialidadeId ;
      private bool[] BC000O103_n457EspecialidadeId ;
      private int[] BC000O103_A437ResponsavelNacionalidade ;
      private bool[] BC000O103_n437ResponsavelNacionalidade ;
      private int[] BC000O103_A484ClienteNacionalidade ;
      private bool[] BC000O103_n484ClienteNacionalidade ;
      private int[] BC000O103_A442ResponsavelProfissao ;
      private bool[] BC000O103_n442ResponsavelProfissao ;
      private int[] BC000O103_A487ClienteProfissao ;
      private bool[] BC000O103_n487ClienteProfissao ;
      private int[] BC000O103_A489ClienteConvenio ;
      private bool[] BC000O103_n489ClienteConvenio ;
      private DateTime[] BC000O103_A780SerasaUltimaData_F ;
      private short[] BC000O103_A608SecUserId_F ;
      private bool[] BC000O103_n608SecUserId_F ;
      private int[] BC000O103_A309ClienteQtdTitulos_F ;
      private bool[] BC000O103_n309ClienteQtdTitulos_F ;
      private decimal[] BC000O103_A310ClienteValorAPagar_F ;
      private bool[] BC000O103_n310ClienteValorAPagar_F ;
      private decimal[] BC000O103_A311ClienteValorAReceber_F ;
      private bool[] BC000O103_n311ClienteValorAReceber_F ;
      private short[] BC000O103_A732SerasaConsultas_F ;
      private short[] BC000O103_A1031RelacionamentoSacado ;
      private bool[] BC000O103_n1031RelacionamentoSacado ;
      private SdtCliente bcCliente ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class cliente_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
         ,new ForEachCursor(def[47])
         ,new ForEachCursor(def[48])
         ,new ForEachCursor(def[49])
         ,new ForEachCursor(def[50])
         ,new ForEachCursor(def[51])
         ,new ForEachCursor(def[52])
         ,new ForEachCursor(def[53])
         ,new ForEachCursor(def[54])
         ,new ForEachCursor(def[55])
         ,new ForEachCursor(def[56])
         ,new ForEachCursor(def[57])
         ,new ForEachCursor(def[58])
         ,new ForEachCursor(def[59])
         ,new ForEachCursor(def[60])
         ,new ForEachCursor(def[61])
         ,new ForEachCursor(def[62])
         ,new ForEachCursor(def[63])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000O2;
          prmBC000O2 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O3;
          prmBC000O3 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O4;
          prmBC000O4 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000O5;
          prmBC000O5 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000O6;
          prmBC000O6 = new Object[] {
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000O7;
          prmBC000O7 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O8;
          prmBC000O8 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O9;
          prmBC000O9 = new Object[] {
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O10;
          prmBC000O10 = new Object[] {
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O11;
          prmBC000O11 = new Object[] {
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O12;
          prmBC000O12 = new Object[] {
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O13;
          prmBC000O13 = new Object[] {
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O19;
          prmBC000O19 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O23;
          prmBC000O23 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O26;
          prmBC000O26 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O28;
          prmBC000O28 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O30;
          prmBC000O30 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O40;
          prmBC000O40 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC000O40;
          cmdBufferBC000O40=" SELECT TM1.ClienteId, TM1.ClienteCreatedAt, TM1.ClienteUpdatedAt, TM1.ClienteDocumento, TM1.ClienteRazaoSocial, TM1.ClienteNomeFantasia, TM1.ClienteDataNascimento, TM1.ClienteTipoPessoa, T8.TipoClienteDescricao, T8.TipoClientePortal, TM1.ClienteStatus, T9.ConvenioDescricao AS ClienteConvenioDescricao, TM1.ClienteLogUser, T10.NacionalidadeNome AS ClienteNacionalidadeNome, T11.ProfissaoNome AS ClienteProfissaoNome, TM1.ClienteEstadoCivil, TM1.EnderecoTipo, TM1.EnderecoCEP, TM1.EnderecoLogradouro, TM1.EnderecoBairro, TM1.EnderecoCidade, T12.MunicipioNome, T12.MunicipioUF, TM1.EnderecoNumero, TM1.EnderecoComplemento, TM1.ContatoEmail, TM1.ContatoDDD, TM1.ContatoDDI, TM1.ContatoNumero, TM1.ContatoTelefoneNumero, TM1.ContatoTelefoneDDD, TM1.ContatoTelefoneDDI, TM1.ClienteRG, TM1.ClienteDepositoTipo, TM1.ClientePixTipo, TM1.ClientePix, T13.BancoCodigo, T13.BancoNome, TM1.ContaAgencia, TM1.ContaNumero, TM1.ResponsavelNome, T14.NacionalidadeNome AS ResponsavelNacionalidadeNome, TM1.ResponsavelEstadoCivil, TM1.ResponsavelRG, T15.ProfissaoNome AS ResponsavelProfissaoNome, TM1.ResponsavelCPF, TM1.ResponsavelCEP, TM1.ResponsavelLogradouro, TM1.ResponsavelBairro, TM1.ResponsavelCidade, T16.MunicipioUF AS ResponsavelMunicipioUF, T16.MunicipioNome AS ResponsavelMunicipioNome, TM1.ResponsavelLogradouroNumero, TM1.ResponsavelComplemento, TM1.ResponsavelDDD, TM1.ResponsavelNumero, TM1.ResponsavelEmail, TM1.ClienteSituacao, TM1.ResponsavelCargo, T8.TipoClientePortalPjPf, TM1.ClienteTipoRisco, TM1.TipoClienteId, TM1.MunicipioCodigo, TM1.ResponsavelMunicipio AS ResponsavelMunicipio, TM1.BancoId, TM1.EspecialidadeId, TM1.ResponsavelNacionalidade AS ResponsavelNacionalidade, TM1.ClienteNacionalidade AS ClienteNacionalidade, TM1.ResponsavelProfissao AS ResponsavelProfissao, TM1.ClienteProfissao "
          + " AS ClienteProfissao, TM1.ClienteConvenio AS ClienteConvenio, COALESCE( T6.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T2.SecUserId_F, 0) AS SecUserId_F, COALESCE( T3.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F, COALESCE( T4.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T5.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T6.SerasaConsultas_F, 0) AS SerasaConsultas_F, COALESCE( T7.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (((((((((((((((Cliente TM1 LEFT JOIN LATERAL (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE (TM1.ClienteId = SecUserOwnerId) AND (SecUserOwnerId = :ClienteId) GROUP BY SecUserOwnerId ) T2 ON T2.SecUserOwnerId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T19.ClienteId FROM ((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) WHERE (TM1.ClienteId = T19.ClienteId) AND (Not T17.TituloDeleted) GROUP BY T19.ClienteId ) T3 ON T3.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T20.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T21.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T21.TituloValor, 0) - COALESCE( T21.TituloDesconto, 0)) - COALESCE( T22.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T21.TituloId FROM (Titulo T21 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T21.TituloId"
          + " = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T22 ON T22.TituloId = T21.TituloId) ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T4 ON T4.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T17.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T17.TituloValor, 0) - COALESCE( T17.TituloDesconto, 0)) - COALESCE( T20.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T17.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T5 ON T5.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T6 ON T6.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (TM1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T7 ON T7.ClienteId = TM1.ClienteId) LEFT JOIN TipoCliente T8 ON T8.TipoClienteId = TM1.TipoClienteId) LEFT JOIN Convenio T9 ON T9.ConvenioId = TM1.ClienteConvenio) LEFT JOIN Nacionalidade T10 ON T10.NacionalidadeId = TM1.ClienteNacionalidade) LEFT JOIN Profissao T11 ON T11.ProfissaoId = TM1.ClienteProfissao) LEFT JOIN Municipio T12 ON T12.MunicipioCodigo = TM1.MunicipioCodigo) LEFT JOIN Banco T13 ON T13.BancoId"
          + " = TM1.BancoId) LEFT JOIN Nacionalidade T14 ON T14.NacionalidadeId = TM1.ResponsavelNacionalidade) LEFT JOIN Profissao T15 ON T15.ProfissaoId = TM1.ResponsavelProfissao) LEFT JOIN Municipio T16 ON T16.MunicipioCodigo = TM1.ResponsavelMunicipio) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId" ;
          Object[] prmBC000O15;
          prmBC000O15 = new Object[] {
          new ParDef("SerasaUltimaData_F",GXType.DateTime,8,5) ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O17;
          prmBC000O17 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O41;
          prmBC000O41 = new Object[] {
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O42;
          prmBC000O42 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O43;
          prmBC000O43 = new Object[] {
          new ParDef("ClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ClienteLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoCEP",GXType.VarChar,8,0){Nullable=true} ,
          new ParDef("EnderecoLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoCidade",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoNumero",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("EnderecoComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContatoEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ContatoDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ClienteDepositoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePix",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("ContaAgencia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ContaNumero",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ResponsavelNome",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ResponsavelEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ResponsavelCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ResponsavelCEP",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouroNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ResponsavelNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteSituacao",GXType.Char,1,0){Nullable=true} ,
          new ParDef("ResponsavelCargo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTipoRisco",GXType.VarChar,40,0) ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC000O43;
          cmdBufferBC000O43=" SAVEPOINT gxupdate;INSERT INTO Cliente(ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio) VALUES(:ClienteCreatedAt, :ClienteUpdatedAt, :ClienteDocumento, :ClienteRazaoSocial, :ClienteNomeFantasia, :ClienteDataNascimento, :ClienteTipoPessoa, :ClienteStatus, :ClienteLogUser, :ClienteEstadoCivil, :EnderecoTipo, :EnderecoCEP, :EnderecoLogradouro, :EnderecoBairro, :EnderecoCidade, :EnderecoNumero, :EnderecoComplemento, :ContatoEmail, :ContatoDDD, :ContatoDDI, :ContatoNumero, :ContatoTelefoneNumero, :ContatoTelefoneDDD, :ContatoTelefoneDDI, :ClienteRG, :ClienteDepositoTipo, :ClientePixTipo, :ClientePix, :ContaAgencia, :ContaNumero, :ResponsavelNome, :ResponsavelEstadoCivil, :ResponsavelRG, :ResponsavelCPF, :ResponsavelCEP, :ResponsavelLogradouro, :ResponsavelBairro, :ResponsavelCidade, :ResponsavelLogradouroNumero, :ResponsavelComplemento, :ResponsavelDDD, "
          + " :ResponsavelNumero, :ResponsavelEmail, :ClienteSituacao, :ResponsavelCargo, :ClienteTipoRisco, :TipoClienteId, :MunicipioCodigo, :ResponsavelMunicipio, :BancoId, :EspecialidadeId, :ResponsavelNacionalidade, :ClienteNacionalidade, :ResponsavelProfissao, :ClienteProfissao, :ClienteConvenio);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC000O44;
          prmBC000O44 = new Object[] {
          };
          Object[] prmBC000O45;
          prmBC000O45 = new Object[] {
          new ParDef("ClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ClienteLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoCEP",GXType.VarChar,8,0){Nullable=true} ,
          new ParDef("EnderecoLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoCidade",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoNumero",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("EnderecoComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContatoEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ContatoDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ClienteDepositoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePix",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("ContaAgencia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ContaNumero",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ResponsavelNome",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ResponsavelEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ResponsavelCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ResponsavelCEP",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouroNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ResponsavelNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteSituacao",GXType.Char,1,0){Nullable=true} ,
          new ParDef("ResponsavelCargo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTipoRisco",GXType.VarChar,40,0) ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC000O45;
          cmdBufferBC000O45=" SAVEPOINT gxupdate;UPDATE Cliente SET ClienteCreatedAt=:ClienteCreatedAt, ClienteUpdatedAt=:ClienteUpdatedAt, ClienteDocumento=:ClienteDocumento, ClienteRazaoSocial=:ClienteRazaoSocial, ClienteNomeFantasia=:ClienteNomeFantasia, ClienteDataNascimento=:ClienteDataNascimento, ClienteTipoPessoa=:ClienteTipoPessoa, ClienteStatus=:ClienteStatus, ClienteLogUser=:ClienteLogUser, ClienteEstadoCivil=:ClienteEstadoCivil, EnderecoTipo=:EnderecoTipo, EnderecoCEP=:EnderecoCEP, EnderecoLogradouro=:EnderecoLogradouro, EnderecoBairro=:EnderecoBairro, EnderecoCidade=:EnderecoCidade, EnderecoNumero=:EnderecoNumero, EnderecoComplemento=:EnderecoComplemento, ContatoEmail=:ContatoEmail, ContatoDDD=:ContatoDDD, ContatoDDI=:ContatoDDI, ContatoNumero=:ContatoNumero, ContatoTelefoneNumero=:ContatoTelefoneNumero, ContatoTelefoneDDD=:ContatoTelefoneDDD, ContatoTelefoneDDI=:ContatoTelefoneDDI, ClienteRG=:ClienteRG, ClienteDepositoTipo=:ClienteDepositoTipo, ClientePixTipo=:ClientePixTipo, ClientePix=:ClientePix, ContaAgencia=:ContaAgencia, ContaNumero=:ContaNumero, ResponsavelNome=:ResponsavelNome, ResponsavelEstadoCivil=:ResponsavelEstadoCivil, ResponsavelRG=:ResponsavelRG, ResponsavelCPF=:ResponsavelCPF, ResponsavelCEP=:ResponsavelCEP, ResponsavelLogradouro=:ResponsavelLogradouro, ResponsavelBairro=:ResponsavelBairro, ResponsavelCidade=:ResponsavelCidade, ResponsavelLogradouroNumero=:ResponsavelLogradouroNumero, ResponsavelComplemento=:ResponsavelComplemento, ResponsavelDDD=:ResponsavelDDD, ResponsavelNumero=:ResponsavelNumero, ResponsavelEmail=:ResponsavelEmail, ClienteSituacao=:ClienteSituacao, ResponsavelCargo=:ResponsavelCargo, ClienteTipoRisco=:ClienteTipoRisco, TipoClienteId=:TipoClienteId, MunicipioCodigo=:MunicipioCodigo, ResponsavelMunicipio=:ResponsavelMunicipio, BancoId=:BancoId, EspecialidadeId=:EspecialidadeId, "
          + " ResponsavelNacionalidade=:ResponsavelNacionalidade, ClienteNacionalidade=:ClienteNacionalidade, ResponsavelProfissao=:ResponsavelProfissao, ClienteProfissao=:ClienteProfissao, ClienteConvenio=:ClienteConvenio  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC000O46;
          prmBC000O46 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O48;
          prmBC000O48 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O50;
          prmBC000O50 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O54;
          prmBC000O54 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O57;
          prmBC000O57 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O59;
          prmBC000O59 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O61;
          prmBC000O61 = new Object[] {
          new ParDef("SerasaUltimaData_F",GXType.DateTime,8,5) ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O63;
          prmBC000O63 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O64;
          prmBC000O64 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000O65;
          prmBC000O65 = new Object[] {
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O66;
          prmBC000O66 = new Object[] {
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O67;
          prmBC000O67 = new Object[] {
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O68;
          prmBC000O68 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000O69;
          prmBC000O69 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O70;
          prmBC000O70 = new Object[] {
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O71;
          prmBC000O71 = new Object[] {
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O72;
          prmBC000O72 = new Object[] {
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000O73;
          prmBC000O73 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O74;
          prmBC000O74 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O75;
          prmBC000O75 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O76;
          prmBC000O76 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O77;
          prmBC000O77 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O78;
          prmBC000O78 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O79;
          prmBC000O79 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O80;
          prmBC000O80 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O81;
          prmBC000O81 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O82;
          prmBC000O82 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O83;
          prmBC000O83 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O84;
          prmBC000O84 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O85;
          prmBC000O85 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O86;
          prmBC000O86 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O87;
          prmBC000O87 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O88;
          prmBC000O88 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O89;
          prmBC000O89 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O90;
          prmBC000O90 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O91;
          prmBC000O91 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O92;
          prmBC000O92 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O93;
          prmBC000O93 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000O103;
          prmBC000O103 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC000O103;
          cmdBufferBC000O103=" SELECT TM1.ClienteId, TM1.ClienteCreatedAt, TM1.ClienteUpdatedAt, TM1.ClienteDocumento, TM1.ClienteRazaoSocial, TM1.ClienteNomeFantasia, TM1.ClienteDataNascimento, TM1.ClienteTipoPessoa, T8.TipoClienteDescricao, T8.TipoClientePortal, TM1.ClienteStatus, T9.ConvenioDescricao AS ClienteConvenioDescricao, TM1.ClienteLogUser, T10.NacionalidadeNome AS ClienteNacionalidadeNome, T11.ProfissaoNome AS ClienteProfissaoNome, TM1.ClienteEstadoCivil, TM1.EnderecoTipo, TM1.EnderecoCEP, TM1.EnderecoLogradouro, TM1.EnderecoBairro, TM1.EnderecoCidade, T12.MunicipioNome, T12.MunicipioUF, TM1.EnderecoNumero, TM1.EnderecoComplemento, TM1.ContatoEmail, TM1.ContatoDDD, TM1.ContatoDDI, TM1.ContatoNumero, TM1.ContatoTelefoneNumero, TM1.ContatoTelefoneDDD, TM1.ContatoTelefoneDDI, TM1.ClienteRG, TM1.ClienteDepositoTipo, TM1.ClientePixTipo, TM1.ClientePix, T13.BancoCodigo, T13.BancoNome, TM1.ContaAgencia, TM1.ContaNumero, TM1.ResponsavelNome, T14.NacionalidadeNome AS ResponsavelNacionalidadeNome, TM1.ResponsavelEstadoCivil, TM1.ResponsavelRG, T15.ProfissaoNome AS ResponsavelProfissaoNome, TM1.ResponsavelCPF, TM1.ResponsavelCEP, TM1.ResponsavelLogradouro, TM1.ResponsavelBairro, TM1.ResponsavelCidade, T16.MunicipioUF AS ResponsavelMunicipioUF, T16.MunicipioNome AS ResponsavelMunicipioNome, TM1.ResponsavelLogradouroNumero, TM1.ResponsavelComplemento, TM1.ResponsavelDDD, TM1.ResponsavelNumero, TM1.ResponsavelEmail, TM1.ClienteSituacao, TM1.ResponsavelCargo, T8.TipoClientePortalPjPf, TM1.ClienteTipoRisco, TM1.TipoClienteId, TM1.MunicipioCodigo, TM1.ResponsavelMunicipio AS ResponsavelMunicipio, TM1.BancoId, TM1.EspecialidadeId, TM1.ResponsavelNacionalidade AS ResponsavelNacionalidade, TM1.ClienteNacionalidade AS ClienteNacionalidade, TM1.ResponsavelProfissao AS ResponsavelProfissao, TM1.ClienteProfissao "
          + " AS ClienteProfissao, TM1.ClienteConvenio AS ClienteConvenio, COALESCE( T6.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T2.SecUserId_F, 0) AS SecUserId_F, COALESCE( T3.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F, COALESCE( T4.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T5.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T6.SerasaConsultas_F, 0) AS SerasaConsultas_F, COALESCE( T7.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (((((((((((((((Cliente TM1 LEFT JOIN LATERAL (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE (TM1.ClienteId = SecUserOwnerId) AND (SecUserOwnerId = :ClienteId) GROUP BY SecUserOwnerId ) T2 ON T2.SecUserOwnerId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T19.ClienteId FROM ((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) WHERE (TM1.ClienteId = T19.ClienteId) AND (Not T17.TituloDeleted) GROUP BY T19.ClienteId ) T3 ON T3.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T20.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T21.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T21.TituloValor, 0) - COALESCE( T21.TituloDesconto, 0)) - COALESCE( T22.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T21.TituloId FROM (Titulo T21 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T21.TituloId"
          + " = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T22 ON T22.TituloId = T21.TituloId) ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T4 ON T4.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T17.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T17.TituloValor, 0) - COALESCE( T17.TituloDesconto, 0)) - COALESCE( T20.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T17.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T5 ON T5.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T6 ON T6.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (TM1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T7 ON T7.ClienteId = TM1.ClienteId) LEFT JOIN TipoCliente T8 ON T8.TipoClienteId = TM1.TipoClienteId) LEFT JOIN Convenio T9 ON T9.ConvenioId = TM1.ClienteConvenio) LEFT JOIN Nacionalidade T10 ON T10.NacionalidadeId = TM1.ClienteNacionalidade) LEFT JOIN Profissao T11 ON T11.ProfissaoId = TM1.ClienteProfissao) LEFT JOIN Municipio T12 ON T12.MunicipioCodigo = TM1.MunicipioCodigo) LEFT JOIN Banco T13 ON T13.BancoId"
          + " = TM1.BancoId) LEFT JOIN Nacionalidade T14 ON T14.NacionalidadeId = TM1.ResponsavelNacionalidade) LEFT JOIN Profissao T15 ON T15.ProfissaoId = TM1.ResponsavelProfissao) LEFT JOIN Municipio T16 ON T16.MunicipioCodigo = TM1.ResponsavelMunicipio) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId" ;
          def= new CursorDef[] {
              new CursorDef("BC000O2", "SELECT ClienteId, ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio FROM Cliente WHERE ClienteId = :ClienteId  FOR UPDATE OF Cliente",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O3", "SELECT ClienteId, ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O4", "SELECT TipoClienteDescricao, TipoClientePortal, TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O5", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O6", "SELECT MunicipioUF AS ResponsavelMunicipioUF, MunicipioNome AS ResponsavelMunicipioNome FROM Municipio WHERE MunicipioCodigo = :ResponsavelMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O7", "SELECT BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O8", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O9", "SELECT NacionalidadeNome AS ResponsavelNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ResponsavelNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O10", "SELECT NacionalidadeNome AS ClienteNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ClienteNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O11", "SELECT ProfissaoNome AS ResponsavelProfissaoNome FROM Profissao WHERE ProfissaoId = :ResponsavelProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O12", "SELECT ProfissaoNome AS ClienteProfissaoNome FROM Profissao WHERE ProfissaoId = :ClienteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O13", "SELECT ConvenioDescricao AS ClienteConvenioDescricao FROM Convenio WHERE ConvenioId = :ClienteConvenio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O15", "SELECT COALESCE( T1.SerasaScoreUltimaData_F, 0) AS SerasaScoreUltimaData_F, COALESCE( T1.SerasaUltimoValorRecomendado_F, 0) AS SerasaUltimoValorRecomendado_F FROM (SELECT MAX(SerasaScore) AS SerasaScoreUltimaData_F, ClienteId, MAX(SerasaValorLimiteRecomendado) AS SerasaUltimoValorRecomendado_F FROM Serasa WHERE SerasaCreatedAt = :SerasaUltimaData_F GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O17", "SELECT COALESCE( T1.SecUserId_F, 0) AS SecUserId_F FROM (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE SecUserOwnerId = :ClienteId GROUP BY SecUserOwnerId ) T1 WHERE T1.SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O19", "SELECT COALESCE( T1.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM (SELECT COUNT(*) AS ClienteQtdTitulos_F, T4.ClienteId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE Not T2.TituloDeleted GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O23", "SELECT COALESCE( T1.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F FROM (SELECT SUM(COALESCE( T5.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O26", "SELECT COALESCE( T1.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F FROM (SELECT SUM(CASE  WHEN COALESCE( T2.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T2.TituloValor, 0) - COALESCE( T2.TituloDesconto, 0)) - COALESCE( T5.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O28", "SELECT COALESCE( T1.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T1.SerasaConsultas_F, 0) AS SerasaConsultas_F FROM (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O30", "SELECT COALESCE( T1.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE RelacionamentoTipo = ( 'Sacado') GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O40", cmdBufferBC000O40,true, GxErrorMask.GX_NOMASK, false, this,prmBC000O40,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O41", "SELECT ClienteDocumento FROM Cliente WHERE (ClienteDocumento = :ClienteDocumento) AND (Not ( ClienteId = :ClienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O42", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O42,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O43", cmdBufferBC000O43, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000O43)
             ,new CursorDef("BC000O44", "SELECT currval('ClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O44,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O45", cmdBufferBC000O45, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000O45)
             ,new CursorDef("BC000O46", "SAVEPOINT gxupdate;DELETE FROM Cliente  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000O46)
             ,new CursorDef("BC000O48", "SELECT COALESCE( T1.SecUserId_F, 0) AS SecUserId_F FROM (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE SecUserOwnerId = :ClienteId GROUP BY SecUserOwnerId ) T1 WHERE T1.SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O48,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O50", "SELECT COALESCE( T1.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM (SELECT COUNT(*) AS ClienteQtdTitulos_F, T4.ClienteId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE Not T2.TituloDeleted GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O50,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O54", "SELECT COALESCE( T1.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F FROM (SELECT SUM(COALESCE( T5.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O54,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O57", "SELECT COALESCE( T1.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F FROM (SELECT SUM(CASE  WHEN COALESCE( T2.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T2.TituloValor, 0) - COALESCE( T2.TituloDesconto, 0)) - COALESCE( T5.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O57,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O59", "SELECT COALESCE( T1.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T1.SerasaConsultas_F, 0) AS SerasaConsultas_F FROM (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O59,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O61", "SELECT COALESCE( T1.SerasaScoreUltimaData_F, 0) AS SerasaScoreUltimaData_F, COALESCE( T1.SerasaUltimoValorRecomendado_F, 0) AS SerasaUltimoValorRecomendado_F FROM (SELECT MAX(SerasaScore) AS SerasaScoreUltimaData_F, ClienteId, MAX(SerasaValorLimiteRecomendado) AS SerasaUltimoValorRecomendado_F FROM Serasa WHERE SerasaCreatedAt = :SerasaUltimaData_F GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O61,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O63", "SELECT COALESCE( T1.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE RelacionamentoTipo = ( 'Sacado') GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O64", "SELECT TipoClienteDescricao, TipoClientePortal, TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O64,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O65", "SELECT ConvenioDescricao AS ClienteConvenioDescricao FROM Convenio WHERE ConvenioId = :ClienteConvenio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O65,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O66", "SELECT NacionalidadeNome AS ClienteNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ClienteNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O66,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O67", "SELECT ProfissaoNome AS ClienteProfissaoNome FROM Profissao WHERE ProfissaoId = :ClienteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O67,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O68", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O68,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O69", "SELECT BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O69,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O70", "SELECT NacionalidadeNome AS ResponsavelNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ResponsavelNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O70,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O71", "SELECT ProfissaoNome AS ResponsavelProfissaoNome FROM Profissao WHERE ProfissaoId = :ResponsavelProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O71,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O72", "SELECT MunicipioUF AS ResponsavelMunicipioUF, MunicipioNome AS ResponsavelMunicipioNome FROM Municipio WHERE MunicipioCodigo = :ResponsavelMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O72,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000O73", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE SacadoId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O73,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O74", "SELECT PropostaId FROM Proposta WHERE PropostaEmpresaClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O74,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O75", "SELECT PropostaId FROM Proposta WHERE PropostaClinicaId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O75,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O76", "SELECT PropostaId FROM Proposta WHERE PropostaResponsavelId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O76,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O77", "SELECT PropostaId FROM Proposta WHERE PropostaPacienteClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O77,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O78", "SELECT ContratoId FROM Contrato WHERE ContratoClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O78,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O79", "SELECT TituloId FROM Titulo WHERE TituloClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O79,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O80", "SELECT SecUserId FROM SecUser WHERE SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O80,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O81", "SELECT RelacionamentoId FROM Relacionamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O81,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O82", "SELECT OperacoesId FROM Operacoes WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O82,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O83", "SELECT RepresentanteId FROM Representante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O83,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O84", "SELECT CreditoId FROM Credito WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O84,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O85", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalDestinatarioClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O85,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O86", "SELECT NotaFiscalId FROM NotaFiscal WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O86,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O87", "SELECT SerasaId FROM Serasa WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O87,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O88", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O88,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O89", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ReponsavelClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O89,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O90", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O90,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O91", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O91,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O92", "SELECT FinanciamentoId FROM Financiamento WHERE IntermediadorClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O92,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O93", "SELECT FinanciamentoId FROM Financiamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O93,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000O103", cmdBufferBC000O103,true, GxErrorMask.GX_NOMASK, false, this,prmBC000O103,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((long[]) buf[43])[0] = rslt.getLong(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((long[]) buf[49])[0] = rslt.getLong(26);
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
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((long[]) buf[65])[0] = rslt.getLong(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((int[]) buf[77])[0] = rslt.getInt(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((int[]) buf[83])[0] = rslt.getInt(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((string[]) buf[85])[0] = rslt.getVarchar(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getString(45, 1);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((short[]) buf[92])[0] = rslt.getShort(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((string[]) buf[96])[0] = rslt.getVarchar(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((int[]) buf[98])[0] = rslt.getInt(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((int[]) buf[100])[0] = rslt.getInt(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((int[]) buf[102])[0] = rslt.getInt(53);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                ((int[]) buf[106])[0] = rslt.getInt(55);
                ((bool[]) buf[107])[0] = rslt.wasNull(55);
                ((int[]) buf[108])[0] = rslt.getInt(56);
                ((bool[]) buf[109])[0] = rslt.wasNull(56);
                ((int[]) buf[110])[0] = rslt.getInt(57);
                ((bool[]) buf[111])[0] = rslt.wasNull(57);
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
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((long[]) buf[43])[0] = rslt.getLong(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((long[]) buf[49])[0] = rslt.getLong(26);
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
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((long[]) buf[65])[0] = rslt.getLong(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((int[]) buf[77])[0] = rslt.getInt(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((int[]) buf[83])[0] = rslt.getInt(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((string[]) buf[85])[0] = rslt.getVarchar(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getString(45, 1);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((short[]) buf[92])[0] = rslt.getShort(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((string[]) buf[96])[0] = rslt.getVarchar(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((int[]) buf[98])[0] = rslt.getInt(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((int[]) buf[100])[0] = rslt.getInt(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((int[]) buf[102])[0] = rslt.getInt(53);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                ((int[]) buf[106])[0] = rslt.getInt(55);
                ((bool[]) buf[107])[0] = rslt.wasNull(55);
                ((int[]) buf[108])[0] = rslt.getInt(56);
                ((bool[]) buf[109])[0] = rslt.wasNull(56);
                ((int[]) buf[110])[0] = rslt.getInt(57);
                ((bool[]) buf[111])[0] = rslt.wasNull(57);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
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
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
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
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((long[]) buf[57])[0] = rslt.getLong(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((long[]) buf[63])[0] = rslt.getLong(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((string[]) buf[81])[0] = rslt.getVarchar(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((long[]) buf[85])[0] = rslt.getLong(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getVarchar(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((string[]) buf[93])[0] = rslt.getVarchar(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((string[]) buf[95])[0] = rslt.getVarchar(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((string[]) buf[97])[0] = rslt.getVarchar(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((string[]) buf[99])[0] = rslt.getVarchar(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((string[]) buf[101])[0] = rslt.getVarchar(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((string[]) buf[105])[0] = rslt.getVarchar(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((short[]) buf[107])[0] = rslt.getShort(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((int[]) buf[109])[0] = rslt.getInt(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((string[]) buf[111])[0] = rslt.getVarchar(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((string[]) buf[113])[0] = rslt.getString(58, 1);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((string[]) buf[115])[0] = rslt.getVarchar(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((bool[]) buf[117])[0] = rslt.getBool(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((string[]) buf[119])[0] = rslt.getVarchar(61);
                ((short[]) buf[120])[0] = rslt.getShort(62);
                ((bool[]) buf[121])[0] = rslt.wasNull(62);
                ((string[]) buf[122])[0] = rslt.getVarchar(63);
                ((bool[]) buf[123])[0] = rslt.wasNull(63);
                ((string[]) buf[124])[0] = rslt.getVarchar(64);
                ((bool[]) buf[125])[0] = rslt.wasNull(64);
                ((int[]) buf[126])[0] = rslt.getInt(65);
                ((bool[]) buf[127])[0] = rslt.wasNull(65);
                ((int[]) buf[128])[0] = rslt.getInt(66);
                ((bool[]) buf[129])[0] = rslt.wasNull(66);
                ((int[]) buf[130])[0] = rslt.getInt(67);
                ((bool[]) buf[131])[0] = rslt.wasNull(67);
                ((int[]) buf[132])[0] = rslt.getInt(68);
                ((bool[]) buf[133])[0] = rslt.wasNull(68);
                ((int[]) buf[134])[0] = rslt.getInt(69);
                ((bool[]) buf[135])[0] = rslt.wasNull(69);
                ((int[]) buf[136])[0] = rslt.getInt(70);
                ((bool[]) buf[137])[0] = rslt.wasNull(70);
                ((int[]) buf[138])[0] = rslt.getInt(71);
                ((bool[]) buf[139])[0] = rslt.wasNull(71);
                ((DateTime[]) buf[140])[0] = rslt.getGXDateTime(72);
                ((short[]) buf[141])[0] = rslt.getShort(73);
                ((bool[]) buf[142])[0] = rslt.wasNull(73);
                ((int[]) buf[143])[0] = rslt.getInt(74);
                ((bool[]) buf[144])[0] = rslt.wasNull(74);
                ((decimal[]) buf[145])[0] = rslt.getDecimal(75);
                ((bool[]) buf[146])[0] = rslt.wasNull(75);
                ((decimal[]) buf[147])[0] = rslt.getDecimal(76);
                ((bool[]) buf[148])[0] = rslt.wasNull(76);
                ((short[]) buf[149])[0] = rslt.getShort(77);
                ((short[]) buf[150])[0] = rslt.getShort(78);
                ((bool[]) buf[151])[0] = rslt.wasNull(78);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 35 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 38 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 39 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 40 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 41 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 42 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 43 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 44 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 45 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 46 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 47 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 48 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 49 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 50 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 51 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 52 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 53 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 54 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 55 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 56 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 57 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 58 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 59 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults60( cursor, rslt, buf) ;
    }

    public void getresults60( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 60 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 61 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 62 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 63 :
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
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
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
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((long[]) buf[57])[0] = rslt.getLong(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((long[]) buf[63])[0] = rslt.getLong(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((string[]) buf[81])[0] = rslt.getVarchar(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((long[]) buf[85])[0] = rslt.getLong(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getVarchar(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((string[]) buf[93])[0] = rslt.getVarchar(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((string[]) buf[95])[0] = rslt.getVarchar(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((string[]) buf[97])[0] = rslt.getVarchar(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((string[]) buf[99])[0] = rslt.getVarchar(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((string[]) buf[101])[0] = rslt.getVarchar(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((string[]) buf[105])[0] = rslt.getVarchar(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((short[]) buf[107])[0] = rslt.getShort(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((int[]) buf[109])[0] = rslt.getInt(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((string[]) buf[111])[0] = rslt.getVarchar(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((string[]) buf[113])[0] = rslt.getString(58, 1);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((string[]) buf[115])[0] = rslt.getVarchar(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((bool[]) buf[117])[0] = rslt.getBool(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((string[]) buf[119])[0] = rslt.getVarchar(61);
                ((short[]) buf[120])[0] = rslt.getShort(62);
                ((bool[]) buf[121])[0] = rslt.wasNull(62);
                ((string[]) buf[122])[0] = rslt.getVarchar(63);
                ((bool[]) buf[123])[0] = rslt.wasNull(63);
                ((string[]) buf[124])[0] = rslt.getVarchar(64);
                ((bool[]) buf[125])[0] = rslt.wasNull(64);
                ((int[]) buf[126])[0] = rslt.getInt(65);
                ((bool[]) buf[127])[0] = rslt.wasNull(65);
                ((int[]) buf[128])[0] = rslt.getInt(66);
                ((bool[]) buf[129])[0] = rslt.wasNull(66);
                ((int[]) buf[130])[0] = rslt.getInt(67);
                ((bool[]) buf[131])[0] = rslt.wasNull(67);
                ((int[]) buf[132])[0] = rslt.getInt(68);
                ((bool[]) buf[133])[0] = rslt.wasNull(68);
                ((int[]) buf[134])[0] = rslt.getInt(69);
                ((bool[]) buf[135])[0] = rslt.wasNull(69);
                ((int[]) buf[136])[0] = rslt.getInt(70);
                ((bool[]) buf[137])[0] = rslt.wasNull(70);
                ((int[]) buf[138])[0] = rslt.getInt(71);
                ((bool[]) buf[139])[0] = rslt.wasNull(71);
                ((DateTime[]) buf[140])[0] = rslt.getGXDateTime(72);
                ((short[]) buf[141])[0] = rslt.getShort(73);
                ((bool[]) buf[142])[0] = rslt.wasNull(73);
                ((int[]) buf[143])[0] = rslt.getInt(74);
                ((bool[]) buf[144])[0] = rslt.wasNull(74);
                ((decimal[]) buf[145])[0] = rslt.getDecimal(75);
                ((bool[]) buf[146])[0] = rslt.wasNull(75);
                ((decimal[]) buf[147])[0] = rslt.getDecimal(76);
                ((bool[]) buf[148])[0] = rslt.wasNull(76);
                ((short[]) buf[149])[0] = rslt.getShort(77);
                ((short[]) buf[150])[0] = rslt.getShort(78);
                ((bool[]) buf[151])[0] = rslt.wasNull(78);
                return;
       }
    }

 }

}
