﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;

namespace WIDM_ICT_App
{
    [Activity(Label = "WIDM ICT App", MainLauncher = true, Icon = "@drawable/WIDM_Icon")]
    public class MainActivity : Activity
    {
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

            Button btn1 = FindViewById<Button>(Resource.Id.btn1);
            Button btn2 = FindViewById<Button>(Resource.Id.btn2);
            TextView tv_con = FindViewById<TextView>(Resource.Id.tv_con);

            /*
            if (!isOnline)
            {
                tv_con.Visibility = Android.Views.ViewStates.Visible;

            }

            else
            {
                tv_con.Visibility = Android.Views.ViewStates.Invisible;
            }

              */

            //Login knop

            btn1.Click += delegate
            {
                //Code om in te loggen

            };



            //Registratie voor wie is de mol 
             btn2.Click += delegate
             {
                 StartActivity(typeof(registreer));

             };
        }
    }
}


