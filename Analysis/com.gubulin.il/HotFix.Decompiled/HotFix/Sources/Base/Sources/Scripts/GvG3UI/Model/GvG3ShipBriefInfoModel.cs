using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvG3ShipBriefInfoModel
{
	public string ShipId;

	public int EntityId;

	public string ShipName;

	public int WorkersOnboardCount;

	public int ShipType;

	public int TargetBuildCompleteTime;

	private Action<GvG3ShipBriefInfoModel> _onChange;

	public ShipStateModel ShipStateModel => Singleton<WorldStateManager>.Instance.TryGetShip(EntityId);

	public eShipBuildState ShipBuildState { get; }

	public bool IsPendingAcceptance => (ShipBuildState == eShipBuildState.Building || ShipBuildState == eShipBuildState.Rebuilding) && GameController.Instance.GetServerTime() > TargetBuildCompleteTime;

	public string ShipIcon
	{
		get
		{
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(ShipType);
			return ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
		}
	}

	public GvG3ShipBriefInfoModel(GvGShipDetailModel detailModel, Action<GvG3ShipBriefInfoModel> changeAction)
	{
		ShipId = detailModel.ShipId;
		EntityId = detailModel.EntityId;
		ShipName = detailModel.ShipName;
		WorkersOnboardCount = detailModel.WorkersOnboardCount;
		ShipType = detailModel.ShipType;
		_onChange = changeAction;
		ShipBuildState = detailModel.ShipBuildState;
		TargetBuildCompleteTime = detailModel.TargetBuildCompleteTime;
		if (ShipStateModel != null)
		{
			ShipStateModel shipStateModel = ShipStateModel;
			shipStateModel.OnChange = (Action<ShipStateModel>)Delegate.Combine(shipStateModel.OnChange, new Action<ShipStateModel>(UpdateShipStateInfo));
			ShipStateModel shipStateModel2 = ShipStateModel;
			shipStateModel2.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Combine(shipStateModel2.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(UpdateShipStateInfo));
		}
	}

	public void UpdateShipBriefInfo()
	{
		_onChange?.Invoke(this);
	}

	private void UpdateShipStateInfo(ShipStateModel newState)
	{
		WorkersOnboardCount = newState.WorkersOnboardCount;
		_onChange?.Invoke(this);
	}

	public void RemoveOnShipStateChange()
	{
		if (ShipStateModel != null)
		{
			ShipStateModel shipStateModel = ShipStateModel;
			shipStateModel.OnChange = (Action<ShipStateModel>)Delegate.Remove(shipStateModel.OnChange, new Action<ShipStateModel>(UpdateShipStateInfo));
			ShipStateModel shipStateModel2 = ShipStateModel;
			shipStateModel2.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Remove(shipStateModel2.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(UpdateShipStateInfo));
		}
	}
}
