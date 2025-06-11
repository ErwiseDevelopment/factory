/*
				   File: type_SdtSdtDocumentos
			Description: SdtDocumentos
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
	[XmlRoot(ElementName="SdtDocumentos")]
	[XmlType(TypeName="SdtDocumentos" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdtDocumentos : GxUserType
	{
		public SdtSdtDocumentos( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtDocumentos_Documentosdescricao = "";

			gxTv_SdtSdtDocumentos_Documento = "";

		}

		public SdtSdtDocumentos(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocumentosId")]
		[XmlElement(ElementName="DocumentosId")]
		public int gxTpr_Documentosid
		{
			get {
				return gxTv_SdtSdtDocumentos_Documentosid; 
			}
			set {
				gxTv_SdtSdtDocumentos_Documentosid = value;
				SetDirty("Documentosid");
			}
		}




		[SoapElement(ElementName="DocumentosDescricao")]
		[XmlElement(ElementName="DocumentosDescricao")]
		public string gxTpr_Documentosdescricao
		{
			get {
				return gxTv_SdtSdtDocumentos_Documentosdescricao; 
			}
			set {
				gxTv_SdtSdtDocumentos_Documentosdescricao = value;
				SetDirty("Documentosdescricao");
			}
		}




		[SoapElement(ElementName="DocumentoObrigatorio")]
		[XmlElement(ElementName="DocumentoObrigatorio")]
		public bool gxTpr_Documentoobrigatorio
		{
			get {
				return gxTv_SdtSdtDocumentos_Documentoobrigatorio; 
			}
			set {
				gxTv_SdtSdtDocumentos_Documentoobrigatorio = value;
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
				return context.FileToByteArray(gxTv_SdtSdtDocumentos_Documento) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtSdtDocumentos_Documento=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Documento
		{
			get {
				return gxTv_SdtSdtDocumentos_Documento; 
			}
			set {
				gxTv_SdtSdtDocumentos_Documento = value;
				SetDirty("Documento");
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
			gxTv_SdtSdtDocumentos_Documentosdescricao = "";

			gxTv_SdtSdtDocumentos_Documento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdtDocumentos_Documentosid;
		 

		protected string gxTv_SdtSdtDocumentos_Documentosdescricao;
		 

		protected bool gxTv_SdtSdtDocumentos_Documentoobrigatorio;
		 

		protected string gxTv_SdtSdtDocumentos_Documento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtDocumentos", Namespace="Factory21")]
	public class SdtSdtDocumentos_RESTInterface : GxGenericCollectionItem<SdtSdtDocumentos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtDocumentos_RESTInterface( ) : base()
		{	
		}

		public SdtSdtDocumentos_RESTInterface( SdtSdtDocumentos psdt ) : base(psdt)
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


		#endregion
		[JsonIgnore]
		public SdtSdtDocumentos sdt
		{
			get { 
				return (SdtSdtDocumentos)Sdt;
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
				sdt = new SdtSdtDocumentos() ;
			}
		}
	}
	#endregion
}