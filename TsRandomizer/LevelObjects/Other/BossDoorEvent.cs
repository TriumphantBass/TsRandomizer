using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Randomisation;

namespace TsRandomizer.LevelObjects.Other
{
	[TimeSpinnerType("Timespinner.GameObjects.Events.Doors.BossDoorEvent")]
	// ReSharper disable once UnusedMember.Global
	class BossDoorEvent : LevelObject
	{
		public BossDoorEvent(Mobile typedObject) : base(typedObject)
		{
		}

		protected override void Initialize(SeedOptions options, ItemLocationMap itemLocations)
		{
			if (Dynamic._isDemonDoor)
			{
				Dynamic._isDemonDoor = false;
				Dynamic.IsLocked = false;
			}
		}
	}
}
