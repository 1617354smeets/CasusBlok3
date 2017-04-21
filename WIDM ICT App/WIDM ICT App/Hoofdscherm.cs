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

        GoogleMap map;
        LocationManager locationManager;
        String provider;
        double currentLong = 5.958949;
        double currentLat = 50.880790;
        TextView schermnaam;
        private Double checkLong;
        private Double checkLat;
        private Toast distance;
        private string message;

        private string opdr = "1";

        ImageButton opdracht;

        public void OnMapReady(GoogleMap googleMap)
        {

            map = googleMap;
            //Opties voor kaart

            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            googleMap.MyLocationEnabled = true;

            setMarker(checkLong, checkLat, googleMap);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Hoofdscherm);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);


            //checkLat = connect.Opdracht.CoordX;
            //checkLong = connect.Opdracht.CoordY;

            //Buttons
            ImageButton molboekje = FindViewById<ImageButton>(Resource.Id.imageButton2);
            ImageButton accountsettings = FindViewById<ImageButton>(Resource.Id.imageButton1);
            opdracht = FindViewById<ImageButton>(Resource.Id.imageButton3);
            //opdracht.Enabled = false;

            //Textveld voor het widm boekje
            schermnaam = FindViewById<TextView>(Resource.Id.textView1);

            
            //voeg de naam van de speler boven aan het scherm toe
            schermnaam.Text = connect.SpelerAccount.Naam;
            

            //test toast
            distance = Toast.MakeText(ApplicationContext, message, ToastLength.Long);


            //zorgt voor de locatiewijzigingen

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);
            
            Location location = locationManager.GetLastKnownLocation(provider);
            if (location == null)
                System.Diagnostics.Debug.WriteLine("No location!");



           

            molboekje.Click += delegate
            {
                connect.MolboekOphalen();
                StartActivity(typeof(Molboekje));


            };

            accountsettings.Click += delegate
            {
                StartActivity(typeof(accountsettings));
            };

            opdracht.Click += delegate
            {
                connect.send("getOpdracht|"+opdr);
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
            double afstand = Getafstand(checkLat, checkLong, currentLat, currentLong);
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


        //zorgen voor de coordinaten 
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

        public void setMarker(Double x, Double y, GoogleMap googleMap)
        {
            //Haalt alle oude markers weg
            googleMap.Clear();

            //Voegt volgende doel toe
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(x, y));
            markerOptions.SetTitle("Next checkpoint");
            googleMap.AddMarker(markerOptions);
        }

        

    }
}
