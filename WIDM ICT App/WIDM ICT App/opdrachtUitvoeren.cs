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
        private Button pijlButton;
        private EditText maxScore;
        private EditText maxTijd;
        private EditText opdrachtNr;
        private Connection connect;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            pijlButton = FindViewById<Button>(Resource.Id.imageButton1);
            maxTijd = FindViewById<EditText>(Resource.Id.maxTijd);
            opdrachtNr = FindViewById<EditText>(Resource.Id.opdrachtNr);
            maxScore = FindViewById<EditText>(Resource.Id.maxScore);
            pijlButton.Click += delegate
            {
                //terug naar kaart
            };

        
            
        }
    }
}