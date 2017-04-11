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
    [Activity(Label = "opdrachtUitvoeren")]
    public class opdrachtUitvoeren : Activity
    {
        private ImageButton pijlButton;
        private TextView maxScore;
        private TextView maxTijd;
        private TextView opdrachtNr;
        private TextView beschrijving;
        private Connection connect;
        private Opdracht dezeOpdracht;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.opdrachtUitvoeren);

            pijlButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            maxTijd = FindViewById<TextView>(Resource.Id.maxTijd);
            opdrachtNr = FindViewById<TextView>(Resource.Id.opdrachtNr);
            maxScore = FindViewById<TextView>(Resource.Id.maxScore);
            beschrijving = FindViewById<TextView>(Resource.Id.beschrijving);
            connect = Connection.Instance;
                updateOpdracht();
            
            pijlButton.Click += delegate
            {
                //terug naar kaart
            };



        }            
        
        public void updateOpdracht()
        {
            //dezeOpdracht = connect.opdracht1;

            maxTijd.Text = "koekje";
            opdrachtNr.Text = "Opdracht " + dezeOpdracht.OpdrachtNummer;
            maxScore.Text = dezeOpdracht.ScoreMax + "";
            beschrijving.Text = dezeOpdracht.Beschrijving + "";
        }


    }
}