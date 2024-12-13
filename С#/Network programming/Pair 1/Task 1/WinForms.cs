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

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            int port = 1024;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    clientSocket.Connect(endPoint);
                    string message = "Привіт, сервере!";
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                    clientSocket.Send(messageBytes);

                    byte[] buffer = new byte[1024];
                    int receivedBytes = clientSocket.Receive(buffer);
                    string serverMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                    txtOutput.Text += $"О {DateTime.Now:HH:mm} від сервера отримано рядок: {serverMessage}\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Клієнт");
                }
            }
        }
    }
}
