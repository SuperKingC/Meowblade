using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;

public class TalentEvent
{
	private readonly List<int> _activeTalents;

	private readonly List<int> _specialTalents;

	public TalentEvent(List<int> activeTalents, List<int> specialTalents)
	{
		_activeTalents = activeTalents ?? new List<int>();
		_specialTalents = specialTalents ?? new List<int>();
	}

	public void UpdateActiveTalents(List<int> activeTalents)
	{
		_activeTalents.Clear();
		_activeTalents.AddRange(activeTalents ?? new List<int>());
	}

	public void UpdateActiveTalent(int talentIdx)
	{
		if (!_activeTalents.Contains(talentIdx))
		{
			_activeTalents.Add(talentIdx);
		}
	}

	public void ClearActiveTalents()
	{
		_activeTalents.Clear();
	}

	public bool HasTalent(int idx)
	{
		return _activeTalents.Contains(idx);
	}

	public bool HasTalent(eTalent idx)
	{
		return _activeTalents.Contains((int)idx);
	}

	public bool HasTalent<T>()
	{
		return _activeTalents.Contains((int)Enum.Parse(typeof(eTalent), typeof(T).Name));
	}

	public static T GetConfig<T>()
	{
		int num = (int)Enum.Parse(typeof(eTalent), typeof(T).Name);
		if (!TryGetEffect(num, out var effect))
		{
			ILRuntimeDebug.LogError($"GvGMode3TalentSystem GetConfig Failed! idx={num}");
			return default(T);
		}
		return JsonHelper.ToObject<T>(effect);
	}

	private static bool TryGetEffect(int idx, out string effect)
	{
		GDEGvGTalentConfigData gDEGvGTalentConfigData = GvGTalentConfigHelper.GeTalentConfigData(idx);
		bool result = gDEGvGTalentConfigData != null;
		effect = gDEGvGTalentConfigData?.Effect;
		return result;
	}

	private static bool TryGetDesc(int idx, out string desc)
	{
		GDEGvGTalentConfigData gDEGvGTalentConfigData = GvGTalentConfigHelper.GeTalentConfigData(idx);
		bool result = gDEGvGTalentConfigData != null;
		desc = gDEGvGTalentConfigData?.Desc;
		return result;
	}

	public static string GetTalentDesc<T>()
	{
		int num = (int)Enum.Parse(typeof(eTalent), typeof(T).Name);
		if (TryGetDesc(num, out var desc))
		{
			return desc;
		}
		ILRuntimeDebug.LogError($"GvGMode3TalentSystem GetConfig Failed! idx={num}");
		return string.Empty;
	}
}
