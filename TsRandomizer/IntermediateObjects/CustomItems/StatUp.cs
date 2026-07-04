using Timespinner.GameAbstractions.Gameplay;
using Timespinner.GameAbstractions.Inventory;
using TsRandomizer.Randomisation;
using TsRandomizer.Screens;

namespace TsRandomizer.IntermediateObjects.CustomItems
{
	abstract class StatUp : CustomItem
	{
		public override int AnimationIndex => 46; // TODO find proper stat numbers

		protected override bool RemoveFromInventory => false;

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
		public HpUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.HpUp)
		{
			SetDescription("Increases maximum HP.", null);
		}
	}

	class AuraUp : StatUp
	{
		public AuraUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.AuraUp)
		{
			SetDescription("Increases maximum aura.", null);
		}
	}

	class SandUp : StatUp
	{
		public SandUp(ItemUnlockingMap unlockingMap) : base(unlockingMap, CustomItemType.SandUp)
		{
			SetDescription("Increases maximum sand.", null);
		}
	}
}
