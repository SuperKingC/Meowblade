using System.Collections.Generic;
using Assets.Scripts.Managers;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

public class ChangeCurrentFormationUnitCommandExecutor
{
	private readonly Contexts _contexts;

	public ChangeCurrentFormationUnitCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(ChangeCurrentFormationUnitCommand cmd)
	{
		int portalId = cmd.portalId;
		string unitId = cmd.unitId;
		string context = cmd.context;
		string subContext = cmd.subContext;
		Dictionary<string, Dictionary<string, List<string>>> value = _contexts.config.formationUnits.value;
		if (!value.TryGetValue(context, out var value2))
		{
			value2 = new Dictionary<string, List<string>>();
			value.Add(context, value2);
		}
		if (!value2.TryGetValue(subContext, out var value3))
		{
			value3 = new List<string>();
			for (int i = 0; i < 12; i++)
			{
				value3.Add("Unlock");
			}
			value2.Add(subContext, value3);
		}
		bool flag = IsUnitIdValid(unitId);
		int num = value3.IndexOf(unitId);
		int num2 = 0;
		foreach (string item in value3)
		{
			if (IsUnitIdValid(item))
			{
				num2++;
			}
		}
		bool flag2 = false;
		if (_contexts.gameState.hasBattleFieldLevel)
		{
			flag2 = _contexts.gameState.battleFieldLevel.value.BattleMode == BattleMode.DefenceMode;
		}
		if (!IsUnitIdValid(value3[portalId]) && num2 == 5 && num == -1 && flag2 && !string.IsNullOrEmpty(unitId))
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText735") + "5" + LanguagesManager.GetDesc("CsharpCodeZhTcText736") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (num >= 0)
		{
			value3[num] = "Unlock";
		}
		string text = value3[portalId];
		bool flag3 = !string.IsNullOrEmpty(text) && !(text == "Unlock") && !(text == "Lock");
		value3[portalId] = unitId;
		if (flag && flag3 && num >= 0)
		{
			value3[num] = text;
		}
		for (int j = 0; j < value3.Count; j++)
		{
			GameManagers.Instance.UserArchiveManager.SetBattleFormation(j, value3[j], context, subContext);
		}
		_contexts.config.ReplaceFormationUnits(value);
	}

	private static bool IsUnitIdValid(string unitId)
	{
		return !string.IsNullOrEmpty(unitId) && !(unitId == "Unlock") && !(unitId == "Lock");
	}
}
