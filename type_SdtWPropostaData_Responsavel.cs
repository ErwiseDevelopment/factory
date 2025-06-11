/*
				   File: type_SdtWPropostaData_Responsavel
			Description: Responsavel
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
	[XmlRoot(ElementName="WPropostaData.Responsavel")]
	[XmlType(TypeName="WPropostaData.Responsavel" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Responsavel : GxUserType
	{
		public SdtWPropostaData_Responsavel( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Responsavel_Responsavelclientedocumento = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelclientetipopessoa = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelclienterazaosocial = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelclienteestadocivil = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoemail = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelcep = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocep = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecologradouro = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelendereconumero = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocomplemento = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecobairro = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocidade = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiocodigo = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipionome = "";

			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiouf = "";

		}

		public SdtWPropostaData_Responsavel(IGxContext context)
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
			AddObjectProperty("ResponsavelClienteDocumento", gxTpr_Responsavelclientedocumento, false);


			AddObjectProperty("ResponsavelClienteTipoPessoa", gxTpr_Responsavelclientetipopessoa, false);


			AddObjectProperty("ResponsavelTipoClienteId", gxTpr_Responsaveltipoclienteid, false);


			AddObjectProperty("ResponsavelClienteId", gxTpr_Responsavelclienteid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Responsavelclientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Responsavelclientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Responsavelclientedatanascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ResponsavelClienteDataNascimento", sDateCnv, false);



			AddObjectProperty("ResponsavelClienteRazaoSocial", gxTpr_Responsavelclienterazaosocial, false);


			AddObjectProperty("ResponsavelClienteRG", gxTpr_Responsavelclienterg, false);


			AddObjectProperty("ResponsavelClienteNacionalidade", gxTpr_Responsavelclientenacionalidade, false);


			AddObjectProperty("ResponsavelClienteEstadoCivil", gxTpr_Responsavelclienteestadocivil, false);


			AddObjectProperty("ResponsavelClienteProfissao", gxTpr_Responsavelclienteprofissao, false);


			AddObjectProperty("ResponsavelClienteStatus", gxTpr_Responsavelclientestatus, false);


			AddObjectProperty("ResponsavelContatoEmail", gxTpr_Responsavelcontatoemail, false);


			AddObjectProperty("ResponsavelContatoDDD", gxTpr_Responsavelcontatoddd, false);


			AddObjectProperty("ResponsavelContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Responsavelcontatonumero, 18, 0)), false);


			AddObjectProperty("ResponsavelContatoTelefoneDDD", gxTpr_Responsavelcontatotelefoneddd, false);


			AddObjectProperty("ResponsavelContatoTelefoneNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Responsavelcontatotelefonenumero, 18, 0)), false);


			AddObjectProperty("ResponsavelCEP", gxTpr_Responsavelcep, false);


			AddObjectProperty("ResponsavelEnderecoCEP", gxTpr_Responsavelenderecocep, false);


			AddObjectProperty("ResponsavelEnderecoLogradouro", gxTpr_Responsavelenderecologradouro, false);


			AddObjectProperty("ResponsavelEnderecoNumero", gxTpr_Responsavelendereconumero, false);


			AddObjectProperty("ResponsavelEnderecoComplemento", gxTpr_Responsavelenderecocomplemento, false);


			AddObjectProperty("ResponsavelEnderecoBairro", gxTpr_Responsavelenderecobairro, false);


			AddObjectProperty("ResponsavelEnderecoCidade", gxTpr_Responsavelenderecocidade, false);


			AddObjectProperty("ResponsavelMunicipioCodigo", gxTpr_Responsavelmunicipiocodigo, false);


			AddObjectProperty("ResponsavelMunicipioNome", gxTpr_Responsavelmunicipionome, false);


			AddObjectProperty("ResponsavelMunicipioUF", gxTpr_Responsavelmunicipiouf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResponsavelClienteDocumento")]
		[XmlElement(ElementName="ResponsavelClienteDocumento")]
		public string gxTpr_Responsavelclientedocumento
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclientedocumento; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientedocumento = value;
				SetDirty("Responsavelclientedocumento");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteTipoPessoa")]
		[XmlElement(ElementName="ResponsavelClienteTipoPessoa")]
		public string gxTpr_Responsavelclientetipopessoa
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclientetipopessoa; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientetipopessoa = value;
				SetDirty("Responsavelclientetipopessoa");
			}
		}




		[SoapElement(ElementName="ResponsavelTipoClienteId")]
		[XmlElement(ElementName="ResponsavelTipoClienteId")]
		public short gxTpr_Responsaveltipoclienteid
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsaveltipoclienteid; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsaveltipoclienteid = value;
				SetDirty("Responsaveltipoclienteid");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteId")]
		[XmlElement(ElementName="ResponsavelClienteId")]
		public int gxTpr_Responsavelclienteid
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclienteid; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclienteid = value;
				SetDirty("Responsavelclienteid");
			}
		}



		[SoapElement(ElementName="ResponsavelClienteDataNascimento")]
		[XmlElement(ElementName="ResponsavelClienteDataNascimento" , IsNullable=true)]
		public string gxTpr_Responsavelclientedatanascimento_Nullable
		{
			get {
				if ( gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento).value ;
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Responsavelclientedatanascimento
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento = value;
				SetDirty("Responsavelclientedatanascimento");
			}
		}



		[SoapElement(ElementName="ResponsavelClienteRazaoSocial")]
		[XmlElement(ElementName="ResponsavelClienteRazaoSocial")]
		public string gxTpr_Responsavelclienterazaosocial
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclienterazaosocial; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclienterazaosocial = value;
				SetDirty("Responsavelclienterazaosocial");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteRG")]
		[XmlElement(ElementName="ResponsavelClienteRG")]
		public long gxTpr_Responsavelclienterg
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclienterg; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclienterg = value;
				SetDirty("Responsavelclienterg");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteNacionalidade")]
		[XmlElement(ElementName="ResponsavelClienteNacionalidade")]
		public int gxTpr_Responsavelclientenacionalidade
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclientenacionalidade; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientenacionalidade = value;
				SetDirty("Responsavelclientenacionalidade");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteEstadoCivil")]
		[XmlElement(ElementName="ResponsavelClienteEstadoCivil")]
		public string gxTpr_Responsavelclienteestadocivil
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclienteestadocivil; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclienteestadocivil = value;
				SetDirty("Responsavelclienteestadocivil");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteProfissao")]
		[XmlElement(ElementName="ResponsavelClienteProfissao")]
		public int gxTpr_Responsavelclienteprofissao
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclienteprofissao; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclienteprofissao = value;
				SetDirty("Responsavelclienteprofissao");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteStatus")]
		[XmlElement(ElementName="ResponsavelClienteStatus")]
		public bool gxTpr_Responsavelclientestatus
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelclientestatus; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelclientestatus = value;
				SetDirty("Responsavelclientestatus");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoEmail")]
		[XmlElement(ElementName="ResponsavelContatoEmail")]
		public string gxTpr_Responsavelcontatoemail
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoemail; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoemail = value;
				SetDirty("Responsavelcontatoemail");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoDDD")]
		[XmlElement(ElementName="ResponsavelContatoDDD")]
		public short gxTpr_Responsavelcontatoddd
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoddd; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoddd = value;
				SetDirty("Responsavelcontatoddd");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoNumero")]
		[XmlElement(ElementName="ResponsavelContatoNumero")]
		public long gxTpr_Responsavelcontatonumero
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcontatonumero; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcontatonumero = value;
				SetDirty("Responsavelcontatonumero");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoTelefoneDDD")]
		[XmlElement(ElementName="ResponsavelContatoTelefoneDDD")]
		public short gxTpr_Responsavelcontatotelefoneddd
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefoneddd; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefoneddd = value;
				SetDirty("Responsavelcontatotelefoneddd");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoTelefoneNumero")]
		[XmlElement(ElementName="ResponsavelContatoTelefoneNumero")]
		public long gxTpr_Responsavelcontatotelefonenumero
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefonenumero; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefonenumero = value;
				SetDirty("Responsavelcontatotelefonenumero");
			}
		}




		[SoapElement(ElementName="ResponsavelCEP")]
		[XmlElement(ElementName="ResponsavelCEP")]
		public string gxTpr_Responsavelcep
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelcep; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelcep = value;
				SetDirty("Responsavelcep");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoCEP")]
		[XmlElement(ElementName="ResponsavelEnderecoCEP")]
		public string gxTpr_Responsavelenderecocep
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocep; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocep = value;
				SetDirty("Responsavelenderecocep");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoLogradouro")]
		[XmlElement(ElementName="ResponsavelEnderecoLogradouro")]
		public string gxTpr_Responsavelenderecologradouro
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelenderecologradouro; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelenderecologradouro = value;
				SetDirty("Responsavelenderecologradouro");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoNumero")]
		[XmlElement(ElementName="ResponsavelEnderecoNumero")]
		public string gxTpr_Responsavelendereconumero
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelendereconumero; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelendereconumero = value;
				SetDirty("Responsavelendereconumero");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoComplemento")]
		[XmlElement(ElementName="ResponsavelEnderecoComplemento")]
		public string gxTpr_Responsavelenderecocomplemento
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocomplemento; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocomplemento = value;
				SetDirty("Responsavelenderecocomplemento");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoBairro")]
		[XmlElement(ElementName="ResponsavelEnderecoBairro")]
		public string gxTpr_Responsavelenderecobairro
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelenderecobairro; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelenderecobairro = value;
				SetDirty("Responsavelenderecobairro");
			}
		}




		[SoapElement(ElementName="ResponsavelEnderecoCidade")]
		[XmlElement(ElementName="ResponsavelEnderecoCidade")]
		public string gxTpr_Responsavelenderecocidade
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocidade; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocidade = value;
				SetDirty("Responsavelenderecocidade");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipioCodigo")]
		[XmlElement(ElementName="ResponsavelMunicipioCodigo")]
		public string gxTpr_Responsavelmunicipiocodigo
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiocodigo; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiocodigo = value;
				SetDirty("Responsavelmunicipiocodigo");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipioNome")]
		[XmlElement(ElementName="ResponsavelMunicipioNome")]
		public string gxTpr_Responsavelmunicipionome
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipionome; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipionome = value;
				SetDirty("Responsavelmunicipionome");
			}
		}




		[SoapElement(ElementName="ResponsavelMunicipioUF")]
		[XmlElement(ElementName="ResponsavelMunicipioUF")]
		public string gxTpr_Responsavelmunicipiouf
		{
			get {
				return gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiouf; 
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiouf = value;
				SetDirty("Responsavelmunicipiouf");
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
			gxTv_SdtWPropostaData_Responsavel_Responsavelclientedocumento = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelclientetipopessoa = "";



			gxTv_SdtWPropostaData_Responsavel_Responsavelclienterazaosocial = "";


			gxTv_SdtWPropostaData_Responsavel_Responsavelclienteestadocivil = "";


			gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoemail = "";




			gxTv_SdtWPropostaData_Responsavel_Responsavelcep = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocep = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecologradouro = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelendereconumero = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocomplemento = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecobairro = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocidade = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiocodigo = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipionome = "";
			gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiouf = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelclientedocumento;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelclientetipopessoa;
		 

		protected short gxTv_SdtWPropostaData_Responsavel_Responsaveltipoclienteid;
		 

		protected int gxTv_SdtWPropostaData_Responsavel_Responsavelclienteid;
		 

		protected DateTime gxTv_SdtWPropostaData_Responsavel_Responsavelclientedatanascimento;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelclienterazaosocial;
		 

		protected long gxTv_SdtWPropostaData_Responsavel_Responsavelclienterg;
		 

		protected int gxTv_SdtWPropostaData_Responsavel_Responsavelclientenacionalidade;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelclienteestadocivil;
		 

		protected int gxTv_SdtWPropostaData_Responsavel_Responsavelclienteprofissao;
		 

		protected bool gxTv_SdtWPropostaData_Responsavel_Responsavelclientestatus;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoemail;
		 

		protected short gxTv_SdtWPropostaData_Responsavel_Responsavelcontatoddd;
		 

		protected long gxTv_SdtWPropostaData_Responsavel_Responsavelcontatonumero;
		 

		protected short gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefoneddd;
		 

		protected long gxTv_SdtWPropostaData_Responsavel_Responsavelcontatotelefonenumero;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelcep;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocep;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelenderecologradouro;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelendereconumero;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocomplemento;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelenderecobairro;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelenderecocidade;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiocodigo;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipionome;
		 

		protected string gxTv_SdtWPropostaData_Responsavel_Responsavelmunicipiouf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Responsavel", Namespace="Factory21")]
	public class SdtWPropostaData_Responsavel_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Responsavel>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Responsavel_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Responsavel_RESTInterface( SdtWPropostaData_Responsavel psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ResponsavelClienteDocumento")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ResponsavelClienteDocumento", Order=0)]
		public  string gxTpr_Responsavelclientedocumento
		{
			get { 
				return sdt.gxTpr_Responsavelclientedocumento;

			}
			set { 
				 sdt.gxTpr_Responsavelclientedocumento = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteTipoPessoa")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ResponsavelClienteTipoPessoa", Order=1)]
		public  string gxTpr_Responsavelclientetipopessoa
		{
			get { 
				return sdt.gxTpr_Responsavelclientetipopessoa;

			}
			set { 
				 sdt.gxTpr_Responsavelclientetipopessoa = value;
			}
		}

		[JsonPropertyName("ResponsavelTipoClienteId")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ResponsavelTipoClienteId", Order=2)]
		public short gxTpr_Responsaveltipoclienteid
		{
			get { 
				return sdt.gxTpr_Responsaveltipoclienteid;

			}
			set { 
				sdt.gxTpr_Responsaveltipoclienteid = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ResponsavelClienteId", Order=3)]
		public  string gxTpr_Responsavelclienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelclienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelclienteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelClienteDataNascimento")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ResponsavelClienteDataNascimento", Order=4)]
		public  string gxTpr_Responsavelclientedatanascimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Responsavelclientedatanascimento);

			}
			set { 
				sdt.gxTpr_Responsavelclientedatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("ResponsavelClienteRazaoSocial")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ResponsavelClienteRazaoSocial", Order=5)]
		public  string gxTpr_Responsavelclienterazaosocial
		{
			get { 
				return sdt.gxTpr_Responsavelclienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Responsavelclienterazaosocial = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteRG")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ResponsavelClienteRG", Order=6)]
		public  string gxTpr_Responsavelclienterg
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelclienterg, 12, 0));

			}
			set { 
				sdt.gxTpr_Responsavelclienterg = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelClienteNacionalidade")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ResponsavelClienteNacionalidade", Order=7)]
		public  string gxTpr_Responsavelclientenacionalidade
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelclientenacionalidade, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelclientenacionalidade = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelClienteEstadoCivil")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="ResponsavelClienteEstadoCivil", Order=8)]
		public  string gxTpr_Responsavelclienteestadocivil
		{
			get { 
				return sdt.gxTpr_Responsavelclienteestadocivil;

			}
			set { 
				 sdt.gxTpr_Responsavelclienteestadocivil = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteProfissao")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ResponsavelClienteProfissao", Order=9)]
		public  string gxTpr_Responsavelclienteprofissao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelclienteprofissao, 9, 0));

			}
			set { 
				sdt.gxTpr_Responsavelclienteprofissao = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelClienteStatus")]
		[JsonPropertyOrder(10)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="ResponsavelClienteStatus", Order=10)]
		public bool gxTpr_Responsavelclientestatus
		{
			get { 
				return sdt.gxTpr_Responsavelclientestatus;

			}
			set { 
				sdt.gxTpr_Responsavelclientestatus = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoEmail")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ResponsavelContatoEmail", Order=11)]
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
		[JsonPropertyOrder(12)]
		[DataMember(Name="ResponsavelContatoDDD", Order=12)]
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
		[JsonPropertyOrder(13)]
		[DataMember(Name="ResponsavelContatoNumero", Order=13)]
		public  string gxTpr_Responsavelcontatonumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelcontatonumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Responsavelcontatonumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelContatoTelefoneDDD")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="ResponsavelContatoTelefoneDDD", Order=14)]
		public short gxTpr_Responsavelcontatotelefoneddd
		{
			get { 
				return sdt.gxTpr_Responsavelcontatotelefoneddd;

			}
			set { 
				sdt.gxTpr_Responsavelcontatotelefoneddd = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoTelefoneNumero")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="ResponsavelContatoTelefoneNumero", Order=15)]
		public  string gxTpr_Responsavelcontatotelefonenumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Responsavelcontatotelefonenumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Responsavelcontatotelefonenumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResponsavelCEP")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="ResponsavelCEP", Order=16)]
		public  string gxTpr_Responsavelcep
		{
			get { 
				return sdt.gxTpr_Responsavelcep;

			}
			set { 
				 sdt.gxTpr_Responsavelcep = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoCEP")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="ResponsavelEnderecoCEP", Order=17)]
		public  string gxTpr_Responsavelenderecocep
		{
			get { 
				return sdt.gxTpr_Responsavelenderecocep;

			}
			set { 
				 sdt.gxTpr_Responsavelenderecocep = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoLogradouro")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="ResponsavelEnderecoLogradouro", Order=18)]
		public  string gxTpr_Responsavelenderecologradouro
		{
			get { 
				return sdt.gxTpr_Responsavelenderecologradouro;

			}
			set { 
				 sdt.gxTpr_Responsavelenderecologradouro = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoNumero")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="ResponsavelEnderecoNumero", Order=19)]
		public  string gxTpr_Responsavelendereconumero
		{
			get { 
				return sdt.gxTpr_Responsavelendereconumero;

			}
			set { 
				 sdt.gxTpr_Responsavelendereconumero = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoComplemento")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="ResponsavelEnderecoComplemento", Order=20)]
		public  string gxTpr_Responsavelenderecocomplemento
		{
			get { 
				return sdt.gxTpr_Responsavelenderecocomplemento;

			}
			set { 
				 sdt.gxTpr_Responsavelenderecocomplemento = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoBairro")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="ResponsavelEnderecoBairro", Order=21)]
		public  string gxTpr_Responsavelenderecobairro
		{
			get { 
				return sdt.gxTpr_Responsavelenderecobairro;

			}
			set { 
				 sdt.gxTpr_Responsavelenderecobairro = value;
			}
		}

		[JsonPropertyName("ResponsavelEnderecoCidade")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="ResponsavelEnderecoCidade", Order=22)]
		public  string gxTpr_Responsavelenderecocidade
		{
			get { 
				return sdt.gxTpr_Responsavelenderecocidade;

			}
			set { 
				 sdt.gxTpr_Responsavelenderecocidade = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipioCodigo")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="ResponsavelMunicipioCodigo", Order=23)]
		public  string gxTpr_Responsavelmunicipiocodigo
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipiocodigo;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipiocodigo = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipioNome")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="ResponsavelMunicipioNome", Order=24)]
		public  string gxTpr_Responsavelmunicipionome
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipionome;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipionome = value;
			}
		}

		[JsonPropertyName("ResponsavelMunicipioUF")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="ResponsavelMunicipioUF", Order=25)]
		public  string gxTpr_Responsavelmunicipiouf
		{
			get { 
				return sdt.gxTpr_Responsavelmunicipiouf;

			}
			set { 
				 sdt.gxTpr_Responsavelmunicipiouf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Responsavel sdt
		{
			get { 
				return (SdtWPropostaData_Responsavel)Sdt;
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
				sdt = new SdtWPropostaData_Responsavel() ;
			}
		}
	}
	#endregion
}