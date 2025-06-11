/*
				   File: type_SdtSdSerasa_criteriosAnalisados
			Description: criteriosAnalisados
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
	[XmlRoot(ElementName="SdSerasa.criteriosAnalisados")]
	[XmlType(TypeName="SdSerasa.criteriosAnalisados" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_criteriosAnalisados : GxUserType
	{
		public SdtSdSerasa_criteriosAnalisados( )
		{
			/* Constructor for serialization */
		}

		public SdtSdSerasa_criteriosAnalisados(IGxContext context)
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
			AddObjectProperty("cpfRegular", gxTpr_Cpfregular, false);


			AddObjectProperty("semRestritivoAtivo", gxTpr_Semrestritivoativo, false);


			AddObjectProperty("semProtestosAtivos", gxTpr_Semprotestosativos, false);


			AddObjectProperty("baixoComprometimentoDeRenda", gxTpr_Baixocomprometimentoderenda, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cpfRegular")]
		[XmlElement(ElementName="cpfRegular")]
		public bool gxTpr_Cpfregular
		{
			get {
				return gxTv_SdtSdSerasa_criteriosAnalisados_Cpfregular; 
			}
			set {
				gxTv_SdtSdSerasa_criteriosAnalisados_Cpfregular = value;
				SetDirty("Cpfregular");
			}
		}




		[SoapElement(ElementName="semRestritivoAtivo")]
		[XmlElement(ElementName="semRestritivoAtivo")]
		public bool gxTpr_Semrestritivoativo
		{
			get {
				return gxTv_SdtSdSerasa_criteriosAnalisados_Semrestritivoativo; 
			}
			set {
				gxTv_SdtSdSerasa_criteriosAnalisados_Semrestritivoativo = value;
				SetDirty("Semrestritivoativo");
			}
		}




		[SoapElement(ElementName="semProtestosAtivos")]
		[XmlElement(ElementName="semProtestosAtivos")]
		public bool gxTpr_Semprotestosativos
		{
			get {
				return gxTv_SdtSdSerasa_criteriosAnalisados_Semprotestosativos; 
			}
			set {
				gxTv_SdtSdSerasa_criteriosAnalisados_Semprotestosativos = value;
				SetDirty("Semprotestosativos");
			}
		}




		[SoapElement(ElementName="baixoComprometimentoDeRenda")]
		[XmlElement(ElementName="baixoComprometimentoDeRenda")]
		public bool gxTpr_Baixocomprometimentoderenda
		{
			get {
				return gxTv_SdtSdSerasa_criteriosAnalisados_Baixocomprometimentoderenda; 
			}
			set {
				gxTv_SdtSdSerasa_criteriosAnalisados_Baixocomprometimentoderenda = value;
				SetDirty("Baixocomprometimentoderenda");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdSerasa_criteriosAnalisados_Cpfregular;
		 

		protected bool gxTv_SdtSdSerasa_criteriosAnalisados_Semrestritivoativo;
		 

		protected bool gxTv_SdtSdSerasa_criteriosAnalisados_Semprotestosativos;
		 

		protected bool gxTv_SdtSdSerasa_criteriosAnalisados_Baixocomprometimentoderenda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.criteriosAnalisados", Namespace="Factory21")]
	public class SdtSdSerasa_criteriosAnalisados_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_criteriosAnalisados>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_criteriosAnalisados_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_criteriosAnalisados_RESTInterface( SdtSdSerasa_criteriosAnalisados psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("cpfRegular")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="cpfRegular", Order=0)]
		public bool gxTpr_Cpfregular
		{
			get { 
				return sdt.gxTpr_Cpfregular;

			}
			set { 
				sdt.gxTpr_Cpfregular = value;
			}
		}

		[JsonPropertyName("semRestritivoAtivo")]
		[JsonPropertyOrder(1)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="semRestritivoAtivo", Order=1)]
		public bool gxTpr_Semrestritivoativo
		{
			get { 
				return sdt.gxTpr_Semrestritivoativo;

			}
			set { 
				sdt.gxTpr_Semrestritivoativo = value;
			}
		}

		[JsonPropertyName("semProtestosAtivos")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="semProtestosAtivos", Order=2)]
		public bool gxTpr_Semprotestosativos
		{
			get { 
				return sdt.gxTpr_Semprotestosativos;

			}
			set { 
				sdt.gxTpr_Semprotestosativos = value;
			}
		}

		[JsonPropertyName("baixoComprometimentoDeRenda")]
		[JsonPropertyOrder(3)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="baixoComprometimentoDeRenda", Order=3)]
		public bool gxTpr_Baixocomprometimentoderenda
		{
			get { 
				return sdt.gxTpr_Baixocomprometimentoderenda;

			}
			set { 
				sdt.gxTpr_Baixocomprometimentoderenda = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_criteriosAnalisados sdt
		{
			get { 
				return (SdtSdSerasa_criteriosAnalisados)Sdt;
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
				sdt = new SdtSdSerasa_criteriosAnalisados() ;
			}
		}
	}
	#endregion
}