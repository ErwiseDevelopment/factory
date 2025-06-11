/*
				   File: type_SdtWPropostaData_Clinica_GridItem
			Description: Grid
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
	[XmlRoot(ElementName="WPropostaData.Clinica.GridItem")]
	[XmlType(TypeName="WPropostaData.Clinica.GridItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Clinica_GridItem : GxUserType
	{
		public SdtWPropostaData_Clinica_GridItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Clinica_GridItem_Clienterazaosocial = "";

			gxTv_SdtWPropostaData_Clinica_GridItem_Clientenomefantasia = "";

			gxTv_SdtWPropostaData_Clinica_GridItem_Clientedocumento = "";


		}

		public SdtWPropostaData_Clinica_GridItem(IGxContext context)
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
			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("ClienteNomeFantasia", gxTpr_Clientenomefantasia, false);


			AddObjectProperty("ClienteDocumento", gxTpr_Clientedocumento, false);


			AddObjectProperty("GridClienteId", gxTpr_Gridclienteid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_GridItem_Clienterazaosocial; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_GridItem_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="ClienteNomeFantasia")]
		[XmlElement(ElementName="ClienteNomeFantasia")]
		public string gxTpr_Clientenomefantasia
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_GridItem_Clientenomefantasia; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_GridItem_Clientenomefantasia = value;
				SetDirty("Clientenomefantasia");
			}
		}




		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_GridItem_Clientedocumento; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_GridItem_Clientedocumento = value;
				SetDirty("Clientedocumento");
			}
		}




		[SoapElement(ElementName="GridClienteId")]
		[XmlElement(ElementName="GridClienteId")]
		public int gxTpr_Gridclienteid
		{
			get {
				return gxTv_SdtWPropostaData_Clinica_GridItem_Gridclienteid; 
			}
			set {
				gxTv_SdtWPropostaData_Clinica_GridItem_Gridclienteid = value;
				SetDirty("Gridclienteid");
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
			gxTv_SdtWPropostaData_Clinica_GridItem_Clienterazaosocial = "";
			gxTv_SdtWPropostaData_Clinica_GridItem_Clientenomefantasia = "";
			gxTv_SdtWPropostaData_Clinica_GridItem_Clientedocumento = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPropostaData_Clinica_GridItem_Clienterazaosocial;
		 

		protected string gxTv_SdtWPropostaData_Clinica_GridItem_Clientenomefantasia;
		 

		protected string gxTv_SdtWPropostaData_Clinica_GridItem_Clientedocumento;
		 

		protected int gxTv_SdtWPropostaData_Clinica_GridItem_Gridclienteid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPropostaData.Clinica.GridItem", Namespace="Factory21")]
	public class SdtWPropostaData_Clinica_GridItem_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Clinica_GridItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Clinica_GridItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Clinica_GridItem_RESTInterface( SdtWPropostaData_Clinica_GridItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteRazaoSocial")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ClienteRazaoSocial", Order=0)]
		public  string gxTpr_Clienterazaosocial
		{
			get { 
				return sdt.gxTpr_Clienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Clienterazaosocial = value;
			}
		}

		[JsonPropertyName("ClienteNomeFantasia")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClienteNomeFantasia", Order=1)]
		public  string gxTpr_Clientenomefantasia
		{
			get { 
				return sdt.gxTpr_Clientenomefantasia;

			}
			set { 
				 sdt.gxTpr_Clientenomefantasia = value;
			}
		}

		[JsonPropertyName("ClienteDocumento")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ClienteDocumento", Order=2)]
		public  string gxTpr_Clientedocumento
		{
			get { 
				return sdt.gxTpr_Clientedocumento;

			}
			set { 
				 sdt.gxTpr_Clientedocumento = value;
			}
		}

		[JsonPropertyName("GridClienteId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="GridClienteId", Order=3)]
		public  string gxTpr_Gridclienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Gridclienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Gridclienteid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Clinica_GridItem sdt
		{
			get { 
				return (SdtWPropostaData_Clinica_GridItem)Sdt;
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
				sdt = new SdtWPropostaData_Clinica_GridItem() ;
			}
		}
	}
	#endregion
}