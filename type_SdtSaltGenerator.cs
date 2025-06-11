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
   public class SdtSaltGenerator : GxUserType, IGxExternalObject
   {
      public SdtSaltGenerator( )
      {
         /* Constructor for serialization */
      }

      public SdtSaltGenerator( IGxContext context )
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

      public string generatesecuresalt( int gxTp_length )
      {
         string returngeneratesecuresalt;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         returngeneratesecuresalt = "";
         returngeneratesecuresalt = (string)(SaltGenerator_externalReference.GenerateSecureSalt(gxTp_length));
         return returngeneratesecuresalt ;
      }

      public string generatehexsalt( int gxTp_length )
      {
         string returngeneratehexsalt;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         returngeneratehexsalt = "";
         returngeneratehexsalt = (string)(SaltGenerator_externalReference.GenerateHexSalt(gxTp_length));
         return returngeneratehexsalt ;
      }

      public string generatetimestampedsalt( int gxTp_baseLength )
      {
         string returngeneratetimestampedsalt;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         returngeneratetimestampedsalt = "";
         returngeneratetimestampedsalt = (string)(SaltGenerator_externalReference.GenerateTimestampedSalt(gxTp_baseLength));
         return returngeneratetimestampedsalt ;
      }

      public string generatecustomsalt( int gxTp_length ,
                                        bool gxTp_useUppercase ,
                                        bool gxTp_useLowercase ,
                                        bool gxTp_useNumbers ,
                                        bool gxTp_useSpecialChars )
      {
         string returngeneratecustomsalt;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         returngeneratecustomsalt = "";
         returngeneratecustomsalt = (string)(SaltGenerator_externalReference.GenerateCustomSalt(gxTp_length, gxTp_useUppercase, gxTp_useLowercase, gxTp_useNumbers, gxTp_useSpecialChars));
         return returngeneratecustomsalt ;
      }

      public bool validatesaltentropy( string gxTp_salt )
      {
         bool returnvalidatesaltentropy;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         returnvalidatesaltentropy = false;
         returnvalidatesaltentropy = (bool)(SaltGenerator_externalReference.ValidateSaltEntropy(gxTp_salt));
         return returnvalidatesaltentropy ;
      }

      public object generatemultiplesalts( int gxTp_count ,
                                           int gxTp_length )
      {
         object returngeneratemultiplesalts;
         if ( SaltGenerator_externalReference == null )
         {
            SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
         }
         System.String[] externalParm0;
         externalParm0 = SaltGenerator_externalReference.GenerateMultipleSalts(gxTp_count, gxTp_length);
         returngeneratemultiplesalts = (object)(externalParm0);
         return returngeneratemultiplesalts ;
      }

      public Object ExternalInstance
      {
         get {
            if ( SaltGenerator_externalReference == null )
            {
               SaltGenerator_externalReference = new SecurityUtils.SaltGenerator();
            }
            return SaltGenerator_externalReference ;
         }

         set {
            SaltGenerator_externalReference = (SecurityUtils.SaltGenerator)(value);
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

      protected SecurityUtils.SaltGenerator SaltGenerator_externalReference=null ;
   }

}
