using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.SocketClient.SyncSocketProtocolCore;
using Module.SocketClient.SyncSocketProtocol;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace Module.SocketClient
{
    class Program
    {
        public static int PacketSize = 32 * 1024;

        static ClientUploadSocket uploadSocket;

        static void Main(string[] args)
        {
            uploadSocket = new ClientUploadSocket();
            uploadSocket.Connect("127.0.0.1", 8888);//192.168.31.120
            Console.WriteLine("Connect Server Success");
            uploadSocket.DoActive();
            uploadSocket.DoLogin("admin", "admin");
            Console.WriteLine("Login Server Success");

            //string fileName = "G:\\LargeGame\\AimxyV111877.exe";// Console.ReadLine();

            //for (int i = 0; i < 3; i++) //发送失败后，尝试3次重发
            //{
            //    if (SendFile(fileName, uploadSocket))
            //    {
            //        Console.WriteLine("Upload File Success");
            //        break;
            //    }
            //    Thread.Sleep(10 * 1000); //发送失败等待10S后重连
            //}

            byte[] buffer = new byte[4096];

            int value = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = byte.Parse(value.ToString());
                value++;
                if (value > 255) value = 0;
            }

            
            Console.WriteLine("start send buffer");

            while (true)
            {
                if (Console.ReadLine()=="A")
                {
                    uploadSocket.DoData(buffer, 0, buffer.Length);
                    Console.WriteLine("success");
                }
                else
                {
                    break;
                }
            }

            Console.ReadKey();
        }

        protected static bool SendFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                try
                {
                    long fileSize = 0;
                    if (!uploadSocket.DoUpload("", Path.GetFileName(fileName), ref fileSize))
                        throw new Exception(uploadSocket.ErrorString);
                    fileStream.Position = fileSize;
                    byte[] readBuffer = new byte[PacketSize];
                    while (fileStream.Position < fileStream.Length)
                    {
                        int count = fileStream.Read(readBuffer, 0, PacketSize);
                        if (!uploadSocket.DoData(readBuffer, 0, count))
                            throw new Exception(uploadSocket.ErrorString);
                    }
                    if (!uploadSocket.DoEof(fileStream.Length))
                        throw new Exception(uploadSocket.ErrorString);
                    return true;
                }
                catch (Exception E)
                {
                    Console.WriteLine("Upload File Error: " + E.Message);
                    return false;
                }
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
