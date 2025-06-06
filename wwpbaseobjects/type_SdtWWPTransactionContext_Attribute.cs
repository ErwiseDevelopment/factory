/*
				   File: type_SdtWWPTransactionContext_Attribute
			Description: Attributes
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
	[XmlRoot(ElementName="WWPTransactionContext.Attribute")]
	[XmlType(TypeName="WWPTransactionContext.Attribute" , Namespace="Factory2" )]
	[Serializable]
	public class SdtWWPTransactionContext_Attribute : GxUserType
	{
		public SdtWWPTransactionContext_Attribute( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPTransactionContext_Attribute_Attributename = "";

			gxTv_SdtWWPTransactionContext_Attribute_Attributevalue = "";

		}

		public SdtWWPTransactionContext_Attribute(IGxContext context)
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
			AddObjectProperty("AttributeName", gxTpr_Attributename, false);


			AddObjectProperty("AttributeValue", gxTpr_Attributevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtWWPTransactionContext_Attribute_Attributename; 
			}
			set {
				gxTv_SdtWWPTransactionContext_Attribute_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="AttributeValue")]
		[XmlElement(ElementName="AttributeValue")]
		public string gxTpr_Attributevalue
		{
			get {
				return gxTv_SdtWWPTransactionContext_Attribute_Attributevalue; 
			}
			set {
				gxTv_SdtWWPTransactionContext_Attribute_Attributevalue = value;
				SetDirty("Attributevalue");
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
			gxTv_SdtWWPTransactionContext_Attribute_Attributename = "";
			gxTv_SdtWWPTransactionContext_Attribute_Attributevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPTransactionContext_Attribute_Attributename;
		 

		protected string gxTv_SdtWWPTransactionContext_Attribute_Attributevalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWPTransactionContext.Attribute", Namespace="Factory2")]
	public class SdtWWPTransactionContext_Attribute_RESTInterface : GxGenericCollectionItem<SdtWWPTransactionContext_Attribute>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPTransactionContext_Attribute_RESTInterface( ) : base()
		{	
		}

		public SdtWWPTransactionContext_Attribute_RESTInterface( SdtWWPTransactionContext_Attribute psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("AttributeName")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="AttributeName", Order=0)]
		public  string gxTpr_Attributename
		{
			get { 
				return sdt.gxTpr_Attributename;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[JsonPropertyName("AttributeValue")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="AttributeValue", Order=1)]
		public  string gxTpr_Attributevalue
		{
			get { 
				return sdt.gxTpr_Attributevalue;

			}
			set { 
				 sdt.gxTpr_Attributevalue = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWWPTransactionContext_Attribute sdt
		{
			get { 
				return (SdtWWPTransactionContext_Attribute)Sdt;
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
				sdt = new SdtWWPTransactionContext_Attribute() ;
			}
		}
	}
	#endregion
}