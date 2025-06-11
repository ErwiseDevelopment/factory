/*
				   File: type_SdtWpNovaPropostaData
			Description: WpNovaPropostaData
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
	[XmlRoot(ElementName="WpNovaPropostaData")]
	[XmlType(TypeName="WpNovaPropostaData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWpNovaPropostaData : GxUserType
	{
		public SdtWpNovaPropostaData( )
		{
			/* Constructor for serialization */
		}

		public SdtWpNovaPropostaData(IGxContext context)
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
			if (gxTv_SdtWpNovaPropostaData_Novocliente != null)
			{
				AddObjectProperty("NovoCliente", gxTv_SdtWpNovaPropostaData_Novocliente, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Responsavel != null)
			{
				AddObjectProperty("Responsavel", gxTv_SdtWpNovaPropostaData_Responsavel, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Conta != null)
			{
				AddObjectProperty("Conta", gxTv_SdtWpNovaPropostaData_Conta, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Proposta != null)
			{
				AddObjectProperty("Proposta", gxTv_SdtWpNovaPropostaData_Proposta, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Documentos != null)
			{
				AddObjectProperty("Documentos", gxTv_SdtWpNovaPropostaData_Documentos, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Resumo != null)
			{
				AddObjectProperty("Resumo", gxTv_SdtWpNovaPropostaData_Resumo, false);
			}
			if (gxTv_SdtWpNovaPropostaData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWpNovaPropostaData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NovoCliente" )]
		[XmlElement(ElementName="NovoCliente" )]
		public SdtWpNovaPropostaData_NovoCliente gxTpr_Novocliente
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Novocliente == null )
				{
					gxTv_SdtWpNovaPropostaData_Novocliente = new SdtWpNovaPropostaData_NovoCliente(context);
				}
				gxTv_SdtWpNovaPropostaData_Novocliente_N = false;
				SetDirty("Novocliente");
				return gxTv_SdtWpNovaPropostaData_Novocliente;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Novocliente_N = false;
				gxTv_SdtWpNovaPropostaData_Novocliente = value;
				SetDirty("Novocliente");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Novocliente_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Novocliente_N = true;
			gxTv_SdtWpNovaPropostaData_Novocliente = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Novocliente_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Novocliente == null;
		}
		public bool ShouldSerializegxTpr_Novocliente_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Novocliente != null && gxTv_SdtWpNovaPropostaData_Novocliente.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Responsavel" )]
		[XmlElement(ElementName="Responsavel" )]
		public SdtWpNovaPropostaData_Responsavel gxTpr_Responsavel
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Responsavel == null )
				{
					gxTv_SdtWpNovaPropostaData_Responsavel = new SdtWpNovaPropostaData_Responsavel(context);
				}
				gxTv_SdtWpNovaPropostaData_Responsavel_N = false;
				SetDirty("Responsavel");
				return gxTv_SdtWpNovaPropostaData_Responsavel;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Responsavel_N = false;
				gxTv_SdtWpNovaPropostaData_Responsavel = value;
				SetDirty("Responsavel");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Responsavel_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Responsavel_N = true;
			gxTv_SdtWpNovaPropostaData_Responsavel = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Responsavel_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Responsavel == null;
		}
		public bool ShouldSerializegxTpr_Responsavel_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Responsavel != null && gxTv_SdtWpNovaPropostaData_Responsavel.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Conta" )]
		[XmlElement(ElementName="Conta" )]
		public SdtWpNovaPropostaData_Conta gxTpr_Conta
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Conta == null )
				{
					gxTv_SdtWpNovaPropostaData_Conta = new SdtWpNovaPropostaData_Conta(context);
				}
				gxTv_SdtWpNovaPropostaData_Conta_N = false;
				SetDirty("Conta");
				return gxTv_SdtWpNovaPropostaData_Conta;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Conta_N = false;
				gxTv_SdtWpNovaPropostaData_Conta = value;
				SetDirty("Conta");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Conta_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Conta_N = true;
			gxTv_SdtWpNovaPropostaData_Conta = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Conta_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Conta == null;
		}
		public bool ShouldSerializegxTpr_Conta_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Conta != null && gxTv_SdtWpNovaPropostaData_Conta.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Proposta" )]
		[XmlElement(ElementName="Proposta" )]
		public SdtWpNovaPropostaData_Proposta gxTpr_Proposta
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Proposta == null )
				{
					gxTv_SdtWpNovaPropostaData_Proposta = new SdtWpNovaPropostaData_Proposta(context);
				}
				gxTv_SdtWpNovaPropostaData_Proposta_N = false;
				SetDirty("Proposta");
				return gxTv_SdtWpNovaPropostaData_Proposta;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Proposta_N = false;
				gxTv_SdtWpNovaPropostaData_Proposta = value;
				SetDirty("Proposta");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Proposta_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Proposta_N = true;
			gxTv_SdtWpNovaPropostaData_Proposta = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Proposta_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Proposta == null;
		}
		public bool ShouldSerializegxTpr_Proposta_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Proposta != null && gxTv_SdtWpNovaPropostaData_Proposta.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Documentos" )]
		[XmlElement(ElementName="Documentos" )]
		public SdtWpNovaPropostaData_Documentos gxTpr_Documentos
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Documentos == null )
				{
					gxTv_SdtWpNovaPropostaData_Documentos = new SdtWpNovaPropostaData_Documentos(context);
				}
				gxTv_SdtWpNovaPropostaData_Documentos_N = false;
				SetDirty("Documentos");
				return gxTv_SdtWpNovaPropostaData_Documentos;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Documentos_N = false;
				gxTv_SdtWpNovaPropostaData_Documentos = value;
				SetDirty("Documentos");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Documentos_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Documentos_N = true;
			gxTv_SdtWpNovaPropostaData_Documentos = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Documentos_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Documentos == null;
		}
		public bool ShouldSerializegxTpr_Documentos_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Documentos != null && gxTv_SdtWpNovaPropostaData_Documentos.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Resumo" )]
		[XmlElement(ElementName="Resumo" )]
		public SdtWpNovaPropostaData_Resumo gxTpr_Resumo
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Resumo == null )
				{
					gxTv_SdtWpNovaPropostaData_Resumo = new SdtWpNovaPropostaData_Resumo(context);
				}
				gxTv_SdtWpNovaPropostaData_Resumo_N = false;
				SetDirty("Resumo");
				return gxTv_SdtWpNovaPropostaData_Resumo;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Resumo_N = false;
				gxTv_SdtWpNovaPropostaData_Resumo = value;
				SetDirty("Resumo");
			}

		}

		public void gxTv_SdtWpNovaPropostaData_Resumo_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Resumo_N = true;
			gxTv_SdtWpNovaPropostaData_Resumo = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Resumo_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Resumo == null;
		}
		public bool ShouldSerializegxTpr_Resumo_Json()
		{
				return (gxTv_SdtWpNovaPropostaData_Resumo != null && gxTv_SdtWpNovaPropostaData_Resumo.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Auxiliardata == null )
				{
					gxTv_SdtWpNovaPropostaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWpNovaPropostaData_Auxiliardata;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Auxiliardata_N = false;
				gxTv_SdtWpNovaPropostaData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Auxiliardata == null )
				{
					gxTv_SdtWpNovaPropostaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWpNovaPropostaData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtWpNovaPropostaData_Auxiliardata ;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Auxiliardata_N = false;
				gxTv_SdtWpNovaPropostaData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWpNovaPropostaData_Auxiliardata_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Auxiliardata_N = true;
			gxTv_SdtWpNovaPropostaData_Auxiliardata = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWpNovaPropostaData_Auxiliardata != null && gxTv_SdtWpNovaPropostaData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Novocliente_Json() ||
				ShouldSerializegxTpr_Responsavel_Json() ||
				ShouldSerializegxTpr_Conta_Json() ||
				ShouldSerializegxTpr_Proposta_Json() ||
				ShouldSerializegxTpr_Documentos_Json() ||
				ShouldSerializegxTpr_Resumo_Json() ||
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
			gxTv_SdtWpNovaPropostaData_Novocliente_N = true;


			gxTv_SdtWpNovaPropostaData_Responsavel_N = true;


			gxTv_SdtWpNovaPropostaData_Conta_N = true;


			gxTv_SdtWpNovaPropostaData_Proposta_N = true;


			gxTv_SdtWpNovaPropostaData_Documentos_N = true;


			gxTv_SdtWpNovaPropostaData_Resumo_N = true;


			gxTv_SdtWpNovaPropostaData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWpNovaPropostaData_Novocliente_N;
		protected SdtWpNovaPropostaData_NovoCliente gxTv_SdtWpNovaPropostaData_Novocliente = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Responsavel_N;
		protected SdtWpNovaPropostaData_Responsavel gxTv_SdtWpNovaPropostaData_Responsavel = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Conta_N;
		protected SdtWpNovaPropostaData_Conta gxTv_SdtWpNovaPropostaData_Conta = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Proposta_N;
		protected SdtWpNovaPropostaData_Proposta gxTv_SdtWpNovaPropostaData_Proposta = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Documentos_N;
		protected SdtWpNovaPropostaData_Documentos gxTv_SdtWpNovaPropostaData_Documentos = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Resumo_N;
		protected SdtWpNovaPropostaData_Resumo gxTv_SdtWpNovaPropostaData_Resumo = null; 

		protected bool gxTv_SdtWpNovaPropostaData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWpNovaPropostaData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WpNovaPropostaData", Namespace="Factory21")]
	public class SdtWpNovaPropostaData_RESTInterface : GxGenericCollectionItem<SdtWpNovaPropostaData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWpNovaPropostaData_RESTInterface( ) : base()
		{	
		}

		public SdtWpNovaPropostaData_RESTInterface( SdtWpNovaPropostaData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("NovoCliente")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="NovoCliente", Order=0, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_NovoCliente_RESTInterface gxTpr_Novocliente
		{
			get {
				if (sdt.ShouldSerializegxTpr_Novocliente_Json())
					return new SdtWpNovaPropostaData_NovoCliente_RESTInterface(sdt.gxTpr_Novocliente);
				else
					return null;

			}

			set {
				sdt.gxTpr_Novocliente = value.sdt;
			}

		}

		[JsonPropertyName("Responsavel")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Responsavel", Order=1, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_Responsavel_RESTInterface gxTpr_Responsavel
		{
			get {
				if (sdt.ShouldSerializegxTpr_Responsavel_Json())
					return new SdtWpNovaPropostaData_Responsavel_RESTInterface(sdt.gxTpr_Responsavel);
				else
					return null;

			}

			set {
				sdt.gxTpr_Responsavel = value.sdt;
			}

		}

		[JsonPropertyName("Conta")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Conta", Order=2, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_Conta_RESTInterface gxTpr_Conta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Conta_Json())
					return new SdtWpNovaPropostaData_Conta_RESTInterface(sdt.gxTpr_Conta);
				else
					return null;

			}

			set {
				sdt.gxTpr_Conta = value.sdt;
			}

		}

		[JsonPropertyName("Proposta")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Proposta", Order=3, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_Proposta_RESTInterface gxTpr_Proposta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Proposta_Json())
					return new SdtWpNovaPropostaData_Proposta_RESTInterface(sdt.gxTpr_Proposta);
				else
					return null;

			}

			set {
				sdt.gxTpr_Proposta = value.sdt;
			}

		}

		[JsonPropertyName("Documentos")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Documentos", Order=4, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_Documentos_RESTInterface gxTpr_Documentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Documentos_Json())
					return new SdtWpNovaPropostaData_Documentos_RESTInterface(sdt.gxTpr_Documentos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Documentos = value.sdt;
			}

		}

		[JsonPropertyName("Resumo")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Resumo", Order=5, EmitDefaultValue=false)]
		public SdtWpNovaPropostaData_Resumo_RESTInterface gxTpr_Resumo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Resumo_Json())
					return new SdtWpNovaPropostaData_Resumo_RESTInterface(sdt.gxTpr_Resumo);
				else
					return null;

			}

			set {
				sdt.gxTpr_Resumo = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=6, EmitDefaultValue=false)]
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
		public SdtWpNovaPropostaData sdt
		{
			get { 
				return (SdtWpNovaPropostaData)Sdt;
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
				sdt = new SdtWpNovaPropostaData() ;
			}
		}
	}
	#endregion
}