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
	abstract class Gebruiker
	{

		private int gebruikersID;
		private string username;
		private string password;
		private string naam;
		private int geslacht;
		private string geboortedatum;

		public Gebruiker(int gebruikersID, string username, string password, string naam, int geslacht, string geboortedatum)
		{
			this.gebruikersID = gebruikersID;
			this.username = username;
			this.password = password;
			this.naam = naam;
			this.geslacht = geslacht;
			this.geboortedatum = geboortedatum;
		}

		public int GebruikersID
		{
			get
			{
				return gebruikersID;
			}

			set
			{
				gebruikersID = value;
			}
		}

		public string Username
		{
			get
			{
				return username;
			}

			set
			{
				username = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}

			set
			{
				password = value;
			}
		}

		public string Naam
		{
			get
			{
				return naam;
			}

			set
			{
				naam = value;
			}
		}

		public int Geslacht
		{
			get
			{
				return geslacht;
			}

			set
			{
				geslacht = value;
			}
		}

		public string Geboortedatum
		{
			get
			{
				return geboortedatum;
			}

			set
			{
				geboortedatum = value;
			}
		}
	}
}