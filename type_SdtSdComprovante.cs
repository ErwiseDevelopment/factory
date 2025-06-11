/*
				   File: type_SdtSdComprovante
			Description: SdComprovante
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
	[XmlRoot(ElementName="SdComprovante")]
	[XmlType(TypeName="SdComprovante" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdComprovante : GxUserType
	{
		public SdtSdComprovante( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdComprovante_Clientedocumento = "";

			gxTv_SdtSdComprovante_Clienterazaosocial = "";

			gxTv_SdtSdComprovante_Clientetipopessoa = "";

			gxTv_SdtSdComprovante_Clientetipoclientedescricao = "";

			gxTv_SdtSdComprovante_Clientenacionalidadenome = "";

			gxTv_SdtSdComprovante_Clienteestadocivil = "";

			gxTv_SdtSdComprovante_Clienteprofissaonome = "";

			gxTv_SdtSdComprovante_Clienteenderecocep = "";

			gxTv_SdtSdComprovante_Clienteenderecologradouro = "";

			gxTv_SdtSdComprovante_Clienteenderecobairro = "";

			gxTv_SdtSdComprovante_Clienteenderecocidade = "";

			gxTv_SdtSdComprovante_Clienteenderecomunicipionome = "";

			gxTv_SdtSdComprovante_Clienteenderecomunicipiouf = "";

			gxTv_SdtSdComprovante_Clienteendereconumero = "";

			gxTv_SdtSdComprovante_Clienteenderecocomplemento = "";

			gxTv_SdtSdComprovante_Contatoemail = "";

			gxTv_SdtSdComprovante_Responsaveldocumento = "";

			gxTv_SdtSdComprovante_Responsavelrazaosocial = "";

			gxTv_SdtSdComprovante_Responsaveltipopessoa = "";

			gxTv_SdtSdComprovante_Responsaveltipoclientedescricao = "";

			gxTv_SdtSdComprovante_Responsavelrg = "";

			gxTv_SdtSdComprovante_Responsavelnacionalidade = "";

			gxTv_SdtSdComprovante_Responsavelestadocivil = "";

			gxTv_SdtSdComprovante_Responsavelprofissao = "";

			gxTv_SdtSdComprovante_Responsavelcontatoemail = "";

			gxTv_SdtSdComprovante_Bancopixtipo = "";

			gxTv_SdtSdComprovante_Bancopixchave = "";

			gxTv_SdtSdComprovante_Banconome = "";

			gxTv_SdtSdComprovante_Bancoagencia = "";

			gxTv_SdtSdComprovante_Bancoconta = "";

			gxTv_SdtSdComprovante_Propostaprocedimentosmedicos = "";

			gxTv_SdtSdComprovante_Propostaconvenio = "";

			gxTv_SdtSdComprovante_Propostacategoriaconvenio = "";

			gxTv_SdtSdComprovante_Propostavencimentocarteirinha = "";

		}

		public SdtSdComprovante(IGxContext context)
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
			AddObjectProperty("ClienteDocumento", gxTpr_Clientedocumento, false);


			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("ClienteTipoPessoa", gxTpr_Clientetipopessoa, false);


			AddObjectProperty("ClienteTipoClienteDescricao", gxTpr_Clientetipoclientedescricao, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Clientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Clientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Clientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ClienteDataNascimento", sDateCnv, false);



			AddObjectProperty("ClienteRG", gxTpr_Clienterg, false);


			AddObjectProperty("ClienteNacionalidadeNome", gxTpr_Clientenacionalidadenome, false);


			AddObjectProperty("ClienteEstadoCivil", gxTpr_Clienteestadocivil, false);


			AddObjectProperty("ClienteProfissaoNome", gxTpr_Clienteprofissaonome, false);


			AddObjectProperty("ClienteEnderecoCEP", gxTpr_Clienteenderecocep, false);


			AddObjectProperty("ClienteEnderecoLogradouro", gxTpr_Clienteenderecologradouro, false);


			AddObjectProperty("ClienteEnderecoBairro", gxTpr_Clienteenderecobairro, false);


			AddObjectProperty("ClienteEnderecoCidade", gxTpr_Clienteenderecocidade, false);


			AddObjectProperty("ClienteEnderecoMunicipioNome", gxTpr_Clienteenderecomunicipionome, false);


			AddObjectProperty("ClienteEnderecoMunicipioUF", gxTpr_Clienteenderecomunicipiouf, false);


			AddObjectProperty("ClienteEnderecoNumero", gxTpr_Clienteendereconumero, false);


			AddObjectProperty("ClienteEnderecoComplemento", gxTpr_Clienteenderecocomplemento, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);


			AddObjectProperty("ContatoDDD", gxTpr_Contatoddd, false);


			AddObjectProperty("ContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatonumero, 18, 0)), false);


			AddObjectProperty("ResponsavelDocumento", gxTpr_Responsaveldocumento, false);


			AddObjectProperty("ResponsavelRazaoSocial", gxTpr_Responsavelrazaosocial, false);


			AddObjectProperty("ResponsavelTipoPessoa", gxTpr_Responsaveltipopessoa, false);


			AddObjectProperty("ResponsavelTipoClienteDescricao", gxTpr_Responsaveltipoclientedescricao, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Responsaveldatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Responsaveldatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Responsaveldatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ResponsavelDataNascimento", sDateCnv, false);



			AddObjectProperty("ResponsavelRG", gxTpr_Responsavelrg, false);


			AddObjectProperty("ResponsavelNacionalidade", gxTpr_Responsavelnacionalidade, false);


			AddObjectProperty("ResponsavelEstadoCivil", gxTpr_Responsavelestadocivil, false);


			AddObjectProperty("ResponsavelProfissao", gxTpr_Responsavelprofissao, false);


			AddObjectProperty("ResponsavelContatoEmail", gxTpr_Responsavelcontatoemail, false);


			AddObjectProperty("ResponsavelContatoDDD", gxTpr_Responsavelcontatoddd, false);


			AddObjectProperty("ResponsavelContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Responsavelcontatonumero, 18, 0)), false);


			AddObjectProperty("BancoPIXTipo", gxTpr_Bancopixtipo, false);


			AddObjectProperty("BancoPIXChave", gxTpr_Bancopixchave, false);


			AddObjectProperty("BancoNome", gxTpr_Banconome, false);


			AddObjectProperty("BancoAgencia", gxTpr_Bancoagencia, false);


			AddObjectProperty("BancoConta", gxTpr_Bancoconta, false);


			AddObjectProperty("PropostaProcedimentosMedicos", gxTpr_Propostaprocedimentosmedicos, false);


			AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostavalor, 18, 2)), false);


			AddObjectProperty("PropostaConvenio", gxTpr_Propostaconvenio, false);


			AddObjectProperty("PropostaCategoriaConvenio", gxTpr_Propostacategoriaconvenio, false);


			AddObjectProperty("PropostaVencimentoCarteirinha", gxTpr_Propostavencimentocarteirinha, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtSdComprovante_Clientedocumento; 
			}
			set {
				gxTv_SdtSdComprovante_Clientedocumento = value;
				SetDirty("Clientedocumento");
			}
		}




		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtSdComprovante_Clienterazaosocial; 
			}
			set {
				gxTv_SdtSdComprovante_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="ClienteTipoPessoa")]
		[XmlElement(ElementName="ClienteTipoPessoa")]
		public string gxTpr_Clientetipopessoa
		{
			get {
				return gxTv_SdtSdComprovante_Clientetipopessoa; 
			}
			set {
				gxTv_SdtSdComprovante_Clientetipopessoa = value;
				SetDirty("Clientetipopessoa");
			}
		}




		[SoapElement(ElementName="ClienteTipoClienteDescricao")]
		[XmlElement(ElementName="ClienteTipoClienteDescricao")]
		public string gxTpr_Clientetipoclientedescricao
		{
			get {
				return gxTv_SdtSdComprovante_Clientetipoclientedescricao; 
			}
			set {
				gxTv_SdtSdComprovante_Clientetipoclientedescricao = value;
				SetDirty("Clientetipoclientedescricao");
			}
		}



		[SoapElement(ElementName="ClienteDataNascimento")]
		[XmlElement(ElementName="ClienteDataNascimento" , IsNullable=true)]
		public string gxTpr_Clientedatanascimento_Nullable
		{
			get {
				if ( gxTv_SdtSdComprovante_Clientedatanascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdComprovante_Clientedatanascimento).value ;
			}
			set {
				gxTv_SdtSdComprovante_Clientedatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Clientedatanascimento
		{
			get {
				return gxTv_SdtSdComprovante_Clientedatanascimento; 
			}
			set {
				gxTv_SdtSdComprovante_Clientedatanascimento = value;
				SetDirty("Clientedatanascimento");
			}
		}



		[SoapElement(ElementName="ClienteRG")]
		[XmlElement(ElementName="ClienteRG")]
		public long gxTpr_Clienterg
		{
			get {
				return gxTv_SdtSdComprovante_Clienterg; 
			}
			set {
				gxTv_SdtSdComprovante_Clienterg = value;
				SetDirty("Clienterg");
			}
		}




		[SoapElement(ElementName="ClienteNacionalidadeNome")]
		[XmlElement(ElementName="ClienteNacionalidadeNome")]
		public string gxTpr_Clientenacionalidadenome
		{
			get {
				return gxTv_SdtSdComprovante_Clientenacionalidadenome; 
			}
			set {
				gxTv_SdtSdComprovante_Clientenacionalidadenome = value;
				SetDirty("Clientenacionalidadenome");
			}
		}




		[SoapElement(ElementName="ClienteEstadoCivil")]
		[XmlElement(ElementName="ClienteEstadoCivil")]
		public string gxTpr_Clienteestadocivil
		{
			get {
				return gxTv_SdtSdComprovante_Clienteestadocivil; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteestadocivil = value;
				SetDirty("Clienteestadocivil");
			}
		}




		[SoapElement(ElementName="ClienteProfissaoNome")]
		[XmlElement(ElementName="ClienteProfissaoNome")]
		public string gxTpr_Clienteprofissaonome
		{
			get {
				return gxTv_SdtSdComprovante_Clienteprofissaonome; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteprofissaonome = value;
				SetDirty("Clienteprofissaonome");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoCEP")]
		[XmlElement(ElementName="ClienteEnderecoCEP")]
		public string gxTpr_Clienteenderecocep
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecocep; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecocep = value;
				SetDirty("Clienteenderecocep");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoLogradouro")]
		[XmlElement(ElementName="ClienteEnderecoLogradouro")]
		public string gxTpr_Clienteenderecologradouro
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecologradouro; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecologradouro = value;
				SetDirty("Clienteenderecologradouro");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoBairro")]
		[XmlElement(ElementName="ClienteEnderecoBairro")]
		public string gxTpr_Clienteenderecobairro
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecobairro; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecobairro = value;
				SetDirty("Clienteenderecobairro");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoCidade")]
		[XmlElement(ElementName="ClienteEnderecoCidade")]
		public string gxTpr_Clienteenderecocidade
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecocidade; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecocidade = value;
				SetDirty("Clienteenderecocidade");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoMunicipioNome")]
		[XmlElement(ElementName="ClienteEnderecoMunicipioNome")]
		public string gxTpr_Clienteenderecomunicipionome
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecomunicipionome; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecomunicipionome = value;
				SetDirty("Clienteenderecomunicipionome");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoMunicipioUF")]
		[XmlElement(ElementName="ClienteEnderecoMunicipioUF")]
		public string gxTpr_Clienteenderecomunicipiouf
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecomunicipiouf; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecomunicipiouf = value;
				SetDirty("Clienteenderecomunicipiouf");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoNumero")]
		[XmlElement(ElementName="ClienteEnderecoNumero")]
		public string gxTpr_Clienteendereconumero
		{
			get {
				return gxTv_SdtSdComprovante_Clienteendereconumero; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteendereconumero = value;
				SetDirty("Clienteendereconumero");
			}
		}




		[SoapElement(ElementName="ClienteEnderecoComplemento")]
		[XmlElement(ElementName="ClienteEnderecoComplemento")]
		public string gxTpr_Clienteenderecocomplemento
		{
			get {
				return gxTv_SdtSdComprovante_Clienteenderecocomplemento; 
			}
			set {
				gxTv_SdtSdComprovante_Clienteenderecocomplemento = value;
				SetDirty("Clienteenderecocomplemento");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtSdComprovante_Contatoemail; 
			}
			set {
				gxTv_SdtSdComprovante_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="ContatoDDD")]
		[XmlElement(ElementName="ContatoDDD")]
		public short gxTpr_Contatoddd
		{
			get {
				return gxTv_SdtSdComprovante_Contatoddd; 
			}
			set {
				gxTv_SdtSdComprovante_Contatoddd = value;
				SetDirty("Contatoddd");
			}
		}




		[SoapElement(ElementName="ContatoNumero")]
		[XmlElement(ElementName="ContatoNumero")]
		public long gxTpr_Contatonumero
		{
			get {
				return gxTv_SdtSdComprovante_Contatonumero; 
			}
			set {
				gxTv_SdtSdComprovante_Contatonumero = value;
				SetDirty("Contatonumero");
			}
		}




		[SoapElement(ElementName="ResponsavelDocumento")]
		[XmlElement(ElementName="ResponsavelDocumento")]
		public string gxTpr_Responsaveldocumento
		{
			get {
				return gxTv_SdtSdComprovante_Responsaveldocumento; 
			}
			set {
				gxTv_SdtSdComprovante_Responsaveldocumento = value;
				SetDirty("Responsaveldocumento");
			}
		}




		[SoapElement(ElementName="ResponsavelRazaoSocial")]
		[XmlElement(ElementName="ResponsavelRazaoSocial")]
		public string gxTpr_Responsavelrazaosocial
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelrazaosocial; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelrazaosocial = value;
				SetDirty("Responsavelrazaosocial");
			}
		}




		[SoapElement(ElementName="ResponsavelTipoPessoa")]
		[XmlElement(ElementName="ResponsavelTipoPessoa")]
		public string gxTpr_Responsaveltipopessoa
		{
			get {
				return gxTv_SdtSdComprovante_Responsaveltipopessoa; 
			}
			set {
				gxTv_SdtSdComprovante_Responsaveltipopessoa = value;
				SetDirty("Responsaveltipopessoa");
			}
		}




		[SoapElement(ElementName="ResponsavelTipoClienteDescricao")]
		[XmlElement(ElementName="ResponsavelTipoClienteDescricao")]
		public string gxTpr_Responsaveltipoclientedescricao
		{
			get {
				return gxTv_SdtSdComprovante_Responsaveltipoclientedescricao; 
			}
			set {
				gxTv_SdtSdComprovante_Responsaveltipoclientedescricao = value;
				SetDirty("Responsaveltipoclientedescricao");
			}
		}



		[SoapElement(ElementName="ResponsavelDataNascimento")]
		[XmlElement(ElementName="ResponsavelDataNascimento" , IsNullable=true)]
		public string gxTpr_Responsaveldatanascimento_Nullable
		{
			get {
				if ( gxTv_SdtSdComprovante_Responsaveldatanascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdComprovante_Responsaveldatanascimento).value ;
			}
			set {
				gxTv_SdtSdComprovante_Responsaveldatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Responsaveldatanascimento
		{
			get {
				return gxTv_SdtSdComprovante_Responsaveldatanascimento; 
			}
			set {
				gxTv_SdtSdComprovante_Responsaveldatanascimento = value;
				SetDirty("Responsaveldatanascimento");
			}
		}



		[SoapElement(ElementName="ResponsavelRG")]
		[XmlElement(ElementName="ResponsavelRG")]
		public string gxTpr_Responsavelrg
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelrg; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelrg = value;
				SetDirty("Responsavelrg");
			}
		}




		[SoapElement(ElementName="ResponsavelNacionalidade")]
		[XmlElement(ElementName="ResponsavelNacionalidade")]
		public string gxTpr_Responsavelnacionalidade
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelnacionalidade; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelnacionalidade = value;
				SetDirty("Responsavelnacionalidade");
			}
		}




		[SoapElement(ElementName="ResponsavelEstadoCivil")]
		[XmlElement(ElementName="ResponsavelEstadoCivil")]
		public string gxTpr_Responsavelestadocivil
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelestadocivil; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelestadocivil = value;
				SetDirty("Responsavelestadocivil");
			}
		}




		[SoapElement(ElementName="ResponsavelProfissao")]
		[XmlElement(ElementName="ResponsavelProfissao")]
		public string gxTpr_Responsavelprofissao
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelprofissao; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelprofissao = value;
				SetDirty("Responsavelprofissao");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoEmail")]
		[XmlElement(ElementName="ResponsavelContatoEmail")]
		public string gxTpr_Responsavelcontatoemail
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelcontatoemail; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelcontatoemail = value;
				SetDirty("Responsavelcontatoemail");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoDDD")]
		[XmlElement(ElementName="ResponsavelContatoDDD")]
		public short gxTpr_Responsavelcontatoddd
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelcontatoddd; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelcontatoddd = value;
				SetDirty("Responsavelcontatoddd");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoNumero")]
		[XmlElement(ElementName="ResponsavelContatoNumero")]
		public long gxTpr_Responsavelcontatonumero
		{
			get {
				return gxTv_SdtSdComprovante_Responsavelcontatonumero; 
			}
			set {
				gxTv_SdtSdComprovante_Responsavelcontatonumero = value;
				SetDirty("Responsavelcontatonumero");
			}
		}




		[SoapElement(ElementName="BancoPIXTipo")]
		[XmlElement(ElementName="BancoPIXTipo")]
		public string gxTpr_Bancopixtipo
		{
			get {
				return gxTv_SdtSdComprovante_Bancopixtipo; 
			}
			set {
				gxTv_SdtSdComprovante_Bancopixtipo = value;
				SetDirty("Bancopixtipo");
			}
		}




		[SoapElement(ElementName="BancoPIXChave")]
		[XmlElement(ElementName="BancoPIXChave")]
		public string gxTpr_Bancopixchave
		{
			get {
				return gxTv_SdtSdComprovante_Bancopixchave; 
			}
			set {
				gxTv_SdtSdComprovante_Bancopixchave = value;
				SetDirty("Bancopixchave");
			}
		}




		[SoapElement(ElementName="BancoNome")]
		[XmlElement(ElementName="BancoNome")]
		public string gxTpr_Banconome
		{
			get {
				return gxTv_SdtSdComprovante_Banconome; 
			}
			set {
				gxTv_SdtSdComprovante_Banconome = value;
				SetDirty("Banconome");
			}
		}




		[SoapElement(ElementName="BancoAgencia")]
		[XmlElement(ElementName="BancoAgencia")]
		public string gxTpr_Bancoagencia
		{
			get {
				return gxTv_SdtSdComprovante_Bancoagencia; 
			}
			set {
				gxTv_SdtSdComprovante_Bancoagencia = value;
				SetDirty("Bancoagencia");
			}
		}




		[SoapElement(ElementName="BancoConta")]
		[XmlElement(ElementName="BancoConta")]
		public string gxTpr_Bancoconta
		{
			get {
				return gxTv_SdtSdComprovante_Bancoconta; 
			}
			set {
				gxTv_SdtSdComprovante_Bancoconta = value;
				SetDirty("Bancoconta");
			}
		}




		[SoapElement(ElementName="PropostaProcedimentosMedicos")]
		[XmlElement(ElementName="PropostaProcedimentosMedicos")]
		public string gxTpr_Propostaprocedimentosmedicos
		{
			get {
				return gxTv_SdtSdComprovante_Propostaprocedimentosmedicos; 
			}
			set {
				gxTv_SdtSdComprovante_Propostaprocedimentosmedicos = value;
				SetDirty("Propostaprocedimentosmedicos");
			}
		}



		[SoapElement(ElementName="PropostaValor")]
		[XmlElement(ElementName="PropostaValor")]
		public string gxTpr_Propostavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdComprovante_Propostavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdComprovante_Propostavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalor
		{
			get {
				return gxTv_SdtSdComprovante_Propostavalor; 
			}
			set {
				gxTv_SdtSdComprovante_Propostavalor = value;
				SetDirty("Propostavalor");
			}
		}




		[SoapElement(ElementName="PropostaConvenio")]
		[XmlElement(ElementName="PropostaConvenio")]
		public string gxTpr_Propostaconvenio
		{
			get {
				return gxTv_SdtSdComprovante_Propostaconvenio; 
			}
			set {
				gxTv_SdtSdComprovante_Propostaconvenio = value;
				SetDirty("Propostaconvenio");
			}
		}




		[SoapElement(ElementName="PropostaCategoriaConvenio")]
		[XmlElement(ElementName="PropostaCategoriaConvenio")]
		public string gxTpr_Propostacategoriaconvenio
		{
			get {
				return gxTv_SdtSdComprovante_Propostacategoriaconvenio; 
			}
			set {
				gxTv_SdtSdComprovante_Propostacategoriaconvenio = value;
				SetDirty("Propostacategoriaconvenio");
			}
		}




		[SoapElement(ElementName="PropostaVencimentoCarteirinha")]
		[XmlElement(ElementName="PropostaVencimentoCarteirinha")]
		public string gxTpr_Propostavencimentocarteirinha
		{
			get {
				return gxTv_SdtSdComprovante_Propostavencimentocarteirinha; 
			}
			set {
				gxTv_SdtSdComprovante_Propostavencimentocarteirinha = value;
				SetDirty("Propostavencimentocarteirinha");
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
			gxTv_SdtSdComprovante_Clientedocumento = "";
			gxTv_SdtSdComprovante_Clienterazaosocial = "";
			gxTv_SdtSdComprovante_Clientetipopessoa = "";
			gxTv_SdtSdComprovante_Clientetipoclientedescricao = "";


			gxTv_SdtSdComprovante_Clientenacionalidadenome = "";
			gxTv_SdtSdComprovante_Clienteestadocivil = "";
			gxTv_SdtSdComprovante_Clienteprofissaonome = "";
			gxTv_SdtSdComprovante_Clienteenderecocep = "";
			gxTv_SdtSdComprovante_Clienteenderecologradouro = "";
			gxTv_SdtSdComprovante_Clienteenderecobairro = "";
			gxTv_SdtSdComprovante_Clienteenderecocidade = "";
			gxTv_SdtSdComprovante_Clienteenderecomunicipionome = "";
			gxTv_SdtSdComprovante_Clienteenderecomunicipiouf = "";
			gxTv_SdtSdComprovante_Clienteendereconumero = "";
			gxTv_SdtSdComprovante_Clienteenderecocomplemento = "";
			gxTv_SdtSdComprovante_Contatoemail = "";


			gxTv_SdtSdComprovante_Responsaveldocumento = "";
			gxTv_SdtSdComprovante_Responsavelrazaosocial = "";
			gxTv_SdtSdComprovante_Responsaveltipopessoa = "";
			gxTv_SdtSdComprovante_Responsaveltipoclientedescricao = "";

			gxTv_SdtSdComprovante_Responsavelrg = "";
			gxTv_SdtSdComprovante_Responsavelnacionalidade = "";
			gxTv_SdtSdComprovante_Responsavelestadocivil = "";
			gxTv_SdtSdComprovante_Responsavelprofissao = "";
			gxTv_SdtSdComprovante_Responsavelcontatoemail = "";


			gxTv_SdtSdComprovante_Bancopixtipo = "";
			gxTv_SdtSdComprovante_Bancopixchave = "";
			gxTv_SdtSdComprovante_Banconome = "";
			gxTv_SdtSdComprovante_Bancoagencia = "";
			gxTv_SdtSdComprovante_Bancoconta = "";
			gxTv_SdtSdComprovante_Propostaprocedimentosmedicos = "";

			gxTv_SdtSdComprovante_Propostaconvenio = "";
			gxTv_SdtSdComprovante_Propostacategoriaconvenio = "";
			gxTv_SdtSdComprovante_Propostavencimentocarteirinha = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdComprovante_Clientedocumento;
		 

		protected string gxTv_SdtSdComprovante_Clienterazaosocial;
		 

		protected string gxTv_SdtSdComprovante_Clientetipopessoa;
		 

		protected string gxTv_SdtSdComprovante_Clientetipoclientedescricao;
		 

		protected DateTime gxTv_SdtSdComprovante_Clientedatanascimento;
		 

		protected long gxTv_SdtSdComprovante_Clienterg;
		 

		protected string gxTv_SdtSdComprovante_Clientenacionalidadenome;
		 

		protected string gxTv_SdtSdComprovante_Clienteestadocivil;
		 

		protected string gxTv_SdtSdComprovante_Clienteprofissaonome;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecocep;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecologradouro;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecobairro;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecocidade;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecomunicipionome;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecomunicipiouf;
		 

		protected string gxTv_SdtSdComprovante_Clienteendereconumero;
		 

		protected string gxTv_SdtSdComprovante_Clienteenderecocomplemento;
		 

		protected string gxTv_SdtSdComprovante_Contatoemail;
		 

		protected short gxTv_SdtSdComprovante_Contatoddd;
		 

		protected long gxTv_SdtSdComprovante_Contatonumero;
		 

		protected string gxTv_SdtSdComprovante_Responsaveldocumento;
		 

		protected string gxTv_SdtSdComprovante_Responsavelrazaosocial;
		 

		protected string gxTv_SdtSdComprovante_Responsaveltipopessoa;
		 

		protected string gxTv_SdtSdComprovante_Responsaveltipoclientedescricao;
		 

		protected DateTime gxTv_SdtSdComprovante_Responsaveldatanascimento;
		 

		protected string gxTv_SdtSdComprovante_Responsavelrg;
		 

		protected string gxTv_SdtSdComprovante_Responsavelnacionalidade;
		 

		protected string gxTv_SdtSdComprovante_Responsavelestadocivil;
		 

		protected string gxTv_SdtSdComprovante_Responsavelprofissao;
		 

		protected string gxTv_SdtSdComprovante_Responsavelcontatoemail;
		 

		protected short gxTv_SdtSdComprovante_Responsavelcontatoddd;
		 

		protected long gxTv_SdtSdComprovante_Responsavelcontatonumero;
		 

		protected string gxTv_SdtSdComprovante_Bancopixtipo;
		 

		protected string gxTv_SdtSdComprovante_Bancopixchave;
		 

		protected string gxTv_SdtSdComprovante_Banconome;
		 

		protected string gxTv_SdtSdComprovante_Bancoagencia;
		 

		protected string gxTv_SdtSdComprovante_Bancoconta;
		 

		protected string gxTv_SdtSdComprovante_Propostaprocedimentosmedicos;
		 

		protected decimal gxTv_SdtSdComprovante_Propostavalor;
		 

		protected string gxTv_SdtSdComprovante_Propostaconvenio;
		 

		protected string gxTv_SdtSdComprovante_Propostacategoriaconvenio;
		 

		protected string gxTv_SdtSdComprovante_Propostavencimentocarteirinha;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdComprovante", Namespace="Factory21")]
	public class SdtSdComprovante_RESTInterface : GxGenericCollectionItem<SdtSdComprovante>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdComprovante_RESTInterface( ) : base()
		{	
		}

		public SdtSdComprovante_RESTInterface( SdtSdComprovante psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteDocumento")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ClienteDocumento", Order=0)]
		public  string gxTpr_Clientedocumento
		{
			get { 
				return sdt.gxTpr_Clientedocumento;

			}
			set { 
				 sdt.gxTpr_Clientedocumento = value;
			}
		}

		[JsonPropertyName("ClienteRazaoSocial")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClienteRazaoSocial", Order=1)]
		public  string gxTpr_Clienterazaosocial
		{
			get { 
				return sdt.gxTpr_Clienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Clienterazaosocial = value;
			}
		}

		[JsonPropertyName("ClienteTipoPessoa")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ClienteTipoPessoa", Order=2)]
		public  string gxTpr_Clientetipopessoa
		{
			get { 
				return sdt.gxTpr_Clientetipopessoa;

			}
			set { 
				 sdt.gxTpr_Clientetipopessoa = value;
			}
		}

		[JsonPropertyName("ClienteTipoClienteDescricao")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ClienteTipoClienteDescricao", Order=3)]
		public  string gxTpr_Clientetipoclientedescricao
		{
			get { 
				return sdt.gxTpr_Clientetipoclientedescricao;

			}
			set { 
				 sdt.gxTpr_Clientetipoclientedescricao = value;
			}
		}

		[JsonPropertyName("ClienteDataNascimento")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ClienteDataNascimento", Order=4)]
		public  string gxTpr_Clientedatanascimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Clientedatanascimento);

			}
			set { 
				sdt.gxTpr_Clientedatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("ClienteRG")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ClienteRG", Order=5)]
		public  string gxTpr_Clienterg
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienterg, 12, 0));

			}
			set { 
				sdt.gxTpr_Clienterg = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteNacionalidadeNome")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ClienteNacionalidadeNome", Order=6)]
		public  string gxTpr_Clientenacionalidadenome
		{
			get { 
				return sdt.gxTpr_Clientenacionalidadenome;

			}
			set { 
				 sdt.gxTpr_Clientenacionalidadenome = value;
			}
		}

		[JsonPropertyName("ClienteEstadoCivil")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ClienteEstadoCivil", Order=7)]
		public  string gxTpr_Clienteestadocivil
		{
			get { 
				return sdt.gxTpr_Clienteestadocivil;

			}
			set { 
				 sdt.gxTpr_Clienteestadocivil = value;
			}
		}

		[JsonPropertyName("ClienteProfissaoNome")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="ClienteProfissaoNome", Order=8)]
		public  string gxTpr_Clienteprofissaonome
		{
			get { 
				return sdt.gxTpr_Clienteprofissaonome;

			}
			set { 
				 sdt.gxTpr_Clienteprofissaonome = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoCEP")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ClienteEnderecoCEP", Order=9)]
		public  string gxTpr_Clienteenderecocep
		{
			get { 
				return sdt.gxTpr_Clienteenderecocep;

			}
			set { 
				 sdt.gxTpr_Clienteenderecocep = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoLogradouro")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="ClienteEnderecoLogradouro", Order=10)]
		public  string gxTpr_Clienteenderecologradouro
		{
			get { 
				return sdt.gxTpr_Clienteenderecologradouro;

			}
			set { 
				 sdt.gxTpr_Clienteenderecologradouro = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoBairro")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ClienteEnderecoBairro", Order=11)]
		public  string gxTpr_Clienteenderecobairro
		{
			get { 
				return sdt.gxTpr_Clienteenderecobairro;

			}
			set { 
				 sdt.gxTpr_Clienteenderecobairro = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoCidade")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="ClienteEnderecoCidade", Order=12)]
		public  string gxTpr_Clienteenderecocidade
		{
			get { 
				return sdt.gxTpr_Clienteenderecocidade;

			}
			set { 
				 sdt.gxTpr_Clienteenderecocidade = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoMunicipioNome")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="ClienteEnderecoMunicipioNome", Order=13)]
		public  string gxTpr_Clienteenderecomunicipionome
		{
			get { 
				return sdt.gxTpr_Clienteenderecomunicipionome;

			}
			set { 
				 sdt.gxTpr_Clienteenderecomunicipionome = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoMunicipioUF")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="ClienteEnderecoMunicipioUF", Order=14)]
		public  string gxTpr_Clienteenderecomunicipiouf
		{
			get { 
				return sdt.gxTpr_Clienteenderecomunicipiouf;

			}
			set { 
				 sdt.gxTpr_Clienteenderecomunicipiouf = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoNumero")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="ClienteEnderecoNumero", Order=15)]
		public  string gxTpr_Clienteendereconumero
		{
			get { 
				return sdt.gxTpr_Clienteendereconumero;

			}
			set { 
				 sdt.gxTpr_Clienteendereconumero = value;
			}
		}

		[JsonPropertyName("ClienteEnderecoComplemento")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="ClienteEnderecoComplemento", Order=16)]
		public  string gxTpr_Clienteenderecocomplemento
		{
			get { 
				return sdt.gxTpr_Clienteenderecocomplemento;

			}
			set { 
				 sdt.gxTpr_Clienteenderecocomplemento = value;
			}
		}

		[JsonPropertyName("ContatoEmail")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="ContatoEmail", Order=17)]
		public  string gxTpr_Contatoemail
		{
			get { 
				return sdt.gxTpr_Contatoemail;

			}
			set { 
				 sdt.gxTpr_Contatoemail = value;
			}
		}

		[JsonPropertyName("ContatoDDD")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="ContatoDDD", Order=18)]
		public short gxTpr_Contatoddd
		{
			get { 
				return sdt.gxTpr_Contatoddd;

			}
			set { 
				sdt.gxTpr_Contatoddd = value;
			}
		}

		[JsonPropertyName("ContatoNumero")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="ContatoNumero", Order=19)]
		public  string gxTpr_Contatonumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatonumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatonumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelDocumento")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="ResponsavelDocumento", Order=20)]
		public  string gxTpr_Responsaveldocumento
		{
			get { 
				return sdt.gxTpr_Responsaveldocumento;

			}
			set { 
				 sdt.gxTpr_Responsaveldocumento = value;
			}
		}

		[JsonPropertyName("ResponsavelRazaoSocial")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="ResponsavelRazaoSocial", Order=21)]
		public  string gxTpr_Responsavelrazaosocial
		{
			get { 
				return sdt.gxTpr_Responsavelrazaosocial;

			}
			set { 
				 sdt.gxTpr_Responsavelrazaosocial = value;
			}
		}

		[JsonPropertyName("ResponsavelTipoPessoa")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="ResponsavelTipoPessoa", Order=22)]
		public  string gxTpr_Responsaveltipopessoa
		{
			get { 
				return sdt.gxTpr_Responsaveltipopessoa;

			}
			set { 
				 sdt.gxTpr_Responsaveltipopessoa = value;
			}
		}

		[JsonPropertyName("ResponsavelTipoClienteDescricao")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="ResponsavelTipoClienteDescricao", Order=23)]
		public  string gxTpr_Responsaveltipoclientedescricao
		{
			get { 
				return sdt.gxTpr_Responsaveltipoclientedescricao;

			}
			set { 
				 sdt.gxTpr_Responsaveltipoclientedescricao = value;
			}
		}

		[JsonPropertyName("ResponsavelDataNascimento")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="ResponsavelDataNascimento", Order=24)]
		public  string gxTpr_Responsaveldatanascimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Responsaveldatanascimento);

			}
			set { 
				sdt.gxTpr_Responsaveldatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("ResponsavelRG")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="ResponsavelRG", Order=25)]
		public  string gxTpr_Responsavelrg
		{
			get { 
				return sdt.gxTpr_Responsavelrg;

			}
			set { 
				 sdt.gxTpr_Responsavelrg = value;
			}
		}

		[JsonPropertyName("ResponsavelNacionalidade")]
		[JsonPropertyOrder(26)]
		[DataMember(Name="ResponsavelNacionalidade", Order=26)]
		public  string gxTpr_Responsavelnacionalidade
		{
			get { 
				return sdt.gxTpr_Responsavelnacionalidade;

			}
			set { 
				 sdt.gxTpr_Responsavelnacionalidade = value;
			}
		}

		[JsonPropertyName("ResponsavelEstadoCivil")]
		[JsonPropertyOrder(27)]
		[DataMember(Name="ResponsavelEstadoCivil", Order=27)]
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
		[JsonPropertyOrder(28)]
		[DataMember(Name="ResponsavelProfissao", Order=28)]
		public  string gxTpr_Responsavelprofissao
		{
			get { 
				return sdt.gxTpr_Responsavelprofissao;

			}
			set { 
				 sdt.gxTpr_Responsavelprofissao = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoEmail")]
		[JsonPropertyOrder(29)]
		[DataMember(Name="ResponsavelContatoEmail", Order=29)]
		public  string gxTpr_Responsavelcontatoemail
		{
			get { 
				return sdt.gxTpr_Responsavelcontatoemail;

			}
			set { 
				 sdt.gxTpr_Responsavelcontatoemail = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoDDD")]
		[JsonPropertyOrder(30)]
		[DataMember(Name="ResponsavelContatoDDD", Order=30)]
		public short gxTpr_Responsavelcontatoddd
		{
			get { 
				return sdt.gxTpr_Responsavelcontatoddd;

			}
			set { 
				sdt.gxTpr_Responsavelcontatoddd = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoNumero")]
		[JsonPropertyOrder(31)]
		[DataMember(Name="ResponsavelContatoNumero", Order=31)]
		public  string gxTpr_Responsavelcontatonumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelcontatonumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Responsavelcontatonumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("BancoPIXTipo")]
		[JsonPropertyOrder(32)]
		[DataMember(Name="BancoPIXTipo", Order=32)]
		public  string gxTpr_Bancopixtipo
		{
			get { 
				return sdt.gxTpr_Bancopixtipo;

			}
			set { 
				 sdt.gxTpr_Bancopixtipo = value;
			}
		}

		[JsonPropertyName("BancoPIXChave")]
		[JsonPropertyOrder(33)]
		[DataMember(Name="BancoPIXChave", Order=33)]
		public  string gxTpr_Bancopixchave
		{
			get { 
				return sdt.gxTpr_Bancopixchave;

			}
			set { 
				 sdt.gxTpr_Bancopixchave = value;
			}
		}

		[JsonPropertyName("BancoNome")]
		[JsonPropertyOrder(34)]
		[DataMember(Name="BancoNome", Order=34)]
		public  string gxTpr_Banconome
		{
			get { 
				return sdt.gxTpr_Banconome;

			}
			set { 
				 sdt.gxTpr_Banconome = value;
			}
		}

		[JsonPropertyName("BancoAgencia")]
		[JsonPropertyOrder(35)]
		[DataMember(Name="BancoAgencia", Order=35)]
		public  string gxTpr_Bancoagencia
		{
			get { 
				return sdt.gxTpr_Bancoagencia;

			}
			set { 
				 sdt.gxTpr_Bancoagencia = value;
			}
		}

		[JsonPropertyName("BancoConta")]
		[JsonPropertyOrder(36)]
		[DataMember(Name="BancoConta", Order=36)]
		public  string gxTpr_Bancoconta
		{
			get { 
				return sdt.gxTpr_Bancoconta;

			}
			set { 
				 sdt.gxTpr_Bancoconta = value;
			}
		}

		[JsonPropertyName("PropostaProcedimentosMedicos")]
		[JsonPropertyOrder(37)]
		[DataMember(Name="PropostaProcedimentosMedicos", Order=37)]
		public  string gxTpr_Propostaprocedimentosmedicos
		{
			get { 
				return sdt.gxTpr_Propostaprocedimentosmedicos;

			}
			set { 
				 sdt.gxTpr_Propostaprocedimentosmedicos = value;
			}
		}

		[JsonPropertyName("PropostaValor")]
		[JsonPropertyOrder(38)]
		[DataMember(Name="PropostaValor", Order=38)]
		public  string gxTpr_Propostavalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostavalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Propostavalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaConvenio")]
		[JsonPropertyOrder(39)]
		[DataMember(Name="PropostaConvenio", Order=39)]
		public  string gxTpr_Propostaconvenio
		{
			get { 
				return sdt.gxTpr_Propostaconvenio;

			}
			set { 
				 sdt.gxTpr_Propostaconvenio = value;
			}
		}

		[JsonPropertyName("PropostaCategoriaConvenio")]
		[JsonPropertyOrder(40)]
		[DataMember(Name="PropostaCategoriaConvenio", Order=40)]
		public  string gxTpr_Propostacategoriaconvenio
		{
			get { 
				return sdt.gxTpr_Propostacategoriaconvenio;

			}
			set { 
				 sdt.gxTpr_Propostacategoriaconvenio = value;
			}
		}

		[JsonPropertyName("PropostaVencimentoCarteirinha")]
		[JsonPropertyOrder(41)]
		[DataMember(Name="PropostaVencimentoCarteirinha", Order=41)]
		public  string gxTpr_Propostavencimentocarteirinha
		{
			get { 
				return sdt.gxTpr_Propostavencimentocarteirinha;

			}
			set { 
				 sdt.gxTpr_Propostavencimentocarteirinha = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdComprovante sdt
		{
			get { 
				return (SdtSdComprovante)Sdt;
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
				sdt = new SdtSdComprovante() ;
			}
		}
	}
	#endregion
}