using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyClient.SyncSocketProtocolCore;

namespace MyClient.SyncSocketProtocol
{
    class ClientSqlSocket : ClientBaseSocket
    {
        public ClientSqlSocket() :
            base()
        {
            m_protocolFlag = MyServer.ProtocolFlag.SQL;
        }


        
    }
}
