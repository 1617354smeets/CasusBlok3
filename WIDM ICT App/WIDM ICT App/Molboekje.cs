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
    [Activity(Label = "Molboekje")]
    public class Molboekje : Activity
    {
        private Connection connect;
        private ImageButton save;
        private EditText mbtext;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Molboek);

            connect = Connection.Instance;
            connect.setMolboekActivity(this);

            
            



            save = FindViewById<ImageButton>(Resource.Id.image_back);
            mbtext = FindViewById<EditText>(Resource.Id.mbText);
            mbtext.Text = connect.SpelerAccount.Boekje.MolboekBekijken();

            save.Click += delegate
            {
                string sendtext = mbtext.Text;
                MolboekjeBewerken(sendtext);

            };

    

        }

        public override void OnBackPressed()
        {
            string sendtext = mbtext.Text;
            MolboekjeBewerken(sendtext);
        }

        public void MolboekjeBewerken(string tekst)
        {

            connect.MolboekjeUpdtate(tekst);
            StartActivity(typeof(hoofdscherm));
        }
    }
}