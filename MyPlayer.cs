using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanityMusic
{
	public class MyPlayer : ModPlayer
	{
		private Dictionary<int, int> itemToMusicValue;

		public override void Initialize()
		{
			FieldInfo itemToMusicField = typeof(SoundLoader).GetField("itemToMusic", BindingFlags.Static | BindingFlags.NonPublic);
			itemToMusicValue = (Dictionary<int, int>)itemToMusicField.GetValue(null);
		}

		public override void UpdateVanityAccessories()
		{
			for (int accessorySlot = 13; accessorySlot < 18 + Main.LocalPlayer.extraAccessorySlots; accessorySlot++)
			{
				Item item = Main.LocalPlayer.armor[accessorySlot];

				if (item.type >= ItemID.MusicBoxOverworldDay && item.type <= ItemID.MusicBoxBoss3)
					Main.musicBox2 = item.type - ItemID.MusicBoxOverworldDay;

				if (item.type >= ItemID.MusicBoxSnow && item.type <= ItemID.MusicBoxEclipse)
					Main.musicBox2 = item.type - ItemID.MusicBoxSnow + 13;

				if (item.type >= ItemID.MusicBoxPumpkinMoon && item.type <= ItemID.MusicBoxFrostMoon)
					Main.musicBox2 = item.type - ItemID.MusicBoxPumpkinMoon + 28;

				if (item.type >= ItemID.MusicBoxMartians && item.type <= ItemID.MusicBoxHell)
					Main.musicBox2 = item.type - ItemID.MusicBoxMartians + 33;

				if (item.type == ItemID.MusicBoxTowers || item.type == ItemID.MusicBoxGoblins)
					Main.musicBox2 = item.type - ItemID.MusicBoxTowers + 36;

				switch (item.type)
				{
					case ItemID.MusicBoxMushrooms:
						Main.musicBox2 = 27;
						break;

					case ItemID.MusicBoxUndergroundCrimson:
						Main.musicBox2 = 31;
						break;

					case ItemID.MusicBoxLunarBoss:
						Main.musicBox2 = 32;
						break;

					case ItemID.MusicBoxSandstorm:
						Main.musicBox2 = 38;
						break;

					case ItemID.MusicBoxDD2:
						Main.musicBox2 = 39;
						break;
				}

				if (itemToMusicValue.ContainsKey(item.type))
					Main.musicBox2 = itemToMusicValue[item.type];
			}
		}
	}
}