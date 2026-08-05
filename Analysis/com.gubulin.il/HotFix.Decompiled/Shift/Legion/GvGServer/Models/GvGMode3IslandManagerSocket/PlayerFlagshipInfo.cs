using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

public class PlayerFlagshipInfo
{
	public int FlagShipMaxFood;

	public int FlagShipCurFood;

	public bool DailyContributionBoxClaimed;

	public bool DailySupplyPackClaimed;

	public bool OEMAmplifiersCanBeReceived;

	public int FlagShipMissionLastRefreshTimestamp;

	public bool PollutantsCanBePurified;

	public bool OEMAmplifiersHasFailed;

	private readonly string _flagshipMissionsCheckedKey = $"FlagshipMissionsChecked_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}";

	public void UpdateFood(int curFood, int maxFood = 0)
	{
		if (maxFood > 0)
		{
			FlagShipMaxFood = maxFood;
		}
		FlagShipCurFood = curFood;
	}

	public void UpdateDailyContributionBoxClaimed(bool claimed)
	{
		DailyContributionBoxClaimed = claimed;
	}

	public void UpdateDailySupplyPackClaimed(bool claimed)
	{
		DailySupplyPackClaimed = claimed;
	}

	public void UpdateOEMAmplifiersCanBeReceived(bool received)
	{
		OEMAmplifiersCanBeReceived = received;
	}

	public void UpdateOEMAmplifiersHasFailed(bool hasFailed)
	{
		OEMAmplifiersHasFailed = hasFailed;
	}

	private bool FlagShipMissionsChecked()
	{
		if (FlagShipMissionLastRefreshTimestamp <= 0)
		{
			return true;
		}
		if (!PlayerPrefs.HasKey(_flagshipMissionsCheckedKey))
		{
			return false;
		}
		int num = PlayerPrefs.GetInt(_flagshipMissionsCheckedKey, 0);
		if (num < FlagShipMissionLastRefreshTimestamp)
		{
			PlayerPrefs.DeleteKey(_flagshipMissionsCheckedKey);
			return false;
		}
		return true;
	}

	public void SaveFlagShipMissionsChecked()
	{
		if (!PlayerPrefs.HasKey(_flagshipMissionsCheckedKey))
		{
			PlayerPrefs.SetInt(_flagshipMissionsCheckedKey, (int)GameController.Instance.GetServerTime());
		}
	}

	public List<FlagshipInfoType> GetCurFlagshipInfo()
	{
		List<FlagshipInfoType> list = new List<FlagshipInfoType> { FlagshipInfoType.旗舰食物 };
		if (!DailyContributionBoxClaimed)
		{
			list.Add(FlagshipInfoType.贡献宝箱);
		}
		if (DailySupplyPackToBeClaim())
		{
			list.Add(FlagshipInfoType.每日补给);
		}
		if (OEMAmplifiersCanBeReceived || OEMAmplifiersHasFailed)
		{
			list.Add(FlagshipInfoType.代工任务);
		}
		if (!FlagShipMissionsChecked())
		{
			list.Add(FlagshipInfoType.旗舰需求);
		}
		if (CanToBePurified())
		{
			list.Add(FlagshipInfoType.污染净化);
		}
		return list;
		static bool CanToBePurified()
		{
			bool result = false;
			foreach (string item in ConfigDataManager.ItemsByType[ItemType.GvGServer_CollectingMaterial_Polluted])
			{
				int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item, includingGSStock: true);
				if (itemCount > 0)
				{
					result = true;
					break;
				}
			}
			return result;
		}
		bool DailySupplyPackToBeClaim()
		{
			return Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent(eTalent.每日补给) && !DailySupplyPackClaimed;
		}
	}
}
