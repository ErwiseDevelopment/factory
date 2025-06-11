using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtCarimboPdfModifier : GxUserType, IGxExternalObject
   {
      public SdtCarimboPdfModifier( )
      {
         /* Constructor for serialization */
      }

      public SdtCarimboPdfModifier( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string carimbo( string gxTp_inputFilePath ,
                             string gxTp_outputFilePath ,
                             string gxTp_text )
      {
         string returncarimbo;
         returncarimbo = "";
         returncarimbo = (string)(PdfModifier.Carimbo(gxTp_inputFilePath, gxTp_outputFilePath, gxTp_text));
         return returncarimbo ;
      }

      public Object ExternalInstance
      {
         get {
            if ( CarimboPdfModifier_externalReference == null )
            {
               CarimboPdfModifier_externalReference = new PdfModifier();
            }
            return CarimboPdfModifier_externalReference ;
         }

         set {
            CarimboPdfModifier_externalReference = (PdfModifier)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected PdfModifier CarimboPdfModifier_externalReference=null ;
   }

}
