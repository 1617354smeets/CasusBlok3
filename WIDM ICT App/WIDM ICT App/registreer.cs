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
    [Activity(Label = "registreer")]
    public class registreer : Activity
    {

        //de invulvelden
        EditText reg_naam, reg_ww_1, reg_ww_2, reg_mail;

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
                    SetContentView(Resource.Layout.registreer2);
                }
                else if (reg_naam.Text.Equals(""))//dit test of er een naam is ingevuld
                {
                    reg_naam.SetError("Pik, je bent je naam vergeten!",GetDrawable(Resource.Drawable.Error_Icon));
                    reg_naam.RequestFocus();
                }else if (!reg_ww_1.Text.Equals(reg_ww_2.Text) || reg_ww_1.Text.Equals(""))//dit test of de wachtwoorden kloppen
                {
                    reg_ww_1.SetError("Pik, je wachtwoorden kloppen niet!", GetDrawable(Resource.Drawable.Error_Icon));
                    reg_ww_1.RequestFocus();
                }else if (!isEmailValid(reg_mail.Text))//dit klopt of het email bestaat
                {
                    reg_mail.SetError("Pik, je Email bestaat niet!", GetDrawable(Resource.Drawable.Error_Icon));
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
    }
}