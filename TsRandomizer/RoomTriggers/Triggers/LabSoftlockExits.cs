﻿using Microsoft.Xna.Framework;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects.CustomItems;

namespace TsRandomizer.RoomTriggers.Triggers
{
	[RoomTriggerTrigger(11, 16)]
	class LabSoftLockExits : RoomTrigger
	{
		public override void OnRoomLoad(RoomState roomState)
		{
			if (!roomState.Seed.Options.RiskyWarps)
				return;
			// Only spawns if you are past the laser but it's still on (i.e. coming from Dad's Tower warp)
			if (!roomState.Level.IsRoomVisited(11, 35))
				RoomTriggerHelper.SpawnGlowingFloor(roomState.Level, new Point(900, 300));
		}

	}
}
