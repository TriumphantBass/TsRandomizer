using System;
using Timespinner.GameAbstractions.Inventory;
using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Screens;
using TsRandomizer.Settings;
using TsRandomizer.IntermediateObjects.CustomItems;

namespace TsRandomizer.LevelObjects.Other
{
	[TimeSpinnerType("Timespinner.GameObjects.NPCs.QuartermasterNPC")]
	class SeykisNpc : LevelObject
	{
		MerchantInventory merchandiseInventory = new MerchantInventory();

		public SeykisNpc(Mobile typedObject, GameplayScreen gameplayScreen) : base(typedObject, gameplayScreen)
		{
		}

		protected override void Initialize(Seed seed, SettingCollection settings)
		{
			merchandiseInventory.AddItem(EInventoryRelicType.TimespinnerGear3);
			merchandiseInventory.AddItem(EInventoryEquipmentType.Sunglasses);
			merchandiseInventory.AddItem(EInventoryFamiliarType.Meyef); // TODO: needs inventory limit
			merchandiseInventory.AddItem(EInventoryOrbType.Flame, EOrbSlot.Melee);
			merchandiseInventory.AddItem(EInventoryOrbType.Barrier, EOrbSlot.Spell);
			merchandiseInventory.AddItem(EInventoryOrbType.Gun, EOrbSlot.Passive);
			merchandiseInventory.AddItem(EInventoryUseItemType.HiSandBottle);
			merchandiseInventory.AddItem(EInventoryEquipmentType.SecurityVisor);

			// Custom use items
			merchandiseInventory.AsDynamic()._useItemInventory.AddItem((int)CustomItem.GetIdentifier(CustomItemType.NeurotoxinTrap).ItemId); // TODO: need to figure out how to fire
			merchandiseInventory.AsDynamic()._useItemInventory.AddItem((int)CustomItem.GetIdentifier(CustomItemType.SandUp).ItemId);

			// Custom relics
			merchandiseInventory.AsDynamic()._relicInventory.AddItem((int)CustomItem.GetIdentifier(CustomItemType.CubeOfBodie).ItemId);
			merchandiseInventory.AsDynamic()._relicInventory.AddItem((int)CustomItem.GetIdentifier(CustomItemType.MysteriousWarpBeacon).ItemId);


			Dynamic.OpenShop(NPCBase.ENPCType.Quartermaster, merchandiseInventory);
		}
	}
}
