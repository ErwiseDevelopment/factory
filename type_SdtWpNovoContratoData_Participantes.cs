/*
				   File: type_SdtWpNovoContratoData_Participantes
			Description: Participantes
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
	[XmlRoot(ElementName="WpNovoContratoData.Participantes")]
	[XmlType(TypeName="WpNovoContratoData.Participantes" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWpNovoContratoData_Participantes : GxUserType
	{
		public SdtWpNovoContratoData_Participantes( )
		{
			/* Constructor for serialization */
			gxTv_SdtWpNovoContratoData_Participantes_Assinaturaparticipantetipo = "";

			gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob = "";

			gxTv_SdtWpNovoContratoData_Participantes_Contratonome = "";

		}

		public SdtWpNovoContratoData_Participantes(IGxContext context)
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
			AddObjectProperty("ParticipanteId", gxTpr_Participanteid, false);


			AddObjectProperty("AssinaturaParticipanteTipo", gxTpr_Assinaturaparticipantetipo, false);


			AddObjectProperty("ArquivoBlob", gxTpr_Arquivoblob, false);


			AddObjectProperty("ContratoNome", gxTpr_Contratonome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ParticipanteId")]
		[XmlElement(ElementName="ParticipanteId")]
		public int gxTpr_Participanteid
		{
			get {
				return gxTv_SdtWpNovoContratoData_Participantes_Participanteid; 
			}
			set {
				gxTv_SdtWpNovoContratoData_Participantes_Participanteid = value;
				SetDirty("Participanteid");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteTipo")]
		[XmlElement(ElementName="AssinaturaParticipanteTipo")]
		public string gxTpr_Assinaturaparticipantetipo
		{
			get {
				return gxTv_SdtWpNovoContratoData_Participantes_Assinaturaparticipantetipo; 
			}
			set {
				gxTv_SdtWpNovoContratoData_Participantes_Assinaturaparticipantetipo = value;
				SetDirty("Assinaturaparticipantetipo");
			}
		}



		[SoapElement(ElementName="ArquivoBlob")]
		[XmlElement(ElementName="ArquivoBlob")]
		[GxUpload()]
		public byte[] gxTpr_Arquivoblob_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob=context.FileFromByteArray( value) ;
			}
		}[XmlIgnore]
		public string gxTpr_Arquivoblob
		{
			get {
				return gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob; 
			}
			set {
				gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob = value;
				SetDirty("Arquivoblob");
			}
		}




		[SoapElement(ElementName="ContratoNome")]
		[XmlElement(ElementName="ContratoNome")]
		public string gxTpr_Contratonome
		{
			get {
				return gxTv_SdtWpNovoContratoData_Participantes_Contratonome; 
			}
			set {
				gxTv_SdtWpNovoContratoData_Participantes_Contratonome = value;
				SetDirty("Contratonome");
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
			gxTv_SdtWpNovoContratoData_Participantes_Assinaturaparticipantetipo = "";
			gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob = "";
			gxTv_SdtWpNovoContratoData_Participantes_Contratonome = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWpNovoContratoData_Participantes_Participanteid;
		 

		protected string gxTv_SdtWpNovoContratoData_Participantes_Assinaturaparticipantetipo;
		 

		protected string gxTv_SdtWpNovoContratoData_Participantes_Arquivoblob;
		 

		protected string gxTv_SdtWpNovoContratoData_Participantes_Contratonome;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WpNovoContratoData.Participantes", Namespace="Factory21")]
	public class SdtWpNovoContratoData_Participantes_RESTInterface : GxGenericCollectionItem<SdtWpNovoContratoData_Participantes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWpNovoContratoData_Participantes_RESTInterface( ) : base()
		{	
		}

		public SdtWpNovoContratoData_Participantes_RESTInterface( SdtWpNovoContratoData_Participantes psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ParticipanteId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ParticipanteId", Order=0)]
		public  string gxTpr_Participanteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Participanteid, 8, 0));

			}
			set { 
				sdt.gxTpr_Participanteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("AssinaturaParticipanteTipo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="AssinaturaParticipanteTipo", Order=1)]
		public  string gxTpr_Assinaturaparticipantetipo
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantetipo;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantetipo = value;
			}
		}

		[JsonPropertyName("ArquivoBlob")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ArquivoBlob", Order=2)]
		[GxUpload()]
		public  string gxTpr_Arquivoblob
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Arquivoblob);

			}
			set { 
				 sdt.gxTpr_Arquivoblob = value;
			}
		}

		[JsonPropertyName("ContratoNome")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ContratoNome", Order=3)]
		public  string gxTpr_Contratonome
		{
			get { 
				return sdt.gxTpr_Contratonome;

			}
			set { 
				 sdt.gxTpr_Contratonome = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWpNovoContratoData_Participantes sdt
		{
			get { 
				return (SdtWpNovoContratoData_Participantes)Sdt;
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
				sdt = new SdtWpNovoContratoData_Participantes() ;
			}
		}
	}
	#endregion
}