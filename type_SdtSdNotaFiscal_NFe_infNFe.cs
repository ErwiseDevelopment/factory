/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe
			Description: infNFe
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Id = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_Versao = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide != null)
			{
				AddObjectProperty("ide", gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit != null)
			{
				AddObjectProperty("emit", gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest != null)
			{
				AddObjectProperty("dest", gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada != null)
			{
				AddObjectProperty("retirada", gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega != null)
			{
				AddObjectProperty("entrega", gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Det != null)
			{
				AddObjectProperty("det", gxTv_SdtSdNotaFiscal_NFe_infNFe_Det, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Total != null)
			{
				AddObjectProperty("total", gxTv_SdtSdNotaFiscal_NFe_infNFe_Total, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp != null)
			{
				AddObjectProperty("transp", gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic != null)
			{
				AddObjectProperty("infAdic", gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic, false);
			}

			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("versao", gxTpr_Versao, false);

			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr != null)
			{
				AddObjectProperty("cobr", gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ide" )]
		[XmlElement(ElementName="ide" )]
		public SdtSdNotaFiscal_NFe_infNFe_ide gxTpr_Ide
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide = new SdtSdNotaFiscal_NFe_infNFe_ide(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_N = false;
				SetDirty("Ide");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide = value;
				SetDirty("Ide");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide == null;
		}
		public bool ShouldSerializegxTpr_Ide_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="emit" )]
		[XmlElement(ElementName="emit" )]
		public SdtSdNotaFiscal_NFe_infNFe_emit gxTpr_Emit
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit = new SdtSdNotaFiscal_NFe_infNFe_emit(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_N = false;
				SetDirty("Emit");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit = value;
				SetDirty("Emit");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit == null;
		}
		public bool ShouldSerializegxTpr_Emit_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="dest" )]
		[XmlElement(ElementName="dest" )]
		public SdtSdNotaFiscal_NFe_infNFe_dest gxTpr_Dest
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest = new SdtSdNotaFiscal_NFe_infNFe_dest(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_N = false;
				SetDirty("Dest");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest = value;
				SetDirty("Dest");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest == null;
		}
		public bool ShouldSerializegxTpr_Dest_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="retirada" )]
		[XmlElement(ElementName="retirada" )]
		public SdtSdNotaFiscal_NFe_infNFe_retirada gxTpr_Retirada
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada = new SdtSdNotaFiscal_NFe_infNFe_retirada(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_N = false;
				SetDirty("Retirada");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada = value;
				SetDirty("Retirada");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada == null;
		}
		public bool ShouldSerializegxTpr_Retirada_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="entrega" )]
		[XmlElement(ElementName="entrega" )]
		public SdtSdNotaFiscal_NFe_infNFe_entrega gxTpr_Entrega
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega = new SdtSdNotaFiscal_NFe_infNFe_entrega(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_N = false;
				SetDirty("Entrega");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega = value;
				SetDirty("Entrega");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega == null;
		}
		public bool ShouldSerializegxTpr_Entrega_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="det" )]
		[XmlArray(ElementName="det"  )]
		[XmlArrayItemAttribute(ElementName="detItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_detItem> gxTpr_Det
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Det == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Det = new GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_detItem>( context, "SdNotaFiscal.NFe.infNFe.detItem", "");
				}
				SetDirty("Det");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Det;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Det = value;
				SetDirty("Det");
			}
		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Det = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Det == null;
		}
		public bool ShouldSerializegxTpr_Det_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Det != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Det.Count > 0;

		}


		[SoapElement(ElementName="total" )]
		[XmlElement(ElementName="total" )]
		public SdtSdNotaFiscal_NFe_infNFe_total gxTpr_Total
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Total == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Total = new SdtSdNotaFiscal_NFe_infNFe_total(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_N = false;
				SetDirty("Total");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Total;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Total = value;
				SetDirty("Total");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Total = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Total == null;
		}
		public bool ShouldSerializegxTpr_Total_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Total != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Total.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="transp" )]
		[XmlElement(ElementName="transp" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp gxTpr_Transp
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp = new SdtSdNotaFiscal_NFe_infNFe_transp(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_N = false;
				SetDirty("Transp");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp = value;
				SetDirty("Transp");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp == null;
		}
		public bool ShouldSerializegxTpr_Transp_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="infAdic" )]
		[XmlElement(ElementName="infAdic" )]
		public SdtSdNotaFiscal_NFe_infNFe_infAdic gxTpr_Infadic
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic = new SdtSdNotaFiscal_NFe_infNFe_infAdic(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_N = false;
				SetDirty("Infadic");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic = value;
				SetDirty("Infadic");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic == null;
		}
		public bool ShouldSerializegxTpr_Infadic_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Id; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="versao")]
		[XmlElement(ElementName="versao")]
		public string gxTpr_Versao
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Versao; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Versao = value;
				SetDirty("Versao");
			}
		}



		[SoapElement(ElementName="cobr" )]
		[XmlElement(ElementName="cobr" )]
		public SdtSdNotaFiscal_NFe_infNFe_cobr gxTpr_Cobr
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr = new SdtSdNotaFiscal_NFe_infNFe_cobr(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_N = false;
				SetDirty("Cobr");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr = value;
				SetDirty("Cobr");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr == null;
		}
		public bool ShouldSerializegxTpr_Cobr_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr.ShouldSerializeSdtJson());

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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_N = true;

			gxTv_SdtSdNotaFiscal_NFe_infNFe_Id = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_Versao = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide_N;
		protected SdtSdNotaFiscal_NFe_infNFe_ide gxTv_SdtSdNotaFiscal_NFe_infNFe_Ide = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit_N;
		protected SdtSdNotaFiscal_NFe_infNFe_emit gxTv_SdtSdNotaFiscal_NFe_infNFe_Emit = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest_N;
		protected SdtSdNotaFiscal_NFe_infNFe_dest gxTv_SdtSdNotaFiscal_NFe_infNFe_Dest = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada_N;
		protected SdtSdNotaFiscal_NFe_infNFe_retirada gxTv_SdtSdNotaFiscal_NFe_infNFe_Retirada = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega_N;
		protected SdtSdNotaFiscal_NFe_infNFe_entrega gxTv_SdtSdNotaFiscal_NFe_infNFe_Entrega = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Det_N;
		protected GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_detItem> gxTv_SdtSdNotaFiscal_NFe_infNFe_Det = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Total_N;
		protected SdtSdNotaFiscal_NFe_infNFe_total gxTv_SdtSdNotaFiscal_NFe_infNFe_Total = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp gxTv_SdtSdNotaFiscal_NFe_infNFe_Transp = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic_N;
		protected SdtSdNotaFiscal_NFe_infNFe_infAdic gxTv_SdtSdNotaFiscal_NFe_infNFe_Infadic = null; 


		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_Id;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_Versao;
		 
		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr_N;
		protected SdtSdNotaFiscal_NFe_infNFe_cobr gxTv_SdtSdNotaFiscal_NFe_infNFe_Cobr = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_RESTInterface( SdtSdNotaFiscal_NFe_infNFe psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ide")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ide", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_ide_RESTInterface gxTpr_Ide
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ide_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_ide_RESTInterface(sdt.gxTpr_Ide);
				else
					return null;

			}

			set {
				sdt.gxTpr_Ide = value.sdt;
			}

		}

		[JsonPropertyName("emit")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="emit", Order=1, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_emit_RESTInterface gxTpr_Emit
		{
			get {
				if (sdt.ShouldSerializegxTpr_Emit_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_emit_RESTInterface(sdt.gxTpr_Emit);
				else
					return null;

			}

			set {
				sdt.gxTpr_Emit = value.sdt;
			}

		}

		[JsonPropertyName("dest")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="dest", Order=2, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_dest_RESTInterface gxTpr_Dest
		{
			get {
				if (sdt.ShouldSerializegxTpr_Dest_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_dest_RESTInterface(sdt.gxTpr_Dest);
				else
					return null;

			}

			set {
				sdt.gxTpr_Dest = value.sdt;
			}

		}

		[JsonPropertyName("retirada")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="retirada", Order=3, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_retirada_RESTInterface gxTpr_Retirada
		{
			get {
				if (sdt.ShouldSerializegxTpr_Retirada_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_retirada_RESTInterface(sdt.gxTpr_Retirada);
				else
					return null;

			}

			set {
				sdt.gxTpr_Retirada = value.sdt;
			}

		}

		[JsonPropertyName("entrega")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="entrega", Order=4, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_entrega_RESTInterface gxTpr_Entrega
		{
			get {
				if (sdt.ShouldSerializegxTpr_Entrega_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_entrega_RESTInterface(sdt.gxTpr_Entrega);
				else
					return null;

			}

			set {
				sdt.gxTpr_Entrega = value.sdt;
			}

		}

		[JsonPropertyName("det")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="det", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdNotaFiscal_NFe_infNFe_detItem_RESTInterface> gxTpr_Det
		{
			get {
				if (sdt.ShouldSerializegxTpr_Det_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdNotaFiscal_NFe_infNFe_detItem_RESTInterface>(sdt.gxTpr_Det);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Det);
			}
		}

		[JsonPropertyName("total")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="total", Order=6, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_total_RESTInterface gxTpr_Total
		{
			get {
				if (sdt.ShouldSerializegxTpr_Total_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_total_RESTInterface(sdt.gxTpr_Total);
				else
					return null;

			}

			set {
				sdt.gxTpr_Total = value.sdt;
			}

		}

		[JsonPropertyName("transp")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="transp", Order=7, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_RESTInterface gxTpr_Transp
		{
			get {
				if (sdt.ShouldSerializegxTpr_Transp_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_RESTInterface(sdt.gxTpr_Transp);
				else
					return null;

			}

			set {
				sdt.gxTpr_Transp = value.sdt;
			}

		}

		[JsonPropertyName("infAdic")]
		[JsonPropertyOrder(8)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="infAdic", Order=8, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_infAdic_RESTInterface gxTpr_Infadic
		{
			get {
				if (sdt.ShouldSerializegxTpr_Infadic_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_infAdic_RESTInterface(sdt.gxTpr_Infadic);
				else
					return null;

			}

			set {
				sdt.gxTpr_Infadic = value.sdt;
			}

		}

		[JsonPropertyName("id")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="id", Order=9)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[JsonPropertyName("versao")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="versao", Order=10)]
		public  string gxTpr_Versao
		{
			get { 
				return sdt.gxTpr_Versao;

			}
			set { 
				 sdt.gxTpr_Versao = value;
			}
		}

		[JsonPropertyName("cobr")]
		[JsonPropertyOrder(11)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="cobr", Order=11, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_cobr_RESTInterface gxTpr_Cobr
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cobr_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_cobr_RESTInterface(sdt.gxTpr_Cobr);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cobr = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe() ;
			}
		}
	}
	#endregion
}