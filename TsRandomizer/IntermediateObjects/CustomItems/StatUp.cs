using Timespinner.GameAbstractions.Gameplay;
using Timespinner.GameAbstractions.Inventory;
using TsRandomizer.Randomisation;
using TsRandomizer.Screens;
using TsRandomizer.Extensions;

// todo fix imports
using System;
using System.Linq;
using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.IntermediateObjects;
using System.Collections.Generic;
using Newtonsoft.Json;
using Timespinner.GameAbstractions.Saving;
using TsRandomizer.Settings;


namespace TsRandomizer.IntermediateObjects.CustomItems
{
	abstract class StatUp : CustomItem
	{
		public static readonly Type ToasterType = TimeSpinnerType.Get("Timespinner.GameStateManagement.Screens.InGame.EToastType");

		protected override bool RemoveFromInventory => true;

		public StatUp(ItemUnlockingMap unlockingMap, CustomItemType itemType) : base(unlockingMap, itemType)
		{
		}

		internal override void OnPickup(Level level, GameplayScreen gameplayScreen)
		{
			base.OnPickup(level, gameplayScreen);
			// TODO: use existing stat items for this
		} 
	}
	
	class HpUp : StatUp
	{
		public override int AnimationIndex => 24;
		public HpUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.HpUp)
		{
			SetDescription("Increases maximum HP.", null);
		}

		internal override void OnPickup(Level level, GameplayScreen gameplayScreen)
		{
			base.OnPickup(level, gameplayScreen);
			level.AsDynamic().RequestToastPopup(ToasterType.GetEnumValue("Health"), 0);
			level.GameSave.AddStat(level, EItemType.MaxHP);
		}
	}

	class AuraUp : StatUp
	{
		public override int AnimationIndex => 25;
		public AuraUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.AuraUp)
		{
			SetDescription("Increases maximum aura.", null);
		}

		internal override void OnPickup(Level level, GameplayScreen gameplayScreen)
		{
			base.OnPickup(level, gameplayScreen);
			level.AsDynamic().RequestToastPopup(ToasterType.GetEnumValue("Aura"), 0);
			level.GameSave.AddStat(level, EItemType.MaxAura);
		}
	}

	class SandUp : StatUp
	{
		public override int AnimationIndex => 26;
		public SandUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.SandUp)
		{
			SetDescription("Increases maximum sand.", null);
		}

		internal override void OnPickup(Level level, GameplayScreen gameplayScreen)
		{
			base.OnPickup(level, gameplayScreen);
			level.AsDynamic().RequestToastPopup(ToasterType.GetEnumValue("Sand"), 0);
			level.GameSave.AddStat(level, EItemType.MaxSand);
		}
	}
}
