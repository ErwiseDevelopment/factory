/*
				   File: type_SdtContatoData
			Description: ContatoData
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
	[XmlRoot(ElementName="ContatoData")]
	[XmlType(TypeName="ContatoData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtContatoData : GxUserType
	{
		public SdtContatoData( )
		{
			/* Constructor for serialization */
		}

		public SdtContatoData(IGxContext context)
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
			if (gxTv_SdtContatoData_Primeirocontato != null)
			{
				AddObjectProperty("PrimeiroContato", gxTv_SdtContatoData_Primeirocontato, false);
			}
			if (gxTv_SdtContatoData_Cnpj != null)
			{
				AddObjectProperty("CNPJ", gxTv_SdtContatoData_Cnpj, false);
			}
			if (gxTv_SdtContatoData_Empresa != null)
			{
				AddObjectProperty("Empresa", gxTv_SdtContatoData_Empresa, false);
			}
			if (gxTv_SdtContatoData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtContatoData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrimeiroContato" )]
		[XmlElement(ElementName="PrimeiroContato" )]
		public SdtContatoData_PrimeiroContato gxTpr_Primeirocontato
		{
			get {
				if ( gxTv_SdtContatoData_Primeirocontato == null )
				{
					gxTv_SdtContatoData_Primeirocontato = new SdtContatoData_PrimeiroContato(context);
				}
				gxTv_SdtContatoData_Primeirocontato_N = false;
				SetDirty("Primeirocontato");
				return gxTv_SdtContatoData_Primeirocontato;
			}
			set {
				gxTv_SdtContatoData_Primeirocontato_N = false;
				gxTv_SdtContatoData_Primeirocontato = value;
				SetDirty("Primeirocontato");
			}

		}

		public void gxTv_SdtContatoData_Primeirocontato_SetNull()
		{
			gxTv_SdtContatoData_Primeirocontato_N = true;
			gxTv_SdtContatoData_Primeirocontato = null;
		}

		public bool gxTv_SdtContatoData_Primeirocontato_IsNull()
		{
			return gxTv_SdtContatoData_Primeirocontato == null;
		}
		public bool ShouldSerializegxTpr_Primeirocontato_Json()
		{
				return (gxTv_SdtContatoData_Primeirocontato != null && gxTv_SdtContatoData_Primeirocontato.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="CNPJ" )]
		[XmlElement(ElementName="CNPJ" )]
		public SdtContatoData_CNPJ gxTpr_Cnpj
		{
			get {
				if ( gxTv_SdtContatoData_Cnpj == null )
				{
					gxTv_SdtContatoData_Cnpj = new SdtContatoData_CNPJ(context);
				}
				gxTv_SdtContatoData_Cnpj_N = false;
				SetDirty("Cnpj");
				return gxTv_SdtContatoData_Cnpj;
			}
			set {
				gxTv_SdtContatoData_Cnpj_N = false;
				gxTv_SdtContatoData_Cnpj = value;
				SetDirty("Cnpj");
			}

		}

		public void gxTv_SdtContatoData_Cnpj_SetNull()
		{
			gxTv_SdtContatoData_Cnpj_N = true;
			gxTv_SdtContatoData_Cnpj = null;
		}

		public bool gxTv_SdtContatoData_Cnpj_IsNull()
		{
			return gxTv_SdtContatoData_Cnpj == null;
		}
		public bool ShouldSerializegxTpr_Cnpj_Json()
		{
				return (gxTv_SdtContatoData_Cnpj != null && gxTv_SdtContatoData_Cnpj.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Empresa" )]
		[XmlElement(ElementName="Empresa" )]
		public SdtContatoData_Empresa gxTpr_Empresa
		{
			get {
				if ( gxTv_SdtContatoData_Empresa == null )
				{
					gxTv_SdtContatoData_Empresa = new SdtContatoData_Empresa(context);
				}
				gxTv_SdtContatoData_Empresa_N = false;
				SetDirty("Empresa");
				return gxTv_SdtContatoData_Empresa;
			}
			set {
				gxTv_SdtContatoData_Empresa_N = false;
				gxTv_SdtContatoData_Empresa = value;
				SetDirty("Empresa");
			}

		}

		public void gxTv_SdtContatoData_Empresa_SetNull()
		{
			gxTv_SdtContatoData_Empresa_N = true;
			gxTv_SdtContatoData_Empresa = null;
		}

		public bool gxTv_SdtContatoData_Empresa_IsNull()
		{
			return gxTv_SdtContatoData_Empresa == null;
		}
		public bool ShouldSerializegxTpr_Empresa_Json()
		{
				return (gxTv_SdtContatoData_Empresa != null && gxTv_SdtContatoData_Empresa.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtContatoData_Auxiliardata == null )
				{
					gxTv_SdtContatoData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtContatoData_Auxiliardata;
			}
			set {
				gxTv_SdtContatoData_Auxiliardata_N = false;
				gxTv_SdtContatoData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtContatoData_Auxiliardata == null )
				{
					gxTv_SdtContatoData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtContatoData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtContatoData_Auxiliardata ;
			}
			set {
				gxTv_SdtContatoData_Auxiliardata_N = false;
				gxTv_SdtContatoData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtContatoData_Auxiliardata_SetNull()
		{
			gxTv_SdtContatoData_Auxiliardata_N = true;
			gxTv_SdtContatoData_Auxiliardata = null;
		}

		public bool gxTv_SdtContatoData_Auxiliardata_IsNull()
		{
			return gxTv_SdtContatoData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtContatoData_Auxiliardata != null && gxTv_SdtContatoData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Primeirocontato_Json() ||
				ShouldSerializegxTpr_Cnpj_Json() ||
				ShouldSerializegxTpr_Empresa_Json() ||
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
			gxTv_SdtContatoData_Primeirocontato_N = true;


			gxTv_SdtContatoData_Cnpj_N = true;


			gxTv_SdtContatoData_Empresa_N = true;


			gxTv_SdtContatoData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtContatoData_Primeirocontato_N;
		protected SdtContatoData_PrimeiroContato gxTv_SdtContatoData_Primeirocontato = null; 

		protected bool gxTv_SdtContatoData_Cnpj_N;
		protected SdtContatoData_CNPJ gxTv_SdtContatoData_Cnpj = null; 

		protected bool gxTv_SdtContatoData_Empresa_N;
		protected SdtContatoData_Empresa gxTv_SdtContatoData_Empresa = null; 

		protected bool gxTv_SdtContatoData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtContatoData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ContatoData", Namespace="Factory21")]
	public class SdtContatoData_RESTInterface : GxGenericCollectionItem<SdtContatoData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContatoData_RESTInterface( ) : base()
		{	
		}

		public SdtContatoData_RESTInterface( SdtContatoData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PrimeiroContato")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="PrimeiroContato", Order=0, EmitDefaultValue=false)]
		public SdtContatoData_PrimeiroContato_RESTInterface gxTpr_Primeirocontato
		{
			get {
				if (sdt.ShouldSerializegxTpr_Primeirocontato_Json())
					return new SdtContatoData_PrimeiroContato_RESTInterface(sdt.gxTpr_Primeirocontato);
				else
					return null;

			}

			set {
				sdt.gxTpr_Primeirocontato = value.sdt;
			}

		}

		[JsonPropertyName("CNPJ")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="CNPJ", Order=1, EmitDefaultValue=false)]
		public SdtContatoData_CNPJ_RESTInterface gxTpr_Cnpj
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cnpj_Json())
					return new SdtContatoData_CNPJ_RESTInterface(sdt.gxTpr_Cnpj);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cnpj = value.sdt;
			}

		}

		[JsonPropertyName("Empresa")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Empresa", Order=2, EmitDefaultValue=false)]
		public SdtContatoData_Empresa_RESTInterface gxTpr_Empresa
		{
			get {
				if (sdt.ShouldSerializegxTpr_Empresa_Json())
					return new SdtContatoData_Empresa_RESTInterface(sdt.gxTpr_Empresa);
				else
					return null;

			}

			set {
				sdt.gxTpr_Empresa = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=3, EmitDefaultValue=false)]
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
		public SdtContatoData sdt
		{
			get { 
				return (SdtContatoData)Sdt;
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
				sdt = new SdtContatoData() ;
			}
		}
	}
	#endregion
}