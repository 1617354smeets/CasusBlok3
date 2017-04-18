using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;

namespace WIDM_ICT_App
{
    [Activity(Label = "Hoofdscherm")]
    public class hoofdscherm : Activity, IOnMapReadyCallback
    {
        public void OnMapReady(GoogleMap googleMap)
        {
            //Opties voor kaart
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            googleMap.MyLocationEnabled = true;

            setMarker(10, 20, googleMap);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Hoofdscherm);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            ImageButton molboekje = FindViewById<ImageButton>(Resource.Id.imageButton2);

            molboekje.Click += delegate
            {
                StartActivity(typeof(Molboekje));
            };



        }

        public void setMarker(float x, float y, GoogleMap googleMap)
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
