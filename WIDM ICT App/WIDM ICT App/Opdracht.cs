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
	class Opdracht
	{

		private int opdrachtNummer, scoreMax, time;
		private double coordX, coordY;
		private string beschrijving;

		public int OpdrachtNummer
		{
			get
			{
				return opdrachtNummer;
			}

			set
			{
				opdrachtNummer = value;
			}
		}

		public int ScoreMax
		{
			get
			{
				return scoreMax;
			}

			set
			{
				scoreMax = value;
			}
		}

		public int Time
		{
			get
			{
				return time;
			}

			set
			{
				time = value;
			}
		}

		public double CoordX
		{
			get
			{
				return coordX;
			}

			set
			{
				coordX = value;
			}
		}

		public double CoordY
		{
			get
			{
				return coordY;
			}

			set
			{
				coordY = value;
			}
		}

		public string Beschrijving
		{
			get
			{
				return beschrijving;
			}

			set
			{
				beschrijving = value;
			}
		}

		public Opdracht(int opdrachtNummer, Double coordX, Double coordY, int scoreMax, int time, string beschrijving)
		{
			this.OpdrachtNummer = opdrachtNummer;
			this.CoordX = coordX;
			this.CoordY = coordY;
			this.ScoreMax = scoreMax;
			this.Time = time;
			this.Beschrijving = beschrijving;
		}
	}
}