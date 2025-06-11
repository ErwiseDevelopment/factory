/*
				   File: type_SdtSdSerasa_dividasVencidas
			Description: dividasVencidas
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
	[XmlRoot(ElementName="SdSerasa.dividasVencidas")]
	[XmlType(TypeName="SdSerasa.dividasVencidas" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_dividasVencidas : GxUserType
	{
		public SdtSdSerasa_dividasVencidas( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasa_dividasVencidas_Dataultimaocorrenciadividasvencidas = "";

		}

		public SdtSdSerasa_dividasVencidas(IGxContext context)
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
			AddObjectProperty("quantidadeTotalDividasVencidas", gxTpr_Quantidadetotaldividasvencidas, false);


			AddObjectProperty("valorTotalDividasVencidas", gxTpr_Valortotaldividasvencidas, false);


			AddObjectProperty("dataUltimaOcorrenciaDividasVencidas", gxTpr_Dataultimaocorrenciadividasvencidas, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="quantidadeTotalDividasVencidas")]
		[XmlElement(ElementName="quantidadeTotalDividasVencidas")]
		public string gxTpr_Quantidadetotaldividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_dividasVencidas_Quantidadetotaldividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_dividasVencidas_Quantidadetotaldividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotaldividasvencidas
		{
			get {
				return gxTv_SdtSdSerasa_dividasVencidas_Quantidadetotaldividasvencidas; 
			}
			set {
				gxTv_SdtSdSerasa_dividasVencidas_Quantidadetotaldividasvencidas = value;
				SetDirty("Quantidadetotaldividasvencidas");
			}
		}



		[SoapElement(ElementName="valorTotalDividasVencidas")]
		[XmlElement(ElementName="valorTotalDividasVencidas")]
		public string gxTpr_Valortotaldividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_dividasVencidas_Valortotaldividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_dividasVencidas_Valortotaldividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotaldividasvencidas
		{
			get {
				return gxTv_SdtSdSerasa_dividasVencidas_Valortotaldividasvencidas; 
			}
			set {
				gxTv_SdtSdSerasa_dividasVencidas_Valortotaldividasvencidas = value;
				SetDirty("Valortotaldividasvencidas");
			}
		}




		[SoapElement(ElementName="dataUltimaOcorrenciaDividasVencidas")]
		[XmlElement(ElementName="dataUltimaOcorrenciaDividasVencidas")]
		public string gxTpr_Dataultimaocorrenciadividasvencidas
		{
			get {
				return gxTv_SdtSdSerasa_dividasVencidas_Dataultimaocorrenciadividasvencidas; 
			}
			set {
				gxTv_SdtSdSerasa_dividasVencidas_Dataultimaocorrenciadividasvencidas = value;
				SetDirty("Dataultimaocorrenciadividasvencidas");
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
			gxTv_SdtSdSerasa_dividasVencidas_Dataultimaocorrenciadividasvencidas = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdSerasa_dividasVencidas_Quantidadetotaldividasvencidas;
		 

		protected decimal gxTv_SdtSdSerasa_dividasVencidas_Valortotaldividasvencidas;
		 

		protected string gxTv_SdtSdSerasa_dividasVencidas_Dataultimaocorrenciadividasvencidas;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.dividasVencidas", Namespace="Factory21")]
	public class SdtSdSerasa_dividasVencidas_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_dividasVencidas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_dividasVencidas_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_dividasVencidas_RESTInterface( SdtSdSerasa_dividasVencidas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("quantidadeTotalDividasVencidas")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="quantidadeTotalDividasVencidas", Order=0)]
		public  string gxTpr_Quantidadetotaldividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotaldividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotaldividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalDividasVencidas")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorTotalDividasVencidas", Order=1)]
		public  string gxTpr_Valortotaldividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotaldividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotaldividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataUltimaOcorrenciaDividasVencidas")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="dataUltimaOcorrenciaDividasVencidas", Order=2)]
		public  string gxTpr_Dataultimaocorrenciadividasvencidas
		{
			get { 
				return sdt.gxTpr_Dataultimaocorrenciadividasvencidas;

			}
			set { 
				 sdt.gxTpr_Dataultimaocorrenciadividasvencidas = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_dividasVencidas sdt
		{
			get { 
				return (SdtSdSerasa_dividasVencidas)Sdt;
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
				sdt = new SdtSdSerasa_dividasVencidas() ;
			}
		}
	}
	#endregion
}