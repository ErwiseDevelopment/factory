/*
				   File: type_SdtContatoData_CNPJ
			Description: CNPJ
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
	[XmlRoot(ElementName="ContatoData.CNPJ")]
	[XmlType(TypeName="ContatoData.CNPJ" , Namespace="Factory21" )]
	[Serializable]
	public class SdtContatoData_CNPJ : GxUserType
	{
		public SdtContatoData_CNPJ( )
		{
			/* Constructor for serialization */
			gxTv_SdtContatoData_CNPJ_Clientenomefantasia = "";

			gxTv_SdtContatoData_CNPJ_Clienterazaosocial = "";

			gxTv_SdtContatoData_CNPJ_Enderecologradouro = "";

			gxTv_SdtContatoData_CNPJ_Endereconumero = "";

			gxTv_SdtContatoData_CNPJ_Enderecobairro = "";

			gxTv_SdtContatoData_CNPJ_Enderecocep = "";

			gxTv_SdtContatoData_CNPJ_Enderecocomplemento = "";

			gxTv_SdtContatoData_CNPJ_Contatoemail = "";

			gxTv_SdtContatoData_CNPJ_Municipionome = "";

			gxTv_SdtContatoData_CNPJ_Municipiouf = "";

			gxTv_SdtContatoData_CNPJ_Municipiocodigo = "";

			gxTv_SdtContatoData_CNPJ_Clientedocumento = "";

		}

		public SdtContatoData_CNPJ(IGxContext context)
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


			AddObjectProperty("EnderecoLogradouro", gxTpr_Enderecologradouro, false);


			AddObjectProperty("EnderecoNumero", gxTpr_Endereconumero, false);


			AddObjectProperty("EnderecoBairro", gxTpr_Enderecobairro, false);


			AddObjectProperty("EnderecoCEP", gxTpr_Enderecocep, false);


			AddObjectProperty("EnderecoComplemento", gxTpr_Enderecocomplemento, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);


			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("ClienteDocumento", gxTpr_Clientedocumento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteNomeFantasia")]
		[XmlElement(ElementName="ClienteNomeFantasia")]
		public string gxTpr_Clientenomefantasia
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Clientenomefantasia; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Clientenomefantasia = value;
				SetDirty("Clientenomefantasia");
			}
		}




		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Clienterazaosocial; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="EnderecoLogradouro")]
		[XmlElement(ElementName="EnderecoLogradouro")]
		public string gxTpr_Enderecologradouro
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Enderecologradouro; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Enderecologradouro = value;
				SetDirty("Enderecologradouro");
			}
		}




		[SoapElement(ElementName="EnderecoNumero")]
		[XmlElement(ElementName="EnderecoNumero")]
		public string gxTpr_Endereconumero
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Endereconumero; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Endereconumero = value;
				SetDirty("Endereconumero");
			}
		}




		[SoapElement(ElementName="EnderecoBairro")]
		[XmlElement(ElementName="EnderecoBairro")]
		public string gxTpr_Enderecobairro
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Enderecobairro; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Enderecobairro = value;
				SetDirty("Enderecobairro");
			}
		}




		[SoapElement(ElementName="EnderecoCEP")]
		[XmlElement(ElementName="EnderecoCEP")]
		public string gxTpr_Enderecocep
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Enderecocep; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Enderecocep = value;
				SetDirty("Enderecocep");
			}
		}




		[SoapElement(ElementName="EnderecoComplemento")]
		[XmlElement(ElementName="EnderecoComplemento")]
		public string gxTpr_Enderecocomplemento
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Enderecocomplemento; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Enderecocomplemento = value;
				SetDirty("Enderecocomplemento");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Contatoemail; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Municipionome; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Municipiouf; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Municipiouf = value;
				SetDirty("Municipiouf");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Municipiocodigo; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtContatoData_CNPJ_Clientedocumento; 
			}
			set {
				gxTv_SdtContatoData_CNPJ_Clientedocumento = value;
				SetDirty("Clientedocumento");
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
			gxTv_SdtContatoData_CNPJ_Clientenomefantasia = "";
			gxTv_SdtContatoData_CNPJ_Clienterazaosocial = "";
			gxTv_SdtContatoData_CNPJ_Enderecologradouro = "";
			gxTv_SdtContatoData_CNPJ_Endereconumero = "";
			gxTv_SdtContatoData_CNPJ_Enderecobairro = "";
			gxTv_SdtContatoData_CNPJ_Enderecocep = "";
			gxTv_SdtContatoData_CNPJ_Enderecocomplemento = "";
			gxTv_SdtContatoData_CNPJ_Contatoemail = "";
			gxTv_SdtContatoData_CNPJ_Municipionome = "";
			gxTv_SdtContatoData_CNPJ_Municipiouf = "";
			gxTv_SdtContatoData_CNPJ_Municipiocodigo = "";
			gxTv_SdtContatoData_CNPJ_Clientedocumento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtContatoData_CNPJ_Clientenomefantasia;
		 

		protected string gxTv_SdtContatoData_CNPJ_Clienterazaosocial;
		 

		protected string gxTv_SdtContatoData_CNPJ_Enderecologradouro;
		 

		protected string gxTv_SdtContatoData_CNPJ_Endereconumero;
		 

		protected string gxTv_SdtContatoData_CNPJ_Enderecobairro;
		 

		protected string gxTv_SdtContatoData_CNPJ_Enderecocep;
		 

		protected string gxTv_SdtContatoData_CNPJ_Enderecocomplemento;
		 

		protected string gxTv_SdtContatoData_CNPJ_Contatoemail;
		 

		protected string gxTv_SdtContatoData_CNPJ_Municipionome;
		 

		protected string gxTv_SdtContatoData_CNPJ_Municipiouf;
		 

		protected string gxTv_SdtContatoData_CNPJ_Municipiocodigo;
		 

		protected string gxTv_SdtContatoData_CNPJ_Clientedocumento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ContatoData.CNPJ", Namespace="Factory21")]
	public class SdtContatoData_CNPJ_RESTInterface : GxGenericCollectionItem<SdtContatoData_CNPJ>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContatoData_CNPJ_RESTInterface( ) : base()
		{	
		}

		public SdtContatoData_CNPJ_RESTInterface( SdtContatoData_CNPJ psdt ) : base(psdt)
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

		[JsonPropertyName("EnderecoLogradouro")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="EnderecoLogradouro", Order=2)]
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
		[JsonPropertyOrder(3)]
		[DataMember(Name="EnderecoNumero", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="EnderecoBairro", Order=4)]
		public  string gxTpr_Enderecobairro
		{
			get { 
				return sdt.gxTpr_Enderecobairro;

			}
			set { 
				 sdt.gxTpr_Enderecobairro = value;
			}
		}

		[JsonPropertyName("EnderecoCEP")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="EnderecoCEP", Order=5)]
		public  string gxTpr_Enderecocep
		{
			get { 
				return sdt.gxTpr_Enderecocep;

			}
			set { 
				 sdt.gxTpr_Enderecocep = value;
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

		[JsonPropertyName("ClienteDocumento")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ClienteDocumento", Order=11)]
		public  string gxTpr_Clientedocumento
		{
			get { 
				return sdt.gxTpr_Clientedocumento;

			}
			set { 
				 sdt.gxTpr_Clientedocumento = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtContatoData_CNPJ sdt
		{
			get { 
				return (SdtContatoData_CNPJ)Sdt;
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
				sdt = new SdtContatoData_CNPJ() ;
			}
		}
	}
	#endregion
}