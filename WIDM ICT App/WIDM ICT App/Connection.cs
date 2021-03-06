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
        //Het ip addres van de server dient hier ingevoerd te worden
        private string IP = "10.77.151.228";
        private Thread clientThread;
        private NetworkStream stream;
        private TcpClient client;
        private byte[] buffer;
        private bool isConnected;
        private static Connection instance;

        //user
        private Speler spelerAccount;
        private Opdracht opdracht;
        private int typegebruiker;
        private Group groep;


        //activities
        private MainActivity mainActivity;
        private registreer registreerActivity;
        private registreer2 registreer2Activity;
        private opdrachtVerifieren opdrachtVerifyActivity;
        private opdrachtUitvoeren opdrachtUitvoerActivity;
        private Molboekje molboekActivity;
        private hoofdscherm hoofdschermactivity;

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

        internal Speler SpelerAccount
        {
            get
            {
                return spelerAccount;
            }

            set
            {
                spelerAccount = value;
            }
        }

        public int Typegebruiker
        {
            get
            {
                return typegebruiker;
            }


        }

        internal Group Groep
        {
            get
            {
                return groep;
            }

            set
            {
                groep = value;
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

                        }
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        //inloggen 
        public void Inloggen(string Username, string Password)
        {
            //Methode om in te loggen 
            string loginmessage;
            loginmessage = "login|" + Username + "|" + Password;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(loginmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);

        }

        //registreert een gebruiker
        public void Registreren(string Username, string Password)
        {
            // Methode om een speler te registreren
            string regmessage;
            regmessage = "registreer|" + Username + "|" + Password;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(regmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);

        }

        //controlleert of een gebruiker bestaat
        public void CheckUser(string Username)
        {
            string checkmessage;
            checkmessage = "checkuser|" + Username;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(checkmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

        public void send(string message)
        {//algemene methode om iets te sturen naar de client
            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(message);
            Console.WriteLine("Sending back:" + message);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

        public void Registreer(string username, string password, string groupid, string admin, string mol, string name, string geboortedatum, string Geslacht, string KLEUR, string OGEN, string ETEN, string ROKEN, string RELATIE, string BROERZUS, string TATTOO, string SPORT)
        {

            string message = ("registreer|" + username + "|" + password + "|" + groupid + "|" + admin + "|" + mol + "|" + name + "|" + geboortedatum + "|" + Geslacht + "|" + KLEUR + "|" + OGEN + "|" + ETEN + "|" + ROKEN + "|" + RELATIE + "|" + BROERZUS + "|" + TATTOO + "|" + SPORT);

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(message);
            Console.WriteLine("Sending back:" + message);
            stream.Write(messageInBytes, 0, messageInBytes.Length);

        }

        public void MolboekOphalen()
        {
            string loginmessage;
            loginmessage = "getmolboekje";

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(loginmessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

        public void wwupdate(string wachtwoord)
        {
            string wwm;
            wwm = "updatewachtwoord|"+wachtwoord;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(wwm);
            stream.Write(messageInBytes, 0, messageInBytes.Length);


        }

        public void MolboekjeUpdtate(string tekst)
        {
            string updatemessage;
            updatemessage = "molboekje|" + tekst;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(updatemessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

        public void VerstuurScore(string groep, string opdracht, string score)
        {
            string verimessage;
            verimessage = "verifieropdracht|" + groep + "|" + opdracht + "|" + score;

            byte[] messageInBytes = ASCIIEncoding.ASCII.GetBytes(verimessage);
            stream.Write(messageInBytes, 0, messageInBytes.Length);
        }

        private void checkRead(string read)//hierin kunnen de "commandos" komen waardoor je je bijvoorbeeld kunt registreren
        {
            if (read.StartsWith("login|"))//regelt het inloggen
            {
                if (read.StartsWith("login|valid|"))
                {
                    //regelt het met de user die binnenkomt
                    setUser(read.Replace("login|valid|", ""));
                    mainActivity.startMainScreen();

                }
                else
                {
                    mainActivity.LoginError();
                }
            }
            //de controle voor de user komt hier binnen
            else if (read.StartsWith("checkuser|"))
            {
                read = read.Replace("checkuser|", "");
                if (read.Equals("valid"))
                {
                    //gebruikersnaam is geldig
                    registreerActivity.startReg2();
                }
                else//user already exists so invalid
                {
                    //geen geldige gebruikersnaam
                    registreerActivity.UnivaldUsername();
                }
            }
            else if (read.StartsWith("registratie|"))    //regelt het als de reg. goed of slecht is afgerond
            {
                read = read.Replace("registratie|", "");
                if (read.Equals("succes"))
                {
                    registreer2Activity.RegSucces();
                }
            }
            else if (read.StartsWith("opdracht|"))
            {
                setOpdracht(read);
            }

            else if (read.StartsWith("molboekje|"))
            {
                read = read.Replace("molboekje|", "");
                spelerAccount.Boekje.Tekst = read;
            }
            //maak een groep aan
            else if (read.StartsWith("groep|"))
            {
                read = read.Replace("groep|", "");
                setGroep(read);
            }
            //verwerkt de volgende opdracht
            else if (read.StartsWith("updateopdracht|"))
            {
                read = read.Replace("updateopdracht|", "");
                updateOprdacht(read);
            }



        }

        //verwerkt de volgende opdracht
        private void updateOprdacht(string read)
        {
            string[] readsplit = read.Split('|');

            groep.update(Convert.ToInt32(readsplit[0]), Convert.ToInt32(readsplit[1]));

            

            
            
        }

        private void setOpdracht(string read)
        {
            read = read.Replace("opdracht|", "");
            string[] readsplit = read.Split('|');
            double lat = Convert.ToDouble(readsplit[1]);
            lat = lat / 100000;
            double lon = Convert.ToDouble(readsplit[2]);
            lon = lon / 100000;
            Console.WriteLine("testinglatlong" + lat + "    " + lon);

            Opdracht = new Opdracht(Convert.ToInt32(readsplit[0]), lat, lon, Convert.ToInt32(readsplit[3]), Convert.ToInt32(readsplit[4]), readsplit[5]);
            

            hoofdschermactivity.changemarker(lat, lon);
            //mainActivity.startOpdracht();


        }

        //maakt de gebruiker aan
        private void setUser(string readData)
        {
            string[] readsplit = readData.Split('|');
            // maak speler aan
            if (readsplit[0].Equals("0"))
            {
                typegebruiker = 0;
                spelerAccount = new Speler(Convert.ToInt32(readsplit[1]), readsplit[2].ToString(), readsplit[3].ToString(), readsplit[4].ToString(), Convert.ToInt32(readsplit[5]), readsplit[6].ToString());
                spelerAccount.Mol = Convert.ToBoolean(readsplit[7]);
                spelerAccount.GroepID = Convert.ToInt32(readsplit[8]);
            }
            //spelleider
            else if (readsplit[0].Equals("1"))
            {
                typegebruiker = 1;
                
            }

        }

        private void setGroep(string readData)
        {
            string[] readsplit = readData.Split('|');
            int groepid = Convert.ToInt32(readsplit[0]);
            string[] scoresplit = readsplit[1].Split('@');
            string[] volgordesplit = readsplit[2].Split('@');
            List<int> scorelijst = new List<int>();
            List<int> volgorde = new List<int>();

            for (int i = 0; i < scoresplit.Length - 1; i++)
            {

                int tempscore = Convert.ToInt32(scoresplit[i].ToString());
                scorelijst.Add(tempscore);

            }

            for (int i = 0; i < volgordesplit.Length - 1; i++)
            {
                int tempvolgorde = Convert.ToInt32(volgordesplit[i].ToString());
                volgorde.Add(tempvolgorde);
            }
            groep = new Group(groepid, scorelijst, volgorde);

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

        public void sethoofdschermactivity(hoofdscherm activity)
        {
            this.hoofdschermactivity = activity;
        }


    }
}