/*
				   File: type_SdtSdGetSignature
			Description: SdGetSignature
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
	[XmlRoot(ElementName="SdGetSignature")]
	[XmlType(TypeName="SdGetSignature" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdGetSignature : GxUserType
	{
		public SdtSdGetSignature( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdGetSignature_Enderecoip = "";

			gxTv_SdtSdGetSignature_Geolocalizacao = "";

			gxTv_SdtSdGetSignature_Dispositivo = "";

			gxTv_SdtSdGetSignature_Datahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdGetSignature_Cpf = "";

			gxTv_SdtSdGetSignature_Email = "";

			gxTv_SdtSdGetSignature_Telefone = "";

			gxTv_SdtSdGetSignature_Token = "";

		}

		public SdtSdGetSignature(IGxContext context)
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
			AddObjectProperty("EnderecoIP", gxTpr_Enderecoip, false);


			AddObjectProperty("Geolocalizacao", gxTpr_Geolocalizacao, false);


			AddObjectProperty("Dispositivo", gxTpr_Dispositivo, false);


			datetime_STZ = gxTpr_Datahora;
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
			AddObjectProperty("DataHora", sDateCnv, false);



			AddObjectProperty("CPF", gxTpr_Cpf, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Nascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Nascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Nascimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Nascimento", sDateCnv, false);



			AddObjectProperty("EMail", gxTpr_Email, false);


			AddObjectProperty("Telefone", gxTpr_Telefone, false);


			AddObjectProperty("Token", gxTpr_Token, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EnderecoIP")]
		[XmlElement(ElementName="EnderecoIP")]
		public string gxTpr_Enderecoip
		{
			get {
				return gxTv_SdtSdGetSignature_Enderecoip; 
			}
			set {
				gxTv_SdtSdGetSignature_Enderecoip = value;
				SetDirty("Enderecoip");
			}
		}




		[SoapElement(ElementName="Geolocalizacao")]
		[XmlElement(ElementName="Geolocalizacao")]
		public string gxTpr_Geolocalizacao
		{
			get {
				return gxTv_SdtSdGetSignature_Geolocalizacao; 
			}
			set {
				gxTv_SdtSdGetSignature_Geolocalizacao = value;
				SetDirty("Geolocalizacao");
			}
		}




		[SoapElement(ElementName="Dispositivo")]
		[XmlElement(ElementName="Dispositivo")]
		public string gxTpr_Dispositivo
		{
			get {
				return gxTv_SdtSdGetSignature_Dispositivo; 
			}
			set {
				gxTv_SdtSdGetSignature_Dispositivo = value;
				SetDirty("Dispositivo");
			}
		}



		[SoapElement(ElementName="DataHora")]
		[XmlElement(ElementName="DataHora" , IsNullable=true)]
		public string gxTpr_Datahora_Nullable
		{
			get {
				if ( gxTv_SdtSdGetSignature_Datahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdGetSignature_Datahora).value ;
			}
			set {
				gxTv_SdtSdGetSignature_Datahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Datahora
		{
			get {
				return gxTv_SdtSdGetSignature_Datahora; 
			}
			set {
				gxTv_SdtSdGetSignature_Datahora = value;
				SetDirty("Datahora");
			}
		}



		[SoapElement(ElementName="CPF")]
		[XmlElement(ElementName="CPF")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdGetSignature_Cpf; 
			}
			set {
				gxTv_SdtSdGetSignature_Cpf = value;
				SetDirty("Cpf");
			}
		}



		[SoapElement(ElementName="Nascimento")]
		[XmlElement(ElementName="Nascimento" , IsNullable=true)]
		public string gxTpr_Nascimento_Nullable
		{
			get {
				if ( gxTv_SdtSdGetSignature_Nascimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdGetSignature_Nascimento).value ;
			}
			set {
				gxTv_SdtSdGetSignature_Nascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nascimento
		{
			get {
				return gxTv_SdtSdGetSignature_Nascimento; 
			}
			set {
				gxTv_SdtSdGetSignature_Nascimento = value;
				SetDirty("Nascimento");
			}
		}



		[SoapElement(ElementName="EMail")]
		[XmlElement(ElementName="EMail")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSdGetSignature_Email; 
			}
			set {
				gxTv_SdtSdGetSignature_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="Telefone")]
		[XmlElement(ElementName="Telefone")]
		public string gxTpr_Telefone
		{
			get {
				return gxTv_SdtSdGetSignature_Telefone; 
			}
			set {
				gxTv_SdtSdGetSignature_Telefone = value;
				SetDirty("Telefone");
			}
		}




		[SoapElement(ElementName="Token")]
		[XmlElement(ElementName="Token")]
		public string gxTpr_Token
		{
			get {
				return gxTv_SdtSdGetSignature_Token; 
			}
			set {
				gxTv_SdtSdGetSignature_Token = value;
				SetDirty("Token");
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
			gxTv_SdtSdGetSignature_Enderecoip = "";
			gxTv_SdtSdGetSignature_Geolocalizacao = "";
			gxTv_SdtSdGetSignature_Dispositivo = "";
			gxTv_SdtSdGetSignature_Datahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdGetSignature_Cpf = "";

			gxTv_SdtSdGetSignature_Email = "";
			gxTv_SdtSdGetSignature_Telefone = "";
			gxTv_SdtSdGetSignature_Token = "";
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

		protected string gxTv_SdtSdGetSignature_Enderecoip;
		 

		protected string gxTv_SdtSdGetSignature_Geolocalizacao;
		 

		protected string gxTv_SdtSdGetSignature_Dispositivo;
		 

		protected DateTime gxTv_SdtSdGetSignature_Datahora;
		 

		protected string gxTv_SdtSdGetSignature_Cpf;
		 

		protected DateTime gxTv_SdtSdGetSignature_Nascimento;
		 

		protected string gxTv_SdtSdGetSignature_Email;
		 

		protected string gxTv_SdtSdGetSignature_Telefone;
		 

		protected string gxTv_SdtSdGetSignature_Token;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdGetSignature", Namespace="Factory21")]
	public class SdtSdGetSignature_RESTInterface : GxGenericCollectionItem<SdtSdGetSignature>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdGetSignature_RESTInterface( ) : base()
		{	
		}

		public SdtSdGetSignature_RESTInterface( SdtSdGetSignature psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("EnderecoIP")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="EnderecoIP", Order=0)]
		public  string gxTpr_Enderecoip
		{
			get { 
				return sdt.gxTpr_Enderecoip;

			}
			set { 
				 sdt.gxTpr_Enderecoip = value;
			}
		}

		[JsonPropertyName("Geolocalizacao")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Geolocalizacao", Order=1)]
		public  string gxTpr_Geolocalizacao
		{
			get { 
				return sdt.gxTpr_Geolocalizacao;

			}
			set { 
				 sdt.gxTpr_Geolocalizacao = value;
			}
		}

		[JsonPropertyName("Dispositivo")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="Dispositivo", Order=2)]
		public  string gxTpr_Dispositivo
		{
			get { 
				return sdt.gxTpr_Dispositivo;

			}
			set { 
				 sdt.gxTpr_Dispositivo = value;
			}
		}

		[JsonPropertyName("DataHora")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="DataHora", Order=3)]
		public  string gxTpr_Datahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datahora,context);

			}
			set { 
				sdt.gxTpr_Datahora = DateTimeUtil.CToT2(value,context);
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

		[JsonPropertyName("Nascimento")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="Nascimento", Order=5)]
		public  string gxTpr_Nascimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Nascimento);

			}
			set { 
				sdt.gxTpr_Nascimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("EMail")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="EMail", Order=6)]
		public  string gxTpr_Email
		{
			get { 
				return sdt.gxTpr_Email;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[JsonPropertyName("Telefone")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="Telefone", Order=7)]
		public  string gxTpr_Telefone
		{
			get { 
				return sdt.gxTpr_Telefone;

			}
			set { 
				 sdt.gxTpr_Telefone = value;
			}
		}

		[JsonPropertyName("Token")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="Token", Order=8)]
		public  string gxTpr_Token
		{
			get { 
				return sdt.gxTpr_Token;

			}
			set { 
				 sdt.gxTpr_Token = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdGetSignature sdt
		{
			get { 
				return (SdtSdGetSignature)Sdt;
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
				sdt = new SdtSdGetSignature() ;
			}
		}
	}
	#endregion
}