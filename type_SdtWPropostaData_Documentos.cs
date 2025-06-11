/*
				   File: type_SdtWPropostaData_Documentos
			Description: Documentos
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
	[XmlRoot(ElementName="WPropostaData.Documentos")]
	[XmlType(TypeName="WPropostaData.Documentos" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Documentos : GxUserType
	{
		public SdtWPropostaData_Documentos( )
		{
			/* Constructor for serialization */
		}

		public SdtWPropostaData_Documentos(IGxContext context)
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
			if (gxTv_SdtWPropostaData_Documentos_Griddoc != null)
			{
				AddObjectProperty("GridDoc", gxTv_SdtWPropostaData_Documentos_Griddoc, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GridDoc" )]
		[XmlArray(ElementName="GridDoc"  )]
		[XmlArrayItemAttribute(ElementName="GridDocItem" , IsNullable=false )]
		public GXBaseCollection<SdtWPropostaData_Documentos_GridDocItem> gxTpr_Griddoc
		{
			get {
				if ( gxTv_SdtWPropostaData_Documentos_Griddoc == null )
				{
					gxTv_SdtWPropostaData_Documentos_Griddoc = new GXBaseCollection<SdtWPropostaData_Documentos_GridDocItem>( context, "WPropostaData.Documentos.GridDocItem", "");
				}
				SetDirty("Griddoc");
				return gxTv_SdtWPropostaData_Documentos_Griddoc;
			}
			set {
				gxTv_SdtWPropostaData_Documentos_Griddoc_N = false;
				gxTv_SdtWPropostaData_Documentos_Griddoc = value;
				SetDirty("Griddoc");
			}
		}

		public void gxTv_SdtWPropostaData_Documentos_Griddoc_SetNull()
		{
			gxTv_SdtWPropostaData_Documentos_Griddoc_N = true;
			gxTv_SdtWPropostaData_Documentos_Griddoc = null;
		}

		public bool gxTv_SdtWPropostaData_Documentos_Griddoc_IsNull()
		{
			return gxTv_SdtWPropostaData_Documentos_Griddoc == null;
		}
		public bool ShouldSerializegxTpr_Griddoc_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPropostaData_Documentos_Griddoc != null && gxTv_SdtWPropostaData_Documentos_Griddoc.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Griddoc_GxSimpleCollection_Json() || 
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
			gxTv_SdtWPropostaData_Documentos_Griddoc_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWPropostaData_Documentos_Griddoc_N;
		protected GXBaseCollection<SdtWPropostaData_Documentos_GridDocItem> gxTv_SdtWPropostaData_Documentos_Griddoc = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Documentos", Namespace="Factory21")]
	public class SdtWPropostaData_Documentos_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Documentos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Documentos_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Documentos_RESTInterface( SdtWPropostaData_Documentos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("GridDoc")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="GridDoc", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWPropostaData_Documentos_GridDocItem_RESTInterface> gxTpr_Griddoc
		{
			get {
				if (sdt.ShouldSerializegxTpr_Griddoc_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWPropostaData_Documentos_GridDocItem_RESTInterface>(sdt.gxTpr_Griddoc);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Griddoc);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Documentos sdt
		{
			get { 
				return (SdtWPropostaData_Documentos)Sdt;
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
				sdt = new SdtWPropostaData_Documentos() ;
			}
		}
	}
	#endregion
}