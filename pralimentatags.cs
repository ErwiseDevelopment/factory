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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pralimentatags : GXProcedure
   {
      public pralimentatags( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pralimentatags( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           int aP1_ContratoId ,
                           GXBaseCollection<SdtSdMapearTags> aP2_Array_SDMapearTags ,
                           out SdtSdtListaTags aP3_SdtListaTags )
      {
         this.AV13PropostaId = aP0_PropostaId;
         this.AV14ContratoId = aP1_ContratoId;
         this.AV8Array_SDMapearTags = aP2_Array_SDMapearTags;
         this.AV9SdtListaTags = new SdtSdtListaTags(context) ;
         initialize();
         ExecuteImpl();
         aP3_SdtListaTags=this.AV9SdtListaTags;
      }

      public SdtSdtListaTags executeUdp( int aP0_PropostaId ,
                                         int aP1_ContratoId ,
                                         GXBaseCollection<SdtSdMapearTags> aP2_Array_SDMapearTags )
      {
         execute(aP0_PropostaId, aP1_ContratoId, aP2_Array_SDMapearTags, out aP3_SdtListaTags);
         return AV9SdtListaTags ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 int aP1_ContratoId ,
                                 GXBaseCollection<SdtSdMapearTags> aP2_Array_SDMapearTags ,
                                 out SdtSdtListaTags aP3_SdtListaTags )
      {
         this.AV13PropostaId = aP0_PropostaId;
         this.AV14ContratoId = aP1_ContratoId;
         this.AV8Array_SDMapearTags = aP2_Array_SDMapearTags;
         this.AV9SdtListaTags = new SdtSdtListaTags(context) ;
         SubmitImpl();
         aP3_SdtListaTags=this.AV9SdtListaTags;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! (0==AV13PropostaId) )
         {
            /* Using cursor P00972 */
            pr_default.execute(0, new Object[] {AV13PropostaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A323PropostaId = P00972_A323PropostaId[0];
               A553PropostaResponsavelId = P00972_A553PropostaResponsavelId[0];
               n553PropostaResponsavelId = P00972_n553PropostaResponsavelId[0];
               AV12ClienteId = A553PropostaResponsavelId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         if ( ! (0==AV14ContratoId) )
         {
            /* Using cursor P00973 */
            pr_default.execute(1, new Object[] {AV14ContratoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A227ContratoId = P00973_A227ContratoId[0];
               A473ContratoClienteId = P00973_A473ContratoClienteId[0];
               n473ContratoClienteId = P00973_n473ContratoClienteId[0];
               AV12ClienteId = A473ContratoClienteId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
         AV9SdtListaTags = new SdtSdtListaTags(context);
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV8Array_SDMapearTags.Count )
         {
            AV10SDMapearTags = ((SdtSdMapearTags)AV8Array_SDMapearTags.Item(AV22GXV1));
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Cliente") == 0 )
            {
               /* Using cursor P00979 */
               pr_default.execute(2, new Object[] {AV12ClienteId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A192TipoClienteId = P00979_A192TipoClienteId[0];
                  n192TipoClienteId = P00979_n192TipoClienteId[0];
                  A186MunicipioCodigo = P00979_A186MunicipioCodigo[0];
                  n186MunicipioCodigo = P00979_n186MunicipioCodigo[0];
                  A444ResponsavelMunicipio = P00979_A444ResponsavelMunicipio[0];
                  n444ResponsavelMunicipio = P00979_n444ResponsavelMunicipio[0];
                  A457EspecialidadeId = P00979_A457EspecialidadeId[0];
                  n457EspecialidadeId = P00979_n457EspecialidadeId[0];
                  A597EspecialidadeCreatedBy = P00979_A597EspecialidadeCreatedBy[0];
                  n597EspecialidadeCreatedBy = P00979_n597EspecialidadeCreatedBy[0];
                  A437ResponsavelNacionalidade = P00979_A437ResponsavelNacionalidade[0];
                  n437ResponsavelNacionalidade = P00979_n437ResponsavelNacionalidade[0];
                  A484ClienteNacionalidade = P00979_A484ClienteNacionalidade[0];
                  n484ClienteNacionalidade = P00979_n484ClienteNacionalidade[0];
                  A442ResponsavelProfissao = P00979_A442ResponsavelProfissao[0];
                  n442ResponsavelProfissao = P00979_n442ResponsavelProfissao[0];
                  A487ClienteProfissao = P00979_A487ClienteProfissao[0];
                  n487ClienteProfissao = P00979_n487ClienteProfissao[0];
                  A168ClienteId = P00979_A168ClienteId[0];
                  n168ClienteId = P00979_n168ClienteId[0];
                  A170ClienteRazaoSocial = P00979_A170ClienteRazaoSocial[0];
                  n170ClienteRazaoSocial = P00979_n170ClienteRazaoSocial[0];
                  A204ContatoTelefoneDDI = P00979_A204ContatoTelefoneDDI[0];
                  n204ContatoTelefoneDDI = P00979_n204ContatoTelefoneDDI[0];
                  A199ContatoDDI = P00979_A199ContatoDDI[0];
                  n199ContatoDDI = P00979_n199ContatoDDI[0];
                  A201ContatoEmail = P00979_A201ContatoEmail[0];
                  n201ContatoEmail = P00979_n201ContatoEmail[0];
                  A191EnderecoComplemento = P00979_A191EnderecoComplemento[0];
                  n191EnderecoComplemento = P00979_n191EnderecoComplemento[0];
                  A190EnderecoNumero = P00979_A190EnderecoNumero[0];
                  n190EnderecoNumero = P00979_n190EnderecoNumero[0];
                  A189MunicipioUF = P00979_A189MunicipioUF[0];
                  n189MunicipioUF = P00979_n189MunicipioUF[0];
                  A187MunicipioNome = P00979_A187MunicipioNome[0];
                  n187MunicipioNome = P00979_n187MunicipioNome[0];
                  A185EnderecoCidade = P00979_A185EnderecoCidade[0];
                  n185EnderecoCidade = P00979_n185EnderecoCidade[0];
                  A184EnderecoBairro = P00979_A184EnderecoBairro[0];
                  n184EnderecoBairro = P00979_n184EnderecoBairro[0];
                  A183EnderecoLogradouro = P00979_A183EnderecoLogradouro[0];
                  n183EnderecoLogradouro = P00979_n183EnderecoLogradouro[0];
                  A182EnderecoCEP = P00979_A182EnderecoCEP[0];
                  n182EnderecoCEP = P00979_n182EnderecoCEP[0];
                  A181EnderecoTipo = P00979_A181EnderecoTipo[0];
                  n181EnderecoTipo = P00979_n181EnderecoTipo[0];
                  A141SecUserName = P00979_A141SecUserName[0];
                  n141SecUserName = P00979_n141SecUserName[0];
                  A193TipoClienteDescricao = P00979_A193TipoClienteDescricao[0];
                  n193TipoClienteDescricao = P00979_n193TipoClienteDescricao[0];
                  A172ClienteTipoPessoa = P00979_A172ClienteTipoPessoa[0];
                  n172ClienteTipoPessoa = P00979_n172ClienteTipoPessoa[0];
                  A169ClienteDocumento = P00979_A169ClienteDocumento[0];
                  n169ClienteDocumento = P00979_n169ClienteDocumento[0];
                  A421ClienteRG = P00979_A421ClienteRG[0];
                  n421ClienteRG = P00979_n421ClienteRG[0];
                  A436ResponsavelNome = P00979_A436ResponsavelNome[0];
                  n436ResponsavelNome = P00979_n436ResponsavelNome[0];
                  A438ResponsavelNacionalidadeNome = P00979_A438ResponsavelNacionalidadeNome[0];
                  n438ResponsavelNacionalidadeNome = P00979_n438ResponsavelNacionalidadeNome[0];
                  A439ResponsavelEstadoCivil = P00979_A439ResponsavelEstadoCivil[0];
                  n439ResponsavelEstadoCivil = P00979_n439ResponsavelEstadoCivil[0];
                  A443ResponsavelProfissaoNome = P00979_A443ResponsavelProfissaoNome[0];
                  n443ResponsavelProfissaoNome = P00979_n443ResponsavelProfissaoNome[0];
                  A447ResponsavelCPF = P00979_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = P00979_n447ResponsavelCPF[0];
                  A448ResponsavelCEP = P00979_A448ResponsavelCEP[0];
                  n448ResponsavelCEP = P00979_n448ResponsavelCEP[0];
                  A449ResponsavelLogradouro = P00979_A449ResponsavelLogradouro[0];
                  n449ResponsavelLogradouro = P00979_n449ResponsavelLogradouro[0];
                  A450ResponsavelBairro = P00979_A450ResponsavelBairro[0];
                  n450ResponsavelBairro = P00979_n450ResponsavelBairro[0];
                  A451ResponsavelCidade = P00979_A451ResponsavelCidade[0];
                  n451ResponsavelCidade = P00979_n451ResponsavelCidade[0];
                  A445ResponsavelMunicipioNome = P00979_A445ResponsavelMunicipioNome[0];
                  n445ResponsavelMunicipioNome = P00979_n445ResponsavelMunicipioNome[0];
                  A452ResponsavelLogradouroNumero = P00979_A452ResponsavelLogradouroNumero[0];
                  n452ResponsavelLogradouroNumero = P00979_n452ResponsavelLogradouroNumero[0];
                  A453ResponsavelComplemento = P00979_A453ResponsavelComplemento[0];
                  n453ResponsavelComplemento = P00979_n453ResponsavelComplemento[0];
                  A454ResponsavelDDD = P00979_A454ResponsavelDDD[0];
                  n454ResponsavelDDD = P00979_n454ResponsavelDDD[0];
                  A455ResponsavelNumero = P00979_A455ResponsavelNumero[0];
                  n455ResponsavelNumero = P00979_n455ResponsavelNumero[0];
                  A456ResponsavelEmail = P00979_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = P00979_n456ResponsavelEmail[0];
                  A485ClienteNacionalidadeNome = P00979_A485ClienteNacionalidadeNome[0];
                  n485ClienteNacionalidadeNome = P00979_n485ClienteNacionalidadeNome[0];
                  A486ClienteEstadoCivil = P00979_A486ClienteEstadoCivil[0];
                  n486ClienteEstadoCivil = P00979_n486ClienteEstadoCivil[0];
                  A488ClienteProfissaoNome = P00979_A488ClienteProfissaoNome[0];
                  n488ClienteProfissaoNome = P00979_n488ClienteProfissaoNome[0];
                  A311ClienteValorAReceber_F = P00979_A311ClienteValorAReceber_F[0];
                  n311ClienteValorAReceber_F = P00979_n311ClienteValorAReceber_F[0];
                  A310ClienteValorAPagar_F = P00979_A310ClienteValorAPagar_F[0];
                  n310ClienteValorAPagar_F = P00979_n310ClienteValorAPagar_F[0];
                  A202ContatoTelefoneNumero = P00979_A202ContatoTelefoneNumero[0];
                  n202ContatoTelefoneNumero = P00979_n202ContatoTelefoneNumero[0];
                  A203ContatoTelefoneDDD = P00979_A203ContatoTelefoneDDD[0];
                  n203ContatoTelefoneDDD = P00979_n203ContatoTelefoneDDD[0];
                  A200ContatoNumero = P00979_A200ContatoNumero[0];
                  n200ContatoNumero = P00979_n200ContatoNumero[0];
                  A198ContatoDDD = P00979_A198ContatoDDD[0];
                  n198ContatoDDD = P00979_n198ContatoDDD[0];
                  A193TipoClienteDescricao = P00979_A193TipoClienteDescricao[0];
                  n193TipoClienteDescricao = P00979_n193TipoClienteDescricao[0];
                  A189MunicipioUF = P00979_A189MunicipioUF[0];
                  n189MunicipioUF = P00979_n189MunicipioUF[0];
                  A187MunicipioNome = P00979_A187MunicipioNome[0];
                  n187MunicipioNome = P00979_n187MunicipioNome[0];
                  A445ResponsavelMunicipioNome = P00979_A445ResponsavelMunicipioNome[0];
                  n445ResponsavelMunicipioNome = P00979_n445ResponsavelMunicipioNome[0];
                  A597EspecialidadeCreatedBy = P00979_A597EspecialidadeCreatedBy[0];
                  n597EspecialidadeCreatedBy = P00979_n597EspecialidadeCreatedBy[0];
                  A141SecUserName = P00979_A141SecUserName[0];
                  n141SecUserName = P00979_n141SecUserName[0];
                  A438ResponsavelNacionalidadeNome = P00979_A438ResponsavelNacionalidadeNome[0];
                  n438ResponsavelNacionalidadeNome = P00979_n438ResponsavelNacionalidadeNome[0];
                  A485ClienteNacionalidadeNome = P00979_A485ClienteNacionalidadeNome[0];
                  n485ClienteNacionalidadeNome = P00979_n485ClienteNacionalidadeNome[0];
                  A443ResponsavelProfissaoNome = P00979_A443ResponsavelProfissaoNome[0];
                  n443ResponsavelProfissaoNome = P00979_n443ResponsavelProfissaoNome[0];
                  A488ClienteProfissaoNome = P00979_A488ClienteProfissaoNome[0];
                  n488ClienteProfissaoNome = P00979_n488ClienteProfissaoNome[0];
                  A311ClienteValorAReceber_F = P00979_A311ClienteValorAReceber_F[0];
                  n311ClienteValorAReceber_F = P00979_n311ClienteValorAReceber_F[0];
                  A310ClienteValorAPagar_F = P00979_A310ClienteValorAPagar_F[0];
                  n310ClienteValorAPagar_F = P00979_n310ClienteValorAPagar_F[0];
                  A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
                  A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
                  AV24GXV2 = 1;
                  while ( AV24GXV2 <= AV10SDMapearTags.gxTpr_Tags.Count )
                  {
                     AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV24GXV2));
                     if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{NomeCompleto}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{TotalReceber}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientevalorapagar_f = A311ClienteValorAReceber_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{TotalPagar}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientevalorapagar_f = A310ClienteValorAPagar_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{Celular}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientecelular_f = A206ClienteCelular_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{Telefone}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientetelefone_f = A205ClienteTelefone_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{DDI}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatotelefoneddi = A204ContatoTelefoneDDI;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{DDD}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatotelefoneddd = A203ContatoTelefoneDDD;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{NumeroTelefone}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatotelefonenumero = A202ContatoTelefoneNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{NumeroContato}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatonumero = A200ContatoNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContatoDDI}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatoddi = A199ContatoDDI;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContatoDDD}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatoddd = A198ContatoDDD;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContatoEmail}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Contatoemail = A201ContatoEmail;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoComplemento}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecocomplemento = A191EnderecoComplemento;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoNumero}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Endereconumero = A190EnderecoNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{UF}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Municipiouf = A189MunicipioUF;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{MunicipioNome}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Municipionome = A187MunicipioNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoCidade}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecocidade = A185EnderecoCidade;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoBairro}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecobairro = A184EnderecoBairro;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoLogradouro}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecologradouro = A183EnderecoLogradouro;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoCEP}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecocep = A182EnderecoCEP;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EnderecoTipo}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Enderecotipo = A181EnderecoTipo;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{NomeUsuario}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Secusername = A141SecUserName;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{Tipo}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Tipoclientedescricao = A193TipoClienteDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{TipoPessoa}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientetipopessoa = A172ClienteTipoPessoa;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RazaoSocial}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{CPF/CNPJ}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clientedocumento = A169ClienteDocumento;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RG}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clienterg = A421ClienteRG;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteNomeCompleto}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelnome = A436ResponsavelNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteNacionalidade}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelnacionalidadenome = A438ResponsavelNacionalidadeNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteEstadoCivil}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelestadocivil = A439ResponsavelEstadoCivil;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteProfissão}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelprofissaonome = A443ResponsavelProfissaoNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteCPF}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelcpf = A447ResponsavelCPF;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteCEP}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelcep = A448ResponsavelCEP;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteLogadouro}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavellogradouro = A449ResponsavelLogradouro;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteBairro}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelbairro = A450ResponsavelBairro;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteCidade}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelcidade = A451ResponsavelCidade;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteMunicipio}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelmunicipio = A445ResponsavelMunicipioNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteEnderecoNumero}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavellogradouronumero = A452ResponsavelLogradouroNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteComplemento}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelcomplemento = A453ResponsavelComplemento;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteDDD}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelddd = A454ResponsavelDDD;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteNumero}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelnumero = A455ResponsavelNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{RepresentanteEmail}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelemail = A456ResponsavelEmail;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClienteNacionalidade}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelemail = A485ClienteNacionalidadeNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClienteEstadoCivil}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelemail = A486ClienteEstadoCivil;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClienteProfissão}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelemail = A488ClienteProfissaoNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClienteRG}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Responsavelemail = StringUtil.Str( (decimal)(A421ClienteRG), 12, 0);
                     }
                     AV24GXV2 = (int)(AV24GXV2+1);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Servidor") == 0 )
            {
               AV15Date = DateTimeUtil.ServerDate( context, pr_default);
               AV9SdtListaTags.gxTpr_Anoatual = (short)(DateTimeUtil.Year( AV15Date));
               AV9SdtListaTags.gxTpr_Mesatualextenso = DateTimeUtil.CMonth( AV15Date, "por");
               AV9SdtListaTags.gxTpr_Diaatual = (short)(DateTimeUtil.Day( AV15Date));
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "ConfiguracoesTestemunha") == 0 )
            {
               AV16i = 1;
               /* Using cursor P009710 */
               pr_default.execute(3);
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A480ConfiguracoesTestemunhasDocumento = P009710_A480ConfiguracoesTestemunhasDocumento[0];
                  n480ConfiguracoesTestemunhasDocumento = P009710_n480ConfiguracoesTestemunhasDocumento[0];
                  A479ConfiguracoesTestemunhasNome = P009710_A479ConfiguracoesTestemunhasNome[0];
                  n479ConfiguracoesTestemunhasNome = P009710_n479ConfiguracoesTestemunhasNome[0];
                  A478ConfiguracoesTestemunhasId = P009710_A478ConfiguracoesTestemunhasId[0];
                  if ( AV16i == 1 )
                  {
                     AV9SdtListaTags.gxTpr_Testemunhapadraocpf1 = A480ConfiguracoesTestemunhasDocumento;
                     AV9SdtListaTags.gxTpr_Testemunhapadraonome1 = A479ConfiguracoesTestemunhasNome;
                  }
                  AV16i = (short)(AV16i+1);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Reembolso") == 0 )
            {
               /* Using cursor P009712 */
               pr_default.execute(4, new Object[] {AV13PropostaId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A518ReembolsoId = P009712_A518ReembolsoId[0];
                  n518ReembolsoId = P009712_n518ReembolsoId[0];
                  A542ReembolsoPropostaId = P009712_A542ReembolsoPropostaId[0];
                  n542ReembolsoPropostaId = P009712_n542ReembolsoPropostaId[0];
                  A543ReembolsoPropostaValor = P009712_A543ReembolsoPropostaValor[0];
                  n543ReembolsoPropostaValor = P009712_n543ReembolsoPropostaValor[0];
                  A645ReembolsoValorReembolsado_F = P009712_A645ReembolsoValorReembolsado_F[0];
                  n645ReembolsoValorReembolsado_F = P009712_n645ReembolsoValorReembolsado_F[0];
                  A645ReembolsoValorReembolsado_F = P009712_A645ReembolsoValorReembolsado_F[0];
                  n645ReembolsoValorReembolsado_F = P009712_n645ReembolsoValorReembolsado_F[0];
                  A543ReembolsoPropostaValor = P009712_A543ReembolsoPropostaValor[0];
                  n543ReembolsoPropostaValor = P009712_n543ReembolsoPropostaValor[0];
                  AV27GXV3 = 1;
                  while ( AV27GXV3 <= AV10SDMapearTags.gxTpr_Tags.Count )
                  {
                     AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV27GXV3));
                     if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ReembolsoValor}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Reembolsovalorreembolsado_f = A645ReembolsoValorReembolsado_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ValorRemanescente}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Reembolsosaldovalor = (decimal)(A543ReembolsoPropostaValor-A645ReembolsoValorReembolsado_F);
                     }
                     AV27GXV3 = (int)(AV27GXV3+1);
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Empresa") == 0 )
            {
               /* Using cursor P009713 */
               pr_default.execute(5);
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A464EmpresaBancoId = P009713_A464EmpresaBancoId[0];
                  n464EmpresaBancoId = P009713_n464EmpresaBancoId[0];
                  A250EmpresaNomeFantasia = P009713_A250EmpresaNomeFantasia[0];
                  n250EmpresaNomeFantasia = P009713_n250EmpresaNomeFantasia[0];
                  A251EmpresaRazaoSocial = P009713_A251EmpresaRazaoSocial[0];
                  n251EmpresaRazaoSocial = P009713_n251EmpresaRazaoSocial[0];
                  A403BancoNome = P009713_A403BancoNome[0];
                  n403BancoNome = P009713_n403BancoNome[0];
                  A465EmpresaAgencia = P009713_A465EmpresaAgencia[0];
                  n465EmpresaAgencia = P009713_n465EmpresaAgencia[0];
                  A466EmpresaAgenciaDigito = P009713_A466EmpresaAgenciaDigito[0];
                  n466EmpresaAgenciaDigito = P009713_n466EmpresaAgenciaDigito[0];
                  A467EmpresaConta = P009713_A467EmpresaConta[0];
                  n467EmpresaConta = P009713_n467EmpresaConta[0];
                  A468EmpresaPix = P009713_A468EmpresaPix[0];
                  n468EmpresaPix = P009713_n468EmpresaPix[0];
                  A469EmpresaPixTipo = P009713_A469EmpresaPixTipo[0];
                  n469EmpresaPixTipo = P009713_n469EmpresaPixTipo[0];
                  A470EmpresaEmail = P009713_A470EmpresaEmail[0];
                  n470EmpresaEmail = P009713_n470EmpresaEmail[0];
                  A249EmpresaId = P009713_A249EmpresaId[0];
                  A403BancoNome = P009713_A403BancoNome[0];
                  n403BancoNome = P009713_n403BancoNome[0];
                  AV29GXV4 = 1;
                  while ( AV29GXV4 <= AV10SDMapearTags.gxTpr_Tags.Count )
                  {
                     AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV29GXV4));
                     if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaNomeFantasia}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresanomefantasia = A250EmpresaNomeFantasia;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaRazaoSocial}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresarazaosocial = A251EmpresaRazaoSocial;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaBanco}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresabanconome = A403BancoNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaAgencia}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresaagencia = A465EmpresaAgencia;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaAgenciaDigito}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresaagenciadigito = A466EmpresaAgenciaDigito;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaConta}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresaconta = A467EmpresaConta;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaPix}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresapix = A468EmpresaPix;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaPixTipo}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresapixtipo = A469EmpresaPixTipo;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{EmpresaEmail}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Empresaemail = A470EmpresaEmail;
                     }
                     AV29GXV4 = (int)(AV29GXV4+1);
                  }
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Contrato") == 0 )
            {
               if ( ! (0==AV14ContratoId) )
               {
                  /* Using cursor P009714 */
                  pr_default.execute(6, new Object[] {AV14ContratoId});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A227ContratoId = P009714_A227ContratoId[0];
                     A473ContratoClienteId = P009714_A473ContratoClienteId[0];
                     n473ContratoClienteId = P009714_n473ContratoClienteId[0];
                     A460ContratoTaxa = P009714_A460ContratoTaxa[0];
                     n460ContratoTaxa = P009714_n460ContratoTaxa[0];
                     A461ContratoSLA = P009714_A461ContratoSLA[0];
                     n461ContratoSLA = P009714_n461ContratoSLA[0];
                     A462ContratoJurosMora = P009714_A462ContratoJurosMora[0];
                     n462ContratoJurosMora = P009714_n462ContratoJurosMora[0];
                     A463ContratoIOFMinimo = P009714_A463ContratoIOFMinimo[0];
                     n463ContratoIOFMinimo = P009714_n463ContratoIOFMinimo[0];
                     AV12ClienteId = A473ContratoClienteId;
                     AV31GXV5 = 1;
                     while ( AV31GXV5 <= AV10SDMapearTags.gxTpr_Tags.Count )
                     {
                        AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV31GXV5));
                        if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContratoTaxa}}") == 0 )
                        {
                           AV9SdtListaTags.gxTpr_Contratotaxa = A460ContratoTaxa;
                        }
                        else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContratoSLA}}") == 0 )
                        {
                           AV9SdtListaTags.gxTpr_Contratosla = A461ContratoSLA;
                        }
                        else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContratoJurosMora}}") == 0 )
                        {
                           AV9SdtListaTags.gxTpr_Contratojurosmora = A462ContratoJurosMora;
                        }
                        else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ContratoIOFMinimo}}") == 0 )
                        {
                           AV9SdtListaTags.gxTpr_Contratoiofminimo = A463ContratoIOFMinimo;
                        }
                        AV31GXV5 = (int)(AV31GXV5+1);
                     }
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
            }
            if ( StringUtil.StrCmp(AV10SDMapearTags.gxTpr_Tabela, "Proposta") == 0 )
            {
               /* Using cursor P009716 */
               pr_default.execute(7, new Object[] {AV13PropostaId});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A376ProcedimentosMedicosId = P009716_A376ProcedimentosMedicosId[0];
                  n376ProcedimentosMedicosId = P009716_n376ProcedimentosMedicosId[0];
                  A493ConvenioCategoriaId = P009716_A493ConvenioCategoriaId[0];
                  n493ConvenioCategoriaId = P009716_n493ConvenioCategoriaId[0];
                  A410ConvenioId = P009716_A410ConvenioId[0];
                  n410ConvenioId = P009716_n410ConvenioId[0];
                  A323PropostaId = P009716_A323PropostaId[0];
                  A328PropostaCratedBy = P009716_A328PropostaCratedBy[0];
                  n328PropostaCratedBy = P009716_n328PropostaCratedBy[0];
                  A411ConvenioDescricao = P009716_A411ConvenioDescricao[0];
                  n411ConvenioDescricao = P009716_n411ConvenioDescricao[0];
                  A494ConvenioCategoriaDescricao = P009716_A494ConvenioCategoriaDescricao[0];
                  n494ConvenioCategoriaDescricao = P009716_n494ConvenioCategoriaDescricao[0];
                  A497ConvenioVencimentoMes = P009716_A497ConvenioVencimentoMes[0];
                  n497ConvenioVencimentoMes = P009716_n497ConvenioVencimentoMes[0];
                  A496ConvenioVencimentoAno = P009716_A496ConvenioVencimentoAno[0];
                  n496ConvenioVencimentoAno = P009716_n496ConvenioVencimentoAno[0];
                  A378ProcedimentosMedicosDescricao = P009716_A378ProcedimentosMedicosDescricao[0];
                  n378ProcedimentosMedicosDescricao = P009716_n378ProcedimentosMedicosDescricao[0];
                  A650PropostaValorTaxaClinica_F = P009716_A650PropostaValorTaxaClinica_F[0];
                  n650PropostaValorTaxaClinica_F = P009716_n650PropostaValorTaxaClinica_F[0];
                  A501PropostaTaxaAdministrativa = P009716_A501PropostaTaxaAdministrativa[0];
                  n501PropostaTaxaAdministrativa = P009716_n501PropostaTaxaAdministrativa[0];
                  A326PropostaValor = P009716_A326PropostaValor[0];
                  n326PropostaValor = P009716_n326PropostaValor[0];
                  A378ProcedimentosMedicosDescricao = P009716_A378ProcedimentosMedicosDescricao[0];
                  n378ProcedimentosMedicosDescricao = P009716_n378ProcedimentosMedicosDescricao[0];
                  A410ConvenioId = P009716_A410ConvenioId[0];
                  n410ConvenioId = P009716_n410ConvenioId[0];
                  A494ConvenioCategoriaDescricao = P009716_A494ConvenioCategoriaDescricao[0];
                  n494ConvenioCategoriaDescricao = P009716_n494ConvenioCategoriaDescricao[0];
                  A411ConvenioDescricao = P009716_A411ConvenioDescricao[0];
                  n411ConvenioDescricao = P009716_n411ConvenioDescricao[0];
                  A650PropostaValorTaxaClinica_F = P009716_A650PropostaValorTaxaClinica_F[0];
                  n650PropostaValorTaxaClinica_F = P009716_n650PropostaValorTaxaClinica_F[0];
                  A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
                  AV17ClinicaClienteId = A328PropostaCratedBy;
                  AV33GXV6 = 1;
                  while ( AV33GXV6 <= AV10SDMapearTags.gxTpr_Tags.Count )
                  {
                     AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV33GXV6));
                     if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{Convenio}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Conveniodescricao = A411ConvenioDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ValorProposta}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Propostavalor = A326PropostaValor;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ValorTaxa}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Valortaxa = A575PropostaTaxa_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ValorTaxaExtenso}}") == 0 )
                     {
                        GXt_char1 = "";
                        new numeroporextenso(context ).execute(  A575PropostaTaxa_F, out  GXt_char1) ;
                        AV9SdtListaTags.gxTpr_Valortaxaextenso = GXt_char1;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ValorPropostaExtenso}}") == 0 )
                     {
                        GXt_char1 = AV19ValorExtenso;
                        new numeroporextenso(context ).execute(  A326PropostaValor, out  GXt_char1) ;
                        AV19ValorExtenso = GXt_char1;
                        AV9SdtListaTags.gxTpr_Valorpropostaextenso = AV19ValorExtenso;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{CategoriaConvenio}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Conveniocategoriadescricao = A494ConvenioCategoriaDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{CategoriaMes}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Conveniovencimentomes = A497ConvenioVencimentoMes;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{CategoriaAno}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Conveniovencimentoano = A496ConvenioVencimentoAno;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{NumeroNotaEmprestimo}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Numeronotaemprestimo = A323PropostaId;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{Procedimento}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Procedimentosmedicosdescricao = A378ProcedimentosMedicosDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaValor}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Propostavalortaxaclinica_f = A650PropostaValorTaxaClinica_F;
                     }
                     AV33GXV6 = (int)(AV33GXV6+1);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(7);
               /* Using cursor P009717 */
               pr_default.execute(8, new Object[] {AV17ClinicaClienteId});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A133SecUserId = P009717_A133SecUserId[0];
                  A226SecUserOwnerId = P009717_A226SecUserOwnerId[0];
                  n226SecUserOwnerId = P009717_n226SecUserOwnerId[0];
                  AV18secuserownerid = A226SecUserOwnerId;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(8);
               /* Using cursor P009718 */
               pr_default.execute(9, new Object[] {AV18secuserownerid});
               while ( (pr_default.getStatus(9) != 101) )
               {
                  A186MunicipioCodigo = P009718_A186MunicipioCodigo[0];
                  n186MunicipioCodigo = P009718_n186MunicipioCodigo[0];
                  A402BancoId = P009718_A402BancoId[0];
                  n402BancoId = P009718_n402BancoId[0];
                  A437ResponsavelNacionalidade = P009718_A437ResponsavelNacionalidade[0];
                  n437ResponsavelNacionalidade = P009718_n437ResponsavelNacionalidade[0];
                  A442ResponsavelProfissao = P009718_A442ResponsavelProfissao[0];
                  n442ResponsavelProfissao = P009718_n442ResponsavelProfissao[0];
                  A168ClienteId = P009718_A168ClienteId[0];
                  n168ClienteId = P009718_n168ClienteId[0];
                  A170ClienteRazaoSocial = P009718_A170ClienteRazaoSocial[0];
                  n170ClienteRazaoSocial = P009718_n170ClienteRazaoSocial[0];
                  A183EnderecoLogradouro = P009718_A183EnderecoLogradouro[0];
                  n183EnderecoLogradouro = P009718_n183EnderecoLogradouro[0];
                  A187MunicipioNome = P009718_A187MunicipioNome[0];
                  n187MunicipioNome = P009718_n187MunicipioNome[0];
                  A182EnderecoCEP = P009718_A182EnderecoCEP[0];
                  n182EnderecoCEP = P009718_n182EnderecoCEP[0];
                  A189MunicipioUF = P009718_A189MunicipioUF[0];
                  n189MunicipioUF = P009718_n189MunicipioUF[0];
                  A191EnderecoComplemento = P009718_A191EnderecoComplemento[0];
                  n191EnderecoComplemento = P009718_n191EnderecoComplemento[0];
                  A190EnderecoNumero = P009718_A190EnderecoNumero[0];
                  n190EnderecoNumero = P009718_n190EnderecoNumero[0];
                  A184EnderecoBairro = P009718_A184EnderecoBairro[0];
                  n184EnderecoBairro = P009718_n184EnderecoBairro[0];
                  A436ResponsavelNome = P009718_A436ResponsavelNome[0];
                  n436ResponsavelNome = P009718_n436ResponsavelNome[0];
                  A447ResponsavelCPF = P009718_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = P009718_n447ResponsavelCPF[0];
                  A438ResponsavelNacionalidadeNome = P009718_A438ResponsavelNacionalidadeNome[0];
                  n438ResponsavelNacionalidadeNome = P009718_n438ResponsavelNacionalidadeNome[0];
                  A439ResponsavelEstadoCivil = P009718_A439ResponsavelEstadoCivil[0];
                  n439ResponsavelEstadoCivil = P009718_n439ResponsavelEstadoCivil[0];
                  A443ResponsavelProfissaoNome = P009718_A443ResponsavelProfissaoNome[0];
                  n443ResponsavelProfissaoNome = P009718_n443ResponsavelProfissaoNome[0];
                  A576ResponsavelRG = P009718_A576ResponsavelRG[0];
                  n576ResponsavelRG = P009718_n576ResponsavelRG[0];
                  A449ResponsavelLogradouro = P009718_A449ResponsavelLogradouro[0];
                  n449ResponsavelLogradouro = P009718_n449ResponsavelLogradouro[0];
                  A444ResponsavelMunicipio = P009718_A444ResponsavelMunicipio[0];
                  n444ResponsavelMunicipio = P009718_n444ResponsavelMunicipio[0];
                  A448ResponsavelCEP = P009718_A448ResponsavelCEP[0];
                  n448ResponsavelCEP = P009718_n448ResponsavelCEP[0];
                  A446ResponsavelMunicipioUF = P009718_A446ResponsavelMunicipioUF[0];
                  n446ResponsavelMunicipioUF = P009718_n446ResponsavelMunicipioUF[0];
                  A453ResponsavelComplemento = P009718_A453ResponsavelComplemento[0];
                  n453ResponsavelComplemento = P009718_n453ResponsavelComplemento[0];
                  A452ResponsavelLogradouroNumero = P009718_A452ResponsavelLogradouroNumero[0];
                  n452ResponsavelLogradouroNumero = P009718_n452ResponsavelLogradouroNumero[0];
                  A456ResponsavelEmail = P009718_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = P009718_n456ResponsavelEmail[0];
                  A403BancoNome = P009718_A403BancoNome[0];
                  n403BancoNome = P009718_n403BancoNome[0];
                  A400ContaAgencia = P009718_A400ContaAgencia[0];
                  n400ContaAgencia = P009718_n400ContaAgencia[0];
                  A401ContaNumero = P009718_A401ContaNumero[0];
                  n401ContaNumero = P009718_n401ContaNumero[0];
                  A539ClientePix = P009718_A539ClientePix[0];
                  n539ClientePix = P009718_n539ClientePix[0];
                  A169ClienteDocumento = P009718_A169ClienteDocumento[0];
                  n169ClienteDocumento = P009718_n169ClienteDocumento[0];
                  A455ResponsavelNumero = P009718_A455ResponsavelNumero[0];
                  n455ResponsavelNumero = P009718_n455ResponsavelNumero[0];
                  A454ResponsavelDDD = P009718_A454ResponsavelDDD[0];
                  n454ResponsavelDDD = P009718_n454ResponsavelDDD[0];
                  A187MunicipioNome = P009718_A187MunicipioNome[0];
                  n187MunicipioNome = P009718_n187MunicipioNome[0];
                  A189MunicipioUF = P009718_A189MunicipioUF[0];
                  n189MunicipioUF = P009718_n189MunicipioUF[0];
                  A403BancoNome = P009718_A403BancoNome[0];
                  n403BancoNome = P009718_n403BancoNome[0];
                  A438ResponsavelNacionalidadeNome = P009718_A438ResponsavelNacionalidadeNome[0];
                  n438ResponsavelNacionalidadeNome = P009718_n438ResponsavelNacionalidadeNome[0];
                  A443ResponsavelProfissaoNome = P009718_A443ResponsavelProfissaoNome[0];
                  n443ResponsavelProfissaoNome = P009718_n443ResponsavelProfissaoNome[0];
                  A446ResponsavelMunicipioUF = P009718_A446ResponsavelMunicipioUF[0];
                  n446ResponsavelMunicipioUF = P009718_n446ResponsavelMunicipioUF[0];
                  GXt_char1 = A577ResponsavelCelular_F;
                  new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
                  A577ResponsavelCelular_F = GXt_char1;
                  AV36GXV7 = 1;
                  while ( AV36GXV7 <= AV10SDMapearTags.gxTpr_Tags.Count )
                  {
                     AV11SdMapearTagsTags = ((SdtSdMapearTags_TagsItem)AV10SDMapearTags.gxTpr_Tags.Item(AV36GXV7));
                     if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRazaoSocial}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarazaosocial = A170ClienteRazaoSocial;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaEndereço}}") == 0 )
                     {
                        GXt_char1 = "";
                        new initcap(context ).execute(  A183EnderecoLogradouro, out  GXt_char1) ;
                        GXt_char2 = "";
                        new initcap(context ).execute(  A191EnderecoComplemento, out  GXt_char2) ;
                        GXt_char3 = "";
                        new initcap(context ).execute(  A187MunicipioNome, out  GXt_char3) ;
                        AV9SdtListaTags.gxTpr_Clinicaendereco = StringUtil.Format( "Rua %1, %2, %3 %4/%5 - CEP: %6", GXt_char1, A190EnderecoNumero, (String.IsNullOrEmpty(StringUtil.RTrim( A191EnderecoComplemento))||P009718_n191EnderecoComplemento[0] ? "" : GXt_char2+","), GXt_char3, A189MunicipioUF, A182EnderecoCEP, "", "", "");
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaBairro}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicabairro = A184EnderecoBairro;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteNome}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentantenome = A436ResponsavelNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteCPF}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentantecpf = A447ResponsavelCPF;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteNacionalidade}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentantenacionalidade = A438ResponsavelNacionalidadeNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteEstadoCivil}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentanteestadocivil = A439ResponsavelEstadoCivil;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteProfissão}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentanteprofissao = A443ResponsavelProfissaoNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteRG}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentanterg = A576ResponsavelRG;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteEndereco}}") == 0 )
                     {
                        GXt_char3 = "";
                        new initcap(context ).execute(  A449ResponsavelLogradouro, out  GXt_char3) ;
                        GXt_char2 = "";
                        new initcap(context ).execute(  A453ResponsavelComplemento, out  GXt_char2) ;
                        GXt_char1 = "";
                        new initcap(context ).execute(  A444ResponsavelMunicipio, out  GXt_char1) ;
                        AV9SdtListaTags.gxTpr_Clinicarepresentanteendereco = StringUtil.Format( "Rua %1, %2, %3 %4/%5 - CEP: %6", GXt_char3, StringUtil.LTrimStr( (decimal)(A452ResponsavelLogradouroNumero), 9, 0), (String.IsNullOrEmpty(StringUtil.RTrim( A453ResponsavelComplemento))||P009718_n453ResponsavelComplemento[0] ? "" : GXt_char2+","), GXt_char1, A446ResponsavelMunicipioUF, A448ResponsavelCEP, "", "", "");
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteCelular}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentantecelular = A577ResponsavelCelular_F;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaRepresentanteEmail}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicarepresentanteemail = A456ResponsavelEmail;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaBanco}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicabanco = A403BancoNome;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaAgencia}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicaagencia = A400ContaAgencia;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaConta}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicaconta = A401ContaNumero;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaPIX}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicapix = A539ClientePix;
                     }
                     else if ( StringUtil.StrCmp(AV11SdMapearTagsTags.gxTpr_Tag, "{{ClinicaCNPJ}}") == 0 )
                     {
                        AV9SdtListaTags.gxTpr_Clinicacnpj = A169ClienteDocumento;
                     }
                     AV36GXV7 = (int)(AV36GXV7+1);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(9);
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9SdtListaTags = new SdtSdtListaTags(context);
         P00972_A323PropostaId = new int[1] ;
         P00972_A553PropostaResponsavelId = new int[1] ;
         P00972_n553PropostaResponsavelId = new bool[] {false} ;
         P00973_A227ContratoId = new int[1] ;
         P00973_A473ContratoClienteId = new int[1] ;
         P00973_n473ContratoClienteId = new bool[] {false} ;
         AV10SDMapearTags = new SdtSdMapearTags(context);
         P00979_A192TipoClienteId = new short[1] ;
         P00979_n192TipoClienteId = new bool[] {false} ;
         P00979_A186MunicipioCodigo = new string[] {""} ;
         P00979_n186MunicipioCodigo = new bool[] {false} ;
         P00979_A444ResponsavelMunicipio = new string[] {""} ;
         P00979_n444ResponsavelMunicipio = new bool[] {false} ;
         P00979_A457EspecialidadeId = new int[1] ;
         P00979_n457EspecialidadeId = new bool[] {false} ;
         P00979_A597EspecialidadeCreatedBy = new short[1] ;
         P00979_n597EspecialidadeCreatedBy = new bool[] {false} ;
         P00979_A437ResponsavelNacionalidade = new int[1] ;
         P00979_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00979_A484ClienteNacionalidade = new int[1] ;
         P00979_n484ClienteNacionalidade = new bool[] {false} ;
         P00979_A442ResponsavelProfissao = new int[1] ;
         P00979_n442ResponsavelProfissao = new bool[] {false} ;
         P00979_A487ClienteProfissao = new int[1] ;
         P00979_n487ClienteProfissao = new bool[] {false} ;
         P00979_A168ClienteId = new int[1] ;
         P00979_n168ClienteId = new bool[] {false} ;
         P00979_A170ClienteRazaoSocial = new string[] {""} ;
         P00979_n170ClienteRazaoSocial = new bool[] {false} ;
         P00979_A204ContatoTelefoneDDI = new short[1] ;
         P00979_n204ContatoTelefoneDDI = new bool[] {false} ;
         P00979_A199ContatoDDI = new short[1] ;
         P00979_n199ContatoDDI = new bool[] {false} ;
         P00979_A201ContatoEmail = new string[] {""} ;
         P00979_n201ContatoEmail = new bool[] {false} ;
         P00979_A191EnderecoComplemento = new string[] {""} ;
         P00979_n191EnderecoComplemento = new bool[] {false} ;
         P00979_A190EnderecoNumero = new string[] {""} ;
         P00979_n190EnderecoNumero = new bool[] {false} ;
         P00979_A189MunicipioUF = new string[] {""} ;
         P00979_n189MunicipioUF = new bool[] {false} ;
         P00979_A187MunicipioNome = new string[] {""} ;
         P00979_n187MunicipioNome = new bool[] {false} ;
         P00979_A185EnderecoCidade = new string[] {""} ;
         P00979_n185EnderecoCidade = new bool[] {false} ;
         P00979_A184EnderecoBairro = new string[] {""} ;
         P00979_n184EnderecoBairro = new bool[] {false} ;
         P00979_A183EnderecoLogradouro = new string[] {""} ;
         P00979_n183EnderecoLogradouro = new bool[] {false} ;
         P00979_A182EnderecoCEP = new string[] {""} ;
         P00979_n182EnderecoCEP = new bool[] {false} ;
         P00979_A181EnderecoTipo = new string[] {""} ;
         P00979_n181EnderecoTipo = new bool[] {false} ;
         P00979_A141SecUserName = new string[] {""} ;
         P00979_n141SecUserName = new bool[] {false} ;
         P00979_A193TipoClienteDescricao = new string[] {""} ;
         P00979_n193TipoClienteDescricao = new bool[] {false} ;
         P00979_A172ClienteTipoPessoa = new string[] {""} ;
         P00979_n172ClienteTipoPessoa = new bool[] {false} ;
         P00979_A169ClienteDocumento = new string[] {""} ;
         P00979_n169ClienteDocumento = new bool[] {false} ;
         P00979_A421ClienteRG = new long[1] ;
         P00979_n421ClienteRG = new bool[] {false} ;
         P00979_A436ResponsavelNome = new string[] {""} ;
         P00979_n436ResponsavelNome = new bool[] {false} ;
         P00979_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00979_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00979_A439ResponsavelEstadoCivil = new string[] {""} ;
         P00979_n439ResponsavelEstadoCivil = new bool[] {false} ;
         P00979_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00979_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00979_A447ResponsavelCPF = new string[] {""} ;
         P00979_n447ResponsavelCPF = new bool[] {false} ;
         P00979_A448ResponsavelCEP = new string[] {""} ;
         P00979_n448ResponsavelCEP = new bool[] {false} ;
         P00979_A449ResponsavelLogradouro = new string[] {""} ;
         P00979_n449ResponsavelLogradouro = new bool[] {false} ;
         P00979_A450ResponsavelBairro = new string[] {""} ;
         P00979_n450ResponsavelBairro = new bool[] {false} ;
         P00979_A451ResponsavelCidade = new string[] {""} ;
         P00979_n451ResponsavelCidade = new bool[] {false} ;
         P00979_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00979_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00979_A452ResponsavelLogradouroNumero = new int[1] ;
         P00979_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         P00979_A453ResponsavelComplemento = new string[] {""} ;
         P00979_n453ResponsavelComplemento = new bool[] {false} ;
         P00979_A454ResponsavelDDD = new short[1] ;
         P00979_n454ResponsavelDDD = new bool[] {false} ;
         P00979_A455ResponsavelNumero = new int[1] ;
         P00979_n455ResponsavelNumero = new bool[] {false} ;
         P00979_A456ResponsavelEmail = new string[] {""} ;
         P00979_n456ResponsavelEmail = new bool[] {false} ;
         P00979_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00979_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00979_A486ClienteEstadoCivil = new string[] {""} ;
         P00979_n486ClienteEstadoCivil = new bool[] {false} ;
         P00979_A488ClienteProfissaoNome = new string[] {""} ;
         P00979_n488ClienteProfissaoNome = new bool[] {false} ;
         P00979_A311ClienteValorAReceber_F = new decimal[1] ;
         P00979_n311ClienteValorAReceber_F = new bool[] {false} ;
         P00979_A310ClienteValorAPagar_F = new decimal[1] ;
         P00979_n310ClienteValorAPagar_F = new bool[] {false} ;
         P00979_A202ContatoTelefoneNumero = new long[1] ;
         P00979_n202ContatoTelefoneNumero = new bool[] {false} ;
         P00979_A203ContatoTelefoneDDD = new short[1] ;
         P00979_n203ContatoTelefoneDDD = new bool[] {false} ;
         P00979_A200ContatoNumero = new long[1] ;
         P00979_n200ContatoNumero = new bool[] {false} ;
         P00979_A198ContatoDDD = new short[1] ;
         P00979_n198ContatoDDD = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         A170ClienteRazaoSocial = "";
         A201ContatoEmail = "";
         A191EnderecoComplemento = "";
         A190EnderecoNumero = "";
         A189MunicipioUF = "";
         A187MunicipioNome = "";
         A185EnderecoCidade = "";
         A184EnderecoBairro = "";
         A183EnderecoLogradouro = "";
         A182EnderecoCEP = "";
         A181EnderecoTipo = "";
         A141SecUserName = "";
         A193TipoClienteDescricao = "";
         A172ClienteTipoPessoa = "";
         A169ClienteDocumento = "";
         A436ResponsavelNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A439ResponsavelEstadoCivil = "";
         A443ResponsavelProfissaoNome = "";
         A447ResponsavelCPF = "";
         A448ResponsavelCEP = "";
         A449ResponsavelLogradouro = "";
         A450ResponsavelBairro = "";
         A451ResponsavelCidade = "";
         A445ResponsavelMunicipioNome = "";
         A453ResponsavelComplemento = "";
         A456ResponsavelEmail = "";
         A485ClienteNacionalidadeNome = "";
         A486ClienteEstadoCivil = "";
         A488ClienteProfissaoNome = "";
         A206ClienteCelular_F = "";
         A205ClienteTelefone_F = "";
         AV11SdMapearTagsTags = new SdtSdMapearTags_TagsItem(context);
         AV15Date = DateTime.MinValue;
         P009710_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         P009710_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         P009710_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         P009710_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         P009710_A478ConfiguracoesTestemunhasId = new int[1] ;
         A480ConfiguracoesTestemunhasDocumento = "";
         A479ConfiguracoesTestemunhasNome = "";
         P009712_A518ReembolsoId = new int[1] ;
         P009712_n518ReembolsoId = new bool[] {false} ;
         P009712_A542ReembolsoPropostaId = new int[1] ;
         P009712_n542ReembolsoPropostaId = new bool[] {false} ;
         P009712_A543ReembolsoPropostaValor = new decimal[1] ;
         P009712_n543ReembolsoPropostaValor = new bool[] {false} ;
         P009712_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         P009712_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         P009713_A464EmpresaBancoId = new int[1] ;
         P009713_n464EmpresaBancoId = new bool[] {false} ;
         P009713_A250EmpresaNomeFantasia = new string[] {""} ;
         P009713_n250EmpresaNomeFantasia = new bool[] {false} ;
         P009713_A251EmpresaRazaoSocial = new string[] {""} ;
         P009713_n251EmpresaRazaoSocial = new bool[] {false} ;
         P009713_A403BancoNome = new string[] {""} ;
         P009713_n403BancoNome = new bool[] {false} ;
         P009713_A465EmpresaAgencia = new int[1] ;
         P009713_n465EmpresaAgencia = new bool[] {false} ;
         P009713_A466EmpresaAgenciaDigito = new int[1] ;
         P009713_n466EmpresaAgenciaDigito = new bool[] {false} ;
         P009713_A467EmpresaConta = new int[1] ;
         P009713_n467EmpresaConta = new bool[] {false} ;
         P009713_A468EmpresaPix = new string[] {""} ;
         P009713_n468EmpresaPix = new bool[] {false} ;
         P009713_A469EmpresaPixTipo = new string[] {""} ;
         P009713_n469EmpresaPixTipo = new bool[] {false} ;
         P009713_A470EmpresaEmail = new string[] {""} ;
         P009713_n470EmpresaEmail = new bool[] {false} ;
         P009713_A249EmpresaId = new int[1] ;
         A250EmpresaNomeFantasia = "";
         A251EmpresaRazaoSocial = "";
         A403BancoNome = "";
         A468EmpresaPix = "";
         A469EmpresaPixTipo = "";
         A470EmpresaEmail = "";
         P009714_A227ContratoId = new int[1] ;
         P009714_A473ContratoClienteId = new int[1] ;
         P009714_n473ContratoClienteId = new bool[] {false} ;
         P009714_A460ContratoTaxa = new decimal[1] ;
         P009714_n460ContratoTaxa = new bool[] {false} ;
         P009714_A461ContratoSLA = new short[1] ;
         P009714_n461ContratoSLA = new bool[] {false} ;
         P009714_A462ContratoJurosMora = new decimal[1] ;
         P009714_n462ContratoJurosMora = new bool[] {false} ;
         P009714_A463ContratoIOFMinimo = new decimal[1] ;
         P009714_n463ContratoIOFMinimo = new bool[] {false} ;
         P009716_A376ProcedimentosMedicosId = new int[1] ;
         P009716_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009716_A493ConvenioCategoriaId = new int[1] ;
         P009716_n493ConvenioCategoriaId = new bool[] {false} ;
         P009716_A410ConvenioId = new int[1] ;
         P009716_n410ConvenioId = new bool[] {false} ;
         P009716_A323PropostaId = new int[1] ;
         P009716_A328PropostaCratedBy = new short[1] ;
         P009716_n328PropostaCratedBy = new bool[] {false} ;
         P009716_A411ConvenioDescricao = new string[] {""} ;
         P009716_n411ConvenioDescricao = new bool[] {false} ;
         P009716_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P009716_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P009716_A497ConvenioVencimentoMes = new short[1] ;
         P009716_n497ConvenioVencimentoMes = new bool[] {false} ;
         P009716_A496ConvenioVencimentoAno = new short[1] ;
         P009716_n496ConvenioVencimentoAno = new bool[] {false} ;
         P009716_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         P009716_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         P009716_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         P009716_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         P009716_A501PropostaTaxaAdministrativa = new decimal[1] ;
         P009716_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         P009716_A326PropostaValor = new decimal[1] ;
         P009716_n326PropostaValor = new bool[] {false} ;
         A411ConvenioDescricao = "";
         A494ConvenioCategoriaDescricao = "";
         A378ProcedimentosMedicosDescricao = "";
         AV19ValorExtenso = "";
         P009717_A133SecUserId = new short[1] ;
         P009717_A226SecUserOwnerId = new int[1] ;
         P009717_n226SecUserOwnerId = new bool[] {false} ;
         P009718_A186MunicipioCodigo = new string[] {""} ;
         P009718_n186MunicipioCodigo = new bool[] {false} ;
         P009718_A402BancoId = new int[1] ;
         P009718_n402BancoId = new bool[] {false} ;
         P009718_A437ResponsavelNacionalidade = new int[1] ;
         P009718_n437ResponsavelNacionalidade = new bool[] {false} ;
         P009718_A442ResponsavelProfissao = new int[1] ;
         P009718_n442ResponsavelProfissao = new bool[] {false} ;
         P009718_A168ClienteId = new int[1] ;
         P009718_n168ClienteId = new bool[] {false} ;
         P009718_A170ClienteRazaoSocial = new string[] {""} ;
         P009718_n170ClienteRazaoSocial = new bool[] {false} ;
         P009718_A183EnderecoLogradouro = new string[] {""} ;
         P009718_n183EnderecoLogradouro = new bool[] {false} ;
         P009718_A187MunicipioNome = new string[] {""} ;
         P009718_n187MunicipioNome = new bool[] {false} ;
         P009718_A182EnderecoCEP = new string[] {""} ;
         P009718_n182EnderecoCEP = new bool[] {false} ;
         P009718_A189MunicipioUF = new string[] {""} ;
         P009718_n189MunicipioUF = new bool[] {false} ;
         P009718_A191EnderecoComplemento = new string[] {""} ;
         P009718_n191EnderecoComplemento = new bool[] {false} ;
         P009718_A190EnderecoNumero = new string[] {""} ;
         P009718_n190EnderecoNumero = new bool[] {false} ;
         P009718_A184EnderecoBairro = new string[] {""} ;
         P009718_n184EnderecoBairro = new bool[] {false} ;
         P009718_A436ResponsavelNome = new string[] {""} ;
         P009718_n436ResponsavelNome = new bool[] {false} ;
         P009718_A447ResponsavelCPF = new string[] {""} ;
         P009718_n447ResponsavelCPF = new bool[] {false} ;
         P009718_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P009718_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P009718_A439ResponsavelEstadoCivil = new string[] {""} ;
         P009718_n439ResponsavelEstadoCivil = new bool[] {false} ;
         P009718_A443ResponsavelProfissaoNome = new string[] {""} ;
         P009718_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P009718_A576ResponsavelRG = new long[1] ;
         P009718_n576ResponsavelRG = new bool[] {false} ;
         P009718_A449ResponsavelLogradouro = new string[] {""} ;
         P009718_n449ResponsavelLogradouro = new bool[] {false} ;
         P009718_A444ResponsavelMunicipio = new string[] {""} ;
         P009718_n444ResponsavelMunicipio = new bool[] {false} ;
         P009718_A448ResponsavelCEP = new string[] {""} ;
         P009718_n448ResponsavelCEP = new bool[] {false} ;
         P009718_A446ResponsavelMunicipioUF = new string[] {""} ;
         P009718_n446ResponsavelMunicipioUF = new bool[] {false} ;
         P009718_A453ResponsavelComplemento = new string[] {""} ;
         P009718_n453ResponsavelComplemento = new bool[] {false} ;
         P009718_A452ResponsavelLogradouroNumero = new int[1] ;
         P009718_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         P009718_A456ResponsavelEmail = new string[] {""} ;
         P009718_n456ResponsavelEmail = new bool[] {false} ;
         P009718_A403BancoNome = new string[] {""} ;
         P009718_n403BancoNome = new bool[] {false} ;
         P009718_A400ContaAgencia = new string[] {""} ;
         P009718_n400ContaAgencia = new bool[] {false} ;
         P009718_A401ContaNumero = new string[] {""} ;
         P009718_n401ContaNumero = new bool[] {false} ;
         P009718_A539ClientePix = new string[] {""} ;
         P009718_n539ClientePix = new bool[] {false} ;
         P009718_A169ClienteDocumento = new string[] {""} ;
         P009718_n169ClienteDocumento = new bool[] {false} ;
         P009718_A455ResponsavelNumero = new int[1] ;
         P009718_n455ResponsavelNumero = new bool[] {false} ;
         P009718_A454ResponsavelDDD = new short[1] ;
         P009718_n454ResponsavelDDD = new bool[] {false} ;
         A446ResponsavelMunicipioUF = "";
         A400ContaAgencia = "";
         A401ContaNumero = "";
         A539ClientePix = "";
         A577ResponsavelCelular_F = "";
         GXt_char3 = "";
         GXt_char2 = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pralimentatags__default(),
            new Object[][] {
                new Object[] {
               P00972_A323PropostaId, P00972_A553PropostaResponsavelId, P00972_n553PropostaResponsavelId
               }
               , new Object[] {
               P00973_A227ContratoId, P00973_A473ContratoClienteId, P00973_n473ContratoClienteId
               }
               , new Object[] {
               P00979_A192TipoClienteId, P00979_n192TipoClienteId, P00979_A186MunicipioCodigo, P00979_n186MunicipioCodigo, P00979_A444ResponsavelMunicipio, P00979_n444ResponsavelMunicipio, P00979_A457EspecialidadeId, P00979_n457EspecialidadeId, P00979_A597EspecialidadeCreatedBy, P00979_n597EspecialidadeCreatedBy,
               P00979_A437ResponsavelNacionalidade, P00979_n437ResponsavelNacionalidade, P00979_A484ClienteNacionalidade, P00979_n484ClienteNacionalidade, P00979_A442ResponsavelProfissao, P00979_n442ResponsavelProfissao, P00979_A487ClienteProfissao, P00979_n487ClienteProfissao, P00979_A168ClienteId, P00979_A170ClienteRazaoSocial,
               P00979_n170ClienteRazaoSocial, P00979_A204ContatoTelefoneDDI, P00979_n204ContatoTelefoneDDI, P00979_A199ContatoDDI, P00979_n199ContatoDDI, P00979_A201ContatoEmail, P00979_n201ContatoEmail, P00979_A191EnderecoComplemento, P00979_n191EnderecoComplemento, P00979_A190EnderecoNumero,
               P00979_n190EnderecoNumero, P00979_A189MunicipioUF, P00979_n189MunicipioUF, P00979_A187MunicipioNome, P00979_n187MunicipioNome, P00979_A185EnderecoCidade, P00979_n185EnderecoCidade, P00979_A184EnderecoBairro, P00979_n184EnderecoBairro, P00979_A183EnderecoLogradouro,
               P00979_n183EnderecoLogradouro, P00979_A182EnderecoCEP, P00979_n182EnderecoCEP, P00979_A181EnderecoTipo, P00979_n181EnderecoTipo, P00979_A141SecUserName, P00979_n141SecUserName, P00979_A193TipoClienteDescricao, P00979_n193TipoClienteDescricao, P00979_A172ClienteTipoPessoa,
               P00979_n172ClienteTipoPessoa, P00979_A169ClienteDocumento, P00979_n169ClienteDocumento, P00979_A421ClienteRG, P00979_n421ClienteRG, P00979_A436ResponsavelNome, P00979_n436ResponsavelNome, P00979_A438ResponsavelNacionalidadeNome, P00979_n438ResponsavelNacionalidadeNome, P00979_A439ResponsavelEstadoCivil,
               P00979_n439ResponsavelEstadoCivil, P00979_A443ResponsavelProfissaoNome, P00979_n443ResponsavelProfissaoNome, P00979_A447ResponsavelCPF, P00979_n447ResponsavelCPF, P00979_A448ResponsavelCEP, P00979_n448ResponsavelCEP, P00979_A449ResponsavelLogradouro, P00979_n449ResponsavelLogradouro, P00979_A450ResponsavelBairro,
               P00979_n450ResponsavelBairro, P00979_A451ResponsavelCidade, P00979_n451ResponsavelCidade, P00979_A445ResponsavelMunicipioNome, P00979_n445ResponsavelMunicipioNome, P00979_A452ResponsavelLogradouroNumero, P00979_n452ResponsavelLogradouroNumero, P00979_A453ResponsavelComplemento, P00979_n453ResponsavelComplemento, P00979_A454ResponsavelDDD,
               P00979_n454ResponsavelDDD, P00979_A455ResponsavelNumero, P00979_n455ResponsavelNumero, P00979_A456ResponsavelEmail, P00979_n456ResponsavelEmail, P00979_A485ClienteNacionalidadeNome, P00979_n485ClienteNacionalidadeNome, P00979_A486ClienteEstadoCivil, P00979_n486ClienteEstadoCivil, P00979_A488ClienteProfissaoNome,
               P00979_n488ClienteProfissaoNome, P00979_A311ClienteValorAReceber_F, P00979_n311ClienteValorAReceber_F, P00979_A310ClienteValorAPagar_F, P00979_n310ClienteValorAPagar_F, P00979_A202ContatoTelefoneNumero, P00979_n202ContatoTelefoneNumero, P00979_A203ContatoTelefoneDDD, P00979_n203ContatoTelefoneDDD, P00979_A200ContatoNumero,
               P00979_n200ContatoNumero, P00979_A198ContatoDDD, P00979_n198ContatoDDD
               }
               , new Object[] {
               P009710_A480ConfiguracoesTestemunhasDocumento, P009710_n480ConfiguracoesTestemunhasDocumento, P009710_A479ConfiguracoesTestemunhasNome, P009710_n479ConfiguracoesTestemunhasNome, P009710_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               P009712_A518ReembolsoId, P009712_A542ReembolsoPropostaId, P009712_n542ReembolsoPropostaId, P009712_A543ReembolsoPropostaValor, P009712_n543ReembolsoPropostaValor, P009712_A645ReembolsoValorReembolsado_F, P009712_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               P009713_A464EmpresaBancoId, P009713_n464EmpresaBancoId, P009713_A250EmpresaNomeFantasia, P009713_n250EmpresaNomeFantasia, P009713_A251EmpresaRazaoSocial, P009713_n251EmpresaRazaoSocial, P009713_A403BancoNome, P009713_n403BancoNome, P009713_A465EmpresaAgencia, P009713_n465EmpresaAgencia,
               P009713_A466EmpresaAgenciaDigito, P009713_n466EmpresaAgenciaDigito, P009713_A467EmpresaConta, P009713_n467EmpresaConta, P009713_A468EmpresaPix, P009713_n468EmpresaPix, P009713_A469EmpresaPixTipo, P009713_n469EmpresaPixTipo, P009713_A470EmpresaEmail, P009713_n470EmpresaEmail,
               P009713_A249EmpresaId
               }
               , new Object[] {
               P009714_A227ContratoId, P009714_A473ContratoClienteId, P009714_n473ContratoClienteId, P009714_A460ContratoTaxa, P009714_n460ContratoTaxa, P009714_A461ContratoSLA, P009714_n461ContratoSLA, P009714_A462ContratoJurosMora, P009714_n462ContratoJurosMora, P009714_A463ContratoIOFMinimo,
               P009714_n463ContratoIOFMinimo
               }
               , new Object[] {
               P009716_A376ProcedimentosMedicosId, P009716_n376ProcedimentosMedicosId, P009716_A493ConvenioCategoriaId, P009716_n493ConvenioCategoriaId, P009716_A410ConvenioId, P009716_n410ConvenioId, P009716_A323PropostaId, P009716_A328PropostaCratedBy, P009716_n328PropostaCratedBy, P009716_A411ConvenioDescricao,
               P009716_n411ConvenioDescricao, P009716_A494ConvenioCategoriaDescricao, P009716_n494ConvenioCategoriaDescricao, P009716_A497ConvenioVencimentoMes, P009716_n497ConvenioVencimentoMes, P009716_A496ConvenioVencimentoAno, P009716_n496ConvenioVencimentoAno, P009716_A378ProcedimentosMedicosDescricao, P009716_n378ProcedimentosMedicosDescricao, P009716_A650PropostaValorTaxaClinica_F,
               P009716_n650PropostaValorTaxaClinica_F, P009716_A501PropostaTaxaAdministrativa, P009716_n501PropostaTaxaAdministrativa, P009716_A326PropostaValor, P009716_n326PropostaValor
               }
               , new Object[] {
               P009717_A133SecUserId, P009717_A226SecUserOwnerId, P009717_n226SecUserOwnerId
               }
               , new Object[] {
               P009718_A186MunicipioCodigo, P009718_n186MunicipioCodigo, P009718_A402BancoId, P009718_n402BancoId, P009718_A437ResponsavelNacionalidade, P009718_n437ResponsavelNacionalidade, P009718_A442ResponsavelProfissao, P009718_n442ResponsavelProfissao, P009718_A168ClienteId, P009718_A170ClienteRazaoSocial,
               P009718_n170ClienteRazaoSocial, P009718_A183EnderecoLogradouro, P009718_n183EnderecoLogradouro, P009718_A187MunicipioNome, P009718_n187MunicipioNome, P009718_A182EnderecoCEP, P009718_n182EnderecoCEP, P009718_A189MunicipioUF, P009718_n189MunicipioUF, P009718_A191EnderecoComplemento,
               P009718_n191EnderecoComplemento, P009718_A190EnderecoNumero, P009718_n190EnderecoNumero, P009718_A184EnderecoBairro, P009718_n184EnderecoBairro, P009718_A436ResponsavelNome, P009718_n436ResponsavelNome, P009718_A447ResponsavelCPF, P009718_n447ResponsavelCPF, P009718_A438ResponsavelNacionalidadeNome,
               P009718_n438ResponsavelNacionalidadeNome, P009718_A439ResponsavelEstadoCivil, P009718_n439ResponsavelEstadoCivil, P009718_A443ResponsavelProfissaoNome, P009718_n443ResponsavelProfissaoNome, P009718_A576ResponsavelRG, P009718_n576ResponsavelRG, P009718_A449ResponsavelLogradouro, P009718_n449ResponsavelLogradouro, P009718_A444ResponsavelMunicipio,
               P009718_n444ResponsavelMunicipio, P009718_A448ResponsavelCEP, P009718_n448ResponsavelCEP, P009718_A446ResponsavelMunicipioUF, P009718_n446ResponsavelMunicipioUF, P009718_A453ResponsavelComplemento, P009718_n453ResponsavelComplemento, P009718_A452ResponsavelLogradouroNumero, P009718_n452ResponsavelLogradouroNumero, P009718_A456ResponsavelEmail,
               P009718_n456ResponsavelEmail, P009718_A403BancoNome, P009718_n403BancoNome, P009718_A400ContaAgencia, P009718_n400ContaAgencia, P009718_A401ContaNumero, P009718_n401ContaNumero, P009718_A539ClientePix, P009718_n539ClientePix, P009718_A169ClienteDocumento,
               P009718_n169ClienteDocumento, P009718_A455ResponsavelNumero, P009718_n455ResponsavelNumero, P009718_A454ResponsavelDDD, P009718_n454ResponsavelDDD
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A192TipoClienteId ;
      private short A597EspecialidadeCreatedBy ;
      private short A204ContatoTelefoneDDI ;
      private short A199ContatoDDI ;
      private short A454ResponsavelDDD ;
      private short A203ContatoTelefoneDDD ;
      private short A198ContatoDDD ;
      private short AV16i ;
      private short A461ContratoSLA ;
      private short A328PropostaCratedBy ;
      private short A497ConvenioVencimentoMes ;
      private short A496ConvenioVencimentoAno ;
      private short A133SecUserId ;
      private int AV13PropostaId ;
      private int AV14ContratoId ;
      private int A323PropostaId ;
      private int A553PropostaResponsavelId ;
      private int AV12ClienteId ;
      private int A227ContratoId ;
      private int A473ContratoClienteId ;
      private int AV22GXV1 ;
      private int A457EspecialidadeId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A168ClienteId ;
      private int A452ResponsavelLogradouroNumero ;
      private int A455ResponsavelNumero ;
      private int AV24GXV2 ;
      private int A478ConfiguracoesTestemunhasId ;
      private int A518ReembolsoId ;
      private int A542ReembolsoPropostaId ;
      private int AV27GXV3 ;
      private int A464EmpresaBancoId ;
      private int A465EmpresaAgencia ;
      private int A466EmpresaAgenciaDigito ;
      private int A467EmpresaConta ;
      private int A249EmpresaId ;
      private int AV29GXV4 ;
      private int AV31GXV5 ;
      private int A376ProcedimentosMedicosId ;
      private int A493ConvenioCategoriaId ;
      private int A410ConvenioId ;
      private int AV17ClinicaClienteId ;
      private int AV33GXV6 ;
      private int A226SecUserOwnerId ;
      private int AV18secuserownerid ;
      private int A402BancoId ;
      private int AV36GXV7 ;
      private long A421ClienteRG ;
      private long A202ContatoTelefoneNumero ;
      private long A200ContatoNumero ;
      private long A576ResponsavelRG ;
      private decimal A311ClienteValorAReceber_F ;
      private decimal A310ClienteValorAPagar_F ;
      private decimal A543ReembolsoPropostaValor ;
      private decimal A645ReembolsoValorReembolsado_F ;
      private decimal A460ContratoTaxa ;
      private decimal A462ContratoJurosMora ;
      private decimal A463ContratoIOFMinimo ;
      private decimal A650PropostaValorTaxaClinica_F ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A326PropostaValor ;
      private decimal A575PropostaTaxa_F ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string GXt_char1 ;
      private DateTime AV15Date ;
      private bool n553PropostaResponsavelId ;
      private bool n473ContratoClienteId ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n457EspecialidadeId ;
      private bool n597EspecialidadeCreatedBy ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n204ContatoTelefoneDDI ;
      private bool n199ContatoDDI ;
      private bool n201ContatoEmail ;
      private bool n191EnderecoComplemento ;
      private bool n190EnderecoNumero ;
      private bool n189MunicipioUF ;
      private bool n187MunicipioNome ;
      private bool n185EnderecoCidade ;
      private bool n184EnderecoBairro ;
      private bool n183EnderecoLogradouro ;
      private bool n182EnderecoCEP ;
      private bool n181EnderecoTipo ;
      private bool n141SecUserName ;
      private bool n193TipoClienteDescricao ;
      private bool n172ClienteTipoPessoa ;
      private bool n169ClienteDocumento ;
      private bool n421ClienteRG ;
      private bool n436ResponsavelNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n439ResponsavelEstadoCivil ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n447ResponsavelCPF ;
      private bool n448ResponsavelCEP ;
      private bool n449ResponsavelLogradouro ;
      private bool n450ResponsavelBairro ;
      private bool n451ResponsavelCidade ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n452ResponsavelLogradouroNumero ;
      private bool n453ResponsavelComplemento ;
      private bool n454ResponsavelDDD ;
      private bool n455ResponsavelNumero ;
      private bool n456ResponsavelEmail ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n486ClienteEstadoCivil ;
      private bool n488ClienteProfissaoNome ;
      private bool n311ClienteValorAReceber_F ;
      private bool n310ClienteValorAPagar_F ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n200ContatoNumero ;
      private bool n198ContatoDDD ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n518ReembolsoId ;
      private bool n542ReembolsoPropostaId ;
      private bool n543ReembolsoPropostaValor ;
      private bool n645ReembolsoValorReembolsado_F ;
      private bool n464EmpresaBancoId ;
      private bool n250EmpresaNomeFantasia ;
      private bool n251EmpresaRazaoSocial ;
      private bool n403BancoNome ;
      private bool n465EmpresaAgencia ;
      private bool n466EmpresaAgenciaDigito ;
      private bool n467EmpresaConta ;
      private bool n468EmpresaPix ;
      private bool n469EmpresaPixTipo ;
      private bool n470EmpresaEmail ;
      private bool n460ContratoTaxa ;
      private bool n461ContratoSLA ;
      private bool n462ContratoJurosMora ;
      private bool n463ContratoIOFMinimo ;
      private bool n376ProcedimentosMedicosId ;
      private bool n493ConvenioCategoriaId ;
      private bool n410ConvenioId ;
      private bool n328PropostaCratedBy ;
      private bool n411ConvenioDescricao ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n497ConvenioVencimentoMes ;
      private bool n496ConvenioVencimentoAno ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n650PropostaValorTaxaClinica_F ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n326PropostaValor ;
      private bool n226SecUserOwnerId ;
      private bool n402BancoId ;
      private bool n576ResponsavelRG ;
      private bool n446ResponsavelMunicipioUF ;
      private bool n400ContaAgencia ;
      private bool n401ContaNumero ;
      private bool n539ClientePix ;
      private string A378ProcedimentosMedicosDescricao ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string A170ClienteRazaoSocial ;
      private string A201ContatoEmail ;
      private string A191EnderecoComplemento ;
      private string A190EnderecoNumero ;
      private string A189MunicipioUF ;
      private string A187MunicipioNome ;
      private string A185EnderecoCidade ;
      private string A184EnderecoBairro ;
      private string A183EnderecoLogradouro ;
      private string A182EnderecoCEP ;
      private string A181EnderecoTipo ;
      private string A141SecUserName ;
      private string A193TipoClienteDescricao ;
      private string A172ClienteTipoPessoa ;
      private string A169ClienteDocumento ;
      private string A436ResponsavelNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A439ResponsavelEstadoCivil ;
      private string A443ResponsavelProfissaoNome ;
      private string A447ResponsavelCPF ;
      private string A448ResponsavelCEP ;
      private string A449ResponsavelLogradouro ;
      private string A450ResponsavelBairro ;
      private string A451ResponsavelCidade ;
      private string A445ResponsavelMunicipioNome ;
      private string A453ResponsavelComplemento ;
      private string A456ResponsavelEmail ;
      private string A485ClienteNacionalidadeNome ;
      private string A486ClienteEstadoCivil ;
      private string A488ClienteProfissaoNome ;
      private string A206ClienteCelular_F ;
      private string A205ClienteTelefone_F ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string A250EmpresaNomeFantasia ;
      private string A251EmpresaRazaoSocial ;
      private string A403BancoNome ;
      private string A468EmpresaPix ;
      private string A469EmpresaPixTipo ;
      private string A470EmpresaEmail ;
      private string A411ConvenioDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV19ValorExtenso ;
      private string A446ResponsavelMunicipioUF ;
      private string A400ContaAgencia ;
      private string A401ContaNumero ;
      private string A539ClientePix ;
      private string A577ResponsavelCelular_F ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdMapearTags> AV8Array_SDMapearTags ;
      private SdtSdtListaTags AV9SdtListaTags ;
      private IDataStoreProvider pr_default ;
      private int[] P00972_A323PropostaId ;
      private int[] P00972_A553PropostaResponsavelId ;
      private bool[] P00972_n553PropostaResponsavelId ;
      private int[] P00973_A227ContratoId ;
      private int[] P00973_A473ContratoClienteId ;
      private bool[] P00973_n473ContratoClienteId ;
      private SdtSdMapearTags AV10SDMapearTags ;
      private short[] P00979_A192TipoClienteId ;
      private bool[] P00979_n192TipoClienteId ;
      private string[] P00979_A186MunicipioCodigo ;
      private bool[] P00979_n186MunicipioCodigo ;
      private string[] P00979_A444ResponsavelMunicipio ;
      private bool[] P00979_n444ResponsavelMunicipio ;
      private int[] P00979_A457EspecialidadeId ;
      private bool[] P00979_n457EspecialidadeId ;
      private short[] P00979_A597EspecialidadeCreatedBy ;
      private bool[] P00979_n597EspecialidadeCreatedBy ;
      private int[] P00979_A437ResponsavelNacionalidade ;
      private bool[] P00979_n437ResponsavelNacionalidade ;
      private int[] P00979_A484ClienteNacionalidade ;
      private bool[] P00979_n484ClienteNacionalidade ;
      private int[] P00979_A442ResponsavelProfissao ;
      private bool[] P00979_n442ResponsavelProfissao ;
      private int[] P00979_A487ClienteProfissao ;
      private bool[] P00979_n487ClienteProfissao ;
      private int[] P00979_A168ClienteId ;
      private bool[] P00979_n168ClienteId ;
      private string[] P00979_A170ClienteRazaoSocial ;
      private bool[] P00979_n170ClienteRazaoSocial ;
      private short[] P00979_A204ContatoTelefoneDDI ;
      private bool[] P00979_n204ContatoTelefoneDDI ;
      private short[] P00979_A199ContatoDDI ;
      private bool[] P00979_n199ContatoDDI ;
      private string[] P00979_A201ContatoEmail ;
      private bool[] P00979_n201ContatoEmail ;
      private string[] P00979_A191EnderecoComplemento ;
      private bool[] P00979_n191EnderecoComplemento ;
      private string[] P00979_A190EnderecoNumero ;
      private bool[] P00979_n190EnderecoNumero ;
      private string[] P00979_A189MunicipioUF ;
      private bool[] P00979_n189MunicipioUF ;
      private string[] P00979_A187MunicipioNome ;
      private bool[] P00979_n187MunicipioNome ;
      private string[] P00979_A185EnderecoCidade ;
      private bool[] P00979_n185EnderecoCidade ;
      private string[] P00979_A184EnderecoBairro ;
      private bool[] P00979_n184EnderecoBairro ;
      private string[] P00979_A183EnderecoLogradouro ;
      private bool[] P00979_n183EnderecoLogradouro ;
      private string[] P00979_A182EnderecoCEP ;
      private bool[] P00979_n182EnderecoCEP ;
      private string[] P00979_A181EnderecoTipo ;
      private bool[] P00979_n181EnderecoTipo ;
      private string[] P00979_A141SecUserName ;
      private bool[] P00979_n141SecUserName ;
      private string[] P00979_A193TipoClienteDescricao ;
      private bool[] P00979_n193TipoClienteDescricao ;
      private string[] P00979_A172ClienteTipoPessoa ;
      private bool[] P00979_n172ClienteTipoPessoa ;
      private string[] P00979_A169ClienteDocumento ;
      private bool[] P00979_n169ClienteDocumento ;
      private long[] P00979_A421ClienteRG ;
      private bool[] P00979_n421ClienteRG ;
      private string[] P00979_A436ResponsavelNome ;
      private bool[] P00979_n436ResponsavelNome ;
      private string[] P00979_A438ResponsavelNacionalidadeNome ;
      private bool[] P00979_n438ResponsavelNacionalidadeNome ;
      private string[] P00979_A439ResponsavelEstadoCivil ;
      private bool[] P00979_n439ResponsavelEstadoCivil ;
      private string[] P00979_A443ResponsavelProfissaoNome ;
      private bool[] P00979_n443ResponsavelProfissaoNome ;
      private string[] P00979_A447ResponsavelCPF ;
      private bool[] P00979_n447ResponsavelCPF ;
      private string[] P00979_A448ResponsavelCEP ;
      private bool[] P00979_n448ResponsavelCEP ;
      private string[] P00979_A449ResponsavelLogradouro ;
      private bool[] P00979_n449ResponsavelLogradouro ;
      private string[] P00979_A450ResponsavelBairro ;
      private bool[] P00979_n450ResponsavelBairro ;
      private string[] P00979_A451ResponsavelCidade ;
      private bool[] P00979_n451ResponsavelCidade ;
      private string[] P00979_A445ResponsavelMunicipioNome ;
      private bool[] P00979_n445ResponsavelMunicipioNome ;
      private int[] P00979_A452ResponsavelLogradouroNumero ;
      private bool[] P00979_n452ResponsavelLogradouroNumero ;
      private string[] P00979_A453ResponsavelComplemento ;
      private bool[] P00979_n453ResponsavelComplemento ;
      private short[] P00979_A454ResponsavelDDD ;
      private bool[] P00979_n454ResponsavelDDD ;
      private int[] P00979_A455ResponsavelNumero ;
      private bool[] P00979_n455ResponsavelNumero ;
      private string[] P00979_A456ResponsavelEmail ;
      private bool[] P00979_n456ResponsavelEmail ;
      private string[] P00979_A485ClienteNacionalidadeNome ;
      private bool[] P00979_n485ClienteNacionalidadeNome ;
      private string[] P00979_A486ClienteEstadoCivil ;
      private bool[] P00979_n486ClienteEstadoCivil ;
      private string[] P00979_A488ClienteProfissaoNome ;
      private bool[] P00979_n488ClienteProfissaoNome ;
      private decimal[] P00979_A311ClienteValorAReceber_F ;
      private bool[] P00979_n311ClienteValorAReceber_F ;
      private decimal[] P00979_A310ClienteValorAPagar_F ;
      private bool[] P00979_n310ClienteValorAPagar_F ;
      private long[] P00979_A202ContatoTelefoneNumero ;
      private bool[] P00979_n202ContatoTelefoneNumero ;
      private short[] P00979_A203ContatoTelefoneDDD ;
      private bool[] P00979_n203ContatoTelefoneDDD ;
      private long[] P00979_A200ContatoNumero ;
      private bool[] P00979_n200ContatoNumero ;
      private short[] P00979_A198ContatoDDD ;
      private bool[] P00979_n198ContatoDDD ;
      private SdtSdMapearTags_TagsItem AV11SdMapearTagsTags ;
      private string[] P009710_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] P009710_n480ConfiguracoesTestemunhasDocumento ;
      private string[] P009710_A479ConfiguracoesTestemunhasNome ;
      private bool[] P009710_n479ConfiguracoesTestemunhasNome ;
      private int[] P009710_A478ConfiguracoesTestemunhasId ;
      private int[] P009712_A518ReembolsoId ;
      private bool[] P009712_n518ReembolsoId ;
      private int[] P009712_A542ReembolsoPropostaId ;
      private bool[] P009712_n542ReembolsoPropostaId ;
      private decimal[] P009712_A543ReembolsoPropostaValor ;
      private bool[] P009712_n543ReembolsoPropostaValor ;
      private decimal[] P009712_A645ReembolsoValorReembolsado_F ;
      private bool[] P009712_n645ReembolsoValorReembolsado_F ;
      private int[] P009713_A464EmpresaBancoId ;
      private bool[] P009713_n464EmpresaBancoId ;
      private string[] P009713_A250EmpresaNomeFantasia ;
      private bool[] P009713_n250EmpresaNomeFantasia ;
      private string[] P009713_A251EmpresaRazaoSocial ;
      private bool[] P009713_n251EmpresaRazaoSocial ;
      private string[] P009713_A403BancoNome ;
      private bool[] P009713_n403BancoNome ;
      private int[] P009713_A465EmpresaAgencia ;
      private bool[] P009713_n465EmpresaAgencia ;
      private int[] P009713_A466EmpresaAgenciaDigito ;
      private bool[] P009713_n466EmpresaAgenciaDigito ;
      private int[] P009713_A467EmpresaConta ;
      private bool[] P009713_n467EmpresaConta ;
      private string[] P009713_A468EmpresaPix ;
      private bool[] P009713_n468EmpresaPix ;
      private string[] P009713_A469EmpresaPixTipo ;
      private bool[] P009713_n469EmpresaPixTipo ;
      private string[] P009713_A470EmpresaEmail ;
      private bool[] P009713_n470EmpresaEmail ;
      private int[] P009713_A249EmpresaId ;
      private int[] P009714_A227ContratoId ;
      private int[] P009714_A473ContratoClienteId ;
      private bool[] P009714_n473ContratoClienteId ;
      private decimal[] P009714_A460ContratoTaxa ;
      private bool[] P009714_n460ContratoTaxa ;
      private short[] P009714_A461ContratoSLA ;
      private bool[] P009714_n461ContratoSLA ;
      private decimal[] P009714_A462ContratoJurosMora ;
      private bool[] P009714_n462ContratoJurosMora ;
      private decimal[] P009714_A463ContratoIOFMinimo ;
      private bool[] P009714_n463ContratoIOFMinimo ;
      private int[] P009716_A376ProcedimentosMedicosId ;
      private bool[] P009716_n376ProcedimentosMedicosId ;
      private int[] P009716_A493ConvenioCategoriaId ;
      private bool[] P009716_n493ConvenioCategoriaId ;
      private int[] P009716_A410ConvenioId ;
      private bool[] P009716_n410ConvenioId ;
      private int[] P009716_A323PropostaId ;
      private short[] P009716_A328PropostaCratedBy ;
      private bool[] P009716_n328PropostaCratedBy ;
      private string[] P009716_A411ConvenioDescricao ;
      private bool[] P009716_n411ConvenioDescricao ;
      private string[] P009716_A494ConvenioCategoriaDescricao ;
      private bool[] P009716_n494ConvenioCategoriaDescricao ;
      private short[] P009716_A497ConvenioVencimentoMes ;
      private bool[] P009716_n497ConvenioVencimentoMes ;
      private short[] P009716_A496ConvenioVencimentoAno ;
      private bool[] P009716_n496ConvenioVencimentoAno ;
      private string[] P009716_A378ProcedimentosMedicosDescricao ;
      private bool[] P009716_n378ProcedimentosMedicosDescricao ;
      private decimal[] P009716_A650PropostaValorTaxaClinica_F ;
      private bool[] P009716_n650PropostaValorTaxaClinica_F ;
      private decimal[] P009716_A501PropostaTaxaAdministrativa ;
      private bool[] P009716_n501PropostaTaxaAdministrativa ;
      private decimal[] P009716_A326PropostaValor ;
      private bool[] P009716_n326PropostaValor ;
      private short[] P009717_A133SecUserId ;
      private int[] P009717_A226SecUserOwnerId ;
      private bool[] P009717_n226SecUserOwnerId ;
      private string[] P009718_A186MunicipioCodigo ;
      private bool[] P009718_n186MunicipioCodigo ;
      private int[] P009718_A402BancoId ;
      private bool[] P009718_n402BancoId ;
      private int[] P009718_A437ResponsavelNacionalidade ;
      private bool[] P009718_n437ResponsavelNacionalidade ;
      private int[] P009718_A442ResponsavelProfissao ;
      private bool[] P009718_n442ResponsavelProfissao ;
      private int[] P009718_A168ClienteId ;
      private bool[] P009718_n168ClienteId ;
      private string[] P009718_A170ClienteRazaoSocial ;
      private bool[] P009718_n170ClienteRazaoSocial ;
      private string[] P009718_A183EnderecoLogradouro ;
      private bool[] P009718_n183EnderecoLogradouro ;
      private string[] P009718_A187MunicipioNome ;
      private bool[] P009718_n187MunicipioNome ;
      private string[] P009718_A182EnderecoCEP ;
      private bool[] P009718_n182EnderecoCEP ;
      private string[] P009718_A189MunicipioUF ;
      private bool[] P009718_n189MunicipioUF ;
      private string[] P009718_A191EnderecoComplemento ;
      private bool[] P009718_n191EnderecoComplemento ;
      private string[] P009718_A190EnderecoNumero ;
      private bool[] P009718_n190EnderecoNumero ;
      private string[] P009718_A184EnderecoBairro ;
      private bool[] P009718_n184EnderecoBairro ;
      private string[] P009718_A436ResponsavelNome ;
      private bool[] P009718_n436ResponsavelNome ;
      private string[] P009718_A447ResponsavelCPF ;
      private bool[] P009718_n447ResponsavelCPF ;
      private string[] P009718_A438ResponsavelNacionalidadeNome ;
      private bool[] P009718_n438ResponsavelNacionalidadeNome ;
      private string[] P009718_A439ResponsavelEstadoCivil ;
      private bool[] P009718_n439ResponsavelEstadoCivil ;
      private string[] P009718_A443ResponsavelProfissaoNome ;
      private bool[] P009718_n443ResponsavelProfissaoNome ;
      private long[] P009718_A576ResponsavelRG ;
      private bool[] P009718_n576ResponsavelRG ;
      private string[] P009718_A449ResponsavelLogradouro ;
      private bool[] P009718_n449ResponsavelLogradouro ;
      private string[] P009718_A444ResponsavelMunicipio ;
      private bool[] P009718_n444ResponsavelMunicipio ;
      private string[] P009718_A448ResponsavelCEP ;
      private bool[] P009718_n448ResponsavelCEP ;
      private string[] P009718_A446ResponsavelMunicipioUF ;
      private bool[] P009718_n446ResponsavelMunicipioUF ;
      private string[] P009718_A453ResponsavelComplemento ;
      private bool[] P009718_n453ResponsavelComplemento ;
      private int[] P009718_A452ResponsavelLogradouroNumero ;
      private bool[] P009718_n452ResponsavelLogradouroNumero ;
      private string[] P009718_A456ResponsavelEmail ;
      private bool[] P009718_n456ResponsavelEmail ;
      private string[] P009718_A403BancoNome ;
      private bool[] P009718_n403BancoNome ;
      private string[] P009718_A400ContaAgencia ;
      private bool[] P009718_n400ContaAgencia ;
      private string[] P009718_A401ContaNumero ;
      private bool[] P009718_n401ContaNumero ;
      private string[] P009718_A539ClientePix ;
      private bool[] P009718_n539ClientePix ;
      private string[] P009718_A169ClienteDocumento ;
      private bool[] P009718_n169ClienteDocumento ;
      private int[] P009718_A455ResponsavelNumero ;
      private bool[] P009718_n455ResponsavelNumero ;
      private short[] P009718_A454ResponsavelDDD ;
      private bool[] P009718_n454ResponsavelDDD ;
      private SdtSdtListaTags aP3_SdtListaTags ;
   }

   public class pralimentatags__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00972;
          prmP00972 = new Object[] {
          new ParDef("AV13PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00973;
          prmP00973 = new Object[] {
          new ParDef("AV14ContratoId",GXType.Int32,6,0)
          };
          Object[] prmP00979;
          prmP00979 = new Object[] {
          new ParDef("AV12ClienteId",GXType.Int32,9,0)
          };
          string cmdBufferP00979;
          cmdBufferP00979=" SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.EspecialidadeId, T5.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteId, T1.ClienteRazaoSocial, T1.ContatoTelefoneDDI, T1.ContatoDDI, T1.ContatoEmail, T1.EnderecoComplemento, T1.EnderecoNumero, T3.MunicipioUF, T3.MunicipioNome, T1.EnderecoCidade, T1.EnderecoBairro, T1.EnderecoLogradouro, T1.EnderecoCEP, T1.EnderecoTipo, T6.SecUserName, T2.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteDocumento, T1.ClienteRG, T1.ResponsavelNome, T7.NacionalidadeNome AS ResponsavelNacionalidadeNome, T1.ResponsavelEstadoCivil, T9.ProfissaoNome AS ResponsavelProfissaoNome, T1.ResponsavelCPF, T1.ResponsavelCEP, T1.ResponsavelLogradouro, T1.ResponsavelBairro, T1.ResponsavelCidade, T4.MunicipioNome AS ResponsavelMunicipioNome, T1.ResponsavelLogradouroNumero, T1.ResponsavelComplemento, T1.ResponsavelDDD, T1.ResponsavelNumero, T1.ResponsavelEmail, T8.NacionalidadeNome AS ClienteNacionalidadeNome, T1.ClienteEstadoCivil, T10.ProfissaoNome AS ClienteProfissaoNome, COALESCE( T11.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T12.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, T1.ContatoTelefoneNumero, T1.ContatoTelefoneDDD, T1.ContatoNumero, T1.ContatoDDD FROM (((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Especialidade T5 ON T5.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T6 ON "
          + " T6.SecUserId = T5.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ClienteProfissao) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T16.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T15.ClienteId FROM (((Titulo T13 LEFT JOIN NotaFiscalParcelamento T14 ON T14.NotaFiscalParcelamentoID = T13.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T15 ON T15.NotaFiscalId = T14.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T17.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T17.TituloValor, 0) - COALESCE( T17.TituloDesconto, 0)) - COALESCE( T18.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T17.TituloId FROM (Titulo T17 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T17.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T18 ON T18.TituloId = T17.TituloId) ) T16 ON T16.TituloId = T13.TituloId) WHERE T1.ClienteId = T15.ClienteId GROUP BY T15.ClienteId ) T11 ON T11.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T13.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T13.TituloValor, 0) - COALESCE( T13.TituloDesconto, 0)) - COALESCE( T16.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T15.ClienteId FROM (((Titulo T13 LEFT JOIN NotaFiscalParcelamento T14 ON T14.NotaFiscalParcelamentoID = T13.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T15 ON T15.NotaFiscalId = T14.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T13.TituloId"
          + " = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T16 ON T16.TituloId = T13.TituloId) WHERE T1.ClienteId = T15.ClienteId GROUP BY T15.ClienteId ) T12 ON T12.ClienteId = T1.ClienteId) WHERE T1.ClienteId = :AV12ClienteId ORDER BY T1.ClienteId" ;
          Object[] prmP009710;
          prmP009710 = new Object[] {
          };
          Object[] prmP009712;
          prmP009712 = new Object[] {
          new ParDef("AV13PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP009713;
          prmP009713 = new Object[] {
          };
          Object[] prmP009714;
          prmP009714 = new Object[] {
          new ParDef("AV14ContratoId",GXType.Int32,6,0)
          };
          Object[] prmP009716;
          prmP009716 = new Object[] {
          new ParDef("AV13PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP009717;
          prmP009717 = new Object[] {
          new ParDef("AV17ClinicaClienteId",GXType.Int32,9,0)
          };
          Object[] prmP009718;
          prmP009718 = new Object[] {
          new ParDef("AV18secuserownerid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00972", "SELECT PropostaId, PropostaResponsavelId FROM Proposta WHERE PropostaId = :AV13PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00972,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00973", "SELECT ContratoId, ContratoClienteId FROM Contrato WHERE ContratoId = :AV14ContratoId ORDER BY ContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00973,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00979", cmdBufferP00979,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00979,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009710", "SELECT ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas ORDER BY ConfiguracoesTestemunhasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009710,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009712", "SELECT T1.ReembolsoId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T3.PropostaValor AS ReembolsoPropostaValor, COALESCE( T2.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM ((Reembolso T1 LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE T1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T2 ON T2.ReembolsoId = T1.ReembolsoId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) WHERE T1.ReembolsoPropostaId = :AV13PropostaId ORDER BY T1.ReembolsoPropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009712,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009713", "SELECT T1.EmpresaBancoId AS EmpresaBancoId, T1.EmpresaNomeFantasia, T1.EmpresaRazaoSocial, T2.BancoNome, T1.EmpresaAgencia, T1.EmpresaAgenciaDigito, T1.EmpresaConta, T1.EmpresaPix, T1.EmpresaPixTipo, T1.EmpresaEmail, T1.EmpresaId FROM (Empresa T1 LEFT JOIN Banco T2 ON T2.BancoId = T1.EmpresaBancoId) ORDER BY T1.EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009713,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009714", "SELECT ContratoId, ContratoClienteId, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo FROM Contrato WHERE ContratoId = :AV14ContratoId ORDER BY ContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009714,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009716", "SELECT T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T3.ConvenioId, T1.PropostaId, T1.PropostaCratedBy, T4.ConvenioDescricao, T3.ConvenioCategoriaDescricao, T1.ConvenioVencimentoMes, T1.ConvenioVencimentoAno, T2.ProcedimentosMedicosDescricao, COALESCE( T5.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F, T1.PropostaTaxaAdministrativa, T1.PropostaValor FROM ((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Convenio T4 ON T4.ConvenioId = T3.ConvenioId) LEFT JOIN LATERAL (SELECT SUM(T6.TituloValor) AS PropostaValorTaxaClinica_F, T6.TituloPropostaId AS TituloPropostaId FROM (((Titulo T6 LEFT JOIN NotaFiscalParcelamento T7 ON T7.NotaFiscalParcelamentoID = T6.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T8 ON T8.NotaFiscalId = T7.NotaFiscalId) LEFT JOIN Proposta T9 ON T9.PropostaId = T6.TituloPropostaId),  Proposta T10 WHERE (T1.PropostaId = T6.TituloPropostaId) AND (T6.TituloPropostaId = T10.PropostaId) AND (T8.ClienteId = T9.PropostaClinicaId) AND (T6.TituloPropostaTipo = ( 'TAXA')) GROUP BY T6.TituloPropostaId ) T5 ON T5.TituloPropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV13PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009716,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P009717", "SELECT SecUserId, SecUserOwnerId FROM SecUser WHERE SecUserId = :AV17ClinicaClienteId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009717,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009718", "SELECT T1.MunicipioCodigo, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteId, T1.ClienteRazaoSocial, T1.EnderecoLogradouro, T2.MunicipioNome, T1.EnderecoCEP, T2.MunicipioUF, T1.EnderecoComplemento, T1.EnderecoNumero, T1.EnderecoBairro, T1.ResponsavelNome, T1.ResponsavelCPF, T4.NacionalidadeNome AS ResponsavelNacionalidadeNome, T1.ResponsavelEstadoCivil, T5.ProfissaoNome AS ResponsavelProfissaoNome, T1.ResponsavelRG, T1.ResponsavelLogradouro, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.ResponsavelCEP, T6.MunicipioUF AS ResponsavelMunicipioUF, T1.ResponsavelComplemento, T1.ResponsavelLogradouroNumero, T1.ResponsavelEmail, T3.BancoNome, T1.ContaAgencia, T1.ContaNumero, T1.ClientePix, T1.ClienteDocumento, T1.ResponsavelNumero, T1.ResponsavelDDD FROM (((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Banco T3 ON T3.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T4 ON T4.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Profissao T5 ON T5.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Municipio T6 ON T6.MunicipioCodigo = T1.ResponsavelMunicipio) WHERE T1.ClienteId = :AV18secuserownerid ORDER BY T1.ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009718,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
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
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((long[]) buf[53])[0] = rslt.getLong(28);
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
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((int[]) buf[75])[0] = rslt.getInt(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((short[]) buf[79])[0] = rslt.getShort(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((int[]) buf[81])[0] = rslt.getInt(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((string[]) buf[85])[0] = rslt.getVarchar(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getVarchar(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((decimal[]) buf[91])[0] = rslt.getDecimal(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((decimal[]) buf[93])[0] = rslt.getDecimal(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((long[]) buf[95])[0] = rslt.getLong(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((short[]) buf[97])[0] = rslt.getShort(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((long[]) buf[99])[0] = rslt.getLong(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((short[]) buf[101])[0] = rslt.getShort(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
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
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((long[]) buf[35])[0] = rslt.getLong(19);
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
                ((int[]) buf[47])[0] = rslt.getInt(25);
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
                return;
       }
    }

 }

}
