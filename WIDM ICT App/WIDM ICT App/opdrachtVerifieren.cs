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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.opdrachtVerifieren);
            // Create your application here

            Button verzendButton = FindViewById<Button>(Resource.Id.ButtonVerzenden);
            TextView scoreText = FindViewById<TextView>(Resource.Id.ScoreText);

            verzendButton.Click += delegate
            {
                try
                {
                    score = Convert.ToInt32(scoreText.Text);
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
            string kleur = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

    }
}