using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class OemMissionAmplifier
{
	private AmplifierModel _amplifierModel;

	private readonly string _ampMappingFormulaId;

	private AmplifierFormulaModel _formulaModel;

	private OemMissionCost _cost;

	private OemMissionBonus _bonus;

	public int AmpIdx { get; }

	public AmplifierModel AmplifierModel => _amplifierModel ?? (_amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(AmpIdx));

	public string FormulaId => AmplifierFormulaModel?.Key;

	public AmplifierFormulaModel AmplifierFormulaModel => _formulaModel ?? (_formulaModel = AmpConfigHelper.TryGetAmplifierFormula(_ampMappingFormulaId));

	public OemMissionCost Cost
	{
		get
		{
			if (_cost == null && AmplifierFormulaModel != null)
			{
				Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(AmplifierFormulaModel.Data.Data);
				string text = dictionary["OEMMission"];
				if (!OemMissionAmplifierConfigHelper.OemMissionConfig.TryGetValue(text, out var value))
				{
					throw new Exception("OemMissionFormulaBonus Get " + text + " Data is null");
				}
				_cost = JsonHelper.ToObject<OemMissionCost>(value.MissionCost);
			}
			return _cost;
		}
	}

	public OemMissionBonus Bonus
	{
		get
		{
			if (_bonus == null && AmplifierFormulaModel != null)
			{
				Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(AmplifierFormulaModel.Data.Data);
				string text = dictionary["OEMMission"];
				if (!OemMissionAmplifierConfigHelper.OemMissionConfig.TryGetValue(text, out var value))
				{
					throw new Exception("OemMissionFormulaBonus Get " + text + " Data is null");
				}
				_bonus = JsonHelper.ToObject<OemMissionBonus>(value.MissionBonus);
			}
			return _bonus;
		}
	}

	public OemMissionAmplifier(int ampIdx, string formulaId = null)
	{
		AmpIdx = ampIdx;
		_ampMappingFormulaId = (string.IsNullOrEmpty(formulaId) ? string.Empty : ("GvGAmplifierForgeItem_" + formulaId));
	}
}
