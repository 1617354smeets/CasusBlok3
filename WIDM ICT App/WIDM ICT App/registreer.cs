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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registeer);
            // Create your application here


            EditText reg_ww_1 = FindViewById<EditText>(Resource.Id.reg_ww_1);
            reg_ww_1.Click += delegate
            {
                if (reg_ww_1.Text.Equals("Wachtwoord"))
                //de tekst wordt alleen verwijdert als er Wachtwoord staat 
                //zodat er niet per ongeluk een naam word verwijdert
                {
                    reg_ww_1.Text = "";
                    reg_ww_1.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText;
                    //De ingevoerde tekst wordt met bollejtes weergegeven, de wachtwoord input.
                }
            };


            EditText reg_ww_2 = FindViewById<EditText>(Resource.Id.reg_ww_2);
            reg_ww_2.Click += delegate
            {
                if (reg_ww_2.Text.Equals("Herhaal  wachtwoord"))
                //de tekst wordt alleen verwijdert als er Wachtwoord staat 
                //zodat er niet per ongeluk een naam word verwijdert
                {
                    reg_ww_2.Text = "";
                    reg_ww_2.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText;
                    //De ingevoerde tekst wordt met bollejtes weergegeven, de wachtwoord input.
                }
            };


        }
    }
}