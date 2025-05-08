using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoMap
	{
		public static AutoMap _Instance;

		private static Dictionary<string, int[]> planetDictionary;

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

		static AutoMap()
		{
			idMapsNamek = new int[15]
			{
				43, 22, 7, 8, 9, 11, 12, 13, 10, 31,
				32, 33, 34, 43, 25
			};
			idMapsXayda = new int[20]
			{
				44, 23, 14, 15, 16, 17, 18, 20, 19, 35,
				36, 37, 38, 52, 44, 26, 84, 113, 127, 129
			};
			idMapsTraiDat = new int[29]
			{
				42, 21, 0, 1, 2, 3, 4, 5, 6, 27,
				28, 29, 30, 47, 42, 24, 46, 45, 48, 53,
				58, 59, 60, 61, 62, 55, 56, 54, 57
			};
			idMapsTuongLai = new int[10] { 102, 92, 93, 94, 96, 97, 98, 99, 100, 103 };
			idMapsCold = new int[6] { 109, 108, 107, 110, 106, 105 };
			idMapsNappa = new int[23]
			{
				68, 69, 70, 71, 72, 64, 65, 63, 66, 67,
				73, 74, 75, 76, 77, 81, 82, 83, 79, 80,
				131, 132, 133
			};
		}
	}
}
