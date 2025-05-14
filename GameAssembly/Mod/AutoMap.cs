using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAssembly.Mod.Utils;

namespace GameAssembly.Mod
{
	internal class AutoMap : IActionListener
	{
		public static AutoMap _Instance;

		private static Dictionary<string, int[]> planetDictionary;

		private static Dictionary<int, List<NextMap>> linkMaps;

		private static int[] idMapsNamek;

		private static int[] idMapsXayda;

		private static int[] idMapsTraiDat;

		private static int[] idMapsTuongLai;

		private static int[] idMapsCold;

		private static int[] idMapsNappa;

		private static bool isXmaping;

		private static int idMapEnd;

		public static AutoMap getInstance()
		{
			if (_Instance == null)
			{
				_Instance = new AutoMap();
			}
			return _Instance;
		}

		static AutoMap()
		{
			idMapsNamek = new int[15]
			{
				43, 22, 7, 8, 9, 11, 12, 13, 10, 31,
				32, 33, 34, 43, 25
			};
			idMapsXayda = new int[20]
			{
				44, 23, 14, 15, 16, 17, 18, 20, 19, 35,
				36, 37, 38, 52, 44, 26, 84, 113, 127, 129
			};
			idMapsTraiDat = new int[29]
			{
				42, 21, 0, 1, 2, 3, 4, 5, 6, 27,
				28, 29, 30, 47, 42, 24, 46, 45, 48, 53,
				58, 59, 60, 61, 62, 55, 56, 54, 57
			};
			idMapsTuongLai = new int[10] 
			{ 
				102, 92, 93, 94, 96, 97, 98, 99, 100, 103 
			};
			idMapsCold = new int[6] 
			{ 
				109, 108, 107, 110, 106, 105 
			};
			idMapsNappa = new int[23]
			{
				68, 69, 70, 71, 72, 64, 65, 63, 66, 67,
				73, 74, 75, 76, 77, 81, 82, 83, 79, 80,
				131, 132, 133
			};
			addPlanetToDictionary();
			loadLinkMaps();
			loadLinkNPCInMaps();
		}

		public void perform(int idAction, object p)
		{
			switch (idAction)
			{
				case 1:
					showMapsMenu((int[])p);
					break;
				}
			}

		public static void showPlanetsMenu()
		{
			MyVector myVector = new MyVector();
			foreach (KeyValuePair<string, int[]> item in planetDictionary)
			{
				myVector.addElement(new Command(item.Key, getInstance(), 1, item.Value));
			}
			GameCanvas.menu.startAt(myVector, 3);
		}

		private static void showMapsMenu(int[] mapIDs)
		{
			MyVector myVector = new MyVector();
			for (int i = 0; i < mapIDs.Length; i++)
			{
				if ((Char.myCharz().cgender != 0 || (mapIDs[i] != 22 && mapIDs[i] != 23)) && (Char.myCharz().cgender != 1 || (mapIDs[i] != 21 && mapIDs[i] != 23)) && (Char.myCharz().cgender != 2 || (mapIDs[i] != 21 && mapIDs[i] != 22)))
					myVector.addElement(getMapName(mapIDs[i]));
			}
			GameCanvas.menu.startAt(myVector, 3);
		}

		private static void addPlanetToDictionary()
		{
			planetDictionary.Add("Trái đất", idMapsTraiDat);
			planetDictionary.Add("Namếc", idMapsNamek);
			planetDictionary.Add("Xayda", idMapsXayda);
			planetDictionary.Add("Fide", idMapsNappa);
			planetDictionary.Add("Tương lai", idMapsTuongLai);
			planetDictionary.Add("Cold", idMapsCold);
		}

		private static void addLinkMaps(params int[] link)
		{
			for (int i = 0; i < link.Length; i++)
			{
				if (!linkMaps.ContainsKey(link[i]))
					linkMaps.Add(link[i], new List<NextMap>());
				if (i != 0)
					linkMaps[link[i]].Add(new NextMap(link[i - 1], -1, -1));
				if (i != link.Length - 1)
					linkMaps[link[i]].Add(new NextMap(link[i + 1], -1, -1));
			}
		}

