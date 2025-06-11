/*
				   File: type_SdtWcImpNotaFiscalData
			Description: WcImpNotaFiscalData
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
	[XmlRoot(ElementName="WcImpNotaFiscalData")]
	[XmlType(TypeName="WcImpNotaFiscalData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWcImpNotaFiscalData : GxUserType
	{
		public SdtWcImpNotaFiscalData( )
		{
			/* Constructor for serialization */
		}

		public SdtWcImpNotaFiscalData(IGxContext context)
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
			if (gxTv_SdtWcImpNotaFiscalData_Importarxml != null)
			{
				AddObjectProperty("ImportarXML", gxTv_SdtWcImpNotaFiscalData_Importarxml, false);
			}
			if (gxTv_SdtWcImpNotaFiscalData_Produtosnota != null)
			{
				AddObjectProperty("ProdutosNota", gxTv_SdtWcImpNotaFiscalData_Produtosnota, false);
			}
			if (gxTv_SdtWcImpNotaFiscalData_Revisao != null)
			{
				AddObjectProperty("Revisao", gxTv_SdtWcImpNotaFiscalData_Revisao, false);
			}
			if (gxTv_SdtWcImpNotaFiscalData_Confirmacao != null)
			{
				AddObjectProperty("Confirmacao", gxTv_SdtWcImpNotaFiscalData_Confirmacao, false);
			}
			if (gxTv_SdtWcImpNotaFiscalData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWcImpNotaFiscalData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ImportarXML" )]
		[XmlElement(ElementName="ImportarXML" )]
		public SdtWcImpNotaFiscalData_ImportarXML gxTpr_Importarxml
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Importarxml == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Importarxml = new SdtWcImpNotaFiscalData_ImportarXML(context);
				}
				gxTv_SdtWcImpNotaFiscalData_Importarxml_N = false;
				SetDirty("Importarxml");
				return gxTv_SdtWcImpNotaFiscalData_Importarxml;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Importarxml_N = false;
				gxTv_SdtWcImpNotaFiscalData_Importarxml = value;
				SetDirty("Importarxml");
			}

		}

		public void gxTv_SdtWcImpNotaFiscalData_Importarxml_SetNull()
		{
			gxTv_SdtWcImpNotaFiscalData_Importarxml_N = true;
			gxTv_SdtWcImpNotaFiscalData_Importarxml = null;
		}

		public bool gxTv_SdtWcImpNotaFiscalData_Importarxml_IsNull()
		{
			return gxTv_SdtWcImpNotaFiscalData_Importarxml == null;
		}
		public bool ShouldSerializegxTpr_Importarxml_Json()
		{
				return (gxTv_SdtWcImpNotaFiscalData_Importarxml != null && gxTv_SdtWcImpNotaFiscalData_Importarxml.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="ProdutosNota" )]
		[XmlElement(ElementName="ProdutosNota" )]
		public SdtWcImpNotaFiscalData_ProdutosNota gxTpr_Produtosnota
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Produtosnota == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Produtosnota = new SdtWcImpNotaFiscalData_ProdutosNota(context);
				}
				gxTv_SdtWcImpNotaFiscalData_Produtosnota_N = false;
				SetDirty("Produtosnota");
				return gxTv_SdtWcImpNotaFiscalData_Produtosnota;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Produtosnota_N = false;
				gxTv_SdtWcImpNotaFiscalData_Produtosnota = value;
				SetDirty("Produtosnota");
			}

		}

		public void gxTv_SdtWcImpNotaFiscalData_Produtosnota_SetNull()
		{
			gxTv_SdtWcImpNotaFiscalData_Produtosnota_N = true;
			gxTv_SdtWcImpNotaFiscalData_Produtosnota = null;
		}

		public bool gxTv_SdtWcImpNotaFiscalData_Produtosnota_IsNull()
		{
			return gxTv_SdtWcImpNotaFiscalData_Produtosnota == null;
		}
		public bool ShouldSerializegxTpr_Produtosnota_Json()
		{
				return (gxTv_SdtWcImpNotaFiscalData_Produtosnota != null && gxTv_SdtWcImpNotaFiscalData_Produtosnota.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Revisao" )]
		[XmlElement(ElementName="Revisao" )]
		public SdtWcImpNotaFiscalData_Revisao gxTpr_Revisao
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Revisao == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Revisao = new SdtWcImpNotaFiscalData_Revisao(context);
				}
				gxTv_SdtWcImpNotaFiscalData_Revisao_N = false;
				SetDirty("Revisao");
				return gxTv_SdtWcImpNotaFiscalData_Revisao;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Revisao_N = false;
				gxTv_SdtWcImpNotaFiscalData_Revisao = value;
				SetDirty("Revisao");
			}

		}

		public void gxTv_SdtWcImpNotaFiscalData_Revisao_SetNull()
		{
			gxTv_SdtWcImpNotaFiscalData_Revisao_N = true;
			gxTv_SdtWcImpNotaFiscalData_Revisao = null;
		}

		public bool gxTv_SdtWcImpNotaFiscalData_Revisao_IsNull()
		{
			return gxTv_SdtWcImpNotaFiscalData_Revisao == null;
		}
		public bool ShouldSerializegxTpr_Revisao_Json()
		{
				return (gxTv_SdtWcImpNotaFiscalData_Revisao != null && gxTv_SdtWcImpNotaFiscalData_Revisao.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Confirmacao" )]
		[XmlElement(ElementName="Confirmacao" )]
		public SdtWcImpNotaFiscalData_Confirmacao gxTpr_Confirmacao
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Confirmacao == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Confirmacao = new SdtWcImpNotaFiscalData_Confirmacao(context);
				}
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_N = false;
				SetDirty("Confirmacao");
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_N = false;
				gxTv_SdtWcImpNotaFiscalData_Confirmacao = value;
				SetDirty("Confirmacao");
			}

		}

		public void gxTv_SdtWcImpNotaFiscalData_Confirmacao_SetNull()
		{
			gxTv_SdtWcImpNotaFiscalData_Confirmacao_N = true;
			gxTv_SdtWcImpNotaFiscalData_Confirmacao = null;
		}

		public bool gxTv_SdtWcImpNotaFiscalData_Confirmacao_IsNull()
		{
			return gxTv_SdtWcImpNotaFiscalData_Confirmacao == null;
		}
		public bool ShouldSerializegxTpr_Confirmacao_Json()
		{
				return (gxTv_SdtWcImpNotaFiscalData_Confirmacao != null && gxTv_SdtWcImpNotaFiscalData_Confirmacao.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Auxiliardata == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWcImpNotaFiscalData_Auxiliardata;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N = false;
				gxTv_SdtWcImpNotaFiscalData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Auxiliardata == null )
				{
					gxTv_SdtWcImpNotaFiscalData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtWcImpNotaFiscalData_Auxiliardata ;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N = false;
				gxTv_SdtWcImpNotaFiscalData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWcImpNotaFiscalData_Auxiliardata_SetNull()
		{
			gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N = true;
			gxTv_SdtWcImpNotaFiscalData_Auxiliardata = null;
		}

		public bool gxTv_SdtWcImpNotaFiscalData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWcImpNotaFiscalData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWcImpNotaFiscalData_Auxiliardata != null && gxTv_SdtWcImpNotaFiscalData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Importarxml_Json() ||
				ShouldSerializegxTpr_Produtosnota_Json() ||
				ShouldSerializegxTpr_Revisao_Json() ||
				ShouldSerializegxTpr_Confirmacao_Json() ||
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
				false);
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
			gxTv_SdtWcImpNotaFiscalData_Importarxml_N = true;


			gxTv_SdtWcImpNotaFiscalData_Produtosnota_N = true;


			gxTv_SdtWcImpNotaFiscalData_Revisao_N = true;


			gxTv_SdtWcImpNotaFiscalData_Confirmacao_N = true;


			gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWcImpNotaFiscalData_Importarxml_N;
		protected SdtWcImpNotaFiscalData_ImportarXML gxTv_SdtWcImpNotaFiscalData_Importarxml = null; 

		protected bool gxTv_SdtWcImpNotaFiscalData_Produtosnota_N;
		protected SdtWcImpNotaFiscalData_ProdutosNota gxTv_SdtWcImpNotaFiscalData_Produtosnota = null; 

		protected bool gxTv_SdtWcImpNotaFiscalData_Revisao_N;
		protected SdtWcImpNotaFiscalData_Revisao gxTv_SdtWcImpNotaFiscalData_Revisao = null; 

		protected bool gxTv_SdtWcImpNotaFiscalData_Confirmacao_N;
		protected SdtWcImpNotaFiscalData_Confirmacao gxTv_SdtWcImpNotaFiscalData_Confirmacao = null; 

		protected bool gxTv_SdtWcImpNotaFiscalData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWcImpNotaFiscalData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WcImpNotaFiscalData", Namespace="Factory21")]
	public class SdtWcImpNotaFiscalData_RESTInterface : GxGenericCollectionItem<SdtWcImpNotaFiscalData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWcImpNotaFiscalData_RESTInterface( ) : base()
		{	
		}

		public SdtWcImpNotaFiscalData_RESTInterface( SdtWcImpNotaFiscalData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ImportarXML")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ImportarXML", Order=0, EmitDefaultValue=false)]
		public SdtWcImpNotaFiscalData_ImportarXML_RESTInterface gxTpr_Importarxml
		{
			get {
				if (sdt.ShouldSerializegxTpr_Importarxml_Json())
					return new SdtWcImpNotaFiscalData_ImportarXML_RESTInterface(sdt.gxTpr_Importarxml);
				else
					return null;

			}

			set {
				sdt.gxTpr_Importarxml = value.sdt;
			}

		}

		[JsonPropertyName("ProdutosNota")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ProdutosNota", Order=1, EmitDefaultValue=false)]
		public SdtWcImpNotaFiscalData_ProdutosNota_RESTInterface gxTpr_Produtosnota
		{
			get {
				if (sdt.ShouldSerializegxTpr_Produtosnota_Json())
					return new SdtWcImpNotaFiscalData_ProdutosNota_RESTInterface(sdt.gxTpr_Produtosnota);
				else
					return null;

			}

			set {
				sdt.gxTpr_Produtosnota = value.sdt;
			}

		}

		[JsonPropertyName("Revisao")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Revisao", Order=2, EmitDefaultValue=false)]
		public SdtWcImpNotaFiscalData_Revisao_RESTInterface gxTpr_Revisao
		{
			get {
				if (sdt.ShouldSerializegxTpr_Revisao_Json())
					return new SdtWcImpNotaFiscalData_Revisao_RESTInterface(sdt.gxTpr_Revisao);
				else
					return null;

			}

			set {
				sdt.gxTpr_Revisao = value.sdt;
			}

		}

		[JsonPropertyName("Confirmacao")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Confirmacao", Order=3, EmitDefaultValue=false)]
		public SdtWcImpNotaFiscalData_Confirmacao_RESTInterface gxTpr_Confirmacao
		{
			get {
				if (sdt.ShouldSerializegxTpr_Confirmacao_Json())
					return new SdtWcImpNotaFiscalData_Confirmacao_RESTInterface(sdt.gxTpr_Confirmacao);
				else
					return null;

			}

			set {
				sdt.gxTpr_Confirmacao = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=4, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWcImpNotaFiscalData sdt
		{
			get { 
				return (SdtWcImpNotaFiscalData)Sdt;
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
				sdt = new SdtWcImpNotaFiscalData() ;
			}
		}
	}
	#endregion
}