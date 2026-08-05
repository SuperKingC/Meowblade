using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGShipOverviewModel
{
	private const int MAX_POSSIBLE_SHIP_COUNT = 6;

	private GvGMode3ObserverRecord RecordData;

	public int MaxAvailableShipCount;

	public Dictionary<int, int> BuildableShipType;

	public readonly List<GvGShipDetailModel> Ships;

	public int MaxShipSlotCount
	{
		get
		{
			if (MaxAvailableShipCount > 6)
			{
				throw new Exception("[GvGShipOverviewModel] 解锁的飞空艇数量比规定的最大飞空艇数量大");
			}
			return Math.Min(MaxAvailableShipCount + 1, 6);
		}
	}

	public bool HasEnterIz => RecordData.HasEnterIZ;

	public bool ShipsHasAvailableCount
	{
		get
		{
			foreach (KeyValuePair<int, int> item in BuildableShipType)
			{
				if (item.Value > 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	public GvGShipOverviewModel()
	{
		Ships = new List<GvGShipDetailModel>();
	}

	public void GetData(Action onSuccess)
	{
		RecordData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		RefreshData();
		onSuccess?.Invoke();
	}

	public void SetData(GvGMode3ObserverRecord record)
	{
		UnregisterShipStateEvents();
		RecordData = record;
		RefreshData();
	}

	public void RefreshData()
	{
		MaxAvailableShipCount = RecordData.ShipCountLimit;
		BuildableShipType = RecordData.GetBuildableShipType();
		UnregisterShipStateEvents();
		foreach (GvGMode3ShipModel ship in RecordData.Ships)
		{
			GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel
			{
				WorkersOnboardCountLimit = RecordData.WorkersOnboardCountLimit,
				AmplifierCountLimit = RecordData.AmplifierCountLimit
			};
			gvGShipDetailModel.SetRecordData(ship);
			gvGShipDetailModel.RegisterEvent();
			Ships.Add(gvGShipDetailModel);
		}
		Ships.Sort(ShipCompare);
	}

	private void UnregisterShipStateEvents()
	{
		foreach (GvGShipDetailModel ship in Ships)
		{
			ship.UnregisterEvent();
		}
		Ships.Clear();
	}

	public void Release()
	{
		UnregisterShipStateEvents();
	}

	public static int ShipCompare(GvGShipDetailModel a, GvGShipDetailModel b)
	{
		if (a.Index == b.Index && a.Index < 0)
		{
			return a.ShipType - b.ShipType;
		}
		if (a.Index < 0)
		{
			return 1;
		}
		if (b.Index < 0)
		{
			return -1;
		}
		return a.Index - b.Index;
	}
}
