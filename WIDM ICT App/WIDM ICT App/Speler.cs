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
	class Speler : Gebruiker
	{

		private bool mol;
		private int groepID;
		private Molboekclass boekje;

		public bool Mol
		{
			get
			{
				return mol;
			}

			set
			{
				mol = value;
			}
		}

		public int GroepID
		{
			get
			{
				return groepID;
			}

			set
			{
				groepID = value;
			}
		}

		public Molboekclass Boekje
		{
			get
			{
				return boekje;
			}

			set
			{
				boekje = value;
			}
		}

		public Speler(int gebruikersID, string username, string password, string naam, int geslacht, string geboortedatum) : base(gebruikersID, username, password, naam, geslacht, geboortedatum)
		{
			Mol = false;
		}

	}
}