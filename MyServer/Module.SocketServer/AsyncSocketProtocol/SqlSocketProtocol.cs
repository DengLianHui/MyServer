using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module.SocketServer
{
    class SqlSocketProtocol : BaseSocketProtocol
    {
        public SqlSocketProtocol(AsyncSocketServer asyncSocketServer, AsyncSocketUserToken asyncSocketUserToken)
            : base(asyncSocketServer, asyncSocketUserToken)
        {
            m_socketFlag = "SQL";
        }

        public override bool ProcessCommand(byte[] buffer, int offset, int count)
        {
            return base.ProcessCommand(buffer, offset, count);
        }
    }
}
