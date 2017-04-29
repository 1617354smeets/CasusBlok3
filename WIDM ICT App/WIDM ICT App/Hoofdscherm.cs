using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Util;
using Android.Content;


namespace WIDM_ICT_App
{
    [Activity(Label = "Hoofdscherm")]
    public class hoofdscherm : Activity, IOnMapReadyCallback, ILocationListener
    {
        Connection connect = Connection.Instance;
        TextView status;
        GoogleMap googleMap;
        LocationManager locationManager;
        String provider;
        double currentLong;
        double currentLat;
        TextView schermnaam;
        private Double checkLong;
        private Double checkLat;
        private Toast distance;
        private string message;

        private int opdr;
        private int totaalopdrachten;



        ImageButton opdracht;

        public double CheckLong
        {
            get
            {
                return checkLong;
            }

            set
            {
                checkLong = value;
            }
        }

        public double CheckLat
        {
            get
            {
                return checkLat;
            }

            set
            {
                checkLat = value;
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //Opties voor kaart

            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            googleMap.MyLocationEnabled = true;
            this.googleMap = googleMap;
            
            double lat = 1000000;
            lat = lat / 100000;
            setMarker(lat, 10.0);//, googleMap);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Hoofdscherm);

            connect.sethoofdschermactivity(this);

            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            opdr = connect.Groep.HuidigeOpdracht;
            totaalopdrachten = connect.Groep.Aantalopdrachten;

            //haalt de huidige opdracht op
            connect.send("getOpdracht|" + Convert.ToString(opdr));





            //Buttons
            ImageButton molboekje = FindViewById<ImageButton>(Resource.Id.imageButton2);
            ImageButton accountsettings = FindViewById<ImageButton>(Resource.Id.imageButton1);
            status = FindViewById<TextView>(Resource.Id.status);
            opdracht = FindViewById<ImageButton>(Resource.Id.imageButton3);
            status.Text = Convert.ToString(opdr) + "/" + Convert.ToString(totaalopdrachten);


            //opdracht.Enabled = false;

            //Textveld voor het widm boekje
            schermnaam = FindViewById<TextView>(Resource.Id.textView1);


            //voeg de naam van de speler boven aan het scherm toe
            schermnaam.Text = connect.SpelerAccount.Naam + "       Groep: " + connect.Groep.GroupID;


            //test toast
            distance = Toast.MakeText(ApplicationContext, message, ToastLength.Long);


            //zorgt voor de locatiewijzigingen, het kan zijn dat de app hierop vastloopt met een error. Zorg ervoor dat de app locatie machtiging heeft op de telefoon. dit kan via instellingen.

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);

            Location location = locationManager.GetLastKnownLocation(provider);
            if (location == null)
                System.Diagnostics.Debug.WriteLine("No location!");


            //start de eindvragenlijst.

            status.Click += delegate
            {
                StartActivity(typeof(Eindspel));
            };


            //open het molboekje
            molboekje.Click += delegate
            {
                connect.MolboekOphalen();
                StartActivity(typeof(Molboekje));


            };

            // open de accountinstellingen
            accountsettings.Click += delegate
            {
                StartActivity(typeof(accountsettings));
            };

            //knop om de opdracht te zien.
            opdracht.Click += delegate
            {
                StartActivity(typeof(opdrachtUitvoeren));
            };

        }

        protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(provider, 0, 0, this);
        }


        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }


        public void OnLocationChanged(Location location)
        {
            // zet de coordinaten in een double;
            currentLat = location.Latitude;
            currentLong = location.Longitude;

            //test voor het ophalen van de coordinaten
            //schermnaam.Text = "Lat" + Convert.ToString(currentLat) + "Long" + Convert.ToString(currentLong);


            // check de afstand tussen de speler en het checkpoint
            double afstand = Getafstand(CheckLat, CheckLong, currentLat, currentLong);
            message = "Distance: " + Convert.ToString(afstand);
            // distance.Show();

            if (Convert.ToInt32(afstand) < 30)
            {

                opdracht.Enabled = true;
            }
            //schermnaam.Text = Convert.ToString(afstand/1000);
        }

        public void startopdracht()
        {
            StartActivity(typeof(opdrachtUitvoeren));
        }


        //zorgen voor de coordinaten van de huidige locatie
        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }
        public void OnProviderDisabled(string provider)
        {
        }
        public void OnProviderEnabled(string provider)
        {
        }

        public double Getafstand(double Lat1, double Long1, double Lat2, double Long2)
        {
            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                       Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                       Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }

        private double DegreeToRadian(double degree)
        {
            return Math.PI * degree / 180.0;
        }

        public double getAfstand2(double latA, double longA, double latB, double longB)
        {
            double dLat = DegreeToRadian(latB - latA);
            double dLong = DegreeToRadian(longB - longA);

            latA = DegreeToRadian(latA);
            latB = DegreeToRadian(latB);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLong / 2) * Math.Sin(dLong) + Math.Cos(latA) * Math.Cos(latB);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = (6371 * c) / 1000;
            return d;
        }

        public void setMarker(double x, double y)// ,GoogleMap googleMap)
        {
            //Haalt alle oude markers weg
            /*
            if (googleMap != null)
            {
                googleMap.Clear();
            }
            */

            //Voegt volgende doel toe
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(x, y));
            markerOptions.SetTitle("Next checkpoint");
            //googleMap.AddMarker(markerOptions);
            //error, hier gaat iets mis met het ophalen van de mapp
        }

        public void changemarker(double Lat, double Long)
        {
            setMarker(Lat, Long);//, googleMap);
        }

    }
}
