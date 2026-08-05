using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvG3MyShipsBriefInfoModel
{
	private GvGMode3ObserverRecord _recordData;

	private List<GvGShipDetailModel> _shipsDetail;

	private Action<GvG3ShipBriefInfoModel> _changeAction;

	public List<GvG3ShipBriefInfoModel> ShipsBriefInfo;

	public GvG3MyShipsBriefInfoModel(Action<GvG3ShipBriefInfoModel> changeAction)
	{
		_changeAction = changeAction;
		_shipsDetail = new List<GvGShipDetailModel>();
		ShipsBriefInfo = new List<GvG3ShipBriefInfoModel>();
	}

	public void DataClear()
	{
		ShipsBriefInfoClear();
		_shipsDetail.Clear();
		_recordData = null;
		_changeAction = null;
	}

	public void GetData(Action onSuccess)
	{
		_recordData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		InitData();
		onSuccess?.Invoke();
	}

	public void RefreshData(string shipId)
	{
		_recordData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		RefreshShipData(shipId);
	}

	public void OnShipsCountChange(Action onFinished)
	{
		_recordData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		InitData();
		onFinished?.Invoke();
	}

	public GvGShipDetailModel GetDetailModel(string shipId)
	{
		return _shipsDetail.FirstOrDefault((GvGShipDetailModel t) => shipId == t.ShipId);
	}

	private void InitData()
	{
		_shipsDetail.Clear();
		ShipsBriefInfoClear();
		foreach (GvGMode3ShipModel ship in _recordData.Ships)
		{
			GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel
			{
				WorkersOnboardCountLimit = _recordData.WorkersOnboardCountLimit,
				AmplifierCountLimit = _recordData.AmplifierCountLimit
			};
			gvGShipDetailModel.SetRecordData(ship);
			_shipsDetail.Add(gvGShipDetailModel);
			ShipsBriefInfo.Add(new GvG3ShipBriefInfoModel(gvGShipDetailModel, _changeAction));
		}
	}

	private void RefreshShipData(string shipId)
	{
		int num = -1;
		for (int num2 = _shipsDetail.Count - 1; num2 >= 0; num2--)
		{
			if (!(_shipsDetail[num2].ShipId != shipId))
			{
				num = num2;
				break;
			}
		}
		if (num == -1)
		{
			return;
		}
		GvGShipDetailModel gvGShipDetailModel = null;
		foreach (GvGMode3ShipModel ship in _recordData.Ships)
		{
			if (!(ship.ShipId != shipId))
			{
				gvGShipDetailModel = new GvGShipDetailModel
				{
					WorkersOnboardCountLimit = _recordData.WorkersOnboardCountLimit,
					AmplifierCountLimit = _recordData.AmplifierCountLimit
				};
				gvGShipDetailModel.SetRecordData(ship);
			}
		}
		_shipsDetail[num] = gvGShipDetailModel;
		ShipsBriefInfo[num].RemoveOnShipStateChange();
		ShipsBriefInfo[num] = new GvG3ShipBriefInfoModel(gvGShipDetailModel, _changeAction);
		ShipsBriefInfo[num].UpdateShipBriefInfo();
	}

	private void ShipsBriefInfoClear()
	{
		if (ShipsBriefInfo != null)
		{
			for (int i = 0; i < ShipsBriefInfo.Count; i++)
			{
				ShipsBriefInfo[i].RemoveOnShipStateChange();
			}
			ShipsBriefInfo.Clear();
		}
	}
}
