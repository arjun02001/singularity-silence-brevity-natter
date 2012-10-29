using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace NatterCWindowsFormsApplication
{
    public partial class NatterForm : Form
    {
        private string userName = string.Empty;
        private TcpClient tcpServer;
        private StreamReader srRecieve;
        private StreamWriter swSender;
        private delegate void UpdateLogCallback(string message);
        private delegate void CloseConnectionCallback(string reason);
        private Thread threadMessaging;
        private IPAddress ipAddress;
        private bool connected;
        public NatterForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }
        void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    connected = false;
                    swSender.Close();
                    srRecieve.Close();
                    tcpServer.Close();
                }
            }
            catch (Exception)
            { }
        }
        private void InitializeConnection()
        {
            try
            {
                ipAddress = IPAddress.Parse(ipAddressTextBox.Text);
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddress, 1986);
                connected = true;
                userName = userTextBox.Text;
                ipAddressTextBox.Enabled = false;
                userTextBox.Enabled = false;
                sendTextBox.Enabled = true;
                sendButton.Enabled = true;
                connectButton.Text = "Disconnect";
                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine(userTextBox.Text);
                swSender.Flush();
                threadMessaging = new Thread(new ThreadStart(RecieveMessages));
                threadMessaging.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("CONNECTION NOT ESTABILISHED");
            }
        }
        private void CloseConnection(string reason)
        {
            try
            {
                clientLogTextBox.AppendText(reason + "\r\n");
                ipAddressTextBox.Enabled = true;
                userTextBox.Enabled = true;
                sendTextBox.Enabled = false;
                sendButton.Enabled = false;
                connectButton.Text = "Connect";
                connected = false;
                swSender.Close();
                srRecieve.Close();
                tcpServer.Close();
            }
            catch (Exception)
            {
            }
        }
        private void RecieveMessages()
        {
            try
            {
                srRecieve = new StreamReader(tcpServer.GetStream());
                string conResponse = srRecieve.ReadLine();
                if (conResponse[0] == '1')
                {
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected" });
                }
                else
                {
                    string reason = "Not Connected.";
                    reason += conResponse.Substring(2, conResponse.Length - 2);
                    this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { reason });
                }
                while (connected)
                {
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] {"\n"+ srRecieve.ReadLine() });
                }
            }
            catch (Exception)
            {
            }
       }
        private void SendMessage()
        {
            try
            {
                if (sendTextBox.Text!=null)
                {
                    swSender.WriteLine(sendTextBox.Text);
                    swSender.Flush();
                }
                sendTextBox.Text = null;
            }
            catch (Exception)
            {
            }
        }
        private void UpdateLog(string Message)
        {
            try
            {
                clientLogTextBox.AppendText(Message + "\n\r");
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception)
            { }
        }
        void Connect()
        {
            try
            {
                if (!connected)
                {
                    InitializeConnection();
                }
                else
                {
                    CloseConnection("\nUser Disconnected");
                }
            }
            catch (Exception)
            {
            }
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }
        
        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void sendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    SendMessage();
                }
            }
            catch (Exception)
            { }
        }

        private void userTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char) Keys.Enter)
                Connect();
        }

        private void NatterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
             try
            {
                if (connected)
                {
                    connected = false;
                    swSender.Close();
                    srRecieve.Close();
                    tcpServer.Close();
                }
            }
            catch (Exception)
            { }
        }
    }
}
