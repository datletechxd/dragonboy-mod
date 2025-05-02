using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoSkill
	{
		public static AutoSkill _Instance;

		public static AutoSkill getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new AutoSkill();
			}
			return _Instance;
		}
	}
}
