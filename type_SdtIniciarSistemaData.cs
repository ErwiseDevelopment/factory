/*
				   File: type_SdtIniciarSistemaData
			Description: IniciarSistemaData
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
	[XmlRoot(ElementName="IniciarSistemaData")]
	[XmlType(TypeName="IniciarSistemaData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtIniciarSistemaData : GxUserType
	{
		public SdtIniciarSistemaData( )
		{
			/* Constructor for serialization */
		}

		public SdtIniciarSistemaData(IGxContext context)
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
			if (gxTv_SdtIniciarSistemaData_Empresa != null)
			{
				AddObjectProperty("Empresa", gxTv_SdtIniciarSistemaData_Empresa, false);
			}
			if (gxTv_SdtIniciarSistemaData_Usuario != null)
			{
				AddObjectProperty("Usuario", gxTv_SdtIniciarSistemaData_Usuario, false);
			}
			if (gxTv_SdtIniciarSistemaData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtIniciarSistemaData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Empresa" )]
		[XmlElement(ElementName="Empresa" )]
		public SdtIniciarSistemaData_Empresa gxTpr_Empresa
		{
			get {
				if ( gxTv_SdtIniciarSistemaData_Empresa == null )
				{
					gxTv_SdtIniciarSistemaData_Empresa = new SdtIniciarSistemaData_Empresa(context);
				}
				gxTv_SdtIniciarSistemaData_Empresa_N = false;
				SetDirty("Empresa");
				return gxTv_SdtIniciarSistemaData_Empresa;
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_N = false;
				gxTv_SdtIniciarSistemaData_Empresa = value;
				SetDirty("Empresa");
			}

		}

		public void gxTv_SdtIniciarSistemaData_Empresa_SetNull()
		{
			gxTv_SdtIniciarSistemaData_Empresa_N = true;
			gxTv_SdtIniciarSistemaData_Empresa = null;
		}

		public bool gxTv_SdtIniciarSistemaData_Empresa_IsNull()
		{
			return gxTv_SdtIniciarSistemaData_Empresa == null;
		}
		public bool ShouldSerializegxTpr_Empresa_Json()
		{
				return (gxTv_SdtIniciarSistemaData_Empresa != null && gxTv_SdtIniciarSistemaData_Empresa.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Usuario" )]
		[XmlElement(ElementName="Usuario" )]
		public SdtIniciarSistemaData_Usuario gxTpr_Usuario
		{
			get {
				if ( gxTv_SdtIniciarSistemaData_Usuario == null )
				{
					gxTv_SdtIniciarSistemaData_Usuario = new SdtIniciarSistemaData_Usuario(context);
				}
				gxTv_SdtIniciarSistemaData_Usuario_N = false;
				SetDirty("Usuario");
				return gxTv_SdtIniciarSistemaData_Usuario;
			}
			set {
				gxTv_SdtIniciarSistemaData_Usuario_N = false;
				gxTv_SdtIniciarSistemaData_Usuario = value;
				SetDirty("Usuario");
			}

		}

		public void gxTv_SdtIniciarSistemaData_Usuario_SetNull()
		{
			gxTv_SdtIniciarSistemaData_Usuario_N = true;
			gxTv_SdtIniciarSistemaData_Usuario = null;
		}

		public bool gxTv_SdtIniciarSistemaData_Usuario_IsNull()
		{
			return gxTv_SdtIniciarSistemaData_Usuario == null;
		}
		public bool ShouldSerializegxTpr_Usuario_Json()
		{
				return (gxTv_SdtIniciarSistemaData_Usuario != null && gxTv_SdtIniciarSistemaData_Usuario.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtIniciarSistemaData_Auxiliardata == null )
				{
					gxTv_SdtIniciarSistemaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtIniciarSistemaData_Auxiliardata;
			}
			set {
				gxTv_SdtIniciarSistemaData_Auxiliardata_N = false;
				gxTv_SdtIniciarSistemaData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtIniciarSistemaData_Auxiliardata == null )
				{
					gxTv_SdtIniciarSistemaData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtIniciarSistemaData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtIniciarSistemaData_Auxiliardata ;
			}
			set {
				gxTv_SdtIniciarSistemaData_Auxiliardata_N = false;
				gxTv_SdtIniciarSistemaData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtIniciarSistemaData_Auxiliardata_SetNull()
		{
			gxTv_SdtIniciarSistemaData_Auxiliardata_N = true;
			gxTv_SdtIniciarSistemaData_Auxiliardata = null;
		}

		public bool gxTv_SdtIniciarSistemaData_Auxiliardata_IsNull()
		{
			return gxTv_SdtIniciarSistemaData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtIniciarSistemaData_Auxiliardata != null && gxTv_SdtIniciarSistemaData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Empresa_Json() ||
				ShouldSerializegxTpr_Usuario_Json() ||
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
			gxTv_SdtIniciarSistemaData_Empresa_N = true;


			gxTv_SdtIniciarSistemaData_Usuario_N = true;


			gxTv_SdtIniciarSistemaData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtIniciarSistemaData_Empresa_N;
		protected SdtIniciarSistemaData_Empresa gxTv_SdtIniciarSistemaData_Empresa = null; 

		protected bool gxTv_SdtIniciarSistemaData_Usuario_N;
		protected SdtIniciarSistemaData_Usuario gxTv_SdtIniciarSistemaData_Usuario = null; 

		protected bool gxTv_SdtIniciarSistemaData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtIniciarSistemaData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"IniciarSistemaData", Namespace="Factory21")]
	public class SdtIniciarSistemaData_RESTInterface : GxGenericCollectionItem<SdtIniciarSistemaData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIniciarSistemaData_RESTInterface( ) : base()
		{	
		}

		public SdtIniciarSistemaData_RESTInterface( SdtIniciarSistemaData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Empresa")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Empresa", Order=0, EmitDefaultValue=false)]
		public SdtIniciarSistemaData_Empresa_RESTInterface gxTpr_Empresa
		{
			get {
				if (sdt.ShouldSerializegxTpr_Empresa_Json())
					return new SdtIniciarSistemaData_Empresa_RESTInterface(sdt.gxTpr_Empresa);
				else
					return null;

			}

			set {
				sdt.gxTpr_Empresa = value.sdt;
			}

		}

		[JsonPropertyName("Usuario")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Usuario", Order=1, EmitDefaultValue=false)]
		public SdtIniciarSistemaData_Usuario_RESTInterface gxTpr_Usuario
		{
			get {
				if (sdt.ShouldSerializegxTpr_Usuario_Json())
					return new SdtIniciarSistemaData_Usuario_RESTInterface(sdt.gxTpr_Usuario);
				else
					return null;

			}

			set {
				sdt.gxTpr_Usuario = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=2, EmitDefaultValue=false)]
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
		public SdtIniciarSistemaData sdt
		{
			get { 
				return (SdtIniciarSistemaData)Sdt;
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
				sdt = new SdtIniciarSistemaData() ;
			}
		}
	}
	#endregion
}