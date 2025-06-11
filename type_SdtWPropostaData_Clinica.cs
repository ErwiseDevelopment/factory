/*
				   File: type_SdtWPropostaData_Clinica
			Description: Clinica
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
	[XmlRoot(ElementName="WPropostaData.Clinica")]
	[XmlType(TypeName="WPropostaData.Clinica" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Clinica : GxUserType
	{
		public SdtWPropostaData_Clinica( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Clinica_Filtro = "";


		}

		public SdtWPropostaData_Clinica(IGxContext context)
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
			AddObjectProperty("Filtro", gxTpr_Filtro, false);


			AddObjectProperty("ClienteId", gxTpr_Clienteid, false);

			if (gxTv_SdtWPropostaData_Clinica_Grid != null)
			{
				AddObjectProperty("Grid", gxTv_SdtWPropostaData_Clinica_Grid, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Filtro")]
		[XmlElement(ElementName="Filtro")]
		public string gxTpr_Filtro
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_Filtro; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_Filtro = value;
				SetDirty("Filtro");
			}
		}




		[SoapElement(ElementName="ClienteId")]
		[XmlElement(ElementName="ClienteId")]
		public int gxTpr_Clienteid
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_Clienteid; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_Clienteid = value;
				SetDirty("Clienteid");
			}
		}




		[SoapElement(ElementName="Grid" )]
		[XmlArray(ElementName="Grid"  )]
		[XmlArrayItemAttribute(ElementName="GridItem" , IsNullable=false )]
		public GXBaseCollection<SdtWPropostaData_Clinica_GridItem> gxTpr_Grid
		{
			get {
				if ( gxTv_SdtWPropostaData_Clinica_Grid == null )
				{
					gxTv_SdtWPropostaData_Clinica_Grid = new GXBaseCollection<SdtWPropostaData_Clinica_GridItem>( context, "WPropostaData.Clinica.GridItem", "");
				}
				SetDirty("Grid");
				return gxTv_SdtWPropostaData_Clinica_Grid;
			}
			set {
				gxTv_SdtWPropostaData_Clinica_Grid_N = false;
				gxTv_SdtWPropostaData_Clinica_Grid = value;
				SetDirty("Grid");
			}
		}

		public void gxTv_SdtWPropostaData_Clinica_Grid_SetNull()
		{
			gxTv_SdtWPropostaData_Clinica_Grid_N = true;
			gxTv_SdtWPropostaData_Clinica_Grid = null;
		}

		public bool gxTv_SdtWPropostaData_Clinica_Grid_IsNull()
		{
			return gxTv_SdtWPropostaData_Clinica_Grid == null;
		}
		public bool ShouldSerializegxTpr_Grid_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPropostaData_Clinica_Grid != null && gxTv_SdtWPropostaData_Clinica_Grid.Count > 0;

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
			gxTv_SdtWPropostaData_Clinica_Filtro = "";


			gxTv_SdtWPropostaData_Clinica_Grid_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPropostaData_Clinica_Filtro;
		 

		protected int gxTv_SdtWPropostaData_Clinica_Clienteid;
		 
		protected bool gxTv_SdtWPropostaData_Clinica_Grid_N;
		protected GXBaseCollection<SdtWPropostaData_Clinica_GridItem> gxTv_SdtWPropostaData_Clinica_Grid = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Clinica", Namespace="Factory21")]
	public class SdtWPropostaData_Clinica_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Clinica>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Clinica_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Clinica_RESTInterface( SdtWPropostaData_Clinica psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Filtro")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Filtro", Order=0)]
		public  string gxTpr_Filtro
		{
			get { 
				return sdt.gxTpr_Filtro;

			}
			set { 
				 sdt.gxTpr_Filtro = value;
			}
		}

		[JsonPropertyName("ClienteId")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClienteId", Order=1)]
		public  string gxTpr_Clienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("Grid")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Grid", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWPropostaData_Clinica_GridItem_RESTInterface> gxTpr_Grid
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grid_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWPropostaData_Clinica_GridItem_RESTInterface>(sdt.gxTpr_Grid);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Grid);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Clinica sdt
		{
			get { 
				return (SdtWPropostaData_Clinica)Sdt;
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
				sdt = new SdtWPropostaData_Clinica() ;
			}
		}
	}
	#endregion
}