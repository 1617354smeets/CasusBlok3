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
    


    class Molboekclass
    {
        private string tekst;


        public Molboekclass()
        {
            this.Tekst = "";
        }

        public string Tekst
        {
            get
            {
                return tekst;
            }

            set
            {
                tekst = value;
            }
        }
    }
}