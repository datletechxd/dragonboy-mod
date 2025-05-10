using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod.Utils
{
	internal class NextMap
	{
		public int MapID;

		public int Npc;

		public int Index;

		public NextMap(int mapID, int npcID, int index)
		{
			MapID = mapID;
			Npc = npcID;
			Index = index;
		}

		public string getMapName()
		{
			return TileMap.mapNames[MapID];
		}

		public string getMapName(PopUp popup)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < popup.says.Length; i++)
			{
				stringBuilder.Append(popup.says[i]);
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString().Trim();
		}
	}
}
