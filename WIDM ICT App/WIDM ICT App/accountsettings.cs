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
    [Activity(Label = "accountsettings")]
    public class accountsettings : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Connection connect = Connection.Instance;

            SetContentView(Resource.Layout.accountsettings);


            //Textview voor de account naam
            TextView tv1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView mail = FindViewById<TextView>(Resource.Id.tv_mail2);

            tv1.Text = connect.SpelerAccount.Naam;
            mail.Text = connect.SpelerAccount.Username;

            //Buttons
            ImageButton terug = FindViewById<ImageButton>(Resource.Id.image_back);


            terug.Click += delegate
            {
                // terug naar vorige acctivity
                StartActivity(typeof(hoofdscherm));
            };



        }
    }
}