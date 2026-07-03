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
				var shopMenuEntries = shopMenu._items; // (List<this.ShopMenuEntryType>)shopMenu; // < Timespinner.GameStateManagement.Screens.Shop.ShopMenuEntry >

				// populate from merchandise inventory instead TODO
				var meyef = new ItemIdentifier(EInventoryFamiliarType.Meyef);
				var newItem = new InventoryFamiliar(EInventoryFamiliarType.Meyef, null)
				{
					Experience = 1000,
				};
				var newMenuEntry = ShopMenuEntryType.CreateInstance(false, newItem, EInventoryCategoryType.Familiar);

				var newEntries = (IList)shopMenuEntries;
				newEntries.Add(newMenuEntry);
				// +		Entries	Count = 1	System.Collections.Generic.IList<Timespinner.GameStateManagement.MenuEntry> {System.Collections.Generic.List<Timespinner.GameStateManagement.MenuEntry>}
				shopMenu._items = newEntries.ToList(ShopMenuEntryType);
				var mainMenuEntry = newEntries.ToList(MainMenuEntryType)[1];
				((IList)shopMenu.Entries).Add(mainMenuEntry);

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

					// dynamicShopMenuEntry.ItemType = EInventoryCategoryType.Familiar;
					// dynamicShopMenuEntry.Item = new ItemIdentifier(EInventoryFamiliarType.Meyef);
				}
				/*shopMenu._items.AsDyna

				var entries = ((IList)Dynamic.MenuEntries)
				.Cast<object>()
				.Concat(menuEntry.AsTimeSpinnerMenuEntry())
				.ToList(MainMenuEntryType)

				this._relicMenuEntry = new MenuEntry(Loc.Get("shop_relics_header"))
				{
					Description = str
				};
				this._relicMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.ItemMenuEntrySelected);
				this.MenuEntries.Add(this._relicMenuEntry);
				ShopMenuEntryCollection menuEntryCollection = new ShopMenuEntryCollection(this._shopPriceModifier, new Action<ShopMenuEntry>(this.OnItemSelected), this.GCM.SpPauseMenu, this._isBuying);
				menuEntryCollection.AddEntries((IEnumerable<InventoryItem>)this._merchandiseInventory.RelicInventory.Inventory.Values, EInventoryCategoryType.Relic);
				this._categoryMenuCollections.Add(menuEntryCollection);
				this._subMenuCollections.Add((MenuEntryCollection)menuEntryCollection);

				((object)Dynamic._primaryMenuCollection).AsDynamic()._entries = entries;*/
			}
		}
	}
}
