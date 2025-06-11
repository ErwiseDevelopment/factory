/*
				   File: type_SdtSdCadastroRepresentante
			Description: SdCadastroRepresentante
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
	[XmlRoot(ElementName="SdCadastroRepresentante")]
	[XmlType(TypeName="SdCadastroRepresentante" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdCadastroRepresentante : GxUserType
	{
		public SdtSdCadastroRepresentante( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdCadastroRepresentante_Nome = "";

			gxTv_SdtSdCadastroRepresentante_Cargo = "";

			gxTv_SdtSdCadastroRepresentante_Email = "";

			gxTv_SdtSdCadastroRepresentante_Celular = "";

			gxTv_SdtSdCadastroRepresentante_Cpf = "";

			gxTv_SdtSdCadastroRepresentante_Empresacnpj = "";

		}

		public SdtSdCadastroRepresentante(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Nome", gxTpr_Nome, false);


			AddObjectProperty("Cargo", gxTpr_Cargo, false);


			AddObjectProperty("Email", gxTpr_Email, false);


			AddObjectProperty("Celular", gxTpr_Celular, false);


			AddObjectProperty("CPF", gxTpr_Cpf, false);


			AddObjectProperty("EmpresaCNPJ", gxTpr_Empresacnpj, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Id; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Nome; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Nome = value;
				SetDirty("Nome");
			}
		}




		[SoapElement(ElementName="Cargo")]
		[XmlElement(ElementName="Cargo")]
		public string gxTpr_Cargo
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Cargo; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Cargo = value;
				SetDirty("Cargo");
			}
		}




		[SoapElement(ElementName="Email")]
		[XmlElement(ElementName="Email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Email; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="Celular")]
		[XmlElement(ElementName="Celular")]
		public string gxTpr_Celular
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Celular; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Celular = value;
				SetDirty("Celular");
			}
		}




		[SoapElement(ElementName="CPF")]
		[XmlElement(ElementName="CPF")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Cpf; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="EmpresaCNPJ")]
		[XmlElement(ElementName="EmpresaCNPJ")]
		public string gxTpr_Empresacnpj
		{
			get {
				return gxTv_SdtSdCadastroRepresentante_Empresacnpj; 
			}
			set {
				gxTv_SdtSdCadastroRepresentante_Empresacnpj = value;
				SetDirty("Empresacnpj");
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
			gxTv_SdtSdCadastroRepresentante_Nome = "";
			gxTv_SdtSdCadastroRepresentante_Cargo = "";
			gxTv_SdtSdCadastroRepresentante_Email = "";
			gxTv_SdtSdCadastroRepresentante_Celular = "";
			gxTv_SdtSdCadastroRepresentante_Cpf = "";
			gxTv_SdtSdCadastroRepresentante_Empresacnpj = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdCadastroRepresentante_Id;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Nome;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Cargo;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Email;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Celular;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Cpf;
		 

		protected string gxTv_SdtSdCadastroRepresentante_Empresacnpj;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdCadastroRepresentante", Namespace="Factory21")]
	public class SdtSdCadastroRepresentante_RESTInterface : GxGenericCollectionItem<SdtSdCadastroRepresentante>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdCadastroRepresentante_RESTInterface( ) : base()
		{	
		}

		public SdtSdCadastroRepresentante_RESTInterface( SdtSdCadastroRepresentante psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Id")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 9, 0));

			}
			set { 
				sdt.gxTpr_Id = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("Nome")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Nome", Order=1)]
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
		[JsonPropertyOrder(2)]
		[DataMember(Name="Cargo", Order=2)]
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
		[JsonPropertyOrder(3)]
		[DataMember(Name="Email", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="Celular", Order=4)]
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
		[JsonPropertyOrder(5)]
		[DataMember(Name="CPF", Order=5)]
		public  string gxTpr_Cpf
		{
			get { 
				return sdt.gxTpr_Cpf;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}

		[JsonPropertyName("EmpresaCNPJ")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="EmpresaCNPJ", Order=6)]
		public  string gxTpr_Empresacnpj
		{
			get { 
				return sdt.gxTpr_Empresacnpj;

			}
			set { 
				 sdt.gxTpr_Empresacnpj = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdCadastroRepresentante sdt
		{
			get { 
				return (SdtSdCadastroRepresentante)Sdt;
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
				sdt = new SdtSdCadastroRepresentante() ;
			}
		}
	}
	#endregion
}