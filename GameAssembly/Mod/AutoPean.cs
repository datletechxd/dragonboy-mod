using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoPean
	{
		public static AutoPean _Instance;

		public static AutoPean getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new AutoPean();
			}
			return _Instance;
		}
	}
}
