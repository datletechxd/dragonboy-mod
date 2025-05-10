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

		public Waypoint getWayPoint()
		{
			int num = 0;
			Waypoint waypoint;
			while (true)
			{
				if (num < TileMap.vGo.size())
				{
					waypoint = (Waypoint)TileMap.vGo.elementAt(num);
					if (getMapName().Equals(getMapName(waypoint.popup)))
						break;
					num++;
					continue;
				}
				return null;
			}
			return waypoint;
		}

		public void teleportTo(int x, int y)
		{
			if (GameScr.canAutoPlay)
			{
				Char.myCharz().cx = x;
				Char.myCharz().cy = y;
				Service.gI().charMove();
				return;
			}
			Char.myCharz().cx = x;
			Char.myCharz().cy = y;
			Service.gI().charMove();
			Char.myCharz().cx = x;
			Char.myCharz().cy = y + 1;
			Service.gI().charMove();
			Char.myCharz().cx = x;
			Char.myCharz().cy = y;
			Service.gI().charMove();
		}

		public void enterWaypoint(Waypoint waypoint)
		{
			int num = ((waypoint.maxX < 60) ? 15 : ((waypoint.minX <= TileMap.pxw - 60) ? ((waypoint.minX + waypoint.maxX) / 2) : (TileMap.pxw - 15)));
			int maxY = waypoint.maxY;
			if (num != -1 && maxY != -1)
			{
				teleportTo(num, maxY);
				if (waypoint.isOffline)
					Service.gI().getMapOffline();
				else
					Service.gI().requestChangeMap();
			}
			else
				GameScr.info1.addInfo("Có lỗi xảy ra", 0);
		}
	}
}
