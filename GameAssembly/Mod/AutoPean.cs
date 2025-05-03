using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod
{
	internal class AutoPean
	{
		public static AutoPean _Instance;

		public static bool isAutoRequestPean;

		public static long lastTimeRequestedPean;

		public static bool isAutoDonatePean;

		public static AutoPean getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new AutoPean();
			}
			return _Instance;
		}

		public static void update()
		{
			if (isAutoRequestPean)
			{
				autoRequestPean();
			}
			if (isAutoDonatePean)
			{
				autoDonatePean();
			}
		}

		private static void autoRequestPean()
		{
			if (mSystem.currentTimeMillis() - lastTimeRequestedPean >= 301000L)
			{
				lastTimeRequestedPean = mSystem.currentTimeMillis();
				Service.gI().clanMessage(1, "", -1);
			}
		}

		private static void autoDonatePean()
		{
			for (int i = 0; i < ClanMessage.vMessage.size(); i++)
			{
				ClanMessage clanMessage = (ClanMessage)ClanMessage.vMessage.elementAt(i);
				if (clanMessage.maxCap != 0 && clanMessage.playerName != global::Char.myCharz().cName && clanMessage.recieve != clanMessage.maxCap)
				{
					Service.gI().clanDonate(clanMessage.id);
					return;
				}
			}
		}
	}
}
