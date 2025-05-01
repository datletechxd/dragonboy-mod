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
			mFont.tahoma_7b_white.drawString(g, string.Concat(new string[]
			{
				"Map: ",
				TileMap.mapNames[TileMap.mapID],
				" [",
				TileMap.zoneID.ToString(),
				"]"
			}), 25, GameCanvas.h - 200, 0);
			mFont.tahoma_7b_white.drawString(g, "Time: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), 25, GameCanvas.h - 210, 0);
			int num = GameCanvas.h - 180;
		}
	}
}
