/*
				   File: type_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem
			Description: chequesDevolvidos
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.chequesDevolvidosItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.chequesDevolvidosItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem(IGxContext context)
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
			AddObjectProperty("totalConsultasCheques", gxTpr_Totalconsultascheques, false);


			AddObjectProperty("quantidadeChequeSemFundos", gxTpr_Quantidadechequesemfundos, false);


			AddObjectProperty("valorTotalChequeSemFundos", gxTpr_Valortotalchequesemfundos, false);


			AddObjectProperty("quantidadeTotalChequeSustado", gxTpr_Quantidadetotalchequesustado, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dataultimaocorrenciachequesustado)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dataultimaocorrenciachequesustado)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dataultimaocorrenciachequesustado)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("dataUltimaOcorrenciaChequeSustado", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="totalConsultasCheques")]
		[XmlElement(ElementName="totalConsultasCheques")]
		public string gxTpr_Totalconsultascheques_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Totalconsultascheques, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Totalconsultascheques = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalconsultascheques
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Totalconsultascheques; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Totalconsultascheques = value;
				SetDirty("Totalconsultascheques");
			}
		}



		[SoapElement(ElementName="quantidadeChequeSemFundos")]
		[XmlElement(ElementName="quantidadeChequeSemFundos")]
		public string gxTpr_Quantidadechequesemfundos_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadechequesemfundos, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadechequesemfundos = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadechequesemfundos
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadechequesemfundos; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadechequesemfundos = value;
				SetDirty("Quantidadechequesemfundos");
			}
		}



		[SoapElement(ElementName="valorTotalChequeSemFundos")]
		[XmlElement(ElementName="valorTotalChequeSemFundos")]
		public string gxTpr_Valortotalchequesemfundos_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Valortotalchequesemfundos, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Valortotalchequesemfundos = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalchequesemfundos
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Valortotalchequesemfundos; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Valortotalchequesemfundos = value;
				SetDirty("Valortotalchequesemfundos");
			}
		}



		[SoapElement(ElementName="quantidadeTotalChequeSustado")]
		[XmlElement(ElementName="quantidadeTotalChequeSustado")]
		public string gxTpr_Quantidadetotalchequesustado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadetotalchequesustado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadetotalchequesustado = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalchequesustado
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadetotalchequesustado; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadetotalchequesustado = value;
				SetDirty("Quantidadetotalchequesustado");
			}
		}



		[SoapElement(ElementName="dataUltimaOcorrenciaChequeSustado")]
		[XmlElement(ElementName="dataUltimaOcorrenciaChequeSustado" , IsNullable=true)]
		public string gxTpr_Dataultimaocorrenciachequesustado_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataultimaocorrenciachequesustado
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado = value;
				SetDirty("Dataultimaocorrenciachequesustado");
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
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Totalconsultascheques;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadechequesemfundos;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Valortotalchequesemfundos;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Quantidadetotalchequesustado;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_Dataultimaocorrenciachequesustado;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.chequesDevolvidosItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_RESTInterface( SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("totalConsultasCheques")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="totalConsultasCheques", Order=0)]
		public  string gxTpr_Totalconsultascheques
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalconsultascheques, 10, 5));

			}
			set { 
				sdt.gxTpr_Totalconsultascheques =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeChequeSemFundos")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="quantidadeChequeSemFundos", Order=1)]
		public  string gxTpr_Quantidadechequesemfundos
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadechequesemfundos, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadechequesemfundos =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalChequeSemFundos")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="valorTotalChequeSemFundos", Order=2)]
		public  string gxTpr_Valortotalchequesemfundos
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalchequesemfundos, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalchequesemfundos =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeTotalChequeSustado")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="quantidadeTotalChequeSustado", Order=3)]
		public  string gxTpr_Quantidadetotalchequesustado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalchequesustado, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalchequesustado =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataUltimaOcorrenciaChequeSustado")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="dataUltimaOcorrenciaChequeSustado", Order=4)]
		public  string gxTpr_Dataultimaocorrenciachequesustado
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dataultimaocorrenciachequesustado);

			}
			set { 
				sdt.gxTpr_Dataultimaocorrenciachequesustado = DateTimeUtil.CToD2(value);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem() ;
			}
		}
	}
	#endregion
}