using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eFramework
{
    public class Encrypt
    {
        #region "Staments"
        //Clase que representa los algoritmos simetrico provisto por .net

        static SymmetricAlgorithm symmetricAlgorithm;

        static string keyText = ConfigurationManager.AppSettings["CryptoKey"].ToString();
        #region "VectoresInicialización"
        //Vectores de inicializacion y sal en bytes usados para los cifrados
        static byte[] IV_8 = new byte[] {
        2,
        63,
        9,
        36,
        235,
        174,
        78,
        12};

        static byte[] IV_16 = new byte[] {
        10,
        142,
        4,
        251,
        179,
        203,
        188,
        194,
        28,
        229,
        27,
        56,
        149,
        204,
        236,
        83};

        static byte[] IV_24 = new byte[] {
        37,
        28,
        19,
        44,
        25,
        170,
        122,
        25,
        25,
        57,
        127,
        5,
        22,
        1,
        66,
        65,
        14,
        155,
        224,
        64,
        9,
        77,
        18,
        251};

        static byte[] IV_32 = new byte[] {
        133,
        206,
        56,
        64,
        110,
        158,
        132,
        22,
        99,
        190,
        35,
        129,
        101,
        49,
        204,
        248,
        251,
        243,
        13,
        194,
        160,
        195,
        89,
        152,
        149,
        227,
        245,
        5,
        218,
        86,
        161,
        124};

        static byte[] SALT_BYTES = new byte[] {
        162,
        27,
        98,
        1,
        28,
        239,
        64,
        30,
        156,
        102,
        223};
        #endregion

        #endregion

        #region "Enumerators"
        private enum EnumSymmetricAlgorithm
        {
            AES,
            DES,
            RC2,
            Rijndael,
            TripleDES
        }

        private enum EnumSimmetricKeySize : int
        {
            RC2 = 64,
            DES = 64,
            TripleDES = 192,
            AES = 128,
            AES256 = 256
        }

        #endregion

        #region "Propertys"
        private static string KeyWord
        {
            set { keyText = value; }
        }
        #endregion

        #region "Methods"

        ///// <summary>
        ///// Hashes a text using MD5 algorithm
        ///// </summary>
        ///// <param name="value">text to hash</param>
        ///// <returns>hashed text (Base64String)</returns>
        public static string GetHashMD5(string value)
        {
            UnicodeEncoding Ue = new UnicodeEncoding();
            byte[] ByteSourceText = Ue.GetBytes(value);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            ////obtener el valor del hash value desde el origen (byteSurceText)
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);

            Md5.Clear();
            ////retornarlo como un string
            return Convert.ToBase64String(ByteHash);
        }

        ///// <summary>
        ///// Compares a Hash agains a non hashed value
        ///// </summary>
        ///// <param name="value">value to evaluate</param>
        ///// <param name="hash">hash to evaluate against</param>
        ///// <returns>True if the hash matches</returns>
        public static bool CompareHashMD5(string value, string hash)
        {
            return (hash.Equals(GetHashMD5(value)));
        }

        private static void BuildSymmetricCrypto(EnumSymmetricAlgorithm symmetricAlgorihmType)
        {
            if (keyText == "")
            {
                throw new Exception("Invalid Key Word!");
            }

            //Se selecciona el tipo de algoritmo de cifrado a aplicar
            switch (symmetricAlgorihmType)
            {
                case EnumSymmetricAlgorithm.AES:
                    break;
                //symmetricAlgorithm = New AesCryptoServiceProvider() With {.KeySize = EnumSimmetricKeySize.AES, .IV = IV_16}
                case EnumSymmetricAlgorithm.DES:
                    symmetricAlgorithm = new DESCryptoServiceProvider
                    {
                        KeySize = (int)EnumSimmetricKeySize.DES,
                        IV = IV_8
                    };
                    break;
                case EnumSymmetricAlgorithm.RC2:
                    symmetricAlgorithm = new RC2CryptoServiceProvider
                    {
                        KeySize = (int)EnumSimmetricKeySize.RC2,
                        IV = IV_8
                    };
                    break;
                case EnumSymmetricAlgorithm.Rijndael:
                    symmetricAlgorithm = new RijndaelManaged
                    {
                        KeySize = (int)EnumSimmetricKeySize.AES256,
                        IV = IV_16
                    };
                    break;
                case EnumSymmetricAlgorithm.TripleDES:
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider
                    {
                        KeySize = (int)EnumSimmetricKeySize.TripleDES,
                        IV = IV_8
                    };
                    break;
            }

            var _with1 = symmetricAlgorithm;
            _with1.Key = (new Rfc2898DeriveBytes(keyText, SALT_BYTES, 5)).GetBytes(Convert.ToInt32(_with1.KeySize / 8));
            _with1.Mode = CipherMode.CBC;
        }

        public static string DataEncryption(string KeyWord, string dataDecrypted)
        {
            keyText = KeyWord.Trim();

            return DataEncryption(dataDecrypted);
        }

        public static string DataEncryption(string dataDecrypted)
        {
            if ((dataDecrypted != null))
            {
                BuildSymmetricCrypto(EnumSymmetricAlgorithm.TripleDES);

                //Se lleva a a un array de bytes la informacion a cifrar
                byte[] dataDecryptedBytes = Encoding.UTF8.GetBytes(dataDecrypted.Trim());

                //Realiza el cifrado de la informacion
                byte[] dataEncryptedBytes = symmetricAlgorithm.CreateEncryptor().TransformFinalBlock(dataDecryptedBytes, 0, dataDecryptedBytes.GetLength(0));

                return Convert.ToBase64String(dataEncryptedBytes);
            }
            else
            {
                return null;
            }
        }

        public static string DataDecryption(string KeyWord, string dataEncrypted)
        {
            keyText = KeyWord;

            return DataDecryption(dataEncrypted);
        }

        public static string DataDecryption(string dataEncrypted)
        {
            if ((dataEncrypted != null))
            {
                BuildSymmetricCrypto(EnumSymmetricAlgorithm.TripleDES);

                //Si la longitud del dato cifrado es igual a la longitud máxima - 1, se agrega un espacio al final para 
                if (dataEncrypted.TrimEnd().Length == (symmetricAlgorithm.Key.Length - 1))
                {
                    dataEncrypted = dataEncrypted.TrimEnd() + Strings.Chr(Strings.Asc(dataEncrypted.Substring(dataEncrypted.Length - 1, 1)));
                }
                else
                {
                    dataEncrypted = dataEncrypted.TrimEnd();
                }

                if (dataEncrypted.TrimStart().Length == (symmetricAlgorithm.Key.Length - 1))
                {
                    dataEncrypted = Strings.Chr(Strings.Asc(dataEncrypted.Substring(0, 1))) + dataEncrypted.TrimStart();
                }
                else
                {
                    dataEncrypted = dataEncrypted.TrimStart();
                }

                //Se lleva a a un array de bytes la informacion a cifrar
                byte[] dataEncryptedBytes = Convert.FromBase64String(dataEncrypted);


                //Realiza el descifrado de la informacion
                byte[] dataDecryptedBytes = symmetricAlgorithm.CreateDecryptor().TransformFinalBlock(dataEncryptedBytes, 0, dataEncryptedBytes.GetLength(0));
                return Encoding.UTF8.GetString(dataDecryptedBytes);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
