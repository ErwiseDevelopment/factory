/*
				   File: type_SdtWpNovoContratoData
			Description: WpNovoContratoData
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
	[XmlRoot(ElementName="WpNovoContratoData")]
	[XmlType(TypeName="WpNovoContratoData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWpNovoContratoData : GxUserType
	{
		public SdtWpNovoContratoData( )
		{
			/* Constructor for serialization */
		}

		public SdtWpNovoContratoData(IGxContext context)
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
			if (gxTv_SdtWpNovoContratoData_Participantes != null)
			{
				AddObjectProperty("Participantes", gxTv_SdtWpNovoContratoData_Participantes, false);
			}
			if (gxTv_SdtWpNovoContratoData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWpNovoContratoData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Participantes" )]
		[XmlElement(ElementName="Participantes" )]
		public SdtWpNovoContratoData_Participantes gxTpr_Participantes
		{
			get {
				if ( gxTv_SdtWpNovoContratoData_Participantes == null )
				{
					gxTv_SdtWpNovoContratoData_Participantes = new SdtWpNovoContratoData_Participantes(context);
				}
				gxTv_SdtWpNovoContratoData_Participantes_N = false;
				SetDirty("Participantes");
				return gxTv_SdtWpNovoContratoData_Participantes;
			}
			set {
				gxTv_SdtWpNovoContratoData_Participantes_N = false;
				gxTv_SdtWpNovoContratoData_Participantes = value;
				SetDirty("Participantes");
			}

		}

		public void gxTv_SdtWpNovoContratoData_Participantes_SetNull()
		{
			gxTv_SdtWpNovoContratoData_Participantes_N = true;
			gxTv_SdtWpNovoContratoData_Participantes = null;
		}

		public bool gxTv_SdtWpNovoContratoData_Participantes_IsNull()
		{
			return gxTv_SdtWpNovoContratoData_Participantes == null;
		}
		public bool ShouldSerializegxTpr_Participantes_Json()
		{
				return (gxTv_SdtWpNovoContratoData_Participantes != null && gxTv_SdtWpNovoContratoData_Participantes.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWpNovoContratoData_Auxiliardata == null )
				{
					gxTv_SdtWpNovoContratoData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWpNovoContratoData_Auxiliardata;
			}
			set {
				gxTv_SdtWpNovoContratoData_Auxiliardata_N = false;
				gxTv_SdtWpNovoContratoData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWpNovoContratoData_Auxiliardata == null )
				{
					gxTv_SdtWpNovoContratoData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWpNovoContratoData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtWpNovoContratoData_Auxiliardata ;
			}
			set {
				gxTv_SdtWpNovoContratoData_Auxiliardata_N = false;
				gxTv_SdtWpNovoContratoData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWpNovoContratoData_Auxiliardata_SetNull()
		{
			gxTv_SdtWpNovoContratoData_Auxiliardata_N = true;
			gxTv_SdtWpNovoContratoData_Auxiliardata = null;
		}

		public bool gxTv_SdtWpNovoContratoData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWpNovoContratoData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWpNovoContratoData_Auxiliardata != null && gxTv_SdtWpNovoContratoData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Participantes_Json() ||
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
			gxTv_SdtWpNovoContratoData_Participantes_N = true;


			gxTv_SdtWpNovoContratoData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWpNovoContratoData_Participantes_N;
		protected SdtWpNovoContratoData_Participantes gxTv_SdtWpNovoContratoData_Participantes = null; 

		protected bool gxTv_SdtWpNovoContratoData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWpNovoContratoData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WpNovoContratoData", Namespace="Factory21")]
	public class SdtWpNovoContratoData_RESTInterface : GxGenericCollectionItem<SdtWpNovoContratoData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWpNovoContratoData_RESTInterface( ) : base()
		{	
		}

		public SdtWpNovoContratoData_RESTInterface( SdtWpNovoContratoData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Participantes")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Participantes", Order=0, EmitDefaultValue=false)]
		public SdtWpNovoContratoData_Participantes_RESTInterface gxTpr_Participantes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Participantes_Json())
					return new SdtWpNovoContratoData_Participantes_RESTInterface(sdt.gxTpr_Participantes);
				else
					return null;

			}

			set {
				sdt.gxTpr_Participantes = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=1, EmitDefaultValue=false)]
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
		public SdtWpNovoContratoData sdt
		{
			get { 
				return (SdtWpNovoContratoData)Sdt;
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
				sdt = new SdtWpNovoContratoData() ;
			}
		}
	}
	#endregion
}