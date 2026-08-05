using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Managers;

public class FormationUnitsManager : Manager
{
	public static Action<string, string, List<string>> ChangeFormationUnits;

	private List<string> _buffer = new List<string>();

	public FormationUnitsManager(GameManagers managers)
		: base(managers)
	{
	}

	public ActionResult ChangeFormationUnit(string ctx, string mode, List<string> unitsId, bool isFighting = false)
	{
		string subContext = mode;
		Dictionary<string, string> battleFormation = Managers.UserArchiveManager.GetBattleFormation(ctx, subContext);
		List<string> units = new List<string>(battleFormation.Values);
		int num = 0;
		if (unitsId.Count == units.Count)
		{
			for (int i = 0; i < units.Count; i++)
			{
				units[i] = unitsId[i];
				if (IsUnitIdValid(units[i]))
				{
					num++;
				}
			}
		}
		else
		{
			if (unitsId.Count != 5)
			{
				return new ActionResult
				{
					Result = false,
					ResultCode = ActionResultCode.UnitsIdError
				};
			}
			for (int j = 0; j < 12; j++)
			{
				if (j < unitsId.Count)
				{
					units[j] = unitsId[j];
				}
				else
				{
					units[j] = "Unlock";
				}
			}
		}
		bool flag = mode == BattleMode.DefenceMode.ToString();
		if (num == 5 && flag)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.TeamNumExceed
			};
		}
		if (!isFighting)
		{
			for (int k = 0; k < units.Count; k++)
			{
				Managers.UserArchiveManager.SetBattleFormation(k, units[k], ctx, subContext);
			}
		}
		ChangeFormationUnits(ctx, subContext, units);
		ILRequestHelper<SyncFormationUnitsResponse>.Request((EventContext)null, (Func<Task<SyncFormationUnitsResponse>>)(() => GameController.Contexts.Service<INetworkService>().SyncFormationUnits(-1L, ctx, subContext, units)), (Action<SyncFormationUnitsResponse>)delegate(SyncFormationUnitsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
		return new ActionResult
		{
			Result = true
		};
	}

	public ActionResult ChangeFormationUnit(string ctx, string mode, int portalId, string unitId, bool isFighting = false)
	{
		Dictionary<string, string> battleFormation = Managers.UserArchiveManager.GetBattleFormation(ctx, mode);
		List<string> list = new List<string>(battleFormation.Values);
		bool flag = IsUnitIdValid(unitId);
		int num = list.IndexOf(unitId);
		int num2 = 0;
		foreach (string item in list)
		{
			if (IsUnitIdValid(item))
			{
				num2++;
			}
		}
		bool flag2 = mode == BattleMode.DefenceMode.ToString();
		if (!IsUnitIdValid(list[portalId]) && num2 == 5 && num == -1 && flag2 && !string.IsNullOrEmpty(unitId))
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.TeamNumExceed
			};
		}
		if (num >= 0)
		{
			list[num] = "Unlock";
		}
		string text = list[portalId];
		bool flag3 = !string.IsNullOrEmpty(text) && !(text == "Unlock") && !(text == "Lock");
		list[portalId] = unitId;
		if (flag && flag3 && num >= 0)
		{
			list[num] = text;
		}
		if (!isFighting)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Managers.UserArchiveManager.SetBattleFormation(i, list[i], ctx, mode);
			}
		}
		ChangeFormationUnits(ctx, mode, list);
		return new ActionResult
		{
			Result = true
		};
	}

	private static bool IsUnitIdValid(string unitId)
	{
		return !string.IsNullOrEmpty(unitId) && !(unitId == "Unlock") && !(unitId == "Lock");
	}

	public void OnSoldierUnlocked(string soldierId)
	{
		List<string> unlockedSoldiers = Managers.UserArchiveManager.GetUnlockedSoldiers();
		if (unlockedSoldiers == null)
		{
			return;
		}
		unlockedSoldiers = new List<string>(unlockedSoldiers);
		List<string> assignedSoldiers = Managers.UserArchiveManager.GetAssignedSoldiers();
		unlockedSoldiers.RemoveAll((string s) => assignedSoldiers.Contains(s));
		if (unlockedSoldiers.Count < 1 || unlockedSoldiers.Count > 5)
		{
			return;
		}
		string text = ChapterType.StoryMain.ToString();
		string text2 = BattleMode.RushMode.ToString();
		Dictionary<string, string> battleFormation = Managers.UserArchiveManager.GetBattleFormation(text, text2);
		List<string> list = new List<string>();
		foreach (string value in battleFormation.Values)
		{
			list.Add(value);
		}
		List<string> buffer = _buffer;
		int num = 0;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			string text3 = list[num2];
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "Unlock";
			}
			if (text3 != "Unlock" && text3 != "Lock")
			{
				num++;
			}
			buffer.Add(text3);
		}
		List<string> list2 = new List<string>(unlockedSoldiers);
		foreach (string item in buffer)
		{
			if (list2.Contains(item))
			{
				list2.Remove(item);
			}
			if (list2.Count < 1)
			{
				break;
			}
		}
		if (list2.Count == 0 || num == 5)
		{
			buffer.Clear();
			return;
		}
		int num3 = 0;
		int count = list2.Count;
		for (int num4 = 0; num4 < Math.Min(buffer.Count, 5); num4++)
		{
			if (!(buffer[num4] != "Unlock"))
			{
				ChangeFormationUnit(text, text2, num4, list2[num3]);
				if (++num3 >= count || ++num == 5)
				{
					break;
				}
			}
		}
		buffer.Clear();
	}
}
