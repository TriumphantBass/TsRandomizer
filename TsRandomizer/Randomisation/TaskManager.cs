using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Timespinner.Core;
using Timespinner.Core.Specifications;
using Timespinner.GameAbstractions.Gameplay;
using Timespinner.GameAbstractions.Inventory;
using TsRandomizer.Extensions;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.IntermediateObjects.CustomItems;
using TsRandomizer.Settings;

namespace TsRandomizer.Randomisation
{
	struct TaskDefinition
	{
		public string Name;
		public string Description;
		public string SaveString;
	}

	enum ETaskId
	{
		CollectMemory,
		CollectLetter,
		CollectFamiliar,
		CollectDownload,
		SaveEschem,
		SaveSeykis,
		FindNelisteTools,
		FindFoodSyth,
		TradeLibrarian,
		CheckRegret,
		CheckDynamo,
		CheckWaterfall,
		DisableHangarLasers,
		UseTowerTimespinner,
		DefeatGenzaLocation,
		DefeatTwoPrincesLocation,
		DefeatMawLocation,
		DefeatDadLocation,
		DefeatNightmareLocation,
		DefeatIfritLocation,
		DefeatRavenlordLocation,
		DefeatCantoranLocation
	}


	static class TaskManager
	{
		public static int[] GetValidTasks(Seed seed)
		{
			var validTasks = Enum.GetValues(typeof(ETaskId)).Cast<int>().ToList();
			if (!seed.Options.Cantoran)
				validTasks.Remove((int)ETaskId.DefeatCantoranLocation);
			if (!seed.Options.GyreArchives)
			{
				validTasks.Remove((int)ETaskId.DefeatRavenlordLocation);
				validTasks.Remove((int)ETaskId.DefeatIfritLocation);
			}
			var random = new Random((int)seed.Id);
			return validTasks.OrderBy(x => random.Next()).ToArray();
		}

		public static TaskDefinition GetTask(int taskId)
		{
			switch (taskId)
			{
				case (int)ETaskId.CollectFamiliar:
					return new TaskDefinition
					{
						Name = "Aviary of Dreams",
						Description = "Collect all familiars",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.CollectMemory:
					return new TaskDefinition
					{
						Name = "Living Memory",
						Description = "Collect all memories",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.CollectLetter:
					return new TaskDefinition
					{
						Name = "Scholar",
						Description = "Collect all letters",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.CollectDownload:
					return new TaskDefinition
					{
						Name = "Full Hard Drive",
						Description = "Collect all downloads",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.SaveEschem:
					return new TaskDefinition
					{
						Name = "Rescue Eschem",
						Description = "Save Eschem from the Caves",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.SaveSeykis:
					return new TaskDefinition
					{
						Name = "Rescue Seykis",
						Description = "Save Seykis from the young Cheveur",
						SaveString = "TaskPlaceholder"
					};
				case (int)ETaskId.UseTowerTimespinner:
					return new TaskDefinition
					{
						Name = "Use Metropolis Timespinner",
						Description = "Use the Timespinner at the top of Varndagroth Towers",
						SaveString = "TaskPlaceholder"
					};
				default:
					return new TaskDefinition
					{
						Name = String.Format("Placeholder Task {0}", taskId),
						Description = "Failed to generate task.",
						SaveString = "TaskPlaceholder"
					};
			}
		}

		public static TaskDefinition[] GetTaskList(Seed seed, int taskCount)
		{
			int[] validTasks = TaskManager.GetValidTasks(seed);
			TaskDefinition[] taskList = new TaskDefinition[taskCount];
			for (int i = 0; i < taskCount; i++)
			{
				taskList[i] = GetTask(validTasks[i]);
			}
			return taskList;
		}
	}
}
