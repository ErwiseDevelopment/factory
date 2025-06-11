/*
				   File: type_SdtSdSerasa_enderecoPessoal
			Description: enderecoPessoal
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
	[XmlRoot(ElementName="SdSerasa.enderecoPessoal")]
	[XmlType(TypeName="SdSerasa.enderecoPessoal" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_enderecoPessoal : GxUserType
	{
		public SdtSdSerasa_enderecoPessoal( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasa_enderecoPessoal_Endereco = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Numerocasa = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Complemento = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Bairro = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Cidade = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Estado = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Cep = "";

			gxTv_SdtSdSerasa_enderecoPessoal_Telefone = "";

		}

		public SdtSdSerasa_enderecoPessoal(IGxContext context)
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
			AddObjectProperty("endereco", gxTpr_Endereco, false);


			AddObjectProperty("numeroCasa", gxTpr_Numerocasa, false);


			AddObjectProperty("complemento", gxTpr_Complemento, false);


			AddObjectProperty("bairro", gxTpr_Bairro, false);


			AddObjectProperty("cidade", gxTpr_Cidade, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			AddObjectProperty("cep", gxTpr_Cep, false);


			AddObjectProperty("telefone", gxTpr_Telefone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="endereco")]
		[XmlElement(ElementName="endereco")]
		public string gxTpr_Endereco
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Endereco; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Endereco = value;
				SetDirty("Endereco");
			}
		}




		[SoapElement(ElementName="numeroCasa")]
		[XmlElement(ElementName="numeroCasa")]
		public string gxTpr_Numerocasa
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Numerocasa; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Numerocasa = value;
				SetDirty("Numerocasa");
			}
		}




		[SoapElement(ElementName="complemento")]
		[XmlElement(ElementName="complemento")]
		public string gxTpr_Complemento
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Complemento; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Complemento = value;
				SetDirty("Complemento");
			}
		}




		[SoapElement(ElementName="bairro")]
		[XmlElement(ElementName="bairro")]
		public string gxTpr_Bairro
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Bairro; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Bairro = value;
				SetDirty("Bairro");
			}
		}




		[SoapElement(ElementName="cidade")]
		[XmlElement(ElementName="cidade")]
		public string gxTpr_Cidade
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Cidade; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Cidade = value;
				SetDirty("Cidade");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Estado; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="cep")]
		[XmlElement(ElementName="cep")]
		public string gxTpr_Cep
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Cep; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Cep = value;
				SetDirty("Cep");
			}
		}




		[SoapElement(ElementName="telefone")]
		[XmlElement(ElementName="telefone")]
		public string gxTpr_Telefone
		{
			get {
				return gxTv_SdtSdSerasa_enderecoPessoal_Telefone; 
			}
			set {
				gxTv_SdtSdSerasa_enderecoPessoal_Telefone = value;
				SetDirty("Telefone");
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
			gxTv_SdtSdSerasa_enderecoPessoal_Endereco = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Numerocasa = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Complemento = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Bairro = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Cidade = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Estado = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Cep = "";
			gxTv_SdtSdSerasa_enderecoPessoal_Telefone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Endereco;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Numerocasa;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Complemento;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Bairro;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Cidade;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Estado;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Cep;
		 

		protected string gxTv_SdtSdSerasa_enderecoPessoal_Telefone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.enderecoPessoal", Namespace="Factory21")]
	public class SdtSdSerasa_enderecoPessoal_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_enderecoPessoal>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_enderecoPessoal_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_enderecoPessoal_RESTInterface( SdtSdSerasa_enderecoPessoal psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("endereco")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="endereco", Order=0)]
		public  string gxTpr_Endereco
		{
			get { 
				return sdt.gxTpr_Endereco;

			}
			set { 
				 sdt.gxTpr_Endereco = value;
			}
		}

		[JsonPropertyName("numeroCasa")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="numeroCasa", Order=1)]
		public  string gxTpr_Numerocasa
		{
			get { 
				return sdt.gxTpr_Numerocasa;

			}
			set { 
				 sdt.gxTpr_Numerocasa = value;
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

		[JsonPropertyName("cidade")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="cidade", Order=4)]
		public  string gxTpr_Cidade
		{
			get { 
				return sdt.gxTpr_Cidade;

			}
			set { 
				 sdt.gxTpr_Cidade = value;
			}
		}

		[JsonPropertyName("estado")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="estado", Order=5)]
		public  string gxTpr_Estado
		{
			get { 
				return sdt.gxTpr_Estado;

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[JsonPropertyName("cep")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="cep", Order=6)]
		public  string gxTpr_Cep
		{
			get { 
				return sdt.gxTpr_Cep;

			}
			set { 
				 sdt.gxTpr_Cep = value;
			}
		}

		[JsonPropertyName("telefone")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="telefone", Order=7)]
		public  string gxTpr_Telefone
		{
			get { 
				return sdt.gxTpr_Telefone;

			}
			set { 
				 sdt.gxTpr_Telefone = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_enderecoPessoal sdt
		{
			get { 
				return (SdtSdSerasa_enderecoPessoal)Sdt;
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
				sdt = new SdtSdSerasa_enderecoPessoal() ;
			}
		}
	}
	#endregion
}