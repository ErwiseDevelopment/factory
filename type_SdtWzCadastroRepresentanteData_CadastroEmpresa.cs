/*
				   File: type_SdtWzCadastroRepresentanteData_CadastroEmpresa
			Description: CadastroEmpresa
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
	[XmlRoot(ElementName="WzCadastroRepresentanteData.CadastroEmpresa")]
	[XmlType(TypeName="WzCadastroRepresentanteData.CadastroEmpresa" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWzCadastroRepresentanteData_CadastroEmpresa : GxUserType
	{
		public SdtWzCadastroRepresentanteData_CadastroEmpresa( )
		{
			/* Constructor for serialization */
			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Cnpj = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresanome = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaendereco = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaatividadeeconomica = "";

		}

		public SdtWzCadastroRepresentanteData_CadastroEmpresa(IGxContext context)
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
			AddObjectProperty("CNPJ", gxTpr_Cnpj, false);


			AddObjectProperty("CompanyIsFound", gxTpr_Companyisfound, false);


			AddObjectProperty("EmpresaNome", gxTpr_Empresanome, false);


			AddObjectProperty("EmpresaEndereco", gxTpr_Empresaendereco, false);


			AddObjectProperty("EmpresaAtividadeEconomica", gxTpr_Empresaatividadeeconomica, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CNPJ")]
		[XmlElement(ElementName="CNPJ")]
		public string gxTpr_Cnpj
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Cnpj; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Cnpj = value;
				SetDirty("Cnpj");
			}
		}




		[SoapElement(ElementName="CompanyIsFound")]
		[XmlElement(ElementName="CompanyIsFound")]
		public bool gxTpr_Companyisfound
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Companyisfound; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Companyisfound = value;
				SetDirty("Companyisfound");
			}
		}




		[SoapElement(ElementName="EmpresaNome")]
		[XmlElement(ElementName="EmpresaNome")]
		public string gxTpr_Empresanome
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresanome; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresanome = value;
				SetDirty("Empresanome");
			}
		}




		[SoapElement(ElementName="EmpresaEndereco")]
		[XmlElement(ElementName="EmpresaEndereco")]
		public string gxTpr_Empresaendereco
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaendereco; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaendereco = value;
				SetDirty("Empresaendereco");
			}
		}




		[SoapElement(ElementName="EmpresaAtividadeEconomica")]
		[XmlElement(ElementName="EmpresaAtividadeEconomica")]
		public string gxTpr_Empresaatividadeeconomica
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaatividadeeconomica; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaatividadeeconomica = value;
				SetDirty("Empresaatividadeeconomica");
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
			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Cnpj = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresanome = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaendereco = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaatividadeeconomica = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Cnpj;
		 

		protected bool gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Companyisfound;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresanome;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaendereco;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroEmpresa_Empresaatividadeeconomica;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WzCadastroRepresentanteData.CadastroEmpresa", Namespace="Factory21")]
	public class SdtWzCadastroRepresentanteData_CadastroEmpresa_RESTInterface : GxGenericCollectionItem<SdtWzCadastroRepresentanteData_CadastroEmpresa>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWzCadastroRepresentanteData_CadastroEmpresa_RESTInterface( ) : base()
		{	
		}

		public SdtWzCadastroRepresentanteData_CadastroEmpresa_RESTInterface( SdtWzCadastroRepresentanteData_CadastroEmpresa psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("CNPJ")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="CNPJ", Order=0)]
		public  string gxTpr_Cnpj
		{
			get { 
				return sdt.gxTpr_Cnpj;

			}
			set { 
				 sdt.gxTpr_Cnpj = value;
			}
		}

		[JsonPropertyName("CompanyIsFound")]
		[JsonPropertyOrder(1)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="CompanyIsFound", Order=1)]
		public bool gxTpr_Companyisfound
		{
			get { 
				return sdt.gxTpr_Companyisfound;

			}
			set { 
				sdt.gxTpr_Companyisfound = value;
			}
		}

		[JsonPropertyName("EmpresaNome")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="EmpresaNome", Order=2)]
		public  string gxTpr_Empresanome
		{
			get { 
				return sdt.gxTpr_Empresanome;

			}
			set { 
				 sdt.gxTpr_Empresanome = value;
			}
		}

		[JsonPropertyName("EmpresaEndereco")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="EmpresaEndereco", Order=3)]
		public  string gxTpr_Empresaendereco
		{
			get { 
				return sdt.gxTpr_Empresaendereco;

			}
			set { 
				 sdt.gxTpr_Empresaendereco = value;
			}
		}

		[JsonPropertyName("EmpresaAtividadeEconomica")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="EmpresaAtividadeEconomica", Order=4)]
		public  string gxTpr_Empresaatividadeeconomica
		{
			get { 
				return sdt.gxTpr_Empresaatividadeeconomica;

			}
			set { 
				 sdt.gxTpr_Empresaatividadeeconomica = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWzCadastroRepresentanteData_CadastroEmpresa sdt
		{
			get { 
				return (SdtWzCadastroRepresentanteData_CadastroEmpresa)Sdt;
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
				sdt = new SdtWzCadastroRepresentanteData_CadastroEmpresa() ;
			}
		}
	}
	#endregion
}