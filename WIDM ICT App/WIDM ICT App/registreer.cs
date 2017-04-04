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
using Android.Text;

namespace WIDM_ICT_App
{
    [Activity(Label = "Registratie")]
    public class registreer : Activity
    {

        //De invulvelden
        EditText reg_naam, reg_ww_1, reg_ww_2, reg_mail;

        //variabelen voor het doorgeven van de data naar de volgende activity
        public static string username;
        public static string name;
        public static string password;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registeer);
            // Create your application here

            //vind de invulvelden
            reg_naam = FindViewById<EditText>(Resource.Id.reg_naam);
            reg_ww_1 = FindViewById<EditText>(Resource.Id.reg_ww_1);
            reg_ww_2 = FindViewById<EditText>(Resource.Id.reg_ww_2);
            reg_mail = FindViewById<EditText>(Resource.Id.reg_mail);

            //gaat naar het volgende scherm van het registreerscherm
            Button btnNext = FindViewById<Button>(Resource.Id.btn_reg_next);
            btnNext.Click += delegate
            {
                //gaat naar het tweede scherm van de registratie
                if (!reg_naam.Text.Equals("") && isEmailValid(reg_mail.Text) && !reg_ww_1.Text.Equals("") && reg_ww_1.Text.Equals(reg_ww_2.Text))
                {
                    username = reg_mail.Text;
                    name = reg_naam.Text;
                    password = GETHash(reg_ww_1.Text);

                    //verstuur data naar de volgend activity;
                    //
                    var registreer22 = new Intent(this, typeof(registreer2));
                    // Bundle extras = new Bundle();
                    registreer22.PutExtra("EXTRA_USERNAME", username);
                    registreer22.PutExtra("EXTRA_PASSWORD", password);
                    registreer22.PutExtra("EXTRA_NAME", name);
                    // registreer22.PutExtras(extras);
                    StartActivity(registreer22);


                }
                else if (reg_naam.Text.Equals(""))//dit test of er een naam is ingevuld
                {
                    reg_naam.SetError("Vul je naam in!", GetDrawable(Resource.Drawable.Error_Icon));
                    reg_naam.RequestFocus();
                }
                else if (!reg_ww_1.Text.Equals(reg_ww_2.Text) || reg_ww_1.Text.Equals(""))//dit test of de wachtwoorden kloppen
                {
                    reg_ww_1.SetError("De wachtwoorden komen niet overeen", GetDrawable(Resource.Drawable.Error_Icon));
                    reg_ww_1.RequestFocus();
                }
                else if (!isEmailValid(reg_mail.Text))//dit klopt of het email bestaat
                {
                    reg_mail.SetError("Vul een geldig e-mail adres in!", GetDrawable(Resource.Drawable.Error_Icon));
                    reg_mail.RequestFocus();
                }
            };

            //gaat terug naar het login scherm
            Button btnBack = FindViewById<Button>(Resource.Id.btn_reg_cancel1);
            btnBack.Click += delegate
            {

                StartActivity(typeof(MainActivity));
            };




        }




        private bool isEmailValid(String email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }

        public string GETHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
           
            return Convert.ToBase64String(hashBytes);
        }


        
    }
}