using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using System.Net.Sockets;

namespace WIDM_ICT_App
{
	class Connection
	{

		private int port = 50000;
		private string IP = "10.77.152.171";
		private Thread clientThread, reconnectThread;
		private NetworkStream stream;
		private TcpClient client;
		private byte[] buffer;
		private bool isConnected;

        //activities
        private MainActivity mainActivity;

		public bool IsConnected
		{
			get
			{
				return isConnected;
			}

			set
			{
				isConnected = value;
			}
		}

		public Connection()
		{
			client = new TcpClient(IP, port);
			stream = client.GetStream();
			buffer = new byte[client.ReceiveBufferSize];
			clientThread = new Thread(listen);
			clientThread.Start();
			//reconnectThread = new Thread(reconnect);
			//reconnectThread.Start();
		}

		private void listen()
		{
			isConnected = true;
			while (isConnected)
			{

				if (stream.DataAvailable)
				{
					//---read incoming stream---
					int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);

					//---convert the data received into a string---
					string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
					Console.WriteLine("Received:" + dataReceived + "from the server");
					checkRead(dataReceived);

					//Console.WriteLine(client.Connected);
				}
				else
				{
					if (client.Client.Poll(0, SelectMode.SelectRead))
					{
						byte[] checkConn = new byte[1];
						if (client.Client.Receive(checkConn, SocketFlags.Peek) == 0)
						{
							isConnected = false;
							Console.WriteLine("client disconnected!");
						}
					}
				}
			}

			stream.Close();
			client.Close();
		}

		private void reconnect()
		{
			while (true)
			{
				if (!isConnected)
				{
					if (client.Client.Poll(0, SelectMode.SelectRead))
					{
						byte[] checkConn = new byte[1];
						if (client.Client.Receive(checkConn, SocketFlags.Peek) != 0)
						{
							isConnected = true;
							stream = client.GetStream();
							Console.WriteLine("client connected again!");
						}
					}
				}
				else {
					Thread.Sleep(1000);
				}
			}
		}

		public void send(string message)
		{//algemene methode om iets te sturen naar de client
			byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(message);
			Console.WriteLine("Sending back:" + message);
			stream.Write(messageInBytes, 0, messageInBytes.Length);
		}

		private void checkRead(string read)//hierin kunnen de "commandos" komen waardoor je je bijvoorbeeld kunt registreren
		{
			if (read.StartsWith("world"))
			{
				Console.WriteLine("found world");
                mainActivity.btn1.Text = "found";
			}
		}

        public void setMainActivity(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

	}
}