using TestingSystems.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace TestingSystems.Helpers
{
    public enum XmlInputType
    {
        XmlString,
        XmlFile
    }

    public class SerializeDeserializeHelper
    {
        #region Serialization methods

        /// <summary>
        /// Serialize class with encryption/ without encryption to a file
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="serializationMethod">Serialization method</param>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        public static void Serialize<T>(Enums.SerializatioDeSerializationMethod serializationMethod, T targetObject, string filePath)
        {
            if (targetObject == null)
                return;

            switch (serializationMethod)
            {
                case Enums.SerializatioDeSerializationMethod.Normal:
                    NormalSerialization(targetObject, filePath);
                    break;

                case Enums.SerializatioDeSerializationMethod.Encrypted:
                    EncryptedSerialization(targetObject, filePath);
                    break;
            }
        }

        /// <summary>
        /// Serialize list of a class to a file
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObjects">List of a class object</param>
        /// <param name="filePath">File path</param>
        /// <param name="prefix">Namespace prefix</param>
        /// <param name="nameSpace">Namespace</param>
        public static void Serialize<T>(List<T> targetObjects, string filePath, string prefix = "", string nameSpace = "")
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(prefix, nameSpace);

                var xmlSerializer = new XmlSerializer(typeof(List<T>));

                xmlSerializer.Serialize(fileStream, targetObjects, xmlSerializerNamespaces);

                fileStream.Close();
            }
        }

        /// <summary>
        /// Serialize class with encryption to a file
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        private static void EncryptedSerialization<T>(T targetObject, string filePath)
        {
            const string strEncrypt = "*#4$%^.++q~!cfr0(_!#$@$!&#&#*&@(7cy9rn8r265&$@&*E^184t44tq2cr9o3r6329";
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            var key = Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));

            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                // Will cause 'Length of the data to encrypt is invalid' exception
                //desCryptoServiceProvider.Padding = PaddingMode.None;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        binaryFormatter.Serialize(cryptoStream, targetObject);
                        cryptoStream.FlushFinalBlock();
                    }
                }
            }
        }

        /// <summary>
        /// Serialize class to a file
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        private static void NormalSerialization<T>(T targetObject, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(fileStream, targetObject);

                fileStream.Close();
            }
        }

        /// <summary>
        /// Serialize class to a file with encryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static bool EncryptedSerialize<T>(T targetObject, string filePath)
        {
            if (targetObject == null)
                return false;

            var keyDetails = GetEncryptionDecryptionKey();

            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (var cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateEncryptor(keyDetails.Item1, keyDetails.Item2), CryptoStreamMode.Write))
                    {
                        new BinaryFormatter().Serialize(cryptoStream, targetObject);
                        cryptoStream.FlushFinalBlock();
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Serialize class to a file without encryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        /// <param name="prefix">Namespace prefix</param>
        /// <param name="nameSpace">Namespace</param>
        public static bool XmlSerialize<T>(T targetObject, string filePath, string prefix = "", string nameSpace = "")
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    var xmlSerializerNamespaces = new XmlSerializerNamespaces();
                    xmlSerializerNamespaces.Add(prefix, nameSpace);

                    new XmlSerializer(typeof(T)).Serialize(fileStream, targetObject, xmlSerializerNamespaces);

                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Serialize list of a class to a file without encryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">List of a class object</param>
        /// <param name="filePath">File path</param>
        /// <param name="prefix">Namespace prefix</param>
        /// <param name="nameSpace">Namespace</param>
        public static bool XmlSerialize<T>(List<T> targetObject, string filePath, string prefix = "", string nameSpace = "")
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    var xmlSerializerNamespaces = new XmlSerializerNamespaces();
                    xmlSerializerNamespaces.Add(prefix, nameSpace);

                    new XmlSerializer(typeof(List<T>)).Serialize(fileStream, targetObject, xmlSerializerNamespaces);

                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Serialize class to a file without encryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">Class object</param>
        /// <param name="filePath">File path</param>
        /// <param name="prefix">Namespace prefix</param>
        /// <param name="nameSpace">Namespace</param>
        public static void BinarySerialize<T>(T targetObject, string filePath, string prefix = "", string nameSpace = "")
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, targetObject);
                fileStream.Close();
            }
        }

        /// <summary>
        /// Serialize list of a class to a file without encryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="targetObject">List of a class object</param>
        /// <param name="filePath">File path</param>
        /// <param name="prefix">Namespace prefix</param>
        /// <param name="nameSpace">Namespace</param>
        public static void BinarySerialize<T>(List<T> targetObject, string filePath, string prefix = "", string nameSpace = "")
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, targetObject);
                fileStream.Close();
            }
        }

        #endregion

        #region De-serialization methods

        public static T Deserialize<T>(Enums.SerializatioDeSerializationMethod deSerializationMethod, Enums.XmlInputType xmlInputType, string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);

            switch (deSerializationMethod)
            {
                case Enums.SerializatioDeSerializationMethod.Normal:
                    return NormalDeSerialization<T>(filePath, xmlInputType);

                case Enums.SerializatioDeSerializationMethod.Encrypted:
                    return EncryptedDeSerialization<T>(filePath);
            }

            return default(T);
        }

        /// <summary>
        /// De-serialize xml string/file to a list of a class object
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="xmlInput">Xml string/path</param>
        /// <param name="xmlInputType">Input type string/file</param>
        /// <returns>List of a class object</returns>
        public static List<T> DeserializeToList<T>(string xmlInput, Enums.XmlInputType xmlInputType)
        {
            switch (xmlInputType)
            {
                case Enums.XmlInputType.XmlString:

                    using (TextReader textReader = new StringReader(xmlInput))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<T>));

                        return (List<T>)xmlSerializer.Deserialize(textReader);
                    }

                case Enums.XmlInputType.XmlFile:

                    if (!File.Exists(xmlInput))
                        return default(List<T>);

                    using (FileStream fileStream = new FileStream(xmlInput, FileMode.Open, FileAccess.Read))
                    {
                        if (fileStream == null || fileStream.Length == 0)
                            return default(List<T>);

                        var xmlSerializer = new XmlSerializer(typeof(T));

                        return (List<T>)xmlSerializer.Deserialize(fileStream);
                    }
            }

            return default(List<T>);
        }

        private static T EncryptedDeSerialization<T>(string filePath)
        {
            T expectedObject = default(T);

            if (!File.Exists(filePath))
                return default(T);

            const string strEncrypt = "*#4$%^.++q~!cfr0(_!#$@$!&#&#*&@(7cy9rn8r265&$@&*E^184t44tq2cr9o3r6329";
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            var key = Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));

            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                // Will cause 'Length of the data to encrypt is invalid' exception
                //desCryptoServiceProvider.Padding = PaddingMode.None;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (fileStream.Length > 0)
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();

                            expectedObject = (T)binaryFormatter.Deserialize(cryptoStream);
                        }
                    }
                }
            }

            return expectedObject;
        }

        /// <summary>
        /// De-serialize xml string/file to a class object
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="xmlInput">Xml string/path</param>
        /// <param name="xmlInputType">Input type string/file</param>
        /// <returns>Class object</returns>                
        private static T NormalDeSerialization<T>(string xmlInput, Enums.XmlInputType xmlInputType)
        {
            switch (xmlInputType)
            {
                case Enums.XmlInputType.XmlString:

                    using (TextReader textReader = new StringReader(xmlInput))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));

                        return (T)xmlSerializer.Deserialize(textReader);
                    }

                case 
                    Enums.XmlInputType.XmlFile:

                    if (!File.Exists(xmlInput)) return default(T);

                    using (FileStream fileStream = new FileStream(xmlInput, FileMode.Open, FileAccess.Read))
                    {
                        if (fileStream == null || fileStream.Length == 0)
                            return default(T);

                        var xmlSerializer = new XmlSerializer(typeof(T));

                        return (T)xmlSerializer.Deserialize(fileStream);
                    }
            }

            return default(T);
        }

        /// <summary>
        /// De-serialize xml string/file to a list of a class object using decryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static T DecryptedDeserialize<T>(string filePath)
        {
            T expectedObject = default(T);

            if (!File.Exists(filePath))
                return default(T);

            var keyDetails = GetEncryptionDecryptionKey();

            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (fileStream.Length > 0)
                    {
                        using (var cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateDecryptor(keyDetails.Item1, keyDetails.Item2), CryptoStreamMode.Read))
                        {
                            expectedObject = (T)(new BinaryFormatter()).Deserialize(cryptoStream);
                        }
                    }
                }
            }

            return expectedObject;
        }

        /// <summary>
        /// De-serialize xml string/file to a list of a class object without decryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="xmlInput">Xml string/path</param>
        /// <param name="xmlInputType">Input type string/file</param>
        /// <returns>List of a class object</returns>
        public static List<T> XmlDeserializeToList<T>(string xmlInput, XmlInputType xmlInputType)
        {
            try
            {
                switch (xmlInputType)
                {
                    case XmlInputType.XmlString:

                        using (TextReader textReader = new StringReader(xmlInput))
                        {
                            var xmlSerializer = new XmlSerializer(typeof(List<T>));

                            return (List<T>)xmlSerializer.Deserialize(textReader);
                        }

                    case XmlInputType.XmlFile:

                        if (!File.Exists(xmlInput))
                            return default(List<T>);

                        using (FileStream fileStream = new FileStream(xmlInput, FileMode.Open, FileAccess.Read))
                        {
                            if (fileStream == null || fileStream.Length == 0)
                                return default(List<T>);

                            var xmlSerializer = new XmlSerializer(typeof(T));

                            return (List<T>)xmlSerializer.Deserialize(fileStream);
                        }
                }

                return default(List<T>);
            }
            catch
            {
                return default(List<T>);
            }
        }

        /// <summary>
        /// De-serialize xml string/file to a class object without decryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="xmlInput">Xml string/path</param>
        /// <param name="xmlInputType">Input type string/file</param>
        /// <returns>Class object</returns>                
        public static T XmlDeserializeToObject<T>(string xmlInput, XmlInputType xmlInputType)
        {
            try
            {
                switch (xmlInputType)
                {
                    case XmlInputType.XmlString:

                        using (var textReader = new StringReader(xmlInput))
                        {
                            var xmlSerializer = new XmlSerializer(typeof(T));

                            return (T)xmlSerializer.Deserialize(textReader);
                        }

                    case XmlInputType.XmlFile:

                        if (!File.Exists(xmlInput))
                            return default(T);

                        using (var fileStream = new FileStream(xmlInput, FileMode.Open, FileAccess.Read))
                        {
                            if (fileStream == null || fileStream.Length == 0)
                                return default(T);

                            var xmlSerializer = new XmlSerializer(typeof(T));

                            return (T)xmlSerializer.Deserialize(fileStream);
                        }
                }

                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// De-serialize xml string/file to a list of a class object without decryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="filePath">Xml string/path</param>
        /// <returns>List of a class object</returns>
        public static List<T> BinaryDeserializeToList<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(List<T>);

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fileStream == null || fileStream.Length == 0)
                    return default(List<T>);

                return (List<T>)new BinaryFormatter().Deserialize(fileStream);
            }
        }

        /// <summary>
        /// De-serialize xml string/file to a class object without decryption
        /// </summary>
        /// <typeparam name="T">Class object type</typeparam>
        /// <param name="filePath">Xml string/path</param>
        /// <returns>Class object</returns>                
        public static T BinaryDeserializeToObject<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fileStream == null || fileStream.Length == 0)
                    return default(T);

                return (T)new BinaryFormatter().Deserialize(fileStream);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get encryption-decryption key
        /// </summary>
        /// <returns></returns>
        private static Tuple<byte[], byte[]> GetEncryptionDecryptionKey()
        {
            const string encryptionDecryptionKey = "*#4$%^.++q~!cfr0(_!#$@$!&#&#*&@(7cy9rn8r265&$@&*E^184t44tq2cr9o3r6329";
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            var key = Encoding.UTF8.GetBytes(encryptionDecryptionKey.Substring(0, 8));

            return Tuple.Create(key, iv);
        }

        #endregion
    }
}
