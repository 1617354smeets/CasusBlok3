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
	class Group
	{

		private int groupID;
        private int groepscore;
        private List<int> volgorde;
        private List<int> opdrachtscore;
        private int huidigeOpdracht = 1;
        private int aantalopdrachten;


		public Group(int groupID, List<int> opdrachtscore, List<int> volgorde)
		{
			this.groupID = groupID;
            this.volgorde = volgorde;
            this.opdrachtscore = opdrachtscore;
            aantalopdrachten = volgorde.Count;
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

        public int HuidigeOpdracht
        {
            get
            {
                return huidigeOpdracht;
            }
        }


        public int Aantalopdrachten
        {
            get
            {
                return aantalopdrachten;
            }

            
        }
        // ga naar de volgende opdracht
        public void update(int opdracht, int score)
        {
            opdrachtscore[opdracht] = score;
            huidigeOpdracht++;

        }

        

        public void Groepwijzigen()
        {
            //Hier komt de code die ervoor zorgt dat de groep kan worden aangepast.

        }
	}
}