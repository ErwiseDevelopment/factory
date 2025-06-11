/*
				   File: type_SdtEnderecoCompleto
			Description: EnderecoCompleto
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

using GeneXus.Programs;
using GeneXus.Programs.myobjects;
namespace GeneXus.Programs.myobjects.viacep
{
	[XmlRoot(ElementName="EnderecoCompleto")]
	[XmlType(TypeName="EnderecoCompleto" , Namespace="Factory21" )]
	[Serializable]
	public class SdtEnderecoCompleto : GxUserType
	{
		public SdtEnderecoCompleto( )
		{
			/* Constructor for serialization */
			gxTv_SdtEnderecoCompleto_Cep = "";

			gxTv_SdtEnderecoCompleto_Logradouro = "";

			gxTv_SdtEnderecoCompleto_Complemento = "";

			gxTv_SdtEnderecoCompleto_Bairro = "";

			gxTv_SdtEnderecoCompleto_Localidade = "";

			gxTv_SdtEnderecoCompleto_Uf = "";

			gxTv_SdtEnderecoCompleto_Unidade = "";

			gxTv_SdtEnderecoCompleto_Ibge = "";

			gxTv_SdtEnderecoCompleto_Gia = "";

			gxTv_SdtEnderecoCompleto_Ddd = "";

		}

		public SdtEnderecoCompleto(IGxContext context)
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
			AddObjectProperty("cep", gxTpr_Cep, false);


			AddObjectProperty("logradouro", gxTpr_Logradouro, false);


			AddObjectProperty("complemento", gxTpr_Complemento, false);


			AddObjectProperty("bairro", gxTpr_Bairro, false);


			AddObjectProperty("localidade", gxTpr_Localidade, false);


			AddObjectProperty("uf", gxTpr_Uf, false);


			AddObjectProperty("unidade", gxTpr_Unidade, false);


			AddObjectProperty("ibge", gxTpr_Ibge, false);


			AddObjectProperty("gia", gxTpr_Gia, false);


			AddObjectProperty("ddd", gxTpr_Ddd, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cep")]
		[XmlElement(ElementName="cep")]
		public string gxTpr_Cep
		{
			get {
				return gxTv_SdtEnderecoCompleto_Cep; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Cep = value;
				SetDirty("Cep");
			}
		}




		[SoapElement(ElementName="logradouro")]
		[XmlElement(ElementName="logradouro")]
		public string gxTpr_Logradouro
		{
			get {
				return gxTv_SdtEnderecoCompleto_Logradouro; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Logradouro = value;
				SetDirty("Logradouro");
			}
		}




		[SoapElement(ElementName="complemento")]
		[XmlElement(ElementName="complemento")]
		public string gxTpr_Complemento
		{
			get {
				return gxTv_SdtEnderecoCompleto_Complemento; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Complemento = value;
				SetDirty("Complemento");
			}
		}




		[SoapElement(ElementName="bairro")]
		[XmlElement(ElementName="bairro")]
		public string gxTpr_Bairro
		{
			get {
				return gxTv_SdtEnderecoCompleto_Bairro; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Bairro = value;
				SetDirty("Bairro");
			}
		}




		[SoapElement(ElementName="localidade")]
		[XmlElement(ElementName="localidade")]
		public string gxTpr_Localidade
		{
			get {
				return gxTv_SdtEnderecoCompleto_Localidade; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Localidade = value;
				SetDirty("Localidade");
			}
		}




		[SoapElement(ElementName="uf")]
		[XmlElement(ElementName="uf")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtEnderecoCompleto_Uf; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Uf = value;
				SetDirty("Uf");
			}
		}




		[SoapElement(ElementName="unidade")]
		[XmlElement(ElementName="unidade")]
		public string gxTpr_Unidade
		{
			get {
				return gxTv_SdtEnderecoCompleto_Unidade; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Unidade = value;
				SetDirty("Unidade");
			}
		}




		[SoapElement(ElementName="ibge")]
		[XmlElement(ElementName="ibge")]
		public string gxTpr_Ibge
		{
			get {
				return gxTv_SdtEnderecoCompleto_Ibge; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Ibge = value;
				SetDirty("Ibge");
			}
		}




		[SoapElement(ElementName="gia")]
		[XmlElement(ElementName="gia")]
		public string gxTpr_Gia
		{
			get {
				return gxTv_SdtEnderecoCompleto_Gia; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Gia = value;
				SetDirty("Gia");
			}
		}




		[SoapElement(ElementName="ddd")]
		[XmlElement(ElementName="ddd")]
		public string gxTpr_Ddd
		{
			get {
				return gxTv_SdtEnderecoCompleto_Ddd; 
			}
			set {
				gxTv_SdtEnderecoCompleto_Ddd = value;
				SetDirty("Ddd");
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
			gxTv_SdtEnderecoCompleto_Cep = "";
			gxTv_SdtEnderecoCompleto_Logradouro = "";
			gxTv_SdtEnderecoCompleto_Complemento = "";
			gxTv_SdtEnderecoCompleto_Bairro = "";
			gxTv_SdtEnderecoCompleto_Localidade = "";
			gxTv_SdtEnderecoCompleto_Uf = "";
			gxTv_SdtEnderecoCompleto_Unidade = "";
			gxTv_SdtEnderecoCompleto_Ibge = "";
			gxTv_SdtEnderecoCompleto_Gia = "";
			gxTv_SdtEnderecoCompleto_Ddd = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtEnderecoCompleto_Cep;
		 

		protected string gxTv_SdtEnderecoCompleto_Logradouro;
		 

		protected string gxTv_SdtEnderecoCompleto_Complemento;
		 

		protected string gxTv_SdtEnderecoCompleto_Bairro;
		 

		protected string gxTv_SdtEnderecoCompleto_Localidade;
		 

		protected string gxTv_SdtEnderecoCompleto_Uf;
		 

		protected string gxTv_SdtEnderecoCompleto_Unidade;
		 

		protected string gxTv_SdtEnderecoCompleto_Ibge;
		 

		protected string gxTv_SdtEnderecoCompleto_Gia;
		 

		protected string gxTv_SdtEnderecoCompleto_Ddd;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"EnderecoCompleto", Namespace="Factory21")]
	public class SdtEnderecoCompleto_RESTInterface : GxGenericCollectionItem<SdtEnderecoCompleto>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtEnderecoCompleto_RESTInterface( ) : base()
		{	
		}

		public SdtEnderecoCompleto_RESTInterface( SdtEnderecoCompleto psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("cep")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="cep", Order=0)]
		public  string gxTpr_Cep
		{
			get { 
				return sdt.gxTpr_Cep;

			}
			set { 
				 sdt.gxTpr_Cep = value;
			}
		}

		[JsonPropertyName("logradouro")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="logradouro", Order=1)]
		public  string gxTpr_Logradouro
		{
			get { 
				return sdt.gxTpr_Logradouro;

			}
			set { 
				 sdt.gxTpr_Logradouro = value;
			}
		}

		[JsonPropertyName("complemento")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="complemento", Order=2)]
		public  string gxTpr_Complemento
		{
			get { 
				return sdt.gxTpr_Complemento;

			}
			set { 
				 sdt.gxTpr_Complemento = value;
			}
		}

		[JsonPropertyName("bairro")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="bairro", Order=3)]
		public  string gxTpr_Bairro
		{
			get { 
				return sdt.gxTpr_Bairro;

			}
			set { 
				 sdt.gxTpr_Bairro = value;
			}
		}

		[JsonPropertyName("localidade")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="localidade", Order=4)]
		public  string gxTpr_Localidade
		{
			get { 
				return sdt.gxTpr_Localidade;

			}
			set { 
				 sdt.gxTpr_Localidade = value;
			}
		}

		[JsonPropertyName("uf")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="uf", Order=5)]
		public  string gxTpr_Uf
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Uf);

			}
			set { 
				 sdt.gxTpr_Uf = value;
			}
		}

		[JsonPropertyName("unidade")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="unidade", Order=6)]
		public  string gxTpr_Unidade
		{
			get { 
				return sdt.gxTpr_Unidade;

			}
			set { 
				 sdt.gxTpr_Unidade = value;
			}
		}

		[JsonPropertyName("ibge")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ibge", Order=7)]
		public  string gxTpr_Ibge
		{
			get { 
				return sdt.gxTpr_Ibge;

			}
			set { 
				 sdt.gxTpr_Ibge = value;
			}
		}

		[JsonPropertyName("gia")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="gia", Order=8)]
		public  string gxTpr_Gia
		{
			get { 
				return sdt.gxTpr_Gia;

			}
			set { 
				 sdt.gxTpr_Gia = value;
			}
		}

		[JsonPropertyName("ddd")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ddd", Order=9)]
		public  string gxTpr_Ddd
		{
			get { 
				return sdt.gxTpr_Ddd;

			}
			set { 
				 sdt.gxTpr_Ddd = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtEnderecoCompleto sdt
		{
			get { 
				return (SdtEnderecoCompleto)Sdt;
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
				sdt = new SdtEnderecoCompleto() ;
			}
		}
	}
	#endregion
}