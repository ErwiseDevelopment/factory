/*
				   File: type_SdtSdEnderecoCliente
			Description: SdEnderecoCliente
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
	[XmlRoot(ElementName="SdEnderecoCliente")]
	[XmlType(TypeName="SdEnderecoCliente" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEnderecoCliente : GxUserType
	{
		public SdtSdEnderecoCliente( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEnderecoCliente_Enderecocep = "";

			gxTv_SdtSdEnderecoCliente_Enderecologradouro = "";

			gxTv_SdtSdEnderecoCliente_Enderecobairro = "";

			gxTv_SdtSdEnderecoCliente_Enderecocidade = "";

			gxTv_SdtSdEnderecoCliente_Municipiocodigo = "";

			gxTv_SdtSdEnderecoCliente_Endereconumero = "";

			gxTv_SdtSdEnderecoCliente_Enderecocomplemento = "";

		}

		public SdtSdEnderecoCliente(IGxContext context)
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
			AddObjectProperty("EnderecoCEP", gxTpr_Enderecocep, false);


			AddObjectProperty("EnderecoLogradouro", gxTpr_Enderecologradouro, false);


			AddObjectProperty("EnderecoBairro", gxTpr_Enderecobairro, false);


			AddObjectProperty("EnderecoCidade", gxTpr_Enderecocidade, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("EnderecoNumero", gxTpr_Endereconumero, false);


			AddObjectProperty("EnderecoComplemento", gxTpr_Enderecocomplemento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EnderecoCEP")]
		[XmlElement(ElementName="EnderecoCEP")]
		public string gxTpr_Enderecocep
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Enderecocep; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Enderecocep = value;
				SetDirty("Enderecocep");
			}
		}




		[SoapElement(ElementName="EnderecoLogradouro")]
		[XmlElement(ElementName="EnderecoLogradouro")]
		public string gxTpr_Enderecologradouro
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Enderecologradouro; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Enderecologradouro = value;
				SetDirty("Enderecologradouro");
			}
		}




		[SoapElement(ElementName="EnderecoBairro")]
		[XmlElement(ElementName="EnderecoBairro")]
		public string gxTpr_Enderecobairro
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Enderecobairro; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Enderecobairro = value;
				SetDirty("Enderecobairro");
			}
		}




		[SoapElement(ElementName="EnderecoCidade")]
		[XmlElement(ElementName="EnderecoCidade")]
		public string gxTpr_Enderecocidade
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Enderecocidade; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Enderecocidade = value;
				SetDirty("Enderecocidade");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Municipiocodigo; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="EnderecoNumero")]
		[XmlElement(ElementName="EnderecoNumero")]
		public string gxTpr_Endereconumero
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Endereconumero; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Endereconumero = value;
				SetDirty("Endereconumero");
			}
		}




		[SoapElement(ElementName="EnderecoComplemento")]
		[XmlElement(ElementName="EnderecoComplemento")]
		public string gxTpr_Enderecocomplemento
		{
			get {
				return gxTv_SdtSdEnderecoCliente_Enderecocomplemento; 
			}
			set {
				gxTv_SdtSdEnderecoCliente_Enderecocomplemento = value;
				SetDirty("Enderecocomplemento");
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
			gxTv_SdtSdEnderecoCliente_Enderecocep = "";
			gxTv_SdtSdEnderecoCliente_Enderecologradouro = "";
			gxTv_SdtSdEnderecoCliente_Enderecobairro = "";
			gxTv_SdtSdEnderecoCliente_Enderecocidade = "";
			gxTv_SdtSdEnderecoCliente_Municipiocodigo = "";
			gxTv_SdtSdEnderecoCliente_Endereconumero = "";
			gxTv_SdtSdEnderecoCliente_Enderecocomplemento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdEnderecoCliente_Enderecocep;
		 

		protected string gxTv_SdtSdEnderecoCliente_Enderecologradouro;
		 

		protected string gxTv_SdtSdEnderecoCliente_Enderecobairro;
		 

		protected string gxTv_SdtSdEnderecoCliente_Enderecocidade;
		 

		protected string gxTv_SdtSdEnderecoCliente_Municipiocodigo;
		 

		protected string gxTv_SdtSdEnderecoCliente_Endereconumero;
		 

		protected string gxTv_SdtSdEnderecoCliente_Enderecocomplemento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEnderecoCliente", Namespace="Factory21")]
	public class SdtSdEnderecoCliente_RESTInterface : GxGenericCollectionItem<SdtSdEnderecoCliente>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEnderecoCliente_RESTInterface( ) : base()
		{	
		}

		public SdtSdEnderecoCliente_RESTInterface( SdtSdEnderecoCliente psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("EnderecoCEP")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="EnderecoCEP", Order=0)]
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
		[JsonPropertyOrder(1)]
		[DataMember(Name="EnderecoLogradouro", Order=1)]
		public  string gxTpr_Enderecologradouro
		{
			get { 
				return sdt.gxTpr_Enderecologradouro;

			}
			set { 
				 sdt.gxTpr_Enderecologradouro = value;
			}
		}

		[JsonPropertyName("EnderecoBairro")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="EnderecoBairro", Order=2)]
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
		[JsonPropertyOrder(3)]
		[DataMember(Name="EnderecoCidade", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="MunicipioCodigo", Order=4)]
		public  string gxTpr_Municipiocodigo
		{
			get { 
				return sdt.gxTpr_Municipiocodigo;

			}
			set { 
				 sdt.gxTpr_Municipiocodigo = value;
			}
		}

		[JsonPropertyName("EnderecoNumero")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="EnderecoNumero", Order=5)]
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


		#endregion
		[JsonIgnore]
		public SdtSdEnderecoCliente sdt
		{
			get { 
				return (SdtSdEnderecoCliente)Sdt;
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
				sdt = new SdtSdEnderecoCliente() ;
			}
		}
	}
	#endregion
}