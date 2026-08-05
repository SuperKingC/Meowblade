using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Extension;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.GvGWorldMap3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_WorkerPage : GComponent, IGvGShipDetailPage
{
	public Controller State;

	public GImage n70;

	public GImage n88;

	public GImage n75;

	public GImage n84;

	public GTextField n74;

	public GTextField n86;

	public GImage n90;

	public GTextField n89;

	public GTextField n87;

	public UI_com_NavigatingStatus NavigatingStatus;

	public UI_com_MiningStatus MiningStatus;

	public UI_com_BattleStatus BattleStatus;

	public UI_btn_AddWorker AddWorker;

	public UI_btn_ReduceWorker ReduceWorker;

	public GList workersBackList;

	public GList workersList;

	public GTextField n80;

	public GTextField TotalFreeWorkers;

	public GGroup n82;

	public GTextField WorkersOnboard;

	public UI_btn_ConfirnWorkersBtn ConfirnWorkersBtn;

	public const string URL = "ui://u6x0b1gnzpu41p";

	public static string Name = "UI_WorkerPage";

	private const string NoMiningSpine = "sailorworker";

	private const string NoMiningSkin = "sailorworker";

	private const string NoMiningAnimation = "idle";

	private const string GvGMode3ShipWorkersChanged = "GVG_MODE3_SHIP_WORKERS_CHANGED";

	private const string GvgAutoFillWorkersTip = "GvgAutoFillWorkersTip";

	private GvGShipDetailModel _data;

	private UI_GvGShipDetailPanel _parentPanel;

	private ShipStateModel _stateData;

	private RealTimeShipSummarySpeedModel _speedModel;

	private bool IsInitRendered;

	public int MofifiedWorkers;

	private bool IsInitNoMiningAnim;

	private bool IsInitMiningAnim;

	private bool IsInitNavigatingAnim;

	private int StorehouseLimit = -1;

	private List<GameObject> AnimList;

	private HashSet<string> ChangedSelectedMinerals;

	private bool IsSelectedMineralChanged => ChangedSelectedMinerals.Count > 0;

	private int AvailableWorkersLeft => Dungeon.GetFreeManPower(GameManagers.Instance);

	private int WorkersOnboardCountLimit => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.WorkersOnboardCountLimit;

	public int PageIndex { get; set; }

	public bool PageActivated { get; set; }

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41p";
	}

	public static UI_WorkerPage CreateInstance()
	{
		return (UI_WorkerPage)(object)UIPackage.CreateObject("GvGShipDetail", "WorkerPage");
	}

	public static UI_WorkerPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n74 = (GTextField)((GComponent)this).GetChild("n74");
		string id = "ui://u6x0b1gnzpu41p".Replace("ui://", "") + "-" + ((GObject)n74).id;
		((GObject)n74).text = LanguagesManager.GetDesc(id);
		n86 = (GTextField)((GComponent)this).GetChild("n86");
		string id2 = "ui://u6x0b1gnzpu41p".Replace("ui://", "") + "-" + ((GObject)n86).id;
		((GObject)n86).text = LanguagesManager.GetDesc(id2);
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n89 = (GTextField)((GComponent)this).GetChild("n89");
		string id3 = "ui://u6x0b1gnzpu41p".Replace("ui://", "") + "-" + ((GObject)n89).id;
		((GObject)n89).text = LanguagesManager.GetDesc(id3);
		n87 = (GTextField)((GComponent)this).GetChild("n87");
		string id4 = "ui://u6x0b1gnzpu41p".Replace("ui://", "") + "-" + ((GObject)n87).id;
		((GObject)n87).text = LanguagesManager.GetDesc(id4);
		NavigatingStatus = (UI_com_NavigatingStatus)(object)((GComponent)this).GetChild("NavigatingStatus");
		MiningStatus = (UI_com_MiningStatus)(object)((GComponent)this).GetChild("MiningStatus");
		BattleStatus = (UI_com_BattleStatus)(object)((GComponent)this).GetChild("BattleStatus");
		AddWorker = (UI_btn_AddWorker)(object)((GComponent)this).GetChild("AddWorker");
		ReduceWorker = (UI_btn_ReduceWorker)(object)((GComponent)this).GetChild("ReduceWorker");
		workersBackList = (GList)((GComponent)this).GetChild("workersBackList");
		workersList = (GList)((GComponent)this).GetChild("workersList");
		n80 = (GTextField)((GComponent)this).GetChild("n80");
		string id5 = "ui://u6x0b1gnzpu41p".Replace("ui://", "") + "-" + ((GObject)n80).id;
		((GObject)n80).text = LanguagesManager.GetDesc(id5);
		TotalFreeWorkers = (GTextField)((GComponent)this).GetChild("TotalFreeWorkers");
		n82 = (GGroup)((GComponent)this).GetChild("n82");
		WorkersOnboard = (GTextField)((GComponent)this).GetChild("WorkersOnboard");
		ConfirnWorkersBtn = (UI_btn_ConfirnWorkersBtn)(object)((GComponent)this).GetChild("ConfirnWorkersBtn");
	}

	public void Init(GvGShipDetailModel detailData, UI_GvGShipDetailPanel parentPanel)
	{
		_data = detailData;
		_parentPanel = parentPanel;
		_stateData = _parentPanel.StateData;
		IsInitRendered = false;
		IsInitNoMiningAnim = false;
		IsInitMiningAnim = false;
		IsInitNavigatingAnim = false;
		((GObject)ConfirnWorkersBtn).enabled = false;
		ShipStateModel stateData = _stateData;
		stateData.OnShipSummaryChange = (Action)Delegate.Combine(stateData.OnShipSummaryChange, new Action(OnShipSummaryChange));
		ShipStateModel stateData2 = _stateData;
		stateData2.OnChange = (Action<ShipStateModel>)Delegate.Combine(stateData2.OnChange, new Action<ShipStateModel>(OnChangeStateData));
		ShipStateModel stateData3 = _stateData;
		stateData3.OnCollectingConfigChange = (Action)Delegate.Combine(stateData3.OnCollectingConfigChange, new Action(OnCollectingConfigChange));
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Combine(instance.OnChange, new Action(UpdateCurrentMining));
		AnimList = new List<GameObject>();
		ChangedSelectedMinerals = new HashSet<string>();
		StorehouseLimit = -1;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		((GObject)AddWorker).onClick.Set(new EventCallback1(OnAddWorker));
		((GObject)ReduceWorker).onClick.Set(new EventCallback1(OnReduceWorker));
		((GObject)ConfirnWorkersBtn).onClick.Set(new EventCallback1(OnConfirmWorkers));
		((GButton)MiningStatus.MiningDetailPages.OneClickCheckBox).onChanged.Set(new EventCallback1(OnOneClickCheckBoxChange));
		((GObject)MiningStatus.MiningDetailPages.ConfirmToMineBtn).onClick.Set(new EventCallback1(OnClickConfirmToMineBtn));
		((GObject)MiningStatus.MiningDetailPages.ChangeOptionBtn).onClick.Set(new EventCallback1(OnChangeOption));
		((GObject)MiningStatus.MiningDetailPages.CollectBuff).onClick.Set(new EventCallback1(ShowRealTimeEfficiencyText));
		((GObject)NavigatingStatus.SpeedBuff).onClick.Set(new EventCallback1(ShowRealTimeEfficiencyText));
		SharedMessenger.AddListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
		((GObject)MiningStatus.MiningDetailPages.miningDesc).onClickLink.Set(new EventCallback1(ShowMiningPriorityDescTip));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)AddWorker).onClick.Clear();
		((GObject)ReduceWorker).onClick.Clear();
		((GObject)ConfirnWorkersBtn).onClick.Clear();
		((GObject)MiningStatus.MiningDetailPages.ConfirmToMineBtn).onClick.Clear();
		((GObject)MiningStatus.MiningDetailPages.ChangeOptionBtn).onClick.Clear();
		((GObject)MiningStatus.MiningDetailPages.CollectBuff).onClick.Clear();
		((GObject)NavigatingStatus.SpeedBuff).onClick.Clear();
		ShipStateModel stateData = _stateData;
		stateData.OnShipSummaryChange = (Action)Delegate.Remove(stateData.OnShipSummaryChange, new Action(OnShipSummaryChange));
		ShipStateModel stateData2 = _stateData;
		stateData2.OnChange = (Action<ShipStateModel>)Delegate.Remove(stateData2.OnChange, new Action<ShipStateModel>(OnChangeStateData));
		ShipStateModel stateData3 = _stateData;
		stateData3.OnCollectingConfigChange = (Action)Delegate.Remove(stateData3.OnCollectingConfigChange, new Action(OnCollectingConfigChange));
		SharedMessenger.RemoveListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Remove(instance.OnChange, new Action(UpdateCurrentMining));
		((GObject)MiningStatus.MiningDetailPages.miningDesc).onClickLink.Clear();
	}

	public void OnActivate()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		PageActivated = true;
		RenderPage();
		if (!Timers.inst.Exists(new TimerCallback(RefreshRealTimeCollectingEfficiencyPerSeconds)))
		{
			Timers.inst.Add(30f, 0, new TimerCallback(RefreshRealTimeCollectingEfficiencyPerSeconds));
		}
	}

	public void OnInactivate()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		PageActivated = false;
		if (Timers.inst.Exists(new TimerCallback(RefreshRealTimeCollectingEfficiencyPerSeconds)))
		{
			Timers.inst.Remove(new TimerCallback(RefreshRealTimeCollectingEfficiencyPerSeconds));
		}
	}

	public void OnDestroy()
	{
		foreach (GameObject anim in AnimList)
		{
			if ((Object)(object)anim != (Object)null)
			{
				Object.Destroy((Object)(object)anim);
			}
		}
		if (IsInitMiningAnim)
		{
			MiningStatus.MiningDetailPages.MiningCave.OnDestroy();
		}
		if (IsInitNavigatingAnim)
		{
			NavigatingStatus.OarDeck.OnDestroy();
		}
	}

	public void OnChangeStateData(ShipStateModel shipStateModel)
	{
		UpdateWorkerPageState();
	}

	private void OnShipLaunched(string shipId)
	{
		if (!(shipId != _stateData.ShipId))
		{
			IsInitRendered = false;
			RenderPage();
		}
	}

	public static void ShowMiningPriorityDescTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		FairyGUITip.ShowTip((GObject)context.sender, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "WorkerMiningPriorityDesc".ToLanguage();
		}, default(Rect), lastSetXy: true);
	}

	private void OnAddWorker(EventContext context)
	{
		int num = _stateData.WorkersOnboardCount + AvailableWorkersLeft;
		int num2 = Mathf.Min(num, WorkersOnboardCountLimit);
		MofifiedWorkers++;
		if (MofifiedWorkers > num2)
		{
			MofifiedWorkers = num2;
		}
		UpdateSpeed();
		((GObject)ConfirnWorkersBtn).enabled = ConfirmWorkersBtnEnabled();
		UpdateIncreasedWorkerList();
		RefreshTotalFreeWorker();
	}

	private void OnReduceWorker(EventContext context)
	{
		if (workersList.numItems == 0)
		{
			return;
		}
		Transition reduce = ((UI_WorkerItem)(object)((GComponent)workersList).GetChildAt(workersList.numItems - 1)).reduce;
		if (!reduce.playing)
		{
			MofifiedWorkers--;
			if (MofifiedWorkers < 0)
			{
				MofifiedWorkers = 0;
			}
			UpdateSpeed();
			((GObject)ConfirnWorkersBtn).enabled = ConfirmWorkersBtnEnabled();
			UpdateDecreasedWorkerList();
			RefreshTotalFreeWorker();
		}
	}

	private void OnConfirmWorkers(EventContext context)
	{
		ILRequestHelper<GvGMode3ChangeShipConfigResponse>.Request((EventContext)null, (Func<Task<GvGMode3ChangeShipConfigResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ChangeShipConfig(_stateData.ShipId, 1, JsonHelper.ToJson(new GvGMode3ChangeShipConfigAction_ChangeWorker
		{
			WorkerCount = MofifiedWorkers
		}))), (Action<GvGMode3ChangeShipConfigResponse>)delegate(GvGMode3ChangeShipConfigResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(_stateData.ShipId).TemporaryData.WorkersOnboardCount = MofifiedWorkers;
				((GObject)ConfirnWorkersBtn).enabled = ConfirmWorkersBtnEnabled();
				UpdateWorkerInfo();
				SharedMessenger.Broadcast("ON_GVG3_ShipWorkersModified");
				GvGMode3ObserverRecord gvGMode3ObserverRecord = GameManagers.Instance.UserArchiveManager.LoadGvGMode3Record();
				GvGMode3ShipModel gvGMode3ShipModel = gvGMode3ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == _stateData.ShipId);
				gvGMode3ShipModel.PermanentData.ManPower = MofifiedWorkers;
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				RefreshTotalFreeWorker();
			}
		});
	}

	private void ConfirmWorkersChange(Action onFinished)
	{
		ILRequestHelper<GvGMode3ChangeShipConfigResponse>.Request((EventContext)null, (Func<Task<GvGMode3ChangeShipConfigResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ChangeShipConfig(_stateData.ShipId, 1, JsonHelper.ToJson(new GvGMode3ChangeShipConfigAction_ChangeWorker
		{
			WorkerCount = MofifiedWorkers
		}))), (Action<GvGMode3ChangeShipConfigResponse>)delegate(GvGMode3ChangeShipConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(_stateData.ShipId).TemporaryData.WorkersOnboardCount = MofifiedWorkers;
				SharedMessenger.Broadcast("ON_GVG3_ShipWorkersModified");
				UpdateWorkerInfo();
				((GObject)ConfirnWorkersBtn).enabled = false;
				onFinished?.Invoke();
				GvGMode3ObserverRecord gvGMode3ObserverRecord = GameManagers.Instance.UserArchiveManager.LoadGvGMode3Record();
				GvGMode3ShipModel gvGMode3ShipModel = gvGMode3ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == _stateData.ShipId);
				gvGMode3ShipModel.PermanentData.ManPower = MofifiedWorkers;
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
			}
		});
	}

	private void OnChangeOption(EventContext context)
	{
		UpdateMiningDetailPages(eMiningPageState.SelectMinerals);
	}

	private void OnSelectDeselectMineralItem(UI_MineralItem slot)
	{
		int nextBtnState = UI_main_IslandOutput.GetNextBtnState(slot.state.selectedIndex);
		SetMineralSlotState(slot, nextBtnState);
		UpdateOneClickSelected();
	}

	private void SetMineralSlotState(UI_MineralItem slot, int slotIndex)
	{
		slot.state.SetSelectedIndex(slotIndex);
		CollectingStockModel collectingStockModel = (CollectingStockModel)((GObject)slot).data;
		string modelId = collectingStockModel.GetModelId();
		if (!slot.IsStateChange())
		{
			ChangedSelectedMinerals.Remove(modelId);
		}
		else
		{
			ChangedSelectedMinerals.Add(modelId);
		}
	}

	private void OnClickConfirmToMineBtn(EventContext context)
	{
		if (IsSelectedMineralChanged)
		{
			OnConfirmToMine();
		}
		else
		{
			UpdateMiningDetailPages(eMiningPageState.CurrentMining);
		}
	}

	public void OnConfirmToMine(Action onFinished = null, Action onEmtySelectionCancel = null)
	{
		List<string> list = new List<string>();
		GList mineralList = MiningStatus.MiningDetailPages.MineralList;
		for (int i = 0; i < mineralList.numItems; i++)
		{
			UI_MineralItem uI_MineralItem = (UI_MineralItem)(object)((GComponent)mineralList).GetChildAt(i);
			if (uI_MineralItem.IsSelected)
			{
				int prior = ((uI_MineralItem.state.selectedIndex == 2) ? 1 : 0);
				CollectingStockModel collectingStockModel = (CollectingStockModel)((GObject)uI_MineralItem).data;
				string miningConfigStr = collectingStockModel.GetMiningConfigStr(prior);
				list.Add(miningConfigStr);
			}
		}
		if (list.Count > 0)
		{
			Singleton<WorldStateManager>.Instance.ChangeShipCollectingInfo(_stateData.EntityId, list, UpdateMiningPage);
		}
		else
		{
			"GvG3CollectingStopTip".ToLanguage().ToConfirmPopup(OnEmtySelectionConfirm, onEmtySelectionCancel, (AlignType)0);
		}
		void OnEmtySelectionConfirm()
		{
			GoTo(_stateData.StayIslandId, _stateData.ShipId);
			OnSuccess();
		}
		void OnSuccess()
		{
			ChangedSelectedMinerals.Clear();
			onFinished?.Invoke();
		}
		void UpdateMiningPage()
		{
			UpdateMiningDetailPages(eMiningPageState.CurrentMining);
			OnSuccess();
		}
	}

	private void OnOneClickCheckBoxChange(EventContext context)
	{
		GList mineralList = MiningStatus.MiningDetailPages.MineralList;
		bool selected = ((GButton)MiningStatus.MiningDetailPages.OneClickCheckBox).selected;
		int slotIndex = (selected ? 1 : 0);
		GObject[] children = ((GComponent)mineralList).GetChildren();
		foreach (GObject val in children)
		{
			UI_MineralItem uI_MineralItem = (UI_MineralItem)(object)val;
			if (uI_MineralItem.IsSelected != selected)
			{
				SetMineralSlotState(uI_MineralItem, slotIndex);
			}
		}
	}

	private void RenderPage()
	{
		if (PageActivated && !IsInitRendered)
		{
			if (_stateData.State == eShipState.NotLaunched)
			{
				InitRenderer(new RealTimeShipSummarySpeedModel());
			}
			else
			{
				Singleton<GvGShipUiInfoManager>.Instance.SyncShipCollectingDetailInfo(_stateData.EntityId, InitRenderer);
			}
		}
		void InitRenderer(RealTimeShipSummarySpeedModel speedModel)
		{
			if (!((GObject)this).isDisposed)
			{
				_speedModel = speedModel;
				IsInitRendered = true;
				UpdateWorkerPageState(isInit: true);
				MofifiedWorkers = _stateData.WorkersOnboardCount;
				UpdateWorkerList();
				TryAutoFillWorkers();
				((GObject)NavigatingStatus.ShipSpeed).text = ((_stateData.State == eShipState.DuringFlight) ? $"{_stateData.ShipSpeed()}" : $"{_speedModel.GetFlightSpeed(MofifiedWorkers)}");
				Singleton<GvGShipUiInfoManager>.Instance.GetRealTimeShipSummarySpeed(_stateData.ShipId, -1, ShowSpeedBuff);
				RenderMiningSpeed();
			}
		}
		void ShowSpeedBuff(RealTimeShipSummarySpeedModel speedModel)
		{
			((GObject)NavigatingStatus.SpeedBuff).visible = _stateData.HasSpeedBuff();
			if (((GObject)NavigatingStatus.SpeedBuff).visible)
			{
				((GObject)NavigatingStatus.SpeedBuff).data = _stateData.SpeedBuffDesc();
			}
		}
	}

	private void RefreshRealTimeCollectingEfficiencyPerSeconds(object param)
	{
		if (State.selectedIndex == 4 && MiningStatus.MiningDetailPages.State.selectedIndex != 2)
		{
			Singleton<GvGShipUiInfoManager>.Instance.SyncRealTimeCollectingEfficiency(_stateData.ShipId);
		}
	}

	private void UpdateWorkerPageState(bool isInit = false)
	{
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_stateData.StayIslandId);
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(_stateData.StayIslandId).Props.Type;
		bool flag = islandStateModel != null && _stateData.State == eShipState.Stay && type != eIslandType.MainMoon && type != eIslandType.Moon;
		if (islandStateModel != null && islandStateModel.IslandId == Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId && _stateData.State == eShipState.Stay)
		{
			State.selectedIndex = 1;
		}
		else if (flag)
		{
			State.selectedIndex = 5;
		}
		else
		{
			State.selectedIndex = (int)_stateData.UiState;
		}
		if (State.selectedIndex == 3)
		{
			UpdateNavigatingStatus();
		}
		else if (State.selectedIndex == 4)
		{
			ShipStateModel stateData = _stateData;
			eMiningPageState miningState = ((stateData != null && stateData.SelectedMinerals?.Count > 0) ? eMiningPageState.CurrentMining : eMiningPageState.SelectMinerals);
			UpdateMiningDetailPages(miningState);
			if (isInit)
			{
				Singleton<GvGStoreHouseManager>.Instance.GetRealtimeStockLimit(delegate(C2S_GetRealTimeStorehouseLimitParModel.Response res)
				{
					StorehouseLimit = res.StorehouseLimit;
					UpdateMiningDetailPages(miningState);
				});
				SyncStoreHouseMineral(miningState);
			}
		}
		if (State.selectedIndex == 5 && MiningStatus.MiningDetailPages.MiningCave.IsRunning)
		{
			MiningStatus.MiningDetailPages.MiningCave.StopMining();
		}
	}

	private void SyncStoreHouseMineral(eMiningPageState miningState)
	{
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			UpdateCurrentMining();
		});
	}

	private static void ShowRealTimeEfficiencyText(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		string desc = val.data.ToString();
		FairyGUITip.ShowTip(val, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = desc;
		});
	}

	private void TryAutoFillWorkers()
	{
		if (_stateData.State != eShipState.NotLaunched && MofifiedWorkers <= 0)
		{
			int num = _stateData.WorkersOnboardCount + AvailableWorkersLeft;
			int num2 = Mathf.Min(num, WorkersOnboardCountLimit);
			if (num2 > 0)
			{
				MofifiedWorkers = num2;
				UpdateIncreasedWorkerList();
				RefreshTotalFreeWorker();
				UpdateSpeed();
				_parentPanel.UpdateWorkerTabHasNotice();
				((GObject)ConfirnWorkersBtn).enabled = ConfirmWorkersBtnEnabled();
				"GvgAutoFillWorkersTip".ToShowLanguageTip();
			}
		}
	}

	private void UpdateWorkerInfo()
	{
		UpdateWorkerList();
		UpdateSpeed();
		_parentPanel.UpdateWorkerTabHasNotice();
	}

	private void UpdateWorkerList()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		MofifiedWorkers = _stateData.WorkersOnboardCount;
		workersList.itemRenderer = new ListItemRenderer(WorkersListItemRenderer);
		workersList.numItems = _stateData.WorkersOnboardCount;
		((GObject)WorkersOnboard).text = $"{_stateData.WorkersOnboardCount}/{WorkersOnboardCountLimit}";
		RefreshTotalFreeWorker();
	}

	private void UpdateIncreasedWorkerList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		workersList.itemRenderer = new ListItemRenderer(WorkersListItemRenderer);
		workersList.numItems = MofifiedWorkers;
		int num = Mathf.Clamp(workersList.numItems - 1, 0, workersList.numItems);
		GObject[] children = ((GComponent)workersList).GetChildren();
		if (workersList.numItems > 0 && children != null && children.Length != 0)
		{
			((UI_WorkerItem)(object)((GComponent)workersList).GetChildAt(num)).increase.Play();
		}
		((GObject)WorkersOnboard).text = $"{MofifiedWorkers}/{WorkersOnboardCountLimit}";
	}

	private void RefreshTotalFreeWorker()
	{
		((GObject)TotalFreeWorkers).text = (AvailableWorkersLeft - MofifiedWorkers + _stateData.WorkersOnboardCount).ToString();
	}

	private void UpdateDecreasedWorkerList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		workersList.itemRenderer = new ListItemRenderer(WorkersListItemRenderer);
		if (workersList.numItems != 0)
		{
			((UI_WorkerItem)(object)((GComponent)workersList).GetChildAt(workersList.numItems - 1)).reduce.Play((PlayCompleteCallback)delegate
			{
				workersList.numItems = MofifiedWorkers;
				((GObject)WorkersOnboard).text = $"{MofifiedWorkers}/{WorkersOnboardCountLimit}";
			});
		}
	}

	private void WorkersListItemRenderer(int index, GObject obj)
	{
		UI_WorkerItem uI_WorkerItem = (UI_WorkerItem)(object)obj;
		if (index < _stateData.WorkersOnboardCount)
		{
			uI_WorkerItem.HasWorker.selectedIndex = 2;
		}
		else if (index < MofifiedWorkers)
		{
			uI_WorkerItem.HasWorker.selectedIndex = 1;
		}
		else
		{
			uI_WorkerItem.HasWorker.selectedIndex = 0;
		}
	}

	private void UpdateNavigatingStatus()
	{
		InitNavigatingAninmation();
	}

	private void UpdateMiningDetailPages(eMiningPageState miningState)
	{
		bool flag = _stateData.CollectingEfficiencyModel != null && _stateData.CollectingEfficiencyModel.HasRealTimeCollectingEfficiency();
		((GObject)MiningStatus.MiningDetailPages.CollectBuff).visible = flag;
		if (flag)
		{
			((GObject)MiningStatus.MiningDetailPages.CollectBuff).data = _stateData.CollectingEfficiencyModel.GetCollectingEfficiencyText();
		}
		if (MiningStatus.State.selectedIndex != 0)
		{
			UI_com_MiningDetailPages miningDetailPages = MiningStatus.MiningDetailPages;
			miningDetailPages.State.selectedIndex = (int)miningState;
			switch (miningState)
			{
			case eMiningPageState.SelectMinerals:
				UpdateSelectMinerals(miningDetailPages);
				break;
			case eMiningPageState.CurrentMining:
				UpdateCurrentMining(miningDetailPages);
				break;
			case eMiningPageState.CurrentNoMining:
				UpdateCurrentNoMining(miningDetailPages);
				break;
			}
		}
	}

	private void UpdateSelectMinerals(UI_com_MiningDetailPages panel)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		if (_stateData.SelectedMinerals != null)
		{
			panel.MineralList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MineralItemRenderer(i, (UI_MineralItem)(object)o);
			};
			panel.MineralList.numItems = _stateData.AvailableMinerals.Count;
			UpdateOneClickSelected();
		}
	}

	private void UpdateCurrentMining()
	{
		ShipStateModel stateData = _stateData;
		eMiningPageState eMiningPageState = ((stateData != null && stateData.SelectedMinerals?.Count > 0) ? eMiningPageState.CurrentMining : eMiningPageState.SelectMinerals);
		if (eMiningPageState == eMiningPageState.CurrentMining)
		{
			UpdateCurrentMining(MiningStatus.MiningDetailPages);
		}
	}

	private void UpdateCurrentMining(UI_com_MiningDetailPages panel)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		if (State.selectedIndex == 4 && _stateData.SelectedMinerals != null)
		{
			panel.MiningMineralList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MiningMineralItemRenderer(i, (UI_MiningMineralItem)(object)o);
			};
			panel.MiningMineralList.numItems = _stateData.SelectedMinerals.Count;
			InitMiningAnimation();
		}
	}

	private void UpdateCurrentNoMining(UI_com_MiningDetailPages panel)
	{
		InitNoMiningAnimation();
	}

	private void MineralItemRenderer(int index, UI_MineralItem item)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		string itemId = _stateData.AvailableMinerals[index].GetItemId();
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		int itemLevel = GameManagers.Instance.UserArchiveManager.GetItemLevel(itemId);
		int curStock = _stateData.AvailableMinerals[index].CurStock;
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId);
		((GObject)item).data = _stateData.AvailableMinerals[index];
		((GObject)item.title).text = gDEItemData.Name;
		item.title.color = Color32.op_Implicit(UiHelper.GetColorByItemLevel(itemLevel));
		((GObject)item.num).text = curStock.ToString();
		((GObject)item.GvGStoreHouseStock).text = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId).ToString();
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, itemId);
		string modelId = _stateData.AvailableMinerals[index].GetModelId();
		MiningState miningStateForModelId = _stateData.GetMiningStateForModelId(modelId);
		item.state.SetSelectedIndex((int)miningStateForModelId);
		item.InitState = item.state.selectedIndex;
		if (StorehouseLimit > 0)
		{
			item.IsMax.selectedIndex = ((itemCount >= StorehouseLimit) ? 1 : 0);
		}
		((GObject)item).onClick.Set((EventCallback0)delegate
		{
			OnSelectDeselectMineralItem(item);
		});
	}

	private void UpdateOneClickSelected()
	{
		GList mineralList = MiningStatus.MiningDetailPages.MineralList;
		for (int i = 0; i < mineralList.numItems; i++)
		{
			if (((GComponent)mineralList).GetChildAt(i) is UI_MineralItem { IsSelected: false })
			{
				((GButton)MiningStatus.MiningDetailPages.OneClickCheckBox).selected = false;
				return;
			}
		}
		((GButton)MiningStatus.MiningDetailPages.OneClickCheckBox).selected = true;
	}

	private void MiningMineralItemRenderer(int index, UI_MiningMineralItem item)
	{
		string text = _stateData.SelectedMinerals[index];
		string collectingStockModelItemId = ShipConfigHelper.GetCollectingStockModelItemId(text);
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(collectingStockModelItemId);
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(gDEItemData.Key);
		((GObject)item.num).text = itemCount.ShortNumberFormat();
		FGUIManager.Instance.SetItemIconAndFrame(item.icon, collectingStockModelItemId);
		if (StorehouseLimit > 0)
		{
			item.IsMax.selectedIndex = ((itemCount >= StorehouseLimit) ? 1 : 0);
		}
		MiningState miningStateForModelId = _stateData.GetMiningStateForModelId(text);
		item.state.SetSelectedIndex((miningStateForModelId == MiningState.PriorMining) ? 1 : 0);
	}

	private void InitNavigatingAninmation()
	{
		if (!IsInitNavigatingAnim)
		{
			IsInitNavigatingAnim = true;
			NavigatingStatus.OarDeck.Init(_data.EntityId);
		}
	}

	private void InitMiningAnimation()
	{
		if (!IsInitMiningAnim)
		{
			IsInitMiningAnim = true;
			MiningStatus.MiningDetailPages.MiningCave.Init(_data.EntityId);
		}
	}

	private void InitNoMiningAnimation()
	{
		if (!IsInitNoMiningAnim)
		{
			IsInitNoMiningAnim = true;
			GameObject item = UiHelper.LoadSpine_AB(MiningStatus.MiningDetailPages.SpineLoader_NoMining, "sailorworker", 100f, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "sailorworker");
				animation.AnimationState.SetAnimation(0, "idle", true);
			});
			AnimList.Add(item);
		}
	}

	private void OnShipSummaryChange()
	{
		((GObject)NavigatingStatus.ShipSpeed).text = $"{_stateData.ShipSpeed()}";
	}

	private void OnCollectingConfigChange()
	{
		RenderMiningSpeed();
	}

	private void UpdateSpeed()
	{
		((GObject)NavigatingStatus.ShipSpeed).text = $"{_speedModel.GetFlightSpeed(MofifiedWorkers)}";
		RenderMiningSpeed();
	}

	private void RenderMiningSpeed()
	{
		((GObject)MiningStatus.MiningSpeed1).text = $"{MofifiedWorkers * 100}%";
		((GObject)MiningStatus.MiningDetailPages.MiningEfficiency).text = $"{(_stateData.CollectingEfficiencyModel.Total + 1f) * 100f:0.#}%";
	}

	public void OnShipStateChange()
	{
		IsInitRendered = false;
		RenderPage();
	}

	private void GoTo(int targetIslandId, string shipId)
	{
		ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId);
		C2S_IslandAction.Request req = new C2S_IslandAction.Request
		{
			ShipId = shipStateModel.ShipId,
			StartId = shipStateModel.StayIslandId,
			EndId = targetIslandId,
			ActionEnum = eIslandAction.GoTo,
			ActionData = string.Empty,
			NextActionEnum = eIslandAction.FakeAction,
			NextActionData = string.Empty
		};
		Singleton<WorldStateManager>.Instance.SendIslandAction(req);
	}

	public bool ConfigModified()
	{
		return ((GObject)ConfirnWorkersBtn).enabled || IsSelectedMineralChanged;
	}

	public void ConfirmOperationOnChangePage(Action changePage, Action revert)
	{
		if (((GObject)ConfirnWorkersBtn).enabled)
		{
			"GVG_MODE3_SHIP_WORKERS_CHANGED".ToLanguage().ToConfirmPopup(ConfirmAction, CancelAction, (AlignType)0);
		}
		else if (IsSelectedMineralChanged)
		{
			"GvG3CollectingChangeTip".ToLanguage().ToConfirmPopup(ConfirmAction2, CancelAction2, (AlignType)0);
		}
		void CancelAction()
		{
			MofifiedWorkers = _stateData.WorkersOnboardCount;
			UpdateWorkerInfo();
			((GObject)ConfirnWorkersBtn).enabled = ConfirmWorkersBtnEnabled();
			changePage?.Invoke();
		}
		void CancelAction2()
		{
			ChangedSelectedMinerals.Clear();
			UpdateMiningDetailPages(eMiningPageState.CurrentMining);
			changePage?.Invoke();
		}
		void ConfirmAction()
		{
			ConfirmWorkersChange(changePage);
		}
		void ConfirmAction2()
		{
			OnConfirmToMine(changePage, CancelAction2);
		}
	}

	public void ConfirmOperationOnClose(Action endAction)
	{
		if (((GObject)ConfirnWorkersBtn).enabled)
		{
			"GVG_MODE3_SHIP_WORKERS_CHANGED".ToLanguage().ToConfirmPopup(ConfirmAction, endAction, (AlignType)0);
		}
		else if (IsSelectedMineralChanged)
		{
			"GvG3CollectingChangeTip".ToLanguage().ToConfirmPopup(ConfirmAction2, CancelAction, (AlignType)0);
		}
		void CancelAction()
		{
			endAction?.Invoke();
		}
		void ConfirmAction()
		{
			ConfirmWorkersChange(endAction);
		}
		void ConfirmAction2()
		{
			OnConfirmToMine(endAction);
		}
	}

	private bool ConfirmWorkersBtnEnabled()
	{
		if (MofifiedWorkers < 1)
		{
			return false;
		}
		return MofifiedWorkers != _stateData.WorkersOnboardCount;
	}
}
