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

	public class User
	{
		

		private string username;
		private string password;
		private bool admin;
		private int groupID;
		private bool mol;
		private string naam;
		private string geboortedatum;
		private int geslacht;
		private int vraag1, vraag2, vraag3, vraag4, vraag5, vraag6, vraag7, vraag8;

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

		public bool Admin
		{
			get
			{
				return admin;
			}

			set
			{
				admin = value;
			}
		}

		public int GroupID
		{
			get
			{
				return groupID;
			}

			set
			{
				groupID = value;
			}
		}

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

		public int Vraag1
		{
			get
			{
				return vraag1;
			}

			set
			{
				vraag1 = value;
			}
		}

		public int Vraag2
		{
			get
			{
				return vraag2;
			}

			set
			{
				vraag2 = value;
			}
		}

		public int Vraag3
		{
			get
			{
				return vraag3;
			}

			set
			{
				vraag3 = value;
			}
		}

		public int Vraag4
		{
			get
			{
				return vraag4;
			}

			set
			{
				vraag4 = value;
			}
		}

		public int Vraag5
		{
			get
			{
				return vraag5;
			}

			set
			{
				vraag5 = value;
			}
		}

		public int Vraag6
		{
			get
			{
				return vraag6;
			}

			set
			{
				vraag6 = value;
			}
		}

		public int Vraag7
		{
			get
			{
				return vraag7;
			}

			set
			{
				vraag7 = value;
			}
		}

		public int Vraag8
		{
			get
			{
				return vraag8;
			}

			set
			{
				vraag8 = value;
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

		public User(string username, string password, bool admin, int groupID, bool mol, string naam, string geboortedatum, int geslacht, int vraag1, int vraag2, int vraag3, int vraag4, int vraag5, int vraag6, int vraag7, int vraag8)
		{
			this.Username = username;
			this.Password = password;
			this.Admin = admin;
			this.GroupID = groupID;
			this.Mol = mol;
			this.Naam = naam;
			this.Geboortedatum = geboortedatum;
			this.Geslacht = geslacht;
			this.Vraag1 = vraag1;
			this.Vraag2 = vraag2;
			this.Vraag3 = vraag3;
			this.Vraag4 = vraag4;
			this.Vraag5 = vraag5;
			this.Vraag6 = vraag6;
			this.Vraag7 = vraag7;
			this.Vraag8 = vraag8;
		}

	}
}