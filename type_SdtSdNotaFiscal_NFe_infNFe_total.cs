/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_total
			Description: total
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.total")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.total" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_total : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_total( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_total(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot != null)
			{
				AddObjectProperty("ICMSTot", gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ICMSTot" )]
		[XmlElement(ElementName="ICMSTot" )]
		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot gxTpr_Icmstot
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot = new SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_N = false;
				SetDirty("Icmstot");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot = value;
				SetDirty("Icmstot");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot == null;
		}
		public bool ShouldSerializegxTpr_Icmstot_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Icmstot_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot_N;
		protected SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot gxTv_SdtSdNotaFiscal_NFe_infNFe_total_Icmstot = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.total", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_total_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_total>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_total_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_total_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_total psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ICMSTot")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ICMSTot", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_RESTInterface gxTpr_Icmstot
		{
			get {
				if (sdt.ShouldSerializegxTpr_Icmstot_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_RESTInterface(sdt.gxTpr_Icmstot);
				else
					return null;

			}

			set {
				sdt.gxTpr_Icmstot = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_total sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_total)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_total() ;
			}
		}
	}
	#endregion
}