using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Extension;

public static class FormulaOemMissionExtension
{
	public static List<FormulaOemUiBonus> ReadFormulaOemUiBonus(this FormulaOemMission formulaOemMission, float makeBonusContribution)
	{
		if (!OemMissionAmplifierConfigHelper.OemMissionConfig.TryGetValue(formulaOemMission.FormulaOEMMission, out var value))
		{
			throw new Exception("ReadFormulaOemUiBonus Get " + formulaOemMission.FormulaOEMMission + " Data is null");
		}
		List<FormulaOemUiBonus> list = new List<FormulaOemUiBonus>(5);
		OemMissionBonus oemMissionBonus = JsonHelper.ToObject<OemMissionBonus>(value.MissionBonus);
		KeyValuePair<string, int> baseBonus = oemMissionBonus.GetBaseBonus();
		list.Add(new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Base,
			Key = "I65001",
			Value = baseBonus.Value
		});
		list.Add(new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Make,
			Key = "I65001",
			Value = makeBonusContribution
		});
		KeyValuePair<string, int> titanBonus = oemMissionBonus.GetTitanBonus();
		list.Add(new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Titan,
			Key = "I65001",
			Value = titanBonus.Value
		});
		KeyValuePair<string, int> criticalBonus = oemMissionBonus.GetCriticalBonus();
		list.Add(new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Critical,
			Key = "I65001",
			Value = criticalBonus.Value
		});
		FormulaOemSubTypeData formulaOemSubTypeData = JsonHelper.ToObject<FormulaOemSubTypeData>(value.SubTypeData);
		list.Add(new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Immediate,
			Key = "I65001",
			Value = formulaOemSubTypeData.PostContributionPoint
		});
		return list;
	}
}
