using System;
using System.Net;
using log4net;
using System.IO;

namespace Module.SocketServer
{
    public class Program
    {
        public static ILog Logger;
        public static AsyncSocketServer m_asyncSocketSvr;
        public static string FileDirectory;

        static void Main(string[] args)
        {
            InitLog4();

            FileDirectory = Directory.GetCurrentDirectory() + "\\Files";
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
                        Send("");
                        break;

                    default:
                        break;
                }
            }
        }

        protected static bool Send(string fileName)
        {
            AsyncSocketUserToken[] asyncSocketUserToken = new AsyncSocketUserToken[1];

            m_asyncSocketSvr.AsyncSocketUserTokenList.CopyList(ref asyncSocketUserToken);



            //FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                try
                {
                    DownloadSocketProtocol download = new DownloadSocketProtocol(m_asyncSocketSvr, asyncSocketUserToken[0]);

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
                //fileStream.Close();
            }
        }

        private static void InitLog4()
        {
            DateTime currentTime = DateTime.Now;
            log4net.GlobalContext.Properties["LogDir"] = currentTime.ToString("yyyyMM");
            log4net.GlobalContext.Properties["LogFileName"] = "_SocketAsyncServer" + currentTime.ToString("yyyyMMdd");

            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log4net.config";
            var fi = new FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(fi);
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Logger.Debug("Log4net init success");
        }
    }
}