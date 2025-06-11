/*
				   File: type_SdtSdConteudoRecomendaPF_data_enderecosItem
			Description: enderecos
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.enderecosItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.enderecosItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_enderecosItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_enderecosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Endereco = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cidade = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Complemento = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Bairro = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Numerocasa = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Estado = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefone = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefone = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cep = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefonecoml = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefonecoml = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Celular = "";

			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddcelular = "";

		}

		public SdtSdConteudoRecomendaPF_data_enderecosItem(IGxContext context)
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


			AddObjectProperty("cidade", gxTpr_Cidade, false);


			AddObjectProperty("complemento", gxTpr_Complemento, false);


			AddObjectProperty("bairro", gxTpr_Bairro, false);


			AddObjectProperty("numeroCasa", gxTpr_Numerocasa, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			AddObjectProperty("telefone", gxTpr_Telefone, false);


			AddObjectProperty("dddTelefone", gxTpr_Dddtelefone, false);


			AddObjectProperty("cep", gxTpr_Cep, false);


			AddObjectProperty("telefoneComl", gxTpr_Telefonecoml, false);


			AddObjectProperty("dddTelefoneComl", gxTpr_Dddtelefonecoml, false);


			AddObjectProperty("celular", gxTpr_Celular, false);


			AddObjectProperty("dddCelular", gxTpr_Dddcelular, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="endereco")]
		[XmlElement(ElementName="endereco")]
		public string gxTpr_Endereco
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Endereco; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Endereco = value;
				SetDirty("Endereco");
			}
		}




		[SoapElement(ElementName="cidade")]
		[XmlElement(ElementName="cidade")]
		public string gxTpr_Cidade
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cidade; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cidade = value;
				SetDirty("Cidade");
			}
		}




		[SoapElement(ElementName="complemento")]
		[XmlElement(ElementName="complemento")]
		public string gxTpr_Complemento
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Complemento; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Complemento = value;
				SetDirty("Complemento");
			}
		}




		[SoapElement(ElementName="bairro")]
		[XmlElement(ElementName="bairro")]
		public string gxTpr_Bairro
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Bairro; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Bairro = value;
				SetDirty("Bairro");
			}
		}




		[SoapElement(ElementName="numeroCasa")]
		[XmlElement(ElementName="numeroCasa")]
		public string gxTpr_Numerocasa
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Numerocasa; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Numerocasa = value;
				SetDirty("Numerocasa");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Estado; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="telefone")]
		[XmlElement(ElementName="telefone")]
		public string gxTpr_Telefone
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefone; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefone = value;
				SetDirty("Telefone");
			}
		}




		[SoapElement(ElementName="dddTelefone")]
		[XmlElement(ElementName="dddTelefone")]
		public string gxTpr_Dddtelefone
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefone; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefone = value;
				SetDirty("Dddtelefone");
			}
		}




		[SoapElement(ElementName="cep")]
		[XmlElement(ElementName="cep")]
		public string gxTpr_Cep
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cep; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cep = value;
				SetDirty("Cep");
			}
		}




		[SoapElement(ElementName="telefoneComl")]
		[XmlElement(ElementName="telefoneComl")]
		public string gxTpr_Telefonecoml
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefonecoml; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefonecoml = value;
				SetDirty("Telefonecoml");
			}
		}




		[SoapElement(ElementName="dddTelefoneComl")]
		[XmlElement(ElementName="dddTelefoneComl")]
		public string gxTpr_Dddtelefonecoml
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefonecoml; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefonecoml = value;
				SetDirty("Dddtelefonecoml");
			}
		}




		[SoapElement(ElementName="celular")]
		[XmlElement(ElementName="celular")]
		public string gxTpr_Celular
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Celular; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Celular = value;
				SetDirty("Celular");
			}
		}




		[SoapElement(ElementName="dddCelular")]
		[XmlElement(ElementName="dddCelular")]
		public string gxTpr_Dddcelular
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddcelular; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddcelular = value;
				SetDirty("Dddcelular");
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
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Endereco = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cidade = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Complemento = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Bairro = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Numerocasa = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Estado = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefone = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefone = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cep = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefonecoml = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefonecoml = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Celular = "";
			gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddcelular = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Endereco;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cidade;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Complemento;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Bairro;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Numerocasa;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Estado;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefone;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefone;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Cep;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Telefonecoml;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddtelefonecoml;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Celular;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_enderecosItem_Dddcelular;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.enderecosItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_enderecosItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_enderecosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_enderecosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_enderecosItem_RESTInterface( SdtSdConteudoRecomendaPF_data_enderecosItem psdt ) : base(psdt)
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

		[JsonPropertyName("cidade")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="cidade", Order=1)]
		public  string gxTpr_Cidade
		{
			get { 
				return sdt.gxTpr_Cidade;

			}
			set { 
				 sdt.gxTpr_Cidade = value;
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

		[JsonPropertyName("numeroCasa")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="numeroCasa", Order=4)]
		public  string gxTpr_Numerocasa
		{
			get { 
				return sdt.gxTpr_Numerocasa;

			}
			set { 
				 sdt.gxTpr_Numerocasa = value;
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

		[JsonPropertyName("telefone")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="telefone", Order=6)]
		public  string gxTpr_Telefone
		{
			get { 
				return sdt.gxTpr_Telefone;

			}
			set { 
				 sdt.gxTpr_Telefone = value;
			}
		}

		[JsonPropertyName("dddTelefone")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="dddTelefone", Order=7)]
		public  string gxTpr_Dddtelefone
		{
			get { 
				return sdt.gxTpr_Dddtelefone;

			}
			set { 
				 sdt.gxTpr_Dddtelefone = value;
			}
		}

		[JsonPropertyName("cep")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="cep", Order=8)]
		public  string gxTpr_Cep
		{
			get { 
				return sdt.gxTpr_Cep;

			}
			set { 
				 sdt.gxTpr_Cep = value;
			}
		}

		[JsonPropertyName("telefoneComl")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="telefoneComl", Order=9)]
		public  string gxTpr_Telefonecoml
		{
			get { 
				return sdt.gxTpr_Telefonecoml;

			}
			set { 
				 sdt.gxTpr_Telefonecoml = value;
			}
		}

		[JsonPropertyName("dddTelefoneComl")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="dddTelefoneComl", Order=10)]
		public  string gxTpr_Dddtelefonecoml
		{
			get { 
				return sdt.gxTpr_Dddtelefonecoml;

			}
			set { 
				 sdt.gxTpr_Dddtelefonecoml = value;
			}
		}

		[JsonPropertyName("celular")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="celular", Order=11)]
		public  string gxTpr_Celular
		{
			get { 
				return sdt.gxTpr_Celular;

			}
			set { 
				 sdt.gxTpr_Celular = value;
			}
		}

		[JsonPropertyName("dddCelular")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="dddCelular", Order=12)]
		public  string gxTpr_Dddcelular
		{
			get { 
				return sdt.gxTpr_Dddcelular;

			}
			set { 
				 sdt.gxTpr_Dddcelular = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_enderecosItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_enderecosItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_enderecosItem() ;
			}
		}
	}
	#endregion
}