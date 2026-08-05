using System;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;

public class 魔的第八天TalentEffect
{
	private readonly Lazy<OuterTechEffect<float>> _魔的第八天 = new Lazy<OuterTechEffect<float>>(() => new OuterTechEffect<float>
	{
		EffectValue = Mathf.Max(OuterTechHelper.魔的第八天.Value.ReturnPercent, 0f)
	});

	private string _魔的第八天ReturnPercent;

	public float 魔的第八天ReturnPercentValue => _魔的第八天.Value.EffectValue;

	public string 魔的第八天ReturnPercentStr => _魔的第八天ReturnPercent ?? (_魔的第八天ReturnPercent = $"{Mathf.RoundToInt(魔的第八天ReturnPercentValue)}");

	public int 魔的第八天TotalTimes => OuterTechHelper.魔的第八天.Value.Value;

	public int LimitTime => Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o魔的第八天_LimitTime;

	public static long GetUnlockTime()
	{
		long num = Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp;
		int triggerDay = OuterTechHelper.魔的第八天.Value.TriggerDay;
		DateTimeOffset now = DateTimeHelper.Parse(num).AddDays(triggerDay);
		return DateTimeHelper.GetDailyRefreshTime(now).ToUnixTimeSeconds();
	}
}
