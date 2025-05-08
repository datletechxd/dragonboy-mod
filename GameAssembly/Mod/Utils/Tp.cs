using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAssembly.Mod.Utils
{
	internal class Tp
	{
		public static void teleportCoordinates(int x, int y)
		{
			global::Char.myCharz().cx = x;
			global::Char.myCharz().cy = y;
			Service.gI().charMove();
		}

		public static void teleportToTarget()
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
			if (global::Char.myCharz().itemFocus != null)
			{
				teleportCoordinates(global::Char.myCharz().itemFocus.x, global::Char.myCharz().itemFocus.y);
				return;
			}
			if (global::Char.myCharz().mobFocus != null)
			{
				teleportCoordinates(global::Char.myCharz().mobFocus.x, global::Char.myCharz().mobFocus.y);
				return;
			}
			GameScr.info1.addInfo("Không Có Mục Tiêu!", 0);
		}

		public static void teleportToCharInList(int widthRect, int heightRect, int i)
		{
			if (GameCanvas.isPointerHoldIn(GameCanvas.w - widthRect, 95 + (heightRect + 1) * i, widthRect, heightRect))
			{
				GameCanvas.isPointerJustDown = false;
				if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
				{
					global::Char @char = MainMod.listCharsInMap[i];
					if (global::Char.myCharz().charFocus != null && global::Char.myCharz().charFocus.cName == @char.cName)
					{
						teleportCoordinates(global::Char.myCharz().charFocus.cx, global::Char.myCharz().charFocus.cy);
					}
					else
					{
						Char.myCharz().mobFocus = null;
						Char.myCharz().npcFocus = null;
						Char.myCharz().itemFocus = null;
						Char.myCharz().charFocus = null;
						Char.myCharz().charFocus = @char;
					}
					global::Char.myCharz().currentMovePoint = null;
					GameCanvas.clearAllPointerEvent();
					return;
				}
			}
		}
	}
}
