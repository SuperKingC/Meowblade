using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SoldierPotentialData
{
	public readonly string SoldierId;

	public readonly int Level;

	public readonly Dictionary<string, float> Attributes;

	public readonly Dictionary<string, int> OriginRequirement;

	public SoldierPotentialData(GDESoldierPotentialData data)
	{
		SoldierId = data.SoldierId;
		Level = data.Level;
		Attributes = new Dictionary<string, float>();
		if (!string.IsNullOrEmpty(data.Attributes))
		{
			foreach (KeyValuePair<string, float> item in JsonHelper.ToObject<Dictionary<string, float>>(data.Attributes))
			{
				Attributes.Add(item.Key, item.Value);
			}
		}
		OriginRequirement = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(data.Requirement))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item2 in JsonHelper.ToObject<Dictionary<string, int>>(data.Requirement))
		{
			OriginRequirement.Add(item2.Key, item2.Value);
		}
	}

	public Dictionary<string, int> Requirements(GameManagers managers, Dictionary<string, int> buffer = null)
	{
		if (buffer == null)
		{
			buffer = new Dictionary<string, int>();
		}
		else
		{
			buffer.Clear();
		}
		List<string> list = new List<string> { SoldierId };
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(SoldierId);
		if (gDESoldierData != null)
		{
			list.Add(gDESoldierData.AiType);
		}
		float num = managers.ModifierManager.GetPercentFloatPayload("SoldierPotentialUpgradeCost", list.ToArray()) + 1f;
		foreach (KeyValuePair<string, int> item in OriginRequirement)
		{
			buffer.Add(item.Key, Mathf.RoundToInt((float)item.Value * num));
		}
		return buffer;
	}
}
