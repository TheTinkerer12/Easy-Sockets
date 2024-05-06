**This library was made and built using .NET version 8**\\

A C# library making it easier to work with sockets.\
This library adds some a new class called EasySocket, which gives you some extra functions to more easily work with sockets.\
In the EasySocket class, there is a public variable called BaseSocket, which is the socket the class uses to do everything.\\

Functions and uses:\\

Host(string IPAddress, int Port, int MaxPendingConnections) starts a server and listens for connections\
Accept(Socket ClientSocket) accepts a connection\
Send(Socket ClientSocket, string Data) sends data through a socket\
ReceiveString(Socket ClientSocket) receives a string that was sent\
ReceiveBytes(Socket ClientSocket) receives a byte array that was sent\
Close() shuts down a socket connection\
Connect(string IPAddress, Port) connects a client to a server\\\\


Example for host:\\

using EasySockets;\
EasySocket serverSocket = new EasySocket();\
serverSocket.Host("127.0.0.1", 8000, 5);\
Console.WriteLine("Listening for connections...");\
EasySocket ClientSocket = new EasySocket();\
serverSocket.Accept(ClientSocket);\
Console.WriteLine("Client Connected!");\
ClientSocket.Send(ClientSocket, "Hello");\
Console.WriteLine(ClientSocket.ReceiveString(ClientSocket));\
serverSocket.Close();\


Example for client:\\

ClientSocket.Connect("127.0.0.1, 8000);\
Console.WriteLine("Connected to server!");\
ClientSocket.Send(ClientSocket, "Hello");\
Console.WriteLine(ClientSocket.ReceiveString(ClientSocket));\
ClientSocket.Close();
