using System;
using Timespinner.GameAbstractions.Inventory;
using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Screens;
using TsRandomizer.Settings;

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
			merchandiseInventory.AddItem(EInventoryFamiliarType.Meyef);
			merchandiseInventory.AddItem(EInventoryOrbType.Flame, EOrbSlot.Melee);
			merchandiseInventory.AddItem(EInventoryOrbType.Barrier, EOrbSlot.Spell);
			merchandiseInventory.AddItem(EInventoryOrbType.Gun, EOrbSlot.Passive);
			merchandiseInventory.AddItem(EInventoryUseItemType.HiSandBottle);
			merchandiseInventory.AddItem(EInventoryEquipmentType.SecurityVisor);
			Dynamic.OpenShop(NPCBase.ENPCType.Quartermaster, merchandiseInventory);
		}
	}
}
