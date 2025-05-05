using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod.Utils
{
	internal class Boss
	{
		public int getMapID(string mapName)
		{
			for (int i = 0; i < TileMap.mapNames.Length; i++)
			{
				if (TileMap.mapNames[i].Equals(mapName))
				{
					return i;
				}
			}
			return -1;
		}
	}
}
