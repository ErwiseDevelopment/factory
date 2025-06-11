/*
				   File: type_SdtSdtListaTags
			Description: SdtListaTags
				 Author: Nemo 🐠 for C# (.NET) version 18.0.12.186073
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SdtListaTags")]
	[XmlType(TypeName="SdtListaTags" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdtListaTags : GxUserType
	{
		public SdtSdtListaTags( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtListaTags_Clientenomefantasia = "";

			gxTv_SdtSdtListaTags_Clientecelular_f = "";

			gxTv_SdtSdtListaTags_Clientetelefone_f = "";

			gxTv_SdtSdtListaTags_Contatoemail = "";

			gxTv_SdtSdtListaTags_Enderecocomplemento = "";

			gxTv_SdtSdtListaTags_Endereconumero = "";

			gxTv_SdtSdtListaTags_Municipiouf = "";

			gxTv_SdtSdtListaTags_Municipionome = "";

			gxTv_SdtSdtListaTags_Enderecocidade = "";

			gxTv_SdtSdtListaTags_Enderecobairro = "";

			gxTv_SdtSdtListaTags_Enderecologradouro = "";

			gxTv_SdtSdtListaTags_Enderecocep = "";

			gxTv_SdtSdtListaTags_Enderecotipo = "";

			gxTv_SdtSdtListaTags_Secusername = "";

			gxTv_SdtSdtListaTags_Tipoclientedescricao = "";

			gxTv_SdtSdtListaTags_Clientetipopessoa = "";

			gxTv_SdtSdtListaTags_Clienterazaosocial = "";

			gxTv_SdtSdtListaTags_Clientedocumento = "";

			gxTv_SdtSdtListaTags_Conveniodescricao = "";

			gxTv_SdtSdtListaTags_Valorpropostaextenso = "";

			gxTv_SdtSdtListaTags_Valortaxaextenso = "";

			gxTv_SdtSdtListaTags_Empresabanconome = "";

			gxTv_SdtSdtListaTags_Responsavelnome = "";

			gxTv_SdtSdtListaTags_Responsavelprofissaonome = "";

			gxTv_SdtSdtListaTags_Responsavelnacionalidadenome = "";

			gxTv_SdtSdtListaTags_Responsavelestadocivil = "";

			gxTv_SdtSdtListaTags_Responsavelcpf = "";

			gxTv_SdtSdtListaTags_Responsavelcep = "";

			gxTv_SdtSdtListaTags_Responsavellogradouro = "";

			gxTv_SdtSdtListaTags_Responsavelbairro = "";

			gxTv_SdtSdtListaTags_Responsavelcidade = "";

			gxTv_SdtSdtListaTags_Responsavelmunicipio = "";

			gxTv_SdtSdtListaTags_Responsavelcomplemento = "";

			gxTv_SdtSdtListaTags_Responsavelmunicipiouf = "";

			gxTv_SdtSdtListaTags_Responsavelmunicipionome = "";

			gxTv_SdtSdtListaTags_Responsavelemail = "";

			gxTv_SdtSdtListaTags_Empresanomefantasia = "";

			gxTv_SdtSdtListaTags_Empresarazaosocial = "";

			gxTv_SdtSdtListaTags_Empresapix = "";

			gxTv_SdtSdtListaTags_Empresapixtipo = "";

			gxTv_SdtSdtListaTags_Empresaemail = "";

			gxTv_SdtSdtListaTags_Clienteprofissao = "";

			gxTv_SdtSdtListaTags_Clientenacionalidade = "";

			gxTv_SdtSdtListaTags_Clienteestadocivil = "";

			gxTv_SdtSdtListaTags_Conveniocategoriadescricao = "";

			gxTv_SdtSdtListaTags_Mesatualextenso = "";

			gxTv_SdtSdtListaTags_Clinicarazaosocial = "";

			gxTv_SdtSdtListaTags_Clinicaendereco = "";

			gxTv_SdtSdtListaTags_Clinicabairro = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantenome = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantecpf = "";

			gxTv_SdtSdtListaTags_Testemunhapadraonome1 = "";

			gxTv_SdtSdtListaTags_Testemunhapadraocpf1 = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantenacionalidade = "";

			gxTv_SdtSdtListaTags_Clinicarepresentanteestadocivil = "";

			gxTv_SdtSdtListaTags_Clinicarepresentanteprofissao = "";

			gxTv_SdtSdtListaTags_Clinicarepresentanteendereco = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantetelefone = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantecelular = "";

			gxTv_SdtSdtListaTags_Clinicarepresentanteemail = "";

			gxTv_SdtSdtListaTags_Clinicacnpj = "";

			gxTv_SdtSdtListaTags_Clientebanco = "";

			gxTv_SdtSdtListaTags_Clienteagencia = "";

			gxTv_SdtSdtListaTags_Clienteconta = "";

			gxTv_SdtSdtListaTags_Clientepix = "";

			gxTv_SdtSdtListaTags_Clinicabanco = "";

			gxTv_SdtSdtListaTags_Clinicaagencia = "";

			gxTv_SdtSdtListaTags_Clinicaconta = "";

			gxTv_SdtSdtListaTags_Clinicapix = "";

			gxTv_SdtSdtListaTags_Procedimentosmedicosdescricao = "";


		}

		public SdtSdtListaTags(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("ClienteNomeFantasia", gxTpr_Clientenomefantasia, false);


			AddObjectProperty("ClienteValorAReceber_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Clientevalorareceber_f, 18, 2)), false);


			AddObjectProperty("ClienteValorAPagar_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Clientevalorapagar_f, 18, 2)), false);


			AddObjectProperty("ClienteCelular_F", gxTpr_Clientecelular_f, false);


			AddObjectProperty("ClienteTelefone_F", gxTpr_Clientetelefone_f, false);


			AddObjectProperty("ContatoTelefoneDDI", gxTpr_Contatotelefoneddi, false);


			AddObjectProperty("ContatoTelefoneDDD", gxTpr_Contatotelefoneddd, false);


			AddObjectProperty("ContatoTelefoneNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatotelefonenumero, 18, 0)), false);


			AddObjectProperty("ContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatonumero, 18, 0)), false);


			AddObjectProperty("ContatoDDI", gxTpr_Contatoddi, false);


			AddObjectProperty("ContatoDDD", gxTpr_Contatoddd, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);


			AddObjectProperty("EnderecoComplemento", gxTpr_Enderecocomplemento, false);


			AddObjectProperty("EnderecoNumero", gxTpr_Endereconumero, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);


			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("EnderecoCidade", gxTpr_Enderecocidade, false);


			AddObjectProperty("EnderecoBairro", gxTpr_Enderecobairro, false);


			AddObjectProperty("EnderecoLogradouro", gxTpr_Enderecologradouro, false);


			AddObjectProperty("EnderecoCEP", gxTpr_Enderecocep, false);


			AddObjectProperty("EnderecoTipo", gxTpr_Enderecotipo, false);


			AddObjectProperty("SecUserName", gxTpr_Secusername, false);


			AddObjectProperty("TipoClienteDescricao", gxTpr_Tipoclientedescricao, false);


			AddObjectProperty("TipoClienteId", gxTpr_Tipoclienteid, false);


			AddObjectProperty("ClienteTipoPessoa", gxTpr_Clientetipopessoa, false);


			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("ClienteDocumento", gxTpr_Clientedocumento, false);


			AddObjectProperty("ClienteRg", gxTpr_Clienterg, false);


			AddObjectProperty("ConvenioDescricao", gxTpr_Conveniodescricao, false);


			AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostavalor, 18, 2)), false);


			AddObjectProperty("ValorPropostaExtenso", gxTpr_Valorpropostaextenso, false);


			AddObjectProperty("ValorTaxa", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valortaxa, 18, 2)), false);


			AddObjectProperty("ValorTaxaExtenso", gxTpr_Valortaxaextenso, false);


			AddObjectProperty("EmpresaBancoNome", gxTpr_Empresabanconome, false);


			AddObjectProperty("ResponsavelNome", gxTpr_Responsavelnome, false);


			AddObjectProperty("ResponsavelProfissaoNome", gxTpr_Responsavelprofissaonome, false);


			AddObjectProperty("ResponsavelNacionalidade", gxTpr_Responsavelnacionalidade, false);


			AddObjectProperty("ResponsavelNacionalidadeNome", gxTpr_Responsavelnacionalidadenome, false);


			AddObjectProperty("ResponsavelEstadoCivil", gxTpr_Responsavelestadocivil, false);


			AddObjectProperty("ResponsavelProfissao", gxTpr_Responsavelprofissao, false);


			AddObjectProperty("ResponsavelCPF", gxTpr_Responsavelcpf, false);


			AddObjectProperty("ResponsavelCEP", gxTpr_Responsavelcep, false);


			AddObjectProperty("ResponsavelLogradouro", gxTpr_Responsavellogradouro, false);


			AddObjectProperty("ResponsavelBairro", gxTpr_Responsavelbairro, false);


			AddObjectProperty("ResponsavelCidade", gxTpr_Responsavelcidade, false);


			AddObjectProperty("ResponsavelMunicipio", gxTpr_Responsavelmunicipio, false);


			AddObjectProperty("ResponsavelLogradouroNumero", gxTpr_Responsavellogradouronumero, false);


			AddObjectProperty("ResponsavelComplemento", gxTpr_Responsavelcomplemento, false);


			AddObjectProperty("ResponsavelDDD", gxTpr_Responsavelddd, false);


			AddObjectProperty("ResponsavelMunicipioUF", gxTpr_Responsavelmunicipiouf, false);


			AddObjectProperty("ResponsavelMunicipioNome", gxTpr_Responsavelmunicipionome, false);


			AddObjectProperty("ResponsavelNumero", gxTpr_Responsavelnumero, false);


			AddObjectProperty("ResponsavelEmail", gxTpr_Responsavelemail, false);


			AddObjectProperty("ContratoTaxa", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contratotaxa, 16, 4)), false);


			AddObjectProperty("ContratoSLA", gxTpr_Contratosla, false);


			AddObjectProperty("ContratoJurosMora", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contratojurosmora, 16, 4)), false);


			AddObjectProperty("ContratoIOFMinimo", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contratoiofminimo, 16, 4)), false);


			AddObjectProperty("EmpresaNomeFantasia", gxTpr_Empresanomefantasia, false);


			AddObjectProperty("EmpresaRazaoSocial", gxTpr_Empresarazaosocial, false);


			AddObjectProperty("EmpresaBancoId", gxTpr_Empresabancoid, false);


			AddObjectProperty("EmpresaAgencia", gxTpr_Empresaagencia, false);


			AddObjectProperty("EmpresaAgenciaDigito", gxTpr_Empresaagenciadigito, false);


			AddObjectProperty("EmpresaConta", gxTpr_Empresaconta, false);


			AddObjectProperty("EmpresaPix", gxTpr_Empresapix, false);


			AddObjectProperty("EmpresaPixTipo", gxTpr_Empresapixtipo, false);


			AddObjectProperty("EmpresaEmail", gxTpr_Empresaemail, false);


			AddObjectProperty("ClienteProfissao", gxTpr_Clienteprofissao, false);


			AddObjectProperty("ClienteNacionalidade", gxTpr_Clientenacionalidade, false);


			AddObjectProperty("ClienteEstadoCivil", gxTpr_Clienteestadocivil, false);


			AddObjectProperty("ConvenioCategoriaDescricao", gxTpr_Conveniocategoriadescricao, false);


			AddObjectProperty("ConvenioVencimentoAno", gxTpr_Conveniovencimentoano, false);


			AddObjectProperty("ConvenioVencimentoMes", gxTpr_Conveniovencimentomes, false);


			AddObjectProperty("AnoAtual", gxTpr_Anoatual, false);


			AddObjectProperty("MesAtualExtenso", gxTpr_Mesatualextenso, false);


			AddObjectProperty("DiaAtual", gxTpr_Diaatual, false);


			AddObjectProperty("ClinicaRazaoSocial", gxTpr_Clinicarazaosocial, false);


			AddObjectProperty("ClinicaEndereco", gxTpr_Clinicaendereco, false);


			AddObjectProperty("ClinicaBairro", gxTpr_Clinicabairro, false);


			AddObjectProperty("ClinicaRepresentanteNome", gxTpr_Clinicarepresentantenome, false);


			AddObjectProperty("ClinicaRepresentanteCPF", gxTpr_Clinicarepresentantecpf, false);


			AddObjectProperty("TestemunhaPadraoNome1", gxTpr_Testemunhapadraonome1, false);


			AddObjectProperty("TestemunhaPadraoCPF1", gxTpr_Testemunhapadraocpf1, false);


			AddObjectProperty("NumeroNotaEmprestimo", gxTpr_Numeronotaemprestimo, false);


			AddObjectProperty("ClinicaRepresentanteNacionalidade", gxTpr_Clinicarepresentantenacionalidade, false);


			AddObjectProperty("ClinicaRepresentanteEstadoCivil", gxTpr_Clinicarepresentanteestadocivil, false);


			AddObjectProperty("ClinicaRepresentanteProfissao", gxTpr_Clinicarepresentanteprofissao, false);


			AddObjectProperty("ClinicaRepresentanteRG", gxTpr_Clinicarepresentanterg, false);


			AddObjectProperty("ClinicaRepresentanteEndereco", gxTpr_Clinicarepresentanteendereco, false);


			AddObjectProperty("ClinicaRepresentanteTelefone", gxTpr_Clinicarepresentantetelefone, false);


			AddObjectProperty("ClinicaRepresentanteCelular", gxTpr_Clinicarepresentantecelular, false);


			AddObjectProperty("ClinicaRepresentanteEmail", gxTpr_Clinicarepresentanteemail, false);


			AddObjectProperty("ClinicaCNPJ", gxTpr_Clinicacnpj, false);


			AddObjectProperty("ClienteBanco", gxTpr_Clientebanco, false);


			AddObjectProperty("ClienteAgencia", gxTpr_Clienteagencia, false);


			AddObjectProperty("ClienteConta", gxTpr_Clienteconta, false);


			AddObjectProperty("ClientePIX", gxTpr_Clientepix, false);


			AddObjectProperty("ClinicaBanco", gxTpr_Clinicabanco, false);


			AddObjectProperty("ClinicaAgencia", gxTpr_Clinicaagencia, false);


			AddObjectProperty("ClinicaConta", gxTpr_Clinicaconta, false);


			AddObjectProperty("ClinicaPIX", gxTpr_Clinicapix, false);


			AddObjectProperty("ProcedimentosMedicosDescricao", gxTpr_Procedimentosmedicosdescricao, false);


			AddObjectProperty("ReembolsoValorReembolsado_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Reembolsovalorreembolsado_f, 18, 2)), false);


			AddObjectProperty("ReembolsoSaldoValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Reembolsosaldovalor, 18, 2)), false);


			AddObjectProperty("PropostaValorTaxaClinica_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostavalortaxaclinica_f, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteNomeFantasia")]
		[XmlElement(ElementName="ClienteNomeFantasia")]
		public string gxTpr_Clientenomefantasia
		{
			get {
				return gxTv_SdtSdtListaTags_Clientenomefantasia; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientenomefantasia = value;
				SetDirty("Clientenomefantasia");
			}
		}



		[SoapElement(ElementName="ClienteValorAReceber_F")]
		[XmlElement(ElementName="ClienteValorAReceber_F")]
		public string gxTpr_Clientevalorareceber_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Clientevalorareceber_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Clientevalorareceber_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Clientevalorareceber_f
		{
			get {
				return gxTv_SdtSdtListaTags_Clientevalorareceber_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientevalorareceber_f = value;
				SetDirty("Clientevalorareceber_f");
			}
		}



		[SoapElement(ElementName="ClienteValorAPagar_F")]
		[XmlElement(ElementName="ClienteValorAPagar_F")]
		public string gxTpr_Clientevalorapagar_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Clientevalorapagar_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Clientevalorapagar_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Clientevalorapagar_f
		{
			get {
				return gxTv_SdtSdtListaTags_Clientevalorapagar_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientevalorapagar_f = value;
				SetDirty("Clientevalorapagar_f");
			}
		}




		[SoapElement(ElementName="ClienteCelular_F")]
		[XmlElement(ElementName="ClienteCelular_F")]
		public string gxTpr_Clientecelular_f
		{
			get {
				return gxTv_SdtSdtListaTags_Clientecelular_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientecelular_f = value;
				SetDirty("Clientecelular_f");
			}
		}




		[SoapElement(ElementName="ClienteTelefone_F")]
		[XmlElement(ElementName="ClienteTelefone_F")]
		public string gxTpr_Clientetelefone_f
		{
			get {
				return gxTv_SdtSdtListaTags_Clientetelefone_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientetelefone_f = value;
				SetDirty("Clientetelefone_f");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneDDI")]
		[XmlElement(ElementName="ContatoTelefoneDDI")]
		public short gxTpr_Contatotelefoneddi
		{
			get {
				return gxTv_SdtSdtListaTags_Contatotelefoneddi; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatotelefoneddi = value;
				SetDirty("Contatotelefoneddi");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneDDD")]
		[XmlElement(ElementName="ContatoTelefoneDDD")]
		public short gxTpr_Contatotelefoneddd
		{
			get {
				return gxTv_SdtSdtListaTags_Contatotelefoneddd; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatotelefoneddd = value;
				SetDirty("Contatotelefoneddd");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneNumero")]
		[XmlElement(ElementName="ContatoTelefoneNumero")]
		public long gxTpr_Contatotelefonenumero
		{
			get {
				return gxTv_SdtSdtListaTags_Contatotelefonenumero; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatotelefonenumero = value;
				SetDirty("Contatotelefonenumero");
			}
		}




		[SoapElement(ElementName="ContatoNumero")]
		[XmlElement(ElementName="ContatoNumero")]
		public long gxTpr_Contatonumero
		{
			get {
				return gxTv_SdtSdtListaTags_Contatonumero; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatonumero = value;
				SetDirty("Contatonumero");
			}
		}




		[SoapElement(ElementName="ContatoDDI")]
		[XmlElement(ElementName="ContatoDDI")]
		public short gxTpr_Contatoddi
		{
			get {
				return gxTv_SdtSdtListaTags_Contatoddi; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatoddi = value;
				SetDirty("Contatoddi");
			}
		}




		[SoapElement(ElementName="ContatoDDD")]
		[XmlElement(ElementName="ContatoDDD")]
		public short gxTpr_Contatoddd
		{
			get {
				return gxTv_SdtSdtListaTags_Contatoddd; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatoddd = value;
				SetDirty("Contatoddd");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtSdtListaTags_Contatoemail; 
			}
			set {
				gxTv_SdtSdtListaTags_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="EnderecoComplemento")]
		[XmlElement(ElementName="EnderecoComplemento")]
		public string gxTpr_Enderecocomplemento
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecocomplemento; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecocomplemento = value;
				SetDirty("Enderecocomplemento");
			}
		}




		[SoapElement(ElementName="EnderecoNumero")]
		[XmlElement(ElementName="EnderecoNumero")]
		public string gxTpr_Endereconumero
		{
			get {
				return gxTv_SdtSdtListaTags_Endereconumero; 
			}
			set {
				gxTv_SdtSdtListaTags_Endereconumero = value;
				SetDirty("Endereconumero");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtSdtListaTags_Municipiouf; 
			}
			set {
				gxTv_SdtSdtListaTags_Municipiouf = value;
				SetDirty("Municipiouf");
			}
		}




		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtSdtListaTags_Municipionome; 
			}
			set {
				gxTv_SdtSdtListaTags_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="EnderecoCidade")]
		[XmlElement(ElementName="EnderecoCidade")]
		public string gxTpr_Enderecocidade
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecocidade; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecocidade = value;
				SetDirty("Enderecocidade");
			}
		}




		[SoapElement(ElementName="EnderecoBairro")]
		[XmlElement(ElementName="EnderecoBairro")]
		public string gxTpr_Enderecobairro
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecobairro; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecobairro = value;
				SetDirty("Enderecobairro");
			}
		}




		[SoapElement(ElementName="EnderecoLogradouro")]
		[XmlElement(ElementName="EnderecoLogradouro")]
		public string gxTpr_Enderecologradouro
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecologradouro; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecologradouro = value;
				SetDirty("Enderecologradouro");
			}
		}




		[SoapElement(ElementName="EnderecoCEP")]
		[XmlElement(ElementName="EnderecoCEP")]
		public string gxTpr_Enderecocep
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecocep; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecocep = value;
				SetDirty("Enderecocep");
			}
		}




		[SoapElement(ElementName="EnderecoTipo")]
		[XmlElement(ElementName="EnderecoTipo")]
		public string gxTpr_Enderecotipo
		{
			get {
				return gxTv_SdtSdtListaTags_Enderecotipo; 
			}
			set {
				gxTv_SdtSdtListaTags_Enderecotipo = value;
				SetDirty("Enderecotipo");
			}
		}




		[SoapElement(ElementName="SecUserName")]
		[XmlElement(ElementName="SecUserName")]
		public string gxTpr_Secusername
		{
			get {
				return gxTv_SdtSdtListaTags_Secusername; 
			}
			set {
				gxTv_SdtSdtListaTags_Secusername = value;
				SetDirty("Secusername");
			}
		}




		[SoapElement(ElementName="TipoClienteDescricao")]
		[XmlElement(ElementName="TipoClienteDescricao")]
		public string gxTpr_Tipoclientedescricao
		{
			get {
				return gxTv_SdtSdtListaTags_Tipoclientedescricao; 
			}
			set {
				gxTv_SdtSdtListaTags_Tipoclientedescricao = value;
				SetDirty("Tipoclientedescricao");
			}
		}




		[SoapElement(ElementName="TipoClienteId")]
		[XmlElement(ElementName="TipoClienteId")]
		public short gxTpr_Tipoclienteid
		{
			get {
				return gxTv_SdtSdtListaTags_Tipoclienteid; 
			}
			set {
				gxTv_SdtSdtListaTags_Tipoclienteid = value;
				SetDirty("Tipoclienteid");
			}
		}




		[SoapElement(ElementName="ClienteTipoPessoa")]
		[XmlElement(ElementName="ClienteTipoPessoa")]
		public string gxTpr_Clientetipopessoa
		{
			get {
				return gxTv_SdtSdtListaTags_Clientetipopessoa; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientetipopessoa = value;
				SetDirty("Clientetipopessoa");
			}
		}




		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtSdtListaTags_Clienterazaosocial; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtSdtListaTags_Clientedocumento; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientedocumento = value;
				SetDirty("Clientedocumento");
			}
		}




		[SoapElement(ElementName="ClienteRg")]
		[XmlElement(ElementName="ClienteRg")]
		public long gxTpr_Clienterg
		{
			get {
				return gxTv_SdtSdtListaTags_Clienterg; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienterg = value;
				SetDirty("Clienterg");
			}
		}




		[SoapElement(ElementName="ConvenioDescricao")]
		[XmlElement(ElementName="ConvenioDescricao")]
		public string gxTpr_Conveniodescricao
		{
			get {
				return gxTv_SdtSdtListaTags_Conveniodescricao; 
			}
			set {
				gxTv_SdtSdtListaTags_Conveniodescricao = value;
				SetDirty("Conveniodescricao");
			}
		}



		[SoapElement(ElementName="PropostaValor")]
		[XmlElement(ElementName="PropostaValor")]
		public string gxTpr_Propostavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Propostavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Propostavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalor
		{
			get {
				return gxTv_SdtSdtListaTags_Propostavalor; 
			}
			set {
				gxTv_SdtSdtListaTags_Propostavalor = value;
				SetDirty("Propostavalor");
			}
		}




		[SoapElement(ElementName="ValorPropostaExtenso")]
		[XmlElement(ElementName="ValorPropostaExtenso")]
		public string gxTpr_Valorpropostaextenso
		{
			get {
				return gxTv_SdtSdtListaTags_Valorpropostaextenso; 
			}
			set {
				gxTv_SdtSdtListaTags_Valorpropostaextenso = value;
				SetDirty("Valorpropostaextenso");
			}
		}



		[SoapElement(ElementName="ValorTaxa")]
		[XmlElement(ElementName="ValorTaxa")]
		public string gxTpr_Valortaxa_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Valortaxa, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Valortaxa = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortaxa
		{
			get {
				return gxTv_SdtSdtListaTags_Valortaxa; 
			}
			set {
				gxTv_SdtSdtListaTags_Valortaxa = value;
				SetDirty("Valortaxa");
			}
		}




		[SoapElement(ElementName="ValorTaxaExtenso")]
		[XmlElement(ElementName="ValorTaxaExtenso")]
		public string gxTpr_Valortaxaextenso
		{
			get {
				return gxTv_SdtSdtListaTags_Valortaxaextenso; 
			}
			set {
				gxTv_SdtSdtListaTags_Valortaxaextenso = value;
				SetDirty("Valortaxaextenso");
			}
		}




		[SoapElement(ElementName="EmpresaBancoNome")]
		[XmlElement(ElementName="EmpresaBancoNome")]
		public string gxTpr_Empresabanconome
		{
			get {
				return gxTv_SdtSdtListaTags_Empresabanconome; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresabanconome = value;
				SetDirty("Empresabanconome");
			}
		}




		[SoapElement(ElementName="ResponsavelNome")]
		[XmlElement(ElementName="ResponsavelNome")]
		public string gxTpr_Responsavelnome
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelnome; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelnome = value;
				SetDirty("Responsavelnome");
			}
		}




		[SoapElement(ElementName="ResponsavelProfissaoNome")]
		[XmlElement(ElementName="ResponsavelProfissaoNome")]
		public string gxTpr_Responsavelprofissaonome
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelprofissaonome; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelprofissaonome = value;
				SetDirty("Responsavelprofissaonome");
			}
		}




		[SoapElement(ElementName="ResponsavelNacionalidade")]
		[XmlElement(ElementName="ResponsavelNacionalidade")]
		public int gxTpr_Responsavelnacionalidade
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelnacionalidade; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelnacionalidade = value;
				SetDirty("Responsavelnacionalidade");
			}
		}




		[SoapElement(ElementName="ResponsavelNacionalidadeNome")]
		[XmlElement(ElementName="ResponsavelNacionalidadeNome")]
		public string gxTpr_Responsavelnacionalidadenome
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelnacionalidadenome; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelnacionalidadenome = value;
				SetDirty("Responsavelnacionalidadenome");
			}
		}




		[SoapElement(ElementName="ResponsavelEstadoCivil")]
		[XmlElement(ElementName="ResponsavelEstadoCivil")]
		public string gxTpr_Responsavelestadocivil
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelestadocivil; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelestadocivil = value;
				SetDirty("Responsavelestadocivil");
			}
		}




		[SoapElement(ElementName="ResponsavelProfissao")]
		[XmlElement(ElementName="ResponsavelProfissao")]
		public int gxTpr_Responsavelprofissao
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelprofissao; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelprofissao = value;
				SetDirty("Responsavelprofissao");
			}
		}




		[SoapElement(ElementName="ResponsavelCPF")]
		[XmlElement(ElementName="ResponsavelCPF")]
		public string gxTpr_Responsavelcpf
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelcpf; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelcpf = value;
				SetDirty("Responsavelcpf");
			}
		}




		[SoapElement(ElementName="ResponsavelCEP")]
		[XmlElement(ElementName="ResponsavelCEP")]
		public string gxTpr_Responsavelcep
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelcep; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelcep = value;
				SetDirty("Responsavelcep");
			}
		}




		[SoapElement(ElementName="ResponsavelLogradouro")]
		[XmlElement(ElementName="ResponsavelLogradouro")]
		public string gxTpr_Responsavellogradouro
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavellogradouro; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavellogradouro = value;
				SetDirty("Responsavellogradouro");
			}
		}




		[SoapElement(ElementName="ResponsavelBairro")]
		[XmlElement(ElementName="ResponsavelBairro")]
		public string gxTpr_Responsavelbairro
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelbairro; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelbairro = value;
				SetDirty("Responsavelbairro");
			}
		}




		[SoapElement(ElementName="ResponsavelCidade")]
		[XmlElement(ElementName="ResponsavelCidade")]
		public string gxTpr_Responsavelcidade
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelcidade; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelcidade = value;
				SetDirty("Responsavelcidade");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipio")]
		[XmlElement(ElementName="ResponsavelMunicipio")]
		public string gxTpr_Responsavelmunicipio
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelmunicipio; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelmunicipio = value;
				SetDirty("Responsavelmunicipio");
			}
		}




		[SoapElement(ElementName="ResponsavelLogradouroNumero")]
		[XmlElement(ElementName="ResponsavelLogradouroNumero")]
		public int gxTpr_Responsavellogradouronumero
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavellogradouronumero; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavellogradouronumero = value;
				SetDirty("Responsavellogradouronumero");
			}
		}




		[SoapElement(ElementName="ResponsavelComplemento")]
		[XmlElement(ElementName="ResponsavelComplemento")]
		public string gxTpr_Responsavelcomplemento
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelcomplemento; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelcomplemento = value;
				SetDirty("Responsavelcomplemento");
			}
		}




		[SoapElement(ElementName="ResponsavelDDD")]
		[XmlElement(ElementName="ResponsavelDDD")]
		public short gxTpr_Responsavelddd
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelddd; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelddd = value;
				SetDirty("Responsavelddd");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipioUF")]
		[XmlElement(ElementName="ResponsavelMunicipioUF")]
		public string gxTpr_Responsavelmunicipiouf
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelmunicipiouf; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelmunicipiouf = value;
				SetDirty("Responsavelmunicipiouf");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipioNome")]
		[XmlElement(ElementName="ResponsavelMunicipioNome")]
		public string gxTpr_Responsavelmunicipionome
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelmunicipionome; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelmunicipionome = value;
				SetDirty("Responsavelmunicipionome");
			}
		}




		[SoapElement(ElementName="ResponsavelNumero")]
		[XmlElement(ElementName="ResponsavelNumero")]
		public int gxTpr_Responsavelnumero
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelnumero; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelnumero = value;
				SetDirty("Responsavelnumero");
			}
		}




		[SoapElement(ElementName="ResponsavelEmail")]
		[XmlElement(ElementName="ResponsavelEmail")]
		public string gxTpr_Responsavelemail
		{
			get {
				return gxTv_SdtSdtListaTags_Responsavelemail; 
			}
			set {
				gxTv_SdtSdtListaTags_Responsavelemail = value;
				SetDirty("Responsavelemail");
			}
		}



		[SoapElement(ElementName="ContratoTaxa")]
		[XmlElement(ElementName="ContratoTaxa")]
		public string gxTpr_Contratotaxa_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Contratotaxa, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Contratotaxa = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Contratotaxa
		{
			get {
				return gxTv_SdtSdtListaTags_Contratotaxa; 
			}
			set {
				gxTv_SdtSdtListaTags_Contratotaxa = value;
				SetDirty("Contratotaxa");
			}
		}




		[SoapElement(ElementName="ContratoSLA")]
		[XmlElement(ElementName="ContratoSLA")]
		public short gxTpr_Contratosla
		{
			get {
				return gxTv_SdtSdtListaTags_Contratosla; 
			}
			set {
				gxTv_SdtSdtListaTags_Contratosla = value;
				SetDirty("Contratosla");
			}
		}



		[SoapElement(ElementName="ContratoJurosMora")]
		[XmlElement(ElementName="ContratoJurosMora")]
		public string gxTpr_Contratojurosmora_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Contratojurosmora, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Contratojurosmora = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Contratojurosmora
		{
			get {
				return gxTv_SdtSdtListaTags_Contratojurosmora; 
			}
			set {
				gxTv_SdtSdtListaTags_Contratojurosmora = value;
				SetDirty("Contratojurosmora");
			}
		}



		[SoapElement(ElementName="ContratoIOFMinimo")]
		[XmlElement(ElementName="ContratoIOFMinimo")]
		public string gxTpr_Contratoiofminimo_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Contratoiofminimo, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Contratoiofminimo = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Contratoiofminimo
		{
			get {
				return gxTv_SdtSdtListaTags_Contratoiofminimo; 
			}
			set {
				gxTv_SdtSdtListaTags_Contratoiofminimo = value;
				SetDirty("Contratoiofminimo");
			}
		}




		[SoapElement(ElementName="EmpresaNomeFantasia")]
		[XmlElement(ElementName="EmpresaNomeFantasia")]
		public string gxTpr_Empresanomefantasia
		{
			get {
				return gxTv_SdtSdtListaTags_Empresanomefantasia; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresanomefantasia = value;
				SetDirty("Empresanomefantasia");
			}
		}




		[SoapElement(ElementName="EmpresaRazaoSocial")]
		[XmlElement(ElementName="EmpresaRazaoSocial")]
		public string gxTpr_Empresarazaosocial
		{
			get {
				return gxTv_SdtSdtListaTags_Empresarazaosocial; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresarazaosocial = value;
				SetDirty("Empresarazaosocial");
			}
		}




		[SoapElement(ElementName="EmpresaBancoId")]
		[XmlElement(ElementName="EmpresaBancoId")]
		public int gxTpr_Empresabancoid
		{
			get {
				return gxTv_SdtSdtListaTags_Empresabancoid; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresabancoid = value;
				SetDirty("Empresabancoid");
			}
		}




		[SoapElement(ElementName="EmpresaAgencia")]
		[XmlElement(ElementName="EmpresaAgencia")]
		public int gxTpr_Empresaagencia
		{
			get {
				return gxTv_SdtSdtListaTags_Empresaagencia; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresaagencia = value;
				SetDirty("Empresaagencia");
			}
		}




		[SoapElement(ElementName="EmpresaAgenciaDigito")]
		[XmlElement(ElementName="EmpresaAgenciaDigito")]
		public int gxTpr_Empresaagenciadigito
		{
			get {
				return gxTv_SdtSdtListaTags_Empresaagenciadigito; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresaagenciadigito = value;
				SetDirty("Empresaagenciadigito");
			}
		}




		[SoapElement(ElementName="EmpresaConta")]
		[XmlElement(ElementName="EmpresaConta")]
		public int gxTpr_Empresaconta
		{
			get {
				return gxTv_SdtSdtListaTags_Empresaconta; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresaconta = value;
				SetDirty("Empresaconta");
			}
		}




		[SoapElement(ElementName="EmpresaPix")]
		[XmlElement(ElementName="EmpresaPix")]
		public string gxTpr_Empresapix
		{
			get {
				return gxTv_SdtSdtListaTags_Empresapix; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresapix = value;
				SetDirty("Empresapix");
			}
		}




		[SoapElement(ElementName="EmpresaPixTipo")]
		[XmlElement(ElementName="EmpresaPixTipo")]
		public string gxTpr_Empresapixtipo
		{
			get {
				return gxTv_SdtSdtListaTags_Empresapixtipo; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresapixtipo = value;
				SetDirty("Empresapixtipo");
			}
		}




		[SoapElement(ElementName="EmpresaEmail")]
		[XmlElement(ElementName="EmpresaEmail")]
		public string gxTpr_Empresaemail
		{
			get {
				return gxTv_SdtSdtListaTags_Empresaemail; 
			}
			set {
				gxTv_SdtSdtListaTags_Empresaemail = value;
				SetDirty("Empresaemail");
			}
		}




		[SoapElement(ElementName="ClienteProfissao")]
		[XmlElement(ElementName="ClienteProfissao")]
		public string gxTpr_Clienteprofissao
		{
			get {
				return gxTv_SdtSdtListaTags_Clienteprofissao; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienteprofissao = value;
				SetDirty("Clienteprofissao");
			}
		}




		[SoapElement(ElementName="ClienteNacionalidade")]
		[XmlElement(ElementName="ClienteNacionalidade")]
		public string gxTpr_Clientenacionalidade
		{
			get {
				return gxTv_SdtSdtListaTags_Clientenacionalidade; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientenacionalidade = value;
				SetDirty("Clientenacionalidade");
			}
		}




		[SoapElement(ElementName="ClienteEstadoCivil")]
		[XmlElement(ElementName="ClienteEstadoCivil")]
		public string gxTpr_Clienteestadocivil
		{
			get {
				return gxTv_SdtSdtListaTags_Clienteestadocivil; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienteestadocivil = value;
				SetDirty("Clienteestadocivil");
			}
		}




		[SoapElement(ElementName="ConvenioCategoriaDescricao")]
		[XmlElement(ElementName="ConvenioCategoriaDescricao")]
		public string gxTpr_Conveniocategoriadescricao
		{
			get {
				return gxTv_SdtSdtListaTags_Conveniocategoriadescricao; 
			}
			set {
				gxTv_SdtSdtListaTags_Conveniocategoriadescricao = value;
				SetDirty("Conveniocategoriadescricao");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoAno")]
		[XmlElement(ElementName="ConvenioVencimentoAno")]
		public short gxTpr_Conveniovencimentoano
		{
			get {
				return gxTv_SdtSdtListaTags_Conveniovencimentoano; 
			}
			set {
				gxTv_SdtSdtListaTags_Conveniovencimentoano = value;
				SetDirty("Conveniovencimentoano");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoMes")]
		[XmlElement(ElementName="ConvenioVencimentoMes")]
		public short gxTpr_Conveniovencimentomes
		{
			get {
				return gxTv_SdtSdtListaTags_Conveniovencimentomes; 
			}
			set {
				gxTv_SdtSdtListaTags_Conveniovencimentomes = value;
				SetDirty("Conveniovencimentomes");
			}
		}




		[SoapElement(ElementName="AnoAtual")]
		[XmlElement(ElementName="AnoAtual")]
		public short gxTpr_Anoatual
		{
			get {
				return gxTv_SdtSdtListaTags_Anoatual; 
			}
			set {
				gxTv_SdtSdtListaTags_Anoatual = value;
				SetDirty("Anoatual");
			}
		}




		[SoapElement(ElementName="MesAtualExtenso")]
		[XmlElement(ElementName="MesAtualExtenso")]
		public string gxTpr_Mesatualextenso
		{
			get {
				return gxTv_SdtSdtListaTags_Mesatualextenso; 
			}
			set {
				gxTv_SdtSdtListaTags_Mesatualextenso = value;
				SetDirty("Mesatualextenso");
			}
		}




		[SoapElement(ElementName="DiaAtual")]
		[XmlElement(ElementName="DiaAtual")]
		public short gxTpr_Diaatual
		{
			get {
				return gxTv_SdtSdtListaTags_Diaatual; 
			}
			set {
				gxTv_SdtSdtListaTags_Diaatual = value;
				SetDirty("Diaatual");
			}
		}




		[SoapElement(ElementName="ClinicaRazaoSocial")]
		[XmlElement(ElementName="ClinicaRazaoSocial")]
		public string gxTpr_Clinicarazaosocial
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarazaosocial; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarazaosocial = value;
				SetDirty("Clinicarazaosocial");
			}
		}




		[SoapElement(ElementName="ClinicaEndereco")]
		[XmlElement(ElementName="ClinicaEndereco")]
		public string gxTpr_Clinicaendereco
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicaendereco; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicaendereco = value;
				SetDirty("Clinicaendereco");
			}
		}




		[SoapElement(ElementName="ClinicaBairro")]
		[XmlElement(ElementName="ClinicaBairro")]
		public string gxTpr_Clinicabairro
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicabairro; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicabairro = value;
				SetDirty("Clinicabairro");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteNome")]
		[XmlElement(ElementName="ClinicaRepresentanteNome")]
		public string gxTpr_Clinicarepresentantenome
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentantenome; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentantenome = value;
				SetDirty("Clinicarepresentantenome");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteCPF")]
		[XmlElement(ElementName="ClinicaRepresentanteCPF")]
		public string gxTpr_Clinicarepresentantecpf
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentantecpf; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentantecpf = value;
				SetDirty("Clinicarepresentantecpf");
			}
		}




		[SoapElement(ElementName="TestemunhaPadraoNome1")]
		[XmlElement(ElementName="TestemunhaPadraoNome1")]
		public string gxTpr_Testemunhapadraonome1
		{
			get {
				return gxTv_SdtSdtListaTags_Testemunhapadraonome1; 
			}
			set {
				gxTv_SdtSdtListaTags_Testemunhapadraonome1 = value;
				SetDirty("Testemunhapadraonome1");
			}
		}




		[SoapElement(ElementName="TestemunhaPadraoCPF1")]
		[XmlElement(ElementName="TestemunhaPadraoCPF1")]
		public string gxTpr_Testemunhapadraocpf1
		{
			get {
				return gxTv_SdtSdtListaTags_Testemunhapadraocpf1; 
			}
			set {
				gxTv_SdtSdtListaTags_Testemunhapadraocpf1 = value;
				SetDirty("Testemunhapadraocpf1");
			}
		}




		[SoapElement(ElementName="NumeroNotaEmprestimo")]
		[XmlElement(ElementName="NumeroNotaEmprestimo")]
		public int gxTpr_Numeronotaemprestimo
		{
			get {
				return gxTv_SdtSdtListaTags_Numeronotaemprestimo; 
			}
			set {
				gxTv_SdtSdtListaTags_Numeronotaemprestimo = value;
				SetDirty("Numeronotaemprestimo");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteNacionalidade")]
		[XmlElement(ElementName="ClinicaRepresentanteNacionalidade")]
		public string gxTpr_Clinicarepresentantenacionalidade
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentantenacionalidade; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentantenacionalidade = value;
				SetDirty("Clinicarepresentantenacionalidade");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteEstadoCivil")]
		[XmlElement(ElementName="ClinicaRepresentanteEstadoCivil")]
		public string gxTpr_Clinicarepresentanteestadocivil
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentanteestadocivil; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentanteestadocivil = value;
				SetDirty("Clinicarepresentanteestadocivil");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteProfissao")]
		[XmlElement(ElementName="ClinicaRepresentanteProfissao")]
		public string gxTpr_Clinicarepresentanteprofissao
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentanteprofissao; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentanteprofissao = value;
				SetDirty("Clinicarepresentanteprofissao");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteRG")]
		[XmlElement(ElementName="ClinicaRepresentanteRG")]
		public long gxTpr_Clinicarepresentanterg
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentanterg; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentanterg = value;
				SetDirty("Clinicarepresentanterg");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteEndereco")]
		[XmlElement(ElementName="ClinicaRepresentanteEndereco")]
		public string gxTpr_Clinicarepresentanteendereco
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentanteendereco; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentanteendereco = value;
				SetDirty("Clinicarepresentanteendereco");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteTelefone")]
		[XmlElement(ElementName="ClinicaRepresentanteTelefone")]
		public string gxTpr_Clinicarepresentantetelefone
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentantetelefone; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentantetelefone = value;
				SetDirty("Clinicarepresentantetelefone");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteCelular")]
		[XmlElement(ElementName="ClinicaRepresentanteCelular")]
		public string gxTpr_Clinicarepresentantecelular
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentantecelular; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentantecelular = value;
				SetDirty("Clinicarepresentantecelular");
			}
		}




		[SoapElement(ElementName="ClinicaRepresentanteEmail")]
		[XmlElement(ElementName="ClinicaRepresentanteEmail")]
		public string gxTpr_Clinicarepresentanteemail
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicarepresentanteemail; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicarepresentanteemail = value;
				SetDirty("Clinicarepresentanteemail");
			}
		}




		[SoapElement(ElementName="ClinicaCNPJ")]
		[XmlElement(ElementName="ClinicaCNPJ")]
		public string gxTpr_Clinicacnpj
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicacnpj; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicacnpj = value;
				SetDirty("Clinicacnpj");
			}
		}




		[SoapElement(ElementName="ClienteBanco")]
		[XmlElement(ElementName="ClienteBanco")]
		public string gxTpr_Clientebanco
		{
			get {
				return gxTv_SdtSdtListaTags_Clientebanco; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientebanco = value;
				SetDirty("Clientebanco");
			}
		}




		[SoapElement(ElementName="ClienteAgencia")]
		[XmlElement(ElementName="ClienteAgencia")]
		public string gxTpr_Clienteagencia
		{
			get {
				return gxTv_SdtSdtListaTags_Clienteagencia; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienteagencia = value;
				SetDirty("Clienteagencia");
			}
		}




		[SoapElement(ElementName="ClienteConta")]
		[XmlElement(ElementName="ClienteConta")]
		public string gxTpr_Clienteconta
		{
			get {
				return gxTv_SdtSdtListaTags_Clienteconta; 
			}
			set {
				gxTv_SdtSdtListaTags_Clienteconta = value;
				SetDirty("Clienteconta");
			}
		}




		[SoapElement(ElementName="ClientePIX")]
		[XmlElement(ElementName="ClientePIX")]
		public string gxTpr_Clientepix
		{
			get {
				return gxTv_SdtSdtListaTags_Clientepix; 
			}
			set {
				gxTv_SdtSdtListaTags_Clientepix = value;
				SetDirty("Clientepix");
			}
		}




		[SoapElement(ElementName="ClinicaBanco")]
		[XmlElement(ElementName="ClinicaBanco")]
		public string gxTpr_Clinicabanco
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicabanco; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicabanco = value;
				SetDirty("Clinicabanco");
			}
		}




		[SoapElement(ElementName="ClinicaAgencia")]
		[XmlElement(ElementName="ClinicaAgencia")]
		public string gxTpr_Clinicaagencia
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicaagencia; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicaagencia = value;
				SetDirty("Clinicaagencia");
			}
		}




		[SoapElement(ElementName="ClinicaConta")]
		[XmlElement(ElementName="ClinicaConta")]
		public string gxTpr_Clinicaconta
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicaconta; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicaconta = value;
				SetDirty("Clinicaconta");
			}
		}




		[SoapElement(ElementName="ClinicaPIX")]
		[XmlElement(ElementName="ClinicaPIX")]
		public string gxTpr_Clinicapix
		{
			get {
				return gxTv_SdtSdtListaTags_Clinicapix; 
			}
			set {
				gxTv_SdtSdtListaTags_Clinicapix = value;
				SetDirty("Clinicapix");
			}
		}




		[SoapElement(ElementName="ProcedimentosMedicosDescricao")]
		[XmlElement(ElementName="ProcedimentosMedicosDescricao")]
		public string gxTpr_Procedimentosmedicosdescricao
		{
			get {
				return gxTv_SdtSdtListaTags_Procedimentosmedicosdescricao; 
			}
			set {
				gxTv_SdtSdtListaTags_Procedimentosmedicosdescricao = value;
				SetDirty("Procedimentosmedicosdescricao");
			}
		}



		[SoapElement(ElementName="ReembolsoValorReembolsado_F")]
		[XmlElement(ElementName="ReembolsoValorReembolsado_F")]
		public string gxTpr_Reembolsovalorreembolsado_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Reembolsovalorreembolsado_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Reembolsovalorreembolsado_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Reembolsovalorreembolsado_f
		{
			get {
				return gxTv_SdtSdtListaTags_Reembolsovalorreembolsado_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Reembolsovalorreembolsado_f = value;
				SetDirty("Reembolsovalorreembolsado_f");
			}
		}



		[SoapElement(ElementName="ReembolsoSaldoValor")]
		[XmlElement(ElementName="ReembolsoSaldoValor")]
		public string gxTpr_Reembolsosaldovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Reembolsosaldovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Reembolsosaldovalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Reembolsosaldovalor
		{
			get {
				return gxTv_SdtSdtListaTags_Reembolsosaldovalor; 
			}
			set {
				gxTv_SdtSdtListaTags_Reembolsosaldovalor = value;
				SetDirty("Reembolsosaldovalor");
			}
		}



		[SoapElement(ElementName="PropostaValorTaxaClinica_F")]
		[XmlElement(ElementName="PropostaValorTaxaClinica_F")]
		public string gxTpr_Propostavalortaxaclinica_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtListaTags_Propostavalortaxaclinica_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtListaTags_Propostavalortaxaclinica_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalortaxaclinica_f
		{
			get {
				return gxTv_SdtSdtListaTags_Propostavalortaxaclinica_f; 
			}
			set {
				gxTv_SdtSdtListaTags_Propostavalortaxaclinica_f = value;
				SetDirty("Propostavalortaxaclinica_f");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSdtListaTags_Clientenomefantasia = "";


			gxTv_SdtSdtListaTags_Clientecelular_f = "";
			gxTv_SdtSdtListaTags_Clientetelefone_f = "";






			gxTv_SdtSdtListaTags_Contatoemail = "";
			gxTv_SdtSdtListaTags_Enderecocomplemento = "";
			gxTv_SdtSdtListaTags_Endereconumero = "";
			gxTv_SdtSdtListaTags_Municipiouf = "";
			gxTv_SdtSdtListaTags_Municipionome = "";
			gxTv_SdtSdtListaTags_Enderecocidade = "";
			gxTv_SdtSdtListaTags_Enderecobairro = "";
			gxTv_SdtSdtListaTags_Enderecologradouro = "";
			gxTv_SdtSdtListaTags_Enderecocep = "";
			gxTv_SdtSdtListaTags_Enderecotipo = "";
			gxTv_SdtSdtListaTags_Secusername = "";
			gxTv_SdtSdtListaTags_Tipoclientedescricao = "";

			gxTv_SdtSdtListaTags_Clientetipopessoa = "";
			gxTv_SdtSdtListaTags_Clienterazaosocial = "";
			gxTv_SdtSdtListaTags_Clientedocumento = "";

			gxTv_SdtSdtListaTags_Conveniodescricao = "";

			gxTv_SdtSdtListaTags_Valorpropostaextenso = "";

			gxTv_SdtSdtListaTags_Valortaxaextenso = "";
			gxTv_SdtSdtListaTags_Empresabanconome = "";
			gxTv_SdtSdtListaTags_Responsavelnome = "";
			gxTv_SdtSdtListaTags_Responsavelprofissaonome = "";

			gxTv_SdtSdtListaTags_Responsavelnacionalidadenome = "";
			gxTv_SdtSdtListaTags_Responsavelestadocivil = "";

			gxTv_SdtSdtListaTags_Responsavelcpf = "";
			gxTv_SdtSdtListaTags_Responsavelcep = "";
			gxTv_SdtSdtListaTags_Responsavellogradouro = "";
			gxTv_SdtSdtListaTags_Responsavelbairro = "";
			gxTv_SdtSdtListaTags_Responsavelcidade = "";
			gxTv_SdtSdtListaTags_Responsavelmunicipio = "";

			gxTv_SdtSdtListaTags_Responsavelcomplemento = "";

			gxTv_SdtSdtListaTags_Responsavelmunicipiouf = "";
			gxTv_SdtSdtListaTags_Responsavelmunicipionome = "";

			gxTv_SdtSdtListaTags_Responsavelemail = "";




			gxTv_SdtSdtListaTags_Empresanomefantasia = "";
			gxTv_SdtSdtListaTags_Empresarazaosocial = "";




			gxTv_SdtSdtListaTags_Empresapix = "";
			gxTv_SdtSdtListaTags_Empresapixtipo = "";
			gxTv_SdtSdtListaTags_Empresaemail = "";
			gxTv_SdtSdtListaTags_Clienteprofissao = "";
			gxTv_SdtSdtListaTags_Clientenacionalidade = "";
			gxTv_SdtSdtListaTags_Clienteestadocivil = "";
			gxTv_SdtSdtListaTags_Conveniocategoriadescricao = "";



			gxTv_SdtSdtListaTags_Mesatualextenso = "";

			gxTv_SdtSdtListaTags_Clinicarazaosocial = "";
			gxTv_SdtSdtListaTags_Clinicaendereco = "";
			gxTv_SdtSdtListaTags_Clinicabairro = "";
			gxTv_SdtSdtListaTags_Clinicarepresentantenome = "";
			gxTv_SdtSdtListaTags_Clinicarepresentantecpf = "";
			gxTv_SdtSdtListaTags_Testemunhapadraonome1 = "";
			gxTv_SdtSdtListaTags_Testemunhapadraocpf1 = "";

			gxTv_SdtSdtListaTags_Clinicarepresentantenacionalidade = "";
			gxTv_SdtSdtListaTags_Clinicarepresentanteestadocivil = "";
			gxTv_SdtSdtListaTags_Clinicarepresentanteprofissao = "";

			gxTv_SdtSdtListaTags_Clinicarepresentanteendereco = "";
			gxTv_SdtSdtListaTags_Clinicarepresentantetelefone = "";
			gxTv_SdtSdtListaTags_Clinicarepresentantecelular = "";
			gxTv_SdtSdtListaTags_Clinicarepresentanteemail = "";
			gxTv_SdtSdtListaTags_Clinicacnpj = "";
			gxTv_SdtSdtListaTags_Clientebanco = "";
			gxTv_SdtSdtListaTags_Clienteagencia = "";
			gxTv_SdtSdtListaTags_Clienteconta = "";
			gxTv_SdtSdtListaTags_Clientepix = "";
			gxTv_SdtSdtListaTags_Clinicabanco = "";
			gxTv_SdtSdtListaTags_Clinicaagencia = "";
			gxTv_SdtSdtListaTags_Clinicaconta = "";
			gxTv_SdtSdtListaTags_Clinicapix = "";
			gxTv_SdtSdtListaTags_Procedimentosmedicosdescricao = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdtListaTags_Clientenomefantasia;
		 

		protected decimal gxTv_SdtSdtListaTags_Clientevalorareceber_f;
		 

		protected decimal gxTv_SdtSdtListaTags_Clientevalorapagar_f;
		 

		protected string gxTv_SdtSdtListaTags_Clientecelular_f;
		 

		protected string gxTv_SdtSdtListaTags_Clientetelefone_f;
		 

		protected short gxTv_SdtSdtListaTags_Contatotelefoneddi;
		 

		protected short gxTv_SdtSdtListaTags_Contatotelefoneddd;
		 

		protected long gxTv_SdtSdtListaTags_Contatotelefonenumero;
		 

		protected long gxTv_SdtSdtListaTags_Contatonumero;
		 

		protected short gxTv_SdtSdtListaTags_Contatoddi;
		 

		protected short gxTv_SdtSdtListaTags_Contatoddd;
		 

		protected string gxTv_SdtSdtListaTags_Contatoemail;
		 

		protected string gxTv_SdtSdtListaTags_Enderecocomplemento;
		 

		protected string gxTv_SdtSdtListaTags_Endereconumero;
		 

		protected string gxTv_SdtSdtListaTags_Municipiouf;
		 

		protected string gxTv_SdtSdtListaTags_Municipionome;
		 

		protected string gxTv_SdtSdtListaTags_Enderecocidade;
		 

		protected string gxTv_SdtSdtListaTags_Enderecobairro;
		 

		protected string gxTv_SdtSdtListaTags_Enderecologradouro;
		 

		protected string gxTv_SdtSdtListaTags_Enderecocep;
		 

		protected string gxTv_SdtSdtListaTags_Enderecotipo;
		 

		protected string gxTv_SdtSdtListaTags_Secusername;
		 

		protected string gxTv_SdtSdtListaTags_Tipoclientedescricao;
		 

		protected short gxTv_SdtSdtListaTags_Tipoclienteid;
		 

		protected string gxTv_SdtSdtListaTags_Clientetipopessoa;
		 

		protected string gxTv_SdtSdtListaTags_Clienterazaosocial;
		 

		protected string gxTv_SdtSdtListaTags_Clientedocumento;
		 

		protected long gxTv_SdtSdtListaTags_Clienterg;
		 

		protected string gxTv_SdtSdtListaTags_Conveniodescricao;
		 

		protected decimal gxTv_SdtSdtListaTags_Propostavalor;
		 

		protected string gxTv_SdtSdtListaTags_Valorpropostaextenso;
		 

		protected decimal gxTv_SdtSdtListaTags_Valortaxa;
		 

		protected string gxTv_SdtSdtListaTags_Valortaxaextenso;
		 

		protected string gxTv_SdtSdtListaTags_Empresabanconome;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelnome;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelprofissaonome;
		 

		protected int gxTv_SdtSdtListaTags_Responsavelnacionalidade;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelnacionalidadenome;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelestadocivil;
		 

		protected int gxTv_SdtSdtListaTags_Responsavelprofissao;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelcpf;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelcep;
		 

		protected string gxTv_SdtSdtListaTags_Responsavellogradouro;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelbairro;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelcidade;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelmunicipio;
		 

		protected int gxTv_SdtSdtListaTags_Responsavellogradouronumero;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelcomplemento;
		 

		protected short gxTv_SdtSdtListaTags_Responsavelddd;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelmunicipiouf;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelmunicipionome;
		 

		protected int gxTv_SdtSdtListaTags_Responsavelnumero;
		 

		protected string gxTv_SdtSdtListaTags_Responsavelemail;
		 

		protected decimal gxTv_SdtSdtListaTags_Contratotaxa;
		 

		protected short gxTv_SdtSdtListaTags_Contratosla;
		 

		protected decimal gxTv_SdtSdtListaTags_Contratojurosmora;
		 

		protected decimal gxTv_SdtSdtListaTags_Contratoiofminimo;
		 

		protected string gxTv_SdtSdtListaTags_Empresanomefantasia;
		 

		protected string gxTv_SdtSdtListaTags_Empresarazaosocial;
		 

		protected int gxTv_SdtSdtListaTags_Empresabancoid;
		 

		protected int gxTv_SdtSdtListaTags_Empresaagencia;
		 

		protected int gxTv_SdtSdtListaTags_Empresaagenciadigito;
		 

		protected int gxTv_SdtSdtListaTags_Empresaconta;
		 

		protected string gxTv_SdtSdtListaTags_Empresapix;
		 

		protected string gxTv_SdtSdtListaTags_Empresapixtipo;
		 

		protected string gxTv_SdtSdtListaTags_Empresaemail;
		 

		protected string gxTv_SdtSdtListaTags_Clienteprofissao;
		 

		protected string gxTv_SdtSdtListaTags_Clientenacionalidade;
		 

		protected string gxTv_SdtSdtListaTags_Clienteestadocivil;
		 

		protected string gxTv_SdtSdtListaTags_Conveniocategoriadescricao;
		 

		protected short gxTv_SdtSdtListaTags_Conveniovencimentoano;
		 

		protected short gxTv_SdtSdtListaTags_Conveniovencimentomes;
		 

		protected short gxTv_SdtSdtListaTags_Anoatual;
		 

		protected string gxTv_SdtSdtListaTags_Mesatualextenso;
		 

		protected short gxTv_SdtSdtListaTags_Diaatual;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarazaosocial;
		 

		protected string gxTv_SdtSdtListaTags_Clinicaendereco;
		 

		protected string gxTv_SdtSdtListaTags_Clinicabairro;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentantenome;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentantecpf;
		 

		protected string gxTv_SdtSdtListaTags_Testemunhapadraonome1;
		 

		protected string gxTv_SdtSdtListaTags_Testemunhapadraocpf1;
		 

		protected int gxTv_SdtSdtListaTags_Numeronotaemprestimo;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentantenacionalidade;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentanteestadocivil;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentanteprofissao;
		 

		protected long gxTv_SdtSdtListaTags_Clinicarepresentanterg;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentanteendereco;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentantetelefone;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentantecelular;
		 

		protected string gxTv_SdtSdtListaTags_Clinicarepresentanteemail;
		 

		protected string gxTv_SdtSdtListaTags_Clinicacnpj;
		 

		protected string gxTv_SdtSdtListaTags_Clientebanco;
		 

		protected string gxTv_SdtSdtListaTags_Clienteagencia;
		 

		protected string gxTv_SdtSdtListaTags_Clienteconta;
		 

		protected string gxTv_SdtSdtListaTags_Clientepix;
		 

		protected string gxTv_SdtSdtListaTags_Clinicabanco;
		 

		protected string gxTv_SdtSdtListaTags_Clinicaagencia;
		 

		protected string gxTv_SdtSdtListaTags_Clinicaconta;
		 

		protected string gxTv_SdtSdtListaTags_Clinicapix;
		 

		protected string gxTv_SdtSdtListaTags_Procedimentosmedicosdescricao;
		 

		protected decimal gxTv_SdtSdtListaTags_Reembolsovalorreembolsado_f;
		 

		protected decimal gxTv_SdtSdtListaTags_Reembolsosaldovalor;
		 

		protected decimal gxTv_SdtSdtListaTags_Propostavalortaxaclinica_f;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtListaTags", Namespace="Factory21")]
	public class SdtSdtListaTags_RESTInterface : GxGenericCollectionItem<SdtSdtListaTags>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtListaTags_RESTInterface( ) : base()
		{	
		}

		public SdtSdtListaTags_RESTInterface( SdtSdtListaTags psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteNomeFantasia")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ClienteNomeFantasia", Order=0)]
		public  string gxTpr_Clientenomefantasia
		{
			get { 
				return sdt.gxTpr_Clientenomefantasia;

			}
			set { 
				 sdt.gxTpr_Clientenomefantasia = value;
			}
		}

		[JsonPropertyName("ClienteValorAReceber_F")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClienteValorAReceber_F", Order=1)]
		public  string gxTpr_Clientevalorareceber_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Clientevalorareceber_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Clientevalorareceber_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteValorAPagar_F")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ClienteValorAPagar_F", Order=2)]
		public  string gxTpr_Clientevalorapagar_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Clientevalorapagar_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Clientevalorapagar_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteCelular_F")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ClienteCelular_F", Order=3)]
		public  string gxTpr_Clientecelular_f
		{
			get { 
				return sdt.gxTpr_Clientecelular_f;

			}
			set { 
				 sdt.gxTpr_Clientecelular_f = value;
			}
		}

		[JsonPropertyName("ClienteTelefone_F")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ClienteTelefone_F", Order=4)]
		public  string gxTpr_Clientetelefone_f
		{
			get { 
				return sdt.gxTpr_Clientetelefone_f;

			}
			set { 
				 sdt.gxTpr_Clientetelefone_f = value;
			}
		}

		[JsonPropertyName("ContatoTelefoneDDI")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ContatoTelefoneDDI", Order=5)]
		public short gxTpr_Contatotelefoneddi
		{
			get { 
				return sdt.gxTpr_Contatotelefoneddi;

			}
			set { 
				sdt.gxTpr_Contatotelefoneddi = value;
			}
		}

		[JsonPropertyName("ContatoTelefoneDDD")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ContatoTelefoneDDD", Order=6)]
		public short gxTpr_Contatotelefoneddd
		{
			get { 
				return sdt.gxTpr_Contatotelefoneddd;

			}
			set { 
				sdt.gxTpr_Contatotelefoneddd = value;
			}
		}

		[JsonPropertyName("ContatoTelefoneNumero")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ContatoTelefoneNumero", Order=7)]
		public  string gxTpr_Contatotelefonenumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatotelefonenumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatotelefonenumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContatoNumero")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="ContatoNumero", Order=8)]
		public  string gxTpr_Contatonumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatonumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatonumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContatoDDI")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ContatoDDI", Order=9)]
		public short gxTpr_Contatoddi
		{
			get { 
				return sdt.gxTpr_Contatoddi;

			}
			set { 
				sdt.gxTpr_Contatoddi = value;
			}
		}

		[JsonPropertyName("ContatoDDD")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="ContatoDDD", Order=10)]
		public short gxTpr_Contatoddd
		{
			get { 
				return sdt.gxTpr_Contatoddd;

			}
			set { 
				sdt.gxTpr_Contatoddd = value;
			}
		}

		[JsonPropertyName("ContatoEmail")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ContatoEmail", Order=11)]
		public  string gxTpr_Contatoemail
		{
			get { 
				return sdt.gxTpr_Contatoemail;

			}
			set { 
				 sdt.gxTpr_Contatoemail = value;
			}
		}

		[JsonPropertyName("EnderecoComplemento")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="EnderecoComplemento", Order=12)]
		public  string gxTpr_Enderecocomplemento
		{
			get { 
				return sdt.gxTpr_Enderecocomplemento;

			}
			set { 
				 sdt.gxTpr_Enderecocomplemento = value;
			}
		}

		[JsonPropertyName("EnderecoNumero")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="EnderecoNumero", Order=13)]
		public  string gxTpr_Endereconumero
		{
			get { 
				return sdt.gxTpr_Endereconumero;

			}
			set { 
				 sdt.gxTpr_Endereconumero = value;
			}
		}

		[JsonPropertyName("MunicipioUF")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="MunicipioUF", Order=14)]
		public  string gxTpr_Municipiouf
		{
			get { 
				return sdt.gxTpr_Municipiouf;

			}
			set { 
				 sdt.gxTpr_Municipiouf = value;
			}
		}

		[JsonPropertyName("MunicipioNome")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="MunicipioNome", Order=15)]
		public  string gxTpr_Municipionome
		{
			get { 
				return sdt.gxTpr_Municipionome;

			}
			set { 
				 sdt.gxTpr_Municipionome = value;
			}
		}

		[JsonPropertyName("EnderecoCidade")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="EnderecoCidade", Order=16)]
		public  string gxTpr_Enderecocidade
		{
			get { 
				return sdt.gxTpr_Enderecocidade;

			}
			set { 
				 sdt.gxTpr_Enderecocidade = value;
			}
		}

		[JsonPropertyName("EnderecoBairro")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="EnderecoBairro", Order=17)]
		public  string gxTpr_Enderecobairro
		{
			get { 
				return sdt.gxTpr_Enderecobairro;

			}
			set { 
				 sdt.gxTpr_Enderecobairro = value;
			}
		}

		[JsonPropertyName("EnderecoLogradouro")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="EnderecoLogradouro", Order=18)]
		public  string gxTpr_Enderecologradouro
		{
			get { 
				return sdt.gxTpr_Enderecologradouro;

			}
			set { 
				 sdt.gxTpr_Enderecologradouro = value;
			}
		}

		[JsonPropertyName("EnderecoCEP")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="EnderecoCEP", Order=19)]
		public  string gxTpr_Enderecocep
		{
			get { 
				return sdt.gxTpr_Enderecocep;

			}
			set { 
				 sdt.gxTpr_Enderecocep = value;
			}
		}

		[JsonPropertyName("EnderecoTipo")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="EnderecoTipo", Order=20)]
		public  string gxTpr_Enderecotipo
		{
			get { 
				return sdt.gxTpr_Enderecotipo;

			}
			set { 
				 sdt.gxTpr_Enderecotipo = value;
			}
		}

		[JsonPropertyName("SecUserName")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="SecUserName", Order=21)]
		public  string gxTpr_Secusername
		{
			get { 
				return sdt.gxTpr_Secusername;

			}
			set { 
				 sdt.gxTpr_Secusername = value;
			}
		}

		[JsonPropertyName("TipoClienteDescricao")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="TipoClienteDescricao", Order=22)]
		public  string gxTpr_Tipoclientedescricao
		{
			get { 
				return sdt.gxTpr_Tipoclientedescricao;

			}
			set { 
				 sdt.gxTpr_Tipoclientedescricao = value;
			}
		}

		[JsonPropertyName("TipoClienteId")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="TipoClienteId", Order=23)]
		public short gxTpr_Tipoclienteid
		{
			get { 
				return sdt.gxTpr_Tipoclienteid;

			}
			set { 
				sdt.gxTpr_Tipoclienteid = value;
			}
		}

		[JsonPropertyName("ClienteTipoPessoa")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="ClienteTipoPessoa", Order=24)]
		public  string gxTpr_Clientetipopessoa
		{
			get { 
				return sdt.gxTpr_Clientetipopessoa;

			}
			set { 
				 sdt.gxTpr_Clientetipopessoa = value;
			}
		}

		[JsonPropertyName("ClienteRazaoSocial")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="ClienteRazaoSocial", Order=25)]
		public  string gxTpr_Clienterazaosocial
		{
			get { 
				return sdt.gxTpr_Clienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Clienterazaosocial = value;
			}
		}

		[JsonPropertyName("ClienteDocumento")]
		[JsonPropertyOrder(26)]
		[DataMember(Name="ClienteDocumento", Order=26)]
		public  string gxTpr_Clientedocumento
		{
			get { 
				return sdt.gxTpr_Clientedocumento;

			}
			set { 
				 sdt.gxTpr_Clientedocumento = value;
			}
		}

		[JsonPropertyName("ClienteRg")]
		[JsonPropertyOrder(27)]
		[DataMember(Name="ClienteRg", Order=27)]
		public  string gxTpr_Clienterg
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienterg, 12, 0));

			}
			set { 
				sdt.gxTpr_Clienterg = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ConvenioDescricao")]
		[JsonPropertyOrder(28)]
		[DataMember(Name="ConvenioDescricao", Order=28)]
		public  string gxTpr_Conveniodescricao
		{
			get { 
				return sdt.gxTpr_Conveniodescricao;

			}
			set { 
				 sdt.gxTpr_Conveniodescricao = value;
			}
		}

		[JsonPropertyName("PropostaValor")]
		[JsonPropertyOrder(29)]
		[DataMember(Name="PropostaValor", Order=29)]
		public  string gxTpr_Propostavalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostavalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Propostavalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ValorPropostaExtenso")]
		[JsonPropertyOrder(30)]
		[DataMember(Name="ValorPropostaExtenso", Order=30)]
		public  string gxTpr_Valorpropostaextenso
		{
			get { 
				return sdt.gxTpr_Valorpropostaextenso;

			}
			set { 
				 sdt.gxTpr_Valorpropostaextenso = value;
			}
		}

		[JsonPropertyName("ValorTaxa")]
		[JsonPropertyOrder(31)]
		[DataMember(Name="ValorTaxa", Order=31)]
		public  string gxTpr_Valortaxa
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortaxa, 18, 2));

			}
			set { 
				sdt.gxTpr_Valortaxa =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ValorTaxaExtenso")]
		[JsonPropertyOrder(32)]
		[DataMember(Name="ValorTaxaExtenso", Order=32)]
		public  string gxTpr_Valortaxaextenso
		{
			get { 
				return sdt.gxTpr_Valortaxaextenso;

			}
			set { 
				 sdt.gxTpr_Valortaxaextenso = value;
			}
		}

		[JsonPropertyName("EmpresaBancoNome")]
		[JsonPropertyOrder(33)]
		[DataMember(Name="EmpresaBancoNome", Order=33)]
		public  string gxTpr_Empresabanconome
		{
			get { 
				return sdt.gxTpr_Empresabanconome;

			}
			set { 
				 sdt.gxTpr_Empresabanconome = value;
			}
		}

		[JsonPropertyName("ResponsavelNome")]
		[JsonPropertyOrder(34)]
		[DataMember(Name="ResponsavelNome", Order=34)]
		public  string gxTpr_Responsavelnome
		{
			get { 
				return sdt.gxTpr_Responsavelnome;

			}
			set { 
				 sdt.gxTpr_Responsavelnome = value;
			}
		}

		[JsonPropertyName("ResponsavelProfissaoNome")]
		[JsonPropertyOrder(35)]
		[DataMember(Name="ResponsavelProfissaoNome", Order=35)]
		public  string gxTpr_Responsavelprofissaonome
		{
			get { 
				return sdt.gxTpr_Responsavelprofissaonome;

			}
			set { 
				 sdt.gxTpr_Responsavelprofissaonome = value;
			}
		}

		[JsonPropertyName("ResponsavelNacionalidade")]
		[JsonPropertyOrder(36)]
		[DataMember(Name="ResponsavelNacionalidade", Order=36)]
		public  string gxTpr_Responsavelnacionalidade
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelnacionalidade, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelnacionalidade = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelNacionalidadeNome")]
		[JsonPropertyOrder(37)]
		[DataMember(Name="ResponsavelNacionalidadeNome", Order=37)]
		public  string gxTpr_Responsavelnacionalidadenome
		{
			get { 
				return sdt.gxTpr_Responsavelnacionalidadenome;

			}
			set { 
				 sdt.gxTpr_Responsavelnacionalidadenome = value;
			}
		}

		[JsonPropertyName("ResponsavelEstadoCivil")]
		[JsonPropertyOrder(38)]
		[DataMember(Name="ResponsavelEstadoCivil", Order=38)]
		public  string gxTpr_Responsavelestadocivil
		{
			get { 
				return sdt.gxTpr_Responsavelestadocivil;

			}
			set { 
				 sdt.gxTpr_Responsavelestadocivil = value;
			}
		}

		[JsonPropertyName("ResponsavelProfissao")]
		[JsonPropertyOrder(39)]
		[DataMember(Name="ResponsavelProfissao", Order=39)]
		public  string gxTpr_Responsavelprofissao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelprofissao, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelprofissao = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelCPF")]
		[JsonPropertyOrder(40)]
		[DataMember(Name="ResponsavelCPF", Order=40)]
		public  string gxTpr_Responsavelcpf
		{
			get { 
				return sdt.gxTpr_Responsavelcpf;

			}
			set { 
				 sdt.gxTpr_Responsavelcpf = value;
			}
		}

		[JsonPropertyName("ResponsavelCEP")]
		[JsonPropertyOrder(41)]
		[DataMember(Name="ResponsavelCEP", Order=41)]
		public  string gxTpr_Responsavelcep
		{
			get { 
				return sdt.gxTpr_Responsavelcep;

			}
			set { 
				 sdt.gxTpr_Responsavelcep = value;
			}
		}

		[JsonPropertyName("ResponsavelLogradouro")]
		[JsonPropertyOrder(42)]
		[DataMember(Name="ResponsavelLogradouro", Order=42)]
		public  string gxTpr_Responsavellogradouro
		{
			get { 
				return sdt.gxTpr_Responsavellogradouro;

			}
			set { 
				 sdt.gxTpr_Responsavellogradouro = value;
			}
		}

		[JsonPropertyName("ResponsavelBairro")]
		[JsonPropertyOrder(43)]
		[DataMember(Name="ResponsavelBairro", Order=43)]
		public  string gxTpr_Responsavelbairro
		{
			get { 
				return sdt.gxTpr_Responsavelbairro;

			}
			set { 
				 sdt.gxTpr_Responsavelbairro = value;
			}
		}

		[JsonPropertyName("ResponsavelCidade")]
		[JsonPropertyOrder(44)]
		[DataMember(Name="ResponsavelCidade", Order=44)]
		public  string gxTpr_Responsavelcidade
		{
			get { 
				return sdt.gxTpr_Responsavelcidade;

			}
			set { 
				 sdt.gxTpr_Responsavelcidade = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipio")]
		[JsonPropertyOrder(45)]
		[DataMember(Name="ResponsavelMunicipio", Order=45)]
		public  string gxTpr_Responsavelmunicipio
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipio;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipio = value;
			}
		}

		[JsonPropertyName("ResponsavelLogradouroNumero")]
		[JsonPropertyOrder(46)]
		[DataMember(Name="ResponsavelLogradouroNumero", Order=46)]
		public  string gxTpr_Responsavellogradouronumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavellogradouronumero, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavellogradouronumero = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelComplemento")]
		[JsonPropertyOrder(47)]
		[DataMember(Name="ResponsavelComplemento", Order=47)]
		public  string gxTpr_Responsavelcomplemento
		{
			get { 
				return sdt.gxTpr_Responsavelcomplemento;

			}
			set { 
				 sdt.gxTpr_Responsavelcomplemento = value;
			}
		}

		[JsonPropertyName("ResponsavelDDD")]
		[JsonPropertyOrder(48)]
		[DataMember(Name="ResponsavelDDD", Order=48)]
		public short gxTpr_Responsavelddd
		{
			get { 
				return sdt.gxTpr_Responsavelddd;

			}
			set { 
				sdt.gxTpr_Responsavelddd = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipioUF")]
		[JsonPropertyOrder(49)]
		[DataMember(Name="ResponsavelMunicipioUF", Order=49)]
		public  string gxTpr_Responsavelmunicipiouf
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipiouf;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipiouf = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipioNome")]
		[JsonPropertyOrder(50)]
		[DataMember(Name="ResponsavelMunicipioNome", Order=50)]
		public  string gxTpr_Responsavelmunicipionome
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipionome;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipionome = value;
			}
		}

		[JsonPropertyName("ResponsavelNumero")]
		[JsonPropertyOrder(51)]
		[DataMember(Name="ResponsavelNumero", Order=51)]
		public  string gxTpr_Responsavelnumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelnumero, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelnumero = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelEmail")]
		[JsonPropertyOrder(52)]
		[DataMember(Name="ResponsavelEmail", Order=52)]
		public  string gxTpr_Responsavelemail
		{
			get { 
				return sdt.gxTpr_Responsavelemail;

			}
			set { 
				 sdt.gxTpr_Responsavelemail = value;
			}
		}

		[JsonPropertyName("ContratoTaxa")]
		[JsonPropertyOrder(53)]
		[DataMember(Name="ContratoTaxa", Order=53)]
		public  string gxTpr_Contratotaxa
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Contratotaxa, 16, 4));

			}
			set { 
				sdt.gxTpr_Contratotaxa =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContratoSLA")]
		[JsonPropertyOrder(54)]
		[DataMember(Name="ContratoSLA", Order=54)]
		public short gxTpr_Contratosla
		{
			get { 
				return sdt.gxTpr_Contratosla;

			}
			set { 
				sdt.gxTpr_Contratosla = value;
			}
		}

		[JsonPropertyName("ContratoJurosMora")]
		[JsonPropertyOrder(55)]
		[DataMember(Name="ContratoJurosMora", Order=55)]
		public  string gxTpr_Contratojurosmora
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Contratojurosmora, 16, 4));

			}
			set { 
				sdt.gxTpr_Contratojurosmora =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContratoIOFMinimo")]
		[JsonPropertyOrder(56)]
		[DataMember(Name="ContratoIOFMinimo", Order=56)]
		public  string gxTpr_Contratoiofminimo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Contratoiofminimo, 16, 4));

			}
			set { 
				sdt.gxTpr_Contratoiofminimo =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaNomeFantasia")]
		[JsonPropertyOrder(57)]
		[DataMember(Name="EmpresaNomeFantasia", Order=57)]
		public  string gxTpr_Empresanomefantasia
		{
			get { 
				return sdt.gxTpr_Empresanomefantasia;

			}
			set { 
				 sdt.gxTpr_Empresanomefantasia = value;
			}
		}

		[JsonPropertyName("EmpresaRazaoSocial")]
		[JsonPropertyOrder(58)]
		[DataMember(Name="EmpresaRazaoSocial", Order=58)]
		public  string gxTpr_Empresarazaosocial
		{
			get { 
				return sdt.gxTpr_Empresarazaosocial;

			}
			set { 
				 sdt.gxTpr_Empresarazaosocial = value;
			}
		}

		[JsonPropertyName("EmpresaBancoId")]
		[JsonPropertyOrder(59)]
		[DataMember(Name="EmpresaBancoId", Order=59)]
		public  string gxTpr_Empresabancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresabancoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresabancoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaAgencia")]
		[JsonPropertyOrder(60)]
		[DataMember(Name="EmpresaAgencia", Order=60)]
		public  string gxTpr_Empresaagencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaagencia, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresaagencia = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaAgenciaDigito")]
		[JsonPropertyOrder(61)]
		[DataMember(Name="EmpresaAgenciaDigito", Order=61)]
		public  string gxTpr_Empresaagenciadigito
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaagenciadigito, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresaagenciadigito = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaConta")]
		[JsonPropertyOrder(62)]
		[DataMember(Name="EmpresaConta", Order=62)]
		public  string gxTpr_Empresaconta
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaconta, 8, 0));

			}
			set { 
				sdt.gxTpr_Empresaconta = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaPix")]
		[JsonPropertyOrder(63)]
		[DataMember(Name="EmpresaPix", Order=63)]
		public  string gxTpr_Empresapix
		{
			get { 
				return sdt.gxTpr_Empresapix;

			}
			set { 
				 sdt.gxTpr_Empresapix = value;
			}
		}

		[JsonPropertyName("EmpresaPixTipo")]
		[JsonPropertyOrder(64)]
		[DataMember(Name="EmpresaPixTipo", Order=64)]
		public  string gxTpr_Empresapixtipo
		{
			get { 
				return sdt.gxTpr_Empresapixtipo;

			}
			set { 
				 sdt.gxTpr_Empresapixtipo = value;
			}
		}

		[JsonPropertyName("EmpresaEmail")]
		[JsonPropertyOrder(65)]
		[DataMember(Name="EmpresaEmail", Order=65)]
		public  string gxTpr_Empresaemail
		{
			get { 
				return sdt.gxTpr_Empresaemail;

			}
			set { 
				 sdt.gxTpr_Empresaemail = value;
			}
		}

		[JsonPropertyName("ClienteProfissao")]
		[JsonPropertyOrder(66)]
		[DataMember(Name="ClienteProfissao", Order=66)]
		public  string gxTpr_Clienteprofissao
		{
			get { 
				return sdt.gxTpr_Clienteprofissao;

			}
			set { 
				 sdt.gxTpr_Clienteprofissao = value;
			}
		}

		[JsonPropertyName("ClienteNacionalidade")]
		[JsonPropertyOrder(67)]
		[DataMember(Name="ClienteNacionalidade", Order=67)]
		public  string gxTpr_Clientenacionalidade
		{
			get { 
				return sdt.gxTpr_Clientenacionalidade;

			}
			set { 
				 sdt.gxTpr_Clientenacionalidade = value;
			}
		}

		[JsonPropertyName("ClienteEstadoCivil")]
		[JsonPropertyOrder(68)]
		[DataMember(Name="ClienteEstadoCivil", Order=68)]
		public  string gxTpr_Clienteestadocivil
		{
			get { 
				return sdt.gxTpr_Clienteestadocivil;

			}
			set { 
				 sdt.gxTpr_Clienteestadocivil = value;
			}
		}

		[JsonPropertyName("ConvenioCategoriaDescricao")]
		[JsonPropertyOrder(69)]
		[DataMember(Name="ConvenioCategoriaDescricao", Order=69)]
		public  string gxTpr_Conveniocategoriadescricao
		{
			get { 
				return sdt.gxTpr_Conveniocategoriadescricao;

			}
			set { 
				 sdt.gxTpr_Conveniocategoriadescricao = value;
			}
		}

		[JsonPropertyName("ConvenioVencimentoAno")]
		[JsonPropertyOrder(70)]
		[DataMember(Name="ConvenioVencimentoAno", Order=70)]
		public short gxTpr_Conveniovencimentoano
		{
			get { 
				return sdt.gxTpr_Conveniovencimentoano;

			}
			set { 
				sdt.gxTpr_Conveniovencimentoano = value;
			}
		}

		[JsonPropertyName("ConvenioVencimentoMes")]
		[JsonPropertyOrder(71)]
		[DataMember(Name="ConvenioVencimentoMes", Order=71)]
		public short gxTpr_Conveniovencimentomes
		{
			get { 
				return sdt.gxTpr_Conveniovencimentomes;

			}
			set { 
				sdt.gxTpr_Conveniovencimentomes = value;
			}
		}

		[JsonPropertyName("AnoAtual")]
		[JsonPropertyOrder(72)]
		[DataMember(Name="AnoAtual", Order=72)]
		public short gxTpr_Anoatual
		{
			get { 
				return sdt.gxTpr_Anoatual;

			}
			set { 
				sdt.gxTpr_Anoatual = value;
			}
		}

		[JsonPropertyName("MesAtualExtenso")]
		[JsonPropertyOrder(73)]
		[DataMember(Name="MesAtualExtenso", Order=73)]
		public  string gxTpr_Mesatualextenso
		{
			get { 
				return sdt.gxTpr_Mesatualextenso;

			}
			set { 
				 sdt.gxTpr_Mesatualextenso = value;
			}
		}

		[JsonPropertyName("DiaAtual")]
		[JsonPropertyOrder(74)]
		[DataMember(Name="DiaAtual", Order=74)]
		public short gxTpr_Diaatual
		{
			get { 
				return sdt.gxTpr_Diaatual;

			}
			set { 
				sdt.gxTpr_Diaatual = value;
			}
		}

		[JsonPropertyName("ClinicaRazaoSocial")]
		[JsonPropertyOrder(75)]
		[DataMember(Name="ClinicaRazaoSocial", Order=75)]
		public  string gxTpr_Clinicarazaosocial
		{
			get { 
				return sdt.gxTpr_Clinicarazaosocial;

			}
			set { 
				 sdt.gxTpr_Clinicarazaosocial = value;
			}
		}

		[JsonPropertyName("ClinicaEndereco")]
		[JsonPropertyOrder(76)]
		[DataMember(Name="ClinicaEndereco", Order=76)]
		public  string gxTpr_Clinicaendereco
		{
			get { 
				return sdt.gxTpr_Clinicaendereco;

			}
			set { 
				 sdt.gxTpr_Clinicaendereco = value;
			}
		}

		[JsonPropertyName("ClinicaBairro")]
		[JsonPropertyOrder(77)]
		[DataMember(Name="ClinicaBairro", Order=77)]
		public  string gxTpr_Clinicabairro
		{
			get { 
				return sdt.gxTpr_Clinicabairro;

			}
			set { 
				 sdt.gxTpr_Clinicabairro = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteNome")]
		[JsonPropertyOrder(78)]
		[DataMember(Name="ClinicaRepresentanteNome", Order=78)]
		public  string gxTpr_Clinicarepresentantenome
		{
			get { 
				return sdt.gxTpr_Clinicarepresentantenome;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentantenome = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteCPF")]
		[JsonPropertyOrder(79)]
		[DataMember(Name="ClinicaRepresentanteCPF", Order=79)]
		public  string gxTpr_Clinicarepresentantecpf
		{
			get { 
				return sdt.gxTpr_Clinicarepresentantecpf;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentantecpf = value;
			}
		}

		[JsonPropertyName("TestemunhaPadraoNome1")]
		[JsonPropertyOrder(80)]
		[DataMember(Name="TestemunhaPadraoNome1", Order=80)]
		public  string gxTpr_Testemunhapadraonome1
		{
			get { 
				return sdt.gxTpr_Testemunhapadraonome1;

			}
			set { 
				 sdt.gxTpr_Testemunhapadraonome1 = value;
			}
		}

		[JsonPropertyName("TestemunhaPadraoCPF1")]
		[JsonPropertyOrder(81)]
		[DataMember(Name="TestemunhaPadraoCPF1", Order=81)]
		public  string gxTpr_Testemunhapadraocpf1
		{
			get { 
				return sdt.gxTpr_Testemunhapadraocpf1;

			}
			set { 
				 sdt.gxTpr_Testemunhapadraocpf1 = value;
			}
		}

		[JsonPropertyName("NumeroNotaEmprestimo")]
		[JsonPropertyOrder(82)]
		[DataMember(Name="NumeroNotaEmprestimo", Order=82)]
		public  string gxTpr_Numeronotaemprestimo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Numeronotaemprestimo, 9, 0));

			}
			set { 
				sdt.gxTpr_Numeronotaemprestimo = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClinicaRepresentanteNacionalidade")]
		[JsonPropertyOrder(83)]
		[DataMember(Name="ClinicaRepresentanteNacionalidade", Order=83)]
		public  string gxTpr_Clinicarepresentantenacionalidade
		{
			get { 
				return sdt.gxTpr_Clinicarepresentantenacionalidade;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentantenacionalidade = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteEstadoCivil")]
		[JsonPropertyOrder(84)]
		[DataMember(Name="ClinicaRepresentanteEstadoCivil", Order=84)]
		public  string gxTpr_Clinicarepresentanteestadocivil
		{
			get { 
				return sdt.gxTpr_Clinicarepresentanteestadocivil;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentanteestadocivil = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteProfissao")]
		[JsonPropertyOrder(85)]
		[DataMember(Name="ClinicaRepresentanteProfissao", Order=85)]
		public  string gxTpr_Clinicarepresentanteprofissao
		{
			get { 
				return sdt.gxTpr_Clinicarepresentanteprofissao;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentanteprofissao = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteRG")]
		[JsonPropertyOrder(86)]
		[DataMember(Name="ClinicaRepresentanteRG", Order=86)]
		public  string gxTpr_Clinicarepresentanterg
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clinicarepresentanterg, 12, 0));

			}
			set { 
				sdt.gxTpr_Clinicarepresentanterg = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClinicaRepresentanteEndereco")]
		[JsonPropertyOrder(87)]
		[DataMember(Name="ClinicaRepresentanteEndereco", Order=87)]
		public  string gxTpr_Clinicarepresentanteendereco
		{
			get { 
				return sdt.gxTpr_Clinicarepresentanteendereco;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentanteendereco = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteTelefone")]
		[JsonPropertyOrder(88)]
		[DataMember(Name="ClinicaRepresentanteTelefone", Order=88)]
		public  string gxTpr_Clinicarepresentantetelefone
		{
			get { 
				return sdt.gxTpr_Clinicarepresentantetelefone;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentantetelefone = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteCelular")]
		[JsonPropertyOrder(89)]
		[DataMember(Name="ClinicaRepresentanteCelular", Order=89)]
		public  string gxTpr_Clinicarepresentantecelular
		{
			get { 
				return sdt.gxTpr_Clinicarepresentantecelular;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentantecelular = value;
			}
		}

		[JsonPropertyName("ClinicaRepresentanteEmail")]
		[JsonPropertyOrder(90)]
		[DataMember(Name="ClinicaRepresentanteEmail", Order=90)]
		public  string gxTpr_Clinicarepresentanteemail
		{
			get { 
				return sdt.gxTpr_Clinicarepresentanteemail;

			}
			set { 
				 sdt.gxTpr_Clinicarepresentanteemail = value;
			}
		}

		[JsonPropertyName("ClinicaCNPJ")]
		[JsonPropertyOrder(91)]
		[DataMember(Name="ClinicaCNPJ", Order=91)]
		public  string gxTpr_Clinicacnpj
		{
			get { 
				return sdt.gxTpr_Clinicacnpj;

			}
			set { 
				 sdt.gxTpr_Clinicacnpj = value;
			}
		}

		[JsonPropertyName("ClienteBanco")]
		[JsonPropertyOrder(92)]
		[DataMember(Name="ClienteBanco", Order=92)]
		public  string gxTpr_Clientebanco
		{
			get { 
				return sdt.gxTpr_Clientebanco;

			}
			set { 
				 sdt.gxTpr_Clientebanco = value;
			}
		}

		[JsonPropertyName("ClienteAgencia")]
		[JsonPropertyOrder(93)]
		[DataMember(Name="ClienteAgencia", Order=93)]
		public  string gxTpr_Clienteagencia
		{
			get { 
				return sdt.gxTpr_Clienteagencia;

			}
			set { 
				 sdt.gxTpr_Clienteagencia = value;
			}
		}

		[JsonPropertyName("ClienteConta")]
		[JsonPropertyOrder(94)]
		[DataMember(Name="ClienteConta", Order=94)]
		public  string gxTpr_Clienteconta
		{
			get { 
				return sdt.gxTpr_Clienteconta;

			}
			set { 
				 sdt.gxTpr_Clienteconta = value;
			}
		}

		[JsonPropertyName("ClientePIX")]
		[JsonPropertyOrder(95)]
		[DataMember(Name="ClientePIX", Order=95)]
		public  string gxTpr_Clientepix
		{
			get { 
				return sdt.gxTpr_Clientepix;

			}
			set { 
				 sdt.gxTpr_Clientepix = value;
			}
		}

		[JsonPropertyName("ClinicaBanco")]
		[JsonPropertyOrder(96)]
		[DataMember(Name="ClinicaBanco", Order=96)]
		public  string gxTpr_Clinicabanco
		{
			get { 
				return sdt.gxTpr_Clinicabanco;

			}
			set { 
				 sdt.gxTpr_Clinicabanco = value;
			}
		}

		[JsonPropertyName("ClinicaAgencia")]
		[JsonPropertyOrder(97)]
		[DataMember(Name="ClinicaAgencia", Order=97)]
		public  string gxTpr_Clinicaagencia
		{
			get { 
				return sdt.gxTpr_Clinicaagencia;

			}
			set { 
				 sdt.gxTpr_Clinicaagencia = value;
			}
		}

		[JsonPropertyName("ClinicaConta")]
		[JsonPropertyOrder(98)]
		[DataMember(Name="ClinicaConta", Order=98)]
		public  string gxTpr_Clinicaconta
		{
			get { 
				return sdt.gxTpr_Clinicaconta;

			}
			set { 
				 sdt.gxTpr_Clinicaconta = value;
			}
		}

		[JsonPropertyName("ClinicaPIX")]
		[JsonPropertyOrder(99)]
		[DataMember(Name="ClinicaPIX", Order=99)]
		public  string gxTpr_Clinicapix
		{
			get { 
				return sdt.gxTpr_Clinicapix;

			}
			set { 
				 sdt.gxTpr_Clinicapix = value;
			}
		}

		[JsonPropertyName("ProcedimentosMedicosDescricao")]
		[JsonPropertyOrder(100)]
		[DataMember(Name="ProcedimentosMedicosDescricao", Order=100)]
		public  string gxTpr_Procedimentosmedicosdescricao
		{
			get { 
				return sdt.gxTpr_Procedimentosmedicosdescricao;

			}
			set { 
				 sdt.gxTpr_Procedimentosmedicosdescricao = value;
			}
		}

		[JsonPropertyName("ReembolsoValorReembolsado_F")]
		[JsonPropertyOrder(101)]
		[DataMember(Name="ReembolsoValorReembolsado_F", Order=101)]
		public  string gxTpr_Reembolsovalorreembolsado_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Reembolsovalorreembolsado_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Reembolsovalorreembolsado_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ReembolsoSaldoValor")]
		[JsonPropertyOrder(102)]
		[DataMember(Name="ReembolsoSaldoValor", Order=102)]
		public  string gxTpr_Reembolsosaldovalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Reembolsosaldovalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Reembolsosaldovalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaValorTaxaClinica_F")]
		[JsonPropertyOrder(103)]
		[DataMember(Name="PropostaValorTaxaClinica_F", Order=103)]
		public  string gxTpr_Propostavalortaxaclinica_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostavalortaxaclinica_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Propostavalortaxaclinica_f =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdtListaTags sdt
		{
			get { 
				return (SdtSdtListaTags)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSdtListaTags() ;
			}
		}
	}
	#endregion
}