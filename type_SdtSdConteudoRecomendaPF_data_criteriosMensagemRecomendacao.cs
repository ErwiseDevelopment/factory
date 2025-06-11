/*
				   File: type_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao
			Description: criteriosMensagemRecomendacao
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.criteriosMensagemRecomendacao")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.criteriosMensagemRecomendacao" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao( )
		{
			/* Constructor for serialization */
		}

		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao(IGxContext context)
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
			AddObjectProperty("semProtestosAtivos", gxTpr_Semprotestosativos, false);


			AddObjectProperty("semAcoesJudiciais", gxTpr_Semacoesjudiciais, false);


			AddObjectProperty("baixoComprometimentoDeRenda", gxTpr_Baixocomprometimentoderenda, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="semProtestosAtivos")]
		[XmlElement(ElementName="semProtestosAtivos")]
		public bool gxTpr_Semprotestosativos
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semprotestosativos; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semprotestosativos = value;
				SetDirty("Semprotestosativos");
			}
		}




		[SoapElement(ElementName="semAcoesJudiciais")]
		[XmlElement(ElementName="semAcoesJudiciais")]
		public bool gxTpr_Semacoesjudiciais
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semacoesjudiciais; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semacoesjudiciais = value;
				SetDirty("Semacoesjudiciais");
			}
		}




		[SoapElement(ElementName="baixoComprometimentoDeRenda")]
		[XmlElement(ElementName="baixoComprometimentoDeRenda")]
		public bool gxTpr_Baixocomprometimentoderenda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Baixocomprometimentoderenda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Baixocomprometimentoderenda = value;
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

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semprotestosativos;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Semacoesjudiciais;
		 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_Baixocomprometimentoderenda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.criteriosMensagemRecomendacao", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_RESTInterface( SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("semProtestosAtivos")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="semProtestosAtivos", Order=0)]
		public bool gxTpr_Semprotestosativos
		{
			get { 
				return sdt.gxTpr_Semprotestosativos;

			}
			set { 
				sdt.gxTpr_Semprotestosativos = value;
			}
		}

		[JsonPropertyName("semAcoesJudiciais")]
		[JsonPropertyOrder(1)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="semAcoesJudiciais", Order=1)]
		public bool gxTpr_Semacoesjudiciais
		{
			get { 
				return sdt.gxTpr_Semacoesjudiciais;

			}
			set { 
				sdt.gxTpr_Semacoesjudiciais = value;
			}
		}

		[JsonPropertyName("baixoComprometimentoDeRenda")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="baixoComprometimentoDeRenda", Order=2)]
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
		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao() ;
			}
		}
	}
	#endregion
}