using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod.Utils
{
	internal class Teleport
	{
		public static void teleportCoordinates(int x, int y)
		{
			global::Char.myCharz().cx = x;
			global::Char.myCharz().cy = y;
			Service.gI().charMove();
		}

		public static void teleportToFocus()
		{
			if (global::Char.myCharz().charFocus != null)
			{
				teleportCoordinates(global::Char.myCharz().charFocus.cx, global::Char.myCharz().charFocus.cy);
				return;
			}
			if (global::Char.myCharz().npcFocus != null)
			{
				teleportCoordinates(global::Char.myCharz().npcFocus.cx, global::Char.myCharz().npcFocus.cy - 3);
				return;
			}
			GameScr.info1.addInfo("Không Có Mục Tiêu!", 0);
		}
	}
}
