using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Screens;


namespace TsRandomizer.LevelObjects.Other
{
	[TimeSpinnerType("Timespinner.GameObjects.Events.Doors.GyrePortalEvent")]
	// ReSharper disable once UnusedMember.Global
	class GyrePortalEvent : LevelObject
	{
		public GyrePortalEvent(Mobile typedObject) : base(typedObject)
		{
			Dynamic._isUsable = true;
		}
    }
}
