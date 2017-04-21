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
            Button bntww = FindViewById<Button>(Resource.Id.btn_ww);
            Button btn_rol = FindViewById<Button>(Resource.Id.btn_rol);


            // Edittext
            EditText huidigww = FindViewById<EditText>(Resource.Id.huidigww);
            EditText nieuwww = FindViewById<EditText>(Resource.Id.nieuwww);
            EditText hhww = FindViewById<EditText>(Resource.Id.hhww);

            terug.Click += delegate
            {
                // terug naar vorige acctivity
                StartActivity(typeof(hoofdscherm));
            };

            bntww.Click += delegate
            {
                string wachtwoord = connect.SpelerAccount.Password;
                string newpass = nieuwww.Text;
                string currentpass = GETHash(huidigww.Text);


                if (currentpass.Equals(wachtwoord))
                {
                    if (nieuwww.Text.Equals(hhww.Text))
                    {
                        connect.wwupdate(GETHash(newpass));
                    }
                    else
                    {
                        Toast br1 = Toast.MakeText(ApplicationContext, "Wachtwoord komt niet overeen", ToastLength.Long);
                        br1.Show();
                    }
                }
                else
                {
                    huidigww.SetError("Het huidige wachtwoord komt niet overeen!", GetDrawable(Resource.Drawable.Error_Icon));
                    huidigww.RequestFocus();
                }

            };


            btn_rol.Click += delegate
            {
                bool mol = connect.SpelerAccount.Mol;
                string rol;

                if (mol)
                {
                    rol = "Je bent de mol";
                }
                else
                {
                    rol = "Je bent NIET mol";
                }
                Toast bericht = Toast.MakeText(ApplicationContext, rol, ToastLength.Long);
                bericht.Show();
            };


        }

        public string GETHash(string password)
        {
            password = "WiDm@ict#17" + password;

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