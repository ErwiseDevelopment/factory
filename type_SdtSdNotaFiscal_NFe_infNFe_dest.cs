/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_dest
			Description: dest
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.dest")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.dest" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_dest : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_dest( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cnpj = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cpf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Xnome = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Ie = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_dest(IGxContext context)
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


			AddObjectProperty("CPF", gxTpr_Cpf, false);


			AddObjectProperty("xNome", gxTpr_Xnome, false);

			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest != null)
			{
				AddObjectProperty("enderDest", gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest, false);
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
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cnpj; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cnpj = value;
				SetDirty("Cnpj");
			}
		}




		[SoapElement(ElementName="CPF")]
		[XmlElement(ElementName="CPF")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cpf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="xNome")]
		[XmlElement(ElementName="xNome")]
		public string gxTpr_Xnome
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Xnome; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Xnome = value;
				SetDirty("Xnome");
			}
		}



		[SoapElement(ElementName="enderDest" )]
		[XmlElement(ElementName="enderDest" )]
		public SdtSdNotaFiscal_NFe_infNFe_dest_enderDest gxTpr_Enderdest
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest = new SdtSdNotaFiscal_NFe_infNFe_dest_enderDest(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_N = false;
				SetDirty("Enderdest");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest = value;
				SetDirty("Enderdest");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest == null;
		}
		public bool ShouldSerializegxTpr_Enderdest_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="IE")]
		[XmlElement(ElementName="IE")]
		public string gxTpr_Ie
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Ie; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Ie = value;
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cnpj = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cpf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Xnome = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_N = true;

			gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Ie = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cnpj;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Cpf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Xnome;
		 
		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest_N;
		protected SdtSdNotaFiscal_NFe_infNFe_dest_enderDest gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Enderdest = null; 


		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_dest_Ie;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.dest", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_dest_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_dest>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_dest_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_dest_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_dest psdt ) : base(psdt)
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

		[JsonPropertyName("CPF")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="CPF", Order=1)]
		public  string gxTpr_Cpf
		{
			get { 
				return sdt.gxTpr_Cpf;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}

		[JsonPropertyName("xNome")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="xNome", Order=2)]
		public  string gxTpr_Xnome
		{
			get { 
				return sdt.gxTpr_Xnome;

			}
			set { 
				 sdt.gxTpr_Xnome = value;
			}
		}

		[JsonPropertyName("enderDest")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="enderDest", Order=3, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_dest_enderDest_RESTInterface gxTpr_Enderdest
		{
			get {
				if (sdt.ShouldSerializegxTpr_Enderdest_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_dest_enderDest_RESTInterface(sdt.gxTpr_Enderdest);
				else
					return null;

			}

			set {
				sdt.gxTpr_Enderdest = value.sdt;
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
		public SdtSdNotaFiscal_NFe_infNFe_dest sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_dest)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_dest() ;
			}
		}
	}
	#endregion
}