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

		public string GetMapName()
		{
			return TileMap.mapNames[MapID];
		}
	}
}
