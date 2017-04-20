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
    [Activity(Label = "Eindspel2")]
    public class Eindspel2 : Activity
    {
        private string strgeslacht;
        private string strleeftijd;
        private string strsport;
        private string strkleur;
        private string streten;
        private string strogen;
        private string strroken;
        private string strrelatie;
        private string strkind;
        private string strtattoo;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.eindspel2);

            //Sinners--------------------------------------------------------------------------

            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);

            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected1);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.geslacht_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;
            //-----------------
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);

            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected2);
            var adapter2 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.Leeftijd_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;
            //-------------------------
            Spinner spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);

            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected3);
            var adapter3 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.janee_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner3.Adapter = adapter3;

            //-------------------------
            Spinner spinner4 = FindViewById<Spinner>(Resource.Id.spinner4);

            spinner4.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected4);
            var adapter4 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.kleur_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner4.Adapter = adapter4;

            //-------------------------
            Spinner spinner5 = FindViewById<Spinner>(Resource.Id.spinner5);

            spinner5.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected5);
            var adapter5 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.eten_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner5.Adapter = adapter5;

            //-------------------------
            Spinner spinner6 = FindViewById<Spinner>(Resource.Id.spinner6);

            spinner6.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected6);
            var adapter6 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.ogen_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner6.Adapter = adapter6;

            //-------------------------
            Spinner spinner7 = FindViewById<Spinner>(Resource.Id.spinner7);

            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected7);
            var adapter7 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.janee_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner7.Adapter = adapter7;

            //-------------------------
            Spinner spinner8 = FindViewById<Spinner>(Resource.Id.spinner1);

            spinner8.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected8);
            var adapter8 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.janee_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner8.Adapter = adapter8;

            //-------------------------
            Spinner spinner9 = FindViewById<Spinner>(Resource.Id.spinner1);

            spinner9.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected9);
            var adapter9 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.janee_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner9.Adapter = adapter9;

            //-------------------------
            Spinner spinner10 = FindViewById<Spinner>(Resource.Id.spinner10);

            spinner10.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected10);
            var adapter10 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.janee_array, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner10.Adapter = adapter10;


            //Spinners einde ------------------------------------------------------







        }


        //spinners select methodes
        private void spinner_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strgeslacht = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strleeftijd = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected3(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strsport = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected4(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            streten = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected5(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            streten = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected6(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strogen = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected7(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strroken = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected8(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strrelatie = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void spinner_ItemSelected9(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strkind = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


        private void spinner_ItemSelected10(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            strtattoo = string.Format("{0}", spinner.GetItemAtPosition(e.Position));



            // string toast = string.Format("e {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}