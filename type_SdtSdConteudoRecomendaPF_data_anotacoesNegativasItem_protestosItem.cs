/*
				   File: type_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem
			Description: protestos
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.anotacoesNegativasItem.protestosItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.anotacoesNegativasItem.protestosItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cartorio = "";

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cidade = "";

		}

		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem(IGxContext context)
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



			AddObjectProperty("valor", gxTpr_Valor, false);


			AddObjectProperty("cartorio", gxTpr_Cartorio, false);


			AddObjectProperty("cidade", gxTpr_Cidade, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="dataOcorrencia")]
		[XmlElement(ElementName="dataOcorrencia" , IsNullable=true)]
		public string gxTpr_Dataocorrencia_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataocorrencia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia = value;
				SetDirty("Dataocorrencia");
			}
		}


		[SoapElement(ElementName="valor")]
		[XmlElement(ElementName="valor")]
		public string gxTpr_Valor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Valor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Valor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valor
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Valor; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Valor = value;
				SetDirty("Valor");
			}
		}




		[SoapElement(ElementName="cartorio")]
		[XmlElement(ElementName="cartorio")]
		public string gxTpr_Cartorio
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cartorio; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cartorio = value;
				SetDirty("Cartorio");
			}
		}




		[SoapElement(ElementName="cidade")]
		[XmlElement(ElementName="cidade")]
		public string gxTpr_Cidade
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cidade; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cidade = value;
				SetDirty("Cidade");
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
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cartorio = "";
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cidade = "";
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

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Dataocorrencia;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Valor;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cartorio;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_Cidade;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.anotacoesNegativasItem.protestosItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_RESTInterface( SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem psdt ) : base(psdt)
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

		[JsonPropertyName("valor")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valor", Order=1)]
		public  string gxTpr_Valor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valor, 10, 5));

			}
			set { 
				sdt.gxTpr_Valor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("cartorio")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="cartorio", Order=2)]
		public  string gxTpr_Cartorio
		{
			get { 
				return sdt.gxTpr_Cartorio;

			}
			set { 
				 sdt.gxTpr_Cartorio = value;
			}
		}

		[JsonPropertyName("cidade")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="cidade", Order=3)]
		public  string gxTpr_Cidade
		{
			get { 
				return sdt.gxTpr_Cidade;

			}
			set { 
				 sdt.gxTpr_Cidade = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem() ;
			}
		}
	}
	#endregion
}