using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using System.Text;
using System;

namespace WIDM_ICT_App
{
	[Activity(Label = "Wie is de Mol", MainLauncher = true, Icon = "@drawable/WIDM_Icon")]
	public class MainActivity : Activity
	{


		public Button btn1;
		private EditText ww;
		private EditText gb;
		private Connection connect;
		private TextView nocon;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			/*bool isOnline;
            ConnectivityManager conman = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo netinfo = conman.ActiveNetworkInfo;
            if (netinfo.IsConnected)
            {
                isOnline = true;
            }
            else
            {
                isOnline = false;
            }
            
            */


			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			ww = FindViewById<EditText>(Resource.Id.ww_input);
			gb = FindViewById<EditText>(Resource.Id.gb_input);



			btn1 = FindViewById<Button>(Resource.Id.btn1);
			Button btn2 = FindViewById<Button>(Resource.Id.btn2);
			Button kellys = FindViewById<Button>(Resource.Id.btn_kelly);
			nocon = FindViewById<TextView>(Resource.Id.textView1);
			try
			{
				connect = Connection.Instance;
				connect.setMainActivity(this);
			}
			catch
			{
				btn1.Enabled = false;
				btn2.Enabled = false;
				nocon.Text = "NO CONNECTION";
			}





			//Login knop

			btn1.Click += delegate
			{
				string x2 = ww.Text;
				string password = GETHash(ww.Text);
				string username = gb.Text;
				connect.send("login!" + username + "!" + password);

			};




			//Registratie voor wie is de mol 
			btn2.Click += delegate
			{
				StartActivity(typeof(registreer));

			};


			//testknop voor kelly
			kellys.Click += delegate
			{
				StartActivity(typeof(Molboekje));
			};

		}

		public void startMainScreen(bool isAdmin)
		{

			Console.WriteLine("user is een admin:" + isAdmin);
			if (isAdmin)
			{//user is een admin
				StartActivity(typeof(opdrachtVerifieren));
			}
			else
			{//user is geen admin
				StartActivity(typeof(opdrachtUitvoeren));
			}
		}

		public void LoginError()
		{

			// ww.Text = "ERROR";        
		}



		public string GETHash(string password)
		{
			password = "WiDm@ict#17" + password;

			var bytes = new UTF8Encoding().GetBytes(password);
			byte[] hashBytes;
			using (var algorithm = new System.Security.Cryptography.SHA512Managed())
			{
				hashBytes = algorithm.ComputeHash(bytes);
			}

			return Convert.ToBase64String(hashBytes);
		}

	}
}


