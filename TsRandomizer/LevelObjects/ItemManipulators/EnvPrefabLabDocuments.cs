using System;
using System.Linq;
using Timespinner.GameAbstractions.GameObjects;
using Timespinner.GameAbstractions.Gameplay;
using Timespinner.GameAbstractions.HUD;
using Timespinner.GameAbstractions.Inventory;
using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Randomisation;
using TsRandomizer.Screens;


namespace TsRandomizer.LevelObjects.ItemManipulators
{
	[TimeSpinnerType("Timespinner.GameObjects.Events.EnvironmentPrefabs.L11_Lab.EnvPrefabLabHistoricalDocuments")]
	// ReSharper disable once UnusedMember.Global
	class EnvPrefabLabDocuments : ItemManipulator
	{
		public EnvPrefabLabDocuments(Mobile typedObject, ItemLocation itemLocation) : base(typedObject, itemLocation)
		{
		}

		protected override void Initialize(SeedOptions options)
		{

		}

        protected override void OnUpdate(GameplayScreen gameplayScreen)
        {
            base.OnUpdate(gameplayScreen);
        }
    }
}
