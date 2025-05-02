using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class MainMod
	{
		public static MainMod _Instance;

		public static List<global::Char> listCharsInMap = new List<global::Char>();

		public static int runSpeed = 8;

		public static MainMod getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new MainMod();
			}
			return _Instance;
		}

		public static void update()
		{
			getListCharsInMap();
			global::Char.myCharz().cspeed = runSpeed;
		}

		private static void getListCharsInMap()
		{
			listCharsInMap.Clear();
			for (int i = 0; i < GameScr.vCharInMap.size(); i++)
			{
				global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
				if (@char.cName != null && @char.cName != "" && !@char.isPet && !@char.isMiniPet && !@char.cName.StartsWith("#") && !@char.cName.StartsWith("$") && @char.cName != "Trọng tài")
				{
					listCharsInMap.Add(@char);
				}
			}
		}
	}
}
