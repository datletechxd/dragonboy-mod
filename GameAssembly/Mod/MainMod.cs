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

		public static List<Boss> listBosses = new List<Boss>();

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
			if (text.Equals("ahsnm"))
			{
				AutoSkill.isAutoBuff = !AutoSkill.isAutoBuff;
				GameScr.info1.addInfo("Auto hồi sinh namec: " + (AutoSkill.isAutoBuff ? "On" : "Off"), 0);
				text = string.Empty;
			}
			if (text.Equals("xindau"))
			{
				AutoPean.isAutoRequestPean = !AutoPean.isAutoRequestPean;
				GameScr.info1.addInfo("Auto xin đậu: " + (AutoPean.isAutoRequestPean ? "On" : "Off"), 0);
				text = string.Empty;
			}
			if (text.Equals("dp"))
			{
				AutoPean.isAutoDonatePean = !AutoPean.isAutoDonatePean;
				GameScr.info1.addInfo("Auto cho đậu: " + (AutoPean.isAutoDonatePean ? "On" : "Off"), 0);
				text = string.Empty;
			}
			else
			{
				return false;
			}
			return true;
		}

		public static bool updateKey(int unused)
		{
			if (GameCanvas.keyAsciiPress == Hotkeys.H)
			{
				AutoSkill.isAutoBuff = !AutoSkill.isAutoBuff;
				GameScr.info1.addInfo("Auto hồi sinh namec: " + (AutoSkill.isAutoBuff ? "On" : "Off"), 0);

				return true;
			}
			if (GameCanvas.keyAsciiPress == Hotkeys.L)
			{
				GameCanvas.loginScr.backToRegister();

				return true;
			}
			if (GameCanvas.keyAsciiPress == Hotkeys.T)
			{
				Tp.teleportToTarget();
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
