using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnGetDate_Click(object sender, EventArgs e)
        {
            RequestFromServer("дата");
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            RequestFromServer("час");
        }

        private void RequestFromServer(string request)
        {
            int port = 1024;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    clientSocket.Connect(endPoint);

                    byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                    clientSocket.Send(requestBytes);

                    byte[] buffer = new byte[1024];
                    int receivedBytes = clientSocket.Receive(buffer);
                    string serverResponse = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                    txtOutput.Text += $"Від сервера отримано: {serverResponse}\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Клієнт");
                }
            }
        }
    }
}
