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
        private Toast regsucces;
        private Toast loginfail;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			
            


			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			ww = FindViewById<EditText>(Resource.Id.ww_input);
			gb = FindViewById<EditText>(Resource.Id.gb_input);

            regsucces = Toast.MakeText(ApplicationContext, "De registratie is gelukt, u kunt nu inloggen!", ToastLength.Long);

            loginfail = Toast.MakeText(ApplicationContext, "Wachtwoord of gebruikersnaam klopt niet!", ToastLength.Long);

            btn1 = FindViewById<Button>(Resource.Id.btn1);
            TextView btn2 = FindViewById<TextView>(Resource.Id.reg_text);
			//Button btn2 = FindViewById<Button>(Resource.Id.btn2);
			//nocon = FindViewById<TextView>(Resource.Id.textView1);
			try
			{
				connect = Connection.Instance;
				connect.setMainActivity(this);
			}
			catch
			{
				btn1.Enabled = false;
				btn2.Enabled = false;
				//nocon.Text = "NO CONNECTION";
			}





			//Login knop

			btn1.Click += delegate
			{
				string x2 = ww.Text;
				string password = GETHash(ww.Text);
				string username = gb.Text;
                //stuur de login gegevens door naar de connectieclass 
                connect.Inloggen(username, password);

			};




			//Registratie voor wie is de mol, het registratiescherm wordt geopend!
			btn2.Click += delegate
			{
				StartActivity(typeof(registreer));

			};
            		

		}

        public void startMainScreen()
        {

            int type = connect.Typegebruiker;

            if (type == 1 )
            {//user is een admin
                StartActivity(typeof(spelleiderhome));
            }
            else if (type == 0)
            {//user is geen admin
                StartActivity(typeof(hoofdscherm));
                
            }
        }

        public void startOpdracht()
        {
            StartActivity(typeof(opdrachtUitvoeren));
        }

            

		public void LoginError()
		{

            loginfail.Show();       
		}


        public void RegistratieSucces()
        {
            regsucces.Show();
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


