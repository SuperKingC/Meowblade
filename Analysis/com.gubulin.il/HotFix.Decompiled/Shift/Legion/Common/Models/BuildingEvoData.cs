using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class BuildingEvoData
{
	public readonly string BuildingType;

	public readonly int Level;

	public readonly int Slot;

	public readonly Dictionary<string, int> EvoRequire;

	public readonly Dictionary<string, object> Modifiers;

	public readonly int UpgradeTime;

	public BuildingEvoData(GDEBuildingEvoData data)
	{
		BuildingType = data.BuildingType;
		Level = data.EvoLevel;
		Slot = data.Slot;
		UpgradeTime = data.UpgradeTime;
		if (!string.IsNullOrEmpty(data.EvoRequire))
		{
			EvoRequire = JsonHelper.ToObject<Dictionary<string, int>>(data.EvoRequire);
		}
		if (!string.IsNullOrEmpty(data.Modifiers))
		{
			Modifiers = JsonHelper.ToObject<Dictionary<string, object>>(data.Modifiers);
		}
	}

	public List<Modifier> GetEffects(GameManagers managers)
	{
		if (Modifiers == null)
		{
			return null;
		}
		List<Modifier> list = new List<Modifier>();
		foreach (KeyValuePair<string, object> modifier in Modifiers)
		{
			Modifier item = new Modifier(managers, modifier.Key, modifier.Value);
			list.Add(item);
		}
		return list;
	}
}
