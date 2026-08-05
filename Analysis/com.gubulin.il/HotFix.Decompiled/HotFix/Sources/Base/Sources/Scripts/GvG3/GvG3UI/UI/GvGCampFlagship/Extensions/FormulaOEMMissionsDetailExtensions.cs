using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.Extensions;

public static class FormulaOEMMissionsDetailExtensions
{
	public static bool IsNotAvailable(this FormulaOEMMissionsDetail detail)
	{
		bool flag = detail.CloseTimestamp <= (int)GameController.Instance.GetServerTime();
		bool flag2 = detail.FinishCount >= detail.TotalCount;
		return flag || flag2;
	}

	public static string GetMissionCountdown(this FormulaOEMMissionsDetail detail, out int countdownType)
	{
		int num = detail.CloseTimestamp - (int)GameController.Instance.GetServerTime();
		countdownType = ((num <= 3600) ? 1 : 0);
		return UiHelper.ParseTimeShort(Mathf.Max(0, num));
	}

	public static string GetMissionAvailableCount(this FormulaOEMMissionsDetail detail)
	{
		return $"{detail.TotalCount - detail.FinishCount}/{detail.TotalCount}";
	}

	public static string GetMissionCriRate(this FormulaOEMMissionsDetail detail)
	{
		float ampForgeHighQualityRate = OemMissionAmplifierConfigHelper.GetAmpForgeHighQualityRate(detail.AmpIdx);
		return $"{detail.CriRate + ampForgeHighQualityRate: 0.#}%";
	}

	public static void OverrideValues(this FormulaOEMMissionsDetail detail, FormulaOEMMissionsDetail other)
	{
		detail.UserId = other.UserId;
		detail.AmpIdx = other.AmpIdx;
		detail.FinishCount = other.FinishCount;
		detail.TotalCount = other.TotalCount;
		detail.CloseTimestamp = other.CloseTimestamp;
		detail.HasTitanTalent = other.HasTitanTalent;
		detail.CriRate = other.CriRate;
		detail.精益求精Level = other.精益求精Level;
	}
}
