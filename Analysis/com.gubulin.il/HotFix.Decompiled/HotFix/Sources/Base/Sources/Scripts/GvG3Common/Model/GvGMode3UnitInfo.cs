using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.LegendItemInfo;
using UI.LegendItems;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class GvGMode3UnitInfo
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(2)]
	public int PotentialLevel;

	[ProtoMember(3)]
	public int PerTeamMemberCnt;

	[ProtoMember(4)]
	public int Total;

	[ProtoMember(5)]
	public int CurCnt;

	[ProtoMember(6)]
	public int SoldierLevel;

	[ProtoMember(7)]
	public int[] EquippedItems;

	[ProtoMember(8)]
	public string EquippedItemsDetail;

	[ProtoMember(9)]
	public string JsonGameEntityData;

	[ProtoMember(10)]
	public int CombatPower;

	public RealTimeCombatPowerModel RealTimeCombatPowerModel;

	public int RealTimeCombatPower;

	public float RealTimeAttack;

	public float RealTimeDefense;

	public float RealTimeHealth;

	public static float _GvG3ShipSoldiersNumberAlertLevel = -1.5f;

	private readonly string _doNotShowAgain = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}_ShipChangeLegendItemTip";

	public static float GvG3ShipSoldiersNumberAlertLevel
	{
		get
		{
			if (_GvG3ShipSoldiersNumberAlertLevel > -1f)
			{
				return _GvG3ShipSoldiersNumberAlertLevel;
			}
			return _GvG3ShipSoldiersNumberAlertLevel = "GvG3ShipSoldiersNumberAlertLevel".ToConfiguration<float>();
		}
	}

	public bool SoldierNumberNotEnough => (float)CurCnt < (float)Total * GvG3ShipSoldiersNumberAlertLevel;

	public int UnitCombatPower => CombatPower * CurCnt;

	public int PerTeamCombatPower => CombatPower * PerTeamMemberCnt;

	public void UpdateUnitInfo(C2S_GetUnitDetailInfo.Response response)
	{
		JsonGameEntityData = response.jsonGameEntityData;
		EquippedItemsDetail = response.EquippedItemsDetail;
		RealTimeCombatPowerModel = response.Model.Clone();
		RealTimeCombatPower = response.RealTimeCombatPower;
		RealTimeAttack = response.RealTimeAttack;
		RealTimeDefense = response.RealTimeDefense;
		RealTimeHealth = response.RealTimeHealth;
	}

	public GvGMode3UnitInfo Clone()
	{
		return new GvGMode3UnitInfo
		{
			SoldierId = SoldierId,
			PotentialLevel = PotentialLevel,
			PerTeamMemberCnt = PerTeamMemberCnt,
			Total = Total,
			CurCnt = CurCnt,
			SoldierLevel = SoldierLevel,
			EquippedItems = (int[])EquippedItems.Clone(),
			EquippedItemsDetail = EquippedItemsDetail
		};
	}

	public LegendItemUi GetLegendItemCache(long instanceId)
	{
		return (instanceId <= 0) ? null : LegendItemsHelper.GetLegendItemUi(instanceId);
	}

	public void ShowLegendItemInfo(int shipEntityId, long legendItemId, bool allowChange, int slotIndex = -1)
	{
		if (!allowChange)
		{
			Singleton<WorldStateManager>.Instance.GetUnitDetailInfo(shipEntityId, SoldierId, LoadLegendItem);
		}
		else
		{
			LoadLegendItem();
		}
		void GotoChange()
		{
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(P_0.item, SoldierId, slotIndex, 7, null, null, 0, canChangeLockState: false, LegendItemsShowType.Show, shipEntityId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, P_0.uiParameters);
		}
		void LoadLegendItem()
		{
			if (legendItemId <= 0)
			{
				OpenLegendItems();
			}
			else
			{
				LegendItemUi item;
				if (!allowChange)
				{
					List<global::Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem> source = JsonHelper.ToObject<List<global::Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>>(EquippedItemsDetail);
					global::Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem legendItem = source.FirstOrDefault((global::Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem legendDetail) => legendDetail.InstanceId == legendItemId);
					if (legendItem == null)
					{
						return;
					}
					global::Shift.Legion.Common.Models.LegendItem.LegendItem legendItem2 = new global::Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, legendItem);
					item = new LegendItemUi(legendItem2.InstanceId, legendItem2);
				}
				else
				{
					item = GetLegendItemCache(legendItemId);
				}
				Dictionary<string, object> uiParameters = new Dictionary<string, object> { { "GvGModeCanChange", allowChange } };
				if (allowChange)
				{
					GotoChange();
				}
				else
				{
					ShowDetails();
				}
			}
		}
		void OpenLegendItems()
		{
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.GvGModeChoice, legendItemId, SoldierId, slotIndex, shipEntityId);
			LegendItemsHelper.OpenLegendItemBlueprintListPanel(delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
			});
		}
		void ShowDetails()
		{
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(P_0.item, "", -1, 7, null, null, 0, canChangeLockState: false, LegendItemsShowType.Show, shipEntityId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, P_0.uiParameters);
		}
	}
}
