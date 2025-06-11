/*
				   File: type_SdtWPropostaData_NovoCliente
			Description: NovoCliente
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
	[XmlRoot(ElementName="WPropostaData.NovoCliente")]
	[XmlType(TypeName="WPropostaData.NovoCliente" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_NovoCliente : GxUserType
	{
		public SdtWPropostaData_NovoCliente( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_NovoCliente_Clientedocumento = "";

			gxTv_SdtWPropostaData_NovoCliente_Clientetipopessoa = "";

			gxTv_SdtWPropostaData_NovoCliente_Clienterazaosocial = "";

			gxTv_SdtWPropostaData_NovoCliente_Clienteestadocivil = "";

			gxTv_SdtWPropostaData_NovoCliente_Contatoemail = "";

			gxTv_SdtWPropostaData_NovoCliente_Cep = "";

			gxTv_SdtWPropostaData_NovoCliente_Enderecocep = "";

			gxTv_SdtWPropostaData_NovoCliente_Enderecologradouro = "";

			gxTv_SdtWPropostaData_NovoCliente_Endereconumero = "";

			gxTv_SdtWPropostaData_NovoCliente_Enderecocomplemento = "";

			gxTv_SdtWPropostaData_NovoCliente_Enderecobairro = "";

			gxTv_SdtWPropostaData_NovoCliente_Enderecocidade = "";

			gxTv_SdtWPropostaData_NovoCliente_Municipiocodigo = "";

			gxTv_SdtWPropostaData_NovoCliente_Municipionome = "";

			gxTv_SdtWPropostaData_NovoCliente_Municipiouf = "";

			gxTv_SdtWPropostaData_NovoCliente_Clientenomefantasia = "";

		}

		public SdtWPropostaData_NovoCliente(IGxContext context)
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


			AddObjectProperty("ClienteTipoPessoa", gxTpr_Clientetipopessoa, false);


			AddObjectProperty("TipoClienteId", gxTpr_Tipoclienteid, false);


			AddObjectProperty("ClienteId", gxTpr_Clienteid, false);


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



			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("ClienteRG", gxTpr_Clienterg, false);


			AddObjectProperty("ClienteNacionalidade", gxTpr_Clientenacionalidade, false);


			AddObjectProperty("ClienteEstadoCivil", gxTpr_Clienteestadocivil, false);


			AddObjectProperty("ClienteProfissao", gxTpr_Clienteprofissao, false);


			AddObjectProperty("ClienteStatus", gxTpr_Clientestatus, false);


			AddObjectProperty("PossuiResponsavel", gxTpr_Possuiresponsavel, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);


			AddObjectProperty("ContatoDDD", gxTpr_Contatoddd, false);


			AddObjectProperty("ContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatonumero, 18, 0)), false);


			AddObjectProperty("ContatoTelefoneDDD", gxTpr_Contatotelefoneddd, false);


			AddObjectProperty("ContatoTelefoneNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatotelefonenumero, 18, 0)), false);


			AddObjectProperty("CEP", gxTpr_Cep, false);


			AddObjectProperty("EnderecoCEP", gxTpr_Enderecocep, false);


			AddObjectProperty("EnderecoLogradouro", gxTpr_Enderecologradouro, false);


			AddObjectProperty("EnderecoNumero", gxTpr_Endereconumero, false);


			AddObjectProperty("EnderecoComplemento", gxTpr_Enderecocomplemento, false);


			AddObjectProperty("EnderecoBairro", gxTpr_Enderecobairro, false);


			AddObjectProperty("EnderecoCidade", gxTpr_Enderecocidade, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);


			AddObjectProperty("ClienteNomeFantasia", gxTpr_Clientenomefantasia, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientedocumento; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientedocumento = value;
				SetDirty("Clientedocumento");
			}
		}




		[SoapElement(ElementName="ClienteTipoPessoa")]
		[XmlElement(ElementName="ClienteTipoPessoa")]
		public string gxTpr_Clientetipopessoa
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientetipopessoa; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientetipopessoa = value;
				SetDirty("Clientetipopessoa");
			}
		}




		[SoapElement(ElementName="TipoClienteId")]
		[XmlElement(ElementName="TipoClienteId")]
		public short gxTpr_Tipoclienteid
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Tipoclienteid; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Tipoclienteid = value;
				SetDirty("Tipoclienteid");
			}
		}




		[SoapElement(ElementName="ClienteId")]
		[XmlElement(ElementName="ClienteId")]
		public int gxTpr_Clienteid
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clienteid; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clienteid = value;
				SetDirty("Clienteid");
			}
		}



		[SoapElement(ElementName="ClienteDataNascimento")]
		[XmlElement(ElementName="ClienteDataNascimento" , IsNullable=true)]
		public string gxTpr_Clientedatanascimento_Nullable
		{
			get {
				if ( gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento).value ;
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Clientedatanascimento
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento = value;
				SetDirty("Clientedatanascimento");
			}
		}



		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clienterazaosocial; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="ClienteRG")]
		[XmlElement(ElementName="ClienteRG")]
		public long gxTpr_Clienterg
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clienterg; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clienterg = value;
				SetDirty("Clienterg");
			}
		}




		[SoapElement(ElementName="ClienteNacionalidade")]
		[XmlElement(ElementName="ClienteNacionalidade")]
		public int gxTpr_Clientenacionalidade
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientenacionalidade; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientenacionalidade = value;
				SetDirty("Clientenacionalidade");
			}
		}




		[SoapElement(ElementName="ClienteEstadoCivil")]
		[XmlElement(ElementName="ClienteEstadoCivil")]
		public string gxTpr_Clienteestadocivil
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clienteestadocivil; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clienteestadocivil = value;
				SetDirty("Clienteestadocivil");
			}
		}




		[SoapElement(ElementName="ClienteProfissao")]
		[XmlElement(ElementName="ClienteProfissao")]
		public int gxTpr_Clienteprofissao
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clienteprofissao; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clienteprofissao = value;
				SetDirty("Clienteprofissao");
			}
		}




		[SoapElement(ElementName="ClienteStatus")]
		[XmlElement(ElementName="ClienteStatus")]
		public bool gxTpr_Clientestatus
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientestatus; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientestatus = value;
				SetDirty("Clientestatus");
			}
		}




		[SoapElement(ElementName="PossuiResponsavel")]
		[XmlElement(ElementName="PossuiResponsavel")]
		public bool gxTpr_Possuiresponsavel
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Possuiresponsavel; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Possuiresponsavel = value;
				SetDirty("Possuiresponsavel");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Contatoemail; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="ContatoDDD")]
		[XmlElement(ElementName="ContatoDDD")]
		public short gxTpr_Contatoddd
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Contatoddd; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Contatoddd = value;
				SetDirty("Contatoddd");
			}
		}




		[SoapElement(ElementName="ContatoNumero")]
		[XmlElement(ElementName="ContatoNumero")]
		public long gxTpr_Contatonumero
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Contatonumero; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Contatonumero = value;
				SetDirty("Contatonumero");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneDDD")]
		[XmlElement(ElementName="ContatoTelefoneDDD")]
		public short gxTpr_Contatotelefoneddd
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Contatotelefoneddd; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Contatotelefoneddd = value;
				SetDirty("Contatotelefoneddd");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneNumero")]
		[XmlElement(ElementName="ContatoTelefoneNumero")]
		public long gxTpr_Contatotelefonenumero
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Contatotelefonenumero; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Contatotelefonenumero = value;
				SetDirty("Contatotelefonenumero");
			}
		}




		[SoapElement(ElementName="CEP")]
		[XmlElement(ElementName="CEP")]
		public string gxTpr_Cep
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Cep; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Cep = value;
				SetDirty("Cep");
			}
		}




		[SoapElement(ElementName="EnderecoCEP")]
		[XmlElement(ElementName="EnderecoCEP")]
		public string gxTpr_Enderecocep
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Enderecocep; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Enderecocep = value;
				SetDirty("Enderecocep");
			}
		}




		[SoapElement(ElementName="EnderecoLogradouro")]
		[XmlElement(ElementName="EnderecoLogradouro")]
		public string gxTpr_Enderecologradouro
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Enderecologradouro; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Enderecologradouro = value;
				SetDirty("Enderecologradouro");
			}
		}




		[SoapElement(ElementName="EnderecoNumero")]
		[XmlElement(ElementName="EnderecoNumero")]
		public string gxTpr_Endereconumero
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Endereconumero; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Endereconumero = value;
				SetDirty("Endereconumero");
			}
		}




		[SoapElement(ElementName="EnderecoComplemento")]
		[XmlElement(ElementName="EnderecoComplemento")]
		public string gxTpr_Enderecocomplemento
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Enderecocomplemento; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Enderecocomplemento = value;
				SetDirty("Enderecocomplemento");
			}
		}




		[SoapElement(ElementName="EnderecoBairro")]
		[XmlElement(ElementName="EnderecoBairro")]
		public string gxTpr_Enderecobairro
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Enderecobairro; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Enderecobairro = value;
				SetDirty("Enderecobairro");
			}
		}




		[SoapElement(ElementName="EnderecoCidade")]
		[XmlElement(ElementName="EnderecoCidade")]
		public string gxTpr_Enderecocidade
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Enderecocidade; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Enderecocidade = value;
				SetDirty("Enderecocidade");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Municipiocodigo; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Municipionome; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Municipiouf; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Municipiouf = value;
				SetDirty("Municipiouf");
			}
		}




		[SoapElement(ElementName="ClienteNomeFantasia")]
		[XmlElement(ElementName="ClienteNomeFantasia")]
		public string gxTpr_Clientenomefantasia
		{
			get {
				return gxTv_SdtWPropostaData_NovoCliente_Clientenomefantasia; 
			}
			set {
				gxTv_SdtWPropostaData_NovoCliente_Clientenomefantasia = value;
				SetDirty("Clientenomefantasia");
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
			gxTv_SdtWPropostaData_NovoCliente_Clientedocumento = "";
			gxTv_SdtWPropostaData_NovoCliente_Clientetipopessoa = "";



			gxTv_SdtWPropostaData_NovoCliente_Clienterazaosocial = "";


			gxTv_SdtWPropostaData_NovoCliente_Clienteestadocivil = "";



			gxTv_SdtWPropostaData_NovoCliente_Contatoemail = "";




			gxTv_SdtWPropostaData_NovoCliente_Cep = "";
			gxTv_SdtWPropostaData_NovoCliente_Enderecocep = "";
			gxTv_SdtWPropostaData_NovoCliente_Enderecologradouro = "";
			gxTv_SdtWPropostaData_NovoCliente_Endereconumero = "";
			gxTv_SdtWPropostaData_NovoCliente_Enderecocomplemento = "";
			gxTv_SdtWPropostaData_NovoCliente_Enderecobairro = "";
			gxTv_SdtWPropostaData_NovoCliente_Enderecocidade = "";
			gxTv_SdtWPropostaData_NovoCliente_Municipiocodigo = "";
			gxTv_SdtWPropostaData_NovoCliente_Municipionome = "";
			gxTv_SdtWPropostaData_NovoCliente_Municipiouf = "";
			gxTv_SdtWPropostaData_NovoCliente_Clientenomefantasia = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtWPropostaData_NovoCliente_Clientedocumento;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Clientetipopessoa;
		 

		protected short gxTv_SdtWPropostaData_NovoCliente_Tipoclienteid;
		 

		protected int gxTv_SdtWPropostaData_NovoCliente_Clienteid;
		 

		protected DateTime gxTv_SdtWPropostaData_NovoCliente_Clientedatanascimento;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Clienterazaosocial;
		 

		protected long gxTv_SdtWPropostaData_NovoCliente_Clienterg;
		 

		protected int gxTv_SdtWPropostaData_NovoCliente_Clientenacionalidade;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Clienteestadocivil;
		 

		protected int gxTv_SdtWPropostaData_NovoCliente_Clienteprofissao;
		 

		protected bool gxTv_SdtWPropostaData_NovoCliente_Clientestatus;
		 

		protected bool gxTv_SdtWPropostaData_NovoCliente_Possuiresponsavel;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Contatoemail;
		 

		protected short gxTv_SdtWPropostaData_NovoCliente_Contatoddd;
		 

		protected long gxTv_SdtWPropostaData_NovoCliente_Contatonumero;
		 

		protected short gxTv_SdtWPropostaData_NovoCliente_Contatotelefoneddd;
		 

		protected long gxTv_SdtWPropostaData_NovoCliente_Contatotelefonenumero;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Cep;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Enderecocep;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Enderecologradouro;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Endereconumero;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Enderecocomplemento;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Enderecobairro;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Enderecocidade;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Municipiocodigo;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Municipionome;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Municipiouf;
		 

		protected string gxTv_SdtWPropostaData_NovoCliente_Clientenomefantasia;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.NovoCliente", Namespace="Factory21")]
	public class SdtWPropostaData_NovoCliente_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_NovoCliente>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_NovoCliente_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_NovoCliente_RESTInterface( SdtWPropostaData_NovoCliente psdt ) : base(psdt)
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

		[JsonPropertyName("ClienteTipoPessoa")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClienteTipoPessoa", Order=1)]
		public  string gxTpr_Clientetipopessoa
		{
			get { 
				return sdt.gxTpr_Clientetipopessoa;

			}
			set { 
				 sdt.gxTpr_Clientetipopessoa = value;
			}
		}

		[JsonPropertyName("TipoClienteId")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="TipoClienteId", Order=2)]
		public short gxTpr_Tipoclienteid
		{
			get { 
				return sdt.gxTpr_Tipoclienteid;

			}
			set { 
				sdt.gxTpr_Tipoclienteid = value;
			}
		}

		[JsonPropertyName("ClienteId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ClienteId", Order=3)]
		public  string gxTpr_Clienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteid = (int) NumberUtil.Val( value, ".");
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

		[JsonPropertyName("ClienteRazaoSocial")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ClienteRazaoSocial", Order=5)]
		public  string gxTpr_Clienterazaosocial
		{
			get { 
				return sdt.gxTpr_Clienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Clienterazaosocial = value;
			}
		}

		[JsonPropertyName("ClienteRG")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ClienteRG", Order=6)]
		public  string gxTpr_Clienterg
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienterg, 12, 0));

			}
			set { 
				sdt.gxTpr_Clienterg = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteNacionalidade")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ClienteNacionalidade", Order=7)]
		public  string gxTpr_Clientenacionalidade
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clientenacionalidade, 9, 0));

			}
			set { 
				sdt.gxTpr_Clientenacionalidade = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteEstadoCivil")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="ClienteEstadoCivil", Order=8)]
		public  string gxTpr_Clienteestadocivil
		{
			get { 
				return sdt.gxTpr_Clienteestadocivil;

			}
			set { 
				 sdt.gxTpr_Clienteestadocivil = value;
			}
		}

		[JsonPropertyName("ClienteProfissao")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ClienteProfissao", Order=9)]
		public  string gxTpr_Clienteprofissao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteprofissao, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteprofissao = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ClienteStatus")]
		[JsonPropertyOrder(10)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="ClienteStatus", Order=10)]
		public bool gxTpr_Clientestatus
		{
			get { 
				return sdt.gxTpr_Clientestatus;

			}
			set { 
				sdt.gxTpr_Clientestatus = value;
			}
		}

		[JsonPropertyName("PossuiResponsavel")]
		[JsonPropertyOrder(11)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="PossuiResponsavel", Order=11)]
		public bool gxTpr_Possuiresponsavel
		{
			get { 
				return sdt.gxTpr_Possuiresponsavel;

			}
			set { 
				sdt.gxTpr_Possuiresponsavel = value;
			}
		}

		[JsonPropertyName("ContatoEmail")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="ContatoEmail", Order=12)]
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
		[JsonPropertyOrder(13)]
		[DataMember(Name="ContatoDDD", Order=13)]
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
		[JsonPropertyOrder(14)]
		[DataMember(Name="ContatoNumero", Order=14)]
		public  string gxTpr_Contatonumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatonumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatonumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContatoTelefoneDDD")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="ContatoTelefoneDDD", Order=15)]
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
		[JsonPropertyOrder(16)]
		[DataMember(Name="ContatoTelefoneNumero", Order=16)]
		public  string gxTpr_Contatotelefonenumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatotelefonenumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatotelefonenumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("CEP")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="CEP", Order=17)]
		public  string gxTpr_Cep
		{
			get { 
				return sdt.gxTpr_Cep;

			}
			set { 
				 sdt.gxTpr_Cep = value;
			}
		}

		[JsonPropertyName("EnderecoCEP")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="EnderecoCEP", Order=18)]
		public  string gxTpr_Enderecocep
		{
			get { 
				return sdt.gxTpr_Enderecocep;

			}
			set { 
				 sdt.gxTpr_Enderecocep = value;
			}
		}

		[JsonPropertyName("EnderecoLogradouro")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="EnderecoLogradouro", Order=19)]
		public  string gxTpr_Enderecologradouro
		{
			get { 
				return sdt.gxTpr_Enderecologradouro;

			}
			set { 
				 sdt.gxTpr_Enderecologradouro = value;
			}
		}

		[JsonPropertyName("EnderecoNumero")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="EnderecoNumero", Order=20)]
		public  string gxTpr_Endereconumero
		{
			get { 
				return sdt.gxTpr_Endereconumero;

			}
			set { 
				 sdt.gxTpr_Endereconumero = value;
			}
		}

		[JsonPropertyName("EnderecoComplemento")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="EnderecoComplemento", Order=21)]
		public  string gxTpr_Enderecocomplemento
		{
			get { 
				return sdt.gxTpr_Enderecocomplemento;

			}
			set { 
				 sdt.gxTpr_Enderecocomplemento = value;
			}
		}

		[JsonPropertyName("EnderecoBairro")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="EnderecoBairro", Order=22)]
		public  string gxTpr_Enderecobairro
		{
			get { 
				return sdt.gxTpr_Enderecobairro;

			}
			set { 
				 sdt.gxTpr_Enderecobairro = value;
			}
		}

		[JsonPropertyName("EnderecoCidade")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="EnderecoCidade", Order=23)]
		public  string gxTpr_Enderecocidade
		{
			get { 
				return sdt.gxTpr_Enderecocidade;

			}
			set { 
				 sdt.gxTpr_Enderecocidade = value;
			}
		}

		[JsonPropertyName("MunicipioCodigo")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="MunicipioCodigo", Order=24)]
		public  string gxTpr_Municipiocodigo
		{
			get { 
				return sdt.gxTpr_Municipiocodigo;

			}
			set { 
				 sdt.gxTpr_Municipiocodigo = value;
			}
		}

		[JsonPropertyName("MunicipioNome")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="MunicipioNome", Order=25)]
		public  string gxTpr_Municipionome
		{
			get { 
				return sdt.gxTpr_Municipionome;

			}
			set { 
				 sdt.gxTpr_Municipionome = value;
			}
		}

		[JsonPropertyName("MunicipioUF")]
		[JsonPropertyOrder(26)]
		[DataMember(Name="MunicipioUF", Order=26)]
		public  string gxTpr_Municipiouf
		{
			get { 
				return sdt.gxTpr_Municipiouf;

			}
			set { 
				 sdt.gxTpr_Municipiouf = value;
			}
		}

		[JsonPropertyName("ClienteNomeFantasia")]
		[JsonPropertyOrder(27)]
		[DataMember(Name="ClienteNomeFantasia", Order=27)]
		public  string gxTpr_Clientenomefantasia
		{
			get { 
				return sdt.gxTpr_Clientenomefantasia;

			}
			set { 
				 sdt.gxTpr_Clientenomefantasia = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_NovoCliente sdt
		{
			get { 
				return (SdtWPropostaData_NovoCliente)Sdt;
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
				sdt = new SdtWPropostaData_NovoCliente() ;
			}
		}
	}
	#endregion
}