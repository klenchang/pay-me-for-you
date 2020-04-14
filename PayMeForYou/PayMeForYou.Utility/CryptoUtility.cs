using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace PayMeForYou.Utility
{
    public static class CryptoUtility
    {
        public static class RSA
        {
            #region key converter
            /// <summary>
            /// convert public key format from pkcs#8 to xml
            /// </summary>
            /// <param name="pkcs8PublicKey">public key with pkcs#8</param>
            /// <returns></returns>
            public static string ConvertPublicKeyFromPKCS8ToXml(string pkcs8PublicKey)
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(pkcs8PublicKey));
                return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                    Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                    Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
            }
            /// <summary>
            /// convert private key format from pkcs#8 to xml
            /// </summary>
            /// <param name="pkcs8PrivateKey">private key with pkcs#8</param>
            /// <returns></returns>
            public static string ConvertPrivateKeyFromPKCS8ToXml(string pkcs8PrivateKey)
            {
                RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(pkcs8PrivateKey));
                return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                    Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
            }
            /// <summary>
            /// convert public key format from xml to pkcs#8
            /// </summary>
            /// <param name="xmlPublicKey">public key with xml format</param>
            /// <returns></returns>
            public static string ConvertPublicKeyFromXmlToPKCS8(string xmlPublicKey)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlPublicKey);
                BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
                BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
                RsaKeyParameters pub = new RsaKeyParameters(false, m, p);

                SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pub);
                byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
                return Convert.ToBase64String(serializedPublicBytes);
            }
            /// <summary>
            /// convert private key format from pkcs#8 to xml
            /// </summary>
            /// <param name="xmlPrivateKey">private key with xml format</param>
            /// <returns></returns>
            public static string ConvertPrivateKeyFromXmlToPKCS8(string xmlPrivateKey)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlPrivateKey);
                BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
                BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
                BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
                BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
                BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
                BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
                BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
                BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));

                RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);

                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
                byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
                return Convert.ToBase64String(serializedPrivateBytes);
            }
            #endregion

            /// <summary>
            /// verify data with sign
            /// </summary>
            /// <param name="dataBytes">byte array of source data</param>
            /// <param name="sign">signature</param>
            /// <param name="xmlKey">private key or public key with xml format</param>
            /// <param name="halg">hash algorithm</param>
            /// <returns></returns>
            public static bool VerifyData(byte[] dataBytes, string sign, string xmlKey, object halg = null)
            {
                if (halg == null) halg = new SHA1CryptoServiceProvider();
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlKey);
                    var signBytes = Convert.FromBase64String(sign);
                    return rsa.VerifyData(dataBytes, halg, signBytes);
                }
            }
            /// <summary>
            /// get rsa sign base64 string
            /// </summary>
            /// <param name="dataBytes">byte array of source data</param>
            /// <param name="xmlPrivateKey">private key with xml format</param>
            /// <param name="halg">hash algorithm</param>
            /// <returns></returns>
            public static string GetSign(byte[] dataBytes, string xmlPrivateKey, object halg = null)
            {
                if (halg == null) halg = new SHA1CryptoServiceProvider();
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlPrivateKey);
                    var encryptedData = rsa.SignData(dataBytes, halg);

                    return Convert.ToBase64String(encryptedData);
                }
            }

            #region pkcs8 key
            /// <summary>
            /// encrypt data to base64 string with pkcs#8 key
            /// </summary>
            /// <param name="data">source data</param>
            /// <param name="pkcs8Key">private key or public key with pkcs#8 format</param>
            /// <param name="isPublicKey">true:key is publickey ; false:key is privatekey</param>
            /// <param name="encodingName">encoding name</param>
            /// <returns></returns>
            public static string EncryptDataWithPKCS8Key(string data, string pkcs8Key, bool isPublicKey, string encodingName = "utf-8")
            {
                var dataBytes = Encoding.GetEncoding(encodingName).GetBytes(data);
                var resultBytes = EncryptDataToByteArrayWithPKCS8Key(dataBytes, pkcs8Key, isPublicKey);

                return Convert.ToBase64String(resultBytes);
            }
            /// <summary>
            /// decrypt base64 data with pkcs#8 key
            /// </summary>
            /// <param name="encryptedData">encrypted data</param>
            /// <param name="pkcs8Key">private key or public key with pkcs#8 format</param>
            /// <param name="isPublicKey">true:key is publickey ; false:key is privatekey</param>
            /// <param name="encodingName">encoding name</param>
            /// <returns></returns>
            public static string DecryptDataWithPKCS8Key(string encryptedData, string pkcs8Key, bool isPublicKey, string encodingName = "utf-8")
            {
                var dataBytes = Convert.FromBase64String(encryptedData);
                var resultBytes = DecryptDataFromByteArrayWithPKCS8Key(dataBytes, pkcs8Key, isPublicKey);

                return Encoding.GetEncoding(encodingName).GetString(resultBytes);
            }
            /// <summary>
            /// encrypt byte array data with pkcs#8 key
            /// </summary>
            /// <param name="data">source data</param>
            /// <param name="pkcs8Key">private key or public key with pkcs#8 format</param>
            /// <param name="isPublicKey">true:key is publickey ; false:key is privatekey</param>
            /// <returns></returns>
            public static byte[] EncryptDataToByteArrayWithPKCS8Key(byte[] data, string pkcs8Key, bool isPublicKey) => HandleByteArrayWithPKCS8Key(data, pkcs8Key, isPublicKey, true);
            /// <summary>
            /// decrypt byte array data with pkcs#8 key
            /// </summary>
            /// <param name="encryptedData">encrypted data with byte array format</param>
            /// <param name="pkcs8Key">private key or public key with pkcs#8 format</param>
            /// <param name="isPublicKey">true:key is publickey ; false:key is privatekey</param>
            /// <returns></returns>
            public static byte[] DecryptDataFromByteArrayWithPKCS8Key(byte[] encryptedData, string pkcs8Key, bool isPublicKey) => HandleByteArrayWithPKCS8Key(encryptedData, pkcs8Key, isPublicKey, false);
            /// <summary>
            /// encrypted or decrypted byte array data with pkcs#8 key
            /// </summary>
            /// <param name="data">source data</param>
            /// <param name="pkcs8Key">private key or public key with pkcs#8 format</param>
            /// <param name="isPublicKey">true:key is publickey ; false:key is privatekey</param>
            /// <param name="forEncryption">true: for encrypt ; false: for decrypt</param>
            /// <returns></returns>
            private static byte[] HandleByteArrayWithPKCS8Key(byte[] data, string pkcs8Key, bool isPublicKey, bool forEncryption)
            {
                RsaKeyParameters param = null;
                if (isPublicKey)
                    param = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(pkcs8Key));
                else
                    param = (RsaKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(pkcs8Key));

                //if you don't want to use padding mode, you can just declare [var rsa = new RsaEngine()]
                //if you want to use OAEP, you can declare [var rsa = new OaepEncoding(new RsaEngine())]
                var rsa = new Pkcs1Encoding(new RsaEngine());
                rsa.Init(forEncryption, param);

                return rsa.ProcessBlock(data, 0, data.Length);
            }
            #endregion

            #region xml key
            /// <summary>
            /// To divide whole data into several parts with specific block size, then encrypt each part
            /// </summary>
            /// <param name="data">source data</param>
            /// <param name="xmlKey">private key or public key with xml format</param>
            /// <param name="blockSize">block size</param>
            /// <param name="encodingName">encoding name</param>
            /// <returns></returns>
            public static string EncryptDataWithXmlKey(string data, string xmlKey, int blockSize = 0, string encodingName = "utf-8")
            {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlKey);
                    var dataBytes = Encoding.GetEncoding(encodingName).GetBytes(data);
                    var maxBlockSize = (rsa.KeySize / 8);
                    int bufferSize = ((blockSize == 0 || blockSize > maxBlockSize) ? maxBlockSize : blockSize) - 11;   //default is PKCS1Padding, padding size is 11
                    var buffer = new byte[bufferSize];
                    using (MemoryStream inputStream = new MemoryStream(dataBytes), outputStream = new MemoryStream())
                    {
                        while (true)
                        {
                            int readSize = inputStream.Read(buffer, 0, bufferSize);
                            if (readSize <= 0) break;

                            var tempBlock = new byte[readSize];
                            Array.Copy(buffer, 0, tempBlock, 0, readSize);
                            var encryptedBytes = rsa.Encrypt(tempBlock, false);
                            outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        }
                        return Convert.ToBase64String(outputStream.ToArray());
                    }
                }
            }
            /// <summary>
            /// To divide whole encrypted data into several parts, then decrypt each part. block size is key size.
            /// </summary>
            /// <param name="encryptedData">encrypted data</param>
            /// <param name="xmlPrivateKey">private key with xml format</param>
            /// <param name="encodingName">encoding name</param>
            /// <returns></returns>
            public static string DecryptDataWithXmlPrivateKey(string encryptedData, string xmlPrivateKey, string encodingName = "utf-8")
            {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlPrivateKey);
                    var dataBytes = Convert.FromBase64String(encryptedData);
                    int bufferSize = rsa.KeySize / 8;
                    var buffer = new byte[bufferSize];
                    using (MemoryStream inputStream = new MemoryStream(dataBytes), outputStream = new MemoryStream())
                    {
                        while (true)
                        {
                            int readSize = inputStream.Read(buffer, 0, bufferSize);
                            if (readSize <= 0) break;

                            var tempBlock = new byte[readSize];
                            Array.Copy(buffer, 0, tempBlock, 0, readSize);
                            var decryptedBytes = rsa.Decrypt(tempBlock, false);
                            outputStream.Write(decryptedBytes, 0, decryptedBytes.Length);
                        }
                        return Encoding.GetEncoding(encodingName).GetString(outputStream.ToArray());
                    }
                }
            }
            #endregion
        }
        public static class AES
        {
            public static string EncryptToHexString(string data, string key, Encoding encoding, string iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, int blockSize = 128)
            {
                var bData = encoding.GetBytes(data);
                var result = Encrypt(bData, key, encoding, cipherMode, paddingMode, blockSize, iv);
                return string.Join("", result.Select(b => b.ToString("x2")));
            }
            public static string DecryptFromHexString(string data, string key, Encoding encoding, string iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, int blockSize = 128)
            {
                var bData = Enumerable.Range(0, data.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(data.Substring(x, 2), 16)).ToArray();
                return encoding.GetString(Decrypt(bData, key, encoding, cipherMode, paddingMode, blockSize, iv));
            }
            public static string EncryptToBase64String(string data, string key, Encoding encoding, string iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, int blockSize = 128)
            {
                var bData = encoding.GetBytes(data);
                var result = Encrypt(bData, key, encoding, cipherMode, paddingMode, blockSize, iv);
                return Convert.ToBase64String(result);
            }
            public static string DecryptFromBase64String(string data, string key, Encoding encoding, string iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, int blockSize = 128)
            {
                var bData = Convert.FromBase64String(data);
                return encoding.GetString(Decrypt(bData, key, encoding, cipherMode, paddingMode, blockSize, iv));
            }
            private static byte[] Encrypt(byte[] data, string key, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode, int blockSize, string iv = null)
            {
                //after testing, key size will be set up automatically while you fill in key
                //note! some mode, such as ECB, will generate different result each time if you set up key size after key
                //but ECB should return same result each time 
                //so this function will not allow user to set up key size
                var aes = new RijndaelManaged
                {
                    Key = encoding.GetBytes(key),
                    Mode = cipherMode,
                    Padding = paddingMode,
                    BlockSize = blockSize
                };
                if (iv != null)
                    aes.IV = encoding.GetBytes(iv);

                return aes.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
            }
            private static byte[] Decrypt(byte[] data, string key, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode, int blockSize, string iv = null)
            {
                //after testing, key size will be set up automatically while you fill in key
                //and note! if key size is set up after key, TransformFinalBlock will throw a exception
                //so this function will not allow user to set up key size
                var aes = new RijndaelManaged
                {
                    Key = encoding.GetBytes(key),
                    Mode = cipherMode,
                    Padding = paddingMode,
                    BlockSize = blockSize
                };
                if (iv != null)
                    aes.IV = encoding.GetBytes(iv);

                return aes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
            }
        }
        public static class MD5
        {
            public static string EncryptToMD5Hash(string data) => EncryptToMD5Hash(data, Encoding.UTF8);
            public static string EncryptToMD5Hash(string data, Encoding encoding)
            {
                using (var hashAlgorithm = System.Security.Cryptography.MD5.Create())
                    return Encrypt(data, encoding, hashAlgorithm);
            }
            public static string EncryptToHmacMD5Hash(string data, Encoding encoding, string key)
            {
                using (var hashAlgorithm = new HMACMD5(encoding.GetBytes(key)))
                    return Encrypt(data, encoding, hashAlgorithm);
            }
            private static string Encrypt<T>(string data, Encoding encoding, T hashAlgorithm) where T : HashAlgorithm
            {
                var sBuilder = new StringBuilder();
                using (var md5Hash = hashAlgorithm)
                {
                    var byteData = md5Hash.ComputeHash(encoding.GetBytes(data));
                    for (int i = 0; i < byteData.Length; i++)
                        sBuilder.Append(byteData[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public static class SHA
        {
            public static string EncryptToBitByHmacSHA1(string data, string key, Encoding encoding)
            {
                using (var hmac = new HMACSHA1(encoding.GetBytes(key)))
                    return ToBit(Encrypt(data, encoding, hmac));
            }
            public static string EncryptToBitByHmacSHA256(string data, string key, Encoding encoding)
            {
                using (var hmac = new HMACSHA256(encoding.GetBytes(key)))
                    return ToBit(Encrypt(data, encoding, hmac));
            }
            public static string EncryptToBase64ByHmacSHA1(string data, string key, Encoding encoding)
            {
                using (var hmac = new HMACSHA1(encoding.GetBytes(key)))
                    return ToBase64(Encrypt(data, encoding, hmac));
            }
            public static string EncryptToBase64ByHmacSHA256(string data, string key, Encoding encoding)
            {
                using (var hmac = new HMACSHA256(encoding.GetBytes(key)))
                    return ToBase64(Encrypt(data, encoding, hmac));
            }
            private static byte[] Encrypt<T>(string data, Encoding encoding, T hashAlgorithm) where T : HashAlgorithm => hashAlgorithm.ComputeHash(encoding.GetBytes(data));
            private static string ToBit(byte[] byteData) => BitConverter.ToString(byteData).Replace("-", "").ToLower();
            private static string ToBase64(byte[] byteData) => Convert.ToBase64String(byteData);
        }
    }
}
