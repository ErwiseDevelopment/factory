/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_emit
			Description: emit
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.emit")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.emit" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_emit : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_emit( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Cnpj = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xnome = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xfant = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Ie = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_emit(IGxContext context)
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
			AddObjectProperty("CNPJ", gxTpr_Cnpj, false);


			AddObjectProperty("xNome", gxTpr_Xnome, false);


			AddObjectProperty("xFant", gxTpr_Xfant, false);

			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit != null)
			{
				AddObjectProperty("enderEmit", gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit, false);
			}

			AddObjectProperty("IE", gxTpr_Ie, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CNPJ")]
		[XmlElement(ElementName="CNPJ")]
		public string gxTpr_Cnpj
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Cnpj; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Cnpj = value;
				SetDirty("Cnpj");
			}
		}




		[SoapElement(ElementName="xNome")]
		[XmlElement(ElementName="xNome")]
		public string gxTpr_Xnome
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xnome; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xnome = value;
				SetDirty("Xnome");
			}
		}




		[SoapElement(ElementName="xFant")]
		[XmlElement(ElementName="xFant")]
		public string gxTpr_Xfant
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xfant; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xfant = value;
				SetDirty("Xfant");
			}
		}



		[SoapElement(ElementName="enderEmit" )]
		[XmlElement(ElementName="enderEmit" )]
		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit gxTpr_Enderemit
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit = new SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_N = false;
				SetDirty("Enderemit");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit = value;
				SetDirty("Enderemit");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit == null;
		}
		public bool ShouldSerializegxTpr_Enderemit_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="IE")]
		[XmlElement(ElementName="IE")]
		public string gxTpr_Ie
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Ie; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Ie = value;
				SetDirty("Ie");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Cnpj = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xnome = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xfant = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_N = true;

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Ie = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Cnpj;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xnome;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Xfant;
		 
		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit_N;
		protected SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Enderemit = null; 


		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_Ie;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.emit", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_emit_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_emit>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_emit_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_emit_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_emit psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("CNPJ")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="CNPJ", Order=0)]
		public  string gxTpr_Cnpj
		{
			get { 
				return sdt.gxTpr_Cnpj;

			}
			set { 
				 sdt.gxTpr_Cnpj = value;
			}
		}

		[JsonPropertyName("xNome")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="xNome", Order=1)]
		public  string gxTpr_Xnome
		{
			get { 
				return sdt.gxTpr_Xnome;

			}
			set { 
				 sdt.gxTpr_Xnome = value;
			}
		}

		[JsonPropertyName("xFant")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="xFant", Order=2)]
		public  string gxTpr_Xfant
		{
			get { 
				return sdt.gxTpr_Xfant;

			}
			set { 
				 sdt.gxTpr_Xfant = value;
			}
		}

		[JsonPropertyName("enderEmit")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="enderEmit", Order=3, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_RESTInterface gxTpr_Enderemit
		{
			get {
				if (sdt.ShouldSerializegxTpr_Enderemit_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_RESTInterface(sdt.gxTpr_Enderemit);
				else
					return null;

			}

			set {
				sdt.gxTpr_Enderemit = value.sdt;
			}

		}

		[JsonPropertyName("IE")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="IE", Order=4)]
		public  string gxTpr_Ie
		{
			get { 
				return sdt.gxTpr_Ie;

			}
			set { 
				 sdt.gxTpr_Ie = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_emit sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_emit)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_emit() ;
			}
		}
	}
	#endregion
}