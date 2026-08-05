using System;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class FlagShipStateModel
{
	public int CampId;

	public int StayIslandId;

	public FlagShipAttackEvent AttackEvent = null;

	public Action<FlagShipStateModel> OnChangeStayIslandId = delegate
	{
	};

	public Action<FlagShipStateModel> OnChangeAttackEvent = delegate
	{
	};

	public void SyncFlagShipStayIslandId(FlagShipStateInfo info)
	{
		StayIslandId = info.ShipTargetIslandId;
		OnChangeStayIslandId?.Invoke(this);
	}

	public void SyncFlagShipAttackEvent(FlagShipAttackEvent attackEvent)
	{
		AttackEvent = attackEvent;
		OnChangeAttackEvent?.Invoke(this);
	}
}
