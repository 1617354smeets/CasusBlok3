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
		private string IP = "10.77.145.236";
		private Thread clientThread;
		private NetworkStream stream;
		private TcpClient client;
		private byte[] buffer;
		private bool isConnected;
		private static Connection instance;

        //user
        private User clientUser;
        private Opdracht opdracht;



		//activities
		private MainActivity mainActivity;
		private registreer registreerActivity;
		private registreer2 registreer2Activity;
		private opdrachtVerifieren opdrachtVerifyActivity;
		private opdrachtUitvoeren opdrachtUitvoerActivity;
        private Molboekje molboekActivity;

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

        internal Opdracht Opdracht
        {
            get
            {
                return opdracht;
            }

            set
            {
                opdracht = value;
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

        public void Inloggen(string Username, string Password)
        {
            //Methode om in te loggen 
            string loginmessage;
            loginmessage = "login!" + Username + "!" + Password;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(loginmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);

        }

        public void Registreren(string Username, string Password)
        {
            // Methode om een speler te registreren
            string regmessage;
            regmessage = "registreer!" + Username + "!" + Password;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(regmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);

        }

        public void CheckUser(string Username)
        {
            string checkmessage;
            checkmessage = "checkuser!" + Username;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(checkmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

		public void send(string message)
		{//algemene methode om iets te sturen naar de client
			byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(message);
			Console.WriteLine("Sending back:" + message);
			stream.Write(messageInBytes, 0, messageInBytes.Length);
		}

        public void VerstuurScore(string groep, string opdracht, string score)
        {
            string verimessage;
            verimessage = "verifieropdracht!" + groep + "!" + opdracht + "!" + score;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(verimessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

		private void checkRead(string read)//hierin kunnen de "commandos" komen waardoor je je bijvoorbeeld kunt registreren
		{
            if (read.StartsWith("login!"))//regelt het inloggen
            {
                if (read.StartsWith("login!valid!"))
                {
                    //regelt het met de user die binnenkomt
                    setUser(read.Replace("login!valid!", ""));

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
            } else if (read.StartsWith("opdracht!"))
            {
                setOpdracht(read);
            }



		}

        private void setOpdracht(string read)
        {
            read = read.Replace("opdracht!","");
            string[] readsplit = read.Split('!');
            Opdracht = new Opdracht(Convert.ToInt32(readsplit[0]),float.Parse(readsplit[1]),float.Parse(readsplit[2]) , Convert.ToInt32(readsplit[3]),Convert.ToInt32(readsplit[4]),readsplit[5]);
            mainActivity.startOpdracht();
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

        public void setMolboekActivity(Molboekje activity)
        {
            molboekActivity = activity;
        }

	}
}