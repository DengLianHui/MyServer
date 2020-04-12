using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Net;
using System.Linq;
using System.Text;
using System.Diagnostics;
using log4net;
using System.Configuration;
using System.IO;
using System.Net.Sockets;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MyServer
{
    public class Program
    {
        public static ILog Logger;
        public static AsyncSocketServer m_asyncSocketSvr;
        public static string FileDirectory;

        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Now;
            log4net.GlobalContext.Properties["LogDir"] = currentTime.ToString("yyyyMM");
            log4net.GlobalContext.Properties["LogFileName"] = "_SocketAsyncServer" + currentTime.ToString("yyyyMMdd");
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Logger.Debug("START");
            FileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");

            if (!Directory.Exists(FileDirectory)) Directory.CreateDirectory(FileDirectory);

            int port = 8888;
            int numConnections = 8000;
            int socketTimeOutMS = 5 * 60 * 1000;

            m_asyncSocketSvr = new AsyncSocketServer(numConnections);
            m_asyncSocketSvr.SocketTimeOutMS = socketTimeOutMS;
            m_asyncSocketSvr.Init();
            IPEndPoint listenPoint = new IPEndPoint(IPAddress.Parse("192.168.31.120"), port);
            m_asyncSocketSvr.Start(listenPoint);

            Console.WriteLine("Press any key to terminate the server process....");

            bool isAlive = true;

            while (isAlive)
            {
                switch (Console.ReadLine())
                {
                    case "exit":
                        isAlive = false;
                        break;

                    case "send":
                        Send();
                        break;

                    default:
                        break;
                }
            }
        }

        protected static void Send()
        {
            AsyncSocketUserToken[] asyncSocketUserToken=new AsyncSocketUserToken[1];

            m_asyncSocketSvr.AsyncSocketUserTokenList.CopyList(ref asyncSocketUserToken);

            asyncSocketUserToken[0].SendBuffer.ClearPacket(); 
            asyncSocketUserToken[0].SendBuffer.DynamicBufferManager.WriteString("123");
            asyncSocketUserToken[0].SendBuffer.StartPacket();
            asyncSocketUserToken[0].SendBuffer.DynamicBufferManager.WriteString("qwe");
            asyncSocketUserToken[0].SendBuffer.EndPacket();
        }
    }
}