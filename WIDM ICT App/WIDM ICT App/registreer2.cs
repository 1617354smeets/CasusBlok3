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
    [Activity(Label = "Registratie")]
    public class registreer2 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //get data from registreer activity
            string username = Intent.GetStringExtra("EXTRA_USERNAME");
            string password = Intent.GetStringExtra("EXTRA_PASSWORD");
            string name = Intent.GetStringExtra("EXTRA_NAME");
            // string voor de geboortedatum
            string geboortedatum;
            string geslacht;

            SetContentView(Resource.Layout.registreer2);


            //SPINNNER ITEM 1
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            //SPINNER ITEM 1






            //De registratie wordt beindigd en de het loginscherm verschijnt.
            Button btn_back = FindViewById<Button>(Resource.Id.btn_reg_cancel2);
            btn_back.Click += delegate
            {
                StartActivity(typeof(MainActivity));

            };



            





            //geboortedatum knop
            Button datum_click = FindViewById<Button>(Resource.Id.btn_reg_datum);
            datum_click.Click += delegate
            {
                DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    geboortedatum = time.ToShortDateString();
                    datum_click.Text = "Geboorte datum: " + geboortedatum;
                    //ToLongDateString();
                });
                frag.Show(FragmentManager, DatePickerFragment.TAG);
            };

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }




    }
}
 