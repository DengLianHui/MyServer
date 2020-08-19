using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ERP_Demo_WinForm.Tool_Folder
{
    class DesHelper
    {
        readonly string m_key = "poiuytre";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public string Encrypt(string sourceString)
        {
            return Encrypt(sourceString, m_key);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Encrypt(string sourceString, string key)
        {
            byte[] btKey = Encoding.UTF8.GetBytes(key);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inData = Encoding.UTF8.GetBytes(sourceString);

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btKey), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    return sourceString;
                }
            }
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        public string Decrypt(string encryptedString)
        {
            return Decrypt(encryptedString, m_key);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public  string Decrypt(string encryptedString, string key)
        {
            byte[] btKey = Encoding.UTF8.GetBytes(key);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btKey), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    return encryptedString;
                }
            }
        }
    }
}
