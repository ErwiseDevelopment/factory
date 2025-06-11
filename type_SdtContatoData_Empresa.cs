/*
				   File: type_SdtContatoData_Empresa
			Description: Empresa
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
	[XmlRoot(ElementName="ContatoData.Empresa")]
	[XmlType(TypeName="ContatoData.Empresa" , Namespace="Factory21" )]
	[Serializable]
	public class SdtContatoData_Empresa : GxUserType
	{
		public SdtContatoData_Empresa( )
		{
			/* Constructor for serialization */
			gxTv_SdtContatoData_Empresa_Clientenomefantasia = "";

			gxTv_SdtContatoData_Empresa_Clienterazaosocial = "";

			gxTv_SdtContatoData_Empresa_Enderecocep = "";

			gxTv_SdtContatoData_Empresa_Enderecologradouro = "";

			gxTv_SdtContatoData_Empresa_Endereconumero = "";

			gxTv_SdtContatoData_Empresa_Enderecobairro = "";

			gxTv_SdtContatoData_Empresa_Enderecocomplemento = "";

			gxTv_SdtContatoData_Empresa_Contatoemail = "";

			gxTv_SdtContatoData_Empresa_Municipionome = "";

			gxTv_SdtContatoData_Empresa_Municipiouf = "";

			gxTv_SdtContatoData_Empresa_Municipiocodigo = "";


		}

		public SdtContatoData_Empresa(IGxContext context)
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


			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("EnderecoCEP", gxTpr_Enderecocep, false);


			AddObjectProperty("EnderecoLogradouro", gxTpr_Enderecologradouro, false);


			AddObjectProperty("EnderecoNumero", gxTpr_Endereconumero, false);


			AddObjectProperty("EnderecoBairro", gxTpr_Enderecobairro, false);


			AddObjectProperty("EnderecoComplemento", gxTpr_Enderecocomplemento, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);


			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("ContatoTelefoneDDD", gxTpr_Contatotelefoneddd, false);


			AddObjectProperty("ContatoTelefoneNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatotelefonenumero, 18, 0)), false);


			AddObjectProperty("ContatoDDD", gxTpr_Contatoddd, false);


			AddObjectProperty("ContatoNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contatonumero, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteNomeFantasia")]
		[XmlElement(ElementName="ClienteNomeFantasia")]
		public string gxTpr_Clientenomefantasia
		{
			get {
				return gxTv_SdtContatoData_Empresa_Clientenomefantasia; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Clientenomefantasia = value;
				SetDirty("Clientenomefantasia");
			}
		}




		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtContatoData_Empresa_Clienterazaosocial; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="EnderecoCEP")]
		[XmlElement(ElementName="EnderecoCEP")]
		public string gxTpr_Enderecocep
		{
			get {
				return gxTv_SdtContatoData_Empresa_Enderecocep; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Enderecocep = value;
				SetDirty("Enderecocep");
			}
		}




		[SoapElement(ElementName="EnderecoLogradouro")]
		[XmlElement(ElementName="EnderecoLogradouro")]
		public string gxTpr_Enderecologradouro
		{
			get {
				return gxTv_SdtContatoData_Empresa_Enderecologradouro; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Enderecologradouro = value;
				SetDirty("Enderecologradouro");
			}
		}




		[SoapElement(ElementName="EnderecoNumero")]
		[XmlElement(ElementName="EnderecoNumero")]
		public string gxTpr_Endereconumero
		{
			get {
				return gxTv_SdtContatoData_Empresa_Endereconumero; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Endereconumero = value;
				SetDirty("Endereconumero");
			}
		}




		[SoapElement(ElementName="EnderecoBairro")]
		[XmlElement(ElementName="EnderecoBairro")]
		public string gxTpr_Enderecobairro
		{
			get {
				return gxTv_SdtContatoData_Empresa_Enderecobairro; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Enderecobairro = value;
				SetDirty("Enderecobairro");
			}
		}




		[SoapElement(ElementName="EnderecoComplemento")]
		[XmlElement(ElementName="EnderecoComplemento")]
		public string gxTpr_Enderecocomplemento
		{
			get {
				return gxTv_SdtContatoData_Empresa_Enderecocomplemento; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Enderecocomplemento = value;
				SetDirty("Enderecocomplemento");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtContatoData_Empresa_Contatoemail; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtContatoData_Empresa_Municipionome; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtContatoData_Empresa_Municipiouf; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Municipiouf = value;
				SetDirty("Municipiouf");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtContatoData_Empresa_Municipiocodigo; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneDDD")]
		[XmlElement(ElementName="ContatoTelefoneDDD")]
		public short gxTpr_Contatotelefoneddd
		{
			get {
				return gxTv_SdtContatoData_Empresa_Contatotelefoneddd; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Contatotelefoneddd = value;
				SetDirty("Contatotelefoneddd");
			}
		}




		[SoapElement(ElementName="ContatoTelefoneNumero")]
		[XmlElement(ElementName="ContatoTelefoneNumero")]
		public long gxTpr_Contatotelefonenumero
		{
			get {
				return gxTv_SdtContatoData_Empresa_Contatotelefonenumero; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Contatotelefonenumero = value;
				SetDirty("Contatotelefonenumero");
			}
		}




		[SoapElement(ElementName="ContatoDDD")]
		[XmlElement(ElementName="ContatoDDD")]
		public short gxTpr_Contatoddd
		{
			get {
				return gxTv_SdtContatoData_Empresa_Contatoddd; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Contatoddd = value;
				SetDirty("Contatoddd");
			}
		}




		[SoapElement(ElementName="ContatoNumero")]
		[XmlElement(ElementName="ContatoNumero")]
		public long gxTpr_Contatonumero
		{
			get {
				return gxTv_SdtContatoData_Empresa_Contatonumero; 
			}
			set {
				gxTv_SdtContatoData_Empresa_Contatonumero = value;
				SetDirty("Contatonumero");
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
			gxTv_SdtContatoData_Empresa_Clientenomefantasia = "";
			gxTv_SdtContatoData_Empresa_Clienterazaosocial = "";
			gxTv_SdtContatoData_Empresa_Enderecocep = "";
			gxTv_SdtContatoData_Empresa_Enderecologradouro = "";
			gxTv_SdtContatoData_Empresa_Endereconumero = "";
			gxTv_SdtContatoData_Empresa_Enderecobairro = "";
			gxTv_SdtContatoData_Empresa_Enderecocomplemento = "";
			gxTv_SdtContatoData_Empresa_Contatoemail = "";
			gxTv_SdtContatoData_Empresa_Municipionome = "";
			gxTv_SdtContatoData_Empresa_Municipiouf = "";
			gxTv_SdtContatoData_Empresa_Municipiocodigo = "";




			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtContatoData_Empresa_Clientenomefantasia;
		 

		protected string gxTv_SdtContatoData_Empresa_Clienterazaosocial;
		 

		protected string gxTv_SdtContatoData_Empresa_Enderecocep;
		 

		protected string gxTv_SdtContatoData_Empresa_Enderecologradouro;
		 

		protected string gxTv_SdtContatoData_Empresa_Endereconumero;
		 

		protected string gxTv_SdtContatoData_Empresa_Enderecobairro;
		 

		protected string gxTv_SdtContatoData_Empresa_Enderecocomplemento;
		 

		protected string gxTv_SdtContatoData_Empresa_Contatoemail;
		 

		protected string gxTv_SdtContatoData_Empresa_Municipionome;
		 

		protected string gxTv_SdtContatoData_Empresa_Municipiouf;
		 

		protected string gxTv_SdtContatoData_Empresa_Municipiocodigo;
		 

		protected short gxTv_SdtContatoData_Empresa_Contatotelefoneddd;
		 

		protected long gxTv_SdtContatoData_Empresa_Contatotelefonenumero;
		 

		protected short gxTv_SdtContatoData_Empresa_Contatoddd;
		 

		protected long gxTv_SdtContatoData_Empresa_Contatonumero;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ContatoData.Empresa", Namespace="Factory21")]
	public class SdtContatoData_Empresa_RESTInterface : GxGenericCollectionItem<SdtContatoData_Empresa>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContatoData_Empresa_RESTInterface( ) : base()
		{	
		}

		public SdtContatoData_Empresa_RESTInterface( SdtContatoData_Empresa psdt ) : base(psdt)
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

		[JsonPropertyName("EnderecoCEP")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="EnderecoCEP", Order=2)]
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
		[JsonPropertyOrder(3)]
		[DataMember(Name="EnderecoLogradouro", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="EnderecoNumero", Order=4)]
		public  string gxTpr_Endereconumero
		{
			get { 
				return sdt.gxTpr_Endereconumero;

			}
			set { 
				 sdt.gxTpr_Endereconumero = value;
			}
		}

		[JsonPropertyName("EnderecoBairro")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="EnderecoBairro", Order=5)]
		public  string gxTpr_Enderecobairro
		{
			get { 
				return sdt.gxTpr_Enderecobairro;

			}
			set { 
				 sdt.gxTpr_Enderecobairro = value;
			}
		}

		[JsonPropertyName("EnderecoComplemento")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="EnderecoComplemento", Order=6)]
		public  string gxTpr_Enderecocomplemento
		{
			get { 
				return sdt.gxTpr_Enderecocomplemento;

			}
			set { 
				 sdt.gxTpr_Enderecocomplemento = value;
			}
		}

		[JsonPropertyName("ContatoEmail")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ContatoEmail", Order=7)]
		public  string gxTpr_Contatoemail
		{
			get { 
				return sdt.gxTpr_Contatoemail;

			}
			set { 
				 sdt.gxTpr_Contatoemail = value;
			}
		}

		[JsonPropertyName("MunicipioNome")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="MunicipioNome", Order=8)]
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
		[JsonPropertyOrder(9)]
		[DataMember(Name="MunicipioUF", Order=9)]
		public  string gxTpr_Municipiouf
		{
			get { 
				return sdt.gxTpr_Municipiouf;

			}
			set { 
				 sdt.gxTpr_Municipiouf = value;
			}
		}

		[JsonPropertyName("MunicipioCodigo")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="MunicipioCodigo", Order=10)]
		public  string gxTpr_Municipiocodigo
		{
			get { 
				return sdt.gxTpr_Municipiocodigo;

			}
			set { 
				 sdt.gxTpr_Municipiocodigo = value;
			}
		}

		[JsonPropertyName("ContatoTelefoneDDD")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ContatoTelefoneDDD", Order=11)]
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
		[JsonPropertyOrder(12)]
		[DataMember(Name="ContatoTelefoneNumero", Order=12)]
		public  string gxTpr_Contatotelefonenumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contatotelefonenumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contatotelefonenumero = (long) NumberUtil.Val( value, ".");
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


		#endregion
		[JsonIgnore]
		public SdtContatoData_Empresa sdt
		{
			get { 
				return (SdtContatoData_Empresa)Sdt;
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
				sdt = new SdtContatoData_Empresa() ;
			}
		}
	}
	#endregion
}