using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class DisplayGameInfo
	{
		public static DisplayGameInfo _Instance;

		public static DisplayGameInfo getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new DisplayGameInfo();
			}
			return _Instance;
		}
	}
}
