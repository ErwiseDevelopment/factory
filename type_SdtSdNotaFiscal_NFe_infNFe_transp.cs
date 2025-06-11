/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_transp
			Description: transp
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.transp")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.transp" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_transp : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Modfrete = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_transp(IGxContext context)
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
			AddObjectProperty("modFrete", gxTpr_Modfrete, false);

			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta != null)
			{
				AddObjectProperty("transporta", gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp != null)
			{
				AddObjectProperty("veicTransp", gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque != null)
			{
				AddObjectProperty("reboque", gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol != null)
			{
				AddObjectProperty("vol", gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="modFrete")]
		[XmlElement(ElementName="modFrete")]
		public string gxTpr_Modfrete
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Modfrete; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Modfrete = value;
				SetDirty("Modfrete");
			}
		}



		[SoapElement(ElementName="transporta" )]
		[XmlElement(ElementName="transporta" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta gxTpr_Transporta
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta = new SdtSdNotaFiscal_NFe_infNFe_transp_transporta(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_N = false;
				SetDirty("Transporta");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta = value;
				SetDirty("Transporta");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta == null;
		}
		public bool ShouldSerializegxTpr_Transporta_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="veicTransp" )]
		[XmlElement(ElementName="veicTransp" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp_veicTransp gxTpr_Veictransp
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp = new SdtSdNotaFiscal_NFe_infNFe_transp_veicTransp(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_N = false;
				SetDirty("Veictransp");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp = value;
				SetDirty("Veictransp");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp == null;
		}
		public bool ShouldSerializegxTpr_Veictransp_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="reboque" )]
		[XmlElement(ElementName="reboque" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque gxTpr_Reboque
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque = new SdtSdNotaFiscal_NFe_infNFe_transp_reboque(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_N = false;
				SetDirty("Reboque");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque = value;
				SetDirty("Reboque");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque == null;
		}
		public bool ShouldSerializegxTpr_Reboque_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="vol" )]
		[XmlElement(ElementName="vol" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol gxTpr_Vol
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol = new SdtSdNotaFiscal_NFe_infNFe_transp_vol(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_N = false;
				SetDirty("Vol");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol = value;
				SetDirty("Vol");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol == null;
		}
		public bool ShouldSerializegxTpr_Vol_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol.ShouldSerializeSdtJson());

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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Modfrete = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Modfrete;
		 
		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp_transporta gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Transporta = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp_veicTransp gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Veictransp = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp_reboque gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Reboque = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp_vol gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_Vol = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.transp", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_transp>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_transp psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("modFrete")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="modFrete", Order=0)]
		public  string gxTpr_Modfrete
		{
			get { 
				return sdt.gxTpr_Modfrete;

			}
			set { 
				 sdt.gxTpr_Modfrete = value;
			}
		}

		[JsonPropertyName("transporta")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="transporta", Order=1, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta_RESTInterface gxTpr_Transporta
		{
			get {
				if (sdt.ShouldSerializegxTpr_Transporta_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_transporta_RESTInterface(sdt.gxTpr_Transporta);
				else
					return null;

			}

			set {
				sdt.gxTpr_Transporta = value.sdt;
			}

		}

		[JsonPropertyName("veicTransp")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="veicTransp", Order=2, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_veicTransp_RESTInterface gxTpr_Veictransp
		{
			get {
				if (sdt.ShouldSerializegxTpr_Veictransp_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_veicTransp_RESTInterface(sdt.gxTpr_Veictransp);
				else
					return null;

			}

			set {
				sdt.gxTpr_Veictransp = value.sdt;
			}

		}

		[JsonPropertyName("reboque")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="reboque", Order=3, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque_RESTInterface gxTpr_Reboque
		{
			get {
				if (sdt.ShouldSerializegxTpr_Reboque_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_reboque_RESTInterface(sdt.gxTpr_Reboque);
				else
					return null;

			}

			set {
				sdt.gxTpr_Reboque = value.sdt;
			}

		}

		[JsonPropertyName("vol")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="vol", Order=4, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_RESTInterface gxTpr_Vol
		{
			get {
				if (sdt.ShouldSerializegxTpr_Vol_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_vol_RESTInterface(sdt.gxTpr_Vol);
				else
					return null;

			}

			set {
				sdt.gxTpr_Vol = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_transp sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_transp)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_transp() ;
			}
		}
	}
	#endregion
}