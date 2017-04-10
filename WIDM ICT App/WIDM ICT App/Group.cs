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

		public Group(int groupID)
		{
			this.groupID = groupID;
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
	}
}