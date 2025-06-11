/*
				   File: type_SdtSdParticipantes
			Description: SdParticipantes
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
	[XmlRoot(ElementName="SdParticipantes")]
	[XmlType(TypeName="SdParticipantes" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdParticipantes : GxUserType
	{
		public SdtSdParticipantes( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdParticipantes_Participantenome = "";

			gxTv_SdtSdParticipantes_Participantedocumento = "";

			gxTv_SdtSdParticipantes_Participanteemail = "";

			gxTv_SdtSdParticipantes_Assinaturaparticipantetipo = "";

			gxTv_SdtSdParticipantes_Link = "";

			gxTv_SdtSdParticipantes_Descricao = "";

			gxTv_SdtSdParticipantes_Participantetipopessoa = "";

			gxTv_SdtSdParticipantes_Participanterepresentantenome = "";

			gxTv_SdtSdParticipantes_Participanterepresentanteemail = "";

			gxTv_SdtSdParticipantes_Participanterepresentantedocumento = "";

		}

		public SdtSdParticipantes(IGxContext context)
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


			AddObjectProperty("ParticipanteNome", gxTpr_Participantenome, false);


			AddObjectProperty("ParticipanteDocumento", gxTpr_Participantedocumento, false);


			AddObjectProperty("ParticipanteEmail", gxTpr_Participanteemail, false);


			AddObjectProperty("AssinaturaParticipanteTipo", gxTpr_Assinaturaparticipantetipo, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("ClienteId", gxTpr_Clienteid, false);


			AddObjectProperty("Descricao", gxTpr_Descricao, false);


			AddObjectProperty("ParticipanteTipoPessoa", gxTpr_Participantetipopessoa, false);


			AddObjectProperty("ParticipanteRepresentanteNome", gxTpr_Participanterepresentantenome, false);


			AddObjectProperty("ParticipanteRepresentanteEmail", gxTpr_Participanterepresentanteemail, false);


			AddObjectProperty("ParticipanteRepresentanteDocumento", gxTpr_Participanterepresentantedocumento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ParticipanteId")]
		[XmlElement(ElementName="ParticipanteId")]
		public int gxTpr_Participanteid
		{
			get {
				return gxTv_SdtSdParticipantes_Participanteid; 
			}
			set {
				gxTv_SdtSdParticipantes_Participanteid = value;
				SetDirty("Participanteid");
			}
		}




		[SoapElement(ElementName="ParticipanteNome")]
		[XmlElement(ElementName="ParticipanteNome")]
		public string gxTpr_Participantenome
		{
			get {
				return gxTv_SdtSdParticipantes_Participantenome; 
			}
			set {
				gxTv_SdtSdParticipantes_Participantenome = value;
				SetDirty("Participantenome");
			}
		}




		[SoapElement(ElementName="ParticipanteDocumento")]
		[XmlElement(ElementName="ParticipanteDocumento")]
		public string gxTpr_Participantedocumento
		{
			get {
				return gxTv_SdtSdParticipantes_Participantedocumento; 
			}
			set {
				gxTv_SdtSdParticipantes_Participantedocumento = value;
				SetDirty("Participantedocumento");
			}
		}




		[SoapElement(ElementName="ParticipanteEmail")]
		[XmlElement(ElementName="ParticipanteEmail")]
		public string gxTpr_Participanteemail
		{
			get {
				return gxTv_SdtSdParticipantes_Participanteemail; 
			}
			set {
				gxTv_SdtSdParticipantes_Participanteemail = value;
				SetDirty("Participanteemail");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteTipo")]
		[XmlElement(ElementName="AssinaturaParticipanteTipo")]
		public string gxTpr_Assinaturaparticipantetipo
		{
			get {
				return gxTv_SdtSdParticipantes_Assinaturaparticipantetipo; 
			}
			set {
				gxTv_SdtSdParticipantes_Assinaturaparticipantetipo = value;
				SetDirty("Assinaturaparticipantetipo");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtSdParticipantes_Link; 
			}
			set {
				gxTv_SdtSdParticipantes_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="ClienteId")]
		[XmlElement(ElementName="ClienteId")]
		public int gxTpr_Clienteid
		{
			get {
				return gxTv_SdtSdParticipantes_Clienteid; 
			}
			set {
				gxTv_SdtSdParticipantes_Clienteid = value;
				SetDirty("Clienteid");
			}
		}




		[SoapElement(ElementName="Descricao")]
		[XmlElement(ElementName="Descricao")]
		public string gxTpr_Descricao
		{
			get {
				return gxTv_SdtSdParticipantes_Descricao; 
			}
			set {
				gxTv_SdtSdParticipantes_Descricao = value;
				SetDirty("Descricao");
			}
		}




		[SoapElement(ElementName="ParticipanteTipoPessoa")]
		[XmlElement(ElementName="ParticipanteTipoPessoa")]
		public string gxTpr_Participantetipopessoa
		{
			get {
				return gxTv_SdtSdParticipantes_Participantetipopessoa; 
			}
			set {
				gxTv_SdtSdParticipantes_Participantetipopessoa = value;
				SetDirty("Participantetipopessoa");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteNome")]
		[XmlElement(ElementName="ParticipanteRepresentanteNome")]
		public string gxTpr_Participanterepresentantenome
		{
			get {
				return gxTv_SdtSdParticipantes_Participanterepresentantenome; 
			}
			set {
				gxTv_SdtSdParticipantes_Participanterepresentantenome = value;
				SetDirty("Participanterepresentantenome");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteEmail")]
		[XmlElement(ElementName="ParticipanteRepresentanteEmail")]
		public string gxTpr_Participanterepresentanteemail
		{
			get {
				return gxTv_SdtSdParticipantes_Participanterepresentanteemail; 
			}
			set {
				gxTv_SdtSdParticipantes_Participanterepresentanteemail = value;
				SetDirty("Participanterepresentanteemail");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteDocumento")]
		[XmlElement(ElementName="ParticipanteRepresentanteDocumento")]
		public string gxTpr_Participanterepresentantedocumento
		{
			get {
				return gxTv_SdtSdParticipantes_Participanterepresentantedocumento; 
			}
			set {
				gxTv_SdtSdParticipantes_Participanterepresentantedocumento = value;
				SetDirty("Participanterepresentantedocumento");
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
			gxTv_SdtSdParticipantes_Participantenome = "";
			gxTv_SdtSdParticipantes_Participantedocumento = "";
			gxTv_SdtSdParticipantes_Participanteemail = "";
			gxTv_SdtSdParticipantes_Assinaturaparticipantetipo = "";
			gxTv_SdtSdParticipantes_Link = "";

			gxTv_SdtSdParticipantes_Descricao = "";
			gxTv_SdtSdParticipantes_Participantetipopessoa = "";
			gxTv_SdtSdParticipantes_Participanterepresentantenome = "";
			gxTv_SdtSdParticipantes_Participanterepresentanteemail = "";
			gxTv_SdtSdParticipantes_Participanterepresentantedocumento = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdParticipantes_Participanteid;
		 

		protected string gxTv_SdtSdParticipantes_Participantenome;
		 

		protected string gxTv_SdtSdParticipantes_Participantedocumento;
		 

		protected string gxTv_SdtSdParticipantes_Participanteemail;
		 

		protected string gxTv_SdtSdParticipantes_Assinaturaparticipantetipo;
		 

		protected string gxTv_SdtSdParticipantes_Link;
		 

		protected int gxTv_SdtSdParticipantes_Clienteid;
		 

		protected string gxTv_SdtSdParticipantes_Descricao;
		 

		protected string gxTv_SdtSdParticipantes_Participantetipopessoa;
		 

		protected string gxTv_SdtSdParticipantes_Participanterepresentantenome;
		 

		protected string gxTv_SdtSdParticipantes_Participanterepresentanteemail;
		 

		protected string gxTv_SdtSdParticipantes_Participanterepresentantedocumento;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdParticipantes", Namespace="Factory21")]
	public class SdtSdParticipantes_RESTInterface : GxGenericCollectionItem<SdtSdParticipantes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdParticipantes_RESTInterface( ) : base()
		{	
		}

		public SdtSdParticipantes_RESTInterface( SdtSdParticipantes psdt ) : base(psdt)
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

		[JsonPropertyName("ParticipanteNome")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ParticipanteNome", Order=1)]
		public  string gxTpr_Participantenome
		{
			get { 
				return sdt.gxTpr_Participantenome;

			}
			set { 
				 sdt.gxTpr_Participantenome = value;
			}
		}

		[JsonPropertyName("ParticipanteDocumento")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ParticipanteDocumento", Order=2)]
		public  string gxTpr_Participantedocumento
		{
			get { 
				return sdt.gxTpr_Participantedocumento;

			}
			set { 
				 sdt.gxTpr_Participantedocumento = value;
			}
		}

		[JsonPropertyName("ParticipanteEmail")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ParticipanteEmail", Order=3)]
		public  string gxTpr_Participanteemail
		{
			get { 
				return sdt.gxTpr_Participanteemail;

			}
			set { 
				 sdt.gxTpr_Participanteemail = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteTipo")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="AssinaturaParticipanteTipo", Order=4)]
		public  string gxTpr_Assinaturaparticipantetipo
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantetipo;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantetipo = value;
			}
		}

		[JsonPropertyName("Link")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="Link", Order=5)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[JsonPropertyName("ClienteId")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ClienteId", Order=6)]
		public  string gxTpr_Clienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("Descricao")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="Descricao", Order=7)]
		public  string gxTpr_Descricao
		{
			get { 
				return sdt.gxTpr_Descricao;

			}
			set { 
				 sdt.gxTpr_Descricao = value;
			}
		}

		[JsonPropertyName("ParticipanteTipoPessoa")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="ParticipanteTipoPessoa", Order=8)]
		public  string gxTpr_Participantetipopessoa
		{
			get { 
				return sdt.gxTpr_Participantetipopessoa;

			}
			set { 
				 sdt.gxTpr_Participantetipopessoa = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteNome")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="ParticipanteRepresentanteNome", Order=9)]
		public  string gxTpr_Participanterepresentantenome
		{
			get { 
				return sdt.gxTpr_Participanterepresentantenome;

			}
			set { 
				 sdt.gxTpr_Participanterepresentantenome = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteEmail")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="ParticipanteRepresentanteEmail", Order=10)]
		public  string gxTpr_Participanterepresentanteemail
		{
			get { 
				return sdt.gxTpr_Participanterepresentanteemail;

			}
			set { 
				 sdt.gxTpr_Participanterepresentanteemail = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteDocumento")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="ParticipanteRepresentanteDocumento", Order=11)]
		public  string gxTpr_Participanterepresentantedocumento
		{
			get { 
				return sdt.gxTpr_Participanterepresentantedocumento;

			}
			set { 
				 sdt.gxTpr_Participanterepresentantedocumento = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdParticipantes sdt
		{
			get { 
				return (SdtSdParticipantes)Sdt;
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
				sdt = new SdtSdParticipantes() ;
			}
		}
	}
	#endregion
}