/*
				   File: type_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem
			Description: acoesJudiciais
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.anotacoesCompletasItem.acoesJudiciaisItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.anotacoesCompletasItem.acoesJudiciaisItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Natureza = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Distribuidor = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Vara = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Cidade = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Uf = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Principal = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Tipomoeda = "";

		}

		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem(IGxContext context)
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



			AddObjectProperty("natureza", gxTpr_Natureza, false);


			AddObjectProperty("valor", gxTpr_Valor, false);


			AddObjectProperty("distribuidor", gxTpr_Distribuidor, false);


			AddObjectProperty("vara", gxTpr_Vara, false);


			AddObjectProperty("cidade", gxTpr_Cidade, false);


			AddObjectProperty("uf", gxTpr_Uf, false);


			AddObjectProperty("qtdeOcorrencia", gxTpr_Qtdeocorrencia, false);


			AddObjectProperty("principal", gxTpr_Principal, false);


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
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataocorrencia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia = value;
				SetDirty("Dataocorrencia");
			}
		}



		[SoapElement(ElementName="natureza")]
		[XmlElement(ElementName="natureza")]
		public string gxTpr_Natureza
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Natureza; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Natureza = value;
				SetDirty("Natureza");
			}
		}



		[SoapElement(ElementName="valor")]
		[XmlElement(ElementName="valor")]
		public string gxTpr_Valor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Valor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Valor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valor
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Valor; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Valor = value;
				SetDirty("Valor");
			}
		}




		[SoapElement(ElementName="distribuidor")]
		[XmlElement(ElementName="distribuidor")]
		public string gxTpr_Distribuidor
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Distribuidor; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Distribuidor = value;
				SetDirty("Distribuidor");
			}
		}




		[SoapElement(ElementName="vara")]
		[XmlElement(ElementName="vara")]
		public string gxTpr_Vara
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Vara; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Vara = value;
				SetDirty("Vara");
			}
		}




		[SoapElement(ElementName="cidade")]
		[XmlElement(ElementName="cidade")]
		public string gxTpr_Cidade
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Cidade; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Cidade = value;
				SetDirty("Cidade");
			}
		}




		[SoapElement(ElementName="uf")]
		[XmlElement(ElementName="uf")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Uf; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Uf = value;
				SetDirty("Uf");
			}
		}



		[SoapElement(ElementName="qtdeOcorrencia")]
		[XmlElement(ElementName="qtdeOcorrencia")]
		public string gxTpr_Qtdeocorrencia_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Qtdeocorrencia, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Qtdeocorrencia = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Qtdeocorrencia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Qtdeocorrencia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Qtdeocorrencia = value;
				SetDirty("Qtdeocorrencia");
			}
		}




		[SoapElement(ElementName="principal")]
		[XmlElement(ElementName="principal")]
		public string gxTpr_Principal
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Principal; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Principal = value;
				SetDirty("Principal");
			}
		}




		[SoapElement(ElementName="tipoMoeda")]
		[XmlElement(ElementName="tipoMoeda")]
		public string gxTpr_Tipomoeda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Tipomoeda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Tipomoeda = value;
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
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Natureza = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Distribuidor = "";
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Vara = "";
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Cidade = "";
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Uf = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Principal = "";
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Tipomoeda = "";
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

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Dataocorrencia;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Natureza;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Valor;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Distribuidor;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Vara;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Cidade;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Uf;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Qtdeocorrencia;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Principal;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_Tipomoeda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.anotacoesCompletasItem.acoesJudiciaisItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_RESTInterface( SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem psdt ) : base(psdt)
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

		[JsonPropertyName("natureza")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="natureza", Order=1)]
		public  string gxTpr_Natureza
		{
			get { 
				return sdt.gxTpr_Natureza;

			}
			set { 
				 sdt.gxTpr_Natureza = value;
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

		[JsonPropertyName("distribuidor")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="distribuidor", Order=3)]
		public  string gxTpr_Distribuidor
		{
			get { 
				return sdt.gxTpr_Distribuidor;

			}
			set { 
				 sdt.gxTpr_Distribuidor = value;
			}
		}

		[JsonPropertyName("vara")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="vara", Order=4)]
		public  string gxTpr_Vara
		{
			get { 
				return sdt.gxTpr_Vara;

			}
			set { 
				 sdt.gxTpr_Vara = value;
			}
		}

		[JsonPropertyName("cidade")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="cidade", Order=5)]
		public  string gxTpr_Cidade
		{
			get { 
				return sdt.gxTpr_Cidade;

			}
			set { 
				 sdt.gxTpr_Cidade = value;
			}
		}

		[JsonPropertyName("uf")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="uf", Order=6)]
		public  string gxTpr_Uf
		{
			get { 
				return sdt.gxTpr_Uf;

			}
			set { 
				 sdt.gxTpr_Uf = value;
			}
		}

		[JsonPropertyName("qtdeOcorrencia")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="qtdeOcorrencia", Order=7)]
		public  string gxTpr_Qtdeocorrencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Qtdeocorrencia, 10, 5));

			}
			set { 
				sdt.gxTpr_Qtdeocorrencia =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("principal")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="principal", Order=8)]
		public  string gxTpr_Principal
		{
			get { 
				return sdt.gxTpr_Principal;

			}
			set { 
				 sdt.gxTpr_Principal = value;
			}
		}

		[JsonPropertyName("tipoMoeda")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="tipoMoeda", Order=9)]
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
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem() ;
			}
		}
	}
	#endregion
}