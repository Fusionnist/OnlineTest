using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quobject.SocketIoClientDotNet.Client;

namespace Template
{
    class Server
    {
        Socket _socket = null;

        public Server(String host)
        {
            _socket = IO.Socket(host);
        }

        public Socket Socket { get; set; }
    }
}
