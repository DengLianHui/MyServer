﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClient.SyncSocketProtocolCore;

namespace MyClient.SyncSocketProtocol
{
    class ClientUploadSocket : ClientBaseSocket
    {
        public ClientUploadSocket()
            : base()
        {
            m_protocolFlag = MyServer.ProtocolFlag.Upload;
        }

        public bool DoUpload(string dirName, string fileName, ref long fileSize)
        {
            bool bConnect = ReConnectAndLogin(); //检测连接是否还在，如果断开则重连并登录
            if (!bConnect)
                return bConnect;
            try
            {
                m_outgoingDataAssembler.Clear();
                m_outgoingDataAssembler.AddRequest();
                m_outgoingDataAssembler.AddCommand(MyServer.ProtocolKey.Upload);
                m_outgoingDataAssembler.AddValue(MyServer.ProtocolKey.DirName, dirName);
                m_outgoingDataAssembler.AddValue(MyServer.ProtocolKey.FileName, fileName);
                SendCommand();
                bool bSuccess = RecvCommand();
                if (bSuccess)
                {
                    bSuccess = CheckErrorCode();
                    if (bSuccess)
                    {
                        bSuccess = m_incomingDataParser.GetValue(MyServer.ProtocolKey.FileSize, ref fileSize);
                    }
                    return bSuccess;
                }
                else
                    return false;
            }
            catch (Exception E)
            {
                //记录日志
                m_errorString = E.Message;
                return false;
            }
        }

        public bool DoData(byte[] buffer, int offset, int count)
        {
            try
            {
                m_outgoingDataAssembler.Clear();
                m_outgoingDataAssembler.AddRequest();
                m_outgoingDataAssembler.AddCommand(MyServer.ProtocolKey.Data);
                SendCommand(buffer, offset, count);
                return true;
            }
            catch (Exception E)
            {
                //记录日志
                m_errorString = E.Message;
                return false;
            }
        }

        public bool DoEof(Int64 fileSize)
        {
            try
            {
                m_outgoingDataAssembler.Clear();
                m_outgoingDataAssembler.AddRequest();
                m_outgoingDataAssembler.AddCommand(MyServer.ProtocolKey.Eof);
                SendCommand();
                bool bSuccess = RecvCommand();
                if (bSuccess)
                    return CheckErrorCode();
                else
                    return false;
            }
            catch (Exception E)
            {
                //记录日志
                m_errorString = E.Message;
                return false;
            }
        }

        public bool DoPressureTest(byte[] buffer,int offset,int count)
        {
            try
            {
                m_outgoingDataAssembler.Clear();
                m_outgoingDataAssembler.AddRequest();
                m_outgoingDataAssembler.AddCommand(MyServer.ProtocolKey.PressureTest);
                SendCommand(buffer, offset, count);
                return true;
            }
            catch (Exception E)
            {
                //记录日志
                m_errorString = E.Message;
                return false;
            }
        }
    }
}
