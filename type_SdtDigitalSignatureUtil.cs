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
   public class SdtDigitalSignatureUtil : GxUserType, IGxExternalObject
   {
      public SdtDigitalSignatureUtil( )
      {
         /* Constructor for serialization */
      }

      public SdtDigitalSignatureUtil( IGxContext context )
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

      public string addsignature( string gxTp_pathSource ,
                                  string gxTp_pathTarget ,
                                  string gxTp_certPath ,
                                  string gxTp_certPass ,
                                  int gxTp_lx ,
                                  int gxTp_ly ,
                                  int gxTp_ux ,
                                  int gxTp_uy ,
                                  int gxTp_page ,
                                  bool gxTp_visible )
      {
         string returnaddsignature;
         if ( DigitalSignatureUtil_externalReference == null )
         {
            DigitalSignatureUtil_externalReference = new DigitalSignatureLibrary.DigitalSignatureUtil();
         }
         returnaddsignature = "";
         returnaddsignature = (string)(DigitalSignatureUtil_externalReference.AddSignature(gxTp_pathSource, gxTp_pathTarget, gxTp_certPath, gxTp_certPass, gxTp_lx, gxTp_ly, gxTp_ux, gxTp_uy, gxTp_page, gxTp_visible));
         return returnaddsignature ;
      }

      public string addsignature1( string gxTp_pathSource ,
                                   string gxTp_pathTarget ,
                                   string gxTp_certPath ,
                                   string gxTp_certPass ,
                                   bool gxTp_visible )
      {
         string returnaddsignature1;
         if ( DigitalSignatureUtil_externalReference == null )
         {
            DigitalSignatureUtil_externalReference = new DigitalSignatureLibrary.DigitalSignatureUtil();
         }
         returnaddsignature1 = "";
         returnaddsignature1 = (string)(DigitalSignatureUtil_externalReference.AddSignature(gxTp_pathSource, gxTp_pathTarget, gxTp_certPath, gxTp_certPass, gxTp_visible));
         return returnaddsignature1 ;
      }

      public Object ExternalInstance
      {
         get {
            if ( DigitalSignatureUtil_externalReference == null )
            {
               DigitalSignatureUtil_externalReference = new DigitalSignatureLibrary.DigitalSignatureUtil();
            }
            return DigitalSignatureUtil_externalReference ;
         }

         set {
            DigitalSignatureUtil_externalReference = (DigitalSignatureLibrary.DigitalSignatureUtil)(value);
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

      protected DigitalSignatureLibrary.DigitalSignatureUtil DigitalSignatureUtil_externalReference=null ;
   }

}
