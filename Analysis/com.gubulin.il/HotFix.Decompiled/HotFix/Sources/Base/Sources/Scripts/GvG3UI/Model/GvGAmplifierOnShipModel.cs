using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGAmplifierOnShipModel
{
	public class UIShipAmpsInfoModel
	{
		public GvGMode3ShipModel GvGMode3ShipModel;

		public Dictionary<int, int> AmplifiersCount_Dict;

		public List<AmplifierModel> AmplifiersConfig_List;

		public List<string> Soldiers;

		public string ShipId => GvGMode3ShipModel.ShipId;

		public int Index => GvGMode3ShipModel.PermanentData.Index;

		public eRace Race => (eRace)GvGMode3ShipModel.PermanentData.ShipRace;

		public string ShipName => GvGMode3ShipModel.PermanentData.ShipName.ToRealShipName();
	}

	public int AmplifierCountLimit;

	public Dictionary<int, int> StorageAmpsCount_Dict;

	public List<AmplifierModel> StorageAmpsConfig_List;

	public List<UIShipAmpsInfoModel> ShipAmpsInfo_List;

	public void GetData(Action onFinished = null)
	{
		SyncFromRecord(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
		Singleton<GvGAmplifierManager>.Instance.GetAmplifierStorage(delegate(GvGAmplifierManager.AmplifierStorageData data)
		{
			SyncStorageData(data.AmplifierStorage);
			onFinished?.Invoke();
		});
	}

	public void GetShipData(string shipId, Action<string> onFinished = null)
	{
		if (ShipAmpsInfo_List == null)
		{
			throw new Exception("[GvGAmplifierOnShipModel] 没有飞空艇信息, 检查GetData()是否正确");
		}
		UIShipAmpsInfoModel shipInfo = ShipAmpsInfo_List.Find((UIShipAmpsInfoModel s) => s.ShipId == shipId);
		if (shipInfo != null)
		{
			Singleton<GvGAmplifierManager>.Instance.GetShipAmplifiers(shipInfo.ShipId, delegate(GvGAmplifierManager.ShipAmplifiersData data)
			{
				SyncShipData(shipInfo, data.ShipsAmplifiers);
				onFinished?.Invoke(data.ShipId);
			});
		}
	}

	public void ChangeShipAmplifiers(string shipId, Dictionary<int, int> shipAmpChanges, Action onFinished = null)
	{
		UIShipAmpsInfoModel shipInfo = ShipAmpsInfo_List.Find((UIShipAmpsInfoModel s) => s.ShipId == shipId);
		Singleton<GvGAmplifierManager>.Instance.ChangeShipAmplifiers(shipId, shipAmpChanges, delegate(GvGAmplifierManager.StorageAndShipAmplifiersData data)
		{
			if (data == null)
			{
				ILRuntimeDebug.LogError("[GvGAmplifierOnShipModel] 飞空艇装备保存失败！");
			}
			else
			{
				SyncStorageData(data.AmplifierStorage);
				SyncShipData(shipInfo, data.ShipsAmplifiers);
				onFinished?.Invoke();
			}
		});
	}

	private void SyncFromRecord(GvGMode3ObserverRecord record)
	{
		AmplifierCountLimit = record.AmplifierCountLimit;
		ShipAmpsInfo_List = new List<UIShipAmpsInfoModel>();
		foreach (GvGMode3ShipModel ship in record.Ships)
		{
			ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(ship.TemporaryData.EntityId);
			if (shipStateModel == null || shipStateModel.CurrentUnitInfos == null)
			{
				continue;
			}
			List<string> list = new List<string>();
			foreach (GvGMode3UnitInfo currentUnitInfo in shipStateModel.CurrentUnitInfos)
			{
				if (!string.IsNullOrEmpty(currentUnitInfo.SoldierId))
				{
					list.Add(currentUnitInfo.SoldierId);
				}
			}
			ShipAmpsInfo_List.Add(new UIShipAmpsInfoModel
			{
				GvGMode3ShipModel = ship,
				Soldiers = list
			});
		}
		ShipAmpsInfo_List.Sort((UIShipAmpsInfoModel a, UIShipAmpsInfoModel b) => a.Index.CompareTo(b.Index));
	}

	private void SyncStorageData(Dictionary<int, int> amplifierStorage)
	{
		StorageAmpsCount_Dict = amplifierStorage;
		StorageAmpsConfig_List = new List<AmplifierModel>();
		foreach (KeyValuePair<int, int> item in StorageAmpsCount_Dict)
		{
			if (item.Value != 0)
			{
				StorageAmpsConfig_List.Add(AmpConfigHelper.Configs.TryGetNormalAmplifier(item.Key));
			}
		}
	}

	private void SyncShipData(UIShipAmpsInfoModel selectedShipInfo, Dictionary<int, int> shipAmplifiers)
	{
		List<AmplifierModel> list = new List<AmplifierModel>();
		foreach (KeyValuePair<int, int> shipAmplifier in shipAmplifiers)
		{
			list.Add(AmpConfigHelper.Configs.TryGetNormalAmplifier(shipAmplifier.Key));
		}
		selectedShipInfo.AmplifiersCount_Dict = shipAmplifiers;
		selectedShipInfo.AmplifiersConfig_List = list;
	}
}
