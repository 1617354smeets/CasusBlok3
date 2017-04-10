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
	sealed class Connection
	{
	
		private int port = 50000;
		private string IP = "84.25.19.170";
		private Thread clientThread;
		private NetworkStream stream;
		private TcpClient client;
		private byte[] buffer;
		private bool isConnected;
		private static Connection instance;

		//user
		private User clientUser;



		//activities
		private MainActivity mainActivity;
		private registreer registreerActivity;
		private registreer2 registreer2Activity;
		private opdrachtVerifieren opdrachtVerifyActivity;
		private opdrachtUitvoeren opdrachtUitvoerActivity;


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

		private Connection()
		{
			client = new TcpClient(IP, port);
			stream = client.GetStream();
			buffer = new byte[client.ReceiveBufferSize];
			clientThread = new Thread(listen);
			clientThread.Start();
			//reconnectThread = new Thread(reconnect);
			//reconnectThread.Start();
		}


		public static Connection Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Connection();
				}
				return instance;
			}
		}

		public User ClientUser
		{
			get
			{
				return clientUser;
			}

			set
			{
				clientUser = value;
			}
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
				else
				{
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
			if (read.StartsWith("login!"))//regelt het inloggen
			{
				if (read.StartsWith("login!valid!"))
				{
					//regelt het met de user die binnenkomt
					setUser(read.Replace("login!valid!",""));

					mainActivity.startMainScreen(ClientUser.Admin);
				}
				else
				{
					mainActivity.LoginError();
				}
			}
			else if (read.StartsWith("checkuser!"))
			{
				read = read.Replace("checkuser!", "");
				if (read.Equals("valid"))
				{
					registreerActivity.startReg2();
				}
				else//user already exists so invalid
				{
					registreerActivity.UnivaldUsername();
				}
			}
			else if (read.StartsWith("registratie!"))//regelt het als de reg. goed of slecht is afgerond
			{
				read = read.Replace("registratie!", "");
				if (read.Equals("succes"))
				{
					registreer2Activity.RegSucces();
				}
			}



		}

		private void setUser(string readData)
		{
			string[] readsplit = readData.Split('!');
			ClientUser = new User(readsplit[0], readsplit[1], Convert.ToBoolean(readsplit[2]), Convert.ToInt32(readsplit[3]), Convert.ToBoolean(readsplit[4]), readsplit[5], readsplit[6], Convert.ToInt32(readsplit[7]), Convert.ToInt32(readsplit[8]), Convert.ToInt32(readsplit[9]), Convert.ToInt32(readsplit[10]), Convert.ToInt32(readsplit[11]), Convert.ToInt32(readsplit[12]), Convert.ToInt32(readsplit[13]), Convert.ToInt32(readsplit[14]), Convert.ToInt32(readsplit[15]));
		}

		public void setMainActivity(MainActivity mainActivity)
		{
			this.mainActivity = mainActivity;
		}

		public void setRegActivity(registreer regActivity)
		{
			this.registreerActivity = regActivity;
		}

		public void setReg2Activity(registreer2 reg2Activity)
		{
			this.registreer2Activity = reg2Activity;
		}

		public void setOpdrachtVerifyActivity(opdrachtVerifieren activity)
		{
			opdrachtVerifyActivity = activity;
		}

		public void setOpdrachtUitvoerActivity(opdrachtUitvoeren activity)
		{
			opdrachtUitvoerActivity = activity;
		}

	}
}