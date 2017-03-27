using Android.App;
using Android.Widget;
using Android.OS;

namespace WIDM_ICT_App
{
    [Activity(Label = "WIDM_ICT_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //

            //dit voegt toe dat de text gebruikersnaam wordt verwijdert als er op het tekstveld wordt geklikt
            EditText gbInputField = FindViewById<EditText>(Resource.Id.gb_input);
            gbInputField.Click += delegate
            {
                if (gbInputField.Text.Equals("Gebruikersnaam"))
                //de tekst wordt alleen verwijdert als er Gebruikersnaam staat 
                //zodat er niet per ongeluk een naam word verwijdert
                {
                    gbInputField.Text = "";
                }
            };

            //dit voegt toe dat de text wachtwoord wordt verwijdert als er op het tekstveld wordt geklikt
            EditText wwInputField = FindViewById<EditText>(Resource.Id.ww_input);
            wwInputField.Click += delegate
            {
                if (wwInputField.Text.Equals("Wachtwoord"))
                //de tekst wordt alleen verwijdert als er Wachtwoord staat 
                //zodat er niet per ongeluk een wachtwoord word verwijdert
                {
                    wwInputField.Text = "";
                }


                //Test
            };
        }
    }
}

