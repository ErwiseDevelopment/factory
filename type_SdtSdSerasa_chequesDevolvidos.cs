/*
				   File: type_SdtSdSerasa_chequesDevolvidos
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
	[XmlRoot(ElementName="SdSerasa.chequesDevolvidos")]
	[XmlType(TypeName="SdSerasa.chequesDevolvidos" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_chequesDevolvidos : GxUserType
	{
		public SdtSdSerasa_chequesDevolvidos( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasa_chequesDevolvidos_Dataultimaocorrenciachequesustado = "";


		}

		public SdtSdSerasa_chequesDevolvidos(IGxContext context)
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
			AddObjectProperty("quantidadeChequeSemFundos", gxTpr_Quantidadechequesemfundos, false);


			AddObjectProperty("valorTotalChequeSemFundos", gxTpr_Valortotalchequesemfundos, false);


			AddObjectProperty("dataUltimaOcorrenciaChequeSustado", gxTpr_Dataultimaocorrenciachequesustado, false);


			AddObjectProperty("quantidadeTotalChequeSustado", gxTpr_Quantidadetotalchequesustado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="quantidadeChequeSemFundos")]
		[XmlElement(ElementName="quantidadeChequeSemFundos")]
		public string gxTpr_Quantidadechequesemfundos_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadechequesemfundos, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadechequesemfundos = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadechequesemfundos
		{
			get {
				return gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadechequesemfundos; 
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadechequesemfundos = value;
				SetDirty("Quantidadechequesemfundos");
			}
		}



		[SoapElement(ElementName="valorTotalChequeSemFundos")]
		[XmlElement(ElementName="valorTotalChequeSemFundos")]
		public string gxTpr_Valortotalchequesemfundos_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_chequesDevolvidos_Valortotalchequesemfundos, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Valortotalchequesemfundos = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalchequesemfundos
		{
			get {
				return gxTv_SdtSdSerasa_chequesDevolvidos_Valortotalchequesemfundos; 
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Valortotalchequesemfundos = value;
				SetDirty("Valortotalchequesemfundos");
			}
		}




		[SoapElement(ElementName="dataUltimaOcorrenciaChequeSustado")]
		[XmlElement(ElementName="dataUltimaOcorrenciaChequeSustado")]
		public string gxTpr_Dataultimaocorrenciachequesustado
		{
			get {
				return gxTv_SdtSdSerasa_chequesDevolvidos_Dataultimaocorrenciachequesustado; 
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Dataultimaocorrenciachequesustado = value;
				SetDirty("Dataultimaocorrenciachequesustado");
			}
		}



		[SoapElement(ElementName="quantidadeTotalChequeSustado")]
		[XmlElement(ElementName="quantidadeTotalChequeSustado")]
		public string gxTpr_Quantidadetotalchequesustado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadetotalchequesustado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadetotalchequesustado = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalchequesustado
		{
			get {
				return gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadetotalchequesustado; 
			}
			set {
				gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadetotalchequesustado = value;
				SetDirty("Quantidadetotalchequesustado");
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
			gxTv_SdtSdSerasa_chequesDevolvidos_Dataultimaocorrenciachequesustado = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadechequesemfundos;
		 

		protected decimal gxTv_SdtSdSerasa_chequesDevolvidos_Valortotalchequesemfundos;
		 

		protected string gxTv_SdtSdSerasa_chequesDevolvidos_Dataultimaocorrenciachequesustado;
		 

		protected decimal gxTv_SdtSdSerasa_chequesDevolvidos_Quantidadetotalchequesustado;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.chequesDevolvidos", Namespace="Factory21")]
	public class SdtSdSerasa_chequesDevolvidos_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_chequesDevolvidos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_chequesDevolvidos_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_chequesDevolvidos_RESTInterface( SdtSdSerasa_chequesDevolvidos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("quantidadeChequeSemFundos")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="quantidadeChequeSemFundos", Order=0)]
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
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorTotalChequeSemFundos", Order=1)]
		public  string gxTpr_Valortotalchequesemfundos
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalchequesemfundos, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalchequesemfundos =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataUltimaOcorrenciaChequeSustado")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="dataUltimaOcorrenciaChequeSustado", Order=2)]
		public  string gxTpr_Dataultimaocorrenciachequesustado
		{
			get { 
				return sdt.gxTpr_Dataultimaocorrenciachequesustado;

			}
			set { 
				 sdt.gxTpr_Dataultimaocorrenciachequesustado = value;
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


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_chequesDevolvidos sdt
		{
			get { 
				return (SdtSdSerasa_chequesDevolvidos)Sdt;
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
				sdt = new SdtSdSerasa_chequesDevolvidos() ;
			}
		}
	}
	#endregion
}