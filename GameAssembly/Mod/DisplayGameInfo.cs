﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAssembly.Mod.Utils;

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
			paintListCharsInMap(g);
			paintListBosses(g);
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
			if (ch.isFreez)
			{
				mFont.tahoma_7b_red.drawString(g, "Bị TDHS: " + ch.freezSeconds.ToString() + " giây", GameCanvas.w / 2, 40, 2);
			}
		}

		public static void paintListCharsInMap(mGraphics g)
		{
			int num = 95;
			int widthRect = 142;
			int heightRect = 9;
			for (int i = 0; i < MainMod.listCharsInMap.Count; i++)
			{
				Tp.teleportToCharInList(widthRect, heightRect, i);
				global::Char @char = MainMod.listCharsInMap[i];
				g.setColor(2721889, 0.5f);
				g.fillRect(GameCanvas.w - widthRect, num + 2, widthRect - 2, heightRect);
				if (@char.cName != null && @char.cName != "" && !@char.isPet && !@char.isMiniPet && !@char.cName.StartsWith("#") && !@char.cName.StartsWith("$") && @char.cName != "Trọng tài")
				{
					string str = string.Concat(new object[]
					{
						 @char.cName,
						 " [",
						 NinjaUtil.getMoneys((long)@char.cHP),
						 "]"
					});
					bool flag;
					if (!(flag = isBoss(@char)))
					{
						str = string.Concat(new object[]
						{
							 @char.cName,
							 " [",
							 NinjaUtil.getMoneys((long)@char.cHP),
							 " - ",
							 @char.getGender(),
							 "]"
						});
					}
					if (global::Char.myCharz().charFocus != null && global::Char.myCharz().charFocus.cName == @char.cName)
					{
						g.setColor(14155776);
						g.drawLine(global::Char.myCharz().cx - GameScr.cmx, global::Char.myCharz().cy - GameScr.cmy + 1, @char.cx - GameScr.cmx, @char.cy - GameScr.cmy);
						mFont.tahoma_7b_yellow.drawString(g, (i + 1).ToString() + ". " + str, GameCanvas.w - widthRect + 2, num, 0);

						paintCharInfo(g, @char);
					}
					else
					{
						mFont.tahoma_7.drawString(g, (i + 1).ToString() + ". " + str, GameCanvas.w - widthRect + 2, num, 0);
					}
					num += heightRect + 1;
				}
			}
		}

		public static void paintListBosses(mGraphics g)
		{
			int num = 42;
			for (int i = 0; i < MainMod.listBosses.Count; i++)
			{
				g.setColor(2721889, 0.5f);
				g.fillRect(GameCanvas.w - 23, num + 2, 21, 9);
				MainMod.listBosses[i].paint(g, GameCanvas.w - 2, num, mFont.RIGHT);
				num += 10;
			}
		}
	}
}
