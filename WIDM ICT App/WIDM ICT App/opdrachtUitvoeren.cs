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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.opdrachtUitvoeren);
            // Create your application here

      
            TextView scoreText = FindViewById<TextView>(Resource.Id.textView3);
        }
    }
}