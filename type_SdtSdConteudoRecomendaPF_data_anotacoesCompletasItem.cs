/*
				   File: type_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem
			Description: anotacoesCompletas
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.anotacoesCompletasItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.anotacoesCompletasItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial = (DateTime)(DateTime.MinValue);


		}

		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem(IGxContext context)
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
			AddObjectProperty("quantidadeTotalFalencia", gxTpr_Quantidadetotalfalencia, false);


			datetime_STZ = gxTpr_Dataprimeiraacaojudicial;
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
			AddObjectProperty("dataPrimeiraAcaoJudicial", sDateCnv, false);



			datetime_STZ = gxTpr_Dataultimaacaojudicial;
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
			AddObjectProperty("dataUltimaAcaoJudicial", sDateCnv, false);



			AddObjectProperty("valorUltimaAcaoJudicial", gxTpr_Valorultimaacaojudicial, false);


			AddObjectProperty("quantidadeTotalAcaoJudicial", gxTpr_Quantidadetotalacaojudicial, false);


			AddObjectProperty("valorTotalAcaoJudicial", gxTpr_Valortotalacaojudicial, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais != null)
			{
				AddObjectProperty("acoesJudiciais", gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="quantidadeTotalFalencia")]
		[XmlElement(ElementName="quantidadeTotalFalencia")]
		public string gxTpr_Quantidadetotalfalencia_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalfalencia, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalfalencia = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalfalencia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalfalencia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalfalencia = value;
				SetDirty("Quantidadetotalfalencia");
			}
		}



		[SoapElement(ElementName="dataPrimeiraAcaoJudicial")]
		[XmlElement(ElementName="dataPrimeiraAcaoJudicial" , IsNullable=true)]
		public string gxTpr_Dataprimeiraacaojudicial_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataprimeiraacaojudicial
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial = value;
				SetDirty("Dataprimeiraacaojudicial");
			}
		}


		[SoapElement(ElementName="dataUltimaAcaoJudicial")]
		[XmlElement(ElementName="dataUltimaAcaoJudicial" , IsNullable=true)]
		public string gxTpr_Dataultimaacaojudicial_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataultimaacaojudicial
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial = value;
				SetDirty("Dataultimaacaojudicial");
			}
		}


		[SoapElement(ElementName="valorUltimaAcaoJudicial")]
		[XmlElement(ElementName="valorUltimaAcaoJudicial")]
		public string gxTpr_Valorultimaacaojudicial_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valorultimaacaojudicial, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valorultimaacaojudicial = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorultimaacaojudicial
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valorultimaacaojudicial; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valorultimaacaojudicial = value;
				SetDirty("Valorultimaacaojudicial");
			}
		}



		[SoapElement(ElementName="quantidadeTotalAcaoJudicial")]
		[XmlElement(ElementName="quantidadeTotalAcaoJudicial")]
		public string gxTpr_Quantidadetotalacaojudicial_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalacaojudicial, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalacaojudicial = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalacaojudicial
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalacaojudicial; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalacaojudicial = value;
				SetDirty("Quantidadetotalacaojudicial");
			}
		}



		[SoapElement(ElementName="valorTotalAcaoJudicial")]
		[XmlElement(ElementName="valorTotalAcaoJudicial")]
		public string gxTpr_Valortotalacaojudicial_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valortotalacaojudicial, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valortotalacaojudicial = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalacaojudicial
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valortotalacaojudicial; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valortotalacaojudicial = value;
				SetDirty("Valortotalacaojudicial");
			}
		}




		[SoapElement(ElementName="acoesJudiciais" )]
		[XmlArray(ElementName="acoesJudiciais"  )]
		[XmlArrayItemAttribute(ElementName="acoesJudiciaisItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem> gxTpr_Acoesjudiciais
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem>( context, "SdConteudoRecomendaPF.data.anotacoesCompletasItem.acoesJudiciaisItem", "");
				}
				SetDirty("Acoesjudiciais");
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais = value;
				SetDirty("Acoesjudiciais");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais == null;
		}
		public bool ShouldSerializegxTpr_Acoesjudiciais_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais != null && gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais.Count > 0;

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
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial = (DateTime)(DateTime.MinValue);




			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_N = true;

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

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalfalencia;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataprimeiraacaojudicial;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Dataultimaacaojudicial;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valorultimaacaojudicial;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Quantidadetotalacaojudicial;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Valortotalacaojudicial;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem> gxTv_SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_Acoesjudiciais = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.anotacoesCompletasItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_RESTInterface( SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("quantidadeTotalFalencia")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="quantidadeTotalFalencia", Order=0)]
		public  string gxTpr_Quantidadetotalfalencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalfalencia, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalfalencia =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataPrimeiraAcaoJudicial")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="dataPrimeiraAcaoJudicial", Order=1)]
		public  string gxTpr_Dataprimeiraacaojudicial
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Dataprimeiraacaojudicial,context);

			}
			set { 
				sdt.gxTpr_Dataprimeiraacaojudicial = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("dataUltimaAcaoJudicial")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="dataUltimaAcaoJudicial", Order=2)]
		public  string gxTpr_Dataultimaacaojudicial
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Dataultimaacaojudicial,context);

			}
			set { 
				sdt.gxTpr_Dataultimaacaojudicial = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("valorUltimaAcaoJudicial")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="valorUltimaAcaoJudicial", Order=3)]
		public  string gxTpr_Valorultimaacaojudicial
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorultimaacaojudicial, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorultimaacaojudicial =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeTotalAcaoJudicial")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="quantidadeTotalAcaoJudicial", Order=4)]
		public  string gxTpr_Quantidadetotalacaojudicial
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalacaojudicial, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalacaojudicial =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalAcaoJudicial")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="valorTotalAcaoJudicial", Order=5)]
		public  string gxTpr_Valortotalacaojudicial
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalacaojudicial, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalacaojudicial =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("acoesJudiciais")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="acoesJudiciais", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_RESTInterface> gxTpr_Acoesjudiciais
		{
			get {
				if (sdt.ShouldSerializegxTpr_Acoesjudiciais_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem_RESTInterface>(sdt.gxTpr_Acoesjudiciais);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Acoesjudiciais);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem() ;
			}
		}
	}
	#endregion
}