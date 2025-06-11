/*
				   File: type_SdtSdPropostaDocumento
			Description: SdPropostaDocumento
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
	[XmlRoot(ElementName="SdPropostaDocumento")]
	[XmlType(TypeName="SdPropostaDocumento" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdPropostaDocumento : GxUserType
	{
		public SdtSdPropostaDocumento( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdPropostaDocumento_Documentosdescricao = "";

			gxTv_SdtSdPropostaDocumento_Documento = "";

			gxTv_SdtSdPropostaDocumento_Extensao = "";

			gxTv_SdtSdPropostaDocumento_Nome = "";

		}

		public SdtSdPropostaDocumento(IGxContext context)
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
			AddObjectProperty("DocumentosId", gxTpr_Documentosid, false);


			AddObjectProperty("DocumentoObrigatorio", gxTpr_Documentoobrigatorio, false);


			AddObjectProperty("DocumentosDescricao", gxTpr_Documentosdescricao, false);


			AddObjectProperty("Documento", gxTpr_Documento, false);


			AddObjectProperty("Extensao", gxTpr_Extensao, false);


			AddObjectProperty("Nome", gxTpr_Nome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocumentosId")]
		[XmlElement(ElementName="DocumentosId")]
		public int gxTpr_Documentosid
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Documentosid; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Documentosid = value;
				SetDirty("Documentosid");
			}
		}




		[SoapElement(ElementName="DocumentoObrigatorio")]
		[XmlElement(ElementName="DocumentoObrigatorio")]
		public bool gxTpr_Documentoobrigatorio
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Documentoobrigatorio; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Documentoobrigatorio = value;
				SetDirty("Documentoobrigatorio");
			}
		}




		[SoapElement(ElementName="DocumentosDescricao")]
		[XmlElement(ElementName="DocumentosDescricao")]
		public string gxTpr_Documentosdescricao
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Documentosdescricao; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Documentosdescricao = value;
				SetDirty("Documentosdescricao");
			}
		}



		[SoapElement(ElementName="Documento")]
		[XmlElement(ElementName="Documento")]
		[GxUpload()]
		public byte[] gxTpr_Documento_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtSdPropostaDocumento_Documento) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtSdPropostaDocumento_Documento=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Documento
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Documento; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Documento = value;
				SetDirty("Documento");
			}
		}




		[SoapElement(ElementName="Extensao")]
		[XmlElement(ElementName="Extensao")]
		public string gxTpr_Extensao
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Extensao; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Extensao = value;
				SetDirty("Extensao");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtSdPropostaDocumento_Nome; 
			}
			set {
				gxTv_SdtSdPropostaDocumento_Nome = value;
				SetDirty("Nome");
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
			gxTv_SdtSdPropostaDocumento_Documentosdescricao = "";
			gxTv_SdtSdPropostaDocumento_Documento = "";
			gxTv_SdtSdPropostaDocumento_Extensao = "";
			gxTv_SdtSdPropostaDocumento_Nome = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdPropostaDocumento_Documentosid;
		 

		protected bool gxTv_SdtSdPropostaDocumento_Documentoobrigatorio;
		 

		protected string gxTv_SdtSdPropostaDocumento_Documentosdescricao;
		 

		protected string gxTv_SdtSdPropostaDocumento_Documento;
		 

		protected string gxTv_SdtSdPropostaDocumento_Extensao;
		 

		protected string gxTv_SdtSdPropostaDocumento_Nome;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdPropostaDocumento", Namespace="Factory21")]
	public class SdtSdPropostaDocumento_RESTInterface : GxGenericCollectionItem<SdtSdPropostaDocumento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdPropostaDocumento_RESTInterface( ) : base()
		{	
		}

		public SdtSdPropostaDocumento_RESTInterface( SdtSdPropostaDocumento psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("DocumentosId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="DocumentosId", Order=0)]
		public  string gxTpr_Documentosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Documentosid, 9, 0));

			}
			set { 
				sdt.gxTpr_Documentosid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("DocumentoObrigatorio")]
		[JsonPropertyOrder(1)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="DocumentoObrigatorio", Order=1)]
		public bool gxTpr_Documentoobrigatorio
		{
			get { 
				return sdt.gxTpr_Documentoobrigatorio;

			}
			set { 
				sdt.gxTpr_Documentoobrigatorio = value;
			}
		}

		[JsonPropertyName("DocumentosDescricao")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="DocumentosDescricao", Order=2)]
		public  string gxTpr_Documentosdescricao
		{
			get { 
				return sdt.gxTpr_Documentosdescricao;

			}
			set { 
				 sdt.gxTpr_Documentosdescricao = value;
			}
		}

		[JsonPropertyName("Documento")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Documento", Order=3)]
		[GxUpload()]
		public  string gxTpr_Documento
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Documento);

			}
			set { 
				 sdt.gxTpr_Documento = value;
			}
		}

		[JsonPropertyName("Extensao")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="Extensao", Order=4)]
		public  string gxTpr_Extensao
		{
			get { 
				return sdt.gxTpr_Extensao;

			}
			set { 
				 sdt.gxTpr_Extensao = value;
			}
		}

		[JsonPropertyName("Nome")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="Nome", Order=5)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdPropostaDocumento sdt
		{
			get { 
				return (SdtSdPropostaDocumento)Sdt;
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
				sdt = new SdtSdPropostaDocumento() ;
			}
		}
	}
	#endregion
}