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
    [Activity(Label = "registreer")]
    public class registreer : Activity
    {

        //de invulvelden


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registeer);
            // Create your application here


            //gaat naar het volgende scherm van het registreerscherm
            Button btnNext = FindViewById<Button>(Resource.Id.btn_reg_next);
            btnNext.Click += delegate
            {
                //gaat naar het tweede scherm van de registratie
                if ()
                {
                    SetContentView(Resource.Layout.registreer2);
                }

            };

            //gaat terug naar het login scherm
            Button btnBack = FindViewById<Button>(Resource.Id.btn_reg_cancel1);
            btnBack.Click += delegate
            {

                StartActivity(typeof(MainActivity));

            };

        }
    }
}