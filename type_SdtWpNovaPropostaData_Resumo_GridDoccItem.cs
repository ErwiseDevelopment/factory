/*
				   File: type_SdtWpNovaPropostaData_Resumo_GridDoccItem
			Description: GridDocc
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
	[XmlRoot(ElementName="WpNovaPropostaData.Resumo.GridDoccItem")]
	[XmlType(TypeName="WpNovaPropostaData.Resumo.GridDoccItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWpNovaPropostaData_Resumo_GridDoccItem : GxUserType
	{
		public SdtWpNovaPropostaData_Resumo_GridDoccItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosdescricao = "";

			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento = "";

			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumoextensao = "";

			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nome = "";

			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nomearquivo = "";

		}

		public SdtWpNovaPropostaData_Resumo_GridDoccItem(IGxContext context)
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
			AddObjectProperty("ResumoDocumentosId", gxTpr_Resumodocumentosid, false);


			AddObjectProperty("ResumoDocumentosDescricao", gxTpr_Resumodocumentosdescricao, false);


			AddObjectProperty("ResumoDocumentoObrigatorio", gxTpr_Resumodocumentoobrigatorio, false);


			AddObjectProperty("ResumoDocumento", gxTpr_Resumodocumento, false);


			AddObjectProperty("ResumoExtensao", gxTpr_Resumoextensao, false);


			AddObjectProperty("Nome", gxTpr_Nome, false);


			AddObjectProperty("NomeArquivo", gxTpr_Nomearquivo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResumoDocumentosId")]
		[XmlElement(ElementName="ResumoDocumentosId")]
		public int gxTpr_Resumodocumentosid
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosid; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosid = value;
				SetDirty("Resumodocumentosid");
			}
		}




		[SoapElement(ElementName="ResumoDocumentosDescricao")]
		[XmlElement(ElementName="ResumoDocumentosDescricao")]
		public string gxTpr_Resumodocumentosdescricao
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosdescricao; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosdescricao = value;
				SetDirty("Resumodocumentosdescricao");
			}
		}




		[SoapElement(ElementName="ResumoDocumentoObrigatorio")]
		[XmlElement(ElementName="ResumoDocumentoObrigatorio")]
		public bool gxTpr_Resumodocumentoobrigatorio
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentoobrigatorio; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentoobrigatorio = value;
				SetDirty("Resumodocumentoobrigatorio");
			}
		}



		[SoapElement(ElementName="ResumoDocumento")]
		[XmlElement(ElementName="ResumoDocumento")]
		[GxUpload()]
		public byte[] gxTpr_Resumodocumento_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Resumodocumento
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento = value;
				SetDirty("Resumodocumento");
			}
		}




		[SoapElement(ElementName="ResumoExtensao")]
		[XmlElement(ElementName="ResumoExtensao")]
		public string gxTpr_Resumoextensao
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumoextensao; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumoextensao = value;
				SetDirty("Resumoextensao");
			}
		}




		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nome; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nome = value;
				SetDirty("Nome");
			}
		}




		[SoapElement(ElementName="NomeArquivo")]
		[XmlElement(ElementName="NomeArquivo")]
		public string gxTpr_Nomearquivo
		{
			get {
				return gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nomearquivo; 
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nomearquivo = value;
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
			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosdescricao = "";

			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento = "";
			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumoextensao = "";
			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nome = "";
			gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nomearquivo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosid;
		 

		protected string gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentosdescricao;
		 

		protected bool gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumentoobrigatorio;
		 

		protected string gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumodocumento;
		 

		protected string gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Resumoextensao;
		 

		protected string gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nome;
		 

		protected string gxTv_SdtWpNovaPropostaData_Resumo_GridDoccItem_Nomearquivo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WpNovaPropostaData.Resumo.GridDoccItem", Namespace="Factory21")]
	public class SdtWpNovaPropostaData_Resumo_GridDoccItem_RESTInterface : GxGenericCollectionItem<SdtWpNovaPropostaData_Resumo_GridDoccItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWpNovaPropostaData_Resumo_GridDoccItem_RESTInterface( ) : base()
		{	
		}

		public SdtWpNovaPropostaData_Resumo_GridDoccItem_RESTInterface( SdtWpNovaPropostaData_Resumo_GridDoccItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ResumoDocumentosId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ResumoDocumentosId", Order=0)]
		public  string gxTpr_Resumodocumentosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Resumodocumentosid, 9, 0));

			}
			set { 
				sdt.gxTpr_Resumodocumentosid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ResumoDocumentosDescricao")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ResumoDocumentosDescricao", Order=1)]
		public  string gxTpr_Resumodocumentosdescricao
		{
			get { 
				return sdt.gxTpr_Resumodocumentosdescricao;

			}
			set { 
				 sdt.gxTpr_Resumodocumentosdescricao = value;
			}
		}

		[JsonPropertyName("ResumoDocumentoObrigatorio")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="ResumoDocumentoObrigatorio", Order=2)]
		public bool gxTpr_Resumodocumentoobrigatorio
		{
			get { 
				return sdt.gxTpr_Resumodocumentoobrigatorio;

			}
			set { 
				sdt.gxTpr_Resumodocumentoobrigatorio = value;
			}
		}

		[JsonPropertyName("ResumoDocumento")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ResumoDocumento", Order=3)]
		[GxUpload()]
		public  string gxTpr_Resumodocumento
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Resumodocumento);

			}
			set { 
				 sdt.gxTpr_Resumodocumento = value;
			}
		}

		[JsonPropertyName("ResumoExtensao")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ResumoExtensao", Order=4)]
		public  string gxTpr_Resumoextensao
		{
			get { 
				return sdt.gxTpr_Resumoextensao;

			}
			set { 
				 sdt.gxTpr_Resumoextensao = value;
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
		public SdtWpNovaPropostaData_Resumo_GridDoccItem sdt
		{
			get { 
				return (SdtWpNovaPropostaData_Resumo_GridDoccItem)Sdt;
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
				sdt = new SdtWpNovaPropostaData_Resumo_GridDoccItem() ;
			}
		}
	}
	#endregion
}