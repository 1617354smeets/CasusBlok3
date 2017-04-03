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

        public static string geboortedatum;
        public static string kleur;
        public static string ogen;
        public static string eten;
        public static string roken;
        public static string relatie;
        public static string broerzus;
        public static string tattoo;
        public static string sport;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //get data from registreer activity
            string username = Intent.GetStringExtra("EXTRA_USERNAME");
            string password = Intent.GetStringExtra("EXTRA_PASSWORD");
            string name = Intent.GetStringExtra("EXTRA_NAME");
            // string voor de geboortedatum
            

            //vragenlijst strings




            //vragenlijst strings

            SetContentView(Resource.Layout.registreer2);

            


            //SPINNNER ITEMS---------------------------------------------------------------------------------------------------------------------------------------------------
            //Kleur
            Spinner kleur_spinner = FindViewById<Spinner>(Resource.Id.spinner_kleur);

            kleur_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected1);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.kleur_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            kleur_spinner.Adapter = adapter;

            // ETEN
            Spinner eten_spinner = FindViewById<Spinner>(Resource.Id.spinner_eten);

            eten_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected2);
            var adapter2 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.eten_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            eten_spinner.Adapter = adapter2;

            // OGEN
            Spinner ogen_spinner = FindViewById<Spinner>(Resource.Id.spinner_ogen);

            ogen_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected3);
            var adapter3 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.ogen_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            ogen_spinner.Adapter = adapter3;


            // ROKEN

            Spinner roken_spinner = FindViewById<Spinner>(Resource.Id.spinner_roken);

            roken_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected4);
            var adapter4 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.roken_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter4.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            roken_spinner.Adapter = adapter4;


            // RELATIE

            Spinner relatie_spinner = FindViewById<Spinner>(Resource.Id.spinner_relatie);

            relatie_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected5);
            var adapter5 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.relatie_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter5.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            relatie_spinner.Adapter = adapter5;

            // BROER ZUSSEN

            Spinner broerzus_spinner = FindViewById<Spinner>(Resource.Id.spinner_broerzus);

            relatie_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected6);
            var adapter6 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.broerzus_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter6.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            relatie_spinner.Adapter = adapter6;

            //TATTOO
            Spinner tattoo_spinner = FindViewById<Spinner>(Resource.Id.spinner_tattoo);

            tattoo_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected7);
            var adapter7 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.tattoo_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter7.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            relatie_spinner.Adapter = adapter7;

            //sporten
            Spinner sport_spinner = FindViewById<Spinner>(Resource.Id.sport_tattoo);

            sport_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected8);
            var adapter8 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.sport_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter8.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            relatie_spinner.Adapter = adapter8;

            //SPINNER ITEMS

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




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
        // spinners 
        private void spinner_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            kleur = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
            Spinner spinner = (Spinner)sender;

            eten = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


        private void spinner_ItemSelected3(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            eten = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected4(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            roken = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected5(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;

            relatie = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            string toast = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


        private void spinner_ItemSelected6(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;

            broerzus = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            
            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected7(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            tattoo = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
           
            string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected8(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;

            sport = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            string toast = string.Format("Doe je aan sport {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
 