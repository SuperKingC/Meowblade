using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

public class IslandFilterSelectRecord
{
	private readonly string _selectedRecordKey = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_SelectRecord";

	public string LastSelectedFilterId()
	{
		return PlayerPrefs.GetString(_selectedRecordKey);
	}

	public void UpdateSelectedFilterId(string filterId)
	{
		PlayerPrefs.SetString(_selectedRecordKey, filterId);
	}
}
