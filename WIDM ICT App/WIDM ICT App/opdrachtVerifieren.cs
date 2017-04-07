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

namespace WIDM_ICT_App
{
	[Activity(Label = "opdrachtVerifieren")]
	public class opdrachtVerifieren : Activity
	{

		private int score = 0;
		private Connection connect;
		
		private string GROEP;
		private string OPDRACHT;

		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.opdrachtVerifieren);

			// SPINNERS-------------------------------------------------------------

			Spinner spinner_groep = FindViewById<Spinner>(Resource.Id.spinner_groep);

			spinner_groep.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
			var adapter6 = ArrayAdapter.CreateFromResource(
					this, Resource.Array.groep_array, Resource.Layout.spinner);

			adapter6.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner_groep.Adapter = adapter6;

			Spinner opdracht = FindViewById<Spinner>(Resource.Id.spinner_opdracht);

			opdracht.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected2);
			var adapter = ArrayAdapter.CreateFromResource(
					this, Resource.Array.opdracht_array, Resource.Layout.spinner);

			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			opdracht.Adapter = adapter;




			//SPINNERS------------------------------------------------------------


			// Create your application here
			connect = Connection.Instance;
			connect.setOpdrachtVerifyActivity(this);

			Button verzendButton = FindViewById<Button>(Resource.Id.ButtonVerzenden);
			TextView scoreText = FindViewById<TextView>(Resource.Id.ScoreText);

			verzendButton.Click += delegate
			{
				try
				{
					//tijd voor een beetje code van No
					connect.send("verifieropdracht!" + groepint(GROEP) + "!" + opdrachtint(OPDRACHT) + "!" + Convert.ToInt32(scoreText.Text));
				}
				catch (FormatException)
				{
					scoreText.SetError("Dit is geen getal!", GetDrawable(Resource.Drawable.Error_Icon));
					scoreText.Text = "";
					scoreText.RequestFocus();
				}
				Console.WriteLine(score.ToString());
				//hierin moet nog komen te staan hoe de score naar de server wordt verzonden
				//connect.send("addScore!" + score);
			};


			/*List<string> opdrachtenaantal = new List<string>();
            int aantalOpdrachten = 5;
            for (int i = 0; i < aantalOpdrachten; i++)
            {
                opdrachtenaantal.Add("Opdracht " + (i + 1).ToString());
            }*/

		}
		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			GROEP = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



		}


		private void spinner_ItemSelected2(object sender, AdapterView.ItemSelectedEventArgs e)
		{

			Spinner spinner = (Spinner)sender;

			OPDRACHT = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
		}

		private int groepint(string groep)
		{
			switch (groep)
			{
				case "Groep 1":
					return 1;
					;
				case "Groep 2":
					return 2;

				default:
					return 0;



			}

		}

		private int opdrachtint(string opdracht)
		{
			switch (opdracht)
			{
				case "Opdracht 1":
					return 1;
				case "Opdracht 2":
					return 2;
				case "Opdracht 3":
					return 3;
				case "Opdracht 4":
					return 4;
				case "Opdracht 5":
					return 5;
				default:
					return 0;


			}
		}
	}


}