using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module.SocketClient.SyncSocketProtocolCore;

namespace Module.SocketClient.SyncSocketProtocol
{
    class ClientSqlSocket : ClientBaseSocket
    {
        public ClientSqlSocket() :
            base()
        {
            m_protocolFlag = Module.SocketServer.ProtocolFlag.SQL;
        }


        
    }
}
