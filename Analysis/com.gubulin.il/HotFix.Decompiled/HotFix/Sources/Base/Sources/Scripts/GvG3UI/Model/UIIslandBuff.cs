using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class UIIslandBuff
{
	public string AbilityId;

	public Ability Ability;

	public Dictionary<int, List<int>> LevelInfo;

	public int AffectedCampId;

	public bool IsDebuff;

	private GDEAbilityData _abilityData = null;

	public int TotalLevel
	{
		get
		{
			int num = 0;
			foreach (List<int> value in LevelInfo.Values)
			{
				num += value.Sum();
			}
			return num;
		}
	}

	public GDEAbilityData AbilityData
	{
		get
		{
			if (_abilityData == null)
			{
				_abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(AbilityId);
			}
			return _abilityData;
		}
	}

	public UIIslandBuff(IslandBuff _buff, int affectedCampId)
	{
		AbilityId = _buff.Ability.AbilityId;
		Ability = _buff.Ability;
		LevelInfo = new Dictionary<int, List<int>> { 
		{
			_buff.FromIslandId,
			new List<int> { _buff.Ability.N1 }
		} };
		AffectedCampId = affectedCampId;
		IsDebuff = _buff.Ability.IsDebuff;
	}

	public void Merge(IslandBuff _buff)
	{
		if (!_buff.AffectedCampId.Contains(AffectedCampId))
		{
			throw new Exception("[UIIslandBuff] Merge 错误");
		}
		if (!LevelInfo.ContainsKey(_buff.FromIslandId))
		{
			LevelInfo.Add(_buff.FromIslandId, new List<int>());
		}
		LevelInfo[_buff.FromIslandId].Add(_buff.Ability.N1);
	}
}
