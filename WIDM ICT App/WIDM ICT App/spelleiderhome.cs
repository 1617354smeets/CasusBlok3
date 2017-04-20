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
    [Activity(Label = "spelleiderhome")]
    public class spelleiderhome : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Connection connect = Connection.Instance;


            SetContentView(Resource.Layout.spelleiderhome);
            // Create your application here

            Button opdrverifieren = FindViewById<Button>(Resource.Id.btn1spl);

            opdrverifieren.Click += delegate
            {
                StartActivity(typeof(opdrachtVerifieren));
            };




        }
    }
}