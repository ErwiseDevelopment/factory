/*
				   File: type_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem
			Description: SecFunctionalityKeys
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="SecFunctionalitiesToLoad.SecFunctionalityKeysItem")]
	[XmlType(TypeName="SecFunctionalitiesToLoad.SecFunctionalityKeysItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem : GxUserType
	{
		public SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitykey = "";

			gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitydsc = "";

		}

		public SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem(IGxContext context)
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
			AddObjectProperty("SecFunctionalityKey", gxTpr_Secfunctionalitykey, false);


			AddObjectProperty("SecFunctionalityDsc", gxTpr_Secfunctionalitydsc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecFunctionalityKey")]
		[XmlElement(ElementName="SecFunctionalityKey")]
		public string gxTpr_Secfunctionalitykey
		{
			get {
				return gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitykey; 
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitykey = value;
				SetDirty("Secfunctionalitykey");
			}
		}




		[SoapElement(ElementName="SecFunctionalityDsc")]
		[XmlElement(ElementName="SecFunctionalityDsc")]
		public string gxTpr_Secfunctionalitydsc
		{
			get {
				return gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitydsc; 
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitydsc = value;
				SetDirty("Secfunctionalitydsc");
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
			gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitykey = "";
			gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitydsc = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitykey;
		 

		protected string gxTv_SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_Secfunctionalitydsc;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SecFunctionalitiesToLoad.SecFunctionalityKeysItem", Namespace="Factory21")]
	public class SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_RESTInterface : GxGenericCollectionItem<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_RESTInterface( ) : base()
		{	
		}

		public SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_RESTInterface( SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("SecFunctionalityKey")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="SecFunctionalityKey", Order=0)]
		public  string gxTpr_Secfunctionalitykey
		{
			get { 
				return sdt.gxTpr_Secfunctionalitykey;

			}
			set { 
				 sdt.gxTpr_Secfunctionalitykey = value;
			}
		}

		[JsonPropertyName("SecFunctionalityDsc")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="SecFunctionalityDsc", Order=1)]
		public  string gxTpr_Secfunctionalitydsc
		{
			get { 
				return sdt.gxTpr_Secfunctionalitydsc;

			}
			set { 
				 sdt.gxTpr_Secfunctionalitydsc = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem sdt
		{
			get { 
				return (SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem)Sdt;
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
				sdt = new SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem() ;
			}
		}
	}
	#endregion
}