using System.Collections;
using System.Linq;
using Timespinner.GameAbstractions.Inventory;
using Timespinner.GameAbstractions.Saving;
using Timespinner.GameStateManagement.ScreenManager;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Timespinner.GameAbstractions;
using TsRandomizer.Commands;
using TsRandomizer.Drawables;
using TsRandomizer.Randomisation;
using TsRandomizer.Screens.Menu;
using TsRandomizer.Screens.SeedSelection;
using TsRandomizer.Settings;

namespace TsRandomizer.Screens
{
	[TimeSpinnerType("Timespinner.GameStateManagement.Screens.Shop.ShopMenuScreen")]
	// ReSharper disable once UnusedMember.Global
	class ShopMenuScreen : Screen
	{
		static readonly Type ShopMenuEntryType =
			TimeSpinnerType.Get("Timespinner.GameStateManagement.Screens.Shop.ShopMenuEntry");
		static readonly Type MainMenuEntryType = TimeSpinnerType
			.Get("Timespinner.GameStateManagement.MenuEntry");

		public ShopMenuScreen(ScreenManager screenManager, GameScreen screen) : base(screenManager, screen)
		{
			var gameSettings = ((GameSave)Dynamic._saveFile).GetSettings();

			// Menu count varies on relics/items/equipment etc. being in inventory
			// Last menu is always helper functions that don't have an _items
			// but aren't otherwise distinguishable
			foreach (var i in Enumerable.Range(0, ((IList)Dynamic._subMenuCollections).Count - 1))
			{
				var shopMenu = ((IList)Dynamic._subMenuCollections)[i].AsDynamic();

				// Populate types that aren't handled in the vanilla game.
				// TODO make this in its own function
				if (i == 0 && shopMenu._isBuying) {
					var shopMenuEntries = shopMenu._items; // (List<this.ShopMenuEntryType>)shopMenu; // < Timespinner.GameStateManagement.Screens.Shop.ShopMenuEntry >
														   // populate from merchandise inventory instead TODO
														   // Dynamic._merchandiseInventory
														   // TODO Move to orb inventory
					var familiars = Dynamic._merchandiseInventory.FamiliarInventory;
					// TODO: handle stats

					foreach (var familiar in familiars.Inventory)
					{
						var newMenuEntry = ShopMenuEntryType.CreateInstance(false, (InventoryFamiliar)familiar.Value, EInventoryCategoryType.Familiar);

						var newEntries = (IList)shopMenuEntries;
						newEntries.Add(newMenuEntry);
						shopMenu._items = newEntries.ToList(ShopMenuEntryType);
						var mainMenuEntry = newEntries.ToList(MainMenuEntryType)[newEntries.Count - 1];
						((IList)shopMenu.Entries).Add(mainMenuEntry);
					}

				}
				// TODO make this in its own function
				// TODO check that this is an orb menu
				if (i == 1 && shopMenu._isBuying)
				{
					var shopMenuEntries = shopMenu._items; // (List<this.ShopMenuEntryType>)shopMenu; // < Timespinner.GameStateManagement.Screens.Shop.ShopMenuEntry >
														   // populate from merchandise inventory instead TODO
														   // Dynamic._merchandiseInventory
														   // TODO Move to orb inventory
					var orbs = Dynamic._merchandiseInventory.OrbInventory;
					foreach (var orb in orbs.Inventory)
					{
						// Ignore non-melee orbs, vanilla logic already populates them
						if (orb.Value.IsSpellUnlocked || orb.Value.IsPassiveUnlocked)
							continue;

						var newMenuEntry = ShopMenuEntryType.CreateInstance(false, (InventoryOrb)orb.Value, EOrbSlot.Melee);

						var newEntries = (IList)shopMenuEntries;
						newEntries.Add(newMenuEntry);
						shopMenu._items = newEntries.ToList(ShopMenuEntryType);
						var mainMenuEntry = newEntries.ToList(MainMenuEntryType)[newEntries.Count - 1];
						((IList)shopMenu.Entries).Add(mainMenuEntry);
					}
				}

				foreach (var shopMenuEntry in shopMenu._items)
				{
					var dynamicShopMenuEntry = ((object)shopMenuEntry).AsDynamic();

					var item = (InventoryItem)dynamicShopMenuEntry.Item;
					if (item.NameKey == "inv_use_MagicMarbles")
					{
						item.IsSellable = false;
						dynamicShopMenuEntry.ShopPrice = -1;
					}
					
					int currentPrice = dynamicShopMenuEntry.ShopPrice;
					if (currentPrice == 0)
					{
						// Set a price for "priceless" items
						dynamicShopMenuEntry.ShopPrice = 2000;
						currentPrice = dynamicShopMenuEntry.ShopPrice;
					}
					dynamicShopMenuEntry.ShopPrice = (int)(currentPrice * gameSettings.ShopMultiplier.Value);
				}
			}
		}
	}
}
