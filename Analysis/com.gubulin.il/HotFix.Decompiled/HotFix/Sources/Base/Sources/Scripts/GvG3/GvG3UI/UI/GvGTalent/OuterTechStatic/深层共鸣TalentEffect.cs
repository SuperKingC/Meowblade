using System;
using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;

public class 深层共鸣TalentEffect
{
	private readonly Lazy<OuterTechEffect<bool>> _深层共鸣IsActive = new Lazy<OuterTechEffect<bool>>(() => new OuterTechEffect<bool>
	{
		EffectValue = (Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67602".IsActive())
	});

	private readonly Lazy<OuterTechEffect<int>> _深层共鸣 = new Lazy<OuterTechEffect<int>>(() => new OuterTechEffect<int>
	{
		EffectValue = ((Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67602".IsActive()) ? Mathf.Max(OuterTechHelper.Get_深层共鸣ReducePoint(), 0) : 0)
	});

	private readonly Dictionary<string, string> _specialParentTalents = new Dictionary<string, string>();

	public bool 深层共鸣IsActive => _深层共鸣IsActive.Value.EffectValue;

	public int 深层共鸣Value => _深层共鸣.Value.EffectValue;

	public string GetSpecialParentTalent(GDEGvGTalentConfigData talentConfig)
	{
		if (_specialParentTalents.TryGetValue(talentConfig.Key, out var value))
		{
			return value;
		}
		string text = (int.Parse(talentConfig.ParentTalent) - _深层共鸣.Value.EffectValue).ToString();
		_specialParentTalents[talentConfig.Key] = text;
		return text;
	}
}
