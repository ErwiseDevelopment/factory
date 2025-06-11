/*
				   File: type_SdtSdConteudoRecomendaPF_data_informacoesAdicionais
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.informacoesAdicionais")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.informacoesAdicionais" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_informacoesAdicionais : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais( )
		{
			/* Constructor for serialization */
		}

		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais(IGxContext context)
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


			AddObjectProperty("anotacoesConsultasSPC", gxTpr_Anotacoesconsultasspc, false);


			AddObjectProperty("participacaoSocietaria", gxTpr_Participacaosocietaria, false);


			AddObjectProperty("rendaEstimada", gxTpr_Rendaestimada, false);


			AddObjectProperty("historicoPagamentoPF", gxTpr_Historicopagamentopf, false);


			AddObjectProperty("recomendaCompleto", gxTpr_Recomendacompleto, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="anotacoesCompletas")]
		[XmlElement(ElementName="anotacoesCompletas")]
		public bool gxTpr_Anotacoescompletas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoescompletas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoescompletas = value;
				SetDirty("Anotacoescompletas");
			}
		}




		[SoapElement(ElementName="consultasDetalhadasSerasa")]
		[XmlElement(ElementName="consultasDetalhadasSerasa")]
		public bool gxTpr_Consultasdetalhadasserasa
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Consultasdetalhadasserasa; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Consultasdetalhadasserasa = value;
				SetDirty("Consultasdetalhadasserasa");
			}
		}




		[SoapElement(ElementName="anotacoesConsultasSPC")]
		[XmlElement(ElementName="anotacoesConsultasSPC")]
		public bool gxTpr_Anotacoesconsultasspc
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoesconsultasspc; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoesconsultasspc = value;
				SetDirty("Anotacoesconsultasspc");
			}
		}




		[SoapElement(ElementName="participacaoSocietaria")]
		[XmlElement(ElementName="participacaoSocietaria")]
		public bool gxTpr_Participacaosocietaria
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Participacaosocietaria; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Participacaosocietaria = value;
				SetDirty("Participacaosocietaria");
			}
		}




		[SoapElement(ElementName="rendaEstimada")]
		[XmlElement(ElementName="rendaEstimada")]
		public bool gxTpr_Rendaestimada
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Rendaestimada; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Rendaestimada = value;
				SetDirty("Rendaestimada");
			}
		}




		[SoapElement(ElementName="historicoPagamentoPF")]
		[XmlElement(ElementName="historicoPagamentoPF")]
		public bool gxTpr_Historicopagamentopf
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Historicopagamentopf; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Historicopagamentopf = value;
				SetDirty("Historicopagamentopf");
			}
		}




		[SoapElement(ElementName="recomendaCompleto")]
		[XmlElement(ElementName="recomendaCompleto")]
		public bool gxTpr_Recomendacompleto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Recomendacompleto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Recomendacompleto = value;
				SetDirty("Recomendacompleto");
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

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoescompletas;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Consultasdetalhadasserasa;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Anotacoesconsultasspc;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Participacaosocietaria;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Rendaestimada;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Historicopagamentopf;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_informacoesAdicionais_Recomendacompleto;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.informacoesAdicionais", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_informacoesAdicionais_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_informacoesAdicionais>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais_RESTInterface( SdtSdConteudoRecomendaPF_data_informacoesAdicionais psdt ) : base(psdt)
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

		[JsonPropertyName("anotacoesConsultasSPC")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="anotacoesConsultasSPC", Order=2)]
		public bool gxTpr_Anotacoesconsultasspc
		{
			get { 
				return sdt.gxTpr_Anotacoesconsultasspc;

			}
			set { 
				sdt.gxTpr_Anotacoesconsultasspc = value;
			}
		}

		[JsonPropertyName("participacaoSocietaria")]
		[JsonPropertyOrder(3)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="participacaoSocietaria", Order=3)]
		public bool gxTpr_Participacaosocietaria
		{
			get { 
				return sdt.gxTpr_Participacaosocietaria;

			}
			set { 
				sdt.gxTpr_Participacaosocietaria = value;
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

		[JsonPropertyName("historicoPagamentoPF")]
		[JsonPropertyOrder(5)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="historicoPagamentoPF", Order=5)]
		public bool gxTpr_Historicopagamentopf
		{
			get { 
				return sdt.gxTpr_Historicopagamentopf;

			}
			set { 
				sdt.gxTpr_Historicopagamentopf = value;
			}
		}

		[JsonPropertyName("recomendaCompleto")]
		[JsonPropertyOrder(6)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="recomendaCompleto", Order=6)]
		public bool gxTpr_Recomendacompleto
		{
			get { 
				return sdt.gxTpr_Recomendacompleto;

			}
			set { 
				sdt.gxTpr_Recomendacompleto = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_informacoesAdicionais)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_informacoesAdicionais() ;
			}
		}
	}
	#endregion
}