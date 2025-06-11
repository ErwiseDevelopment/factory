using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Cliente" )]
   [XmlType(TypeName =  "Cliente" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtCliente : GxSilentTrnSdt
   {
      public SdtCliente( )
      {
      }

      public SdtCliente( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV168ClienteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV168ClienteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Cliente");
         metadata.Set("BT", "Cliente");
         metadata.Set("PK", "[ \"ClienteId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ConvenioId\" ],\"FKMap\":[ \"ClienteConvenio-ConvenioId\" ] },{ \"FK\":[ \"EspecialidadeId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MunicipioCodigo\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MunicipioCodigo\" ],\"FKMap\":[ \"ResponsavelMunicipio-MunicipioCodigo\" ] },{ \"FK\":[ \"NacionalidadeId\" ],\"FKMap\":[ \"ClienteNacionalidade-NacionalidadeId\" ] },{ \"FK\":[ \"NacionalidadeId\" ],\"FKMap\":[ \"ResponsavelNacionalidade-NacionalidadeId\" ] },{ \"FK\":[ \"ProfissaoId\" ],\"FKMap\":[ \"ClienteProfissao-ProfissaoId\" ] },{ \"FK\":[ \"ProfissaoId\" ],\"FKMap\":[ \"ResponsavelProfissao-ProfissaoId\" ] },{ \"FK\":[ \"TipoClienteId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clientedocumento_Z");
         state.Add("gxTpr_Clienterazaosocial_Z");
         state.Add("gxTpr_Clientenomefantasia_Z");
         state.Add("gxTpr_Clientedatanascimento_Z_Nullable");
         state.Add("gxTpr_Clientetipopessoa_Z");
         state.Add("gxTpr_Especialidadeid_Z");
         state.Add("gxTpr_Tipoclienteid_Z");
         state.Add("gxTpr_Tipoclientedescricao_Z");
         state.Add("gxTpr_Tipoclienteportal_Z");
         state.Add("gxTpr_Clientestatus_Z");
         state.Add("gxTpr_Clienteconvenio_Z");
         state.Add("gxTpr_Clienteconveniodescricao_Z");
         state.Add("gxTpr_Clientecreatedat_Z_Nullable");
         state.Add("gxTpr_Clienteupdatedat_Z_Nullable");
         state.Add("gxTpr_Clienteloguser_Z");
         state.Add("gxTpr_Clientenacionalidade_Z");
         state.Add("gxTpr_Clientenacionalidadenome_Z");
         state.Add("gxTpr_Clienteprofissao_Z");
         state.Add("gxTpr_Clienteprofissaonome_Z");
         state.Add("gxTpr_Clienteestadocivil_Z");
         state.Add("gxTpr_Secuserid_f_Z");
         state.Add("gxTpr_Enderecotipo_Z");
         state.Add("gxTpr_Enderecocep_Z");
         state.Add("gxTpr_Enderecologradouro_Z");
         state.Add("gxTpr_Enderecobairro_Z");
         state.Add("gxTpr_Enderecocidade_Z");
         state.Add("gxTpr_Municipiocodigo_Z");
         state.Add("gxTpr_Municipionome_Z");
         state.Add("gxTpr_Municipiouf_Z");
         state.Add("gxTpr_Endereconumero_Z");
         state.Add("gxTpr_Enderecocomplemento_Z");
         state.Add("gxTpr_Contatoemail_Z");
         state.Add("gxTpr_Contatoddd_Z");
         state.Add("gxTpr_Contatoddi_Z");
         state.Add("gxTpr_Contatonumero_Z");
         state.Add("gxTpr_Contatotelefonenumero_Z");
         state.Add("gxTpr_Contatotelefoneddd_Z");
         state.Add("gxTpr_Contatotelefoneddi_Z");
         state.Add("gxTpr_Clienterg_Z");
         state.Add("gxTpr_Clientetelefone_f_Z");
         state.Add("gxTpr_Clientecelular_f_Z");
         state.Add("gxTpr_Clienteqtdtitulos_f_Z");
         state.Add("gxTpr_Clientevalorapagar_f_Z");
         state.Add("gxTpr_Clientevalorareceber_f_Z");
         state.Add("gxTpr_Clientedepositotipo_Z");
         state.Add("gxTpr_Clientepixtipo_Z");
         state.Add("gxTpr_Clientepix_Z");
         state.Add("gxTpr_Bancoid_Z");
         state.Add("gxTpr_Bancocodigo_Z");
         state.Add("gxTpr_Banconome_Z");
         state.Add("gxTpr_Contaagencia_Z");
         state.Add("gxTpr_Contanumero_Z");
         state.Add("gxTpr_Responsavelnome_Z");
         state.Add("gxTpr_Responsavelnacionalidade_Z");
         state.Add("gxTpr_Responsavelnacionalidadenome_Z");
         state.Add("gxTpr_Responsavelestadocivil_Z");
         state.Add("gxTpr_Responsavelprofissao_Z");
         state.Add("gxTpr_Responsavelrg_Z");
         state.Add("gxTpr_Responsavelprofissaonome_Z");
         state.Add("gxTpr_Responsavelcpf_Z");
         state.Add("gxTpr_Responsavelcep_Z");
         state.Add("gxTpr_Responsavellogradouro_Z");
         state.Add("gxTpr_Responsavelbairro_Z");
         state.Add("gxTpr_Responsavelcidade_Z");
         state.Add("gxTpr_Responsavelmunicipio_Z");
         state.Add("gxTpr_Responsavelmunicipiouf_Z");
         state.Add("gxTpr_Responsavelmunicipionome_Z");
         state.Add("gxTpr_Responsavellogradouronumero_Z");
         state.Add("gxTpr_Responsavelcomplemento_Z");
         state.Add("gxTpr_Responsavelddd_Z");
         state.Add("gxTpr_Responsavelnumero_Z");
         state.Add("gxTpr_Responsavelemail_Z");
         state.Add("gxTpr_Responsavelcelular_f_Z");
         state.Add("gxTpr_Serasaconsultas_f_Z");
         state.Add("gxTpr_Serasaultimadata_f_Z_Nullable");
         state.Add("gxTpr_Serasascoreultimadata_f_Z");
         state.Add("gxTpr_Serasaultimovalorrecomendado_f_Z");
         state.Add("gxTpr_Clientesituacao_Z");
         state.Add("gxTpr_Responsavelcargo_Z");
         state.Add("gxTpr_Tipoclienteportalpjpf_Z");
         state.Add("gxTpr_Relacionamentosacado_Z");
         state.Add("gxTpr_Clientesacado_Z");
         state.Add("gxTpr_Clientetiporisco_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clientedocumento_N");
         state.Add("gxTpr_Clienterazaosocial_N");
         state.Add("gxTpr_Clientenomefantasia_N");
         state.Add("gxTpr_Clientedatanascimento_N");
         state.Add("gxTpr_Clientetipopessoa_N");
         state.Add("gxTpr_Especialidadeid_N");
         state.Add("gxTpr_Tipoclienteid_N");
         state.Add("gxTpr_Tipoclientedescricao_N");
         state.Add("gxTpr_Tipoclienteportal_N");
         state.Add("gxTpr_Clientestatus_N");
         state.Add("gxTpr_Clienteconvenio_N");
         state.Add("gxTpr_Clienteconveniodescricao_N");
         state.Add("gxTpr_Clientecreatedat_N");
         state.Add("gxTpr_Clienteupdatedat_N");
         state.Add("gxTpr_Clienteloguser_N");
         state.Add("gxTpr_Clientenacionalidade_N");
         state.Add("gxTpr_Clientenacionalidadenome_N");
         state.Add("gxTpr_Clienteprofissao_N");
         state.Add("gxTpr_Clienteprofissaonome_N");
         state.Add("gxTpr_Clienteestadocivil_N");
         state.Add("gxTpr_Secuserid_f_N");
         state.Add("gxTpr_Enderecotipo_N");
         state.Add("gxTpr_Enderecocep_N");
         state.Add("gxTpr_Enderecologradouro_N");
         state.Add("gxTpr_Enderecobairro_N");
         state.Add("gxTpr_Enderecocidade_N");
         state.Add("gxTpr_Municipiocodigo_N");
         state.Add("gxTpr_Municipionome_N");
         state.Add("gxTpr_Municipiouf_N");
         state.Add("gxTpr_Endereconumero_N");
         state.Add("gxTpr_Enderecocomplemento_N");
         state.Add("gxTpr_Contatoemail_N");
         state.Add("gxTpr_Contatoddd_N");
         state.Add("gxTpr_Contatoddi_N");
         state.Add("gxTpr_Contatonumero_N");
         state.Add("gxTpr_Contatotelefonenumero_N");
         state.Add("gxTpr_Contatotelefoneddd_N");
         state.Add("gxTpr_Contatotelefoneddi_N");
         state.Add("gxTpr_Clienterg_N");
         state.Add("gxTpr_Clienteqtdtitulos_f_N");
         state.Add("gxTpr_Clientevalorapagar_f_N");
         state.Add("gxTpr_Clientevalorareceber_f_N");
         state.Add("gxTpr_Clientedepositotipo_N");
         state.Add("gxTpr_Clientepixtipo_N");
         state.Add("gxTpr_Clientepix_N");
         state.Add("gxTpr_Bancoid_N");
         state.Add("gxTpr_Bancocodigo_N");
         state.Add("gxTpr_Banconome_N");
         state.Add("gxTpr_Contaagencia_N");
         state.Add("gxTpr_Contanumero_N");
         state.Add("gxTpr_Responsavelnome_N");
         state.Add("gxTpr_Responsavelnacionalidade_N");
         state.Add("gxTpr_Responsavelnacionalidadenome_N");
         state.Add("gxTpr_Responsavelestadocivil_N");
         state.Add("gxTpr_Responsavelprofissao_N");
         state.Add("gxTpr_Responsavelrg_N");
         state.Add("gxTpr_Responsavelprofissaonome_N");
         state.Add("gxTpr_Responsavelcpf_N");
         state.Add("gxTpr_Responsavelcep_N");
         state.Add("gxTpr_Responsavellogradouro_N");
         state.Add("gxTpr_Responsavelbairro_N");
         state.Add("gxTpr_Responsavelcidade_N");
         state.Add("gxTpr_Responsavelmunicipio_N");
         state.Add("gxTpr_Responsavelmunicipiouf_N");
         state.Add("gxTpr_Responsavelmunicipionome_N");
         state.Add("gxTpr_Responsavellogradouronumero_N");
         state.Add("gxTpr_Responsavelcomplemento_N");
         state.Add("gxTpr_Responsavelddd_N");
         state.Add("gxTpr_Responsavelnumero_N");
         state.Add("gxTpr_Responsavelemail_N");
         state.Add("gxTpr_Clientesituacao_N");
         state.Add("gxTpr_Responsavelcargo_N");
         state.Add("gxTpr_Tipoclienteportalpjpf_N");
         state.Add("gxTpr_Relacionamentosacado_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCliente sdt;
         sdt = (SdtCliente)(source);
         gxTv_SdtCliente_Clienteid = sdt.gxTv_SdtCliente_Clienteid ;
         gxTv_SdtCliente_Clientedocumento = sdt.gxTv_SdtCliente_Clientedocumento ;
         gxTv_SdtCliente_Clienterazaosocial = sdt.gxTv_SdtCliente_Clienterazaosocial ;
         gxTv_SdtCliente_Clientenomefantasia = sdt.gxTv_SdtCliente_Clientenomefantasia ;
         gxTv_SdtCliente_Clientedatanascimento = sdt.gxTv_SdtCliente_Clientedatanascimento ;
         gxTv_SdtCliente_Clientetipopessoa = sdt.gxTv_SdtCliente_Clientetipopessoa ;
         gxTv_SdtCliente_Especialidadeid = sdt.gxTv_SdtCliente_Especialidadeid ;
         gxTv_SdtCliente_Tipoclienteid = sdt.gxTv_SdtCliente_Tipoclienteid ;
         gxTv_SdtCliente_Tipoclientedescricao = sdt.gxTv_SdtCliente_Tipoclientedescricao ;
         gxTv_SdtCliente_Tipoclienteportal = sdt.gxTv_SdtCliente_Tipoclienteportal ;
         gxTv_SdtCliente_Clientestatus = sdt.gxTv_SdtCliente_Clientestatus ;
         gxTv_SdtCliente_Clienteconvenio = sdt.gxTv_SdtCliente_Clienteconvenio ;
         gxTv_SdtCliente_Clienteconveniodescricao = sdt.gxTv_SdtCliente_Clienteconveniodescricao ;
         gxTv_SdtCliente_Clientecreatedat = sdt.gxTv_SdtCliente_Clientecreatedat ;
         gxTv_SdtCliente_Clienteupdatedat = sdt.gxTv_SdtCliente_Clienteupdatedat ;
         gxTv_SdtCliente_Clienteloguser = sdt.gxTv_SdtCliente_Clienteloguser ;
         gxTv_SdtCliente_Clientenacionalidade = sdt.gxTv_SdtCliente_Clientenacionalidade ;
         gxTv_SdtCliente_Clientenacionalidadenome = sdt.gxTv_SdtCliente_Clientenacionalidadenome ;
         gxTv_SdtCliente_Clienteprofissao = sdt.gxTv_SdtCliente_Clienteprofissao ;
         gxTv_SdtCliente_Clienteprofissaonome = sdt.gxTv_SdtCliente_Clienteprofissaonome ;
         gxTv_SdtCliente_Clienteestadocivil = sdt.gxTv_SdtCliente_Clienteestadocivil ;
         gxTv_SdtCliente_Secuserid_f = sdt.gxTv_SdtCliente_Secuserid_f ;
         gxTv_SdtCliente_Enderecotipo = sdt.gxTv_SdtCliente_Enderecotipo ;
         gxTv_SdtCliente_Enderecocep = sdt.gxTv_SdtCliente_Enderecocep ;
         gxTv_SdtCliente_Enderecologradouro = sdt.gxTv_SdtCliente_Enderecologradouro ;
         gxTv_SdtCliente_Enderecobairro = sdt.gxTv_SdtCliente_Enderecobairro ;
         gxTv_SdtCliente_Enderecocidade = sdt.gxTv_SdtCliente_Enderecocidade ;
         gxTv_SdtCliente_Municipiocodigo = sdt.gxTv_SdtCliente_Municipiocodigo ;
         gxTv_SdtCliente_Municipionome = sdt.gxTv_SdtCliente_Municipionome ;
         gxTv_SdtCliente_Municipiouf = sdt.gxTv_SdtCliente_Municipiouf ;
         gxTv_SdtCliente_Endereconumero = sdt.gxTv_SdtCliente_Endereconumero ;
         gxTv_SdtCliente_Enderecocomplemento = sdt.gxTv_SdtCliente_Enderecocomplemento ;
         gxTv_SdtCliente_Contatoemail = sdt.gxTv_SdtCliente_Contatoemail ;
         gxTv_SdtCliente_Contatoddd = sdt.gxTv_SdtCliente_Contatoddd ;
         gxTv_SdtCliente_Contatoddi = sdt.gxTv_SdtCliente_Contatoddi ;
         gxTv_SdtCliente_Contatonumero = sdt.gxTv_SdtCliente_Contatonumero ;
         gxTv_SdtCliente_Contatotelefonenumero = sdt.gxTv_SdtCliente_Contatotelefonenumero ;
         gxTv_SdtCliente_Contatotelefoneddd = sdt.gxTv_SdtCliente_Contatotelefoneddd ;
         gxTv_SdtCliente_Contatotelefoneddi = sdt.gxTv_SdtCliente_Contatotelefoneddi ;
         gxTv_SdtCliente_Clienterg = sdt.gxTv_SdtCliente_Clienterg ;
         gxTv_SdtCliente_Clientetelefone_f = sdt.gxTv_SdtCliente_Clientetelefone_f ;
         gxTv_SdtCliente_Clientecelular_f = sdt.gxTv_SdtCliente_Clientecelular_f ;
         gxTv_SdtCliente_Clienteqtdtitulos_f = sdt.gxTv_SdtCliente_Clienteqtdtitulos_f ;
         gxTv_SdtCliente_Clientevalorapagar_f = sdt.gxTv_SdtCliente_Clientevalorapagar_f ;
         gxTv_SdtCliente_Clientevalorareceber_f = sdt.gxTv_SdtCliente_Clientevalorareceber_f ;
         gxTv_SdtCliente_Clientedepositotipo = sdt.gxTv_SdtCliente_Clientedepositotipo ;
         gxTv_SdtCliente_Clientepixtipo = sdt.gxTv_SdtCliente_Clientepixtipo ;
         gxTv_SdtCliente_Clientepix = sdt.gxTv_SdtCliente_Clientepix ;
         gxTv_SdtCliente_Bancoid = sdt.gxTv_SdtCliente_Bancoid ;
         gxTv_SdtCliente_Bancocodigo = sdt.gxTv_SdtCliente_Bancocodigo ;
         gxTv_SdtCliente_Banconome = sdt.gxTv_SdtCliente_Banconome ;
         gxTv_SdtCliente_Contaagencia = sdt.gxTv_SdtCliente_Contaagencia ;
         gxTv_SdtCliente_Contanumero = sdt.gxTv_SdtCliente_Contanumero ;
         gxTv_SdtCliente_Responsavelnome = sdt.gxTv_SdtCliente_Responsavelnome ;
         gxTv_SdtCliente_Responsavelnacionalidade = sdt.gxTv_SdtCliente_Responsavelnacionalidade ;
         gxTv_SdtCliente_Responsavelnacionalidadenome = sdt.gxTv_SdtCliente_Responsavelnacionalidadenome ;
         gxTv_SdtCliente_Responsavelestadocivil = sdt.gxTv_SdtCliente_Responsavelestadocivil ;
         gxTv_SdtCliente_Responsavelprofissao = sdt.gxTv_SdtCliente_Responsavelprofissao ;
         gxTv_SdtCliente_Responsavelrg = sdt.gxTv_SdtCliente_Responsavelrg ;
         gxTv_SdtCliente_Responsavelprofissaonome = sdt.gxTv_SdtCliente_Responsavelprofissaonome ;
         gxTv_SdtCliente_Responsavelcpf = sdt.gxTv_SdtCliente_Responsavelcpf ;
         gxTv_SdtCliente_Responsavelcep = sdt.gxTv_SdtCliente_Responsavelcep ;
         gxTv_SdtCliente_Responsavellogradouro = sdt.gxTv_SdtCliente_Responsavellogradouro ;
         gxTv_SdtCliente_Responsavelbairro = sdt.gxTv_SdtCliente_Responsavelbairro ;
         gxTv_SdtCliente_Responsavelcidade = sdt.gxTv_SdtCliente_Responsavelcidade ;
         gxTv_SdtCliente_Responsavelmunicipio = sdt.gxTv_SdtCliente_Responsavelmunicipio ;
         gxTv_SdtCliente_Responsavelmunicipiouf = sdt.gxTv_SdtCliente_Responsavelmunicipiouf ;
         gxTv_SdtCliente_Responsavelmunicipionome = sdt.gxTv_SdtCliente_Responsavelmunicipionome ;
         gxTv_SdtCliente_Responsavellogradouronumero = sdt.gxTv_SdtCliente_Responsavellogradouronumero ;
         gxTv_SdtCliente_Responsavelcomplemento = sdt.gxTv_SdtCliente_Responsavelcomplemento ;
         gxTv_SdtCliente_Responsavelddd = sdt.gxTv_SdtCliente_Responsavelddd ;
         gxTv_SdtCliente_Responsavelnumero = sdt.gxTv_SdtCliente_Responsavelnumero ;
         gxTv_SdtCliente_Responsavelemail = sdt.gxTv_SdtCliente_Responsavelemail ;
         gxTv_SdtCliente_Responsavelcelular_f = sdt.gxTv_SdtCliente_Responsavelcelular_f ;
         gxTv_SdtCliente_Serasaconsultas_f = sdt.gxTv_SdtCliente_Serasaconsultas_f ;
         gxTv_SdtCliente_Serasaultimadata_f = sdt.gxTv_SdtCliente_Serasaultimadata_f ;
         gxTv_SdtCliente_Serasascoreultimadata_f = sdt.gxTv_SdtCliente_Serasascoreultimadata_f ;
         gxTv_SdtCliente_Serasaultimovalorrecomendado_f = sdt.gxTv_SdtCliente_Serasaultimovalorrecomendado_f ;
         gxTv_SdtCliente_Clientesituacao = sdt.gxTv_SdtCliente_Clientesituacao ;
         gxTv_SdtCliente_Responsavelcargo = sdt.gxTv_SdtCliente_Responsavelcargo ;
         gxTv_SdtCliente_Tipoclienteportalpjpf = sdt.gxTv_SdtCliente_Tipoclienteportalpjpf ;
         gxTv_SdtCliente_Relacionamentosacado = sdt.gxTv_SdtCliente_Relacionamentosacado ;
         gxTv_SdtCliente_Clientesacado = sdt.gxTv_SdtCliente_Clientesacado ;
         gxTv_SdtCliente_Clientetiporisco = sdt.gxTv_SdtCliente_Clientetiporisco ;
         gxTv_SdtCliente_Mode = sdt.gxTv_SdtCliente_Mode ;
         gxTv_SdtCliente_Initialized = sdt.gxTv_SdtCliente_Initialized ;
         gxTv_SdtCliente_Clienteid_Z = sdt.gxTv_SdtCliente_Clienteid_Z ;
         gxTv_SdtCliente_Clientedocumento_Z = sdt.gxTv_SdtCliente_Clientedocumento_Z ;
         gxTv_SdtCliente_Clienterazaosocial_Z = sdt.gxTv_SdtCliente_Clienterazaosocial_Z ;
         gxTv_SdtCliente_Clientenomefantasia_Z = sdt.gxTv_SdtCliente_Clientenomefantasia_Z ;
         gxTv_SdtCliente_Clientedatanascimento_Z = sdt.gxTv_SdtCliente_Clientedatanascimento_Z ;
         gxTv_SdtCliente_Clientetipopessoa_Z = sdt.gxTv_SdtCliente_Clientetipopessoa_Z ;
         gxTv_SdtCliente_Especialidadeid_Z = sdt.gxTv_SdtCliente_Especialidadeid_Z ;
         gxTv_SdtCliente_Tipoclienteid_Z = sdt.gxTv_SdtCliente_Tipoclienteid_Z ;
         gxTv_SdtCliente_Tipoclientedescricao_Z = sdt.gxTv_SdtCliente_Tipoclientedescricao_Z ;
         gxTv_SdtCliente_Tipoclienteportal_Z = sdt.gxTv_SdtCliente_Tipoclienteportal_Z ;
         gxTv_SdtCliente_Clientestatus_Z = sdt.gxTv_SdtCliente_Clientestatus_Z ;
         gxTv_SdtCliente_Clienteconvenio_Z = sdt.gxTv_SdtCliente_Clienteconvenio_Z ;
         gxTv_SdtCliente_Clienteconveniodescricao_Z = sdt.gxTv_SdtCliente_Clienteconveniodescricao_Z ;
         gxTv_SdtCliente_Clientecreatedat_Z = sdt.gxTv_SdtCliente_Clientecreatedat_Z ;
         gxTv_SdtCliente_Clienteupdatedat_Z = sdt.gxTv_SdtCliente_Clienteupdatedat_Z ;
         gxTv_SdtCliente_Clienteloguser_Z = sdt.gxTv_SdtCliente_Clienteloguser_Z ;
         gxTv_SdtCliente_Clientenacionalidade_Z = sdt.gxTv_SdtCliente_Clientenacionalidade_Z ;
         gxTv_SdtCliente_Clientenacionalidadenome_Z = sdt.gxTv_SdtCliente_Clientenacionalidadenome_Z ;
         gxTv_SdtCliente_Clienteprofissao_Z = sdt.gxTv_SdtCliente_Clienteprofissao_Z ;
         gxTv_SdtCliente_Clienteprofissaonome_Z = sdt.gxTv_SdtCliente_Clienteprofissaonome_Z ;
         gxTv_SdtCliente_Clienteestadocivil_Z = sdt.gxTv_SdtCliente_Clienteestadocivil_Z ;
         gxTv_SdtCliente_Secuserid_f_Z = sdt.gxTv_SdtCliente_Secuserid_f_Z ;
         gxTv_SdtCliente_Enderecotipo_Z = sdt.gxTv_SdtCliente_Enderecotipo_Z ;
         gxTv_SdtCliente_Enderecocep_Z = sdt.gxTv_SdtCliente_Enderecocep_Z ;
         gxTv_SdtCliente_Enderecologradouro_Z = sdt.gxTv_SdtCliente_Enderecologradouro_Z ;
         gxTv_SdtCliente_Enderecobairro_Z = sdt.gxTv_SdtCliente_Enderecobairro_Z ;
         gxTv_SdtCliente_Enderecocidade_Z = sdt.gxTv_SdtCliente_Enderecocidade_Z ;
         gxTv_SdtCliente_Municipiocodigo_Z = sdt.gxTv_SdtCliente_Municipiocodigo_Z ;
         gxTv_SdtCliente_Municipionome_Z = sdt.gxTv_SdtCliente_Municipionome_Z ;
         gxTv_SdtCliente_Municipiouf_Z = sdt.gxTv_SdtCliente_Municipiouf_Z ;
         gxTv_SdtCliente_Endereconumero_Z = sdt.gxTv_SdtCliente_Endereconumero_Z ;
         gxTv_SdtCliente_Enderecocomplemento_Z = sdt.gxTv_SdtCliente_Enderecocomplemento_Z ;
         gxTv_SdtCliente_Contatoemail_Z = sdt.gxTv_SdtCliente_Contatoemail_Z ;
         gxTv_SdtCliente_Contatoddd_Z = sdt.gxTv_SdtCliente_Contatoddd_Z ;
         gxTv_SdtCliente_Contatoddi_Z = sdt.gxTv_SdtCliente_Contatoddi_Z ;
         gxTv_SdtCliente_Contatonumero_Z = sdt.gxTv_SdtCliente_Contatonumero_Z ;
         gxTv_SdtCliente_Contatotelefonenumero_Z = sdt.gxTv_SdtCliente_Contatotelefonenumero_Z ;
         gxTv_SdtCliente_Contatotelefoneddd_Z = sdt.gxTv_SdtCliente_Contatotelefoneddd_Z ;
         gxTv_SdtCliente_Contatotelefoneddi_Z = sdt.gxTv_SdtCliente_Contatotelefoneddi_Z ;
         gxTv_SdtCliente_Clienterg_Z = sdt.gxTv_SdtCliente_Clienterg_Z ;
         gxTv_SdtCliente_Clientetelefone_f_Z = sdt.gxTv_SdtCliente_Clientetelefone_f_Z ;
         gxTv_SdtCliente_Clientecelular_f_Z = sdt.gxTv_SdtCliente_Clientecelular_f_Z ;
         gxTv_SdtCliente_Clienteqtdtitulos_f_Z = sdt.gxTv_SdtCliente_Clienteqtdtitulos_f_Z ;
         gxTv_SdtCliente_Clientevalorapagar_f_Z = sdt.gxTv_SdtCliente_Clientevalorapagar_f_Z ;
         gxTv_SdtCliente_Clientevalorareceber_f_Z = sdt.gxTv_SdtCliente_Clientevalorareceber_f_Z ;
         gxTv_SdtCliente_Clientedepositotipo_Z = sdt.gxTv_SdtCliente_Clientedepositotipo_Z ;
         gxTv_SdtCliente_Clientepixtipo_Z = sdt.gxTv_SdtCliente_Clientepixtipo_Z ;
         gxTv_SdtCliente_Clientepix_Z = sdt.gxTv_SdtCliente_Clientepix_Z ;
         gxTv_SdtCliente_Bancoid_Z = sdt.gxTv_SdtCliente_Bancoid_Z ;
         gxTv_SdtCliente_Bancocodigo_Z = sdt.gxTv_SdtCliente_Bancocodigo_Z ;
         gxTv_SdtCliente_Banconome_Z = sdt.gxTv_SdtCliente_Banconome_Z ;
         gxTv_SdtCliente_Contaagencia_Z = sdt.gxTv_SdtCliente_Contaagencia_Z ;
         gxTv_SdtCliente_Contanumero_Z = sdt.gxTv_SdtCliente_Contanumero_Z ;
         gxTv_SdtCliente_Responsavelnome_Z = sdt.gxTv_SdtCliente_Responsavelnome_Z ;
         gxTv_SdtCliente_Responsavelnacionalidade_Z = sdt.gxTv_SdtCliente_Responsavelnacionalidade_Z ;
         gxTv_SdtCliente_Responsavelnacionalidadenome_Z = sdt.gxTv_SdtCliente_Responsavelnacionalidadenome_Z ;
         gxTv_SdtCliente_Responsavelestadocivil_Z = sdt.gxTv_SdtCliente_Responsavelestadocivil_Z ;
         gxTv_SdtCliente_Responsavelprofissao_Z = sdt.gxTv_SdtCliente_Responsavelprofissao_Z ;
         gxTv_SdtCliente_Responsavelrg_Z = sdt.gxTv_SdtCliente_Responsavelrg_Z ;
         gxTv_SdtCliente_Responsavelprofissaonome_Z = sdt.gxTv_SdtCliente_Responsavelprofissaonome_Z ;
         gxTv_SdtCliente_Responsavelcpf_Z = sdt.gxTv_SdtCliente_Responsavelcpf_Z ;
         gxTv_SdtCliente_Responsavelcep_Z = sdt.gxTv_SdtCliente_Responsavelcep_Z ;
         gxTv_SdtCliente_Responsavellogradouro_Z = sdt.gxTv_SdtCliente_Responsavellogradouro_Z ;
         gxTv_SdtCliente_Responsavelbairro_Z = sdt.gxTv_SdtCliente_Responsavelbairro_Z ;
         gxTv_SdtCliente_Responsavelcidade_Z = sdt.gxTv_SdtCliente_Responsavelcidade_Z ;
         gxTv_SdtCliente_Responsavelmunicipio_Z = sdt.gxTv_SdtCliente_Responsavelmunicipio_Z ;
         gxTv_SdtCliente_Responsavelmunicipiouf_Z = sdt.gxTv_SdtCliente_Responsavelmunicipiouf_Z ;
         gxTv_SdtCliente_Responsavelmunicipionome_Z = sdt.gxTv_SdtCliente_Responsavelmunicipionome_Z ;
         gxTv_SdtCliente_Responsavellogradouronumero_Z = sdt.gxTv_SdtCliente_Responsavellogradouronumero_Z ;
         gxTv_SdtCliente_Responsavelcomplemento_Z = sdt.gxTv_SdtCliente_Responsavelcomplemento_Z ;
         gxTv_SdtCliente_Responsavelddd_Z = sdt.gxTv_SdtCliente_Responsavelddd_Z ;
         gxTv_SdtCliente_Responsavelnumero_Z = sdt.gxTv_SdtCliente_Responsavelnumero_Z ;
         gxTv_SdtCliente_Responsavelemail_Z = sdt.gxTv_SdtCliente_Responsavelemail_Z ;
         gxTv_SdtCliente_Responsavelcelular_f_Z = sdt.gxTv_SdtCliente_Responsavelcelular_f_Z ;
         gxTv_SdtCliente_Serasaconsultas_f_Z = sdt.gxTv_SdtCliente_Serasaconsultas_f_Z ;
         gxTv_SdtCliente_Serasaultimadata_f_Z = sdt.gxTv_SdtCliente_Serasaultimadata_f_Z ;
         gxTv_SdtCliente_Serasascoreultimadata_f_Z = sdt.gxTv_SdtCliente_Serasascoreultimadata_f_Z ;
         gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z = sdt.gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z ;
         gxTv_SdtCliente_Clientesituacao_Z = sdt.gxTv_SdtCliente_Clientesituacao_Z ;
         gxTv_SdtCliente_Responsavelcargo_Z = sdt.gxTv_SdtCliente_Responsavelcargo_Z ;
         gxTv_SdtCliente_Tipoclienteportalpjpf_Z = sdt.gxTv_SdtCliente_Tipoclienteportalpjpf_Z ;
         gxTv_SdtCliente_Relacionamentosacado_Z = sdt.gxTv_SdtCliente_Relacionamentosacado_Z ;
         gxTv_SdtCliente_Clientesacado_Z = sdt.gxTv_SdtCliente_Clientesacado_Z ;
         gxTv_SdtCliente_Clientetiporisco_Z = sdt.gxTv_SdtCliente_Clientetiporisco_Z ;
         gxTv_SdtCliente_Clienteid_N = sdt.gxTv_SdtCliente_Clienteid_N ;
         gxTv_SdtCliente_Clientedocumento_N = sdt.gxTv_SdtCliente_Clientedocumento_N ;
         gxTv_SdtCliente_Clienterazaosocial_N = sdt.gxTv_SdtCliente_Clienterazaosocial_N ;
         gxTv_SdtCliente_Clientenomefantasia_N = sdt.gxTv_SdtCliente_Clientenomefantasia_N ;
         gxTv_SdtCliente_Clientedatanascimento_N = sdt.gxTv_SdtCliente_Clientedatanascimento_N ;
         gxTv_SdtCliente_Clientetipopessoa_N = sdt.gxTv_SdtCliente_Clientetipopessoa_N ;
         gxTv_SdtCliente_Especialidadeid_N = sdt.gxTv_SdtCliente_Especialidadeid_N ;
         gxTv_SdtCliente_Tipoclienteid_N = sdt.gxTv_SdtCliente_Tipoclienteid_N ;
         gxTv_SdtCliente_Tipoclientedescricao_N = sdt.gxTv_SdtCliente_Tipoclientedescricao_N ;
         gxTv_SdtCliente_Tipoclienteportal_N = sdt.gxTv_SdtCliente_Tipoclienteportal_N ;
         gxTv_SdtCliente_Clientestatus_N = sdt.gxTv_SdtCliente_Clientestatus_N ;
         gxTv_SdtCliente_Clienteconvenio_N = sdt.gxTv_SdtCliente_Clienteconvenio_N ;
         gxTv_SdtCliente_Clienteconveniodescricao_N = sdt.gxTv_SdtCliente_Clienteconveniodescricao_N ;
         gxTv_SdtCliente_Clientecreatedat_N = sdt.gxTv_SdtCliente_Clientecreatedat_N ;
         gxTv_SdtCliente_Clienteupdatedat_N = sdt.gxTv_SdtCliente_Clienteupdatedat_N ;
         gxTv_SdtCliente_Clienteloguser_N = sdt.gxTv_SdtCliente_Clienteloguser_N ;
         gxTv_SdtCliente_Clientenacionalidade_N = sdt.gxTv_SdtCliente_Clientenacionalidade_N ;
         gxTv_SdtCliente_Clientenacionalidadenome_N = sdt.gxTv_SdtCliente_Clientenacionalidadenome_N ;
         gxTv_SdtCliente_Clienteprofissao_N = sdt.gxTv_SdtCliente_Clienteprofissao_N ;
         gxTv_SdtCliente_Clienteprofissaonome_N = sdt.gxTv_SdtCliente_Clienteprofissaonome_N ;
         gxTv_SdtCliente_Clienteestadocivil_N = sdt.gxTv_SdtCliente_Clienteestadocivil_N ;
         gxTv_SdtCliente_Secuserid_f_N = sdt.gxTv_SdtCliente_Secuserid_f_N ;
         gxTv_SdtCliente_Enderecotipo_N = sdt.gxTv_SdtCliente_Enderecotipo_N ;
         gxTv_SdtCliente_Enderecocep_N = sdt.gxTv_SdtCliente_Enderecocep_N ;
         gxTv_SdtCliente_Enderecologradouro_N = sdt.gxTv_SdtCliente_Enderecologradouro_N ;
         gxTv_SdtCliente_Enderecobairro_N = sdt.gxTv_SdtCliente_Enderecobairro_N ;
         gxTv_SdtCliente_Enderecocidade_N = sdt.gxTv_SdtCliente_Enderecocidade_N ;
         gxTv_SdtCliente_Municipiocodigo_N = sdt.gxTv_SdtCliente_Municipiocodigo_N ;
         gxTv_SdtCliente_Municipionome_N = sdt.gxTv_SdtCliente_Municipionome_N ;
         gxTv_SdtCliente_Municipiouf_N = sdt.gxTv_SdtCliente_Municipiouf_N ;
         gxTv_SdtCliente_Endereconumero_N = sdt.gxTv_SdtCliente_Endereconumero_N ;
         gxTv_SdtCliente_Enderecocomplemento_N = sdt.gxTv_SdtCliente_Enderecocomplemento_N ;
         gxTv_SdtCliente_Contatoemail_N = sdt.gxTv_SdtCliente_Contatoemail_N ;
         gxTv_SdtCliente_Contatoddd_N = sdt.gxTv_SdtCliente_Contatoddd_N ;
         gxTv_SdtCliente_Contatoddi_N = sdt.gxTv_SdtCliente_Contatoddi_N ;
         gxTv_SdtCliente_Contatonumero_N = sdt.gxTv_SdtCliente_Contatonumero_N ;
         gxTv_SdtCliente_Contatotelefonenumero_N = sdt.gxTv_SdtCliente_Contatotelefonenumero_N ;
         gxTv_SdtCliente_Contatotelefoneddd_N = sdt.gxTv_SdtCliente_Contatotelefoneddd_N ;
         gxTv_SdtCliente_Contatotelefoneddi_N = sdt.gxTv_SdtCliente_Contatotelefoneddi_N ;
         gxTv_SdtCliente_Clienterg_N = sdt.gxTv_SdtCliente_Clienterg_N ;
         gxTv_SdtCliente_Clienteqtdtitulos_f_N = sdt.gxTv_SdtCliente_Clienteqtdtitulos_f_N ;
         gxTv_SdtCliente_Clientevalorapagar_f_N = sdt.gxTv_SdtCliente_Clientevalorapagar_f_N ;
         gxTv_SdtCliente_Clientevalorareceber_f_N = sdt.gxTv_SdtCliente_Clientevalorareceber_f_N ;
         gxTv_SdtCliente_Clientedepositotipo_N = sdt.gxTv_SdtCliente_Clientedepositotipo_N ;
         gxTv_SdtCliente_Clientepixtipo_N = sdt.gxTv_SdtCliente_Clientepixtipo_N ;
         gxTv_SdtCliente_Clientepix_N = sdt.gxTv_SdtCliente_Clientepix_N ;
         gxTv_SdtCliente_Bancoid_N = sdt.gxTv_SdtCliente_Bancoid_N ;
         gxTv_SdtCliente_Bancocodigo_N = sdt.gxTv_SdtCliente_Bancocodigo_N ;
         gxTv_SdtCliente_Banconome_N = sdt.gxTv_SdtCliente_Banconome_N ;
         gxTv_SdtCliente_Contaagencia_N = sdt.gxTv_SdtCliente_Contaagencia_N ;
         gxTv_SdtCliente_Contanumero_N = sdt.gxTv_SdtCliente_Contanumero_N ;
         gxTv_SdtCliente_Responsavelnome_N = sdt.gxTv_SdtCliente_Responsavelnome_N ;
         gxTv_SdtCliente_Responsavelnacionalidade_N = sdt.gxTv_SdtCliente_Responsavelnacionalidade_N ;
         gxTv_SdtCliente_Responsavelnacionalidadenome_N = sdt.gxTv_SdtCliente_Responsavelnacionalidadenome_N ;
         gxTv_SdtCliente_Responsavelestadocivil_N = sdt.gxTv_SdtCliente_Responsavelestadocivil_N ;
         gxTv_SdtCliente_Responsavelprofissao_N = sdt.gxTv_SdtCliente_Responsavelprofissao_N ;
         gxTv_SdtCliente_Responsavelrg_N = sdt.gxTv_SdtCliente_Responsavelrg_N ;
         gxTv_SdtCliente_Responsavelprofissaonome_N = sdt.gxTv_SdtCliente_Responsavelprofissaonome_N ;
         gxTv_SdtCliente_Responsavelcpf_N = sdt.gxTv_SdtCliente_Responsavelcpf_N ;
         gxTv_SdtCliente_Responsavelcep_N = sdt.gxTv_SdtCliente_Responsavelcep_N ;
         gxTv_SdtCliente_Responsavellogradouro_N = sdt.gxTv_SdtCliente_Responsavellogradouro_N ;
         gxTv_SdtCliente_Responsavelbairro_N = sdt.gxTv_SdtCliente_Responsavelbairro_N ;
         gxTv_SdtCliente_Responsavelcidade_N = sdt.gxTv_SdtCliente_Responsavelcidade_N ;
         gxTv_SdtCliente_Responsavelmunicipio_N = sdt.gxTv_SdtCliente_Responsavelmunicipio_N ;
         gxTv_SdtCliente_Responsavelmunicipiouf_N = sdt.gxTv_SdtCliente_Responsavelmunicipiouf_N ;
         gxTv_SdtCliente_Responsavelmunicipionome_N = sdt.gxTv_SdtCliente_Responsavelmunicipionome_N ;
         gxTv_SdtCliente_Responsavellogradouronumero_N = sdt.gxTv_SdtCliente_Responsavellogradouronumero_N ;
         gxTv_SdtCliente_Responsavelcomplemento_N = sdt.gxTv_SdtCliente_Responsavelcomplemento_N ;
         gxTv_SdtCliente_Responsavelddd_N = sdt.gxTv_SdtCliente_Responsavelddd_N ;
         gxTv_SdtCliente_Responsavelnumero_N = sdt.gxTv_SdtCliente_Responsavelnumero_N ;
         gxTv_SdtCliente_Responsavelemail_N = sdt.gxTv_SdtCliente_Responsavelemail_N ;
         gxTv_SdtCliente_Clientesituacao_N = sdt.gxTv_SdtCliente_Clientesituacao_N ;
         gxTv_SdtCliente_Responsavelcargo_N = sdt.gxTv_SdtCliente_Responsavelcargo_N ;
         gxTv_SdtCliente_Tipoclienteportalpjpf_N = sdt.gxTv_SdtCliente_Tipoclienteportalpjpf_N ;
         gxTv_SdtCliente_Relacionamentosacado_N = sdt.gxTv_SdtCliente_Relacionamentosacado_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ClienteId", gxTv_SdtCliente_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtCliente_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumento", gxTv_SdtCliente_Clientedocumento, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumento_N", gxTv_SdtCliente_Clientedocumento_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial", gxTv_SdtCliente_Clienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtCliente_Clienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("ClienteNomeFantasia", gxTv_SdtCliente_Clientenomefantasia, false, includeNonInitialized);
         AddObjectProperty("ClienteNomeFantasia_N", gxTv_SdtCliente_Clientenomefantasia_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCliente_Clientedatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCliente_Clientedatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCliente_Clientedatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ClienteDataNascimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteDataNascimento_N", gxTv_SdtCliente_Clientedatanascimento_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTipoPessoa", gxTv_SdtCliente_Clientetipopessoa, false, includeNonInitialized);
         AddObjectProperty("ClienteTipoPessoa_N", gxTv_SdtCliente_Clientetipopessoa_N, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeId", gxTv_SdtCliente_Especialidadeid, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeId_N", gxTv_SdtCliente_Especialidadeid_N, false, includeNonInitialized);
         AddObjectProperty("TipoClienteId", gxTv_SdtCliente_Tipoclienteid, false, includeNonInitialized);
         AddObjectProperty("TipoClienteId_N", gxTv_SdtCliente_Tipoclienteid_N, false, includeNonInitialized);
         AddObjectProperty("TipoClienteDescricao", gxTv_SdtCliente_Tipoclientedescricao, false, includeNonInitialized);
         AddObjectProperty("TipoClienteDescricao_N", gxTv_SdtCliente_Tipoclientedescricao_N, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortal", gxTv_SdtCliente_Tipoclienteportal, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortal_N", gxTv_SdtCliente_Tipoclienteportal_N, false, includeNonInitialized);
         AddObjectProperty("ClienteStatus", gxTv_SdtCliente_Clientestatus, false, includeNonInitialized);
         AddObjectProperty("ClienteStatus_N", gxTv_SdtCliente_Clientestatus_N, false, includeNonInitialized);
         AddObjectProperty("ClienteConvenio", gxTv_SdtCliente_Clienteconvenio, false, includeNonInitialized);
         AddObjectProperty("ClienteConvenio_N", gxTv_SdtCliente_Clienteconvenio_N, false, includeNonInitialized);
         AddObjectProperty("ClienteConvenioDescricao", gxTv_SdtCliente_Clienteconveniodescricao, false, includeNonInitialized);
         AddObjectProperty("ClienteConvenioDescricao_N", gxTv_SdtCliente_Clienteconveniodescricao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCliente_Clientecreatedat;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ClienteCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteCreatedAt_N", gxTv_SdtCliente_Clientecreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCliente_Clienteupdatedat;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ClienteUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteUpdatedAt_N", gxTv_SdtCliente_Clienteupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("ClienteLogUser", gxTv_SdtCliente_Clienteloguser, false, includeNonInitialized);
         AddObjectProperty("ClienteLogUser_N", gxTv_SdtCliente_Clienteloguser_N, false, includeNonInitialized);
         AddObjectProperty("ClienteNacionalidade", gxTv_SdtCliente_Clientenacionalidade, false, includeNonInitialized);
         AddObjectProperty("ClienteNacionalidade_N", gxTv_SdtCliente_Clientenacionalidade_N, false, includeNonInitialized);
         AddObjectProperty("ClienteNacionalidadeNome", gxTv_SdtCliente_Clientenacionalidadenome, false, includeNonInitialized);
         AddObjectProperty("ClienteNacionalidadeNome_N", gxTv_SdtCliente_Clientenacionalidadenome_N, false, includeNonInitialized);
         AddObjectProperty("ClienteProfissao", gxTv_SdtCliente_Clienteprofissao, false, includeNonInitialized);
         AddObjectProperty("ClienteProfissao_N", gxTv_SdtCliente_Clienteprofissao_N, false, includeNonInitialized);
         AddObjectProperty("ClienteProfissaoNome", gxTv_SdtCliente_Clienteprofissaonome, false, includeNonInitialized);
         AddObjectProperty("ClienteProfissaoNome_N", gxTv_SdtCliente_Clienteprofissaonome_N, false, includeNonInitialized);
         AddObjectProperty("ClienteEstadoCivil", gxTv_SdtCliente_Clienteestadocivil, false, includeNonInitialized);
         AddObjectProperty("ClienteEstadoCivil_N", gxTv_SdtCliente_Clienteestadocivil_N, false, includeNonInitialized);
         AddObjectProperty("SecUserId_F", gxTv_SdtCliente_Secuserid_f, false, includeNonInitialized);
         AddObjectProperty("SecUserId_F_N", gxTv_SdtCliente_Secuserid_f_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoTipo", gxTv_SdtCliente_Enderecotipo, false, includeNonInitialized);
         AddObjectProperty("EnderecoTipo_N", gxTv_SdtCliente_Enderecotipo_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoCEP", gxTv_SdtCliente_Enderecocep, false, includeNonInitialized);
         AddObjectProperty("EnderecoCEP_N", gxTv_SdtCliente_Enderecocep_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoLogradouro", gxTv_SdtCliente_Enderecologradouro, false, includeNonInitialized);
         AddObjectProperty("EnderecoLogradouro_N", gxTv_SdtCliente_Enderecologradouro_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoBairro", gxTv_SdtCliente_Enderecobairro, false, includeNonInitialized);
         AddObjectProperty("EnderecoBairro_N", gxTv_SdtCliente_Enderecobairro_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoCidade", gxTv_SdtCliente_Enderecocidade, false, includeNonInitialized);
         AddObjectProperty("EnderecoCidade_N", gxTv_SdtCliente_Enderecocidade_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioCodigo", gxTv_SdtCliente_Municipiocodigo, false, includeNonInitialized);
         AddObjectProperty("MunicipioCodigo_N", gxTv_SdtCliente_Municipiocodigo_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome", gxTv_SdtCliente_Municipionome, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome_N", gxTv_SdtCliente_Municipionome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF", gxTv_SdtCliente_Municipiouf, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF_N", gxTv_SdtCliente_Municipiouf_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoNumero", gxTv_SdtCliente_Endereconumero, false, includeNonInitialized);
         AddObjectProperty("EnderecoNumero_N", gxTv_SdtCliente_Endereconumero_N, false, includeNonInitialized);
         AddObjectProperty("EnderecoComplemento", gxTv_SdtCliente_Enderecocomplemento, false, includeNonInitialized);
         AddObjectProperty("EnderecoComplemento_N", gxTv_SdtCliente_Enderecocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("ContatoEmail", gxTv_SdtCliente_Contatoemail, false, includeNonInitialized);
         AddObjectProperty("ContatoEmail_N", gxTv_SdtCliente_Contatoemail_N, false, includeNonInitialized);
         AddObjectProperty("ContatoDDD", gxTv_SdtCliente_Contatoddd, false, includeNonInitialized);
         AddObjectProperty("ContatoDDD_N", gxTv_SdtCliente_Contatoddd_N, false, includeNonInitialized);
         AddObjectProperty("ContatoDDI", gxTv_SdtCliente_Contatoddi, false, includeNonInitialized);
         AddObjectProperty("ContatoDDI_N", gxTv_SdtCliente_Contatoddi_N, false, includeNonInitialized);
         AddObjectProperty("ContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtCliente_Contatonumero), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ContatoNumero_N", gxTv_SdtCliente_Contatonumero_N, false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneNumero", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtCliente_Contatotelefonenumero), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneNumero_N", gxTv_SdtCliente_Contatotelefonenumero_N, false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneDDD", gxTv_SdtCliente_Contatotelefoneddd, false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneDDD_N", gxTv_SdtCliente_Contatotelefoneddd_N, false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneDDI", gxTv_SdtCliente_Contatotelefoneddi, false, includeNonInitialized);
         AddObjectProperty("ContatoTelefoneDDI_N", gxTv_SdtCliente_Contatotelefoneddi_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRG", gxTv_SdtCliente_Clienterg, false, includeNonInitialized);
         AddObjectProperty("ClienteRG_N", gxTv_SdtCliente_Clienterg_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTelefone_F", gxTv_SdtCliente_Clientetelefone_f, false, includeNonInitialized);
         AddObjectProperty("ClienteCelular_F", gxTv_SdtCliente_Clientecelular_f, false, includeNonInitialized);
         AddObjectProperty("ClienteQtdTitulos_F", gxTv_SdtCliente_Clienteqtdtitulos_f, false, includeNonInitialized);
         AddObjectProperty("ClienteQtdTitulos_F_N", gxTv_SdtCliente_Clienteqtdtitulos_f_N, false, includeNonInitialized);
         AddObjectProperty("ClienteValorAPagar_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Clientevalorapagar_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ClienteValorAPagar_F_N", gxTv_SdtCliente_Clientevalorapagar_f_N, false, includeNonInitialized);
         AddObjectProperty("ClienteValorAReceber_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Clientevalorareceber_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ClienteValorAReceber_F_N", gxTv_SdtCliente_Clientevalorareceber_f_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDepositoTipo", gxTv_SdtCliente_Clientedepositotipo, false, includeNonInitialized);
         AddObjectProperty("ClienteDepositoTipo_N", gxTv_SdtCliente_Clientedepositotipo_N, false, includeNonInitialized);
         AddObjectProperty("ClientePixTipo", gxTv_SdtCliente_Clientepixtipo, false, includeNonInitialized);
         AddObjectProperty("ClientePixTipo_N", gxTv_SdtCliente_Clientepixtipo_N, false, includeNonInitialized);
         AddObjectProperty("ClientePix", gxTv_SdtCliente_Clientepix, false, includeNonInitialized);
         AddObjectProperty("ClientePix_N", gxTv_SdtCliente_Clientepix_N, false, includeNonInitialized);
         AddObjectProperty("BancoId", gxTv_SdtCliente_Bancoid, false, includeNonInitialized);
         AddObjectProperty("BancoId_N", gxTv_SdtCliente_Bancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoCodigo", gxTv_SdtCliente_Bancocodigo, false, includeNonInitialized);
         AddObjectProperty("BancoCodigo_N", gxTv_SdtCliente_Bancocodigo_N, false, includeNonInitialized);
         AddObjectProperty("BancoNome", gxTv_SdtCliente_Banconome, false, includeNonInitialized);
         AddObjectProperty("BancoNome_N", gxTv_SdtCliente_Banconome_N, false, includeNonInitialized);
         AddObjectProperty("ContaAgencia", gxTv_SdtCliente_Contaagencia, false, includeNonInitialized);
         AddObjectProperty("ContaAgencia_N", gxTv_SdtCliente_Contaagencia_N, false, includeNonInitialized);
         AddObjectProperty("ContaNumero", gxTv_SdtCliente_Contanumero, false, includeNonInitialized);
         AddObjectProperty("ContaNumero_N", gxTv_SdtCliente_Contanumero_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNome", gxTv_SdtCliente_Responsavelnome, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNome_N", gxTv_SdtCliente_Responsavelnome_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNacionalidade", gxTv_SdtCliente_Responsavelnacionalidade, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNacionalidade_N", gxTv_SdtCliente_Responsavelnacionalidade_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNacionalidadeNome", gxTv_SdtCliente_Responsavelnacionalidadenome, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNacionalidadeNome_N", gxTv_SdtCliente_Responsavelnacionalidadenome_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelEstadoCivil", gxTv_SdtCliente_Responsavelestadocivil, false, includeNonInitialized);
         AddObjectProperty("ResponsavelEstadoCivil_N", gxTv_SdtCliente_Responsavelestadocivil_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelProfissao", gxTv_SdtCliente_Responsavelprofissao, false, includeNonInitialized);
         AddObjectProperty("ResponsavelProfissao_N", gxTv_SdtCliente_Responsavelprofissao_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelRG", gxTv_SdtCliente_Responsavelrg, false, includeNonInitialized);
         AddObjectProperty("ResponsavelRG_N", gxTv_SdtCliente_Responsavelrg_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelProfissaoNome", gxTv_SdtCliente_Responsavelprofissaonome, false, includeNonInitialized);
         AddObjectProperty("ResponsavelProfissaoNome_N", gxTv_SdtCliente_Responsavelprofissaonome_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCPF", gxTv_SdtCliente_Responsavelcpf, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCPF_N", gxTv_SdtCliente_Responsavelcpf_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCEP", gxTv_SdtCliente_Responsavelcep, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCEP_N", gxTv_SdtCliente_Responsavelcep_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelLogradouro", gxTv_SdtCliente_Responsavellogradouro, false, includeNonInitialized);
         AddObjectProperty("ResponsavelLogradouro_N", gxTv_SdtCliente_Responsavellogradouro_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelBairro", gxTv_SdtCliente_Responsavelbairro, false, includeNonInitialized);
         AddObjectProperty("ResponsavelBairro_N", gxTv_SdtCliente_Responsavelbairro_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCidade", gxTv_SdtCliente_Responsavelcidade, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCidade_N", gxTv_SdtCliente_Responsavelcidade_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipio", gxTv_SdtCliente_Responsavelmunicipio, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipio_N", gxTv_SdtCliente_Responsavelmunicipio_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipioUF", gxTv_SdtCliente_Responsavelmunicipiouf, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipioUF_N", gxTv_SdtCliente_Responsavelmunicipiouf_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipioNome", gxTv_SdtCliente_Responsavelmunicipionome, false, includeNonInitialized);
         AddObjectProperty("ResponsavelMunicipioNome_N", gxTv_SdtCliente_Responsavelmunicipionome_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelLogradouroNumero", gxTv_SdtCliente_Responsavellogradouronumero, false, includeNonInitialized);
         AddObjectProperty("ResponsavelLogradouroNumero_N", gxTv_SdtCliente_Responsavellogradouronumero_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelComplemento", gxTv_SdtCliente_Responsavelcomplemento, false, includeNonInitialized);
         AddObjectProperty("ResponsavelComplemento_N", gxTv_SdtCliente_Responsavelcomplemento_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelDDD", gxTv_SdtCliente_Responsavelddd, false, includeNonInitialized);
         AddObjectProperty("ResponsavelDDD_N", gxTv_SdtCliente_Responsavelddd_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNumero", gxTv_SdtCliente_Responsavelnumero, false, includeNonInitialized);
         AddObjectProperty("ResponsavelNumero_N", gxTv_SdtCliente_Responsavelnumero_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelEmail", gxTv_SdtCliente_Responsavelemail, false, includeNonInitialized);
         AddObjectProperty("ResponsavelEmail_N", gxTv_SdtCliente_Responsavelemail_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCelular_F", gxTv_SdtCliente_Responsavelcelular_f, false, includeNonInitialized);
         AddObjectProperty("SerasaConsultas_F", gxTv_SdtCliente_Serasaconsultas_f, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCliente_Serasaultimadata_f;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaUltimaData_F", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaScoreUltimaData_F", gxTv_SdtCliente_Serasascoreultimadata_f, false, includeNonInitialized);
         AddObjectProperty("SerasaUltimoValorRecomendado_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Serasaultimovalorrecomendado_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ClienteSituacao", gxTv_SdtCliente_Clientesituacao, false, includeNonInitialized);
         AddObjectProperty("ClienteSituacao_N", gxTv_SdtCliente_Clientesituacao_N, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCargo", gxTv_SdtCliente_Responsavelcargo, false, includeNonInitialized);
         AddObjectProperty("ResponsavelCargo_N", gxTv_SdtCliente_Responsavelcargo_N, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf", gxTv_SdtCliente_Tipoclienteportalpjpf, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtCliente_Tipoclienteportalpjpf_N, false, includeNonInitialized);
         AddObjectProperty("RelacionamentoSacado", gxTv_SdtCliente_Relacionamentosacado, false, includeNonInitialized);
         AddObjectProperty("RelacionamentoSacado_N", gxTv_SdtCliente_Relacionamentosacado_N, false, includeNonInitialized);
         AddObjectProperty("ClienteSacado", gxTv_SdtCliente_Clientesacado, false, includeNonInitialized);
         AddObjectProperty("ClienteTipoRisco", gxTv_SdtCliente_Clientetiporisco, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCliente_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCliente_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtCliente_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumento_Z", gxTv_SdtCliente_Clientedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_Z", gxTv_SdtCliente_Clienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteNomeFantasia_Z", gxTv_SdtCliente_Clientenomefantasia_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCliente_Clientedatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCliente_Clientedatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCliente_Clientedatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ClienteDataNascimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteTipoPessoa_Z", gxTv_SdtCliente_Clientetipopessoa_Z, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeId_Z", gxTv_SdtCliente_Especialidadeid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClienteId_Z", gxTv_SdtCliente_Tipoclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClienteDescricao_Z", gxTv_SdtCliente_Tipoclientedescricao_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortal_Z", gxTv_SdtCliente_Tipoclienteportal_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteStatus_Z", gxTv_SdtCliente_Clientestatus_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteConvenio_Z", gxTv_SdtCliente_Clienteconvenio_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteConvenioDescricao_Z", gxTv_SdtCliente_Clienteconveniodescricao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCliente_Clientecreatedat_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ClienteCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCliente_Clienteupdatedat_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ClienteUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteLogUser_Z", gxTv_SdtCliente_Clienteloguser_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteNacionalidade_Z", gxTv_SdtCliente_Clientenacionalidade_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteNacionalidadeNome_Z", gxTv_SdtCliente_Clientenacionalidadenome_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteProfissao_Z", gxTv_SdtCliente_Clienteprofissao_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteProfissaoNome_Z", gxTv_SdtCliente_Clienteprofissaonome_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteEstadoCivil_Z", gxTv_SdtCliente_Clienteestadocivil_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_F_Z", gxTv_SdtCliente_Secuserid_f_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoTipo_Z", gxTv_SdtCliente_Enderecotipo_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoCEP_Z", gxTv_SdtCliente_Enderecocep_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoLogradouro_Z", gxTv_SdtCliente_Enderecologradouro_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoBairro_Z", gxTv_SdtCliente_Enderecobairro_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoCidade_Z", gxTv_SdtCliente_Enderecocidade_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_Z", gxTv_SdtCliente_Municipiocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_Z", gxTv_SdtCliente_Municipionome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_Z", gxTv_SdtCliente_Municipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoNumero_Z", gxTv_SdtCliente_Endereconumero_Z, false, includeNonInitialized);
            AddObjectProperty("EnderecoComplemento_Z", gxTv_SdtCliente_Enderecocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("ContatoEmail_Z", gxTv_SdtCliente_Contatoemail_Z, false, includeNonInitialized);
            AddObjectProperty("ContatoDDD_Z", gxTv_SdtCliente_Contatoddd_Z, false, includeNonInitialized);
            AddObjectProperty("ContatoDDI_Z", gxTv_SdtCliente_Contatoddi_Z, false, includeNonInitialized);
            AddObjectProperty("ContatoNumero_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtCliente_Contatonumero_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneNumero_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtCliente_Contatotelefonenumero_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneDDD_Z", gxTv_SdtCliente_Contatotelefoneddd_Z, false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneDDI_Z", gxTv_SdtCliente_Contatotelefoneddi_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRG_Z", gxTv_SdtCliente_Clienterg_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteTelefone_F_Z", gxTv_SdtCliente_Clientetelefone_f_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCelular_F_Z", gxTv_SdtCliente_Clientecelular_f_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteQtdTitulos_F_Z", gxTv_SdtCliente_Clienteqtdtitulos_f_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteValorAPagar_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Clientevalorapagar_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ClienteValorAReceber_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Clientevalorareceber_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ClienteDepositoTipo_Z", gxTv_SdtCliente_Clientedepositotipo_Z, false, includeNonInitialized);
            AddObjectProperty("ClientePixTipo_Z", gxTv_SdtCliente_Clientepixtipo_Z, false, includeNonInitialized);
            AddObjectProperty("ClientePix_Z", gxTv_SdtCliente_Clientepix_Z, false, includeNonInitialized);
            AddObjectProperty("BancoId_Z", gxTv_SdtCliente_Bancoid_Z, false, includeNonInitialized);
            AddObjectProperty("BancoCodigo_Z", gxTv_SdtCliente_Bancocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("BancoNome_Z", gxTv_SdtCliente_Banconome_Z, false, includeNonInitialized);
            AddObjectProperty("ContaAgencia_Z", gxTv_SdtCliente_Contaagencia_Z, false, includeNonInitialized);
            AddObjectProperty("ContaNumero_Z", gxTv_SdtCliente_Contanumero_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNome_Z", gxTv_SdtCliente_Responsavelnome_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNacionalidade_Z", gxTv_SdtCliente_Responsavelnacionalidade_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNacionalidadeNome_Z", gxTv_SdtCliente_Responsavelnacionalidadenome_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelEstadoCivil_Z", gxTv_SdtCliente_Responsavelestadocivil_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelProfissao_Z", gxTv_SdtCliente_Responsavelprofissao_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelRG_Z", gxTv_SdtCliente_Responsavelrg_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelProfissaoNome_Z", gxTv_SdtCliente_Responsavelprofissaonome_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCPF_Z", gxTv_SdtCliente_Responsavelcpf_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCEP_Z", gxTv_SdtCliente_Responsavelcep_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelLogradouro_Z", gxTv_SdtCliente_Responsavellogradouro_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelBairro_Z", gxTv_SdtCliente_Responsavelbairro_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCidade_Z", gxTv_SdtCliente_Responsavelcidade_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipio_Z", gxTv_SdtCliente_Responsavelmunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipioUF_Z", gxTv_SdtCliente_Responsavelmunicipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipioNome_Z", gxTv_SdtCliente_Responsavelmunicipionome_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelLogradouroNumero_Z", gxTv_SdtCliente_Responsavellogradouronumero_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelComplemento_Z", gxTv_SdtCliente_Responsavelcomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelDDD_Z", gxTv_SdtCliente_Responsavelddd_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNumero_Z", gxTv_SdtCliente_Responsavelnumero_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelEmail_Z", gxTv_SdtCliente_Responsavelemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCelular_F_Z", gxTv_SdtCliente_Responsavelcelular_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaConsultas_F_Z", gxTv_SdtCliente_Serasaconsultas_f_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCliente_Serasaultimadata_f_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaUltimaData_F_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaScoreUltimaData_F_Z", gxTv_SdtCliente_Serasascoreultimadata_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaUltimoValorRecomendado_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ClienteSituacao_Z", gxTv_SdtCliente_Clientesituacao_Z, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCargo_Z", gxTv_SdtCliente_Responsavelcargo_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_Z", gxTv_SdtCliente_Tipoclienteportalpjpf_Z, false, includeNonInitialized);
            AddObjectProperty("RelacionamentoSacado_Z", gxTv_SdtCliente_Relacionamentosacado_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteSacado_Z", gxTv_SdtCliente_Clientesacado_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteTipoRisco_Z", gxTv_SdtCliente_Clientetiporisco_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtCliente_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumento_N", gxTv_SdtCliente_Clientedocumento_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtCliente_Clienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("ClienteNomeFantasia_N", gxTv_SdtCliente_Clientenomefantasia_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDataNascimento_N", gxTv_SdtCliente_Clientedatanascimento_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTipoPessoa_N", gxTv_SdtCliente_Clientetipopessoa_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeId_N", gxTv_SdtCliente_Especialidadeid_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteId_N", gxTv_SdtCliente_Tipoclienteid_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteDescricao_N", gxTv_SdtCliente_Tipoclientedescricao_N, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortal_N", gxTv_SdtCliente_Tipoclienteportal_N, false, includeNonInitialized);
            AddObjectProperty("ClienteStatus_N", gxTv_SdtCliente_Clientestatus_N, false, includeNonInitialized);
            AddObjectProperty("ClienteConvenio_N", gxTv_SdtCliente_Clienteconvenio_N, false, includeNonInitialized);
            AddObjectProperty("ClienteConvenioDescricao_N", gxTv_SdtCliente_Clienteconveniodescricao_N, false, includeNonInitialized);
            AddObjectProperty("ClienteCreatedAt_N", gxTv_SdtCliente_Clientecreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ClienteUpdatedAt_N", gxTv_SdtCliente_Clienteupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("ClienteLogUser_N", gxTv_SdtCliente_Clienteloguser_N, false, includeNonInitialized);
            AddObjectProperty("ClienteNacionalidade_N", gxTv_SdtCliente_Clientenacionalidade_N, false, includeNonInitialized);
            AddObjectProperty("ClienteNacionalidadeNome_N", gxTv_SdtCliente_Clientenacionalidadenome_N, false, includeNonInitialized);
            AddObjectProperty("ClienteProfissao_N", gxTv_SdtCliente_Clienteprofissao_N, false, includeNonInitialized);
            AddObjectProperty("ClienteProfissaoNome_N", gxTv_SdtCliente_Clienteprofissaonome_N, false, includeNonInitialized);
            AddObjectProperty("ClienteEstadoCivil_N", gxTv_SdtCliente_Clienteestadocivil_N, false, includeNonInitialized);
            AddObjectProperty("SecUserId_F_N", gxTv_SdtCliente_Secuserid_f_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoTipo_N", gxTv_SdtCliente_Enderecotipo_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoCEP_N", gxTv_SdtCliente_Enderecocep_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoLogradouro_N", gxTv_SdtCliente_Enderecologradouro_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoBairro_N", gxTv_SdtCliente_Enderecobairro_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoCidade_N", gxTv_SdtCliente_Enderecocidade_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_N", gxTv_SdtCliente_Municipiocodigo_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_N", gxTv_SdtCliente_Municipionome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_N", gxTv_SdtCliente_Municipiouf_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoNumero_N", gxTv_SdtCliente_Endereconumero_N, false, includeNonInitialized);
            AddObjectProperty("EnderecoComplemento_N", gxTv_SdtCliente_Enderecocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("ContatoEmail_N", gxTv_SdtCliente_Contatoemail_N, false, includeNonInitialized);
            AddObjectProperty("ContatoDDD_N", gxTv_SdtCliente_Contatoddd_N, false, includeNonInitialized);
            AddObjectProperty("ContatoDDI_N", gxTv_SdtCliente_Contatoddi_N, false, includeNonInitialized);
            AddObjectProperty("ContatoNumero_N", gxTv_SdtCliente_Contatonumero_N, false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneNumero_N", gxTv_SdtCliente_Contatotelefonenumero_N, false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneDDD_N", gxTv_SdtCliente_Contatotelefoneddd_N, false, includeNonInitialized);
            AddObjectProperty("ContatoTelefoneDDI_N", gxTv_SdtCliente_Contatotelefoneddi_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRG_N", gxTv_SdtCliente_Clienterg_N, false, includeNonInitialized);
            AddObjectProperty("ClienteQtdTitulos_F_N", gxTv_SdtCliente_Clienteqtdtitulos_f_N, false, includeNonInitialized);
            AddObjectProperty("ClienteValorAPagar_F_N", gxTv_SdtCliente_Clientevalorapagar_f_N, false, includeNonInitialized);
            AddObjectProperty("ClienteValorAReceber_F_N", gxTv_SdtCliente_Clientevalorareceber_f_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDepositoTipo_N", gxTv_SdtCliente_Clientedepositotipo_N, false, includeNonInitialized);
            AddObjectProperty("ClientePixTipo_N", gxTv_SdtCliente_Clientepixtipo_N, false, includeNonInitialized);
            AddObjectProperty("ClientePix_N", gxTv_SdtCliente_Clientepix_N, false, includeNonInitialized);
            AddObjectProperty("BancoId_N", gxTv_SdtCliente_Bancoid_N, false, includeNonInitialized);
            AddObjectProperty("BancoCodigo_N", gxTv_SdtCliente_Bancocodigo_N, false, includeNonInitialized);
            AddObjectProperty("BancoNome_N", gxTv_SdtCliente_Banconome_N, false, includeNonInitialized);
            AddObjectProperty("ContaAgencia_N", gxTv_SdtCliente_Contaagencia_N, false, includeNonInitialized);
            AddObjectProperty("ContaNumero_N", gxTv_SdtCliente_Contanumero_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNome_N", gxTv_SdtCliente_Responsavelnome_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNacionalidade_N", gxTv_SdtCliente_Responsavelnacionalidade_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNacionalidadeNome_N", gxTv_SdtCliente_Responsavelnacionalidadenome_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelEstadoCivil_N", gxTv_SdtCliente_Responsavelestadocivil_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelProfissao_N", gxTv_SdtCliente_Responsavelprofissao_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelRG_N", gxTv_SdtCliente_Responsavelrg_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelProfissaoNome_N", gxTv_SdtCliente_Responsavelprofissaonome_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCPF_N", gxTv_SdtCliente_Responsavelcpf_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCEP_N", gxTv_SdtCliente_Responsavelcep_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelLogradouro_N", gxTv_SdtCliente_Responsavellogradouro_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelBairro_N", gxTv_SdtCliente_Responsavelbairro_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCidade_N", gxTv_SdtCliente_Responsavelcidade_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipio_N", gxTv_SdtCliente_Responsavelmunicipio_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipioUF_N", gxTv_SdtCliente_Responsavelmunicipiouf_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelMunicipioNome_N", gxTv_SdtCliente_Responsavelmunicipionome_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelLogradouroNumero_N", gxTv_SdtCliente_Responsavellogradouronumero_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelComplemento_N", gxTv_SdtCliente_Responsavelcomplemento_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelDDD_N", gxTv_SdtCliente_Responsavelddd_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelNumero_N", gxTv_SdtCliente_Responsavelnumero_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelEmail_N", gxTv_SdtCliente_Responsavelemail_N, false, includeNonInitialized);
            AddObjectProperty("ClienteSituacao_N", gxTv_SdtCliente_Clientesituacao_N, false, includeNonInitialized);
            AddObjectProperty("ResponsavelCargo_N", gxTv_SdtCliente_Responsavelcargo_N, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtCliente_Tipoclienteportalpjpf_N, false, includeNonInitialized);
            AddObjectProperty("RelacionamentoSacado_N", gxTv_SdtCliente_Relacionamentosacado_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCliente sdt )
      {
         if ( sdt.IsDirty("ClienteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteid = sdt.gxTv_SdtCliente_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteDocumento") )
         {
            gxTv_SdtCliente_Clientedocumento_N = (short)(sdt.gxTv_SdtCliente_Clientedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedocumento = sdt.gxTv_SdtCliente_Clientedocumento ;
         }
         if ( sdt.IsDirty("ClienteRazaoSocial") )
         {
            gxTv_SdtCliente_Clienterazaosocial_N = (short)(sdt.gxTv_SdtCliente_Clienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterazaosocial = sdt.gxTv_SdtCliente_Clienterazaosocial ;
         }
         if ( sdt.IsDirty("ClienteNomeFantasia") )
         {
            gxTv_SdtCliente_Clientenomefantasia_N = (short)(sdt.gxTv_SdtCliente_Clientenomefantasia_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenomefantasia = sdt.gxTv_SdtCliente_Clientenomefantasia ;
         }
         if ( sdt.IsDirty("ClienteDataNascimento") )
         {
            gxTv_SdtCliente_Clientedatanascimento_N = (short)(sdt.gxTv_SdtCliente_Clientedatanascimento_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedatanascimento = sdt.gxTv_SdtCliente_Clientedatanascimento ;
         }
         if ( sdt.IsDirty("ClienteTipoPessoa") )
         {
            gxTv_SdtCliente_Clientetipopessoa_N = (short)(sdt.gxTv_SdtCliente_Clientetipopessoa_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetipopessoa = sdt.gxTv_SdtCliente_Clientetipopessoa ;
         }
         if ( sdt.IsDirty("EspecialidadeId") )
         {
            gxTv_SdtCliente_Especialidadeid_N = (short)(sdt.gxTv_SdtCliente_Especialidadeid_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Especialidadeid = sdt.gxTv_SdtCliente_Especialidadeid ;
         }
         if ( sdt.IsDirty("TipoClienteId") )
         {
            gxTv_SdtCliente_Tipoclienteid_N = (short)(sdt.gxTv_SdtCliente_Tipoclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteid = sdt.gxTv_SdtCliente_Tipoclienteid ;
         }
         if ( sdt.IsDirty("TipoClienteDescricao") )
         {
            gxTv_SdtCliente_Tipoclientedescricao_N = (short)(sdt.gxTv_SdtCliente_Tipoclientedescricao_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclientedescricao = sdt.gxTv_SdtCliente_Tipoclientedescricao ;
         }
         if ( sdt.IsDirty("TipoClientePortal") )
         {
            gxTv_SdtCliente_Tipoclienteportal_N = (short)(sdt.gxTv_SdtCliente_Tipoclienteportal_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportal = sdt.gxTv_SdtCliente_Tipoclienteportal ;
         }
         if ( sdt.IsDirty("ClienteStatus") )
         {
            gxTv_SdtCliente_Clientestatus_N = (short)(sdt.gxTv_SdtCliente_Clientestatus_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientestatus = sdt.gxTv_SdtCliente_Clientestatus ;
         }
         if ( sdt.IsDirty("ClienteConvenio") )
         {
            gxTv_SdtCliente_Clienteconvenio_N = (short)(sdt.gxTv_SdtCliente_Clienteconvenio_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconvenio = sdt.gxTv_SdtCliente_Clienteconvenio ;
         }
         if ( sdt.IsDirty("ClienteConvenioDescricao") )
         {
            gxTv_SdtCliente_Clienteconveniodescricao_N = (short)(sdt.gxTv_SdtCliente_Clienteconveniodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconveniodescricao = sdt.gxTv_SdtCliente_Clienteconveniodescricao ;
         }
         if ( sdt.IsDirty("ClienteCreatedAt") )
         {
            gxTv_SdtCliente_Clientecreatedat_N = (short)(sdt.gxTv_SdtCliente_Clientecreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecreatedat = sdt.gxTv_SdtCliente_Clientecreatedat ;
         }
         if ( sdt.IsDirty("ClienteUpdatedAt") )
         {
            gxTv_SdtCliente_Clienteupdatedat_N = (short)(sdt.gxTv_SdtCliente_Clienteupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteupdatedat = sdt.gxTv_SdtCliente_Clienteupdatedat ;
         }
         if ( sdt.IsDirty("ClienteLogUser") )
         {
            gxTv_SdtCliente_Clienteloguser_N = (short)(sdt.gxTv_SdtCliente_Clienteloguser_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteloguser = sdt.gxTv_SdtCliente_Clienteloguser ;
         }
         if ( sdt.IsDirty("ClienteNacionalidade") )
         {
            gxTv_SdtCliente_Clientenacionalidade_N = (short)(sdt.gxTv_SdtCliente_Clientenacionalidade_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidade = sdt.gxTv_SdtCliente_Clientenacionalidade ;
         }
         if ( sdt.IsDirty("ClienteNacionalidadeNome") )
         {
            gxTv_SdtCliente_Clientenacionalidadenome_N = (short)(sdt.gxTv_SdtCliente_Clientenacionalidadenome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidadenome = sdt.gxTv_SdtCliente_Clientenacionalidadenome ;
         }
         if ( sdt.IsDirty("ClienteProfissao") )
         {
            gxTv_SdtCliente_Clienteprofissao_N = (short)(sdt.gxTv_SdtCliente_Clienteprofissao_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissao = sdt.gxTv_SdtCliente_Clienteprofissao ;
         }
         if ( sdt.IsDirty("ClienteProfissaoNome") )
         {
            gxTv_SdtCliente_Clienteprofissaonome_N = (short)(sdt.gxTv_SdtCliente_Clienteprofissaonome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissaonome = sdt.gxTv_SdtCliente_Clienteprofissaonome ;
         }
         if ( sdt.IsDirty("ClienteEstadoCivil") )
         {
            gxTv_SdtCliente_Clienteestadocivil_N = (short)(sdt.gxTv_SdtCliente_Clienteestadocivil_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteestadocivil = sdt.gxTv_SdtCliente_Clienteestadocivil ;
         }
         if ( sdt.IsDirty("SecUserId_F") )
         {
            gxTv_SdtCliente_Secuserid_f_N = (short)(sdt.gxTv_SdtCliente_Secuserid_f_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Secuserid_f = sdt.gxTv_SdtCliente_Secuserid_f ;
         }
         if ( sdt.IsDirty("EnderecoTipo") )
         {
            gxTv_SdtCliente_Enderecotipo_N = (short)(sdt.gxTv_SdtCliente_Enderecotipo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecotipo = sdt.gxTv_SdtCliente_Enderecotipo ;
         }
         if ( sdt.IsDirty("EnderecoCEP") )
         {
            gxTv_SdtCliente_Enderecocep_N = (short)(sdt.gxTv_SdtCliente_Enderecocep_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocep = sdt.gxTv_SdtCliente_Enderecocep ;
         }
         if ( sdt.IsDirty("EnderecoLogradouro") )
         {
            gxTv_SdtCliente_Enderecologradouro_N = (short)(sdt.gxTv_SdtCliente_Enderecologradouro_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecologradouro = sdt.gxTv_SdtCliente_Enderecologradouro ;
         }
         if ( sdt.IsDirty("EnderecoBairro") )
         {
            gxTv_SdtCliente_Enderecobairro_N = (short)(sdt.gxTv_SdtCliente_Enderecobairro_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecobairro = sdt.gxTv_SdtCliente_Enderecobairro ;
         }
         if ( sdt.IsDirty("EnderecoCidade") )
         {
            gxTv_SdtCliente_Enderecocidade_N = (short)(sdt.gxTv_SdtCliente_Enderecocidade_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocidade = sdt.gxTv_SdtCliente_Enderecocidade ;
         }
         if ( sdt.IsDirty("MunicipioCodigo") )
         {
            gxTv_SdtCliente_Municipiocodigo_N = (short)(sdt.gxTv_SdtCliente_Municipiocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiocodigo = sdt.gxTv_SdtCliente_Municipiocodigo ;
         }
         if ( sdt.IsDirty("MunicipioNome") )
         {
            gxTv_SdtCliente_Municipionome_N = (short)(sdt.gxTv_SdtCliente_Municipionome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipionome = sdt.gxTv_SdtCliente_Municipionome ;
         }
         if ( sdt.IsDirty("MunicipioUF") )
         {
            gxTv_SdtCliente_Municipiouf_N = (short)(sdt.gxTv_SdtCliente_Municipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiouf = sdt.gxTv_SdtCliente_Municipiouf ;
         }
         if ( sdt.IsDirty("EnderecoNumero") )
         {
            gxTv_SdtCliente_Endereconumero_N = (short)(sdt.gxTv_SdtCliente_Endereconumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Endereconumero = sdt.gxTv_SdtCliente_Endereconumero ;
         }
         if ( sdt.IsDirty("EnderecoComplemento") )
         {
            gxTv_SdtCliente_Enderecocomplemento_N = (short)(sdt.gxTv_SdtCliente_Enderecocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocomplemento = sdt.gxTv_SdtCliente_Enderecocomplemento ;
         }
         if ( sdt.IsDirty("ContatoEmail") )
         {
            gxTv_SdtCliente_Contatoemail_N = (short)(sdt.gxTv_SdtCliente_Contatoemail_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoemail = sdt.gxTv_SdtCliente_Contatoemail ;
         }
         if ( sdt.IsDirty("ContatoDDD") )
         {
            gxTv_SdtCliente_Contatoddd_N = (short)(sdt.gxTv_SdtCliente_Contatoddd_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddd = sdt.gxTv_SdtCliente_Contatoddd ;
         }
         if ( sdt.IsDirty("ContatoDDI") )
         {
            gxTv_SdtCliente_Contatoddi_N = (short)(sdt.gxTv_SdtCliente_Contatoddi_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddi = sdt.gxTv_SdtCliente_Contatoddi ;
         }
         if ( sdt.IsDirty("ContatoNumero") )
         {
            gxTv_SdtCliente_Contatonumero_N = (short)(sdt.gxTv_SdtCliente_Contatonumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatonumero = sdt.gxTv_SdtCliente_Contatonumero ;
         }
         if ( sdt.IsDirty("ContatoTelefoneNumero") )
         {
            gxTv_SdtCliente_Contatotelefonenumero_N = (short)(sdt.gxTv_SdtCliente_Contatotelefonenumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefonenumero = sdt.gxTv_SdtCliente_Contatotelefonenumero ;
         }
         if ( sdt.IsDirty("ContatoTelefoneDDD") )
         {
            gxTv_SdtCliente_Contatotelefoneddd_N = (short)(sdt.gxTv_SdtCliente_Contatotelefoneddd_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddd = sdt.gxTv_SdtCliente_Contatotelefoneddd ;
         }
         if ( sdt.IsDirty("ContatoTelefoneDDI") )
         {
            gxTv_SdtCliente_Contatotelefoneddi_N = (short)(sdt.gxTv_SdtCliente_Contatotelefoneddi_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddi = sdt.gxTv_SdtCliente_Contatotelefoneddi ;
         }
         if ( sdt.IsDirty("ClienteRG") )
         {
            gxTv_SdtCliente_Clienterg_N = (short)(sdt.gxTv_SdtCliente_Clienterg_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterg = sdt.gxTv_SdtCliente_Clienterg ;
         }
         if ( sdt.IsDirty("ClienteTelefone_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetelefone_f = sdt.gxTv_SdtCliente_Clientetelefone_f ;
         }
         if ( sdt.IsDirty("ClienteCelular_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecelular_f = sdt.gxTv_SdtCliente_Clientecelular_f ;
         }
         if ( sdt.IsDirty("ClienteQtdTitulos_F") )
         {
            gxTv_SdtCliente_Clienteqtdtitulos_f_N = (short)(sdt.gxTv_SdtCliente_Clienteqtdtitulos_f_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteqtdtitulos_f = sdt.gxTv_SdtCliente_Clienteqtdtitulos_f ;
         }
         if ( sdt.IsDirty("ClienteValorAPagar_F") )
         {
            gxTv_SdtCliente_Clientevalorapagar_f_N = (short)(sdt.gxTv_SdtCliente_Clientevalorapagar_f_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorapagar_f = sdt.gxTv_SdtCliente_Clientevalorapagar_f ;
         }
         if ( sdt.IsDirty("ClienteValorAReceber_F") )
         {
            gxTv_SdtCliente_Clientevalorareceber_f_N = (short)(sdt.gxTv_SdtCliente_Clientevalorareceber_f_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorareceber_f = sdt.gxTv_SdtCliente_Clientevalorareceber_f ;
         }
         if ( sdt.IsDirty("ClienteDepositoTipo") )
         {
            gxTv_SdtCliente_Clientedepositotipo_N = (short)(sdt.gxTv_SdtCliente_Clientedepositotipo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedepositotipo = sdt.gxTv_SdtCliente_Clientedepositotipo ;
         }
         if ( sdt.IsDirty("ClientePixTipo") )
         {
            gxTv_SdtCliente_Clientepixtipo_N = (short)(sdt.gxTv_SdtCliente_Clientepixtipo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepixtipo = sdt.gxTv_SdtCliente_Clientepixtipo ;
         }
         if ( sdt.IsDirty("ClientePix") )
         {
            gxTv_SdtCliente_Clientepix_N = (short)(sdt.gxTv_SdtCliente_Clientepix_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepix = sdt.gxTv_SdtCliente_Clientepix ;
         }
         if ( sdt.IsDirty("BancoId") )
         {
            gxTv_SdtCliente_Bancoid_N = (short)(sdt.gxTv_SdtCliente_Bancoid_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancoid = sdt.gxTv_SdtCliente_Bancoid ;
         }
         if ( sdt.IsDirty("BancoCodigo") )
         {
            gxTv_SdtCliente_Bancocodigo_N = (short)(sdt.gxTv_SdtCliente_Bancocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancocodigo = sdt.gxTv_SdtCliente_Bancocodigo ;
         }
         if ( sdt.IsDirty("BancoNome") )
         {
            gxTv_SdtCliente_Banconome_N = (short)(sdt.gxTv_SdtCliente_Banconome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Banconome = sdt.gxTv_SdtCliente_Banconome ;
         }
         if ( sdt.IsDirty("ContaAgencia") )
         {
            gxTv_SdtCliente_Contaagencia_N = (short)(sdt.gxTv_SdtCliente_Contaagencia_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contaagencia = sdt.gxTv_SdtCliente_Contaagencia ;
         }
         if ( sdt.IsDirty("ContaNumero") )
         {
            gxTv_SdtCliente_Contanumero_N = (short)(sdt.gxTv_SdtCliente_Contanumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Contanumero = sdt.gxTv_SdtCliente_Contanumero ;
         }
         if ( sdt.IsDirty("ResponsavelNome") )
         {
            gxTv_SdtCliente_Responsavelnome_N = (short)(sdt.gxTv_SdtCliente_Responsavelnome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnome = sdt.gxTv_SdtCliente_Responsavelnome ;
         }
         if ( sdt.IsDirty("ResponsavelNacionalidade") )
         {
            gxTv_SdtCliente_Responsavelnacionalidade_N = (short)(sdt.gxTv_SdtCliente_Responsavelnacionalidade_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidade = sdt.gxTv_SdtCliente_Responsavelnacionalidade ;
         }
         if ( sdt.IsDirty("ResponsavelNacionalidadeNome") )
         {
            gxTv_SdtCliente_Responsavelnacionalidadenome_N = (short)(sdt.gxTv_SdtCliente_Responsavelnacionalidadenome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidadenome = sdt.gxTv_SdtCliente_Responsavelnacionalidadenome ;
         }
         if ( sdt.IsDirty("ResponsavelEstadoCivil") )
         {
            gxTv_SdtCliente_Responsavelestadocivil_N = (short)(sdt.gxTv_SdtCliente_Responsavelestadocivil_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelestadocivil = sdt.gxTv_SdtCliente_Responsavelestadocivil ;
         }
         if ( sdt.IsDirty("ResponsavelProfissao") )
         {
            gxTv_SdtCliente_Responsavelprofissao_N = (short)(sdt.gxTv_SdtCliente_Responsavelprofissao_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissao = sdt.gxTv_SdtCliente_Responsavelprofissao ;
         }
         if ( sdt.IsDirty("ResponsavelRG") )
         {
            gxTv_SdtCliente_Responsavelrg_N = (short)(sdt.gxTv_SdtCliente_Responsavelrg_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelrg = sdt.gxTv_SdtCliente_Responsavelrg ;
         }
         if ( sdt.IsDirty("ResponsavelProfissaoNome") )
         {
            gxTv_SdtCliente_Responsavelprofissaonome_N = (short)(sdt.gxTv_SdtCliente_Responsavelprofissaonome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissaonome = sdt.gxTv_SdtCliente_Responsavelprofissaonome ;
         }
         if ( sdt.IsDirty("ResponsavelCPF") )
         {
            gxTv_SdtCliente_Responsavelcpf_N = (short)(sdt.gxTv_SdtCliente_Responsavelcpf_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcpf = sdt.gxTv_SdtCliente_Responsavelcpf ;
         }
         if ( sdt.IsDirty("ResponsavelCEP") )
         {
            gxTv_SdtCliente_Responsavelcep_N = (short)(sdt.gxTv_SdtCliente_Responsavelcep_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcep = sdt.gxTv_SdtCliente_Responsavelcep ;
         }
         if ( sdt.IsDirty("ResponsavelLogradouro") )
         {
            gxTv_SdtCliente_Responsavellogradouro_N = (short)(sdt.gxTv_SdtCliente_Responsavellogradouro_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouro = sdt.gxTv_SdtCliente_Responsavellogradouro ;
         }
         if ( sdt.IsDirty("ResponsavelBairro") )
         {
            gxTv_SdtCliente_Responsavelbairro_N = (short)(sdt.gxTv_SdtCliente_Responsavelbairro_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelbairro = sdt.gxTv_SdtCliente_Responsavelbairro ;
         }
         if ( sdt.IsDirty("ResponsavelCidade") )
         {
            gxTv_SdtCliente_Responsavelcidade_N = (short)(sdt.gxTv_SdtCliente_Responsavelcidade_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcidade = sdt.gxTv_SdtCliente_Responsavelcidade ;
         }
         if ( sdt.IsDirty("ResponsavelMunicipio") )
         {
            gxTv_SdtCliente_Responsavelmunicipio_N = (short)(sdt.gxTv_SdtCliente_Responsavelmunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipio = sdt.gxTv_SdtCliente_Responsavelmunicipio ;
         }
         if ( sdt.IsDirty("ResponsavelMunicipioUF") )
         {
            gxTv_SdtCliente_Responsavelmunicipiouf_N = (short)(sdt.gxTv_SdtCliente_Responsavelmunicipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipiouf = sdt.gxTv_SdtCliente_Responsavelmunicipiouf ;
         }
         if ( sdt.IsDirty("ResponsavelMunicipioNome") )
         {
            gxTv_SdtCliente_Responsavelmunicipionome_N = (short)(sdt.gxTv_SdtCliente_Responsavelmunicipionome_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipionome = sdt.gxTv_SdtCliente_Responsavelmunicipionome ;
         }
         if ( sdt.IsDirty("ResponsavelLogradouroNumero") )
         {
            gxTv_SdtCliente_Responsavellogradouronumero_N = (short)(sdt.gxTv_SdtCliente_Responsavellogradouronumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouronumero = sdt.gxTv_SdtCliente_Responsavellogradouronumero ;
         }
         if ( sdt.IsDirty("ResponsavelComplemento") )
         {
            gxTv_SdtCliente_Responsavelcomplemento_N = (short)(sdt.gxTv_SdtCliente_Responsavelcomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcomplemento = sdt.gxTv_SdtCliente_Responsavelcomplemento ;
         }
         if ( sdt.IsDirty("ResponsavelDDD") )
         {
            gxTv_SdtCliente_Responsavelddd_N = (short)(sdt.gxTv_SdtCliente_Responsavelddd_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelddd = sdt.gxTv_SdtCliente_Responsavelddd ;
         }
         if ( sdt.IsDirty("ResponsavelNumero") )
         {
            gxTv_SdtCliente_Responsavelnumero_N = (short)(sdt.gxTv_SdtCliente_Responsavelnumero_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnumero = sdt.gxTv_SdtCliente_Responsavelnumero ;
         }
         if ( sdt.IsDirty("ResponsavelEmail") )
         {
            gxTv_SdtCliente_Responsavelemail_N = (short)(sdt.gxTv_SdtCliente_Responsavelemail_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelemail = sdt.gxTv_SdtCliente_Responsavelemail ;
         }
         if ( sdt.IsDirty("ResponsavelCelular_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcelular_f = sdt.gxTv_SdtCliente_Responsavelcelular_f ;
         }
         if ( sdt.IsDirty("SerasaConsultas_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaconsultas_f = sdt.gxTv_SdtCliente_Serasaconsultas_f ;
         }
         if ( sdt.IsDirty("SerasaUltimaData_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimadata_f = sdt.gxTv_SdtCliente_Serasaultimadata_f ;
         }
         if ( sdt.IsDirty("SerasaScoreUltimaData_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasascoreultimadata_f = sdt.gxTv_SdtCliente_Serasascoreultimadata_f ;
         }
         if ( sdt.IsDirty("SerasaUltimoValorRecomendado_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimovalorrecomendado_f = sdt.gxTv_SdtCliente_Serasaultimovalorrecomendado_f ;
         }
         if ( sdt.IsDirty("ClienteSituacao") )
         {
            gxTv_SdtCliente_Clientesituacao_N = (short)(sdt.gxTv_SdtCliente_Clientesituacao_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesituacao = sdt.gxTv_SdtCliente_Clientesituacao ;
         }
         if ( sdt.IsDirty("ResponsavelCargo") )
         {
            gxTv_SdtCliente_Responsavelcargo_N = (short)(sdt.gxTv_SdtCliente_Responsavelcargo_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcargo = sdt.gxTv_SdtCliente_Responsavelcargo ;
         }
         if ( sdt.IsDirty("TipoClientePortalPjPf") )
         {
            gxTv_SdtCliente_Tipoclienteportalpjpf_N = (short)(sdt.gxTv_SdtCliente_Tipoclienteportalpjpf_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportalpjpf = sdt.gxTv_SdtCliente_Tipoclienteportalpjpf ;
         }
         if ( sdt.IsDirty("RelacionamentoSacado") )
         {
            gxTv_SdtCliente_Relacionamentosacado_N = (short)(sdt.gxTv_SdtCliente_Relacionamentosacado_N);
            sdtIsNull = 0;
            gxTv_SdtCliente_Relacionamentosacado = sdt.gxTv_SdtCliente_Relacionamentosacado ;
         }
         if ( sdt.IsDirty("ClienteSacado") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesacado = sdt.gxTv_SdtCliente_Clientesacado ;
         }
         if ( sdt.IsDirty("ClienteTipoRisco") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetiporisco = sdt.gxTv_SdtCliente_Clientetiporisco ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtCliente_Clienteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCliente_Clienteid != value )
            {
               gxTv_SdtCliente_Mode = "INS";
               this.gxTv_SdtCliente_Clienteid_Z_SetNull( );
               this.gxTv_SdtCliente_Clientedocumento_Z_SetNull( );
               this.gxTv_SdtCliente_Clienterazaosocial_Z_SetNull( );
               this.gxTv_SdtCliente_Clientenomefantasia_Z_SetNull( );
               this.gxTv_SdtCliente_Clientedatanascimento_Z_SetNull( );
               this.gxTv_SdtCliente_Clientetipopessoa_Z_SetNull( );
               this.gxTv_SdtCliente_Especialidadeid_Z_SetNull( );
               this.gxTv_SdtCliente_Tipoclienteid_Z_SetNull( );
               this.gxTv_SdtCliente_Tipoclientedescricao_Z_SetNull( );
               this.gxTv_SdtCliente_Tipoclienteportal_Z_SetNull( );
               this.gxTv_SdtCliente_Clientestatus_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteconvenio_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteconveniodescricao_Z_SetNull( );
               this.gxTv_SdtCliente_Clientecreatedat_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteupdatedat_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteloguser_Z_SetNull( );
               this.gxTv_SdtCliente_Clientenacionalidade_Z_SetNull( );
               this.gxTv_SdtCliente_Clientenacionalidadenome_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteprofissao_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteprofissaonome_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteestadocivil_Z_SetNull( );
               this.gxTv_SdtCliente_Secuserid_f_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecotipo_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecocep_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecologradouro_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecobairro_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecocidade_Z_SetNull( );
               this.gxTv_SdtCliente_Municipiocodigo_Z_SetNull( );
               this.gxTv_SdtCliente_Municipionome_Z_SetNull( );
               this.gxTv_SdtCliente_Municipiouf_Z_SetNull( );
               this.gxTv_SdtCliente_Endereconumero_Z_SetNull( );
               this.gxTv_SdtCliente_Enderecocomplemento_Z_SetNull( );
               this.gxTv_SdtCliente_Contatoemail_Z_SetNull( );
               this.gxTv_SdtCliente_Contatoddd_Z_SetNull( );
               this.gxTv_SdtCliente_Contatoddi_Z_SetNull( );
               this.gxTv_SdtCliente_Contatonumero_Z_SetNull( );
               this.gxTv_SdtCliente_Contatotelefonenumero_Z_SetNull( );
               this.gxTv_SdtCliente_Contatotelefoneddd_Z_SetNull( );
               this.gxTv_SdtCliente_Contatotelefoneddi_Z_SetNull( );
               this.gxTv_SdtCliente_Clienterg_Z_SetNull( );
               this.gxTv_SdtCliente_Clientetelefone_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clientecelular_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clienteqtdtitulos_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clientevalorapagar_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clientevalorareceber_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clientedepositotipo_Z_SetNull( );
               this.gxTv_SdtCliente_Clientepixtipo_Z_SetNull( );
               this.gxTv_SdtCliente_Clientepix_Z_SetNull( );
               this.gxTv_SdtCliente_Bancoid_Z_SetNull( );
               this.gxTv_SdtCliente_Bancocodigo_Z_SetNull( );
               this.gxTv_SdtCliente_Banconome_Z_SetNull( );
               this.gxTv_SdtCliente_Contaagencia_Z_SetNull( );
               this.gxTv_SdtCliente_Contanumero_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelnome_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelnacionalidade_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelnacionalidadenome_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelestadocivil_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelprofissao_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelrg_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelprofissaonome_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcpf_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcep_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavellogradouro_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelbairro_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcidade_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelmunicipio_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelmunicipiouf_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelmunicipionome_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavellogradouronumero_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcomplemento_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelddd_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelnumero_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelemail_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcelular_f_Z_SetNull( );
               this.gxTv_SdtCliente_Serasaconsultas_f_Z_SetNull( );
               this.gxTv_SdtCliente_Serasaultimadata_f_Z_SetNull( );
               this.gxTv_SdtCliente_Serasascoreultimadata_f_Z_SetNull( );
               this.gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z_SetNull( );
               this.gxTv_SdtCliente_Clientesituacao_Z_SetNull( );
               this.gxTv_SdtCliente_Responsavelcargo_Z_SetNull( );
               this.gxTv_SdtCliente_Tipoclienteportalpjpf_Z_SetNull( );
               this.gxTv_SdtCliente_Relacionamentosacado_Z_SetNull( );
               this.gxTv_SdtCliente_Clientesacado_Z_SetNull( );
               this.gxTv_SdtCliente_Clientetiporisco_Z_SetNull( );
            }
            gxTv_SdtCliente_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      [  SoapElement( ElementName = "ClienteDocumento" )]
      [  XmlElement( ElementName = "ClienteDocumento"   )]
      public string gxTpr_Clientedocumento
      {
         get {
            return gxTv_SdtCliente_Clientedocumento ;
         }

         set {
            gxTv_SdtCliente_Clientedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedocumento = value;
            SetDirty("Clientedocumento");
         }

      }

      public void gxTv_SdtCliente_Clientedocumento_SetNull( )
      {
         gxTv_SdtCliente_Clientedocumento_N = 1;
         gxTv_SdtCliente_Clientedocumento = "";
         SetDirty("Clientedocumento");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedocumento_IsNull( )
      {
         return (gxTv_SdtCliente_Clientedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial"   )]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return gxTv_SdtCliente_Clienterazaosocial ;
         }

         set {
            gxTv_SdtCliente_Clienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterazaosocial = value;
            SetDirty("Clienterazaosocial");
         }

      }

      public void gxTv_SdtCliente_Clienterazaosocial_SetNull( )
      {
         gxTv_SdtCliente_Clienterazaosocial_N = 1;
         gxTv_SdtCliente_Clienterazaosocial = "";
         SetDirty("Clienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterazaosocial_IsNull( )
      {
         return (gxTv_SdtCliente_Clienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteNomeFantasia" )]
      [  XmlElement( ElementName = "ClienteNomeFantasia"   )]
      public string gxTpr_Clientenomefantasia
      {
         get {
            return gxTv_SdtCliente_Clientenomefantasia ;
         }

         set {
            gxTv_SdtCliente_Clientenomefantasia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenomefantasia = value;
            SetDirty("Clientenomefantasia");
         }

      }

      public void gxTv_SdtCliente_Clientenomefantasia_SetNull( )
      {
         gxTv_SdtCliente_Clientenomefantasia_N = 1;
         gxTv_SdtCliente_Clientenomefantasia = "";
         SetDirty("Clientenomefantasia");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenomefantasia_IsNull( )
      {
         return (gxTv_SdtCliente_Clientenomefantasia_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDataNascimento" )]
      [  XmlElement( ElementName = "ClienteDataNascimento"  , IsNullable=true )]
      public string gxTpr_Clientedatanascimento_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clientedatanascimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCliente_Clientedatanascimento).value ;
         }

         set {
            gxTv_SdtCliente_Clientedatanascimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCliente_Clientedatanascimento = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clientedatanascimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedatanascimento
      {
         get {
            return gxTv_SdtCliente_Clientedatanascimento ;
         }

         set {
            gxTv_SdtCliente_Clientedatanascimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedatanascimento = value;
            SetDirty("Clientedatanascimento");
         }

      }

      public void gxTv_SdtCliente_Clientedatanascimento_SetNull( )
      {
         gxTv_SdtCliente_Clientedatanascimento_N = 1;
         gxTv_SdtCliente_Clientedatanascimento = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedatanascimento");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedatanascimento_IsNull( )
      {
         return (gxTv_SdtCliente_Clientedatanascimento_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTipoPessoa" )]
      [  XmlElement( ElementName = "ClienteTipoPessoa"   )]
      public string gxTpr_Clientetipopessoa
      {
         get {
            return gxTv_SdtCliente_Clientetipopessoa ;
         }

         set {
            gxTv_SdtCliente_Clientetipopessoa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetipopessoa = value;
            SetDirty("Clientetipopessoa");
         }

      }

      public void gxTv_SdtCliente_Clientetipopessoa_SetNull( )
      {
         gxTv_SdtCliente_Clientetipopessoa_N = 1;
         gxTv_SdtCliente_Clientetipopessoa = "";
         SetDirty("Clientetipopessoa");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetipopessoa_IsNull( )
      {
         return (gxTv_SdtCliente_Clientetipopessoa_N==1) ;
      }

      [  SoapElement( ElementName = "EspecialidadeId" )]
      [  XmlElement( ElementName = "EspecialidadeId"   )]
      public int gxTpr_Especialidadeid
      {
         get {
            return gxTv_SdtCliente_Especialidadeid ;
         }

         set {
            gxTv_SdtCliente_Especialidadeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Especialidadeid = value;
            SetDirty("Especialidadeid");
         }

      }

      public void gxTv_SdtCliente_Especialidadeid_SetNull( )
      {
         gxTv_SdtCliente_Especialidadeid_N = 1;
         gxTv_SdtCliente_Especialidadeid = 0;
         SetDirty("Especialidadeid");
         return  ;
      }

      public bool gxTv_SdtCliente_Especialidadeid_IsNull( )
      {
         return (gxTv_SdtCliente_Especialidadeid_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteId" )]
      [  XmlElement( ElementName = "TipoClienteId"   )]
      public short gxTpr_Tipoclienteid
      {
         get {
            return gxTv_SdtCliente_Tipoclienteid ;
         }

         set {
            gxTv_SdtCliente_Tipoclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteid = value;
            SetDirty("Tipoclienteid");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteid_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteid_N = 1;
         gxTv_SdtCliente_Tipoclienteid = 0;
         SetDirty("Tipoclienteid");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteid_IsNull( )
      {
         return (gxTv_SdtCliente_Tipoclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteDescricao" )]
      [  XmlElement( ElementName = "TipoClienteDescricao"   )]
      public string gxTpr_Tipoclientedescricao
      {
         get {
            return gxTv_SdtCliente_Tipoclientedescricao ;
         }

         set {
            gxTv_SdtCliente_Tipoclientedescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclientedescricao = value;
            SetDirty("Tipoclientedescricao");
         }

      }

      public void gxTv_SdtCliente_Tipoclientedescricao_SetNull( )
      {
         gxTv_SdtCliente_Tipoclientedescricao_N = 1;
         gxTv_SdtCliente_Tipoclientedescricao = "";
         SetDirty("Tipoclientedescricao");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclientedescricao_IsNull( )
      {
         return (gxTv_SdtCliente_Tipoclientedescricao_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClientePortal" )]
      [  XmlElement( ElementName = "TipoClientePortal"   )]
      public bool gxTpr_Tipoclienteportal
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportal ;
         }

         set {
            gxTv_SdtCliente_Tipoclienteportal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportal = value;
            SetDirty("Tipoclienteportal");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportal_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportal_N = 1;
         gxTv_SdtCliente_Tipoclienteportal = false;
         SetDirty("Tipoclienteportal");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportal_IsNull( )
      {
         return (gxTv_SdtCliente_Tipoclienteportal_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteStatus" )]
      [  XmlElement( ElementName = "ClienteStatus"   )]
      public bool gxTpr_Clientestatus
      {
         get {
            return gxTv_SdtCliente_Clientestatus ;
         }

         set {
            gxTv_SdtCliente_Clientestatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientestatus = value;
            SetDirty("Clientestatus");
         }

      }

      public void gxTv_SdtCliente_Clientestatus_SetNull( )
      {
         gxTv_SdtCliente_Clientestatus_N = 1;
         gxTv_SdtCliente_Clientestatus = false;
         SetDirty("Clientestatus");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientestatus_IsNull( )
      {
         return (gxTv_SdtCliente_Clientestatus_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteConvenio" )]
      [  XmlElement( ElementName = "ClienteConvenio"   )]
      public int gxTpr_Clienteconvenio
      {
         get {
            return gxTv_SdtCliente_Clienteconvenio ;
         }

         set {
            gxTv_SdtCliente_Clienteconvenio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconvenio = value;
            SetDirty("Clienteconvenio");
         }

      }

      public void gxTv_SdtCliente_Clienteconvenio_SetNull( )
      {
         gxTv_SdtCliente_Clienteconvenio_N = 1;
         gxTv_SdtCliente_Clienteconvenio = 0;
         SetDirty("Clienteconvenio");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconvenio_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteconvenio_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteConvenioDescricao" )]
      [  XmlElement( ElementName = "ClienteConvenioDescricao"   )]
      public string gxTpr_Clienteconveniodescricao
      {
         get {
            return gxTv_SdtCliente_Clienteconveniodescricao ;
         }

         set {
            gxTv_SdtCliente_Clienteconveniodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconveniodescricao = value;
            SetDirty("Clienteconveniodescricao");
         }

      }

      public void gxTv_SdtCliente_Clienteconveniodescricao_SetNull( )
      {
         gxTv_SdtCliente_Clienteconveniodescricao_N = 1;
         gxTv_SdtCliente_Clienteconveniodescricao = "";
         SetDirty("Clienteconveniodescricao");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconveniodescricao_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteconveniodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteCreatedAt" )]
      [  XmlElement( ElementName = "ClienteCreatedAt"  , IsNullable=true )]
      public string gxTpr_Clientecreatedat_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clientecreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Clientecreatedat).value ;
         }

         set {
            gxTv_SdtCliente_Clientecreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Clientecreatedat = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clientecreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientecreatedat
      {
         get {
            return gxTv_SdtCliente_Clientecreatedat ;
         }

         set {
            gxTv_SdtCliente_Clientecreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecreatedat = value;
            SetDirty("Clientecreatedat");
         }

      }

      public void gxTv_SdtCliente_Clientecreatedat_SetNull( )
      {
         gxTv_SdtCliente_Clientecreatedat_N = 1;
         gxTv_SdtCliente_Clientecreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clientecreatedat");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientecreatedat_IsNull( )
      {
         return (gxTv_SdtCliente_Clientecreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteUpdatedAt" )]
      [  XmlElement( ElementName = "ClienteUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Clienteupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clienteupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Clienteupdatedat).value ;
         }

         set {
            gxTv_SdtCliente_Clienteupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Clienteupdatedat = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clienteupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clienteupdatedat
      {
         get {
            return gxTv_SdtCliente_Clienteupdatedat ;
         }

         set {
            gxTv_SdtCliente_Clienteupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteupdatedat = value;
            SetDirty("Clienteupdatedat");
         }

      }

      public void gxTv_SdtCliente_Clienteupdatedat_SetNull( )
      {
         gxTv_SdtCliente_Clienteupdatedat_N = 1;
         gxTv_SdtCliente_Clienteupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clienteupdatedat");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteupdatedat_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteLogUser" )]
      [  XmlElement( ElementName = "ClienteLogUser"   )]
      public short gxTpr_Clienteloguser
      {
         get {
            return gxTv_SdtCliente_Clienteloguser ;
         }

         set {
            gxTv_SdtCliente_Clienteloguser_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteloguser = value;
            SetDirty("Clienteloguser");
         }

      }

      public void gxTv_SdtCliente_Clienteloguser_SetNull( )
      {
         gxTv_SdtCliente_Clienteloguser_N = 1;
         gxTv_SdtCliente_Clienteloguser = 0;
         SetDirty("Clienteloguser");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteloguser_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteloguser_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidade" )]
      [  XmlElement( ElementName = "ClienteNacionalidade"   )]
      public int gxTpr_Clientenacionalidade
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidade ;
         }

         set {
            gxTv_SdtCliente_Clientenacionalidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidade = value;
            SetDirty("Clientenacionalidade");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidade_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidade_N = 1;
         gxTv_SdtCliente_Clientenacionalidade = 0;
         SetDirty("Clientenacionalidade");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidade_IsNull( )
      {
         return (gxTv_SdtCliente_Clientenacionalidade_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidadeNome" )]
      [  XmlElement( ElementName = "ClienteNacionalidadeNome"   )]
      public string gxTpr_Clientenacionalidadenome
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidadenome ;
         }

         set {
            gxTv_SdtCliente_Clientenacionalidadenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidadenome = value;
            SetDirty("Clientenacionalidadenome");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidadenome_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidadenome_N = 1;
         gxTv_SdtCliente_Clientenacionalidadenome = "";
         SetDirty("Clientenacionalidadenome");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidadenome_IsNull( )
      {
         return (gxTv_SdtCliente_Clientenacionalidadenome_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteProfissao" )]
      [  XmlElement( ElementName = "ClienteProfissao"   )]
      public int gxTpr_Clienteprofissao
      {
         get {
            return gxTv_SdtCliente_Clienteprofissao ;
         }

         set {
            gxTv_SdtCliente_Clienteprofissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissao = value;
            SetDirty("Clienteprofissao");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissao_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissao_N = 1;
         gxTv_SdtCliente_Clienteprofissao = 0;
         SetDirty("Clienteprofissao");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissao_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteprofissao_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteProfissaoNome" )]
      [  XmlElement( ElementName = "ClienteProfissaoNome"   )]
      public string gxTpr_Clienteprofissaonome
      {
         get {
            return gxTv_SdtCliente_Clienteprofissaonome ;
         }

         set {
            gxTv_SdtCliente_Clienteprofissaonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissaonome = value;
            SetDirty("Clienteprofissaonome");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissaonome_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissaonome_N = 1;
         gxTv_SdtCliente_Clienteprofissaonome = "";
         SetDirty("Clienteprofissaonome");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissaonome_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteprofissaonome_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteEstadoCivil" )]
      [  XmlElement( ElementName = "ClienteEstadoCivil"   )]
      public string gxTpr_Clienteestadocivil
      {
         get {
            return gxTv_SdtCliente_Clienteestadocivil ;
         }

         set {
            gxTv_SdtCliente_Clienteestadocivil_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteestadocivil = value;
            SetDirty("Clienteestadocivil");
         }

      }

      public void gxTv_SdtCliente_Clienteestadocivil_SetNull( )
      {
         gxTv_SdtCliente_Clienteestadocivil_N = 1;
         gxTv_SdtCliente_Clienteestadocivil = "";
         SetDirty("Clienteestadocivil");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteestadocivil_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteestadocivil_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserId_F" )]
      [  XmlElement( ElementName = "SecUserId_F"   )]
      public short gxTpr_Secuserid_f
      {
         get {
            return gxTv_SdtCliente_Secuserid_f ;
         }

         set {
            gxTv_SdtCliente_Secuserid_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Secuserid_f = value;
            SetDirty("Secuserid_f");
         }

      }

      public void gxTv_SdtCliente_Secuserid_f_SetNull( )
      {
         gxTv_SdtCliente_Secuserid_f_N = 1;
         gxTv_SdtCliente_Secuserid_f = 0;
         SetDirty("Secuserid_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Secuserid_f_IsNull( )
      {
         return (gxTv_SdtCliente_Secuserid_f_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoTipo" )]
      [  XmlElement( ElementName = "EnderecoTipo"   )]
      public string gxTpr_Enderecotipo
      {
         get {
            return gxTv_SdtCliente_Enderecotipo ;
         }

         set {
            gxTv_SdtCliente_Enderecotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecotipo = value;
            SetDirty("Enderecotipo");
         }

      }

      public void gxTv_SdtCliente_Enderecotipo_SetNull( )
      {
         gxTv_SdtCliente_Enderecotipo_N = 1;
         gxTv_SdtCliente_Enderecotipo = "";
         SetDirty("Enderecotipo");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecotipo_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecotipo_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoCEP" )]
      [  XmlElement( ElementName = "EnderecoCEP"   )]
      public string gxTpr_Enderecocep
      {
         get {
            return gxTv_SdtCliente_Enderecocep ;
         }

         set {
            gxTv_SdtCliente_Enderecocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocep = value;
            SetDirty("Enderecocep");
         }

      }

      public void gxTv_SdtCliente_Enderecocep_SetNull( )
      {
         gxTv_SdtCliente_Enderecocep_N = 1;
         gxTv_SdtCliente_Enderecocep = "";
         SetDirty("Enderecocep");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocep_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecocep_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoLogradouro" )]
      [  XmlElement( ElementName = "EnderecoLogradouro"   )]
      public string gxTpr_Enderecologradouro
      {
         get {
            return gxTv_SdtCliente_Enderecologradouro ;
         }

         set {
            gxTv_SdtCliente_Enderecologradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecologradouro = value;
            SetDirty("Enderecologradouro");
         }

      }

      public void gxTv_SdtCliente_Enderecologradouro_SetNull( )
      {
         gxTv_SdtCliente_Enderecologradouro_N = 1;
         gxTv_SdtCliente_Enderecologradouro = "";
         SetDirty("Enderecologradouro");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecologradouro_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecologradouro_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoBairro" )]
      [  XmlElement( ElementName = "EnderecoBairro"   )]
      public string gxTpr_Enderecobairro
      {
         get {
            return gxTv_SdtCliente_Enderecobairro ;
         }

         set {
            gxTv_SdtCliente_Enderecobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecobairro = value;
            SetDirty("Enderecobairro");
         }

      }

      public void gxTv_SdtCliente_Enderecobairro_SetNull( )
      {
         gxTv_SdtCliente_Enderecobairro_N = 1;
         gxTv_SdtCliente_Enderecobairro = "";
         SetDirty("Enderecobairro");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecobairro_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecobairro_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoCidade" )]
      [  XmlElement( ElementName = "EnderecoCidade"   )]
      public string gxTpr_Enderecocidade
      {
         get {
            return gxTv_SdtCliente_Enderecocidade ;
         }

         set {
            gxTv_SdtCliente_Enderecocidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocidade = value;
            SetDirty("Enderecocidade");
         }

      }

      public void gxTv_SdtCliente_Enderecocidade_SetNull( )
      {
         gxTv_SdtCliente_Enderecocidade_N = 1;
         gxTv_SdtCliente_Enderecocidade = "";
         SetDirty("Enderecocidade");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocidade_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecocidade_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo" )]
      [  XmlElement( ElementName = "MunicipioCodigo"   )]
      public string gxTpr_Municipiocodigo
      {
         get {
            return gxTv_SdtCliente_Municipiocodigo ;
         }

         set {
            gxTv_SdtCliente_Municipiocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiocodigo = value;
            SetDirty("Municipiocodigo");
         }

      }

      public void gxTv_SdtCliente_Municipiocodigo_SetNull( )
      {
         gxTv_SdtCliente_Municipiocodigo_N = 1;
         gxTv_SdtCliente_Municipiocodigo = "";
         SetDirty("Municipiocodigo");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiocodigo_IsNull( )
      {
         return (gxTv_SdtCliente_Municipiocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioNome" )]
      [  XmlElement( ElementName = "MunicipioNome"   )]
      public string gxTpr_Municipionome
      {
         get {
            return gxTv_SdtCliente_Municipionome ;
         }

         set {
            gxTv_SdtCliente_Municipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipionome = value;
            SetDirty("Municipionome");
         }

      }

      public void gxTv_SdtCliente_Municipionome_SetNull( )
      {
         gxTv_SdtCliente_Municipionome_N = 1;
         gxTv_SdtCliente_Municipionome = "";
         SetDirty("Municipionome");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipionome_IsNull( )
      {
         return (gxTv_SdtCliente_Municipionome_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioUF" )]
      [  XmlElement( ElementName = "MunicipioUF"   )]
      public string gxTpr_Municipiouf
      {
         get {
            return gxTv_SdtCliente_Municipiouf ;
         }

         set {
            gxTv_SdtCliente_Municipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiouf = value;
            SetDirty("Municipiouf");
         }

      }

      public void gxTv_SdtCliente_Municipiouf_SetNull( )
      {
         gxTv_SdtCliente_Municipiouf_N = 1;
         gxTv_SdtCliente_Municipiouf = "";
         SetDirty("Municipiouf");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiouf_IsNull( )
      {
         return (gxTv_SdtCliente_Municipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoNumero" )]
      [  XmlElement( ElementName = "EnderecoNumero"   )]
      public string gxTpr_Endereconumero
      {
         get {
            return gxTv_SdtCliente_Endereconumero ;
         }

         set {
            gxTv_SdtCliente_Endereconumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Endereconumero = value;
            SetDirty("Endereconumero");
         }

      }

      public void gxTv_SdtCliente_Endereconumero_SetNull( )
      {
         gxTv_SdtCliente_Endereconumero_N = 1;
         gxTv_SdtCliente_Endereconumero = "";
         SetDirty("Endereconumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Endereconumero_IsNull( )
      {
         return (gxTv_SdtCliente_Endereconumero_N==1) ;
      }

      [  SoapElement( ElementName = "EnderecoComplemento" )]
      [  XmlElement( ElementName = "EnderecoComplemento"   )]
      public string gxTpr_Enderecocomplemento
      {
         get {
            return gxTv_SdtCliente_Enderecocomplemento ;
         }

         set {
            gxTv_SdtCliente_Enderecocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocomplemento = value;
            SetDirty("Enderecocomplemento");
         }

      }

      public void gxTv_SdtCliente_Enderecocomplemento_SetNull( )
      {
         gxTv_SdtCliente_Enderecocomplemento_N = 1;
         gxTv_SdtCliente_Enderecocomplemento = "";
         SetDirty("Enderecocomplemento");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocomplemento_IsNull( )
      {
         return (gxTv_SdtCliente_Enderecocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoEmail" )]
      [  XmlElement( ElementName = "ContatoEmail"   )]
      public string gxTpr_Contatoemail
      {
         get {
            return gxTv_SdtCliente_Contatoemail ;
         }

         set {
            gxTv_SdtCliente_Contatoemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoemail = value;
            SetDirty("Contatoemail");
         }

      }

      public void gxTv_SdtCliente_Contatoemail_SetNull( )
      {
         gxTv_SdtCliente_Contatoemail_N = 1;
         gxTv_SdtCliente_Contatoemail = "";
         SetDirty("Contatoemail");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoemail_IsNull( )
      {
         return (gxTv_SdtCliente_Contatoemail_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoDDD" )]
      [  XmlElement( ElementName = "ContatoDDD"   )]
      public short gxTpr_Contatoddd
      {
         get {
            return gxTv_SdtCliente_Contatoddd ;
         }

         set {
            gxTv_SdtCliente_Contatoddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddd = value;
            SetDirty("Contatoddd");
         }

      }

      public void gxTv_SdtCliente_Contatoddd_SetNull( )
      {
         gxTv_SdtCliente_Contatoddd_N = 1;
         gxTv_SdtCliente_Contatoddd = 0;
         SetDirty("Contatoddd");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddd_IsNull( )
      {
         return (gxTv_SdtCliente_Contatoddd_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoDDI" )]
      [  XmlElement( ElementName = "ContatoDDI"   )]
      public short gxTpr_Contatoddi
      {
         get {
            return gxTv_SdtCliente_Contatoddi ;
         }

         set {
            gxTv_SdtCliente_Contatoddi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddi = value;
            SetDirty("Contatoddi");
         }

      }

      public void gxTv_SdtCliente_Contatoddi_SetNull( )
      {
         gxTv_SdtCliente_Contatoddi_N = 1;
         gxTv_SdtCliente_Contatoddi = 0;
         SetDirty("Contatoddi");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddi_IsNull( )
      {
         return (gxTv_SdtCliente_Contatoddi_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoNumero" )]
      [  XmlElement( ElementName = "ContatoNumero"   )]
      public long gxTpr_Contatonumero
      {
         get {
            return gxTv_SdtCliente_Contatonumero ;
         }

         set {
            gxTv_SdtCliente_Contatonumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatonumero = value;
            SetDirty("Contatonumero");
         }

      }

      public void gxTv_SdtCliente_Contatonumero_SetNull( )
      {
         gxTv_SdtCliente_Contatonumero_N = 1;
         gxTv_SdtCliente_Contatonumero = 0;
         SetDirty("Contatonumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatonumero_IsNull( )
      {
         return (gxTv_SdtCliente_Contatonumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneNumero" )]
      [  XmlElement( ElementName = "ContatoTelefoneNumero"   )]
      public long gxTpr_Contatotelefonenumero
      {
         get {
            return gxTv_SdtCliente_Contatotelefonenumero ;
         }

         set {
            gxTv_SdtCliente_Contatotelefonenumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefonenumero = value;
            SetDirty("Contatotelefonenumero");
         }

      }

      public void gxTv_SdtCliente_Contatotelefonenumero_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefonenumero_N = 1;
         gxTv_SdtCliente_Contatotelefonenumero = 0;
         SetDirty("Contatotelefonenumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefonenumero_IsNull( )
      {
         return (gxTv_SdtCliente_Contatotelefonenumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDD" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDD"   )]
      public short gxTpr_Contatotelefoneddd
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddd ;
         }

         set {
            gxTv_SdtCliente_Contatotelefoneddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddd = value;
            SetDirty("Contatotelefoneddd");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddd_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddd_N = 1;
         gxTv_SdtCliente_Contatotelefoneddd = 0;
         SetDirty("Contatotelefoneddd");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddd_IsNull( )
      {
         return (gxTv_SdtCliente_Contatotelefoneddd_N==1) ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDI" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDI"   )]
      public short gxTpr_Contatotelefoneddi
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddi ;
         }

         set {
            gxTv_SdtCliente_Contatotelefoneddi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddi = value;
            SetDirty("Contatotelefoneddi");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddi_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddi_N = 1;
         gxTv_SdtCliente_Contatotelefoneddi = 0;
         SetDirty("Contatotelefoneddi");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddi_IsNull( )
      {
         return (gxTv_SdtCliente_Contatotelefoneddi_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRG" )]
      [  XmlElement( ElementName = "ClienteRG"   )]
      public long gxTpr_Clienterg
      {
         get {
            return gxTv_SdtCliente_Clienterg ;
         }

         set {
            gxTv_SdtCliente_Clienterg_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterg = value;
            SetDirty("Clienterg");
         }

      }

      public void gxTv_SdtCliente_Clienterg_SetNull( )
      {
         gxTv_SdtCliente_Clienterg_N = 1;
         gxTv_SdtCliente_Clienterg = 0;
         SetDirty("Clienterg");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterg_IsNull( )
      {
         return (gxTv_SdtCliente_Clienterg_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTelefone_F" )]
      [  XmlElement( ElementName = "ClienteTelefone_F"   )]
      public string gxTpr_Clientetelefone_f
      {
         get {
            return gxTv_SdtCliente_Clientetelefone_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetelefone_f = value;
            SetDirty("Clientetelefone_f");
         }

      }

      public void gxTv_SdtCliente_Clientetelefone_f_SetNull( )
      {
         gxTv_SdtCliente_Clientetelefone_f = "";
         SetDirty("Clientetelefone_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetelefone_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCelular_F" )]
      [  XmlElement( ElementName = "ClienteCelular_F"   )]
      public string gxTpr_Clientecelular_f
      {
         get {
            return gxTv_SdtCliente_Clientecelular_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecelular_f = value;
            SetDirty("Clientecelular_f");
         }

      }

      public void gxTv_SdtCliente_Clientecelular_f_SetNull( )
      {
         gxTv_SdtCliente_Clientecelular_f = "";
         SetDirty("Clientecelular_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientecelular_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteQtdTitulos_F" )]
      [  XmlElement( ElementName = "ClienteQtdTitulos_F"   )]
      public int gxTpr_Clienteqtdtitulos_f
      {
         get {
            return gxTv_SdtCliente_Clienteqtdtitulos_f ;
         }

         set {
            gxTv_SdtCliente_Clienteqtdtitulos_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteqtdtitulos_f = value;
            SetDirty("Clienteqtdtitulos_f");
         }

      }

      public void gxTv_SdtCliente_Clienteqtdtitulos_f_SetNull( )
      {
         gxTv_SdtCliente_Clienteqtdtitulos_f_N = 1;
         gxTv_SdtCliente_Clienteqtdtitulos_f = 0;
         SetDirty("Clienteqtdtitulos_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteqtdtitulos_f_IsNull( )
      {
         return (gxTv_SdtCliente_Clienteqtdtitulos_f_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteValorAPagar_F" )]
      [  XmlElement( ElementName = "ClienteValorAPagar_F"   )]
      public decimal gxTpr_Clientevalorapagar_f
      {
         get {
            return gxTv_SdtCliente_Clientevalorapagar_f ;
         }

         set {
            gxTv_SdtCliente_Clientevalorapagar_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorapagar_f = value;
            SetDirty("Clientevalorapagar_f");
         }

      }

      public void gxTv_SdtCliente_Clientevalorapagar_f_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorapagar_f_N = 1;
         gxTv_SdtCliente_Clientevalorapagar_f = 0;
         SetDirty("Clientevalorapagar_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorapagar_f_IsNull( )
      {
         return (gxTv_SdtCliente_Clientevalorapagar_f_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteValorAReceber_F" )]
      [  XmlElement( ElementName = "ClienteValorAReceber_F"   )]
      public decimal gxTpr_Clientevalorareceber_f
      {
         get {
            return gxTv_SdtCliente_Clientevalorareceber_f ;
         }

         set {
            gxTv_SdtCliente_Clientevalorareceber_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorareceber_f = value;
            SetDirty("Clientevalorareceber_f");
         }

      }

      public void gxTv_SdtCliente_Clientevalorareceber_f_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorareceber_f_N = 1;
         gxTv_SdtCliente_Clientevalorareceber_f = 0;
         SetDirty("Clientevalorareceber_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorareceber_f_IsNull( )
      {
         return (gxTv_SdtCliente_Clientevalorareceber_f_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDepositoTipo" )]
      [  XmlElement( ElementName = "ClienteDepositoTipo"   )]
      public string gxTpr_Clientedepositotipo
      {
         get {
            return gxTv_SdtCliente_Clientedepositotipo ;
         }

         set {
            gxTv_SdtCliente_Clientedepositotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedepositotipo = value;
            SetDirty("Clientedepositotipo");
         }

      }

      public void gxTv_SdtCliente_Clientedepositotipo_SetNull( )
      {
         gxTv_SdtCliente_Clientedepositotipo_N = 1;
         gxTv_SdtCliente_Clientedepositotipo = "";
         SetDirty("Clientedepositotipo");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedepositotipo_IsNull( )
      {
         return (gxTv_SdtCliente_Clientedepositotipo_N==1) ;
      }

      [  SoapElement( ElementName = "ClientePixTipo" )]
      [  XmlElement( ElementName = "ClientePixTipo"   )]
      public string gxTpr_Clientepixtipo
      {
         get {
            return gxTv_SdtCliente_Clientepixtipo ;
         }

         set {
            gxTv_SdtCliente_Clientepixtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepixtipo = value;
            SetDirty("Clientepixtipo");
         }

      }

      public void gxTv_SdtCliente_Clientepixtipo_SetNull( )
      {
         gxTv_SdtCliente_Clientepixtipo_N = 1;
         gxTv_SdtCliente_Clientepixtipo = "";
         SetDirty("Clientepixtipo");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepixtipo_IsNull( )
      {
         return (gxTv_SdtCliente_Clientepixtipo_N==1) ;
      }

      [  SoapElement( ElementName = "ClientePix" )]
      [  XmlElement( ElementName = "ClientePix"   )]
      public string gxTpr_Clientepix
      {
         get {
            return gxTv_SdtCliente_Clientepix ;
         }

         set {
            gxTv_SdtCliente_Clientepix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepix = value;
            SetDirty("Clientepix");
         }

      }

      public void gxTv_SdtCliente_Clientepix_SetNull( )
      {
         gxTv_SdtCliente_Clientepix_N = 1;
         gxTv_SdtCliente_Clientepix = "";
         SetDirty("Clientepix");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepix_IsNull( )
      {
         return (gxTv_SdtCliente_Clientepix_N==1) ;
      }

      [  SoapElement( ElementName = "BancoId" )]
      [  XmlElement( ElementName = "BancoId"   )]
      public int gxTpr_Bancoid
      {
         get {
            return gxTv_SdtCliente_Bancoid ;
         }

         set {
            gxTv_SdtCliente_Bancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancoid = value;
            SetDirty("Bancoid");
         }

      }

      public void gxTv_SdtCliente_Bancoid_SetNull( )
      {
         gxTv_SdtCliente_Bancoid_N = 1;
         gxTv_SdtCliente_Bancoid = 0;
         SetDirty("Bancoid");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancoid_IsNull( )
      {
         return (gxTv_SdtCliente_Bancoid_N==1) ;
      }

      [  SoapElement( ElementName = "BancoCodigo" )]
      [  XmlElement( ElementName = "BancoCodigo"   )]
      public int gxTpr_Bancocodigo
      {
         get {
            return gxTv_SdtCliente_Bancocodigo ;
         }

         set {
            gxTv_SdtCliente_Bancocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancocodigo = value;
            SetDirty("Bancocodigo");
         }

      }

      public void gxTv_SdtCliente_Bancocodigo_SetNull( )
      {
         gxTv_SdtCliente_Bancocodigo_N = 1;
         gxTv_SdtCliente_Bancocodigo = 0;
         SetDirty("Bancocodigo");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancocodigo_IsNull( )
      {
         return (gxTv_SdtCliente_Bancocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNome" )]
      [  XmlElement( ElementName = "BancoNome"   )]
      public string gxTpr_Banconome
      {
         get {
            return gxTv_SdtCliente_Banconome ;
         }

         set {
            gxTv_SdtCliente_Banconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Banconome = value;
            SetDirty("Banconome");
         }

      }

      public void gxTv_SdtCliente_Banconome_SetNull( )
      {
         gxTv_SdtCliente_Banconome_N = 1;
         gxTv_SdtCliente_Banconome = "";
         SetDirty("Banconome");
         return  ;
      }

      public bool gxTv_SdtCliente_Banconome_IsNull( )
      {
         return (gxTv_SdtCliente_Banconome_N==1) ;
      }

      [  SoapElement( ElementName = "ContaAgencia" )]
      [  XmlElement( ElementName = "ContaAgencia"   )]
      public string gxTpr_Contaagencia
      {
         get {
            return gxTv_SdtCliente_Contaagencia ;
         }

         set {
            gxTv_SdtCliente_Contaagencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contaagencia = value;
            SetDirty("Contaagencia");
         }

      }

      public void gxTv_SdtCliente_Contaagencia_SetNull( )
      {
         gxTv_SdtCliente_Contaagencia_N = 1;
         gxTv_SdtCliente_Contaagencia = "";
         SetDirty("Contaagencia");
         return  ;
      }

      public bool gxTv_SdtCliente_Contaagencia_IsNull( )
      {
         return (gxTv_SdtCliente_Contaagencia_N==1) ;
      }

      [  SoapElement( ElementName = "ContaNumero" )]
      [  XmlElement( ElementName = "ContaNumero"   )]
      public string gxTpr_Contanumero
      {
         get {
            return gxTv_SdtCliente_Contanumero ;
         }

         set {
            gxTv_SdtCliente_Contanumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Contanumero = value;
            SetDirty("Contanumero");
         }

      }

      public void gxTv_SdtCliente_Contanumero_SetNull( )
      {
         gxTv_SdtCliente_Contanumero_N = 1;
         gxTv_SdtCliente_Contanumero = "";
         SetDirty("Contanumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Contanumero_IsNull( )
      {
         return (gxTv_SdtCliente_Contanumero_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelNome" )]
      [  XmlElement( ElementName = "ResponsavelNome"   )]
      public string gxTpr_Responsavelnome
      {
         get {
            return gxTv_SdtCliente_Responsavelnome ;
         }

         set {
            gxTv_SdtCliente_Responsavelnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnome = value;
            SetDirty("Responsavelnome");
         }

      }

      public void gxTv_SdtCliente_Responsavelnome_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnome_N = 1;
         gxTv_SdtCliente_Responsavelnome = "";
         SetDirty("Responsavelnome");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnome_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelnome_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidade" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidade"   )]
      public int gxTpr_Responsavelnacionalidade
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidade ;
         }

         set {
            gxTv_SdtCliente_Responsavelnacionalidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidade = value;
            SetDirty("Responsavelnacionalidade");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidade_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidade_N = 1;
         gxTv_SdtCliente_Responsavelnacionalidade = 0;
         SetDirty("Responsavelnacionalidade");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidade_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelnacionalidade_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidadeNome" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidadeNome"   )]
      public string gxTpr_Responsavelnacionalidadenome
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidadenome ;
         }

         set {
            gxTv_SdtCliente_Responsavelnacionalidadenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidadenome = value;
            SetDirty("Responsavelnacionalidadenome");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidadenome_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidadenome_N = 1;
         gxTv_SdtCliente_Responsavelnacionalidadenome = "";
         SetDirty("Responsavelnacionalidadenome");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidadenome_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelnacionalidadenome_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelEstadoCivil" )]
      [  XmlElement( ElementName = "ResponsavelEstadoCivil"   )]
      public string gxTpr_Responsavelestadocivil
      {
         get {
            return gxTv_SdtCliente_Responsavelestadocivil ;
         }

         set {
            gxTv_SdtCliente_Responsavelestadocivil_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelestadocivil = value;
            SetDirty("Responsavelestadocivil");
         }

      }

      public void gxTv_SdtCliente_Responsavelestadocivil_SetNull( )
      {
         gxTv_SdtCliente_Responsavelestadocivil_N = 1;
         gxTv_SdtCliente_Responsavelestadocivil = "";
         SetDirty("Responsavelestadocivil");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelestadocivil_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelestadocivil_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissao" )]
      [  XmlElement( ElementName = "ResponsavelProfissao"   )]
      public int gxTpr_Responsavelprofissao
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissao ;
         }

         set {
            gxTv_SdtCliente_Responsavelprofissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissao = value;
            SetDirty("Responsavelprofissao");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissao_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissao_N = 1;
         gxTv_SdtCliente_Responsavelprofissao = 0;
         SetDirty("Responsavelprofissao");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissao_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelprofissao_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelRG" )]
      [  XmlElement( ElementName = "ResponsavelRG"   )]
      public long gxTpr_Responsavelrg
      {
         get {
            return gxTv_SdtCliente_Responsavelrg ;
         }

         set {
            gxTv_SdtCliente_Responsavelrg_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelrg = value;
            SetDirty("Responsavelrg");
         }

      }

      public void gxTv_SdtCliente_Responsavelrg_SetNull( )
      {
         gxTv_SdtCliente_Responsavelrg_N = 1;
         gxTv_SdtCliente_Responsavelrg = 0;
         SetDirty("Responsavelrg");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelrg_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelrg_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissaoNome" )]
      [  XmlElement( ElementName = "ResponsavelProfissaoNome"   )]
      public string gxTpr_Responsavelprofissaonome
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissaonome ;
         }

         set {
            gxTv_SdtCliente_Responsavelprofissaonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissaonome = value;
            SetDirty("Responsavelprofissaonome");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissaonome_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissaonome_N = 1;
         gxTv_SdtCliente_Responsavelprofissaonome = "";
         SetDirty("Responsavelprofissaonome");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissaonome_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelprofissaonome_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelCPF" )]
      [  XmlElement( ElementName = "ResponsavelCPF"   )]
      public string gxTpr_Responsavelcpf
      {
         get {
            return gxTv_SdtCliente_Responsavelcpf ;
         }

         set {
            gxTv_SdtCliente_Responsavelcpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcpf = value;
            SetDirty("Responsavelcpf");
         }

      }

      public void gxTv_SdtCliente_Responsavelcpf_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcpf_N = 1;
         gxTv_SdtCliente_Responsavelcpf = "";
         SetDirty("Responsavelcpf");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcpf_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelcpf_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelCEP" )]
      [  XmlElement( ElementName = "ResponsavelCEP"   )]
      public string gxTpr_Responsavelcep
      {
         get {
            return gxTv_SdtCliente_Responsavelcep ;
         }

         set {
            gxTv_SdtCliente_Responsavelcep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcep = value;
            SetDirty("Responsavelcep");
         }

      }

      public void gxTv_SdtCliente_Responsavelcep_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcep_N = 1;
         gxTv_SdtCliente_Responsavelcep = "";
         SetDirty("Responsavelcep");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcep_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelcep_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouro" )]
      [  XmlElement( ElementName = "ResponsavelLogradouro"   )]
      public string gxTpr_Responsavellogradouro
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouro ;
         }

         set {
            gxTv_SdtCliente_Responsavellogradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouro = value;
            SetDirty("Responsavellogradouro");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouro_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouro_N = 1;
         gxTv_SdtCliente_Responsavellogradouro = "";
         SetDirty("Responsavellogradouro");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouro_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavellogradouro_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelBairro" )]
      [  XmlElement( ElementName = "ResponsavelBairro"   )]
      public string gxTpr_Responsavelbairro
      {
         get {
            return gxTv_SdtCliente_Responsavelbairro ;
         }

         set {
            gxTv_SdtCliente_Responsavelbairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelbairro = value;
            SetDirty("Responsavelbairro");
         }

      }

      public void gxTv_SdtCliente_Responsavelbairro_SetNull( )
      {
         gxTv_SdtCliente_Responsavelbairro_N = 1;
         gxTv_SdtCliente_Responsavelbairro = "";
         SetDirty("Responsavelbairro");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelbairro_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelbairro_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelCidade" )]
      [  XmlElement( ElementName = "ResponsavelCidade"   )]
      public string gxTpr_Responsavelcidade
      {
         get {
            return gxTv_SdtCliente_Responsavelcidade ;
         }

         set {
            gxTv_SdtCliente_Responsavelcidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcidade = value;
            SetDirty("Responsavelcidade");
         }

      }

      public void gxTv_SdtCliente_Responsavelcidade_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcidade_N = 1;
         gxTv_SdtCliente_Responsavelcidade = "";
         SetDirty("Responsavelcidade");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcidade_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelcidade_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipio" )]
      [  XmlElement( ElementName = "ResponsavelMunicipio"   )]
      public string gxTpr_Responsavelmunicipio
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipio ;
         }

         set {
            gxTv_SdtCliente_Responsavelmunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipio = value;
            SetDirty("Responsavelmunicipio");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipio_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipio_N = 1;
         gxTv_SdtCliente_Responsavelmunicipio = "";
         SetDirty("Responsavelmunicipio");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipio_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelmunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioUF" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioUF"   )]
      public string gxTpr_Responsavelmunicipiouf
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipiouf ;
         }

         set {
            gxTv_SdtCliente_Responsavelmunicipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipiouf = value;
            SetDirty("Responsavelmunicipiouf");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipiouf_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipiouf_N = 1;
         gxTv_SdtCliente_Responsavelmunicipiouf = "";
         SetDirty("Responsavelmunicipiouf");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipiouf_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelmunicipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioNome" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioNome"   )]
      public string gxTpr_Responsavelmunicipionome
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipionome ;
         }

         set {
            gxTv_SdtCliente_Responsavelmunicipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipionome = value;
            SetDirty("Responsavelmunicipionome");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipionome_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipionome_N = 1;
         gxTv_SdtCliente_Responsavelmunicipionome = "";
         SetDirty("Responsavelmunicipionome");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipionome_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelmunicipionome_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouroNumero" )]
      [  XmlElement( ElementName = "ResponsavelLogradouroNumero"   )]
      public int gxTpr_Responsavellogradouronumero
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouronumero ;
         }

         set {
            gxTv_SdtCliente_Responsavellogradouronumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouronumero = value;
            SetDirty("Responsavellogradouronumero");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouronumero_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouronumero_N = 1;
         gxTv_SdtCliente_Responsavellogradouronumero = 0;
         SetDirty("Responsavellogradouronumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouronumero_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavellogradouronumero_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelComplemento" )]
      [  XmlElement( ElementName = "ResponsavelComplemento"   )]
      public string gxTpr_Responsavelcomplemento
      {
         get {
            return gxTv_SdtCliente_Responsavelcomplemento ;
         }

         set {
            gxTv_SdtCliente_Responsavelcomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcomplemento = value;
            SetDirty("Responsavelcomplemento");
         }

      }

      public void gxTv_SdtCliente_Responsavelcomplemento_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcomplemento_N = 1;
         gxTv_SdtCliente_Responsavelcomplemento = "";
         SetDirty("Responsavelcomplemento");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcomplemento_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelcomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelDDD" )]
      [  XmlElement( ElementName = "ResponsavelDDD"   )]
      public short gxTpr_Responsavelddd
      {
         get {
            return gxTv_SdtCliente_Responsavelddd ;
         }

         set {
            gxTv_SdtCliente_Responsavelddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelddd = value;
            SetDirty("Responsavelddd");
         }

      }

      public void gxTv_SdtCliente_Responsavelddd_SetNull( )
      {
         gxTv_SdtCliente_Responsavelddd_N = 1;
         gxTv_SdtCliente_Responsavelddd = 0;
         SetDirty("Responsavelddd");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelddd_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelddd_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelNumero" )]
      [  XmlElement( ElementName = "ResponsavelNumero"   )]
      public int gxTpr_Responsavelnumero
      {
         get {
            return gxTv_SdtCliente_Responsavelnumero ;
         }

         set {
            gxTv_SdtCliente_Responsavelnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnumero = value;
            SetDirty("Responsavelnumero");
         }

      }

      public void gxTv_SdtCliente_Responsavelnumero_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnumero_N = 1;
         gxTv_SdtCliente_Responsavelnumero = 0;
         SetDirty("Responsavelnumero");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnumero_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelnumero_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelEmail" )]
      [  XmlElement( ElementName = "ResponsavelEmail"   )]
      public string gxTpr_Responsavelemail
      {
         get {
            return gxTv_SdtCliente_Responsavelemail ;
         }

         set {
            gxTv_SdtCliente_Responsavelemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelemail = value;
            SetDirty("Responsavelemail");
         }

      }

      public void gxTv_SdtCliente_Responsavelemail_SetNull( )
      {
         gxTv_SdtCliente_Responsavelemail_N = 1;
         gxTv_SdtCliente_Responsavelemail = "";
         SetDirty("Responsavelemail");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelemail_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelemail_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelCelular_F" )]
      [  XmlElement( ElementName = "ResponsavelCelular_F"   )]
      public string gxTpr_Responsavelcelular_f
      {
         get {
            return gxTv_SdtCliente_Responsavelcelular_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcelular_f = value;
            SetDirty("Responsavelcelular_f");
         }

      }

      public void gxTv_SdtCliente_Responsavelcelular_f_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcelular_f = "";
         SetDirty("Responsavelcelular_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcelular_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaConsultas_F" )]
      [  XmlElement( ElementName = "SerasaConsultas_F"   )]
      public short gxTpr_Serasaconsultas_f
      {
         get {
            return gxTv_SdtCliente_Serasaconsultas_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaconsultas_f = value;
            SetDirty("Serasaconsultas_f");
         }

      }

      public void gxTv_SdtCliente_Serasaconsultas_f_SetNull( )
      {
         gxTv_SdtCliente_Serasaconsultas_f = 0;
         SetDirty("Serasaconsultas_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaconsultas_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaUltimaData_F" )]
      [  XmlElement( ElementName = "SerasaUltimaData_F"  , IsNullable=true )]
      public string gxTpr_Serasaultimadata_f_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Serasaultimadata_f == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Serasaultimadata_f).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Serasaultimadata_f = DateTime.MinValue;
            else
               gxTv_SdtCliente_Serasaultimadata_f = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaultimadata_f
      {
         get {
            return gxTv_SdtCliente_Serasaultimadata_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimadata_f = value;
            SetDirty("Serasaultimadata_f");
         }

      }

      public void gxTv_SdtCliente_Serasaultimadata_f_SetNull( )
      {
         gxTv_SdtCliente_Serasaultimadata_f = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaultimadata_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaultimadata_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaScoreUltimaData_F" )]
      [  XmlElement( ElementName = "SerasaScoreUltimaData_F"   )]
      public short gxTpr_Serasascoreultimadata_f
      {
         get {
            return gxTv_SdtCliente_Serasascoreultimadata_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasascoreultimadata_f = value;
            SetDirty("Serasascoreultimadata_f");
         }

      }

      public void gxTv_SdtCliente_Serasascoreultimadata_f_SetNull( )
      {
         gxTv_SdtCliente_Serasascoreultimadata_f = 0;
         SetDirty("Serasascoreultimadata_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasascoreultimadata_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaUltimoValorRecomendado_F" )]
      [  XmlElement( ElementName = "SerasaUltimoValorRecomendado_F"   )]
      public decimal gxTpr_Serasaultimovalorrecomendado_f
      {
         get {
            return gxTv_SdtCliente_Serasaultimovalorrecomendado_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimovalorrecomendado_f = value;
            SetDirty("Serasaultimovalorrecomendado_f");
         }

      }

      public void gxTv_SdtCliente_Serasaultimovalorrecomendado_f_SetNull( )
      {
         gxTv_SdtCliente_Serasaultimovalorrecomendado_f = 0;
         SetDirty("Serasaultimovalorrecomendado_f");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaultimovalorrecomendado_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteSituacao" )]
      [  XmlElement( ElementName = "ClienteSituacao"   )]
      public string gxTpr_Clientesituacao
      {
         get {
            return gxTv_SdtCliente_Clientesituacao ;
         }

         set {
            gxTv_SdtCliente_Clientesituacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesituacao = value;
            SetDirty("Clientesituacao");
         }

      }

      public void gxTv_SdtCliente_Clientesituacao_SetNull( )
      {
         gxTv_SdtCliente_Clientesituacao_N = 1;
         gxTv_SdtCliente_Clientesituacao = "";
         SetDirty("Clientesituacao");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientesituacao_IsNull( )
      {
         return (gxTv_SdtCliente_Clientesituacao_N==1) ;
      }

      [  SoapElement( ElementName = "ResponsavelCargo" )]
      [  XmlElement( ElementName = "ResponsavelCargo"   )]
      public string gxTpr_Responsavelcargo
      {
         get {
            return gxTv_SdtCliente_Responsavelcargo ;
         }

         set {
            gxTv_SdtCliente_Responsavelcargo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcargo = value;
            SetDirty("Responsavelcargo");
         }

      }

      public void gxTv_SdtCliente_Responsavelcargo_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcargo_N = 1;
         gxTv_SdtCliente_Responsavelcargo = "";
         SetDirty("Responsavelcargo");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcargo_IsNull( )
      {
         return (gxTv_SdtCliente_Responsavelcargo_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf"   )]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportalpjpf ;
         }

         set {
            gxTv_SdtCliente_Tipoclienteportalpjpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportalpjpf = value;
            SetDirty("Tipoclienteportalpjpf");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportalpjpf_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportalpjpf_N = 1;
         gxTv_SdtCliente_Tipoclienteportalpjpf = false;
         SetDirty("Tipoclienteportalpjpf");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportalpjpf_IsNull( )
      {
         return (gxTv_SdtCliente_Tipoclienteportalpjpf_N==1) ;
      }

      [  SoapElement( ElementName = "RelacionamentoSacado" )]
      [  XmlElement( ElementName = "RelacionamentoSacado"   )]
      public short gxTpr_Relacionamentosacado
      {
         get {
            return gxTv_SdtCliente_Relacionamentosacado ;
         }

         set {
            gxTv_SdtCliente_Relacionamentosacado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCliente_Relacionamentosacado = value;
            SetDirty("Relacionamentosacado");
         }

      }

      public void gxTv_SdtCliente_Relacionamentosacado_SetNull( )
      {
         gxTv_SdtCliente_Relacionamentosacado_N = 1;
         gxTv_SdtCliente_Relacionamentosacado = 0;
         SetDirty("Relacionamentosacado");
         return  ;
      }

      public bool gxTv_SdtCliente_Relacionamentosacado_IsNull( )
      {
         return (gxTv_SdtCliente_Relacionamentosacado_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteSacado" )]
      [  XmlElement( ElementName = "ClienteSacado"   )]
      public bool gxTpr_Clientesacado
      {
         get {
            return gxTv_SdtCliente_Clientesacado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesacado = value;
            SetDirty("Clientesacado");
         }

      }

      public void gxTv_SdtCliente_Clientesacado_SetNull( )
      {
         gxTv_SdtCliente_Clientesacado = false;
         SetDirty("Clientesacado");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientesacado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTipoRisco" )]
      [  XmlElement( ElementName = "ClienteTipoRisco"   )]
      public string gxTpr_Clientetiporisco
      {
         get {
            return gxTv_SdtCliente_Clientetiporisco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetiporisco = value;
            SetDirty("Clientetiporisco");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCliente_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCliente_Mode_SetNull( )
      {
         gxTv_SdtCliente_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCliente_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCliente_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCliente_Initialized_SetNull( )
      {
         gxTv_SdtCliente_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCliente_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtCliente_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteid_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumento_Z" )]
      [  XmlElement( ElementName = "ClienteDocumento_Z"   )]
      public string gxTpr_Clientedocumento_Z
      {
         get {
            return gxTv_SdtCliente_Clientedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedocumento_Z = value;
            SetDirty("Clientedocumento_Z");
         }

      }

      public void gxTv_SdtCliente_Clientedocumento_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientedocumento_Z = "";
         SetDirty("Clientedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_Z"   )]
      public string gxTpr_Clienterazaosocial_Z
      {
         get {
            return gxTv_SdtCliente_Clienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterazaosocial_Z = value;
            SetDirty("Clienterazaosocial_Z");
         }

      }

      public void gxTv_SdtCliente_Clienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienterazaosocial_Z = "";
         SetDirty("Clienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNomeFantasia_Z" )]
      [  XmlElement( ElementName = "ClienteNomeFantasia_Z"   )]
      public string gxTpr_Clientenomefantasia_Z
      {
         get {
            return gxTv_SdtCliente_Clientenomefantasia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenomefantasia_Z = value;
            SetDirty("Clientenomefantasia_Z");
         }

      }

      public void gxTv_SdtCliente_Clientenomefantasia_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientenomefantasia_Z = "";
         SetDirty("Clientenomefantasia_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenomefantasia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDataNascimento_Z" )]
      [  XmlElement( ElementName = "ClienteDataNascimento_Z"  , IsNullable=true )]
      public string gxTpr_Clientedatanascimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clientedatanascimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCliente_Clientedatanascimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCliente_Clientedatanascimento_Z = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clientedatanascimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedatanascimento_Z
      {
         get {
            return gxTv_SdtCliente_Clientedatanascimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedatanascimento_Z = value;
            SetDirty("Clientedatanascimento_Z");
         }

      }

      public void gxTv_SdtCliente_Clientedatanascimento_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientedatanascimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedatanascimento_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedatanascimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTipoPessoa_Z" )]
      [  XmlElement( ElementName = "ClienteTipoPessoa_Z"   )]
      public string gxTpr_Clientetipopessoa_Z
      {
         get {
            return gxTv_SdtCliente_Clientetipopessoa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetipopessoa_Z = value;
            SetDirty("Clientetipopessoa_Z");
         }

      }

      public void gxTv_SdtCliente_Clientetipopessoa_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientetipopessoa_Z = "";
         SetDirty("Clientetipopessoa_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetipopessoa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeId_Z" )]
      [  XmlElement( ElementName = "EspecialidadeId_Z"   )]
      public int gxTpr_Especialidadeid_Z
      {
         get {
            return gxTv_SdtCliente_Especialidadeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Especialidadeid_Z = value;
            SetDirty("Especialidadeid_Z");
         }

      }

      public void gxTv_SdtCliente_Especialidadeid_Z_SetNull( )
      {
         gxTv_SdtCliente_Especialidadeid_Z = 0;
         SetDirty("Especialidadeid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Especialidadeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteId_Z" )]
      [  XmlElement( ElementName = "TipoClienteId_Z"   )]
      public short gxTpr_Tipoclienteid_Z
      {
         get {
            return gxTv_SdtCliente_Tipoclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteid_Z = value;
            SetDirty("Tipoclienteid_Z");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteid_Z_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteid_Z = 0;
         SetDirty("Tipoclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteDescricao_Z" )]
      [  XmlElement( ElementName = "TipoClienteDescricao_Z"   )]
      public string gxTpr_Tipoclientedescricao_Z
      {
         get {
            return gxTv_SdtCliente_Tipoclientedescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclientedescricao_Z = value;
            SetDirty("Tipoclientedescricao_Z");
         }

      }

      public void gxTv_SdtCliente_Tipoclientedescricao_Z_SetNull( )
      {
         gxTv_SdtCliente_Tipoclientedescricao_Z = "";
         SetDirty("Tipoclientedescricao_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclientedescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortal_Z" )]
      [  XmlElement( ElementName = "TipoClientePortal_Z"   )]
      public bool gxTpr_Tipoclienteportal_Z
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportal_Z = value;
            SetDirty("Tipoclienteportal_Z");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportal_Z_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportal_Z = false;
         SetDirty("Tipoclienteportal_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteStatus_Z" )]
      [  XmlElement( ElementName = "ClienteStatus_Z"   )]
      public bool gxTpr_Clientestatus_Z
      {
         get {
            return gxTv_SdtCliente_Clientestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientestatus_Z = value;
            SetDirty("Clientestatus_Z");
         }

      }

      public void gxTv_SdtCliente_Clientestatus_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientestatus_Z = false;
         SetDirty("Clientestatus_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteConvenio_Z" )]
      [  XmlElement( ElementName = "ClienteConvenio_Z"   )]
      public int gxTpr_Clienteconvenio_Z
      {
         get {
            return gxTv_SdtCliente_Clienteconvenio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconvenio_Z = value;
            SetDirty("Clienteconvenio_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteconvenio_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteconvenio_Z = 0;
         SetDirty("Clienteconvenio_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconvenio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteConvenioDescricao_Z" )]
      [  XmlElement( ElementName = "ClienteConvenioDescricao_Z"   )]
      public string gxTpr_Clienteconveniodescricao_Z
      {
         get {
            return gxTv_SdtCliente_Clienteconveniodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconveniodescricao_Z = value;
            SetDirty("Clienteconveniodescricao_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteconveniodescricao_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteconveniodescricao_Z = "";
         SetDirty("Clienteconveniodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconveniodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCreatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clientecreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clientecreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Clientecreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Clientecreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clientecreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientecreatedat_Z
      {
         get {
            return gxTv_SdtCliente_Clientecreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecreatedat_Z = value;
            SetDirty("Clientecreatedat_Z");
         }

      }

      public void gxTv_SdtCliente_Clientecreatedat_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientecreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientecreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientecreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteUpdatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clienteupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Clienteupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Clienteupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Clienteupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCliente_Clienteupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clienteupdatedat_Z
      {
         get {
            return gxTv_SdtCliente_Clienteupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteupdatedat_Z = value;
            SetDirty("Clienteupdatedat_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteupdatedat_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clienteupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteLogUser_Z" )]
      [  XmlElement( ElementName = "ClienteLogUser_Z"   )]
      public short gxTpr_Clienteloguser_Z
      {
         get {
            return gxTv_SdtCliente_Clienteloguser_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteloguser_Z = value;
            SetDirty("Clienteloguser_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteloguser_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteloguser_Z = 0;
         SetDirty("Clienteloguser_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteloguser_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidade_Z" )]
      [  XmlElement( ElementName = "ClienteNacionalidade_Z"   )]
      public int gxTpr_Clientenacionalidade_Z
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidade_Z = value;
            SetDirty("Clientenacionalidade_Z");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidade_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidade_Z = 0;
         SetDirty("Clientenacionalidade_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidadeNome_Z" )]
      [  XmlElement( ElementName = "ClienteNacionalidadeNome_Z"   )]
      public string gxTpr_Clientenacionalidadenome_Z
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidadenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidadenome_Z = value;
            SetDirty("Clientenacionalidadenome_Z");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidadenome_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidadenome_Z = "";
         SetDirty("Clientenacionalidadenome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidadenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteProfissao_Z" )]
      [  XmlElement( ElementName = "ClienteProfissao_Z"   )]
      public int gxTpr_Clienteprofissao_Z
      {
         get {
            return gxTv_SdtCliente_Clienteprofissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissao_Z = value;
            SetDirty("Clienteprofissao_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissao_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissao_Z = 0;
         SetDirty("Clienteprofissao_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteProfissaoNome_Z" )]
      [  XmlElement( ElementName = "ClienteProfissaoNome_Z"   )]
      public string gxTpr_Clienteprofissaonome_Z
      {
         get {
            return gxTv_SdtCliente_Clienteprofissaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissaonome_Z = value;
            SetDirty("Clienteprofissaonome_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissaonome_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissaonome_Z = "";
         SetDirty("Clienteprofissaonome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteEstadoCivil_Z" )]
      [  XmlElement( ElementName = "ClienteEstadoCivil_Z"   )]
      public string gxTpr_Clienteestadocivil_Z
      {
         get {
            return gxTv_SdtCliente_Clienteestadocivil_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteestadocivil_Z = value;
            SetDirty("Clienteestadocivil_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteestadocivil_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteestadocivil_Z = "";
         SetDirty("Clienteestadocivil_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteestadocivil_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_F_Z" )]
      [  XmlElement( ElementName = "SecUserId_F_Z"   )]
      public short gxTpr_Secuserid_f_Z
      {
         get {
            return gxTv_SdtCliente_Secuserid_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Secuserid_f_Z = value;
            SetDirty("Secuserid_f_Z");
         }

      }

      public void gxTv_SdtCliente_Secuserid_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Secuserid_f_Z = 0;
         SetDirty("Secuserid_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Secuserid_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoTipo_Z" )]
      [  XmlElement( ElementName = "EnderecoTipo_Z"   )]
      public string gxTpr_Enderecotipo_Z
      {
         get {
            return gxTv_SdtCliente_Enderecotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecotipo_Z = value;
            SetDirty("Enderecotipo_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecotipo_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecotipo_Z = "";
         SetDirty("Enderecotipo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoCEP_Z" )]
      [  XmlElement( ElementName = "EnderecoCEP_Z"   )]
      public string gxTpr_Enderecocep_Z
      {
         get {
            return gxTv_SdtCliente_Enderecocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocep_Z = value;
            SetDirty("Enderecocep_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecocep_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecocep_Z = "";
         SetDirty("Enderecocep_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoLogradouro_Z" )]
      [  XmlElement( ElementName = "EnderecoLogradouro_Z"   )]
      public string gxTpr_Enderecologradouro_Z
      {
         get {
            return gxTv_SdtCliente_Enderecologradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecologradouro_Z = value;
            SetDirty("Enderecologradouro_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecologradouro_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecologradouro_Z = "";
         SetDirty("Enderecologradouro_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecologradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoBairro_Z" )]
      [  XmlElement( ElementName = "EnderecoBairro_Z"   )]
      public string gxTpr_Enderecobairro_Z
      {
         get {
            return gxTv_SdtCliente_Enderecobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecobairro_Z = value;
            SetDirty("Enderecobairro_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecobairro_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecobairro_Z = "";
         SetDirty("Enderecobairro_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoCidade_Z" )]
      [  XmlElement( ElementName = "EnderecoCidade_Z"   )]
      public string gxTpr_Enderecocidade_Z
      {
         get {
            return gxTv_SdtCliente_Enderecocidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocidade_Z = value;
            SetDirty("Enderecocidade_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecocidade_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecocidade_Z = "";
         SetDirty("Enderecocidade_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_Z" )]
      [  XmlElement( ElementName = "MunicipioCodigo_Z"   )]
      public string gxTpr_Municipiocodigo_Z
      {
         get {
            return gxTv_SdtCliente_Municipiocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiocodigo_Z = value;
            SetDirty("Municipiocodigo_Z");
         }

      }

      public void gxTv_SdtCliente_Municipiocodigo_Z_SetNull( )
      {
         gxTv_SdtCliente_Municipiocodigo_Z = "";
         SetDirty("Municipiocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_Z" )]
      [  XmlElement( ElementName = "MunicipioNome_Z"   )]
      public string gxTpr_Municipionome_Z
      {
         get {
            return gxTv_SdtCliente_Municipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipionome_Z = value;
            SetDirty("Municipionome_Z");
         }

      }

      public void gxTv_SdtCliente_Municipionome_Z_SetNull( )
      {
         gxTv_SdtCliente_Municipionome_Z = "";
         SetDirty("Municipionome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_Z" )]
      [  XmlElement( ElementName = "MunicipioUF_Z"   )]
      public string gxTpr_Municipiouf_Z
      {
         get {
            return gxTv_SdtCliente_Municipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiouf_Z = value;
            SetDirty("Municipiouf_Z");
         }

      }

      public void gxTv_SdtCliente_Municipiouf_Z_SetNull( )
      {
         gxTv_SdtCliente_Municipiouf_Z = "";
         SetDirty("Municipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoNumero_Z" )]
      [  XmlElement( ElementName = "EnderecoNumero_Z"   )]
      public string gxTpr_Endereconumero_Z
      {
         get {
            return gxTv_SdtCliente_Endereconumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Endereconumero_Z = value;
            SetDirty("Endereconumero_Z");
         }

      }

      public void gxTv_SdtCliente_Endereconumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Endereconumero_Z = "";
         SetDirty("Endereconumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Endereconumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoComplemento_Z" )]
      [  XmlElement( ElementName = "EnderecoComplemento_Z"   )]
      public string gxTpr_Enderecocomplemento_Z
      {
         get {
            return gxTv_SdtCliente_Enderecocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocomplemento_Z = value;
            SetDirty("Enderecocomplemento_Z");
         }

      }

      public void gxTv_SdtCliente_Enderecocomplemento_Z_SetNull( )
      {
         gxTv_SdtCliente_Enderecocomplemento_Z = "";
         SetDirty("Enderecocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoEmail_Z" )]
      [  XmlElement( ElementName = "ContatoEmail_Z"   )]
      public string gxTpr_Contatoemail_Z
      {
         get {
            return gxTv_SdtCliente_Contatoemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoemail_Z = value;
            SetDirty("Contatoemail_Z");
         }

      }

      public void gxTv_SdtCliente_Contatoemail_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatoemail_Z = "";
         SetDirty("Contatoemail_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoDDD_Z" )]
      [  XmlElement( ElementName = "ContatoDDD_Z"   )]
      public short gxTpr_Contatoddd_Z
      {
         get {
            return gxTv_SdtCliente_Contatoddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddd_Z = value;
            SetDirty("Contatoddd_Z");
         }

      }

      public void gxTv_SdtCliente_Contatoddd_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatoddd_Z = 0;
         SetDirty("Contatoddd_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoDDI_Z" )]
      [  XmlElement( ElementName = "ContatoDDI_Z"   )]
      public short gxTpr_Contatoddi_Z
      {
         get {
            return gxTv_SdtCliente_Contatoddi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddi_Z = value;
            SetDirty("Contatoddi_Z");
         }

      }

      public void gxTv_SdtCliente_Contatoddi_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatoddi_Z = 0;
         SetDirty("Contatoddi_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoNumero_Z" )]
      [  XmlElement( ElementName = "ContatoNumero_Z"   )]
      public long gxTpr_Contatonumero_Z
      {
         get {
            return gxTv_SdtCliente_Contatonumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatonumero_Z = value;
            SetDirty("Contatonumero_Z");
         }

      }

      public void gxTv_SdtCliente_Contatonumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatonumero_Z = 0;
         SetDirty("Contatonumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatonumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneNumero_Z" )]
      [  XmlElement( ElementName = "ContatoTelefoneNumero_Z"   )]
      public long gxTpr_Contatotelefonenumero_Z
      {
         get {
            return gxTv_SdtCliente_Contatotelefonenumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefonenumero_Z = value;
            SetDirty("Contatotelefonenumero_Z");
         }

      }

      public void gxTv_SdtCliente_Contatotelefonenumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefonenumero_Z = 0;
         SetDirty("Contatotelefonenumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefonenumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDD_Z" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDD_Z"   )]
      public short gxTpr_Contatotelefoneddd_Z
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddd_Z = value;
            SetDirty("Contatotelefoneddd_Z");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddd_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddd_Z = 0;
         SetDirty("Contatotelefoneddd_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDI_Z" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDI_Z"   )]
      public short gxTpr_Contatotelefoneddi_Z
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddi_Z = value;
            SetDirty("Contatotelefoneddi_Z");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddi_Z_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddi_Z = 0;
         SetDirty("Contatotelefoneddi_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRG_Z" )]
      [  XmlElement( ElementName = "ClienteRG_Z"   )]
      public long gxTpr_Clienterg_Z
      {
         get {
            return gxTv_SdtCliente_Clienterg_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterg_Z = value;
            SetDirty("Clienterg_Z");
         }

      }

      public void gxTv_SdtCliente_Clienterg_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienterg_Z = 0;
         SetDirty("Clienterg_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterg_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTelefone_F_Z" )]
      [  XmlElement( ElementName = "ClienteTelefone_F_Z"   )]
      public string gxTpr_Clientetelefone_f_Z
      {
         get {
            return gxTv_SdtCliente_Clientetelefone_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetelefone_f_Z = value;
            SetDirty("Clientetelefone_f_Z");
         }

      }

      public void gxTv_SdtCliente_Clientetelefone_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientetelefone_f_Z = "";
         SetDirty("Clientetelefone_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetelefone_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCelular_F_Z" )]
      [  XmlElement( ElementName = "ClienteCelular_F_Z"   )]
      public string gxTpr_Clientecelular_f_Z
      {
         get {
            return gxTv_SdtCliente_Clientecelular_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecelular_f_Z = value;
            SetDirty("Clientecelular_f_Z");
         }

      }

      public void gxTv_SdtCliente_Clientecelular_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientecelular_f_Z = "";
         SetDirty("Clientecelular_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientecelular_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteQtdTitulos_F_Z" )]
      [  XmlElement( ElementName = "ClienteQtdTitulos_F_Z"   )]
      public int gxTpr_Clienteqtdtitulos_f_Z
      {
         get {
            return gxTv_SdtCliente_Clienteqtdtitulos_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteqtdtitulos_f_Z = value;
            SetDirty("Clienteqtdtitulos_f_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteqtdtitulos_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteqtdtitulos_f_Z = 0;
         SetDirty("Clienteqtdtitulos_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteqtdtitulos_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteValorAPagar_F_Z" )]
      [  XmlElement( ElementName = "ClienteValorAPagar_F_Z"   )]
      public decimal gxTpr_Clientevalorapagar_f_Z
      {
         get {
            return gxTv_SdtCliente_Clientevalorapagar_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorapagar_f_Z = value;
            SetDirty("Clientevalorapagar_f_Z");
         }

      }

      public void gxTv_SdtCliente_Clientevalorapagar_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorapagar_f_Z = 0;
         SetDirty("Clientevalorapagar_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorapagar_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteValorAReceber_F_Z" )]
      [  XmlElement( ElementName = "ClienteValorAReceber_F_Z"   )]
      public decimal gxTpr_Clientevalorareceber_f_Z
      {
         get {
            return gxTv_SdtCliente_Clientevalorareceber_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorareceber_f_Z = value;
            SetDirty("Clientevalorareceber_f_Z");
         }

      }

      public void gxTv_SdtCliente_Clientevalorareceber_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorareceber_f_Z = 0;
         SetDirty("Clientevalorareceber_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorareceber_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDepositoTipo_Z" )]
      [  XmlElement( ElementName = "ClienteDepositoTipo_Z"   )]
      public string gxTpr_Clientedepositotipo_Z
      {
         get {
            return gxTv_SdtCliente_Clientedepositotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedepositotipo_Z = value;
            SetDirty("Clientedepositotipo_Z");
         }

      }

      public void gxTv_SdtCliente_Clientedepositotipo_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientedepositotipo_Z = "";
         SetDirty("Clientedepositotipo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedepositotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClientePixTipo_Z" )]
      [  XmlElement( ElementName = "ClientePixTipo_Z"   )]
      public string gxTpr_Clientepixtipo_Z
      {
         get {
            return gxTv_SdtCliente_Clientepixtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepixtipo_Z = value;
            SetDirty("Clientepixtipo_Z");
         }

      }

      public void gxTv_SdtCliente_Clientepixtipo_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientepixtipo_Z = "";
         SetDirty("Clientepixtipo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepixtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClientePix_Z" )]
      [  XmlElement( ElementName = "ClientePix_Z"   )]
      public string gxTpr_Clientepix_Z
      {
         get {
            return gxTv_SdtCliente_Clientepix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepix_Z = value;
            SetDirty("Clientepix_Z");
         }

      }

      public void gxTv_SdtCliente_Clientepix_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientepix_Z = "";
         SetDirty("Clientepix_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_Z" )]
      [  XmlElement( ElementName = "BancoId_Z"   )]
      public int gxTpr_Bancoid_Z
      {
         get {
            return gxTv_SdtCliente_Bancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancoid_Z = value;
            SetDirty("Bancoid_Z");
         }

      }

      public void gxTv_SdtCliente_Bancoid_Z_SetNull( )
      {
         gxTv_SdtCliente_Bancoid_Z = 0;
         SetDirty("Bancoid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCodigo_Z" )]
      [  XmlElement( ElementName = "BancoCodigo_Z"   )]
      public int gxTpr_Bancocodigo_Z
      {
         get {
            return gxTv_SdtCliente_Bancocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancocodigo_Z = value;
            SetDirty("Bancocodigo_Z");
         }

      }

      public void gxTv_SdtCliente_Bancocodigo_Z_SetNull( )
      {
         gxTv_SdtCliente_Bancocodigo_Z = 0;
         SetDirty("Bancocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_Z" )]
      [  XmlElement( ElementName = "BancoNome_Z"   )]
      public string gxTpr_Banconome_Z
      {
         get {
            return gxTv_SdtCliente_Banconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Banconome_Z = value;
            SetDirty("Banconome_Z");
         }

      }

      public void gxTv_SdtCliente_Banconome_Z_SetNull( )
      {
         gxTv_SdtCliente_Banconome_Z = "";
         SetDirty("Banconome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Banconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaAgencia_Z" )]
      [  XmlElement( ElementName = "ContaAgencia_Z"   )]
      public string gxTpr_Contaagencia_Z
      {
         get {
            return gxTv_SdtCliente_Contaagencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contaagencia_Z = value;
            SetDirty("Contaagencia_Z");
         }

      }

      public void gxTv_SdtCliente_Contaagencia_Z_SetNull( )
      {
         gxTv_SdtCliente_Contaagencia_Z = "";
         SetDirty("Contaagencia_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contaagencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaNumero_Z" )]
      [  XmlElement( ElementName = "ContaNumero_Z"   )]
      public string gxTpr_Contanumero_Z
      {
         get {
            return gxTv_SdtCliente_Contanumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contanumero_Z = value;
            SetDirty("Contanumero_Z");
         }

      }

      public void gxTv_SdtCliente_Contanumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Contanumero_Z = "";
         SetDirty("Contanumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Contanumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNome_Z" )]
      [  XmlElement( ElementName = "ResponsavelNome_Z"   )]
      public string gxTpr_Responsavelnome_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnome_Z = value;
            SetDirty("Responsavelnome_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelnome_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnome_Z = "";
         SetDirty("Responsavelnome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidade_Z" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidade_Z"   )]
      public int gxTpr_Responsavelnacionalidade_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidade_Z = value;
            SetDirty("Responsavelnacionalidade_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidade_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidade_Z = 0;
         SetDirty("Responsavelnacionalidade_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidadeNome_Z" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidadeNome_Z"   )]
      public string gxTpr_Responsavelnacionalidadenome_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidadenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidadenome_Z = value;
            SetDirty("Responsavelnacionalidadenome_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidadenome_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidadenome_Z = "";
         SetDirty("Responsavelnacionalidadenome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidadenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelEstadoCivil_Z" )]
      [  XmlElement( ElementName = "ResponsavelEstadoCivil_Z"   )]
      public string gxTpr_Responsavelestadocivil_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelestadocivil_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelestadocivil_Z = value;
            SetDirty("Responsavelestadocivil_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelestadocivil_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelestadocivil_Z = "";
         SetDirty("Responsavelestadocivil_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelestadocivil_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissao_Z" )]
      [  XmlElement( ElementName = "ResponsavelProfissao_Z"   )]
      public int gxTpr_Responsavelprofissao_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissao_Z = value;
            SetDirty("Responsavelprofissao_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissao_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissao_Z = 0;
         SetDirty("Responsavelprofissao_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelRG_Z" )]
      [  XmlElement( ElementName = "ResponsavelRG_Z"   )]
      public long gxTpr_Responsavelrg_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelrg_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelrg_Z = value;
            SetDirty("Responsavelrg_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelrg_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelrg_Z = 0;
         SetDirty("Responsavelrg_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelrg_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissaoNome_Z" )]
      [  XmlElement( ElementName = "ResponsavelProfissaoNome_Z"   )]
      public string gxTpr_Responsavelprofissaonome_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissaonome_Z = value;
            SetDirty("Responsavelprofissaonome_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissaonome_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissaonome_Z = "";
         SetDirty("Responsavelprofissaonome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCPF_Z" )]
      [  XmlElement( ElementName = "ResponsavelCPF_Z"   )]
      public string gxTpr_Responsavelcpf_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcpf_Z = value;
            SetDirty("Responsavelcpf_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcpf_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcpf_Z = "";
         SetDirty("Responsavelcpf_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCEP_Z" )]
      [  XmlElement( ElementName = "ResponsavelCEP_Z"   )]
      public string gxTpr_Responsavelcep_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcep_Z = value;
            SetDirty("Responsavelcep_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcep_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcep_Z = "";
         SetDirty("Responsavelcep_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouro_Z" )]
      [  XmlElement( ElementName = "ResponsavelLogradouro_Z"   )]
      public string gxTpr_Responsavellogradouro_Z
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouro_Z = value;
            SetDirty("Responsavellogradouro_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouro_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouro_Z = "";
         SetDirty("Responsavellogradouro_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelBairro_Z" )]
      [  XmlElement( ElementName = "ResponsavelBairro_Z"   )]
      public string gxTpr_Responsavelbairro_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelbairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelbairro_Z = value;
            SetDirty("Responsavelbairro_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelbairro_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelbairro_Z = "";
         SetDirty("Responsavelbairro_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelbairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCidade_Z" )]
      [  XmlElement( ElementName = "ResponsavelCidade_Z"   )]
      public string gxTpr_Responsavelcidade_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcidade_Z = value;
            SetDirty("Responsavelcidade_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcidade_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcidade_Z = "";
         SetDirty("Responsavelcidade_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipio_Z" )]
      [  XmlElement( ElementName = "ResponsavelMunicipio_Z"   )]
      public string gxTpr_Responsavelmunicipio_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipio_Z = value;
            SetDirty("Responsavelmunicipio_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipio_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipio_Z = "";
         SetDirty("Responsavelmunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioUF_Z" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioUF_Z"   )]
      public string gxTpr_Responsavelmunicipiouf_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipiouf_Z = value;
            SetDirty("Responsavelmunicipiouf_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipiouf_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipiouf_Z = "";
         SetDirty("Responsavelmunicipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioNome_Z" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioNome_Z"   )]
      public string gxTpr_Responsavelmunicipionome_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipionome_Z = value;
            SetDirty("Responsavelmunicipionome_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipionome_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipionome_Z = "";
         SetDirty("Responsavelmunicipionome_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouroNumero_Z" )]
      [  XmlElement( ElementName = "ResponsavelLogradouroNumero_Z"   )]
      public int gxTpr_Responsavellogradouronumero_Z
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouronumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouronumero_Z = value;
            SetDirty("Responsavellogradouronumero_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouronumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouronumero_Z = 0;
         SetDirty("Responsavellogradouronumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouronumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelComplemento_Z" )]
      [  XmlElement( ElementName = "ResponsavelComplemento_Z"   )]
      public string gxTpr_Responsavelcomplemento_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcomplemento_Z = value;
            SetDirty("Responsavelcomplemento_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcomplemento_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcomplemento_Z = "";
         SetDirty("Responsavelcomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelDDD_Z" )]
      [  XmlElement( ElementName = "ResponsavelDDD_Z"   )]
      public short gxTpr_Responsavelddd_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelddd_Z = value;
            SetDirty("Responsavelddd_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelddd_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelddd_Z = 0;
         SetDirty("Responsavelddd_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNumero_Z" )]
      [  XmlElement( ElementName = "ResponsavelNumero_Z"   )]
      public int gxTpr_Responsavelnumero_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnumero_Z = value;
            SetDirty("Responsavelnumero_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelnumero_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnumero_Z = 0;
         SetDirty("Responsavelnumero_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelEmail_Z" )]
      [  XmlElement( ElementName = "ResponsavelEmail_Z"   )]
      public string gxTpr_Responsavelemail_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelemail_Z = value;
            SetDirty("Responsavelemail_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelemail_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelemail_Z = "";
         SetDirty("Responsavelemail_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCelular_F_Z" )]
      [  XmlElement( ElementName = "ResponsavelCelular_F_Z"   )]
      public string gxTpr_Responsavelcelular_f_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcelular_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcelular_f_Z = value;
            SetDirty("Responsavelcelular_f_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcelular_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcelular_f_Z = "";
         SetDirty("Responsavelcelular_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcelular_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaConsultas_F_Z" )]
      [  XmlElement( ElementName = "SerasaConsultas_F_Z"   )]
      public short gxTpr_Serasaconsultas_f_Z
      {
         get {
            return gxTv_SdtCliente_Serasaconsultas_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaconsultas_f_Z = value;
            SetDirty("Serasaconsultas_f_Z");
         }

      }

      public void gxTv_SdtCliente_Serasaconsultas_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Serasaconsultas_f_Z = 0;
         SetDirty("Serasaconsultas_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaconsultas_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaUltimaData_F_Z" )]
      [  XmlElement( ElementName = "SerasaUltimaData_F_Z"  , IsNullable=true )]
      public string gxTpr_Serasaultimadata_f_Z_Nullable
      {
         get {
            if ( gxTv_SdtCliente_Serasaultimadata_f_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCliente_Serasaultimadata_f_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCliente_Serasaultimadata_f_Z = DateTime.MinValue;
            else
               gxTv_SdtCliente_Serasaultimadata_f_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaultimadata_f_Z
      {
         get {
            return gxTv_SdtCliente_Serasaultimadata_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimadata_f_Z = value;
            SetDirty("Serasaultimadata_f_Z");
         }

      }

      public void gxTv_SdtCliente_Serasaultimadata_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Serasaultimadata_f_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaultimadata_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaultimadata_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaScoreUltimaData_F_Z" )]
      [  XmlElement( ElementName = "SerasaScoreUltimaData_F_Z"   )]
      public short gxTpr_Serasascoreultimadata_f_Z
      {
         get {
            return gxTv_SdtCliente_Serasascoreultimadata_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasascoreultimadata_f_Z = value;
            SetDirty("Serasascoreultimadata_f_Z");
         }

      }

      public void gxTv_SdtCliente_Serasascoreultimadata_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Serasascoreultimadata_f_Z = 0;
         SetDirty("Serasascoreultimadata_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasascoreultimadata_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaUltimoValorRecomendado_F_Z" )]
      [  XmlElement( ElementName = "SerasaUltimoValorRecomendado_F_Z"   )]
      public decimal gxTpr_Serasaultimovalorrecomendado_f_Z
      {
         get {
            return gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z = value;
            SetDirty("Serasaultimovalorrecomendado_f_Z");
         }

      }

      public void gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z_SetNull( )
      {
         gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z = 0;
         SetDirty("Serasaultimovalorrecomendado_f_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteSituacao_Z" )]
      [  XmlElement( ElementName = "ClienteSituacao_Z"   )]
      public string gxTpr_Clientesituacao_Z
      {
         get {
            return gxTv_SdtCliente_Clientesituacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesituacao_Z = value;
            SetDirty("Clientesituacao_Z");
         }

      }

      public void gxTv_SdtCliente_Clientesituacao_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientesituacao_Z = "";
         SetDirty("Clientesituacao_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientesituacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCargo_Z" )]
      [  XmlElement( ElementName = "ResponsavelCargo_Z"   )]
      public string gxTpr_Responsavelcargo_Z
      {
         get {
            return gxTv_SdtCliente_Responsavelcargo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcargo_Z = value;
            SetDirty("Responsavelcargo_Z");
         }

      }

      public void gxTv_SdtCliente_Responsavelcargo_Z_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcargo_Z = "";
         SetDirty("Responsavelcargo_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcargo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_Z" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_Z"   )]
      public bool gxTpr_Tipoclienteportalpjpf_Z
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportalpjpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportalpjpf_Z = value;
            SetDirty("Tipoclienteportalpjpf_Z");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportalpjpf_Z_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportalpjpf_Z = false;
         SetDirty("Tipoclienteportalpjpf_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportalpjpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelacionamentoSacado_Z" )]
      [  XmlElement( ElementName = "RelacionamentoSacado_Z"   )]
      public short gxTpr_Relacionamentosacado_Z
      {
         get {
            return gxTv_SdtCliente_Relacionamentosacado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Relacionamentosacado_Z = value;
            SetDirty("Relacionamentosacado_Z");
         }

      }

      public void gxTv_SdtCliente_Relacionamentosacado_Z_SetNull( )
      {
         gxTv_SdtCliente_Relacionamentosacado_Z = 0;
         SetDirty("Relacionamentosacado_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Relacionamentosacado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteSacado_Z" )]
      [  XmlElement( ElementName = "ClienteSacado_Z"   )]
      public bool gxTpr_Clientesacado_Z
      {
         get {
            return gxTv_SdtCliente_Clientesacado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesacado_Z = value;
            SetDirty("Clientesacado_Z");
         }

      }

      public void gxTv_SdtCliente_Clientesacado_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientesacado_Z = false;
         SetDirty("Clientesacado_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientesacado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTipoRisco_Z" )]
      [  XmlElement( ElementName = "ClienteTipoRisco_Z"   )]
      public string gxTpr_Clientetiporisco_Z
      {
         get {
            return gxTv_SdtCliente_Clientetiporisco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetiporisco_Z = value;
            SetDirty("Clientetiporisco_Z");
         }

      }

      public void gxTv_SdtCliente_Clientetiporisco_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientetiporisco_Z = "";
         SetDirty("Clientetiporisco_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetiporisco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtCliente_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtCliente_Clienteid_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumento_N" )]
      [  XmlElement( ElementName = "ClienteDocumento_N"   )]
      public short gxTpr_Clientedocumento_N
      {
         get {
            return gxTv_SdtCliente_Clientedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedocumento_N = value;
            SetDirty("Clientedocumento_N");
         }

      }

      public void gxTv_SdtCliente_Clientedocumento_N_SetNull( )
      {
         gxTv_SdtCliente_Clientedocumento_N = 0;
         SetDirty("Clientedocumento_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_N"   )]
      public short gxTpr_Clienterazaosocial_N
      {
         get {
            return gxTv_SdtCliente_Clienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterazaosocial_N = value;
            SetDirty("Clienterazaosocial_N");
         }

      }

      public void gxTv_SdtCliente_Clienterazaosocial_N_SetNull( )
      {
         gxTv_SdtCliente_Clienterazaosocial_N = 0;
         SetDirty("Clienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNomeFantasia_N" )]
      [  XmlElement( ElementName = "ClienteNomeFantasia_N"   )]
      public short gxTpr_Clientenomefantasia_N
      {
         get {
            return gxTv_SdtCliente_Clientenomefantasia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenomefantasia_N = value;
            SetDirty("Clientenomefantasia_N");
         }

      }

      public void gxTv_SdtCliente_Clientenomefantasia_N_SetNull( )
      {
         gxTv_SdtCliente_Clientenomefantasia_N = 0;
         SetDirty("Clientenomefantasia_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenomefantasia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDataNascimento_N" )]
      [  XmlElement( ElementName = "ClienteDataNascimento_N"   )]
      public short gxTpr_Clientedatanascimento_N
      {
         get {
            return gxTv_SdtCliente_Clientedatanascimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedatanascimento_N = value;
            SetDirty("Clientedatanascimento_N");
         }

      }

      public void gxTv_SdtCliente_Clientedatanascimento_N_SetNull( )
      {
         gxTv_SdtCliente_Clientedatanascimento_N = 0;
         SetDirty("Clientedatanascimento_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedatanascimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTipoPessoa_N" )]
      [  XmlElement( ElementName = "ClienteTipoPessoa_N"   )]
      public short gxTpr_Clientetipopessoa_N
      {
         get {
            return gxTv_SdtCliente_Clientetipopessoa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientetipopessoa_N = value;
            SetDirty("Clientetipopessoa_N");
         }

      }

      public void gxTv_SdtCliente_Clientetipopessoa_N_SetNull( )
      {
         gxTv_SdtCliente_Clientetipopessoa_N = 0;
         SetDirty("Clientetipopessoa_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientetipopessoa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeId_N" )]
      [  XmlElement( ElementName = "EspecialidadeId_N"   )]
      public short gxTpr_Especialidadeid_N
      {
         get {
            return gxTv_SdtCliente_Especialidadeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Especialidadeid_N = value;
            SetDirty("Especialidadeid_N");
         }

      }

      public void gxTv_SdtCliente_Especialidadeid_N_SetNull( )
      {
         gxTv_SdtCliente_Especialidadeid_N = 0;
         SetDirty("Especialidadeid_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Especialidadeid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteId_N" )]
      [  XmlElement( ElementName = "TipoClienteId_N"   )]
      public short gxTpr_Tipoclienteid_N
      {
         get {
            return gxTv_SdtCliente_Tipoclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteid_N = value;
            SetDirty("Tipoclienteid_N");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteid_N_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteid_N = 0;
         SetDirty("Tipoclienteid_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteDescricao_N" )]
      [  XmlElement( ElementName = "TipoClienteDescricao_N"   )]
      public short gxTpr_Tipoclientedescricao_N
      {
         get {
            return gxTv_SdtCliente_Tipoclientedescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclientedescricao_N = value;
            SetDirty("Tipoclientedescricao_N");
         }

      }

      public void gxTv_SdtCliente_Tipoclientedescricao_N_SetNull( )
      {
         gxTv_SdtCliente_Tipoclientedescricao_N = 0;
         SetDirty("Tipoclientedescricao_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclientedescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortal_N" )]
      [  XmlElement( ElementName = "TipoClientePortal_N"   )]
      public short gxTpr_Tipoclienteportal_N
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportal_N = value;
            SetDirty("Tipoclienteportal_N");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportal_N_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportal_N = 0;
         SetDirty("Tipoclienteportal_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteStatus_N" )]
      [  XmlElement( ElementName = "ClienteStatus_N"   )]
      public short gxTpr_Clientestatus_N
      {
         get {
            return gxTv_SdtCliente_Clientestatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientestatus_N = value;
            SetDirty("Clientestatus_N");
         }

      }

      public void gxTv_SdtCliente_Clientestatus_N_SetNull( )
      {
         gxTv_SdtCliente_Clientestatus_N = 0;
         SetDirty("Clientestatus_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientestatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteConvenio_N" )]
      [  XmlElement( ElementName = "ClienteConvenio_N"   )]
      public short gxTpr_Clienteconvenio_N
      {
         get {
            return gxTv_SdtCliente_Clienteconvenio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconvenio_N = value;
            SetDirty("Clienteconvenio_N");
         }

      }

      public void gxTv_SdtCliente_Clienteconvenio_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteconvenio_N = 0;
         SetDirty("Clienteconvenio_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconvenio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteConvenioDescricao_N" )]
      [  XmlElement( ElementName = "ClienteConvenioDescricao_N"   )]
      public short gxTpr_Clienteconveniodescricao_N
      {
         get {
            return gxTv_SdtCliente_Clienteconveniodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteconveniodescricao_N = value;
            SetDirty("Clienteconveniodescricao_N");
         }

      }

      public void gxTv_SdtCliente_Clienteconveniodescricao_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteconveniodescricao_N = 0;
         SetDirty("Clienteconveniodescricao_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteconveniodescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCreatedAt_N" )]
      [  XmlElement( ElementName = "ClienteCreatedAt_N"   )]
      public short gxTpr_Clientecreatedat_N
      {
         get {
            return gxTv_SdtCliente_Clientecreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientecreatedat_N = value;
            SetDirty("Clientecreatedat_N");
         }

      }

      public void gxTv_SdtCliente_Clientecreatedat_N_SetNull( )
      {
         gxTv_SdtCliente_Clientecreatedat_N = 0;
         SetDirty("Clientecreatedat_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientecreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteUpdatedAt_N" )]
      [  XmlElement( ElementName = "ClienteUpdatedAt_N"   )]
      public short gxTpr_Clienteupdatedat_N
      {
         get {
            return gxTv_SdtCliente_Clienteupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteupdatedat_N = value;
            SetDirty("Clienteupdatedat_N");
         }

      }

      public void gxTv_SdtCliente_Clienteupdatedat_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteupdatedat_N = 0;
         SetDirty("Clienteupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteLogUser_N" )]
      [  XmlElement( ElementName = "ClienteLogUser_N"   )]
      public short gxTpr_Clienteloguser_N
      {
         get {
            return gxTv_SdtCliente_Clienteloguser_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteloguser_N = value;
            SetDirty("Clienteloguser_N");
         }

      }

      public void gxTv_SdtCliente_Clienteloguser_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteloguser_N = 0;
         SetDirty("Clienteloguser_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteloguser_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidade_N" )]
      [  XmlElement( ElementName = "ClienteNacionalidade_N"   )]
      public short gxTpr_Clientenacionalidade_N
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidade_N = value;
            SetDirty("Clientenacionalidade_N");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidade_N_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidade_N = 0;
         SetDirty("Clientenacionalidade_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNacionalidadeNome_N" )]
      [  XmlElement( ElementName = "ClienteNacionalidadeNome_N"   )]
      public short gxTpr_Clientenacionalidadenome_N
      {
         get {
            return gxTv_SdtCliente_Clientenacionalidadenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientenacionalidadenome_N = value;
            SetDirty("Clientenacionalidadenome_N");
         }

      }

      public void gxTv_SdtCliente_Clientenacionalidadenome_N_SetNull( )
      {
         gxTv_SdtCliente_Clientenacionalidadenome_N = 0;
         SetDirty("Clientenacionalidadenome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientenacionalidadenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteProfissao_N" )]
      [  XmlElement( ElementName = "ClienteProfissao_N"   )]
      public short gxTpr_Clienteprofissao_N
      {
         get {
            return gxTv_SdtCliente_Clienteprofissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissao_N = value;
            SetDirty("Clienteprofissao_N");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissao_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissao_N = 0;
         SetDirty("Clienteprofissao_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteProfissaoNome_N" )]
      [  XmlElement( ElementName = "ClienteProfissaoNome_N"   )]
      public short gxTpr_Clienteprofissaonome_N
      {
         get {
            return gxTv_SdtCliente_Clienteprofissaonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteprofissaonome_N = value;
            SetDirty("Clienteprofissaonome_N");
         }

      }

      public void gxTv_SdtCliente_Clienteprofissaonome_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteprofissaonome_N = 0;
         SetDirty("Clienteprofissaonome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteprofissaonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteEstadoCivil_N" )]
      [  XmlElement( ElementName = "ClienteEstadoCivil_N"   )]
      public short gxTpr_Clienteestadocivil_N
      {
         get {
            return gxTv_SdtCliente_Clienteestadocivil_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteestadocivil_N = value;
            SetDirty("Clienteestadocivil_N");
         }

      }

      public void gxTv_SdtCliente_Clienteestadocivil_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteestadocivil_N = 0;
         SetDirty("Clienteestadocivil_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteestadocivil_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_F_N" )]
      [  XmlElement( ElementName = "SecUserId_F_N"   )]
      public short gxTpr_Secuserid_f_N
      {
         get {
            return gxTv_SdtCliente_Secuserid_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Secuserid_f_N = value;
            SetDirty("Secuserid_f_N");
         }

      }

      public void gxTv_SdtCliente_Secuserid_f_N_SetNull( )
      {
         gxTv_SdtCliente_Secuserid_f_N = 0;
         SetDirty("Secuserid_f_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Secuserid_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoTipo_N" )]
      [  XmlElement( ElementName = "EnderecoTipo_N"   )]
      public short gxTpr_Enderecotipo_N
      {
         get {
            return gxTv_SdtCliente_Enderecotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecotipo_N = value;
            SetDirty("Enderecotipo_N");
         }

      }

      public void gxTv_SdtCliente_Enderecotipo_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecotipo_N = 0;
         SetDirty("Enderecotipo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoCEP_N" )]
      [  XmlElement( ElementName = "EnderecoCEP_N"   )]
      public short gxTpr_Enderecocep_N
      {
         get {
            return gxTv_SdtCliente_Enderecocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocep_N = value;
            SetDirty("Enderecocep_N");
         }

      }

      public void gxTv_SdtCliente_Enderecocep_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecocep_N = 0;
         SetDirty("Enderecocep_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoLogradouro_N" )]
      [  XmlElement( ElementName = "EnderecoLogradouro_N"   )]
      public short gxTpr_Enderecologradouro_N
      {
         get {
            return gxTv_SdtCliente_Enderecologradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecologradouro_N = value;
            SetDirty("Enderecologradouro_N");
         }

      }

      public void gxTv_SdtCliente_Enderecologradouro_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecologradouro_N = 0;
         SetDirty("Enderecologradouro_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecologradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoBairro_N" )]
      [  XmlElement( ElementName = "EnderecoBairro_N"   )]
      public short gxTpr_Enderecobairro_N
      {
         get {
            return gxTv_SdtCliente_Enderecobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecobairro_N = value;
            SetDirty("Enderecobairro_N");
         }

      }

      public void gxTv_SdtCliente_Enderecobairro_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecobairro_N = 0;
         SetDirty("Enderecobairro_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoCidade_N" )]
      [  XmlElement( ElementName = "EnderecoCidade_N"   )]
      public short gxTpr_Enderecocidade_N
      {
         get {
            return gxTv_SdtCliente_Enderecocidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocidade_N = value;
            SetDirty("Enderecocidade_N");
         }

      }

      public void gxTv_SdtCliente_Enderecocidade_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecocidade_N = 0;
         SetDirty("Enderecocidade_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_N" )]
      [  XmlElement( ElementName = "MunicipioCodigo_N"   )]
      public short gxTpr_Municipiocodigo_N
      {
         get {
            return gxTv_SdtCliente_Municipiocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiocodigo_N = value;
            SetDirty("Municipiocodigo_N");
         }

      }

      public void gxTv_SdtCliente_Municipiocodigo_N_SetNull( )
      {
         gxTv_SdtCliente_Municipiocodigo_N = 0;
         SetDirty("Municipiocodigo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_N" )]
      [  XmlElement( ElementName = "MunicipioNome_N"   )]
      public short gxTpr_Municipionome_N
      {
         get {
            return gxTv_SdtCliente_Municipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipionome_N = value;
            SetDirty("Municipionome_N");
         }

      }

      public void gxTv_SdtCliente_Municipionome_N_SetNull( )
      {
         gxTv_SdtCliente_Municipionome_N = 0;
         SetDirty("Municipionome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_N" )]
      [  XmlElement( ElementName = "MunicipioUF_N"   )]
      public short gxTpr_Municipiouf_N
      {
         get {
            return gxTv_SdtCliente_Municipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Municipiouf_N = value;
            SetDirty("Municipiouf_N");
         }

      }

      public void gxTv_SdtCliente_Municipiouf_N_SetNull( )
      {
         gxTv_SdtCliente_Municipiouf_N = 0;
         SetDirty("Municipiouf_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Municipiouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoNumero_N" )]
      [  XmlElement( ElementName = "EnderecoNumero_N"   )]
      public short gxTpr_Endereconumero_N
      {
         get {
            return gxTv_SdtCliente_Endereconumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Endereconumero_N = value;
            SetDirty("Endereconumero_N");
         }

      }

      public void gxTv_SdtCliente_Endereconumero_N_SetNull( )
      {
         gxTv_SdtCliente_Endereconumero_N = 0;
         SetDirty("Endereconumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Endereconumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnderecoComplemento_N" )]
      [  XmlElement( ElementName = "EnderecoComplemento_N"   )]
      public short gxTpr_Enderecocomplemento_N
      {
         get {
            return gxTv_SdtCliente_Enderecocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Enderecocomplemento_N = value;
            SetDirty("Enderecocomplemento_N");
         }

      }

      public void gxTv_SdtCliente_Enderecocomplemento_N_SetNull( )
      {
         gxTv_SdtCliente_Enderecocomplemento_N = 0;
         SetDirty("Enderecocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Enderecocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoEmail_N" )]
      [  XmlElement( ElementName = "ContatoEmail_N"   )]
      public short gxTpr_Contatoemail_N
      {
         get {
            return gxTv_SdtCliente_Contatoemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoemail_N = value;
            SetDirty("Contatoemail_N");
         }

      }

      public void gxTv_SdtCliente_Contatoemail_N_SetNull( )
      {
         gxTv_SdtCliente_Contatoemail_N = 0;
         SetDirty("Contatoemail_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoDDD_N" )]
      [  XmlElement( ElementName = "ContatoDDD_N"   )]
      public short gxTpr_Contatoddd_N
      {
         get {
            return gxTv_SdtCliente_Contatoddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddd_N = value;
            SetDirty("Contatoddd_N");
         }

      }

      public void gxTv_SdtCliente_Contatoddd_N_SetNull( )
      {
         gxTv_SdtCliente_Contatoddd_N = 0;
         SetDirty("Contatoddd_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoDDI_N" )]
      [  XmlElement( ElementName = "ContatoDDI_N"   )]
      public short gxTpr_Contatoddi_N
      {
         get {
            return gxTv_SdtCliente_Contatoddi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatoddi_N = value;
            SetDirty("Contatoddi_N");
         }

      }

      public void gxTv_SdtCliente_Contatoddi_N_SetNull( )
      {
         gxTv_SdtCliente_Contatoddi_N = 0;
         SetDirty("Contatoddi_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatoddi_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoNumero_N" )]
      [  XmlElement( ElementName = "ContatoNumero_N"   )]
      public short gxTpr_Contatonumero_N
      {
         get {
            return gxTv_SdtCliente_Contatonumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatonumero_N = value;
            SetDirty("Contatonumero_N");
         }

      }

      public void gxTv_SdtCliente_Contatonumero_N_SetNull( )
      {
         gxTv_SdtCliente_Contatonumero_N = 0;
         SetDirty("Contatonumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatonumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneNumero_N" )]
      [  XmlElement( ElementName = "ContatoTelefoneNumero_N"   )]
      public short gxTpr_Contatotelefonenumero_N
      {
         get {
            return gxTv_SdtCliente_Contatotelefonenumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefonenumero_N = value;
            SetDirty("Contatotelefonenumero_N");
         }

      }

      public void gxTv_SdtCliente_Contatotelefonenumero_N_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefonenumero_N = 0;
         SetDirty("Contatotelefonenumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefonenumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDD_N" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDD_N"   )]
      public short gxTpr_Contatotelefoneddd_N
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddd_N = value;
            SetDirty("Contatotelefoneddd_N");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddd_N_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddd_N = 0;
         SetDirty("Contatotelefoneddd_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContatoTelefoneDDI_N" )]
      [  XmlElement( ElementName = "ContatoTelefoneDDI_N"   )]
      public short gxTpr_Contatotelefoneddi_N
      {
         get {
            return gxTv_SdtCliente_Contatotelefoneddi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contatotelefoneddi_N = value;
            SetDirty("Contatotelefoneddi_N");
         }

      }

      public void gxTv_SdtCliente_Contatotelefoneddi_N_SetNull( )
      {
         gxTv_SdtCliente_Contatotelefoneddi_N = 0;
         SetDirty("Contatotelefoneddi_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contatotelefoneddi_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRG_N" )]
      [  XmlElement( ElementName = "ClienteRG_N"   )]
      public short gxTpr_Clienterg_N
      {
         get {
            return gxTv_SdtCliente_Clienterg_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienterg_N = value;
            SetDirty("Clienterg_N");
         }

      }

      public void gxTv_SdtCliente_Clienterg_N_SetNull( )
      {
         gxTv_SdtCliente_Clienterg_N = 0;
         SetDirty("Clienterg_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienterg_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteQtdTitulos_F_N" )]
      [  XmlElement( ElementName = "ClienteQtdTitulos_F_N"   )]
      public short gxTpr_Clienteqtdtitulos_f_N
      {
         get {
            return gxTv_SdtCliente_Clienteqtdtitulos_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clienteqtdtitulos_f_N = value;
            SetDirty("Clienteqtdtitulos_f_N");
         }

      }

      public void gxTv_SdtCliente_Clienteqtdtitulos_f_N_SetNull( )
      {
         gxTv_SdtCliente_Clienteqtdtitulos_f_N = 0;
         SetDirty("Clienteqtdtitulos_f_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteqtdtitulos_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteValorAPagar_F_N" )]
      [  XmlElement( ElementName = "ClienteValorAPagar_F_N"   )]
      public short gxTpr_Clientevalorapagar_f_N
      {
         get {
            return gxTv_SdtCliente_Clientevalorapagar_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorapagar_f_N = value;
            SetDirty("Clientevalorapagar_f_N");
         }

      }

      public void gxTv_SdtCliente_Clientevalorapagar_f_N_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorapagar_f_N = 0;
         SetDirty("Clientevalorapagar_f_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorapagar_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteValorAReceber_F_N" )]
      [  XmlElement( ElementName = "ClienteValorAReceber_F_N"   )]
      public short gxTpr_Clientevalorareceber_f_N
      {
         get {
            return gxTv_SdtCliente_Clientevalorareceber_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientevalorareceber_f_N = value;
            SetDirty("Clientevalorareceber_f_N");
         }

      }

      public void gxTv_SdtCliente_Clientevalorareceber_f_N_SetNull( )
      {
         gxTv_SdtCliente_Clientevalorareceber_f_N = 0;
         SetDirty("Clientevalorareceber_f_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientevalorareceber_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDepositoTipo_N" )]
      [  XmlElement( ElementName = "ClienteDepositoTipo_N"   )]
      public short gxTpr_Clientedepositotipo_N
      {
         get {
            return gxTv_SdtCliente_Clientedepositotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientedepositotipo_N = value;
            SetDirty("Clientedepositotipo_N");
         }

      }

      public void gxTv_SdtCliente_Clientedepositotipo_N_SetNull( )
      {
         gxTv_SdtCliente_Clientedepositotipo_N = 0;
         SetDirty("Clientedepositotipo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientedepositotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClientePixTipo_N" )]
      [  XmlElement( ElementName = "ClientePixTipo_N"   )]
      public short gxTpr_Clientepixtipo_N
      {
         get {
            return gxTv_SdtCliente_Clientepixtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepixtipo_N = value;
            SetDirty("Clientepixtipo_N");
         }

      }

      public void gxTv_SdtCliente_Clientepixtipo_N_SetNull( )
      {
         gxTv_SdtCliente_Clientepixtipo_N = 0;
         SetDirty("Clientepixtipo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepixtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClientePix_N" )]
      [  XmlElement( ElementName = "ClientePix_N"   )]
      public short gxTpr_Clientepix_N
      {
         get {
            return gxTv_SdtCliente_Clientepix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientepix_N = value;
            SetDirty("Clientepix_N");
         }

      }

      public void gxTv_SdtCliente_Clientepix_N_SetNull( )
      {
         gxTv_SdtCliente_Clientepix_N = 0;
         SetDirty("Clientepix_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientepix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_N" )]
      [  XmlElement( ElementName = "BancoId_N"   )]
      public short gxTpr_Bancoid_N
      {
         get {
            return gxTv_SdtCliente_Bancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancoid_N = value;
            SetDirty("Bancoid_N");
         }

      }

      public void gxTv_SdtCliente_Bancoid_N_SetNull( )
      {
         gxTv_SdtCliente_Bancoid_N = 0;
         SetDirty("Bancoid_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCodigo_N" )]
      [  XmlElement( ElementName = "BancoCodigo_N"   )]
      public short gxTpr_Bancocodigo_N
      {
         get {
            return gxTv_SdtCliente_Bancocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Bancocodigo_N = value;
            SetDirty("Bancocodigo_N");
         }

      }

      public void gxTv_SdtCliente_Bancocodigo_N_SetNull( )
      {
         gxTv_SdtCliente_Bancocodigo_N = 0;
         SetDirty("Bancocodigo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Bancocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_N" )]
      [  XmlElement( ElementName = "BancoNome_N"   )]
      public short gxTpr_Banconome_N
      {
         get {
            return gxTv_SdtCliente_Banconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Banconome_N = value;
            SetDirty("Banconome_N");
         }

      }

      public void gxTv_SdtCliente_Banconome_N_SetNull( )
      {
         gxTv_SdtCliente_Banconome_N = 0;
         SetDirty("Banconome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Banconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaAgencia_N" )]
      [  XmlElement( ElementName = "ContaAgencia_N"   )]
      public short gxTpr_Contaagencia_N
      {
         get {
            return gxTv_SdtCliente_Contaagencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contaagencia_N = value;
            SetDirty("Contaagencia_N");
         }

      }

      public void gxTv_SdtCliente_Contaagencia_N_SetNull( )
      {
         gxTv_SdtCliente_Contaagencia_N = 0;
         SetDirty("Contaagencia_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contaagencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaNumero_N" )]
      [  XmlElement( ElementName = "ContaNumero_N"   )]
      public short gxTpr_Contanumero_N
      {
         get {
            return gxTv_SdtCliente_Contanumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Contanumero_N = value;
            SetDirty("Contanumero_N");
         }

      }

      public void gxTv_SdtCliente_Contanumero_N_SetNull( )
      {
         gxTv_SdtCliente_Contanumero_N = 0;
         SetDirty("Contanumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Contanumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNome_N" )]
      [  XmlElement( ElementName = "ResponsavelNome_N"   )]
      public short gxTpr_Responsavelnome_N
      {
         get {
            return gxTv_SdtCliente_Responsavelnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnome_N = value;
            SetDirty("Responsavelnome_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelnome_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnome_N = 0;
         SetDirty("Responsavelnome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidade_N" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidade_N"   )]
      public short gxTpr_Responsavelnacionalidade_N
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidade_N = value;
            SetDirty("Responsavelnacionalidade_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidade_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidade_N = 0;
         SetDirty("Responsavelnacionalidade_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNacionalidadeNome_N" )]
      [  XmlElement( ElementName = "ResponsavelNacionalidadeNome_N"   )]
      public short gxTpr_Responsavelnacionalidadenome_N
      {
         get {
            return gxTv_SdtCliente_Responsavelnacionalidadenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnacionalidadenome_N = value;
            SetDirty("Responsavelnacionalidadenome_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelnacionalidadenome_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnacionalidadenome_N = 0;
         SetDirty("Responsavelnacionalidadenome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnacionalidadenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelEstadoCivil_N" )]
      [  XmlElement( ElementName = "ResponsavelEstadoCivil_N"   )]
      public short gxTpr_Responsavelestadocivil_N
      {
         get {
            return gxTv_SdtCliente_Responsavelestadocivil_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelestadocivil_N = value;
            SetDirty("Responsavelestadocivil_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelestadocivil_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelestadocivil_N = 0;
         SetDirty("Responsavelestadocivil_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelestadocivil_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissao_N" )]
      [  XmlElement( ElementName = "ResponsavelProfissao_N"   )]
      public short gxTpr_Responsavelprofissao_N
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissao_N = value;
            SetDirty("Responsavelprofissao_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissao_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissao_N = 0;
         SetDirty("Responsavelprofissao_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelRG_N" )]
      [  XmlElement( ElementName = "ResponsavelRG_N"   )]
      public short gxTpr_Responsavelrg_N
      {
         get {
            return gxTv_SdtCliente_Responsavelrg_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelrg_N = value;
            SetDirty("Responsavelrg_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelrg_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelrg_N = 0;
         SetDirty("Responsavelrg_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelrg_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelProfissaoNome_N" )]
      [  XmlElement( ElementName = "ResponsavelProfissaoNome_N"   )]
      public short gxTpr_Responsavelprofissaonome_N
      {
         get {
            return gxTv_SdtCliente_Responsavelprofissaonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelprofissaonome_N = value;
            SetDirty("Responsavelprofissaonome_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelprofissaonome_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelprofissaonome_N = 0;
         SetDirty("Responsavelprofissaonome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelprofissaonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCPF_N" )]
      [  XmlElement( ElementName = "ResponsavelCPF_N"   )]
      public short gxTpr_Responsavelcpf_N
      {
         get {
            return gxTv_SdtCliente_Responsavelcpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcpf_N = value;
            SetDirty("Responsavelcpf_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelcpf_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcpf_N = 0;
         SetDirty("Responsavelcpf_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCEP_N" )]
      [  XmlElement( ElementName = "ResponsavelCEP_N"   )]
      public short gxTpr_Responsavelcep_N
      {
         get {
            return gxTv_SdtCliente_Responsavelcep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcep_N = value;
            SetDirty("Responsavelcep_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelcep_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcep_N = 0;
         SetDirty("Responsavelcep_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouro_N" )]
      [  XmlElement( ElementName = "ResponsavelLogradouro_N"   )]
      public short gxTpr_Responsavellogradouro_N
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouro_N = value;
            SetDirty("Responsavellogradouro_N");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouro_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouro_N = 0;
         SetDirty("Responsavellogradouro_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelBairro_N" )]
      [  XmlElement( ElementName = "ResponsavelBairro_N"   )]
      public short gxTpr_Responsavelbairro_N
      {
         get {
            return gxTv_SdtCliente_Responsavelbairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelbairro_N = value;
            SetDirty("Responsavelbairro_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelbairro_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelbairro_N = 0;
         SetDirty("Responsavelbairro_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelbairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCidade_N" )]
      [  XmlElement( ElementName = "ResponsavelCidade_N"   )]
      public short gxTpr_Responsavelcidade_N
      {
         get {
            return gxTv_SdtCliente_Responsavelcidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcidade_N = value;
            SetDirty("Responsavelcidade_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelcidade_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcidade_N = 0;
         SetDirty("Responsavelcidade_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipio_N" )]
      [  XmlElement( ElementName = "ResponsavelMunicipio_N"   )]
      public short gxTpr_Responsavelmunicipio_N
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipio_N = value;
            SetDirty("Responsavelmunicipio_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipio_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipio_N = 0;
         SetDirty("Responsavelmunicipio_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioUF_N" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioUF_N"   )]
      public short gxTpr_Responsavelmunicipiouf_N
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipiouf_N = value;
            SetDirty("Responsavelmunicipiouf_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipiouf_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipiouf_N = 0;
         SetDirty("Responsavelmunicipiouf_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipiouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelMunicipioNome_N" )]
      [  XmlElement( ElementName = "ResponsavelMunicipioNome_N"   )]
      public short gxTpr_Responsavelmunicipionome_N
      {
         get {
            return gxTv_SdtCliente_Responsavelmunicipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelmunicipionome_N = value;
            SetDirty("Responsavelmunicipionome_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelmunicipionome_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelmunicipionome_N = 0;
         SetDirty("Responsavelmunicipionome_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelmunicipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelLogradouroNumero_N" )]
      [  XmlElement( ElementName = "ResponsavelLogradouroNumero_N"   )]
      public short gxTpr_Responsavellogradouronumero_N
      {
         get {
            return gxTv_SdtCliente_Responsavellogradouronumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavellogradouronumero_N = value;
            SetDirty("Responsavellogradouronumero_N");
         }

      }

      public void gxTv_SdtCliente_Responsavellogradouronumero_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavellogradouronumero_N = 0;
         SetDirty("Responsavellogradouronumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavellogradouronumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelComplemento_N" )]
      [  XmlElement( ElementName = "ResponsavelComplemento_N"   )]
      public short gxTpr_Responsavelcomplemento_N
      {
         get {
            return gxTv_SdtCliente_Responsavelcomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcomplemento_N = value;
            SetDirty("Responsavelcomplemento_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelcomplemento_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcomplemento_N = 0;
         SetDirty("Responsavelcomplemento_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelDDD_N" )]
      [  XmlElement( ElementName = "ResponsavelDDD_N"   )]
      public short gxTpr_Responsavelddd_N
      {
         get {
            return gxTv_SdtCliente_Responsavelddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelddd_N = value;
            SetDirty("Responsavelddd_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelddd_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelddd_N = 0;
         SetDirty("Responsavelddd_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelNumero_N" )]
      [  XmlElement( ElementName = "ResponsavelNumero_N"   )]
      public short gxTpr_Responsavelnumero_N
      {
         get {
            return gxTv_SdtCliente_Responsavelnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelnumero_N = value;
            SetDirty("Responsavelnumero_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelnumero_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelnumero_N = 0;
         SetDirty("Responsavelnumero_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelEmail_N" )]
      [  XmlElement( ElementName = "ResponsavelEmail_N"   )]
      public short gxTpr_Responsavelemail_N
      {
         get {
            return gxTv_SdtCliente_Responsavelemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelemail_N = value;
            SetDirty("Responsavelemail_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelemail_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelemail_N = 0;
         SetDirty("Responsavelemail_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteSituacao_N" )]
      [  XmlElement( ElementName = "ClienteSituacao_N"   )]
      public short gxTpr_Clientesituacao_N
      {
         get {
            return gxTv_SdtCliente_Clientesituacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Clientesituacao_N = value;
            SetDirty("Clientesituacao_N");
         }

      }

      public void gxTv_SdtCliente_Clientesituacao_N_SetNull( )
      {
         gxTv_SdtCliente_Clientesituacao_N = 0;
         SetDirty("Clientesituacao_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientesituacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResponsavelCargo_N" )]
      [  XmlElement( ElementName = "ResponsavelCargo_N"   )]
      public short gxTpr_Responsavelcargo_N
      {
         get {
            return gxTv_SdtCliente_Responsavelcargo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Responsavelcargo_N = value;
            SetDirty("Responsavelcargo_N");
         }

      }

      public void gxTv_SdtCliente_Responsavelcargo_N_SetNull( )
      {
         gxTv_SdtCliente_Responsavelcargo_N = 0;
         SetDirty("Responsavelcargo_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Responsavelcargo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_N" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_N"   )]
      public short gxTpr_Tipoclienteportalpjpf_N
      {
         get {
            return gxTv_SdtCliente_Tipoclienteportalpjpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Tipoclienteportalpjpf_N = value;
            SetDirty("Tipoclienteportalpjpf_N");
         }

      }

      public void gxTv_SdtCliente_Tipoclienteportalpjpf_N_SetNull( )
      {
         gxTv_SdtCliente_Tipoclienteportalpjpf_N = 0;
         SetDirty("Tipoclienteportalpjpf_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Tipoclienteportalpjpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelacionamentoSacado_N" )]
      [  XmlElement( ElementName = "RelacionamentoSacado_N"   )]
      public short gxTpr_Relacionamentosacado_N
      {
         get {
            return gxTv_SdtCliente_Relacionamentosacado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Relacionamentosacado_N = value;
            SetDirty("Relacionamentosacado_N");
         }

      }

      public void gxTv_SdtCliente_Relacionamentosacado_N_SetNull( )
      {
         gxTv_SdtCliente_Relacionamentosacado_N = 0;
         SetDirty("Relacionamentosacado_N");
         return  ;
      }

      public bool gxTv_SdtCliente_Relacionamentosacado_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtCliente_Clientedocumento = "";
         gxTv_SdtCliente_Clienterazaosocial = "";
         gxTv_SdtCliente_Clientenomefantasia = "";
         gxTv_SdtCliente_Clientedatanascimento = DateTime.MinValue;
         gxTv_SdtCliente_Clientetipopessoa = "";
         gxTv_SdtCliente_Tipoclientedescricao = "";
         gxTv_SdtCliente_Clienteconveniodescricao = "";
         gxTv_SdtCliente_Clientecreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clienteupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clientenacionalidadenome = "";
         gxTv_SdtCliente_Clienteprofissaonome = "";
         gxTv_SdtCliente_Clienteestadocivil = "";
         gxTv_SdtCliente_Enderecotipo = "";
         gxTv_SdtCliente_Enderecocep = "";
         gxTv_SdtCliente_Enderecologradouro = "";
         gxTv_SdtCliente_Enderecobairro = "";
         gxTv_SdtCliente_Enderecocidade = "";
         gxTv_SdtCliente_Municipiocodigo = "";
         gxTv_SdtCliente_Municipionome = "";
         gxTv_SdtCliente_Municipiouf = "";
         gxTv_SdtCliente_Endereconumero = "";
         gxTv_SdtCliente_Enderecocomplemento = "";
         gxTv_SdtCliente_Contatoemail = "";
         gxTv_SdtCliente_Clientetelefone_f = "";
         gxTv_SdtCliente_Clientecelular_f = "";
         gxTv_SdtCliente_Clientedepositotipo = "";
         gxTv_SdtCliente_Clientepixtipo = "";
         gxTv_SdtCliente_Clientepix = "";
         gxTv_SdtCliente_Banconome = "";
         gxTv_SdtCliente_Contaagencia = "";
         gxTv_SdtCliente_Contanumero = "";
         gxTv_SdtCliente_Responsavelnome = "";
         gxTv_SdtCliente_Responsavelnacionalidadenome = "";
         gxTv_SdtCliente_Responsavelestadocivil = "";
         gxTv_SdtCliente_Responsavelprofissaonome = "";
         gxTv_SdtCliente_Responsavelcpf = "";
         gxTv_SdtCliente_Responsavelcep = "";
         gxTv_SdtCliente_Responsavellogradouro = "";
         gxTv_SdtCliente_Responsavelbairro = "";
         gxTv_SdtCliente_Responsavelcidade = "";
         gxTv_SdtCliente_Responsavelmunicipio = "";
         gxTv_SdtCliente_Responsavelmunicipiouf = "";
         gxTv_SdtCliente_Responsavelmunicipionome = "";
         gxTv_SdtCliente_Responsavelcomplemento = "";
         gxTv_SdtCliente_Responsavelemail = "";
         gxTv_SdtCliente_Responsavelcelular_f = "";
         gxTv_SdtCliente_Serasaultimadata_f = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clientesituacao = "";
         gxTv_SdtCliente_Responsavelcargo = "";
         gxTv_SdtCliente_Clientetiporisco = "";
         gxTv_SdtCliente_Mode = "";
         gxTv_SdtCliente_Clientedocumento_Z = "";
         gxTv_SdtCliente_Clienterazaosocial_Z = "";
         gxTv_SdtCliente_Clientenomefantasia_Z = "";
         gxTv_SdtCliente_Clientedatanascimento_Z = DateTime.MinValue;
         gxTv_SdtCliente_Clientetipopessoa_Z = "";
         gxTv_SdtCliente_Tipoclientedescricao_Z = "";
         gxTv_SdtCliente_Clienteconveniodescricao_Z = "";
         gxTv_SdtCliente_Clientecreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clienteupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clientenacionalidadenome_Z = "";
         gxTv_SdtCliente_Clienteprofissaonome_Z = "";
         gxTv_SdtCliente_Clienteestadocivil_Z = "";
         gxTv_SdtCliente_Enderecotipo_Z = "";
         gxTv_SdtCliente_Enderecocep_Z = "";
         gxTv_SdtCliente_Enderecologradouro_Z = "";
         gxTv_SdtCliente_Enderecobairro_Z = "";
         gxTv_SdtCliente_Enderecocidade_Z = "";
         gxTv_SdtCliente_Municipiocodigo_Z = "";
         gxTv_SdtCliente_Municipionome_Z = "";
         gxTv_SdtCliente_Municipiouf_Z = "";
         gxTv_SdtCliente_Endereconumero_Z = "";
         gxTv_SdtCliente_Enderecocomplemento_Z = "";
         gxTv_SdtCliente_Contatoemail_Z = "";
         gxTv_SdtCliente_Clientetelefone_f_Z = "";
         gxTv_SdtCliente_Clientecelular_f_Z = "";
         gxTv_SdtCliente_Clientedepositotipo_Z = "";
         gxTv_SdtCliente_Clientepixtipo_Z = "";
         gxTv_SdtCliente_Clientepix_Z = "";
         gxTv_SdtCliente_Banconome_Z = "";
         gxTv_SdtCliente_Contaagencia_Z = "";
         gxTv_SdtCliente_Contanumero_Z = "";
         gxTv_SdtCliente_Responsavelnome_Z = "";
         gxTv_SdtCliente_Responsavelnacionalidadenome_Z = "";
         gxTv_SdtCliente_Responsavelestadocivil_Z = "";
         gxTv_SdtCliente_Responsavelprofissaonome_Z = "";
         gxTv_SdtCliente_Responsavelcpf_Z = "";
         gxTv_SdtCliente_Responsavelcep_Z = "";
         gxTv_SdtCliente_Responsavellogradouro_Z = "";
         gxTv_SdtCliente_Responsavelbairro_Z = "";
         gxTv_SdtCliente_Responsavelcidade_Z = "";
         gxTv_SdtCliente_Responsavelmunicipio_Z = "";
         gxTv_SdtCliente_Responsavelmunicipiouf_Z = "";
         gxTv_SdtCliente_Responsavelmunicipionome_Z = "";
         gxTv_SdtCliente_Responsavelcomplemento_Z = "";
         gxTv_SdtCliente_Responsavelemail_Z = "";
         gxTv_SdtCliente_Responsavelcelular_f_Z = "";
         gxTv_SdtCliente_Serasaultimadata_f_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCliente_Clientesituacao_Z = "";
         gxTv_SdtCliente_Responsavelcargo_Z = "";
         gxTv_SdtCliente_Clientetiporisco_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "cliente", "GeneXus.Programs.cliente_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtCliente_Tipoclienteid ;
      private short gxTv_SdtCliente_Clienteloguser ;
      private short gxTv_SdtCliente_Secuserid_f ;
      private short gxTv_SdtCliente_Contatoddd ;
      private short gxTv_SdtCliente_Contatoddi ;
      private short gxTv_SdtCliente_Contatotelefoneddd ;
      private short gxTv_SdtCliente_Contatotelefoneddi ;
      private short gxTv_SdtCliente_Responsavelddd ;
      private short gxTv_SdtCliente_Serasaconsultas_f ;
      private short gxTv_SdtCliente_Serasascoreultimadata_f ;
      private short gxTv_SdtCliente_Relacionamentosacado ;
      private short gxTv_SdtCliente_Initialized ;
      private short gxTv_SdtCliente_Tipoclienteid_Z ;
      private short gxTv_SdtCliente_Clienteloguser_Z ;
      private short gxTv_SdtCliente_Secuserid_f_Z ;
      private short gxTv_SdtCliente_Contatoddd_Z ;
      private short gxTv_SdtCliente_Contatoddi_Z ;
      private short gxTv_SdtCliente_Contatotelefoneddd_Z ;
      private short gxTv_SdtCliente_Contatotelefoneddi_Z ;
      private short gxTv_SdtCliente_Responsavelddd_Z ;
      private short gxTv_SdtCliente_Serasaconsultas_f_Z ;
      private short gxTv_SdtCliente_Serasascoreultimadata_f_Z ;
      private short gxTv_SdtCliente_Relacionamentosacado_Z ;
      private short gxTv_SdtCliente_Clienteid_N ;
      private short gxTv_SdtCliente_Clientedocumento_N ;
      private short gxTv_SdtCliente_Clienterazaosocial_N ;
      private short gxTv_SdtCliente_Clientenomefantasia_N ;
      private short gxTv_SdtCliente_Clientedatanascimento_N ;
      private short gxTv_SdtCliente_Clientetipopessoa_N ;
      private short gxTv_SdtCliente_Especialidadeid_N ;
      private short gxTv_SdtCliente_Tipoclienteid_N ;
      private short gxTv_SdtCliente_Tipoclientedescricao_N ;
      private short gxTv_SdtCliente_Tipoclienteportal_N ;
      private short gxTv_SdtCliente_Clientestatus_N ;
      private short gxTv_SdtCliente_Clienteconvenio_N ;
      private short gxTv_SdtCliente_Clienteconveniodescricao_N ;
      private short gxTv_SdtCliente_Clientecreatedat_N ;
      private short gxTv_SdtCliente_Clienteupdatedat_N ;
      private short gxTv_SdtCliente_Clienteloguser_N ;
      private short gxTv_SdtCliente_Clientenacionalidade_N ;
      private short gxTv_SdtCliente_Clientenacionalidadenome_N ;
      private short gxTv_SdtCliente_Clienteprofissao_N ;
      private short gxTv_SdtCliente_Clienteprofissaonome_N ;
      private short gxTv_SdtCliente_Clienteestadocivil_N ;
      private short gxTv_SdtCliente_Secuserid_f_N ;
      private short gxTv_SdtCliente_Enderecotipo_N ;
      private short gxTv_SdtCliente_Enderecocep_N ;
      private short gxTv_SdtCliente_Enderecologradouro_N ;
      private short gxTv_SdtCliente_Enderecobairro_N ;
      private short gxTv_SdtCliente_Enderecocidade_N ;
      private short gxTv_SdtCliente_Municipiocodigo_N ;
      private short gxTv_SdtCliente_Municipionome_N ;
      private short gxTv_SdtCliente_Municipiouf_N ;
      private short gxTv_SdtCliente_Endereconumero_N ;
      private short gxTv_SdtCliente_Enderecocomplemento_N ;
      private short gxTv_SdtCliente_Contatoemail_N ;
      private short gxTv_SdtCliente_Contatoddd_N ;
      private short gxTv_SdtCliente_Contatoddi_N ;
      private short gxTv_SdtCliente_Contatonumero_N ;
      private short gxTv_SdtCliente_Contatotelefonenumero_N ;
      private short gxTv_SdtCliente_Contatotelefoneddd_N ;
      private short gxTv_SdtCliente_Contatotelefoneddi_N ;
      private short gxTv_SdtCliente_Clienterg_N ;
      private short gxTv_SdtCliente_Clienteqtdtitulos_f_N ;
      private short gxTv_SdtCliente_Clientevalorapagar_f_N ;
      private short gxTv_SdtCliente_Clientevalorareceber_f_N ;
      private short gxTv_SdtCliente_Clientedepositotipo_N ;
      private short gxTv_SdtCliente_Clientepixtipo_N ;
      private short gxTv_SdtCliente_Clientepix_N ;
      private short gxTv_SdtCliente_Bancoid_N ;
      private short gxTv_SdtCliente_Bancocodigo_N ;
      private short gxTv_SdtCliente_Banconome_N ;
      private short gxTv_SdtCliente_Contaagencia_N ;
      private short gxTv_SdtCliente_Contanumero_N ;
      private short gxTv_SdtCliente_Responsavelnome_N ;
      private short gxTv_SdtCliente_Responsavelnacionalidade_N ;
      private short gxTv_SdtCliente_Responsavelnacionalidadenome_N ;
      private short gxTv_SdtCliente_Responsavelestadocivil_N ;
      private short gxTv_SdtCliente_Responsavelprofissao_N ;
      private short gxTv_SdtCliente_Responsavelrg_N ;
      private short gxTv_SdtCliente_Responsavelprofissaonome_N ;
      private short gxTv_SdtCliente_Responsavelcpf_N ;
      private short gxTv_SdtCliente_Responsavelcep_N ;
      private short gxTv_SdtCliente_Responsavellogradouro_N ;
      private short gxTv_SdtCliente_Responsavelbairro_N ;
      private short gxTv_SdtCliente_Responsavelcidade_N ;
      private short gxTv_SdtCliente_Responsavelmunicipio_N ;
      private short gxTv_SdtCliente_Responsavelmunicipiouf_N ;
      private short gxTv_SdtCliente_Responsavelmunicipionome_N ;
      private short gxTv_SdtCliente_Responsavellogradouronumero_N ;
      private short gxTv_SdtCliente_Responsavelcomplemento_N ;
      private short gxTv_SdtCliente_Responsavelddd_N ;
      private short gxTv_SdtCliente_Responsavelnumero_N ;
      private short gxTv_SdtCliente_Responsavelemail_N ;
      private short gxTv_SdtCliente_Clientesituacao_N ;
      private short gxTv_SdtCliente_Responsavelcargo_N ;
      private short gxTv_SdtCliente_Tipoclienteportalpjpf_N ;
      private short gxTv_SdtCliente_Relacionamentosacado_N ;
      private int gxTv_SdtCliente_Clienteid ;
      private int gxTv_SdtCliente_Especialidadeid ;
      private int gxTv_SdtCliente_Clienteconvenio ;
      private int gxTv_SdtCliente_Clientenacionalidade ;
      private int gxTv_SdtCliente_Clienteprofissao ;
      private int gxTv_SdtCliente_Clienteqtdtitulos_f ;
      private int gxTv_SdtCliente_Bancoid ;
      private int gxTv_SdtCliente_Bancocodigo ;
      private int gxTv_SdtCliente_Responsavelnacionalidade ;
      private int gxTv_SdtCliente_Responsavelprofissao ;
      private int gxTv_SdtCliente_Responsavellogradouronumero ;
      private int gxTv_SdtCliente_Responsavelnumero ;
      private int gxTv_SdtCliente_Clienteid_Z ;
      private int gxTv_SdtCliente_Especialidadeid_Z ;
      private int gxTv_SdtCliente_Clienteconvenio_Z ;
      private int gxTv_SdtCliente_Clientenacionalidade_Z ;
      private int gxTv_SdtCliente_Clienteprofissao_Z ;
      private int gxTv_SdtCliente_Clienteqtdtitulos_f_Z ;
      private int gxTv_SdtCliente_Bancoid_Z ;
      private int gxTv_SdtCliente_Bancocodigo_Z ;
      private int gxTv_SdtCliente_Responsavelnacionalidade_Z ;
      private int gxTv_SdtCliente_Responsavelprofissao_Z ;
      private int gxTv_SdtCliente_Responsavellogradouronumero_Z ;
      private int gxTv_SdtCliente_Responsavelnumero_Z ;
      private long gxTv_SdtCliente_Contatonumero ;
      private long gxTv_SdtCliente_Contatotelefonenumero ;
      private long gxTv_SdtCliente_Clienterg ;
      private long gxTv_SdtCliente_Responsavelrg ;
      private long gxTv_SdtCliente_Contatonumero_Z ;
      private long gxTv_SdtCliente_Contatotelefonenumero_Z ;
      private long gxTv_SdtCliente_Clienterg_Z ;
      private long gxTv_SdtCliente_Responsavelrg_Z ;
      private decimal gxTv_SdtCliente_Clientevalorapagar_f ;
      private decimal gxTv_SdtCliente_Clientevalorareceber_f ;
      private decimal gxTv_SdtCliente_Serasaultimovalorrecomendado_f ;
      private decimal gxTv_SdtCliente_Clientevalorapagar_f_Z ;
      private decimal gxTv_SdtCliente_Clientevalorareceber_f_Z ;
      private decimal gxTv_SdtCliente_Serasaultimovalorrecomendado_f_Z ;
      private string gxTv_SdtCliente_Clientesituacao ;
      private string gxTv_SdtCliente_Mode ;
      private string gxTv_SdtCliente_Clientesituacao_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtCliente_Clientecreatedat ;
      private DateTime gxTv_SdtCliente_Clienteupdatedat ;
      private DateTime gxTv_SdtCliente_Serasaultimadata_f ;
      private DateTime gxTv_SdtCliente_Clientecreatedat_Z ;
      private DateTime gxTv_SdtCliente_Clienteupdatedat_Z ;
      private DateTime gxTv_SdtCliente_Serasaultimadata_f_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtCliente_Clientedatanascimento ;
      private DateTime gxTv_SdtCliente_Clientedatanascimento_Z ;
      private bool gxTv_SdtCliente_Tipoclienteportal ;
      private bool gxTv_SdtCliente_Clientestatus ;
      private bool gxTv_SdtCliente_Tipoclienteportalpjpf ;
      private bool gxTv_SdtCliente_Clientesacado ;
      private bool gxTv_SdtCliente_Tipoclienteportal_Z ;
      private bool gxTv_SdtCliente_Clientestatus_Z ;
      private bool gxTv_SdtCliente_Tipoclienteportalpjpf_Z ;
      private bool gxTv_SdtCliente_Clientesacado_Z ;
      private string gxTv_SdtCliente_Clientedocumento ;
      private string gxTv_SdtCliente_Clienterazaosocial ;
      private string gxTv_SdtCliente_Clientenomefantasia ;
      private string gxTv_SdtCliente_Clientetipopessoa ;
      private string gxTv_SdtCliente_Tipoclientedescricao ;
      private string gxTv_SdtCliente_Clienteconveniodescricao ;
      private string gxTv_SdtCliente_Clientenacionalidadenome ;
      private string gxTv_SdtCliente_Clienteprofissaonome ;
      private string gxTv_SdtCliente_Clienteestadocivil ;
      private string gxTv_SdtCliente_Enderecotipo ;
      private string gxTv_SdtCliente_Enderecocep ;
      private string gxTv_SdtCliente_Enderecologradouro ;
      private string gxTv_SdtCliente_Enderecobairro ;
      private string gxTv_SdtCliente_Enderecocidade ;
      private string gxTv_SdtCliente_Municipiocodigo ;
      private string gxTv_SdtCliente_Municipionome ;
      private string gxTv_SdtCliente_Municipiouf ;
      private string gxTv_SdtCliente_Endereconumero ;
      private string gxTv_SdtCliente_Enderecocomplemento ;
      private string gxTv_SdtCliente_Contatoemail ;
      private string gxTv_SdtCliente_Clientetelefone_f ;
      private string gxTv_SdtCliente_Clientecelular_f ;
      private string gxTv_SdtCliente_Clientedepositotipo ;
      private string gxTv_SdtCliente_Clientepixtipo ;
      private string gxTv_SdtCliente_Clientepix ;
      private string gxTv_SdtCliente_Banconome ;
      private string gxTv_SdtCliente_Contaagencia ;
      private string gxTv_SdtCliente_Contanumero ;
      private string gxTv_SdtCliente_Responsavelnome ;
      private string gxTv_SdtCliente_Responsavelnacionalidadenome ;
      private string gxTv_SdtCliente_Responsavelestadocivil ;
      private string gxTv_SdtCliente_Responsavelprofissaonome ;
      private string gxTv_SdtCliente_Responsavelcpf ;
      private string gxTv_SdtCliente_Responsavelcep ;
      private string gxTv_SdtCliente_Responsavellogradouro ;
      private string gxTv_SdtCliente_Responsavelbairro ;
      private string gxTv_SdtCliente_Responsavelcidade ;
      private string gxTv_SdtCliente_Responsavelmunicipio ;
      private string gxTv_SdtCliente_Responsavelmunicipiouf ;
      private string gxTv_SdtCliente_Responsavelmunicipionome ;
      private string gxTv_SdtCliente_Responsavelcomplemento ;
      private string gxTv_SdtCliente_Responsavelemail ;
      private string gxTv_SdtCliente_Responsavelcelular_f ;
      private string gxTv_SdtCliente_Responsavelcargo ;
      private string gxTv_SdtCliente_Clientetiporisco ;
      private string gxTv_SdtCliente_Clientedocumento_Z ;
      private string gxTv_SdtCliente_Clienterazaosocial_Z ;
      private string gxTv_SdtCliente_Clientenomefantasia_Z ;
      private string gxTv_SdtCliente_Clientetipopessoa_Z ;
      private string gxTv_SdtCliente_Tipoclientedescricao_Z ;
      private string gxTv_SdtCliente_Clienteconveniodescricao_Z ;
      private string gxTv_SdtCliente_Clientenacionalidadenome_Z ;
      private string gxTv_SdtCliente_Clienteprofissaonome_Z ;
      private string gxTv_SdtCliente_Clienteestadocivil_Z ;
      private string gxTv_SdtCliente_Enderecotipo_Z ;
      private string gxTv_SdtCliente_Enderecocep_Z ;
      private string gxTv_SdtCliente_Enderecologradouro_Z ;
      private string gxTv_SdtCliente_Enderecobairro_Z ;
      private string gxTv_SdtCliente_Enderecocidade_Z ;
      private string gxTv_SdtCliente_Municipiocodigo_Z ;
      private string gxTv_SdtCliente_Municipionome_Z ;
      private string gxTv_SdtCliente_Municipiouf_Z ;
      private string gxTv_SdtCliente_Endereconumero_Z ;
      private string gxTv_SdtCliente_Enderecocomplemento_Z ;
      private string gxTv_SdtCliente_Contatoemail_Z ;
      private string gxTv_SdtCliente_Clientetelefone_f_Z ;
      private string gxTv_SdtCliente_Clientecelular_f_Z ;
      private string gxTv_SdtCliente_Clientedepositotipo_Z ;
      private string gxTv_SdtCliente_Clientepixtipo_Z ;
      private string gxTv_SdtCliente_Clientepix_Z ;
      private string gxTv_SdtCliente_Banconome_Z ;
      private string gxTv_SdtCliente_Contaagencia_Z ;
      private string gxTv_SdtCliente_Contanumero_Z ;
      private string gxTv_SdtCliente_Responsavelnome_Z ;
      private string gxTv_SdtCliente_Responsavelnacionalidadenome_Z ;
      private string gxTv_SdtCliente_Responsavelestadocivil_Z ;
      private string gxTv_SdtCliente_Responsavelprofissaonome_Z ;
      private string gxTv_SdtCliente_Responsavelcpf_Z ;
      private string gxTv_SdtCliente_Responsavelcep_Z ;
      private string gxTv_SdtCliente_Responsavellogradouro_Z ;
      private string gxTv_SdtCliente_Responsavelbairro_Z ;
      private string gxTv_SdtCliente_Responsavelcidade_Z ;
      private string gxTv_SdtCliente_Responsavelmunicipio_Z ;
      private string gxTv_SdtCliente_Responsavelmunicipiouf_Z ;
      private string gxTv_SdtCliente_Responsavelmunicipionome_Z ;
      private string gxTv_SdtCliente_Responsavelcomplemento_Z ;
      private string gxTv_SdtCliente_Responsavelemail_Z ;
      private string gxTv_SdtCliente_Responsavelcelular_f_Z ;
      private string gxTv_SdtCliente_Responsavelcargo_Z ;
      private string gxTv_SdtCliente_Clientetiporisco_Z ;
   }

   [DataContract(Name = @"Cliente", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCliente_RESTInterface : GxGenericCollectionItem<SdtCliente>
   {
      public SdtCliente_RESTInterface( ) : base()
      {
      }

      public SdtCliente_RESTInterface( SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteDocumento" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumento
      {
         get {
            return sdt.gxTpr_Clientedocumento ;
         }

         set {
            sdt.gxTpr_Clientedocumento = value;
         }

      }

      [DataMember( Name = "ClienteRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return sdt.gxTpr_Clienterazaosocial ;
         }

         set {
            sdt.gxTpr_Clienterazaosocial = value;
         }

      }

      [DataMember( Name = "ClienteNomeFantasia" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Clientenomefantasia
      {
         get {
            return sdt.gxTpr_Clientenomefantasia ;
         }

         set {
            sdt.gxTpr_Clientenomefantasia = value;
         }

      }

      [DataMember( Name = "ClienteDataNascimento" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Clientedatanascimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Clientedatanascimento) ;
         }

         set {
            sdt.gxTpr_Clientedatanascimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ClienteTipoPessoa" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Clientetipopessoa
      {
         get {
            return sdt.gxTpr_Clientetipopessoa ;
         }

         set {
            sdt.gxTpr_Clientetipopessoa = value;
         }

      }

      [DataMember( Name = "EspecialidadeId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Especialidadeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Especialidadeid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Especialidadeid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TipoClienteId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoclienteid
      {
         get {
            return sdt.gxTpr_Tipoclienteid ;
         }

         set {
            sdt.gxTpr_Tipoclienteid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoClienteDescricao" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tipoclientedescricao
      {
         get {
            return sdt.gxTpr_Tipoclientedescricao ;
         }

         set {
            sdt.gxTpr_Tipoclientedescricao = value;
         }

      }

      [DataMember( Name = "TipoClientePortal" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclienteportal
      {
         get {
            return sdt.gxTpr_Tipoclienteportal ;
         }

         set {
            sdt.gxTpr_Tipoclienteportal = value;
         }

      }

      [DataMember( Name = "ClienteStatus" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Clientestatus
      {
         get {
            return sdt.gxTpr_Clientestatus ;
         }

         set {
            sdt.gxTpr_Clientestatus = value;
         }

      }

      [DataMember( Name = "ClienteConvenio" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Clienteconvenio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteconvenio), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteconvenio = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteConvenioDescricao" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Clienteconveniodescricao
      {
         get {
            return sdt.gxTpr_Clienteconveniodescricao ;
         }

         set {
            sdt.gxTpr_Clienteconveniodescricao = value;
         }

      }

      [DataMember( Name = "ClienteCreatedAt" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Clientecreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clientecreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clientecreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ClienteUpdatedAt" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Clienteupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clienteupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clienteupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ClienteLogUser" , Order = 15 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clienteloguser
      {
         get {
            return sdt.gxTpr_Clienteloguser ;
         }

         set {
            sdt.gxTpr_Clienteloguser = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteNacionalidade" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Clientenacionalidade
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientenacionalidade), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clientenacionalidade = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteNacionalidadeNome" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Clientenacionalidadenome
      {
         get {
            return sdt.gxTpr_Clientenacionalidadenome ;
         }

         set {
            sdt.gxTpr_Clientenacionalidadenome = value;
         }

      }

      [DataMember( Name = "ClienteProfissao" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Clienteprofissao
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteprofissao), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteprofissao = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteProfissaoNome" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Clienteprofissaonome
      {
         get {
            return sdt.gxTpr_Clienteprofissaonome ;
         }

         set {
            sdt.gxTpr_Clienteprofissaonome = value;
         }

      }

      [DataMember( Name = "ClienteEstadoCivil" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Clienteestadocivil
      {
         get {
            return sdt.gxTpr_Clienteestadocivil ;
         }

         set {
            sdt.gxTpr_Clienteestadocivil = value;
         }

      }

      [DataMember( Name = "SecUserId_F" , Order = 21 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secuserid_f
      {
         get {
            return sdt.gxTpr_Secuserid_f ;
         }

         set {
            sdt.gxTpr_Secuserid_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EnderecoTipo" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Enderecotipo
      {
         get {
            return sdt.gxTpr_Enderecotipo ;
         }

         set {
            sdt.gxTpr_Enderecotipo = value;
         }

      }

      [DataMember( Name = "EnderecoCEP" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Enderecocep
      {
         get {
            return sdt.gxTpr_Enderecocep ;
         }

         set {
            sdt.gxTpr_Enderecocep = value;
         }

      }

      [DataMember( Name = "EnderecoLogradouro" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Enderecologradouro
      {
         get {
            return sdt.gxTpr_Enderecologradouro ;
         }

         set {
            sdt.gxTpr_Enderecologradouro = value;
         }

      }

      [DataMember( Name = "EnderecoBairro" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Enderecobairro
      {
         get {
            return sdt.gxTpr_Enderecobairro ;
         }

         set {
            sdt.gxTpr_Enderecobairro = value;
         }

      }

      [DataMember( Name = "EnderecoCidade" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Enderecocidade
      {
         get {
            return sdt.gxTpr_Enderecocidade ;
         }

         set {
            sdt.gxTpr_Enderecocidade = value;
         }

      }

      [DataMember( Name = "MunicipioCodigo" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Municipiocodigo
      {
         get {
            return sdt.gxTpr_Municipiocodigo ;
         }

         set {
            sdt.gxTpr_Municipiocodigo = value;
         }

      }

      [DataMember( Name = "MunicipioNome" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
         }

      }

      [DataMember( Name = "MunicipioUF" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Municipiouf
      {
         get {
            return sdt.gxTpr_Municipiouf ;
         }

         set {
            sdt.gxTpr_Municipiouf = value;
         }

      }

      [DataMember( Name = "EnderecoNumero" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Endereconumero
      {
         get {
            return sdt.gxTpr_Endereconumero ;
         }

         set {
            sdt.gxTpr_Endereconumero = value;
         }

      }

      [DataMember( Name = "EnderecoComplemento" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Enderecocomplemento
      {
         get {
            return sdt.gxTpr_Enderecocomplemento ;
         }

         set {
            sdt.gxTpr_Enderecocomplemento = value;
         }

      }

      [DataMember( Name = "ContatoEmail" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Contatoemail
      {
         get {
            return sdt.gxTpr_Contatoemail ;
         }

         set {
            sdt.gxTpr_Contatoemail = value;
         }

      }

      [DataMember( Name = "ContatoDDD" , Order = 33 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contatoddd
      {
         get {
            return sdt.gxTpr_Contatoddd ;
         }

         set {
            sdt.gxTpr_Contatoddd = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContatoDDI" , Order = 34 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contatoddi
      {
         get {
            return sdt.gxTpr_Contatoddi ;
         }

         set {
            sdt.gxTpr_Contatoddi = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContatoNumero" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Contatonumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contatonumero), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Contatonumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContatoTelefoneNumero" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Contatotelefonenumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contatotelefonenumero), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Contatotelefonenumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContatoTelefoneDDD" , Order = 37 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contatotelefoneddd
      {
         get {
            return sdt.gxTpr_Contatotelefoneddd ;
         }

         set {
            sdt.gxTpr_Contatotelefoneddd = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContatoTelefoneDDI" , Order = 38 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contatotelefoneddi
      {
         get {
            return sdt.gxTpr_Contatotelefoneddi ;
         }

         set {
            sdt.gxTpr_Contatotelefoneddi = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteRG" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Clienterg
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienterg), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Clienterg = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteTelefone_F" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Clientetelefone_f
      {
         get {
            return sdt.gxTpr_Clientetelefone_f ;
         }

         set {
            sdt.gxTpr_Clientetelefone_f = value;
         }

      }

      [DataMember( Name = "ClienteCelular_F" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Clientecelular_f
      {
         get {
            return sdt.gxTpr_Clientecelular_f ;
         }

         set {
            sdt.gxTpr_Clientecelular_f = value;
         }

      }

      [DataMember( Name = "ClienteQtdTitulos_F" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Clienteqtdtitulos_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteqtdtitulos_f), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteqtdtitulos_f = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteValorAPagar_F" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Clientevalorapagar_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientevalorapagar_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Clientevalorapagar_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteValorAReceber_F" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Clientevalorareceber_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientevalorareceber_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Clientevalorareceber_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteDepositoTipo" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Clientedepositotipo
      {
         get {
            return sdt.gxTpr_Clientedepositotipo ;
         }

         set {
            sdt.gxTpr_Clientedepositotipo = value;
         }

      }

      [DataMember( Name = "ClientePixTipo" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Clientepixtipo
      {
         get {
            return sdt.gxTpr_Clientepixtipo ;
         }

         set {
            sdt.gxTpr_Clientepixtipo = value;
         }

      }

      [DataMember( Name = "ClientePix" , Order = 47 )]
      [GxSeudo()]
      public string gxTpr_Clientepix
      {
         get {
            return sdt.gxTpr_Clientepix ;
         }

         set {
            sdt.gxTpr_Clientepix = value;
         }

      }

      [DataMember( Name = "BancoId" , Order = 48 )]
      [GxSeudo()]
      public string gxTpr_Bancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Bancoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoCodigo" , Order = 49 )]
      [GxSeudo()]
      public string gxTpr_Bancocodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancocodigo), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Bancocodigo = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoNome" , Order = 50 )]
      [GxSeudo()]
      public string gxTpr_Banconome
      {
         get {
            return sdt.gxTpr_Banconome ;
         }

         set {
            sdt.gxTpr_Banconome = value;
         }

      }

      [DataMember( Name = "ContaAgencia" , Order = 51 )]
      [GxSeudo()]
      public string gxTpr_Contaagencia
      {
         get {
            return sdt.gxTpr_Contaagencia ;
         }

         set {
            sdt.gxTpr_Contaagencia = value;
         }

      }

      [DataMember( Name = "ContaNumero" , Order = 52 )]
      [GxSeudo()]
      public string gxTpr_Contanumero
      {
         get {
            return sdt.gxTpr_Contanumero ;
         }

         set {
            sdt.gxTpr_Contanumero = value;
         }

      }

      [DataMember( Name = "ResponsavelNome" , Order = 53 )]
      [GxSeudo()]
      public string gxTpr_Responsavelnome
      {
         get {
            return sdt.gxTpr_Responsavelnome ;
         }

         set {
            sdt.gxTpr_Responsavelnome = value;
         }

      }

      [DataMember( Name = "ResponsavelNacionalidade" , Order = 54 )]
      [GxSeudo()]
      public string gxTpr_Responsavelnacionalidade
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Responsavelnacionalidade), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Responsavelnacionalidade = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ResponsavelNacionalidadeNome" , Order = 55 )]
      [GxSeudo()]
      public string gxTpr_Responsavelnacionalidadenome
      {
         get {
            return sdt.gxTpr_Responsavelnacionalidadenome ;
         }

         set {
            sdt.gxTpr_Responsavelnacionalidadenome = value;
         }

      }

      [DataMember( Name = "ResponsavelEstadoCivil" , Order = 56 )]
      [GxSeudo()]
      public string gxTpr_Responsavelestadocivil
      {
         get {
            return sdt.gxTpr_Responsavelestadocivil ;
         }

         set {
            sdt.gxTpr_Responsavelestadocivil = value;
         }

      }

      [DataMember( Name = "ResponsavelProfissao" , Order = 57 )]
      [GxSeudo()]
      public string gxTpr_Responsavelprofissao
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Responsavelprofissao), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Responsavelprofissao = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ResponsavelRG" , Order = 58 )]
      [GxSeudo()]
      public string gxTpr_Responsavelrg
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Responsavelrg), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Responsavelrg = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ResponsavelProfissaoNome" , Order = 59 )]
      [GxSeudo()]
      public string gxTpr_Responsavelprofissaonome
      {
         get {
            return sdt.gxTpr_Responsavelprofissaonome ;
         }

         set {
            sdt.gxTpr_Responsavelprofissaonome = value;
         }

      }

      [DataMember( Name = "ResponsavelCPF" , Order = 60 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcpf
      {
         get {
            return sdt.gxTpr_Responsavelcpf ;
         }

         set {
            sdt.gxTpr_Responsavelcpf = value;
         }

      }

      [DataMember( Name = "ResponsavelCEP" , Order = 61 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcep
      {
         get {
            return sdt.gxTpr_Responsavelcep ;
         }

         set {
            sdt.gxTpr_Responsavelcep = value;
         }

      }

      [DataMember( Name = "ResponsavelLogradouro" , Order = 62 )]
      [GxSeudo()]
      public string gxTpr_Responsavellogradouro
      {
         get {
            return sdt.gxTpr_Responsavellogradouro ;
         }

         set {
            sdt.gxTpr_Responsavellogradouro = value;
         }

      }

      [DataMember( Name = "ResponsavelBairro" , Order = 63 )]
      [GxSeudo()]
      public string gxTpr_Responsavelbairro
      {
         get {
            return sdt.gxTpr_Responsavelbairro ;
         }

         set {
            sdt.gxTpr_Responsavelbairro = value;
         }

      }

      [DataMember( Name = "ResponsavelCidade" , Order = 64 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcidade
      {
         get {
            return sdt.gxTpr_Responsavelcidade ;
         }

         set {
            sdt.gxTpr_Responsavelcidade = value;
         }

      }

      [DataMember( Name = "ResponsavelMunicipio" , Order = 65 )]
      [GxSeudo()]
      public string gxTpr_Responsavelmunicipio
      {
         get {
            return sdt.gxTpr_Responsavelmunicipio ;
         }

         set {
            sdt.gxTpr_Responsavelmunicipio = value;
         }

      }

      [DataMember( Name = "ResponsavelMunicipioUF" , Order = 66 )]
      [GxSeudo()]
      public string gxTpr_Responsavelmunicipiouf
      {
         get {
            return sdt.gxTpr_Responsavelmunicipiouf ;
         }

         set {
            sdt.gxTpr_Responsavelmunicipiouf = value;
         }

      }

      [DataMember( Name = "ResponsavelMunicipioNome" , Order = 67 )]
      [GxSeudo()]
      public string gxTpr_Responsavelmunicipionome
      {
         get {
            return sdt.gxTpr_Responsavelmunicipionome ;
         }

         set {
            sdt.gxTpr_Responsavelmunicipionome = value;
         }

      }

      [DataMember( Name = "ResponsavelLogradouroNumero" , Order = 68 )]
      [GxSeudo()]
      public string gxTpr_Responsavellogradouronumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Responsavellogradouronumero), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Responsavellogradouronumero = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ResponsavelComplemento" , Order = 69 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcomplemento
      {
         get {
            return sdt.gxTpr_Responsavelcomplemento ;
         }

         set {
            sdt.gxTpr_Responsavelcomplemento = value;
         }

      }

      [DataMember( Name = "ResponsavelDDD" , Order = 70 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Responsavelddd
      {
         get {
            return sdt.gxTpr_Responsavelddd ;
         }

         set {
            sdt.gxTpr_Responsavelddd = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResponsavelNumero" , Order = 71 )]
      [GxSeudo()]
      public string gxTpr_Responsavelnumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Responsavelnumero), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Responsavelnumero = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ResponsavelEmail" , Order = 72 )]
      [GxSeudo()]
      public string gxTpr_Responsavelemail
      {
         get {
            return sdt.gxTpr_Responsavelemail ;
         }

         set {
            sdt.gxTpr_Responsavelemail = value;
         }

      }

      [DataMember( Name = "ResponsavelCelular_F" , Order = 73 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcelular_f
      {
         get {
            return sdt.gxTpr_Responsavelcelular_f ;
         }

         set {
            sdt.gxTpr_Responsavelcelular_f = value;
         }

      }

      [DataMember( Name = "SerasaConsultas_F" , Order = 74 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasaconsultas_f
      {
         get {
            return sdt.gxTpr_Serasaconsultas_f ;
         }

         set {
            sdt.gxTpr_Serasaconsultas_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaUltimaData_F" , Order = 75 )]
      [GxSeudo()]
      public string gxTpr_Serasaultimadata_f
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Serasaultimadata_f, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Serasaultimadata_f = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SerasaScoreUltimaData_F" , Order = 76 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasascoreultimadata_f
      {
         get {
            return sdt.gxTpr_Serasascoreultimadata_f ;
         }

         set {
            sdt.gxTpr_Serasascoreultimadata_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaUltimoValorRecomendado_F" , Order = 77 )]
      [GxSeudo()]
      public string gxTpr_Serasaultimovalorrecomendado_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasaultimovalorrecomendado_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasaultimovalorrecomendado_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteSituacao" , Order = 78 )]
      [GxSeudo()]
      public string gxTpr_Clientesituacao
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Clientesituacao) ;
         }

         set {
            sdt.gxTpr_Clientesituacao = value;
         }

      }

      [DataMember( Name = "ResponsavelCargo" , Order = 79 )]
      [GxSeudo()]
      public string gxTpr_Responsavelcargo
      {
         get {
            return sdt.gxTpr_Responsavelcargo ;
         }

         set {
            sdt.gxTpr_Responsavelcargo = value;
         }

      }

      [DataMember( Name = "TipoClientePortalPjPf" , Order = 80 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return sdt.gxTpr_Tipoclienteportalpjpf ;
         }

         set {
            sdt.gxTpr_Tipoclienteportalpjpf = value;
         }

      }

      [DataMember( Name = "RelacionamentoSacado" , Order = 81 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Relacionamentosacado
      {
         get {
            return sdt.gxTpr_Relacionamentosacado ;
         }

         set {
            sdt.gxTpr_Relacionamentosacado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteSacado" , Order = 82 )]
      [GxSeudo()]
      public bool gxTpr_Clientesacado
      {
         get {
            return sdt.gxTpr_Clientesacado ;
         }

         set {
            sdt.gxTpr_Clientesacado = value;
         }

      }

      [DataMember( Name = "ClienteTipoRisco" , Order = 83 )]
      [GxSeudo()]
      public string gxTpr_Clientetiporisco
      {
         get {
            return sdt.gxTpr_Clientetiporisco ;
         }

         set {
            sdt.gxTpr_Clientetiporisco = value;
         }

      }

      public SdtCliente sdt
      {
         get {
            return (SdtCliente)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCliente() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 84 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Cliente", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCliente_RESTLInterface : GxGenericCollectionItem<SdtCliente>
   {
      public SdtCliente_RESTLInterface( ) : base()
      {
      }

      public SdtCliente_RESTLInterface( SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteDocumento" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumento
      {
         get {
            return sdt.gxTpr_Clientedocumento ;
         }

         set {
            sdt.gxTpr_Clientedocumento = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCliente sdt
      {
         get {
            return (SdtCliente)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCliente() ;
         }
      }

   }

}
