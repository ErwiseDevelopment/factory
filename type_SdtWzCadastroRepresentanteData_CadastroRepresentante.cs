/*
				   File: type_SdtWzCadastroRepresentanteData_CadastroRepresentante
			Description: CadastroRepresentante
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
	[XmlRoot(ElementName="WzCadastroRepresentanteData.CadastroRepresentante")]
	[XmlType(TypeName="WzCadastroRepresentanteData.CadastroRepresentante" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWzCadastroRepresentanteData_CadastroRepresentante : GxUserType
	{
		public SdtWzCadastroRepresentanteData_CadastroRepresentante( )
		{
			/* Constructor for serialization */
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Nome = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cargo = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Email = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Celular = "";

			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cpf = "";

		}

		public SdtWzCadastroRepresentanteData_CadastroRepresentante(IGxContext context)
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
			AddObjectProperty("Nome", gxTpr_Nome, false);


			AddObjectProperty("Cargo", gxTpr_Cargo, false);


			AddObjectProperty("Email", gxTpr_Email, false);


			AddObjectProperty("Celular", gxTpr_Celular, false);


			AddObjectProperty("CPF", gxTpr_Cpf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Nome; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Nome = value;
				SetDirty("Nome");
			}
		}




		[SoapElement(ElementName="Cargo")]
		[XmlElement(ElementName="Cargo")]
		public string gxTpr_Cargo
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cargo; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cargo = value;
				SetDirty("Cargo");
			}
		}




		[SoapElement(ElementName="Email")]
		[XmlElement(ElementName="Email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Email; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="Celular")]
		[XmlElement(ElementName="Celular")]
		public string gxTpr_Celular
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Celular; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Celular = value;
				SetDirty("Celular");
			}
		}




		[SoapElement(ElementName="CPF")]
		[XmlElement(ElementName="CPF")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cpf; 
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cpf = value;
				SetDirty("Cpf");
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
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Nome = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cargo = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Email = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Celular = "";
			gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cpf = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Nome;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cargo;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Email;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Celular;
		 

		protected string gxTv_SdtWzCadastroRepresentanteData_CadastroRepresentante_Cpf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WzCadastroRepresentanteData.CadastroRepresentante", Namespace="Factory21")]
	public class SdtWzCadastroRepresentanteData_CadastroRepresentante_RESTInterface : GxGenericCollectionItem<SdtWzCadastroRepresentanteData_CadastroRepresentante>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWzCadastroRepresentanteData_CadastroRepresentante_RESTInterface( ) : base()
		{	
		}

		public SdtWzCadastroRepresentanteData_CadastroRepresentante_RESTInterface( SdtWzCadastroRepresentanteData_CadastroRepresentante psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Nome")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Nome", Order=0)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}

		[JsonPropertyName("Cargo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Cargo", Order=1)]
		public  string gxTpr_Cargo
		{
			get { 
				return sdt.gxTpr_Cargo;

			}
			set { 
				 sdt.gxTpr_Cargo = value;
			}
		}

		[JsonPropertyName("Email")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="Email", Order=2)]
		public  string gxTpr_Email
		{
			get { 
				return sdt.gxTpr_Email;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[JsonPropertyName("Celular")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Celular", Order=3)]
		public  string gxTpr_Celular
		{
			get { 
				return sdt.gxTpr_Celular;

			}
			set { 
				 sdt.gxTpr_Celular = value;
			}
		}

		[JsonPropertyName("CPF")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="CPF", Order=4)]
		public  string gxTpr_Cpf
		{
			get { 
				return sdt.gxTpr_Cpf;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWzCadastroRepresentanteData_CadastroRepresentante sdt
		{
			get { 
				return (SdtWzCadastroRepresentanteData_CadastroRepresentante)Sdt;
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
				sdt = new SdtWzCadastroRepresentanteData_CadastroRepresentante() ;
			}
		}
	}
	#endregion
}