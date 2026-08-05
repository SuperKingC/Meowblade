using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_LegendItemBlueprint
{
	public class Model
	{
		public List<Blueprint> Blueprints = new List<Blueprint>();
	}

	public class StatModel
	{
		public List<string> OwnedBluePrintsRecords { get; set; } = new List<string>();

		public int IdentifiedBluePrintsRecords { get; set; } = 0;

		public int HistoryIdentifiedBluePrintsRecords { get; set; } = 0;

		public int HistoryOwnedBluePrintsRecords { get; set; } = 0;

		public bool Checked { get; set; } = false;
	}

	private const string _KEY = "LegendItemBlueprint";

	private const string _STAT_KEY = "LegendItemBlueprintHistory";

	private const string _BLUEPRINT_BOX_3 = "BlueprintBox_3";

	public static List<Blueprint> GetLegendItemBlueprints(this UserArchiveManager manager)
	{
		return manager.GetModel().Blueprints;
	}

	public static List<string> GetOwnedBluePrints(this UserArchiveManager manager)
	{
		return manager.GetStatModel().OwnedBluePrintsRecords;
	}

	public static int GetOwnedBluePrintsRecords(this UserArchiveManager manager)
	{
		return manager.GetStatModel().HistoryOwnedBluePrintsRecords;
	}

	public static int GetIdentifiedBluePrints(this UserArchiveManager manager)
	{
		return manager.GetStatModel().IdentifiedBluePrintsRecords;
	}

	public static int GetIdentifiedBluePrintsRecords(this UserArchiveManager manager)
	{
		return manager.GetStatModel().HistoryIdentifiedBluePrintsRecords;
	}

	public static List<Blueprint> GetLegendItemBlueprints(this UserArchiveManager manager, List<string> blueprintsId)
	{
		if (blueprintsId == null || blueprintsId.Count <= 0)
		{
			return new List<Blueprint>();
		}
		return manager.GetModel().Blueprints.Where((Blueprint t) => blueprintsId.Contains(t.Id)).ToList();
	}

	public static void AddLegendItemBlueprints(this UserArchiveManager manager, List<Blueprint> blueprints)
	{
		if (blueprints == null)
		{
			return;
		}
		foreach (Blueprint blueprint in blueprints)
		{
			manager.AddLegendItemBlueprint(blueprint);
		}
	}

	public static void AddOwnedBluePrintsRecord(this UserArchiveManager manager, List<string> blueprints)
	{
		if (blueprints == null)
		{
			return;
		}
		foreach (string blueprint in blueprints)
		{
			manager.AddOwnedBluePrintsRecords(blueprint);
		}
		SharedMessenger.Broadcast("ON_BLUEPRINTS_CHANGE");
	}

	private static void AddLegendItemBlueprint(this UserArchiveManager manager, Blueprint blueprint)
	{
		Model model = manager.GetModel();
		List<Blueprint> blueprints = model.Blueprints;
		if (blueprints.AddDistinct(blueprint))
		{
			manager.SetModel(model);
		}
	}

	private static void AddOwnedBluePrintsRecords(this UserArchiveManager manager, string blueprintId)
	{
		StatModel statModel = manager.GetStatModel();
		List<string> ownedBluePrintsRecords = statModel.OwnedBluePrintsRecords;
		if (ownedBluePrintsRecords.AddDistinct(blueprintId))
		{
			manager.SetStatModel(statModel);
		}
	}

	public static void RecordIdentifiedBluePrints(this UserArchiveManager manager, int blueprintCount, string itemId)
	{
		if (!(itemId != "BlueprintBox_3"))
		{
			StatModel statModel = manager.GetStatModel();
			statModel.IdentifiedBluePrintsRecords += blueprintCount;
			manager.SetStatModel(statModel);
			SharedMessenger.Broadcast("ON_BLUEPRINTS_IDENTIFY");
		}
	}

	public static void DeleteLegendItemBlueprint(this UserArchiveManager manager, string blueprintId)
	{
		Model model = manager.GetModel();
		model.Blueprints.RemoveAll((Blueprint _blueprint) => _blueprint.Id == blueprintId);
		manager.SetModel(model);
	}

	private static Model GetModel(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("LegendItemBlueprint");
		if (model == null)
		{
			model = new Model();
			if (model.Blueprints == null)
			{
				model.Blueprints = new List<Blueprint>();
			}
			manager.SetConfigValue("LegendItemBlueprint", model);
		}
		return model;
	}

	private static StatModel GetStatModel(this UserArchiveManager manager)
	{
		StatModel statModel = manager.GetConfigValue<StatModel>("LegendItemBlueprintHistory");
		if (statModel == null)
		{
			statModel = new StatModel();
			manager.SetConfigValue("LegendItemBlueprintHistory", statModel);
		}
		return statModel;
	}

	private static void SetModel(this UserArchiveManager manager, Model model)
	{
		manager.SetConfigValue("LegendItemBlueprint", model);
	}

	private static void SetStatModel(this UserArchiveManager manager, StatModel model)
	{
		manager.SetConfigValue("LegendItemBlueprintHistory", model);
	}
}
