using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace ChatServer
{
    public class ChatServer
    {
        public static Hashtable userTable = new Hashtable(30);
        public static Hashtable connectionTable = new Hashtable(30);
        private IPAddress ipAddress;
        private TcpClient tcpClient;
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;
        private Thread listenerThread;
        private TcpListener tcpListener;
        bool serverRunning = false;

        public ChatServer(IPAddress address)
        {
            try
            {
                ipAddress = address;
            }
            catch (Exception)
            { }
        }

        public static void AddUser(TcpClient tcpUser, string userName)
        {
            try
            {
                ChatServer.userTable.Add(userName, tcpUser);
                ChatServer.connectionTable.Add(tcpUser, userName);
                SendAdminMessage(connectionTable[tcpUser] + "  joined");
            }
            catch (Exception)
            { }
        }

        public static void RemoveUser(TcpClient tcpUser)
        {
            try
            {
                if (connectionTable[tcpUser] != null)
                {
                    SendAdminMessage(connectionTable[tcpUser] + "  left");
                    ChatServer.userTable.Remove(ChatServer.connectionTable[tcpUser]);
                    ChatServer.connectionTable.Remove(tcpUser);
                }
            }
            catch (Exception)
            { }
        }

        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            try
            {
                StatusChangedEventHandler statusHandler = StatusChanged;
                if (statusHandler != null)
                {
                    statusHandler(null, e);
                }
            }
            catch (Exception)
            { }
        }

        public static void SendAdminMessage(string message)
        {
            try
            {
                string from = "Admin";
                SendMessage(from, message);
            }
            catch (Exception)
            { }
        }

        public static void SendMessage(string from, string message)
        {
            StreamWriter swSender;
            e = new StatusChangedEventArgs(from + ":  " + message);
            OnStatusChanged(e);
            TcpClient[] tcpClients = new TcpClient[ChatServer.userTable.Count];
            ChatServer.userTable.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    if (message.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    swSender = new StreamWriter(tcpClients[i].GetStream());
                    swSender.WriteLine(from + ":  " + message);
                    swSender.Flush();
                    swSender = null;
                }
                catch (Exception)
                {
                    RemoveUser(tcpClients[i]);
                }
            }
        }

        public void StartListening()
        {
            try
            {
                IPAddress ipLocal = ipAddress;
                tcpListener = new TcpListener(ipLocal, 1986);
                tcpListener.Start();
                serverRunning = true;
                listenerThread = new Thread(KeepListening);
                listenerThread.Start();
            }
            catch (Exception)
            { }
        }

        public void KeepListening()
        {
            try
            {
                while (serverRunning)
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    Connection newConnection = new Connection(tcpClient);
                }
            }
            catch (Exception)
            { }
        }
    }

    public class StatusChangedEventArgs : EventArgs
    {
        public string EventMessage { get; set; }
        public StatusChangedEventArgs(string eventmessage)
        {
            EventMessage = eventmessage;
        }
    }
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    class Connection
    {
        TcpClient tcpClient;
        private Thread senderThread;
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private string currentUser;
        private string response;

        public Connection(TcpClient client)
        {
            try
            {
                tcpClient = client;
                senderThread = new Thread(AcceptClient);
                senderThread.Start();
            }
            catch (Exception)
            { }
        }

        private void CloseConnection()
        {
            try
            {
                tcpClient.Close();
                swSender.Close();
                srReceiver.Close();
            }
            catch (Exception)
            { }
        }

        private void AcceptClient()
        {
            try
            {
                swSender = new StreamWriter(tcpClient.GetStream());
                srReceiver = new StreamReader(tcpClient.GetStream());
                currentUser = srReceiver.ReadLine();
                if (!string.IsNullOrEmpty(currentUser))
                {
                    if (ChatServer.userTable.Contains(currentUser))
                    {
                        swSender.WriteLine("0|Username already exists");
                        swSender.Flush();
                        CloseConnection();
                        return;
                    }
                    else if (currentUser.ToLower() == "admin")
                    {
                        swSender.WriteLine("0|Username is reserved");
                        swSender.Flush();
                        CloseConnection();
                        return;
                    }
                    else
                    {
                        swSender.WriteLine("1");
                        swSender.Flush();
                        ChatServer.AddUser(tcpClient, currentUser);
                    }
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            catch (Exception)
            { }
            try
            {
                while ((response = srReceiver.ReadLine()) != "")
                {
                    if (response == null)
                    {
                        ChatServer.RemoveUser(tcpClient);
                    }
                    else
                    {
                        ChatServer.SendMessage(currentUser, response);
                    }
                }
            }
            catch
            {
                ChatServer.RemoveUser(tcpClient);
            }
        }
    }
}
