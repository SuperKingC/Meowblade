using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class ItemAbility
{
	public string AbilityId;

	public List<ItemEntryData> Variables;

	private int? _level;

	private GDEAbilityData _abilityData;

	public int AbilityLevel => (_level ?? (_level = Convert.ToInt32(Variables?[0].GetValue()))).Value;

	public GDEAbilityData AbilityData => _abilityData ?? (_abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(AbilityId));

	public string Icon { get; set; }

	public void SetLevel(int level)
	{
		_level = level;
	}
}
