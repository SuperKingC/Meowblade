using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGShipDetail;

namespace UI.GvGWorldMap3;

public class UI_com_ShipsInfo : GComponent
{
	public Controller OperationMode;

	public GList ShipList;

	public const string URL = "ui://4eq8fgd2bqhp1u";

	public static string Name = "UI_com_ShipsInfo";

	private bool _initFinished;

	private UI_main_GvGWorldMap3 _mainUi;

	public string CurrentSelectedShipId { get; private set; }

	public GvG3MyShipsBriefInfoModel Data { get; private set; }

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1u";
	}

	public static UI_com_ShipsInfo CreateInstance()
	{
		return (UI_com_ShipsInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipsInfo");
	}

	public static UI_com_ShipsInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipsInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OperationMode = ((GComponent)this).GetController("OperationMode");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
	}

	public void Init(UI_main_GvGWorldMap3 mainUi)
	{
		_mainUi = mainUi;
		Data = new GvG3MyShipsBriefInfoModel(UpdateShipInfo);
		SharedMessenger.AddListener<string>("CLOSE_UI", Update);
		SharedMessenger.AddListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunch);
		SharedMessenger.AddListener("ON_GVG3_SHIP_DESTROY", OnShipsCountChange);
		SharedMessenger.AddListener("ON_SHIP_GROUP_COUNT_LIMIT_CHANGE", RenderShipsList);
		SharedMessenger.AddListener("ON_SHIP_BUILDING_STATE_CHANGE", OnShipBuildStateChange);
		SharedMessenger.AddListener("ON_SHIP_COUNT_LIMIT_CHANGE", OnShipCountLimitChange);
		GvGTalent勘探强化Manager instance = Singleton<GvGTalent勘探强化Manager>.Instance;
		instance.OnChangeShipCountDown = (Action)Delegate.Combine(instance.OnChangeShipCountDown, new Action(RenderShipsList));
		Data.GetData(RenderShipsList);
	}

	public void BeforeDestroy()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		SharedMessenger.RemoveListener<string>("CLOSE_UI", Update);
		SharedMessenger.RemoveListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunch);
		SharedMessenger.RemoveListener("ON_GVG3_SHIP_DESTROY", OnShipsCountChange);
		SharedMessenger.RemoveListener("ON_SHIP_GROUP_COUNT_LIMIT_CHANGE", RenderShipsList);
		SharedMessenger.RemoveListener("ON_SHIP_BUILDING_STATE_CHANGE", OnShipBuildStateChange);
		SharedMessenger.RemoveListener("ON_SHIP_COUNT_LIMIT_CHANGE", OnShipCountLimitChange);
		GvGTalent勘探强化Manager instance = Singleton<GvGTalent勘探强化Manager>.Instance;
		instance.OnChangeShipCountDown = (Action)Delegate.Remove(instance.OnChangeShipCountDown, new Action(RenderShipsList));
		if (Timers.inst.Exists(new TimerCallback(UpdateBuildingState)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateBuildingState));
		}
		Data?.DataClear();
		_mainUi = null;
	}

	public void UpdateType()
	{
		bool flag = _mainUi.IslandSelect.selectedIndex == 2 || _mainUi.IslandSelect.selectedIndex == 3 || _mainUi.IslandSelect.selectedIndex == 4;
		OperationMode.selectedIndex = (flag ? 1 : 0);
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo)
			{
				uI_com_ShipInfo.OperationMode.selectedIndex = OperationMode.selectedIndex;
			}
		}
		if (flag)
		{
			UpdateShipListOnOperationMode();
		}
		else
		{
			UpdateShipListEnabled();
		}
	}

	public void UpdateShipListEnabled()
	{
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo)
			{
				((GObject)uI_com_ShipInfo).enabled = true;
			}
		}
	}

	public void LockShip(int shipEntityId)
	{
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo && i < Data.ShipsBriefInfo.Count)
			{
				((GObject)uI_com_ShipInfo).enabled = Data.ShipsBriefInfo[i].EntityId == shipEntityId;
			}
		}
	}

	private void UpdateShipListOnOperationMode()
	{
		ClearShipState();
		int selectedIndex = _mainUi.IslandSelect.selectedIndex;
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (!(((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo))
			{
				continue;
			}
			if (ShipIsNotReady(i))
			{
				((GObject)uI_com_ShipInfo).enabled = false;
				continue;
			}
			ShipStateModel shipStateModel = Data.ShipsBriefInfo[i].ShipStateModel;
			if (selectedIndex == 2 && ShipCanNotExecuteIslandAction(shipStateModel))
			{
				((GObject)uI_com_ShipInfo).enabled = false;
			}
			else if (selectedIndex == 3 && ShipCanNotExecuteSweep(shipStateModel))
			{
				((GObject)uI_com_ShipInfo).enabled = false;
			}
			else if (selectedIndex == 4 && ShipCanNotRepeatedAttack(shipStateModel))
			{
				((GObject)uI_com_ShipInfo).enabled = false;
			}
			else
			{
				((GObject)uI_com_ShipInfo).enabled = true;
			}
		}
	}

	private void ClearShipState()
	{
		CurrentSelectedShipId = string.Empty;
		Singleton<WorldStateManager>.Instance.SelectMyShip(CurrentSelectedShipId);
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo && uI_com_ShipInfo.IsSelected.selectedIndex == 1)
			{
				uI_com_ShipInfo.IsSelected.selectedIndex = 0;
			}
		}
		ShipList.ResizeToFit(ShipList.numItems);
		((GComponent)ShipList).EnsureBoundsCorrect();
	}

	private bool ShipIsNotReady(int index)
	{
		if (index >= Data.ShipsBriefInfo.Count)
		{
			return true;
		}
		GvG3ShipBriefInfoModel gvG3ShipBriefInfoModel = Data.ShipsBriefInfo[index];
		ShipStateModel shipStateModel = gvG3ShipBriefInfoModel.ShipStateModel;
		return shipStateModel == null;
	}

	private bool ShipCanNotExecuteIslandAction(ShipStateModel shipState)
	{
		int currentIslandId = _mainUi.CurrentIslandId;
		eIslandAction islandActionType = _mainUi.IslandActionType;
		if (shipState.State == eShipState.Fighting || shipState.State == eShipState.DuringFlight || shipState.State == eShipState.SuppressRebellion)
		{
			return true;
		}
		if (shipState.StayIslandId == currentIslandId && islandActionType == eIslandAction.GoTo)
		{
			return true;
		}
		if (shipState.CurrentUnitInfos == null || shipState.CurrentUnitInfos.Count <= 0 || shipState.CurrentUnitInfos.All((GvGMode3UnitInfo unit) => unit.SoldierId == string.Empty) || shipState.WorkersOnboardCount < 1)
		{
			return true;
		}
		if (shipState.CurrentUnitInfos != null && !shipState.CurrentUnitInfos.Any((GvGMode3UnitInfo unit) => unit.CurCnt < unit.Total) && islandActionType == eIslandAction.FillUpSoldier)
		{
			return true;
		}
		return false;
	}

	private bool ShipCanNotRepeatedAttack(ShipStateModel shipState)
	{
		if (shipState.State == eShipState.Fighting || shipState.State == eShipState.DuringFlight || shipState.State == eShipState.SuppressRebellion)
		{
			return true;
		}
		if (shipState.CurrentUnitInfos == null || shipState.CurrentUnitInfos.Count <= 0 || shipState.CurrentUnitInfos.All((GvGMode3UnitInfo unit) => unit.SoldierId == string.Empty) || shipState.WorkersOnboardCount < 1)
		{
			return true;
		}
		return false;
	}

	private bool ShipCanNotExecuteSweep(ShipStateModel shipState)
	{
		int currentIslandId = _mainUi.CurrentIslandId;
		if (shipState.StayIslandId != currentIslandId)
		{
			return true;
		}
		return shipState.State != eShipState.Collecting && shipState.State != eShipState.Stay;
	}

	public void CancelSelectShip()
	{
		if (string.IsNullOrEmpty(CurrentSelectedShipId) || _mainUi.IslandSelect.selectedIndex == 2 || _mainUi.IslandSelect.selectedIndex == 3 || _mainUi.IslandSelect.selectedIndex == 4)
		{
			return;
		}
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (((GComponent)ShipList).GetChildAt(i) is UI_com_ShipInfo uI_com_ShipInfo && uI_com_ShipInfo.IsSelected.selectedIndex == 1)
			{
				uI_com_ShipInfo.IsSelected.selectedIndex = 0;
			}
		}
		ShipList.ResizeToFit(ShipList.numItems);
		((GComponent)ShipList).EnsureBoundsCorrect();
		CurrentSelectedShipId = string.Empty;
		Singleton<WorldStateManager>.Instance.SelectMyShip(CurrentSelectedShipId);
	}

	public void OnShipsCountChange()
	{
		Data.OnShipsCountChange(RenderShipsList);
	}

	private void OnShipLaunch(string shipId)
	{
		Data.OnShipsCountChange(RenderShipsList);
	}

	private void OnShipBuildStateChange()
	{
		Data.OnShipsCountChange(RenderShipsList);
	}

	private void OnShipCountLimitChange()
	{
		Data.OnShipsCountChange(RenderShipsList);
	}

	private void Update(string uiName)
	{
		if (!(uiName != UI_GvGShipDetailPanel.Name) && _initFinished)
		{
			Data.RefreshData(CurrentSelectedShipId);
		}
	}

	private void RenderShipsList()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && !((GObject)ShipList).isDisposed)
		{
			ShipList.itemRenderer = new ListItemRenderer(RenderShipInfo);
			ShipList.numItems = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ShipCountLimit;
			ShipList.ResizeToFit(ShipList.numItems);
			_initFinished = true;
			if (!Timers.inst.Exists(new TimerCallback(UpdateBuildingState)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateBuildingState));
			}
		}
	}

	private void UpdateBuildingState(object param)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			ShipList.itemRenderer = new ListItemRenderer(RenderShipBuildingState);
			ShipList.numItems = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ShipCountLimit;
		}
	}

	private void RenderShipBuildingState(int index, GObject obj)
	{
		if (!(obj is UI_com_ShipInfo uI_com_ShipInfo))
		{
			return;
		}
		GvG3ShipBriefInfoModel gvG3ShipBriefInfoModel = ((Data.ShipsBriefInfo.Count > index) ? Data.ShipsBriefInfo[index] : null);
		if (gvG3ShipBriefInfoModel != null)
		{
			int num = (int)GameController.Instance.GetServerTime();
			int targetBuildCompleteTime = gvG3ShipBriefInfoModel.TargetBuildCompleteTime;
			if (num - targetBuildCompleteTime > 0 && uI_com_ShipInfo.State.selectedIndex == 1)
			{
				uI_com_ShipInfo.State.SetSelectedIndex(3);
			}
		}
	}

	private void RenderShipInfo(int index, GObject obj)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		UI_com_ShipInfo btn = obj as UI_com_ShipInfo;
		ShipStateModel stateInfo;
		if (btn != null)
		{
			GvG3ShipBriefInfoModel gvG3ShipBriefInfoModel = ((Data.ShipsBriefInfo.Count > index) ? Data.ShipsBriefInfo[index] : null);
			stateInfo = gvG3ShipBriefInfoModel?.ShipStateModel;
			btn.RenderBaseInfo(gvG3ShipBriefInfoModel, stateInfo);
			if (gvG3ShipBriefInfoModel != null)
			{
				btn.RenderDetailInfo(gvG3ShipBriefInfoModel, stateInfo);
			}
			btn.Index = index;
			((GObject)btn).data = ((gvG3ShipBriefInfoModel != null) ? gvG3ShipBriefInfoModel.ShipId : string.Empty);
			((GObject)btn).onClick.Set(new EventCallback1(SelectShip));
			((GObject)btn.Icon).onClick.Set(new EventCallback1(OnClickShipIcon));
			((GObject)btn.FocusShip).onClick.Set(new EventCallback1(OnClickShipIcon));
			((GObject)btn.FillupSoldier).onClick.Set(new EventCallback1(OnClickFillupSoldier));
			((GObject)btn.DetectResourceBtn).onClick.Set(new EventCallback1(OnDetectResourceBtn));
		}
		void OnClickFillupSoldier(EventContext context)
		{
			if (CurrentSelectedShipId == stateInfo.ShipId)
			{
				context.StopPropagation();
				if (!stateInfo.CanFillUpUnits())
				{
					"CannotFillupSoldierTips".ToShowLanguageTip();
				}
				else if (stateInfo.SoldierIsFull())
				{
					"GvG3SoldierAlreadyFullTips".ToShowLanguageTip();
				}
				else
				{
					Singleton<WorldStateManager>.Instance.FillUpShipSoldiers(stateInfo.EntityId);
				}
			}
		}
		void OnClickShipIcon(EventContext context)
		{
			if (btn.State.selectedIndex == 0 && stateInfo != null && CurrentSelectedShipId == stateInfo.ShipId)
			{
				context.StopPropagation();
				GvGWorldMapController.Instance.FocusShipByEntityId(stateInfo.EntityId);
			}
		}
		void OnDetectResourceBtn(EventContext context)
		{
			double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
			if (CurrentSelectedShipId == stateInfo.ShipId)
			{
				context.StopPropagation();
				if (Singleton<GvGTalent勘探强化Manager>.Instance.IsLoaded())
				{
					if (Singleton<GvGTalent勘探强化Manager>.Instance.GetShipCountDown(stateInfo.ShipId).IsExpired())
					{
						Singleton<GvGTalent勘探强化Manager>.Instance.DetectIslandResource(stateInfo.ShipId);
					}
					else
					{
						"GvGTalentDetectorCoolingDown".ToShowLanguageTip();
					}
				}
			}
		}
	}

	private void SelectShip(EventContext context)
	{
		context.StopPropagation();
		UI_com_ShipInfo btn = (UI_com_ShipInfo)(object)context.sender;
		string shipId = ((GObject)(btn?)).data.ToString();
		int selectedIndex = _mainUi.IslandSelect.selectedIndex;
		if (selectedIndex == 2 || selectedIndex == 3 || selectedIndex == 4)
		{
			CurrentSelectedShipId = shipId;
			SetShipInfoComState();
			switch (selectedIndex)
			{
			case 2:
				_mainUi.OperationDialog.ShowFlightData();
				break;
			case 3:
				_mainUi.SweepOperationDialog.DisplayOnSelectShip(_mainUi.ShipsInfo.Data.GetDetailModel(CurrentSelectedShipId).EntityId, CurrentSelectedShipId);
				_mainUi.DisplaySweepDialog.Play();
				break;
			case 4:
			{
				List<ShipPlanSoldier> soldiers = _mainUi.ShipsInfo.Data.GetDetailModel(CurrentSelectedShipId).ShipState.GroupInfo.Select((GvGMode3UnitInfo info) => new ShipPlanSoldier(info)).ToList();
				_mainUi.ShipPlanOperationDialog.DisplayOnSelectShip(CurrentSelectedShipId, soldiers);
				_mainUi.DisplayShipPlanDialog.Play();
				break;
			}
			}
		}
		else if (btn.IsSelected.selectedIndex == 0)
		{
			btn.SummaryModeOnClick(delegate
			{
				CurrentSelectedShipId = shipId;
				Singleton<WorldStateManager>.Instance.SelectMyShip(CurrentSelectedShipId);
				SetShipInfoComState();
			}, delegate
			{
				_mainUi.OpenShipOverviewPanel(btn.Index);
			});
		}
		else if (btn.IsSelected.selectedIndex == 1)
		{
			OpenShipDetailPanel();
		}
	}

	private void OpenShipDetailPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGShipDetailPanel.Name, new Dictionary<string, object>
		{
			{
				"GvGShipDetailModelData",
				Data.GetDetailModel(CurrentSelectedShipId)
			},
			{ "OnClose", null }
		});
	}

	public void OpenShipDetailArmyPage()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGShipDetailPanel.Name, new Dictionary<string, object>
		{
			{
				"GvGShipDetailModelData",
				Data.GetDetailModel(CurrentSelectedShipId)
			},
			{ "OnClose", null },
			{ "ShowFillUpTip", true },
			{ "ShowPageIndex", 1 }
		});
	}

	private void SetShipInfoComState()
	{
		for (int i = 0; i < ShipList.numItems; i++)
		{
			UI_com_ShipInfo uI_com_ShipInfo = ((GComponent)ShipList).GetChildAt(i) as UI_com_ShipInfo;
			if (((GObject)(uI_com_ShipInfo?)).data != null)
			{
				bool flag = ((GObject)uI_com_ShipInfo).data.ToString() == CurrentSelectedShipId;
				uI_com_ShipInfo.IsSelected.selectedIndex = (flag ? 1 : 0);
				if (flag)
				{
					RenderShipInfo(i, (GObject)(object)uI_com_ShipInfo);
				}
			}
		}
		ShipList.ResizeToFit(ShipList.numItems);
		((GComponent)ShipList).EnsureBoundsCorrect();
	}

	private void UpdateShipInfo(GvG3ShipBriefInfoModel infoModel)
	{
		for (int i = 0; i < ShipList.numItems; i++)
		{
			UI_com_ShipInfo uI_com_ShipInfo = ((GComponent)ShipList).GetChildAt(i) as UI_com_ShipInfo;
			if (((GObject)(uI_com_ShipInfo?)).data != null && !(((GObject)uI_com_ShipInfo).data.ToString() != infoModel.ShipId))
			{
				uI_com_ShipInfo.Rendered = false;
				RenderShipInfo(i, (GObject)(object)uI_com_ShipInfo);
			}
		}
		if (infoModel.ShipStateModel != null && infoModel.ShipStateModel.IsSoulGuideCoolingDown)
		{
			CancelSelectShip();
			return;
		}
		ShipList.ResizeToFit(ShipList.numItems);
		((GComponent)ShipList).EnsureBoundsCorrect();
	}
}
