using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameAssembly.Mod.Utils;

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
			AutoSkill.update();
			AutoPean.update();
		}

		public static bool onChatFromMe(String text)
		{
			if (text.Contains("ahsnm"))
			{
				AutoSkill.isAutoBuff = !AutoSkill.isAutoBuff;
				GameScr.info1.addInfo("Auto hồi sinh namec: " + (AutoSkill.isAutoBuff ? "On" : "Off"), 0);
				text = string.Empty;

				return true;
			}
			if (text.Contains("rp"))
			{
				AutoPean.isAutoRequestPean = !AutoPean.isAutoRequestPean;
				GameScr.info1.addInfo("Auto xin đậu: " + (AutoPean.isAutoRequestPean ? "On" : "Off"), 0);
				text = string.Empty;

				return true;
			}
			return false;
		}

		public static bool updateKey(int unused)
		{
			if (GameCanvas.keyAsciiPress == Hotkeys.H)
			{
				AutoSkill.isAutoBuff = !AutoSkill.isAutoBuff;
				if (AutoSkill.isAutoBuff)
				{
					new Thread(new ThreadStart(AutoSkill.autoUseSkillBuff)).Start();
				}
				GameScr.info1.addInfo("Auto hồi sinh namec: " + (AutoSkill.isAutoBuff ? "On" : "Off"), 0);
				return true;
			}
			return false;
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
