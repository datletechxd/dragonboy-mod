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
			autoHarvestPean();
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

		public static void autoUsePeanForPet(string info)
		{
			if (info.Equals("Sư phụ ơi cho con đậu thần"))
			{
				GameScr.gI().doUseHP();
			}
		}

		private static void autoHarvestPean()
		{
			if (TileMap.mapID != 21 && TileMap.mapID != 22 && TileMap.mapID != 23)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < global::Char.myCharz().arrItemBox.Length; i++)
			{
				if (global::Char.myCharz().arrItemBox[i] != null && global::Char.myCharz().arrItemBox[i].template.type == 6)
				{
					num += global::Char.myCharz().arrItemBox[i].quantity;
				}
			}
			if (num < 20 && GameCanvas.gameTick % 100 == 0)
			{
				for (int j = 0; j < global::Char.myCharz().arrItemBag.Length; j++)
				{
					if (global::Char.myCharz().arrItemBag[j] != null && global::Char.myCharz().arrItemBag[j].template.type == 6)
					{
						Service.gI().getItem(1, (sbyte)j);
						break;
					}
				}
			}
			if (GameScr.gI().magicTree.currPeas > 0 && (GameScr.hpPotion < 10 || num < 20) && GameCanvas.gameTick % 200 == 0)
			{
				Service.gI().openMenu(4);
				Service.gI().menu(4, 0, 0);
			}
		}
	}
}
