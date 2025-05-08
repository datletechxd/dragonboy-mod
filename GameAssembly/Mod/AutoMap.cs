using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoMap
	{
		public static AutoMap _Instance;

		private static int[] idMapsNamek;

		private static int[] idMapsXayda;

		private static int[] idMapsTraiDat;

		private static int[] idMapsTuongLai;

		private static int[] idMapsCold;

		private static int[] idMapsNappa;

		public static AutoMap getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new AutoMap();
			}
			return _Instance;
		}
	}
}
