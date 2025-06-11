/*
				   File: type_SdtWPropostaData_Documentos_GridDocItem
			Description: GridDoc
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
	[XmlRoot(ElementName="WPropostaData.Documentos.GridDocItem")]
	[XmlType(TypeName="WPropostaData.Documentos.GridDocItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Documentos_GridDocItem : GxUserType
	{
		public SdtWPropostaData_Documentos_GridDocItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosdescricao = "";

			gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento = "";

			gxTv_SdtWPropostaData_Documentos_GridDocItem_Nome = "";

			gxTv_SdtWPropostaData_Documentos_GridDocItem_Extensao = "";

			gxTv_SdtWPropostaData_Documentos_GridDocItem_Nomearquivo = "";

		}

		public SdtWPropostaData_Documentos_GridDocItem(IGxContext context)
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


			AddObjectProperty("DocumentosDescricao", gxTpr_Documentosdescricao, false);


			AddObjectProperty("DocumentoObrigatorio", gxTpr_Documentoobrigatorio, false);


			AddObjectProperty("Documento", gxTpr_Documento, false);


			AddObjectProperty("Nome", gxTpr_Nome, false);


			AddObjectProperty("Extensao", gxTpr_Extensao, false);


			AddObjectProperty("NomeArquivo", gxTpr_Nomearquivo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocumentosId")]
		[XmlElement(ElementName="DocumentosId")]
		public int gxTpr_Documentosid
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosid; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosid = value;
				SetDirty("Documentosid");
			}
		}




		[SoapElement(ElementName="DocumentosDescricao")]
		[XmlElement(ElementName="DocumentosDescricao")]
		public string gxTpr_Documentosdescricao
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosdescricao; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosdescricao = value;
				SetDirty("Documentosdescricao");
			}
		}




		[SoapElement(ElementName="DocumentoObrigatorio")]
		[XmlElement(ElementName="DocumentoObrigatorio")]
		public bool gxTpr_Documentoobrigatorio
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentoobrigatorio; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentoobrigatorio = value;
				SetDirty("Documentoobrigatorio");
			}
		}



		[SoapElement(ElementName="Documento")]
		[XmlElement(ElementName="Documento")]
		[GxUpload()]
		public byte[] gxTpr_Documento_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Documento
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento = value;
				SetDirty("Documento");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Nome; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Nome = value;
				SetDirty("Nome");
			}
		}




		[SoapElement(ElementName="Extensao")]
		[XmlElement(ElementName="Extensao")]
		public string gxTpr_Extensao
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Extensao; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Extensao = value;
				SetDirty("Extensao");
			}
		}




		[SoapElement(ElementName="NomeArquivo")]
		[XmlElement(ElementName="NomeArquivo")]
		public string gxTpr_Nomearquivo
		{
			get {
				return gxTv_SdtWPropostaData_Documentos_GridDocItem_Nomearquivo; 
			}
			set {
				gxTv_SdtWPropostaData_Documentos_GridDocItem_Nomearquivo = value;
				SetDirty("Nomearquivo");
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
			gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosdescricao = "";

			gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento = "";
			gxTv_SdtWPropostaData_Documentos_GridDocItem_Nome = "";
			gxTv_SdtWPropostaData_Documentos_GridDocItem_Extensao = "";
			gxTv_SdtWPropostaData_Documentos_GridDocItem_Nomearquivo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosid;
		 

		protected string gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentosdescricao;
		 

		protected bool gxTv_SdtWPropostaData_Documentos_GridDocItem_Documentoobrigatorio;
		 

		protected string gxTv_SdtWPropostaData_Documentos_GridDocItem_Documento;
		 

		protected string gxTv_SdtWPropostaData_Documentos_GridDocItem_Nome;
		 

		protected string gxTv_SdtWPropostaData_Documentos_GridDocItem_Extensao;
		 

		protected string gxTv_SdtWPropostaData_Documentos_GridDocItem_Nomearquivo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPropostaData.Documentos.GridDocItem", Namespace="Factory21")]
	public class SdtWPropostaData_Documentos_GridDocItem_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Documentos_GridDocItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Documentos_GridDocItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Documentos_GridDocItem_RESTInterface( SdtWPropostaData_Documentos_GridDocItem psdt ) : base(psdt)
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

		[JsonPropertyName("DocumentosDescricao")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="DocumentosDescricao", Order=1)]
		public  string gxTpr_Documentosdescricao
		{
			get { 
				return sdt.gxTpr_Documentosdescricao;

			}
			set { 
				 sdt.gxTpr_Documentosdescricao = value;
			}
		}

		[JsonPropertyName("DocumentoObrigatorio")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="DocumentoObrigatorio", Order=2)]
		public bool gxTpr_Documentoobrigatorio
		{
			get { 
				return sdt.gxTpr_Documentoobrigatorio;

			}
			set { 
				sdt.gxTpr_Documentoobrigatorio = value;
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

		[JsonPropertyName("Nome")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="Nome", Order=4)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}

		[JsonPropertyName("Extensao")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="Extensao", Order=5)]
		public  string gxTpr_Extensao
		{
			get { 
				return sdt.gxTpr_Extensao;

			}
			set { 
				 sdt.gxTpr_Extensao = value;
			}
		}

		[JsonPropertyName("NomeArquivo")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="NomeArquivo", Order=6)]
		public  string gxTpr_Nomearquivo
		{
			get { 
				return sdt.gxTpr_Nomearquivo;

			}
			set { 
				 sdt.gxTpr_Nomearquivo = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Documentos_GridDocItem sdt
		{
			get { 
				return (SdtWPropostaData_Documentos_GridDocItem)Sdt;
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
				sdt = new SdtWPropostaData_Documentos_GridDocItem() ;
			}
		}
	}
	#endregion
}