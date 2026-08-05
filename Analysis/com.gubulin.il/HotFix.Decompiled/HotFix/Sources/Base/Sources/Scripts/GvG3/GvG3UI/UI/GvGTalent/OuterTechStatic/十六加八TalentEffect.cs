using System;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;

public class 十六加八TalentEffect
{
	private readonly Lazy<OuterTechEffect<bool>> _十六加八IsActive = new Lazy<OuterTechEffect<bool>>(() => new OuterTechEffect<bool>
	{
		EffectValue = (Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67301".IsActive())
	});

	private readonly Lazy<OuterTechEffect<float>> _十六加八 = new Lazy<OuterTechEffect<float>>(() => new OuterTechEffect<float>
	{
		EffectValue = ((Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67301".IsActive()) ? Mathf.Max(OuterTechHelper.Get_16加8DiscountRate(), 0f) : 0f)
	});

	private string _十六加八Desc;

	public bool 十六加八IsActive => _十六加八IsActive.Value.EffectValue;

	public float 十六加八_减免Value => _十六加八.Value.EffectValue;

	public string 十六加八Desc => _十六加八Desc ?? (_十六加八Desc = "GvG3OuterTechI67301Desc".ToLanguage().Format(new object[1] { $"{十六加八_减免Value * 100f:0.#}" }));

	public string GetActiveTalentConsume(int consume)
	{
		return Mathf.CeilToInt((float)consume * (1f - 十六加八_减免Value)).ToString();
	}

	public int GetActiveTalentConsumeInt(int consume)
	{
		return Mathf.CeilToInt((float)consume * (1f - 十六加八_减免Value));
	}
}
