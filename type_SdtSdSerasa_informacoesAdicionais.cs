/*
				   File: type_SdtSdSerasa_informacoesAdicionais
			Description: informacoesAdicionais
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
	[XmlRoot(ElementName="SdSerasa.informacoesAdicionais")]
	[XmlType(TypeName="SdSerasa.informacoesAdicionais" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_informacoesAdicionais : GxUserType
	{
		public SdtSdSerasa_informacoesAdicionais( )
		{
			/* Constructor for serialization */
		}

		public SdtSdSerasa_informacoesAdicionais(IGxContext context)
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
			AddObjectProperty("anotacoesCompletas", gxTpr_Anotacoescompletas, false);


			AddObjectProperty("consultasDetalhadasSerasa", gxTpr_Consultasdetalhadasserasa, false);


			AddObjectProperty("participacaoSocietaria", gxTpr_Participacaosocietaria, false);


			AddObjectProperty("rendaEstimado", gxTpr_Rendaestimado, false);


			AddObjectProperty("historicoPagamentoPF", gxTpr_Historicopagamentopf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="anotacoesCompletas")]
		[XmlElement(ElementName="anotacoesCompletas")]
		public bool gxTpr_Anotacoescompletas
		{
			get {
				return gxTv_SdtSdSerasa_informacoesAdicionais_Anotacoescompletas; 
			}
			set {
				gxTv_SdtSdSerasa_informacoesAdicionais_Anotacoescompletas = value;
				SetDirty("Anotacoescompletas");
			}
		}




		[SoapElement(ElementName="consultasDetalhadasSerasa")]
		[XmlElement(ElementName="consultasDetalhadasSerasa")]
		public bool gxTpr_Consultasdetalhadasserasa
		{
			get {
				return gxTv_SdtSdSerasa_informacoesAdicionais_Consultasdetalhadasserasa; 
			}
			set {
				gxTv_SdtSdSerasa_informacoesAdicionais_Consultasdetalhadasserasa = value;
				SetDirty("Consultasdetalhadasserasa");
			}
		}




		[SoapElement(ElementName="participacaoSocietaria")]
		[XmlElement(ElementName="participacaoSocietaria")]
		public bool gxTpr_Participacaosocietaria
		{
			get {
				return gxTv_SdtSdSerasa_informacoesAdicionais_Participacaosocietaria; 
			}
			set {
				gxTv_SdtSdSerasa_informacoesAdicionais_Participacaosocietaria = value;
				SetDirty("Participacaosocietaria");
			}
		}




		[SoapElement(ElementName="rendaEstimado")]
		[XmlElement(ElementName="rendaEstimado")]
		public bool gxTpr_Rendaestimado
		{
			get {
				return gxTv_SdtSdSerasa_informacoesAdicionais_Rendaestimado; 
			}
			set {
				gxTv_SdtSdSerasa_informacoesAdicionais_Rendaestimado = value;
				SetDirty("Rendaestimado");
			}
		}




		[SoapElement(ElementName="historicoPagamentoPF")]
		[XmlElement(ElementName="historicoPagamentoPF")]
		public bool gxTpr_Historicopagamentopf
		{
			get {
				return gxTv_SdtSdSerasa_informacoesAdicionais_Historicopagamentopf; 
			}
			set {
				gxTv_SdtSdSerasa_informacoesAdicionais_Historicopagamentopf = value;
				SetDirty("Historicopagamentopf");
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

		protected bool gxTv_SdtSdSerasa_informacoesAdicionais_Anotacoescompletas;
		 

		protected bool gxTv_SdtSdSerasa_informacoesAdicionais_Consultasdetalhadasserasa;
		 

		protected bool gxTv_SdtSdSerasa_informacoesAdicionais_Participacaosocietaria;
		 

		protected bool gxTv_SdtSdSerasa_informacoesAdicionais_Rendaestimado;
		 

		protected bool gxTv_SdtSdSerasa_informacoesAdicionais_Historicopagamentopf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.informacoesAdicionais", Namespace="Factory21")]
	public class SdtSdSerasa_informacoesAdicionais_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_informacoesAdicionais>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_informacoesAdicionais_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_informacoesAdicionais_RESTInterface( SdtSdSerasa_informacoesAdicionais psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("anotacoesCompletas")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="anotacoesCompletas", Order=0)]
		public bool gxTpr_Anotacoescompletas
		{
			get { 
				return sdt.gxTpr_Anotacoescompletas;

			}
			set { 
				sdt.gxTpr_Anotacoescompletas = value;
			}
		}

		[JsonPropertyName("consultasDetalhadasSerasa")]
		[JsonPropertyOrder(1)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="consultasDetalhadasSerasa", Order=1)]
		public bool gxTpr_Consultasdetalhadasserasa
		{
			get { 
				return sdt.gxTpr_Consultasdetalhadasserasa;

			}
			set { 
				sdt.gxTpr_Consultasdetalhadasserasa = value;
			}
		}

		[JsonPropertyName("participacaoSocietaria")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="participacaoSocietaria", Order=2)]
		public bool gxTpr_Participacaosocietaria
		{
			get { 
				return sdt.gxTpr_Participacaosocietaria;

			}
			set { 
				sdt.gxTpr_Participacaosocietaria = value;
			}
		}

		[JsonPropertyName("rendaEstimado")]
		[JsonPropertyOrder(3)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="rendaEstimado", Order=3)]
		public bool gxTpr_Rendaestimado
		{
			get { 
				return sdt.gxTpr_Rendaestimado;

			}
			set { 
				sdt.gxTpr_Rendaestimado = value;
			}
		}

		[JsonPropertyName("historicoPagamentoPF")]
		[JsonPropertyOrder(4)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="historicoPagamentoPF", Order=4)]
		public bool gxTpr_Historicopagamentopf
		{
			get { 
				return sdt.gxTpr_Historicopagamentopf;

			}
			set { 
				sdt.gxTpr_Historicopagamentopf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_informacoesAdicionais sdt
		{
			get { 
				return (SdtSdSerasa_informacoesAdicionais)Sdt;
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
				sdt = new SdtSdSerasa_informacoesAdicionais() ;
			}
		}
	}
	#endregion
}