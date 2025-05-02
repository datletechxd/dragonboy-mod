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

		public static void paint(mGraphics g)
		{
			paintModInfo(g);
		}

		public static void paintModInfo(mGraphics g)
		{
			mFont.tahoma_7b_white.drawString(g, string.Concat(new string[]
			{
				"Map: ",
				TileMap.mapNames[TileMap.mapID],
				" [",
				TileMap.zoneID.ToString(),
				"]"
			}), 25, GameCanvas.h - 200, 0);
			mFont.tahoma_7b_white.drawString(g, "Time: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), 25, GameCanvas.h - 210, 0);
		} 

		public static bool isBoss(global::Char ch)
		{
			return ch.cName != null && ch.cName != "" && !ch.isPet && !ch.isMiniPet && char.IsUpper(char.Parse(ch.cName.Substring(0, 1))) && ch.cName != "Trọng tài" && !ch.cName.StartsWith("#") && !ch.cName.StartsWith("$");
		}

		public static void paintCharInfo(mGraphics g, global::Char ch)
		{
			mFont.tahoma_7b_red.drawString(g, string.Concat(new string[]
			{
				 ch.cName,
				 " [",
				 NinjaUtil.getMoneys((long)ch.cHP),
				 "/",
				 NinjaUtil.getMoneys((long)ch.cHPFull),
				 "]"
			}), GameCanvas.w / 2, 30, 2);
		}
	}
}