		private static void loadLinkMaps()
		{
			addLinkMaps(0, 21);
			addLinkMaps(1, 47);
			addLinkMaps(47, 111);
			addLinkMaps(2, 24);
			addLinkMaps(5, 29);
			addLinkMaps(7, 22);
			addLinkMaps(9, 25);
			addLinkMaps(13, 33);
			addLinkMaps(14, 23);
			addLinkMaps(16, 26);
			addLinkMaps(20, 37);
			addLinkMaps(39, 21);
			addLinkMaps(40, 22);
			addLinkMaps(41, 23);
			addLinkMaps(109, 105);
			addLinkMaps(109, 106);
			addLinkMaps(106, 107);
			addLinkMaps(108, 105);
			addLinkMaps(80, 105);
			addLinkMaps(3, 27, 28, 29, 30);
			addLinkMaps(11, 31, 32, 33, 34);
			addLinkMaps(17, 35, 36, 37, 38);
			addLinkMaps(109, 108, 107, 110, 106);
			addLinkMaps(47, 46, 45, 48);
			addLinkMaps(131, 132, 133);
			addLinkMaps(42, 0, 1, 2, 3, 4, 5, 6);
			addLinkMaps(43, 7, 8, 9, 11, 12, 13, 10);
			addLinkMaps(52, 44, 14, 15, 16, 17, 18, 20, 19);
			addLinkMaps(53, 58, 59, 60, 61, 62, 55, 56, 54, 57);
			addLinkMaps(68, 69, 70, 71, 72, 64, 65, 63, 66, 67, 73, 74, 75, 76, 77, 81, 82, 83, 79, 80);
			addLinkMaps(102, 92, 93, 94, 96, 97, 98, 99, 100, 103);
		}

		private static void addLinkNPCInMaps(int currentMapID, int nextMapID, int npcID, int select)
		{
			if (!linkMaps.ContainsKey(currentMapID))
				linkMaps.Add(currentMapID, new List<NextMap>());
			linkMaps[currentMapID].Add(new NextMap(nextMapID, npcID, select));
		}

		private static void loadLinkNPCInMaps()
		{
			addLinkNPCInMaps(19, 68, 12, 1);
			addLinkNPCInMaps(19, 109, 12, 0);
			addLinkNPCInMaps(24, 25, 10, 0);
			addLinkNPCInMaps(24, 26, 10, 1);
			addLinkNPCInMaps(24, 84, 10, 2);
			addLinkNPCInMaps(25, 24, 11, 0);
			addLinkNPCInMaps(25, 26, 11, 1);
			addLinkNPCInMaps(25, 84, 11, 2);
			addLinkNPCInMaps(26, 24, 12, 0);
			addLinkNPCInMaps(26, 25, 12, 1);
			addLinkNPCInMaps(26, 84, 12, 2);
			addLinkNPCInMaps(27, 102, 38, 1);
			addLinkNPCInMaps(27, 53, 25, 0);
			addLinkNPCInMaps(28, 102, 38, 1);
			addLinkNPCInMaps(29, 102, 38, 1);
			addLinkNPCInMaps(45, 46, 19, 3);
			addLinkNPCInMaps(52, 127, 44, 0);
			addLinkNPCInMaps(52, 129, 23, 3);
			addLinkNPCInMaps(52, 113, 23, 2);
			addLinkNPCInMaps(68, 19, 12, 0);
			addLinkNPCInMaps(80, 131, 60, 0);
			addLinkNPCInMaps(102, 27, 38, 1);
			addLinkNPCInMaps(113, 52, 22, 4);
			addLinkNPCInMaps(127, 52, 44, 2);
			addLinkNPCInMaps(129, 52, 23, 3);
			addLinkNPCInMaps(131, 80, 60, 1);
		}

		private static string getMapName(int mapID)
		{
			switch (mapID)
			{
				case 129:
					return TileMap.mapNames[mapID] + " 23\n[" + mapID + "]";
				default:
					return TileMap.mapNames[mapID] + "\n[" + mapID + "]";
				case 113:
					return string.Concat(new object[3] { "Siêu hạng\n[", mapID, "]" });
			}
		}

		public static void startAutoMap(int mapID)
		{
			isXmaping = true;
			idMapEnd = mapID;
		}

		public static void finishAutoMap()
		{
			isXmaping = false;
		}
	}
}
