/*
				   File: type_SdtSdDocumentosReembolso
			Description: SdDocumentosReembolso
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
	[XmlRoot(ElementName="SdDocumentosReembolso")]
	[XmlType(TypeName="SdDocumentosReembolso" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdDocumentosReembolso : GxUserType
	{
		public SdtSdDocumentosReembolso( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdDocumentosReembolso_Documentosdescricao = "";

			gxTv_SdtSdDocumentosReembolso_Documentonome = "";

			gxTv_SdtSdDocumentosReembolso_Documentoextensao = "";

			gxTv_SdtSdDocumentosReembolso_Documentoblob = "";

			gxTv_SdtSdDocumentosReembolso_Reembolsodocumentostatus = "";

		}

		public SdtSdDocumentosReembolso(IGxContext context)
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


			AddObjectProperty("DocumentoNome", gxTpr_Documentonome, false);


			AddObjectProperty("DocumentoExtensao", gxTpr_Documentoextensao, false);


			AddObjectProperty("DocumentoBlob", gxTpr_Documentoblob, false);


			AddObjectProperty("ReembolsoDocumentoId", gxTpr_Reembolsodocumentoid, false);


			AddObjectProperty("IsUpdated", gxTpr_Isupdated, false);


			AddObjectProperty("ReembolsoDocumentoStatus", gxTpr_Reembolsodocumentostatus, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocumentosId")]
		[XmlElement(ElementName="DocumentosId")]
		public int gxTpr_Documentosid
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Documentosid; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Documentosid = value;
				SetDirty("Documentosid");
			}
		}




		[SoapElement(ElementName="DocumentosDescricao")]
		[XmlElement(ElementName="DocumentosDescricao")]
		public string gxTpr_Documentosdescricao
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Documentosdescricao; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Documentosdescricao = value;
				SetDirty("Documentosdescricao");
			}
		}




		[SoapElement(ElementName="DocumentoNome")]
		[XmlElement(ElementName="DocumentoNome")]
		public string gxTpr_Documentonome
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Documentonome; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Documentonome = value;
				SetDirty("Documentonome");
			}
		}




		[SoapElement(ElementName="DocumentoExtensao")]
		[XmlElement(ElementName="DocumentoExtensao")]
		public string gxTpr_Documentoextensao
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Documentoextensao; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Documentoextensao = value;
				SetDirty("Documentoextensao");
			}
		}



		[SoapElement(ElementName="DocumentoBlob")]
		[XmlElement(ElementName="DocumentoBlob")]
		[GxUpload()]
		public byte[] gxTpr_Documentoblob_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtSdDocumentosReembolso_Documentoblob) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtSdDocumentosReembolso_Documentoblob=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Documentoblob
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Documentoblob; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Documentoblob = value;
				SetDirty("Documentoblob");
			}
		}




		[SoapElement(ElementName="ReembolsoDocumentoId")]
		[XmlElement(ElementName="ReembolsoDocumentoId")]
		public int gxTpr_Reembolsodocumentoid
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Reembolsodocumentoid; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Reembolsodocumentoid = value;
				SetDirty("Reembolsodocumentoid");
			}
		}




		[SoapElement(ElementName="IsUpdated")]
		[XmlElement(ElementName="IsUpdated")]
		public bool gxTpr_Isupdated
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Isupdated; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Isupdated = value;
				SetDirty("Isupdated");
			}
		}




		[SoapElement(ElementName="ReembolsoDocumentoStatus")]
		[XmlElement(ElementName="ReembolsoDocumentoStatus")]
		public string gxTpr_Reembolsodocumentostatus
		{
			get {
				return gxTv_SdtSdDocumentosReembolso_Reembolsodocumentostatus; 
			}
			set {
				gxTv_SdtSdDocumentosReembolso_Reembolsodocumentostatus = value;
				SetDirty("Reembolsodocumentostatus");
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
			gxTv_SdtSdDocumentosReembolso_Documentosdescricao = "";
			gxTv_SdtSdDocumentosReembolso_Documentonome = "";
			gxTv_SdtSdDocumentosReembolso_Documentoextensao = "";
			gxTv_SdtSdDocumentosReembolso_Documentoblob = "";


			gxTv_SdtSdDocumentosReembolso_Reembolsodocumentostatus = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdDocumentosReembolso_Documentosid;
		 

		protected string gxTv_SdtSdDocumentosReembolso_Documentosdescricao;
		 

		protected string gxTv_SdtSdDocumentosReembolso_Documentonome;
		 

		protected string gxTv_SdtSdDocumentosReembolso_Documentoextensao;
		 

		protected string gxTv_SdtSdDocumentosReembolso_Documentoblob;
		 

		protected int gxTv_SdtSdDocumentosReembolso_Reembolsodocumentoid;
		 

		protected bool gxTv_SdtSdDocumentosReembolso_Isupdated;
		 

		protected string gxTv_SdtSdDocumentosReembolso_Reembolsodocumentostatus;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdDocumentosReembolso", Namespace="Factory21")]
	public class SdtSdDocumentosReembolso_RESTInterface : GxGenericCollectionItem<SdtSdDocumentosReembolso>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdDocumentosReembolso_RESTInterface( ) : base()
		{	
		}

		public SdtSdDocumentosReembolso_RESTInterface( SdtSdDocumentosReembolso psdt ) : base(psdt)
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

		[JsonPropertyName("DocumentoNome")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="DocumentoNome", Order=2)]
		public  string gxTpr_Documentonome
		{
			get { 
				return sdt.gxTpr_Documentonome;

			}
			set { 
				 sdt.gxTpr_Documentonome = value;
			}
		}

		[JsonPropertyName("DocumentoExtensao")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="DocumentoExtensao", Order=3)]
		public  string gxTpr_Documentoextensao
		{
			get { 
				return sdt.gxTpr_Documentoextensao;

			}
			set { 
				 sdt.gxTpr_Documentoextensao = value;
			}
		}

		[JsonPropertyName("DocumentoBlob")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="DocumentoBlob", Order=4)]
		[GxUpload()]
		public  string gxTpr_Documentoblob
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Documentoblob);

			}
			set { 
				 sdt.gxTpr_Documentoblob = value;
			}
		}

		[JsonPropertyName("ReembolsoDocumentoId")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ReembolsoDocumentoId", Order=5)]
		public  string gxTpr_Reembolsodocumentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Reembolsodocumentoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Reembolsodocumentoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("IsUpdated")]
		[JsonPropertyOrder(6)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="IsUpdated", Order=6)]
		public bool gxTpr_Isupdated
		{
			get { 
				return sdt.gxTpr_Isupdated;

			}
			set { 
				sdt.gxTpr_Isupdated = value;
			}
		}

		[JsonPropertyName("ReembolsoDocumentoStatus")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ReembolsoDocumentoStatus", Order=7)]
		public  string gxTpr_Reembolsodocumentostatus
		{
			get { 
				return sdt.gxTpr_Reembolsodocumentostatus;

			}
			set { 
				 sdt.gxTpr_Reembolsodocumentostatus = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdDocumentosReembolso sdt
		{
			get { 
				return (SdtSdDocumentosReembolso)Sdt;
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
				sdt = new SdtSdDocumentosReembolso() ;
			}
		}
	}
	#endregion
}