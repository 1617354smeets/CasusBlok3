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
    [Activity(Label = "Eindspel")]
    public class Eindspel : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Eindspel);


            //start button
            Button start = FindViewById<Button>(Resource.Id.start);

            start.Click += delegate
            {
                StartActivity(typeof(Eindspel2));
            };
        }

        public override void OnBackPressed()
        {
            //
        }
    }


    
}