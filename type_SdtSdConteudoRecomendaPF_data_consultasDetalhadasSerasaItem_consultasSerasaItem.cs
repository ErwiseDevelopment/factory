/*
				   File: type_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem
			Description: consultasSerasa
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem.consultasSerasaItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem.consultasSerasaItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Origem = "";

			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Modalidade = "";

			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Tipomoeda = "";

		}

		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem(IGxContext context)
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
			datetime_STZ = gxTpr_Dataocorrencia;
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
			AddObjectProperty("dataOcorrencia", sDateCnv, false);



			AddObjectProperty("origem", gxTpr_Origem, false);


			AddObjectProperty("valor", gxTpr_Valor, false);


			AddObjectProperty("modalidade", gxTpr_Modalidade, false);


			AddObjectProperty("tipoMoeda", gxTpr_Tipomoeda, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="dataOcorrencia")]
		[XmlElement(ElementName="dataOcorrencia" , IsNullable=true)]
		public string gxTpr_Dataocorrencia_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataocorrencia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia = value;
				SetDirty("Dataocorrencia");
			}
		}



		[SoapElement(ElementName="origem")]
		[XmlElement(ElementName="origem")]
		public string gxTpr_Origem
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Origem; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Origem = value;
				SetDirty("Origem");
			}
		}



		[SoapElement(ElementName="valor")]
		[XmlElement(ElementName="valor")]
		public string gxTpr_Valor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Valor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Valor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valor
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Valor; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Valor = value;
				SetDirty("Valor");
			}
		}




		[SoapElement(ElementName="modalidade")]
		[XmlElement(ElementName="modalidade")]
		public string gxTpr_Modalidade
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Modalidade; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Modalidade = value;
				SetDirty("Modalidade");
			}
		}




		[SoapElement(ElementName="tipoMoeda")]
		[XmlElement(ElementName="tipoMoeda")]
		public string gxTpr_Tipomoeda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Tipomoeda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Tipomoeda = value;
				SetDirty("Tipomoeda");
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
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Origem = "";

			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Modalidade = "";
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Tipomoeda = "";
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

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Dataocorrencia;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Origem;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Valor;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Modalidade;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_Tipomoeda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem.consultasSerasaItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_RESTInterface( SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("dataOcorrencia")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="dataOcorrencia", Order=0)]
		public  string gxTpr_Dataocorrencia
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Dataocorrencia,context);

			}
			set { 
				sdt.gxTpr_Dataocorrencia = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("origem")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="origem", Order=1)]
		public  string gxTpr_Origem
		{
			get { 
				return sdt.gxTpr_Origem;

			}
			set { 
				 sdt.gxTpr_Origem = value;
			}
		}

		[JsonPropertyName("valor")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="valor", Order=2)]
		public  string gxTpr_Valor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valor, 10, 5));

			}
			set { 
				sdt.gxTpr_Valor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("modalidade")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="modalidade", Order=3)]
		public  string gxTpr_Modalidade
		{
			get { 
				return sdt.gxTpr_Modalidade;

			}
			set { 
				 sdt.gxTpr_Modalidade = value;
			}
		}

		[JsonPropertyName("tipoMoeda")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="tipoMoeda", Order=4)]
		public  string gxTpr_Tipomoeda
		{
			get { 
				return sdt.gxTpr_Tipomoeda;

			}
			set { 
				 sdt.gxTpr_Tipomoeda = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem() ;
			}
		}
	}
	#endregion
}