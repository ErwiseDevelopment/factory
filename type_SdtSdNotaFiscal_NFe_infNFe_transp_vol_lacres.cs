/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres
			Description: lacres
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.transp.vol.lacres")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.transp.vol.lacres" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_Nlacre = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres(IGxContext context)
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
			AddObjectProperty("nLacre", gxTpr_Nlacre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nLacre")]
		[XmlElement(ElementName="nLacre")]
		public string gxTpr_Nlacre
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_Nlacre; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_Nlacre = value;
				SetDirty("Nlacre");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_Nlacre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_Nlacre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.transp.vol.lacres", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("nLacre")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="nLacre", Order=0)]
		public  string gxTpr_Nlacre
		{
			get { 
				return sdt.gxTpr_Nlacre;

			}
			set { 
				 sdt.gxTpr_Nlacre = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres() ;
			}
		}
	}
	#endregion
}