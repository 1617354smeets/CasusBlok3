﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace WIDM_ICT_App
{
    [Activity(Label = "WIDM_ICT_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            ///

            //GREETZ
            //hoi
            //Test
            //wat is dit toch leuk
        }
    }
}

