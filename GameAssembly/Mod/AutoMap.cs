using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoMap
	{
		public static AutoMap _Instance;

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
