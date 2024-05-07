using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EasySockets
{
    public class EasySocket
    {
        public Socket BaseSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public bool isHosting;
        //------------------------------------------------------------------------------------------------------------
        public void Host(string ServerIPAddress, int ServerPort, int MaxPendingConnections)
        {
            BaseSocket.Bind(new IPEndPoint(IPAddress.Parse(ServerIPAddress), ServerPort));
            BaseSocket.Listen(MaxPendingConnections);
            isHosting = true;
        }
        public void Host(IPAddress ServerIPAddress, int ServerPort, int MaxPendingConnections)
        {
            BaseSocket.Bind(new IPEndPoint(ServerIPAddress, ServerPort));
            BaseSocket.Listen(MaxPendingConnections);
            isHosting = true;
        }
        public void Host(IPEndPoint iPEndPoint, int MaxPendingConnections)
        {
            BaseSocket.Bind(iPEndPoint);
            BaseSocket.Listen(MaxPendingConnections);
            isHosting = true;
        }
        public void Host(EndPoint endPoint, int MaxPendingConnections)
        {
            BaseSocket.Bind(endPoint);
            BaseSocket.Listen(MaxPendingConnections);
            isHosting = true;
        }
        //------------------------------------------------------------------------------------------------------------
        public void Accept(Socket ClientSocket)
        {
            ClientSocket = BaseSocket.Accept();
        }
        public void Accept(EasySocket ClientSocket)
        {
            ClientSocket.BaseSocket = BaseSocket.Accept();
        }
        //------------------------------------------------------------------------------------------------------------
        public void Send(byte[] Data)
        {
            Send(Data);
        }
        public void Send(string Data)
        {
            byte[] temp = Encoding.ASCII.GetBytes(Data);
            Send(temp);
        }
        //------------------------------------------------------------------------------------------------------------
        public string ReceiveString(Socket ClientSocket)
        {
            byte[] temp = new byte[1024];
            int clientBytes = ClientSocket.Receive(temp);
            return Encoding.ASCII.GetString(temp, 0, clientBytes);
        }
        public byte[] ReceiveBytes(Socket ClientSocket)
        {
            byte[] temp = new byte[1024];
            return BitConverter.GetBytes(ClientSocket.Receive(temp));
        }
        public string ReceiveString(EasySocket ClientSocket)
        {
            byte[] temp = new byte[1024];
            int clientBytes = ClientSocket.BaseSocket.Receive(temp);
            return Encoding.ASCII.GetString(temp, 0, clientBytes);
        }
        public byte[] ReceiveBytes(EasySocket ClientSocket)
        {
            byte[] temp = new byte[1024];
            return BitConverter.GetBytes(ClientSocket.BaseSocket.Receive(temp));
        }
        //------------------------------------------------------------------------------------------------------------
        public void Close()
        {
            if (isHosting == false)
            {
                BaseSocket.Shutdown(SocketShutdown.Both);
            }
            BaseSocket.Close();
            isHosting = false;
        }
        //------------------------------------------------------------------------------------------------------------
        public void Connect(string ServerIPAddress, int ServerPort)
        {
            BaseSocket.Connect(new IPEndPoint(IPAddress.Parse(ServerIPAddress), ServerPort));
        }
        public void Connect(IPAddress ServerIPAddress, int ServerPort)
        {
            BaseSocket.Connect(new IPEndPoint(ServerIPAddress, ServerPort));
        }
        public void Connect(IPEndPoint iPEndPoint)
        {
            BaseSocket.Connect(iPEndPoint);
        }
        public void Connect(EndPoint endPoint)
        {
            BaseSocket.Connect(endPoint);
        }
    }
}
