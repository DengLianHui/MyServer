using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using System.Data.Common;

namespace ERP_Demo_WinForm.Tool_Folder
{
    class ChangeHelper
    {
        /// <summary> 
        /// 将一个object对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        public byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// 将一个序列化后的byte[]数组还原       
        /// </summary>
        /// <param name="Bytes"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object BytesToObject(byte[] Bytes, int index, int count)
        {
            using (MemoryStream ms = new MemoryStream(Bytes, index, count))
            {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(ms);
            }
        }

        /// <summary> 
        /// 将一个序列化后的byte[]数组还原         
        /// </summary>
        /// <param name="Bytes"></param>         
        /// <returns></returns> 
        public object BytesToObject(byte[] Bytes)
        {
            return BytesToObject(Bytes, 0, Bytes.Length);
        }

        /// <summary>
        /// 对象到文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ObjectToFile(object obj, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            byte[] vs = ObjectToBytes(obj);
            fileStream.Write(vs, 0, vs.Length);
            fileStream.Close();

            return true;
        }

        /// <summary>
        /// 文件到对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public object FileToObject(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);

            byte[] buffer = new byte[1024 * 1024];

            int count = fileStream.Read(buffer, 0, buffer.Length);

            fileStream.Close();

            return BytesToObject(buffer, 0, count);
        }
    }
}
