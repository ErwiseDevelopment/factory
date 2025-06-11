/*
				   File: type_SdtSdSerasaPFProposta_informacoesAdicionais
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
	[XmlRoot(ElementName="SdSerasaPFProposta.informacoesAdicionais")]
	[XmlType(TypeName="SdSerasaPFProposta.informacoesAdicionais" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasaPFProposta_informacoesAdicionais : GxUserType
	{
		public SdtSdSerasaPFProposta_informacoesAdicionais( )
		{
			/* Constructor for serialization */
		}

		public SdtSdSerasaPFProposta_informacoesAdicionais(IGxContext context)
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


			AddObjectProperty("historicoPagamentoPF", gxTpr_Historicopagamentopf, false);


			AddObjectProperty("rendaEstimada", gxTpr_Rendaestimada, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="anotacoesCompletas")]
		[XmlElement(ElementName="anotacoesCompletas")]
		public bool gxTpr_Anotacoescompletas
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Anotacoescompletas; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Anotacoescompletas = value;
				SetDirty("Anotacoescompletas");
			}
		}




		[SoapElement(ElementName="consultasDetalhadasSerasa")]
		[XmlElement(ElementName="consultasDetalhadasSerasa")]
		public bool gxTpr_Consultasdetalhadasserasa
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Consultasdetalhadasserasa; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Consultasdetalhadasserasa = value;
				SetDirty("Consultasdetalhadasserasa");
			}
		}




		[SoapElement(ElementName="participacaoSocietaria")]
		[XmlElement(ElementName="participacaoSocietaria")]
		public bool gxTpr_Participacaosocietaria
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Participacaosocietaria; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Participacaosocietaria = value;
				SetDirty("Participacaosocietaria");
			}
		}




		[SoapElement(ElementName="historicoPagamentoPF")]
		[XmlElement(ElementName="historicoPagamentoPF")]
		public bool gxTpr_Historicopagamentopf
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Historicopagamentopf; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Historicopagamentopf = value;
				SetDirty("Historicopagamentopf");
			}
		}




		[SoapElement(ElementName="rendaEstimada")]
		[XmlElement(ElementName="rendaEstimada")]
		public bool gxTpr_Rendaestimada
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Rendaestimada; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Rendaestimada = value;
				SetDirty("Rendaestimada");
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

		protected bool gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Anotacoescompletas;
		 

		protected bool gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Consultasdetalhadasserasa;
		 

		protected bool gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Participacaosocietaria;
		 

		protected bool gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Historicopagamentopf;
		 

		protected bool gxTv_SdtSdSerasaPFProposta_informacoesAdicionais_Rendaestimada;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasaPFProposta.informacoesAdicionais", Namespace="Factory21")]
	public class SdtSdSerasaPFProposta_informacoesAdicionais_RESTInterface : GxGenericCollectionItem<SdtSdSerasaPFProposta_informacoesAdicionais>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasaPFProposta_informacoesAdicionais_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasaPFProposta_informacoesAdicionais_RESTInterface( SdtSdSerasaPFProposta_informacoesAdicionais psdt ) : base(psdt)
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

		[JsonPropertyName("historicoPagamentoPF")]
		[JsonPropertyOrder(3)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="historicoPagamentoPF", Order=3)]
		public bool gxTpr_Historicopagamentopf
		{
			get { 
				return sdt.gxTpr_Historicopagamentopf;

			}
			set { 
				sdt.gxTpr_Historicopagamentopf = value;
			}
		}

		[JsonPropertyName("rendaEstimada")]
		[JsonPropertyOrder(4)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="rendaEstimada", Order=4)]
		public bool gxTpr_Rendaestimada
		{
			get { 
				return sdt.gxTpr_Rendaestimada;

			}
			set { 
				sdt.gxTpr_Rendaestimada = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasaPFProposta_informacoesAdicionais sdt
		{
			get { 
				return (SdtSdSerasaPFProposta_informacoesAdicionais)Sdt;
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
				sdt = new SdtSdSerasaPFProposta_informacoesAdicionais() ;
			}
		}
	}
	#endregion
}