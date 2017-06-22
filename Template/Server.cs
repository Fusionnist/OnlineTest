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
        Socket socket = null;

        public Server(String host)
        {
            socket = IO.Socket(host);
        }

        public void setSocket(Socket socket)
        {
            this.socket = socket;
        }

        public Socket getSocket()
        {
            return socket;
        }
    }
}
