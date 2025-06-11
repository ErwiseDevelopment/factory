/*
				   File: type_SdtSdParticipantesContrato
			Description: SdParticipantesContrato
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
	[XmlRoot(ElementName="SdParticipantesContrato")]
	[XmlType(TypeName="SdParticipantesContrato" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdParticipantesContrato : GxUserType
	{
		public SdtSdParticipantesContrato( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdParticipantesContrato_Participantenome = "";

			gxTv_SdtSdParticipantesContrato_Participanteemail = "";

			gxTv_SdtSdParticipantesContrato_Participanterepresentantedocumento = "";

			gxTv_SdtSdParticipantesContrato_Participanterepresentanteemail = "";

			gxTv_SdtSdParticipantesContrato_Participanterepresentantenome = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantecpf = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantekey = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipanteremoteaddres = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantegeolocalizacao = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedispositivo = "";

		}

		public SdtSdParticipantesContrato(IGxContext context)
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
			AddObjectProperty("ParticipanteNome", gxTpr_Participantenome, false);


			AddObjectProperty("ParticipanteEmail", gxTpr_Participanteemail, false);


			AddObjectProperty("ParticipanteRepresentanteDocumento", gxTpr_Participanterepresentantedocumento, false);


			AddObjectProperty("ParticipanteRepresentanteEmail", gxTpr_Participanterepresentanteemail, false);


			AddObjectProperty("ParticipanteRepresentanteNome", gxTpr_Participanterepresentantenome, false);


			AddObjectProperty("AssinaturaParticipanteCPF", gxTpr_Assinaturaparticipantecpf, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Assinaturaparticipantenascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Assinaturaparticipantenascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Assinaturaparticipantenascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("AssinaturaParticipanteNascimento", sDateCnv, false);



			datetime_STZ = gxTpr_Assinaturaparticipantedataconclusao;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("AssinaturaParticipanteDataConclusao", sDateCnv, false);



			AddObjectProperty("AssinaturaParticipanteKey", gxTpr_Assinaturaparticipantekey, false);


			AddObjectProperty("AssinaturaParticipanteRemoteAddres", gxTpr_Assinaturaparticipanteremoteaddres, false);


			AddObjectProperty("AssinaturaParticipanteGeolocalizacao", gxTpr_Assinaturaparticipantegeolocalizacao, false);


			AddObjectProperty("AssinaturaParticipanteDispositivo", gxTpr_Assinaturaparticipantedispositivo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ParticipanteNome")]
		[XmlElement(ElementName="ParticipanteNome")]
		public string gxTpr_Participantenome
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Participantenome; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Participantenome = value;
				SetDirty("Participantenome");
			}
		}




		[SoapElement(ElementName="ParticipanteEmail")]
		[XmlElement(ElementName="ParticipanteEmail")]
		public string gxTpr_Participanteemail
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Participanteemail; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Participanteemail = value;
				SetDirty("Participanteemail");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteDocumento")]
		[XmlElement(ElementName="ParticipanteRepresentanteDocumento")]
		public string gxTpr_Participanterepresentantedocumento
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Participanterepresentantedocumento; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Participanterepresentantedocumento = value;
				SetDirty("Participanterepresentantedocumento");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteEmail")]
		[XmlElement(ElementName="ParticipanteRepresentanteEmail")]
		public string gxTpr_Participanterepresentanteemail
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Participanterepresentanteemail; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Participanterepresentanteemail = value;
				SetDirty("Participanterepresentanteemail");
			}
		}




		[SoapElement(ElementName="ParticipanteRepresentanteNome")]
		[XmlElement(ElementName="ParticipanteRepresentanteNome")]
		public string gxTpr_Participanterepresentantenome
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Participanterepresentantenome; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Participanterepresentantenome = value;
				SetDirty("Participanterepresentantenome");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteCPF")]
		[XmlElement(ElementName="AssinaturaParticipanteCPF")]
		public string gxTpr_Assinaturaparticipantecpf
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantecpf; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantecpf = value;
				SetDirty("Assinaturaparticipantecpf");
			}
		}



		[SoapElement(ElementName="AssinaturaParticipanteNascimento")]
		[XmlElement(ElementName="AssinaturaParticipanteNascimento" , IsNullable=true)]
		public string gxTpr_Assinaturaparticipantenascimento_Nullable
		{
			get {
				if ( gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento).value ;
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Assinaturaparticipantenascimento
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento = value;
				SetDirty("Assinaturaparticipantenascimento");
			}
		}


		[SoapElement(ElementName="AssinaturaParticipanteDataConclusao")]
		[XmlElement(ElementName="AssinaturaParticipanteDataConclusao" , IsNullable=true)]
		public string gxTpr_Assinaturaparticipantedataconclusao_Nullable
		{
			get {
				if ( gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao).value ;
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Assinaturaparticipantedataconclusao
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao = value;
				SetDirty("Assinaturaparticipantedataconclusao");
			}
		}



		[SoapElement(ElementName="AssinaturaParticipanteKey")]
		[XmlElement(ElementName="AssinaturaParticipanteKey")]
		public string gxTpr_Assinaturaparticipantekey
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantekey; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantekey = value;
				SetDirty("Assinaturaparticipantekey");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteRemoteAddres")]
		[XmlElement(ElementName="AssinaturaParticipanteRemoteAddres")]
		public string gxTpr_Assinaturaparticipanteremoteaddres
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipanteremoteaddres; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipanteremoteaddres = value;
				SetDirty("Assinaturaparticipanteremoteaddres");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteGeolocalizacao")]
		[XmlElement(ElementName="AssinaturaParticipanteGeolocalizacao")]
		public string gxTpr_Assinaturaparticipantegeolocalizacao
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantegeolocalizacao; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantegeolocalizacao = value;
				SetDirty("Assinaturaparticipantegeolocalizacao");
			}
		}




		[SoapElement(ElementName="AssinaturaParticipanteDispositivo")]
		[XmlElement(ElementName="AssinaturaParticipanteDispositivo")]
		public string gxTpr_Assinaturaparticipantedispositivo
		{
			get {
				return gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedispositivo; 
			}
			set {
				gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedispositivo = value;
				SetDirty("Assinaturaparticipantedispositivo");
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
			gxTv_SdtSdParticipantesContrato_Participantenome = "";
			gxTv_SdtSdParticipantesContrato_Participanteemail = "";
			gxTv_SdtSdParticipantesContrato_Participanterepresentantedocumento = "";
			gxTv_SdtSdParticipantesContrato_Participanterepresentanteemail = "";
			gxTv_SdtSdParticipantesContrato_Participanterepresentantenome = "";
			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantecpf = "";

			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantekey = "";
			gxTv_SdtSdParticipantesContrato_Assinaturaparticipanteremoteaddres = "";
			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantegeolocalizacao = "";
			gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedispositivo = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtSdParticipantesContrato_Participantenome;
		 

		protected string gxTv_SdtSdParticipantesContrato_Participanteemail;
		 

		protected string gxTv_SdtSdParticipantesContrato_Participanterepresentantedocumento;
		 

		protected string gxTv_SdtSdParticipantesContrato_Participanterepresentanteemail;
		 

		protected string gxTv_SdtSdParticipantesContrato_Participanterepresentantenome;
		 

		protected string gxTv_SdtSdParticipantesContrato_Assinaturaparticipantecpf;
		 

		protected DateTime gxTv_SdtSdParticipantesContrato_Assinaturaparticipantenascimento;
		 

		protected DateTime gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedataconclusao;
		 

		protected string gxTv_SdtSdParticipantesContrato_Assinaturaparticipantekey;
		 

		protected string gxTv_SdtSdParticipantesContrato_Assinaturaparticipanteremoteaddres;
		 

		protected string gxTv_SdtSdParticipantesContrato_Assinaturaparticipantegeolocalizacao;
		 

		protected string gxTv_SdtSdParticipantesContrato_Assinaturaparticipantedispositivo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdParticipantesContrato", Namespace="Factory21")]
	public class SdtSdParticipantesContrato_RESTInterface : GxGenericCollectionItem<SdtSdParticipantesContrato>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdParticipantesContrato_RESTInterface( ) : base()
		{	
		}

		public SdtSdParticipantesContrato_RESTInterface( SdtSdParticipantesContrato psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ParticipanteNome")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ParticipanteNome", Order=0)]
		public  string gxTpr_Participantenome
		{
			get { 
				return sdt.gxTpr_Participantenome;

			}
			set { 
				 sdt.gxTpr_Participantenome = value;
			}
		}

		[JsonPropertyName("ParticipanteEmail")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ParticipanteEmail", Order=1)]
		public  string gxTpr_Participanteemail
		{
			get { 
				return sdt.gxTpr_Participanteemail;

			}
			set { 
				 sdt.gxTpr_Participanteemail = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteDocumento")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ParticipanteRepresentanteDocumento", Order=2)]
		public  string gxTpr_Participanterepresentantedocumento
		{
			get { 
				return sdt.gxTpr_Participanterepresentantedocumento;

			}
			set { 
				 sdt.gxTpr_Participanterepresentantedocumento = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteEmail")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ParticipanteRepresentanteEmail", Order=3)]
		public  string gxTpr_Participanterepresentanteemail
		{
			get { 
				return sdt.gxTpr_Participanterepresentanteemail;

			}
			set { 
				 sdt.gxTpr_Participanterepresentanteemail = value;
			}
		}

		[JsonPropertyName("ParticipanteRepresentanteNome")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ParticipanteRepresentanteNome", Order=4)]
		public  string gxTpr_Participanterepresentantenome
		{
			get { 
				return sdt.gxTpr_Participanterepresentantenome;

			}
			set { 
				 sdt.gxTpr_Participanterepresentantenome = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteCPF")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="AssinaturaParticipanteCPF", Order=5)]
		public  string gxTpr_Assinaturaparticipantecpf
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantecpf;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantecpf = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteNascimento")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="AssinaturaParticipanteNascimento", Order=6)]
		public  string gxTpr_Assinaturaparticipantenascimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Assinaturaparticipantenascimento);

			}
			set { 
				sdt.gxTpr_Assinaturaparticipantenascimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("AssinaturaParticipanteDataConclusao")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="AssinaturaParticipanteDataConclusao", Order=7)]
		public  string gxTpr_Assinaturaparticipantedataconclusao
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantedataconclusao,context);

			}
			set { 
				sdt.gxTpr_Assinaturaparticipantedataconclusao = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("AssinaturaParticipanteKey")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="AssinaturaParticipanteKey", Order=8)]
		public  string gxTpr_Assinaturaparticipantekey
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantekey;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantekey = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteRemoteAddres")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="AssinaturaParticipanteRemoteAddres", Order=9)]
		public  string gxTpr_Assinaturaparticipanteremoteaddres
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipanteremoteaddres;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipanteremoteaddres = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteGeolocalizacao")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="AssinaturaParticipanteGeolocalizacao", Order=10)]
		public  string gxTpr_Assinaturaparticipantegeolocalizacao
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantegeolocalizacao;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantegeolocalizacao = value;
			}
		}

		[JsonPropertyName("AssinaturaParticipanteDispositivo")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="AssinaturaParticipanteDispositivo", Order=11)]
		public  string gxTpr_Assinaturaparticipantedispositivo
		{
			get { 
				return sdt.gxTpr_Assinaturaparticipantedispositivo;

			}
			set { 
				 sdt.gxTpr_Assinaturaparticipantedispositivo = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdParticipantesContrato sdt
		{
			get { 
				return (SdtSdParticipantesContrato)Sdt;
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
				sdt = new SdtSdParticipantesContrato() ;
			}
		}
	}
	#endregion
}