/*
				   File: type_SdtWPropostaData
			Description: WPropostaData
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
	[XmlRoot(ElementName="WPropostaData")]
	[XmlType(TypeName="WPropostaData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData : GxUserType
	{
		public SdtWPropostaData( )
		{
			/* Constructor for serialization */
		}

		public SdtWPropostaData(IGxContext context)
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
			if (gxTv_SdtWPropostaData_Clinica != null)
			{
				AddObjectProperty("Clinica", gxTv_SdtWPropostaData_Clinica, false);
			}
			if (gxTv_SdtWPropostaData_Novocliente != null)
			{
				AddObjectProperty("NovoCliente", gxTv_SdtWPropostaData_Novocliente, false);
			}
			if (gxTv_SdtWPropostaData_Responsavel != null)
			{
				AddObjectProperty("Responsavel", gxTv_SdtWPropostaData_Responsavel, false);
			}
			if (gxTv_SdtWPropostaData_Conta != null)
			{
				AddObjectProperty("Conta", gxTv_SdtWPropostaData_Conta, false);
			}
			if (gxTv_SdtWPropostaData_Proposta != null)
			{
				AddObjectProperty("Proposta", gxTv_SdtWPropostaData_Proposta, false);
			}
			if (gxTv_SdtWPropostaData_Documentos != null)
			{
				AddObjectProperty("Documentos", gxTv_SdtWPropostaData_Documentos, false);
			}
			if (gxTv_SdtWPropostaData_Resumo != null)
			{
				AddObjectProperty("Resumo", gxTv_SdtWPropostaData_Resumo, false);
			}
			if (gxTv_SdtWPropostaData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWPropostaData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Clinica" )]
		[XmlElement(ElementName="Clinica" )]
		public SdtWPropostaData_Clinica gxTpr_Clinica
		{
			get {
				if ( gxTv_SdtWPropostaData_Clinica == null )
				{
					gxTv_SdtWPropostaData_Clinica = new SdtWPropostaData_Clinica(context);
				}
				gxTv_SdtWPropostaData_Clinica_N = false;
				SetDirty("Clinica");
				return gxTv_SdtWPropostaData_Clinica;
			}
			set {
				gxTv_SdtWPropostaData_Clinica_N = false;
				gxTv_SdtWPropostaData_Clinica = value;
				SetDirty("Clinica");
			}

		}

		public void gxTv_SdtWPropostaData_Clinica_SetNull()
		{
			gxTv_SdtWPropostaData_Clinica_N = true;
			gxTv_SdtWPropostaData_Clinica = null;
		}

		public bool gxTv_SdtWPropostaData_Clinica_IsNull()
		{
			return gxTv_SdtWPropostaData_Clinica == null;
		}
		public bool ShouldSerializegxTpr_Clinica_Json()
		{
				return (gxTv_SdtWPropostaData_Clinica != null && gxTv_SdtWPropostaData_Clinica.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="NovoCliente" )]
		[XmlElement(ElementName="NovoCliente" )]
		public SdtWPropostaData_NovoCliente gxTpr_Novocliente
		{
			get {
				if ( gxTv_SdtWPropostaData_Novocliente == null )
				{
					gxTv_SdtWPropostaData_Novocliente = new SdtWPropostaData_NovoCliente(context);
				}
				gxTv_SdtWPropostaData_Novocliente_N = false;
				SetDirty("Novocliente");
				return gxTv_SdtWPropostaData_Novocliente;
			}
			set {
				gxTv_SdtWPropostaData_Novocliente_N = false;
				gxTv_SdtWPropostaData_Novocliente = value;
				SetDirty("Novocliente");
			}

		}

		public void gxTv_SdtWPropostaData_Novocliente_SetNull()
		{
			gxTv_SdtWPropostaData_Novocliente_N = true;
			gxTv_SdtWPropostaData_Novocliente = null;
		}

		public bool gxTv_SdtWPropostaData_Novocliente_IsNull()
		{
			return gxTv_SdtWPropostaData_Novocliente == null;
		}
		public bool ShouldSerializegxTpr_Novocliente_Json()
		{
				return (gxTv_SdtWPropostaData_Novocliente != null && gxTv_SdtWPropostaData_Novocliente.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Responsavel" )]
		[XmlElement(ElementName="Responsavel" )]
		public SdtWPropostaData_Responsavel gxTpr_Responsavel
		{
			get {
				if ( gxTv_SdtWPropostaData_Responsavel == null )
				{
					gxTv_SdtWPropostaData_Responsavel = new SdtWPropostaData_Responsavel(context);
				}
				gxTv_SdtWPropostaData_Responsavel_N = false;
				SetDirty("Responsavel");
				return gxTv_SdtWPropostaData_Responsavel;
			}
			set {
				gxTv_SdtWPropostaData_Responsavel_N = false;
				gxTv_SdtWPropostaData_Responsavel = value;
				SetDirty("Responsavel");
			}

		}

		public void gxTv_SdtWPropostaData_Responsavel_SetNull()
		{
			gxTv_SdtWPropostaData_Responsavel_N = true;
			gxTv_SdtWPropostaData_Responsavel = null;
		}

		public bool gxTv_SdtWPropostaData_Responsavel_IsNull()
		{
			return gxTv_SdtWPropostaData_Responsavel == null;
		}
		public bool ShouldSerializegxTpr_Responsavel_Json()
		{
				return (gxTv_SdtWPropostaData_Responsavel != null && gxTv_SdtWPropostaData_Responsavel.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Conta" )]
		[XmlElement(ElementName="Conta" )]
		public SdtWPropostaData_Conta gxTpr_Conta
		{
			get {
				if ( gxTv_SdtWPropostaData_Conta == null )
				{
					gxTv_SdtWPropostaData_Conta = new SdtWPropostaData_Conta(context);
				}
				gxTv_SdtWPropostaData_Conta_N = false;
				SetDirty("Conta");
				return gxTv_SdtWPropostaData_Conta;
			}
			set {
				gxTv_SdtWPropostaData_Conta_N = false;
				gxTv_SdtWPropostaData_Conta = value;
				SetDirty("Conta");
			}

		}

		public void gxTv_SdtWPropostaData_Conta_SetNull()
		{
			gxTv_SdtWPropostaData_Conta_N = true;
			gxTv_SdtWPropostaData_Conta = null;
		}

		public bool gxTv_SdtWPropostaData_Conta_IsNull()
		{
			return gxTv_SdtWPropostaData_Conta == null;
		}
		public bool ShouldSerializegxTpr_Conta_Json()
		{
				return (gxTv_SdtWPropostaData_Conta != null && gxTv_SdtWPropostaData_Conta.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Proposta" )]
		[XmlElement(ElementName="Proposta" )]
		public SdtWPropostaData_Proposta gxTpr_Proposta
		{
			get {
				if ( gxTv_SdtWPropostaData_Proposta == null )
				{
					gxTv_SdtWPropostaData_Proposta = new SdtWPropostaData_Proposta(context);
				}
				gxTv_SdtWPropostaData_Proposta_N = false;
				SetDirty("Proposta");
				return gxTv_SdtWPropostaData_Proposta;
			}
			set {
				gxTv_SdtWPropostaData_Proposta_N = false;
				gxTv_SdtWPropostaData_Proposta = value;
				SetDirty("Proposta");
			}

		}

		public void gxTv_SdtWPropostaData_Proposta_SetNull()
		{
			gxTv_SdtWPropostaData_Proposta_N = true;
			gxTv_SdtWPropostaData_Proposta = null;
		}

		public bool gxTv_SdtWPropostaData_Proposta_IsNull()
		{
			return gxTv_SdtWPropostaData_Proposta == null;
		}
		public bool ShouldSerializegxTpr_Proposta_Json()
		{
				return (gxTv_SdtWPropostaData_Proposta != null && gxTv_SdtWPropostaData_Proposta.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Documentos" )]
		[XmlElement(ElementName="Documentos" )]
		public SdtWPropostaData_Documentos gxTpr_Documentos
		{
			get {
				if ( gxTv_SdtWPropostaData_Documentos == null )
				{
					gxTv_SdtWPropostaData_Documentos = new SdtWPropostaData_Documentos(context);
				}
				gxTv_SdtWPropostaData_Documentos_N = false;
				SetDirty("Documentos");
				return gxTv_SdtWPropostaData_Documentos;
			}
			set {
				gxTv_SdtWPropostaData_Documentos_N = false;
				gxTv_SdtWPropostaData_Documentos = value;
				SetDirty("Documentos");
			}

		}

		public void gxTv_SdtWPropostaData_Documentos_SetNull()
		{
			gxTv_SdtWPropostaData_Documentos_N = true;
			gxTv_SdtWPropostaData_Documentos = null;
		}

		public bool gxTv_SdtWPropostaData_Documentos_IsNull()
		{
			return gxTv_SdtWPropostaData_Documentos == null;
		}
		public bool ShouldSerializegxTpr_Documentos_Json()
		{
				return (gxTv_SdtWPropostaData_Documentos != null && gxTv_SdtWPropostaData_Documentos.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Resumo" )]
		[XmlElement(ElementName="Resumo" )]
		public SdtWPropostaData_Resumo gxTpr_Resumo
		{
			get {
				if ( gxTv_SdtWPropostaData_Resumo == null )
				{
					gxTv_SdtWPropostaData_Resumo = new SdtWPropostaData_Resumo(context);
				}
				gxTv_SdtWPropostaData_Resumo_N = false;
				SetDirty("Resumo");
				return gxTv_SdtWPropostaData_Resumo;
			}
			set {
				gxTv_SdtWPropostaData_Resumo_N = false;
				gxTv_SdtWPropostaData_Resumo = value;
				SetDirty("Resumo");
			}

		}

		public void gxTv_SdtWPropostaData_Resumo_SetNull()
		{
			gxTv_SdtWPropostaData_Resumo_N = true;
			gxTv_SdtWPropostaData_Resumo = null;
		}

		public bool gxTv_SdtWPropostaData_Resumo_IsNull()
		{
			return gxTv_SdtWPropostaData_Resumo == null;
		}
		public bool ShouldSerializegxTpr_Resumo_Json()
		{
				return (gxTv_SdtWPropostaData_Resumo != null && gxTv_SdtWPropostaData_Resumo.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWPropostaData_Auxiliardata == null )
				{
					gxTv_SdtWPropostaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWPropostaData_Auxiliardata;
			}
			set {
				gxTv_SdtWPropostaData_Auxiliardata_N = false;
				gxTv_SdtWPropostaData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWPropostaData_Auxiliardata == null )
				{
					gxTv_SdtWPropostaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWPropostaData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtWPropostaData_Auxiliardata ;
			}
			set {
				gxTv_SdtWPropostaData_Auxiliardata_N = false;
				gxTv_SdtWPropostaData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWPropostaData_Auxiliardata_SetNull()
		{
			gxTv_SdtWPropostaData_Auxiliardata_N = true;
			gxTv_SdtWPropostaData_Auxiliardata = null;
		}

		public bool gxTv_SdtWPropostaData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWPropostaData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWPropostaData_Auxiliardata != null && gxTv_SdtWPropostaData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Clinica_Json() ||
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
			gxTv_SdtWPropostaData_Clinica_N = true;


			gxTv_SdtWPropostaData_Novocliente_N = true;


			gxTv_SdtWPropostaData_Responsavel_N = true;


			gxTv_SdtWPropostaData_Conta_N = true;


			gxTv_SdtWPropostaData_Proposta_N = true;


			gxTv_SdtWPropostaData_Documentos_N = true;


			gxTv_SdtWPropostaData_Resumo_N = true;


			gxTv_SdtWPropostaData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPropostaData_Clinica_N;
		protected SdtWPropostaData_Clinica gxTv_SdtWPropostaData_Clinica = null; 

		protected bool gxTv_SdtWPropostaData_Novocliente_N;
		protected SdtWPropostaData_NovoCliente gxTv_SdtWPropostaData_Novocliente = null; 

		protected bool gxTv_SdtWPropostaData_Responsavel_N;
		protected SdtWPropostaData_Responsavel gxTv_SdtWPropostaData_Responsavel = null; 

		protected bool gxTv_SdtWPropostaData_Conta_N;
		protected SdtWPropostaData_Conta gxTv_SdtWPropostaData_Conta = null; 

		protected bool gxTv_SdtWPropostaData_Proposta_N;
		protected SdtWPropostaData_Proposta gxTv_SdtWPropostaData_Proposta = null; 

		protected bool gxTv_SdtWPropostaData_Documentos_N;
		protected SdtWPropostaData_Documentos gxTv_SdtWPropostaData_Documentos = null; 

		protected bool gxTv_SdtWPropostaData_Resumo_N;
		protected SdtWPropostaData_Resumo gxTv_SdtWPropostaData_Resumo = null; 

		protected bool gxTv_SdtWPropostaData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWPropostaData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData", Namespace="Factory21")]
	public class SdtWPropostaData_RESTInterface : GxGenericCollectionItem<SdtWPropostaData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_RESTInterface( SdtWPropostaData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Clinica")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Clinica", Order=0, EmitDefaultValue=false)]
		public SdtWPropostaData_Clinica_RESTInterface gxTpr_Clinica
		{
			get {
				if (sdt.ShouldSerializegxTpr_Clinica_Json())
					return new SdtWPropostaData_Clinica_RESTInterface(sdt.gxTpr_Clinica);
				else
					return null;

			}

			set {
				sdt.gxTpr_Clinica = value.sdt;
			}

		}

		[JsonPropertyName("NovoCliente")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="NovoCliente", Order=1, EmitDefaultValue=false)]
		public SdtWPropostaData_NovoCliente_RESTInterface gxTpr_Novocliente
		{
			get {
				if (sdt.ShouldSerializegxTpr_Novocliente_Json())
					return new SdtWPropostaData_NovoCliente_RESTInterface(sdt.gxTpr_Novocliente);
				else
					return null;

			}

			set {
				sdt.gxTpr_Novocliente = value.sdt;
			}

		}

		[JsonPropertyName("Responsavel")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Responsavel", Order=2, EmitDefaultValue=false)]
		public SdtWPropostaData_Responsavel_RESTInterface gxTpr_Responsavel
		{
			get {
				if (sdt.ShouldSerializegxTpr_Responsavel_Json())
					return new SdtWPropostaData_Responsavel_RESTInterface(sdt.gxTpr_Responsavel);
				else
					return null;

			}

			set {
				sdt.gxTpr_Responsavel = value.sdt;
			}

		}

		[JsonPropertyName("Conta")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Conta", Order=3, EmitDefaultValue=false)]
		public SdtWPropostaData_Conta_RESTInterface gxTpr_Conta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Conta_Json())
					return new SdtWPropostaData_Conta_RESTInterface(sdt.gxTpr_Conta);
				else
					return null;

			}

			set {
				sdt.gxTpr_Conta = value.sdt;
			}

		}

		[JsonPropertyName("Proposta")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Proposta", Order=4, EmitDefaultValue=false)]
		public SdtWPropostaData_Proposta_RESTInterface gxTpr_Proposta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Proposta_Json())
					return new SdtWPropostaData_Proposta_RESTInterface(sdt.gxTpr_Proposta);
				else
					return null;

			}

			set {
				sdt.gxTpr_Proposta = value.sdt;
			}

		}

		[JsonPropertyName("Documentos")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Documentos", Order=5, EmitDefaultValue=false)]
		public SdtWPropostaData_Documentos_RESTInterface gxTpr_Documentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Documentos_Json())
					return new SdtWPropostaData_Documentos_RESTInterface(sdt.gxTpr_Documentos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Documentos = value.sdt;
			}

		}

		[JsonPropertyName("Resumo")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Resumo", Order=6, EmitDefaultValue=false)]
		public SdtWPropostaData_Resumo_RESTInterface gxTpr_Resumo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Resumo_Json())
					return new SdtWPropostaData_Resumo_RESTInterface(sdt.gxTpr_Resumo);
				else
					return null;

			}

			set {
				sdt.gxTpr_Resumo = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=7, EmitDefaultValue=false)]
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
		public SdtWPropostaData sdt
		{
			get { 
				return (SdtWPropostaData)Sdt;
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
				sdt = new SdtWPropostaData() ;
			}
		}
	}
	#endregion
}