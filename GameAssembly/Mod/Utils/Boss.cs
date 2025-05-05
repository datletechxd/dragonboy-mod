using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod.Utils
{
	internal class Boss
	{
		public string NameBoss;

		public string MapName;

		public int MapId;

		public DateTime AppearTime;

		public Boss(string chatVip)
		{
			chatVip = chatVip.Replace("BOSS ", "").Replace(" vừa xuất hiện tại ", "|").Replace(" appear at ", "|");
			string[] array = chatVip.Split(new char[]
			{
				 '|'
			});
			this.NameBoss = array[0].Trim();
			this.MapName = array[1].Trim();
			this.MapId = this.getMapID(this.MapName);
			this.AppearTime = DateTime.Now;
		}

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
