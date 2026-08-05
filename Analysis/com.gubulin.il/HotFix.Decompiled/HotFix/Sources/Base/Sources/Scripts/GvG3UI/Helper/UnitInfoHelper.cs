using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class UnitInfoHelper
{
	public static bool CheckIsLowSoldierNumAlert(GvGMode3UnitInfo unitInfo)
	{
		return CheckIsLowSoldierNumAlert(unitInfo.CurCnt, unitInfo.Total);
	}

	public static bool CheckIsLowSoldierNumAlert(int curCnt, int totalCnt)
	{
		float num = (float)curCnt / (float)totalCnt;
		return num < 0.4f;
	}

	public static string GetSoldierNumTextColor(GvGMode3UnitInfo unitInfo)
	{
		return GetSoldierNumTextColor(unitInfo.CurCnt, unitInfo.Total);
	}

	public static string GetSoldierNumTextColor(int curCnt, int totalCnt)
	{
		float num = (float)curCnt / (float)totalCnt;
		if (num < 0.4f)
		{
			return "#ff1a1a";
		}
		if (num <= 0.99f)
		{
			return "#fff04c";
		}
		return "#ffffff";
	}

	public static bool CheckIsValidSoldier(string sid)
	{
		return !string.IsNullOrEmpty(sid) && sid != "Unlock" && sid != "Lock";
	}

	public static bool AreEqual(GvGMode3UnitInfo unitInfo1, GvGMode3UnitInfo unitInfo2)
	{
		if (unitInfo1 == null && unitInfo2 == null)
		{
			return true;
		}
		if (unitInfo1 == null || unitInfo2 == null)
		{
			return false;
		}
		return unitInfo1.SoldierId == unitInfo2.SoldierId && unitInfo1.PotentialLevel == unitInfo2.PotentialLevel && unitInfo1.SoldierLevel == unitInfo2.SoldierLevel && JsonHelper.ToJson(unitInfo1.EquippedItems ?? new int[0]) == JsonHelper.ToJson(unitInfo2.EquippedItems ?? new int[0]) && unitInfo1.CurCnt == unitInfo2.CurCnt;
	}

	public static bool UnitInfosAreEqual(List<GvGMode3UnitInfo> unitInfoList1, List<GvGMode3UnitInfo> unitInfoList2)
	{
		if (unitInfoList1 == null && unitInfoList2 == null)
		{
			return true;
		}
		if (unitInfoList1 == null || unitInfoList2 == null)
		{
			return false;
		}
		if (unitInfoList1.Count != unitInfoList2.Count)
		{
			return false;
		}
		for (int i = 0; i < unitInfoList1.Count; i++)
		{
			if (!AreEqual(unitInfoList1[i], unitInfoList2[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static int GetFormationPower(GvGMode3UnitInfo unitInfo)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(unitInfo.SoldierId);
		FakeSoldier fakeSoldier = new FakeSoldier(unitInfo.SoldierId, unitInfo.SoldierLevel, soldier.EvoLevel, unitInfo.PotentialLevel);
		List<LegendItem> list = new List<LegendItem>();
		if (unitInfo.EquippedItems != null)
		{
			int[] equippedItems = unitInfo.EquippedItems;
			foreach (int num in equippedItems)
			{
				LegendItem legendItem = LegendItemsHelper.GetLegendItemUi(num)?.LegendItemData;
				if (legendItem != null)
				{
					list.Add(legendItem);
				}
			}
		}
		return fakeSoldier.GetCombatPowerWithLegendItems(list) * unitInfo.CurCnt;
	}

	public static Dictionary<string, List<UnitInfo_Protocol>> ToValue(string json)
	{
		Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(json);
		Dictionary<string, List<UnitInfo_Protocol>> dictionary2 = new Dictionary<string, List<UnitInfo_Protocol>>();
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			List<string> list = JsonHelper.ToObject<List<string>>(item.Value);
			List<UnitInfo_Protocol> list2 = new List<UnitInfo_Protocol>();
			foreach (string item2 in list)
			{
				if (string.IsNullOrEmpty(item2))
				{
					list2.Add(null);
					continue;
				}
				byte[] data = Convert.FromBase64String(item2);
				list2.Add(data.Deserialize<UnitInfo_Protocol>());
			}
			dictionary2.Add(item.Key, list2);
		}
		return dictionary2;
	}
}
