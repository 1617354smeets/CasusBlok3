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
        private Button save;
        private EditText mbtext;
        private string gebruikersnaam;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Molboek);

            connect = Connection.Instance;
            connect.setMolboekActivity(this);

            gebruikersnaam = "admin";
            //gebruikersnaam = connect.ClientUser.Username;





            save = FindViewById<Button>(Resource.Id.btn_save);
            mbtext = FindViewById<EditText>(Resource.Id.mbText);
            

            save.Click += delegate
            {
                //mbtext.Text = gebruikersnaam;
                
            };





        }

        public override void OnBackPressed()
        {
            string sendtext = mbtext.Text;
            connect.send("molboekje!" + sendtext);
        }
    }
}