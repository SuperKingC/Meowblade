using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Spine.Unity;
using UI.GvGBrawlFight;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_SummaryPage : GComponent, IGvGShipDetailPage
{
	public Controller CanFillupFoodController;

	public GImage n70;

	public GImage n94;

	public GImage n101;

	public GGraph SpineLoader;

	public UI_btn_ArmySumBtn ArmySumBtn;

	public UI_btn_AmplifierSumBtn AmplifierSumBtn;

	public UI_btn_WorkerSumBtn WorkerSumBtn;

	public GImage n97;

	public GTextField n83;

	public GTextField ShipTotalPower;

	public GGroup PowerGroup;

	public GTextField n87;

	public GTextField TotalFood;

	public GGroup FoodGroup;

	public GButton FoodCountBuff;

	public GImage n96;

	public GImage n95;

	public UI_btn_ShipSkinBtn n98;

	public GButton Race;

	public UI_com_CampIcon CampIcon;

	public UI_btn_RefillFoodBtn RefillFoodBtn;

	public UI_FoodBar FoodBar;

	public GLoader n102;

	public GTextField n99;

	public UI_btn_SoulGuide SoulGuideBtn;

	public const string URL = "ui://u6x0b1gnzpu41n";

	public static string Name = "UI_SummaryPage";

	private GvGShipDetailModel Data;

	private UI_GvGShipDetailPanel ParentPanel;

	private ShipStateModel StateData;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private bool _isInitWorkerRendered;

	private int LastFoodOnBoardCount = -1;

	private Tweener FoodCountTweener;

	public bool CanFillupFood => StateData.State == eShipState.Stay;

	public int PageIndex { get; set; }

	public bool PageActivated { get; set; }

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41n";
	}

	public static UI_SummaryPage CreateInstance()
	{
		return (UI_SummaryPage)(object)UIPackage.CreateObject("GvGShipDetail", "SummaryPage");
	}

	public static UI_SummaryPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SummaryPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CanFillupFoodController = ((GComponent)this).GetController("CanFillupFoodController");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		ArmySumBtn = (UI_btn_ArmySumBtn)(object)((GComponent)this).GetChild("ArmySumBtn");
		AmplifierSumBtn = (UI_btn_AmplifierSumBtn)(object)((GComponent)this).GetChild("AmplifierSumBtn");
		WorkerSumBtn = (UI_btn_WorkerSumBtn)(object)((GComponent)this).GetChild("WorkerSumBtn");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n83 = (GTextField)((GComponent)this).GetChild("n83");
		string id = "ui://u6x0b1gnzpu41n".Replace("ui://", "") + "-" + ((GObject)n83).id;
		((GObject)n83).text = LanguagesManager.GetDesc(id);
		ShipTotalPower = (GTextField)((GComponent)this).GetChild("ShipTotalPower");
		PowerGroup = (GGroup)((GComponent)this).GetChild("PowerGroup");
		n87 = (GTextField)((GComponent)this).GetChild("n87");
		string id2 = "ui://u6x0b1gnzpu41n".Replace("ui://", "") + "-" + ((GObject)n87).id;
		((GObject)n87).text = LanguagesManager.GetDesc(id2);
		TotalFood = (GTextField)((GComponent)this).GetChild("TotalFood");
		FoodGroup = (GGroup)((GComponent)this).GetChild("FoodGroup");
		FoodCountBuff = (GButton)((GComponent)this).GetChild("FoodCountBuff");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		n98 = (UI_btn_ShipSkinBtn)(object)((GComponent)this).GetChild("n98");
		Race = (GButton)((GComponent)this).GetChild("Race");
		CampIcon = (UI_com_CampIcon)(object)((GComponent)this).GetChild("CampIcon");
		RefillFoodBtn = (UI_btn_RefillFoodBtn)(object)((GComponent)this).GetChild("RefillFoodBtn");
		FoodBar = (UI_FoodBar)(object)((GComponent)this).GetChild("FoodBar");
		n102 = (GLoader)((GComponent)this).GetChild("n102");
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id3 = "ui://u6x0b1gnzpu41n".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id3);
		SoulGuideBtn = (UI_btn_SoulGuide)(object)((GComponent)this).GetChild("SoulGuideBtn");
	}

	public void Init(GvGShipDetailModel data, UI_GvGShipDetailPanel parentPanel)
	{
		Data = data;
		ParentPanel = parentPanel;
		StateData = ParentPanel.StateData;
		InitShipAninmation();
		RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)Race, (eRace)Data.ShipType);
		CampIcon.CampId.selectedIndex = Data.CampId;
		((GProgressBar)FoodBar).max = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
		((GObject)FoodCountBuff).visible = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.HasBuff;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		((GObject)ArmySumBtn).onClick.Set((EventCallback0)delegate
		{
			((GComponent)ParentPanel.Tabs).GetChildAt(1).onClick.Call();
		});
		((GObject)AmplifierSumBtn).onClick.Set((EventCallback0)delegate
		{
			((GComponent)ParentPanel.Tabs).GetChildAt(2).onClick.Call();
		});
		((GObject)WorkerSumBtn).onClick.Set((EventCallback0)delegate
		{
			((GComponent)ParentPanel.Tabs).GetChildAt(3).onClick.Call();
		});
		((GObject)RefillFoodBtn).onClick.Set(new EventCallback0(OnClickRefillFood));
		((GObject)SoulGuideBtn).onClick.Set(new EventCallback1(OnOpenSoulGuidePanel));
		SharedMessenger.AddListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
		SharedMessenger.AddListener("ON_GVG3_ShipWorkersModified", UpdateWorkerNumber);
		((GObject)FoodCountBuff).onClick.Set(new EventCallback0(OnClickFoodCountBuff));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ArmySumBtn).onClick.Clear();
		((GObject)AmplifierSumBtn).onClick.Clear();
		((GObject)WorkerSumBtn).onClick.Clear();
		((GObject)RefillFoodBtn).onClick.Clear();
		((GObject)SoulGuideBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
		SharedMessenger.RemoveListener("ON_GVG3_ShipWorkersModified", UpdateWorkerNumber);
		((GObject)FoodCountBuff).onClick.Clear();
	}

	public void OnActivate()
	{
		if (!((GObject)this).isDisposed)
		{
			PageActivated = true;
			UpdateShipData();
			GetShipTotalPower();
			UpdateArmy();
			UpdateAmplifiers();
			UpdateWorker();
			ShipStateModel stateData = StateData;
			stateData.OnChange = (Action<ShipStateModel>)Delegate.Combine(stateData.OnChange, new Action<ShipStateModel>(OnChangeShipState));
			ShipStateModel stateData2 = StateData;
			stateData2.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Combine(stateData2.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(OnChangeShipState));
		}
	}

	public void OnInactivate()
	{
		PageActivated = false;
		ShipStateModel stateData = StateData;
		stateData.OnChange = (Action<ShipStateModel>)Delegate.Remove(stateData.OnChange, new Action<ShipStateModel>(OnChangeShipState));
		ShipStateModel stateData2 = StateData;
		stateData2.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Remove(stateData2.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(OnChangeShipState));
	}

	public void OnDestroy()
	{
		ShipAnimCacheManager.ClearCache();
		TweenExtensions.Kill((Tween)(object)FoodCountTweener, false);
	}

	private void OnClickFoodCountBuff()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)FoodCountBuff, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.GetText();
		});
	}

	private void OnClickRefillFood()
	{
		ShipStateModel shipState = Data.ShipState;
		FlagShipStateModel ourFlagShip = Singleton<WorldStateManager>.Instance.GetOurFlagShip();
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(shipState.StayIslandId);
		if (shipState.State == eShipState.Stay && (islandConfigData.Props.Type == eIslandType.Moon || islandConfigData.Props.Type == eIslandType.MainMoon || ourFlagShip.StayIslandId == shipState.StayIslandId || OuterTechHelper.Is绿色通道Active))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FoodFillupPanel.Name, new Dictionary<string, object> { { "ShipEntityId", Data.EntityId } });
		}
		else
		{
			"CannotRefillFoodTips".ToShowLanguageTip();
		}
	}

	private void OnChangeShipState(ShipStateModel newState)
	{
		if (!((GObject)this).isDisposed)
		{
			UpdateShipData();
			UpdateArmy();
			_isInitWorkerRendered = false;
			UpdateWorker();
		}
	}

	private void OnOpenSoulGuidePanel(EventContext context)
	{
		if (((GObject)SoulGuideBtn).grayed)
		{
			"CannotDoShipSoulGuideTips".ToShowLanguageTip();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_SoulGuidePanel.Name, new Dictionary<string, object> { 
		{
			"OnConfirm",
			new UICallbackParam<Action>(OnConfirmDoSoulGuide)
		} });
	}

	private void OnConfirmDoSoulGuide()
	{
		((GObject)SoulGuideBtn).enabled = false;
		Singleton<WorldStateManager>.Instance.DoSoulGuide(Data.EntityId, delegate(bool succeed)
		{
			if (succeed)
			{
				ParentPanel.End();
				"DoSoulGuideSucceededTip".ToShowLanguageTip();
			}
			else
			{
				((GObject)SoulGuideBtn).enabled = true;
			}
		});
	}

	private void OnShipLaunched(string shipId)
	{
		if (!((GObject)this).isDisposed && !(shipId != Data.ShipId))
		{
			_isInitWorkerRendered = false;
			UpdateWorker();
		}
	}

	private void GetShipTotalPower()
	{
		bool flag = Data.StayIslandId == Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(Data.StayIslandId).Props.Type;
		bool flag2 = type == eIslandType.Moon || type == eIslandType.MainMoon;
		if (Data.ShipState.State == eShipState.Stay && (flag || flag2))
		{
			((GObject)ShipTotalPower).text = "GvGShipDetailDefaultTotalPower".ToLanguage();
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetShipAllCombatPower
		{
			Req = new C2S_GetShipAllCombatPower.Request
			{
				ShipEntityId = StateData.EntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetShipAllCombatPower.Response response = (C2S_GetShipAllCombatPower.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				((GObject)ShipTotalPower).text = $"{response.CombatPower}";
			}
		});
	}

	private void UpdateShipData()
	{
		if (CanFillupFood)
		{
			if (OuterTechHelper.Is绿色通道Active)
			{
				CanFillupFoodController.selectedIndex = 2;
			}
			else
			{
				CanFillupFoodController.selectedIndex = 1;
			}
		}
		else
		{
			CanFillupFoodController.selectedIndex = 0;
		}
		((GObject)SoulGuideBtn).grayed = !StateData.CanDoSoulGuide;
		if (LastFoodOnBoardCount != StateData.FoodOnboardCount)
		{
			if (LastFoodOnBoardCount == -1)
			{
				InterpolateFoodCount(StateData.FoodOnboardCount, StateData.FoodOnboardCount, 0f);
			}
			else
			{
				InterpolateFoodCount(LastFoodOnBoardCount, StateData.FoodOnboardCount, 1.5f);
			}
			LastFoodOnBoardCount = StateData.FoodOnboardCount;
		}
	}

	private void InterpolateFoodCount(float curValue, float endValue, float duration)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (FoodCountTweener != null)
		{
			TweenExtensions.Kill((Tween)(object)FoodCountTweener, false);
		}
		FoodCountTweener = (Tweener)(object)DOTween.To((DOGetter<float>)(() => curValue), (DOSetter<float>)delegate(float x)
		{
			curValue = x;
		}, endValue, duration);
		Action<int> func = delegate(int val)
		{
			int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
			((GObject)TotalFood).text = $"{val}/{num}";
			((GProgressBar)FoodBar).value = ((val > num) ? num : val);
		};
		TweenSettingsExtensions.OnUpdate<Tweener>(FoodCountTweener, (TweenCallback)delegate
		{
			func((int)curValue);
		});
		TweenSettingsExtensions.OnComplete<Tweener>(FoodCountTweener, (TweenCallback)delegate
		{
			func((int)endValue);
			FoodCountTweener = null;
		});
	}

	private void UpdateArmy()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		GList curSelectedSoldiers = ArmySumBtn.CurSelectedSoldiers;
		curSelectedSoldiers.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			SelectedSoldiersItemRenderer(i, (UI_SimpleSoldierSlot)(object)o);
		};
		curSelectedSoldiers.numItems = 5;
		int num = 0;
		bool flag = false;
		foreach (GvGMode3UnitInfo currentUnitInfo in StateData.CurrentUnitInfos)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(currentUnitInfo.SoldierId))
			{
				num++;
				if (UnitInfoHelper.CheckIsLowSoldierNumAlert(currentUnitInfo))
				{
					flag = true;
				}
			}
		}
		((GObject)ArmySumBtn.SelectedSoldiersTotalPower).text = $"{StateData.FormationPower}";
		((GObject)ArmySumBtn.SodierGroupsCount).text = $"{num}/{StateData.CurrentUnitInfos.Count}";
		ArmySumBtn.SoldierStatus.selectedIndex = (flag ? 1 : 0);
	}

	private void SelectedSoldiersItemRenderer(int index, UI_SimpleSoldierSlot item)
	{
		GvGMode3UnitInfo gvGMode3UnitInfo = StateData.CurrentUnitInfos[index];
		string soldierId = gvGMode3UnitInfo.SoldierId;
		if (UnitInfoHelper.CheckIsValidSoldier(soldierId))
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			string iconPath = UiHelper.GetIconPath(soldierId);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(gvGMode3UnitInfo.PotentialLevel);
			UI_SimpleSoldierIcon icon = item.Icon;
			((GObject)icon.SoulStoneLevel).alpha = 1f;
			icon.icon.url = "ui://PublicResources/" + iconPath;
			icon.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GObject)icon.iconFrame).asLoader, gvGMode3UnitInfo.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(icon.SoulStoneLevel, gvGMode3UnitInfo.PotentialLevel, soldier.PotentialProgress);
			item.IsEmpty.selectedIndex = 0;
		}
		else
		{
			item.IsEmpty.selectedIndex = 1;
		}
	}

	private void UpdateAmplifiers()
	{
		Dictionary<eAmplifierType, UI_AmpSummarySlot> dictionary = new Dictionary<eAmplifierType, UI_AmpSummarySlot>
		{
			{
				eAmplifierType.Attack,
				AmplifierSumBtn.AmpType1
			},
			{
				eAmplifierType.Health,
				AmplifierSumBtn.AmpType2
			},
			{
				eAmplifierType.Perks,
				AmplifierSumBtn.AmpType3
			}
		};
		Dictionary<eAmplifierType, int> dictionary2 = new Dictionary<eAmplifierType, int>
		{
			{
				eAmplifierType.Attack,
				0
			},
			{
				eAmplifierType.Health,
				0
			},
			{
				eAmplifierType.Perks,
				0
			}
		};
		Dictionary<int, int> amplifiers = Data.Amplifiers;
		foreach (KeyValuePair<int, int> item in amplifiers)
		{
			int key = item.Key;
			int value = item.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
			dictionary2[amplifierModel.Type] += value;
		}
		int num = 0;
		foreach (eAmplifierType key2 in dictionary.Keys)
		{
			((GObject)dictionary[key2].Total).text = $"{dictionary2[key2]}";
			num += dictionary2[key2];
		}
		((GObject)AmplifierSumBtn.AmplifiersCount).text = $"{num}/{Data.AmplifierCountLimit}";
		((GObject)AmplifierSumBtn.ampScore).text = UI_com_ShipList.GetShipAmpScore(Data.ShipId).ToString();
	}

	private void UpdateWorkerNumber()
	{
		_isInitWorkerRendered = false;
	}

	private void UpdateWorker()
	{
		if (PageActivated)
		{
			if (StateData.UiState == eUIShipState.NotLaunched)
			{
				RenderWorkerSum(null);
			}
			else
			{
				SyncShipCollectingDetailInfo();
			}
		}
		void RenderWorkerSum(RealTimeShipSummarySpeedModel speedModel)
		{
			if (!((GObject)this).isDisposed)
			{
				((GObject)WorkerSumBtn.WorkersCount).text = $"{StateData.WorkersOnboardCount}/{StateData.WorkersOnboardCountLimit}";
				if (StateData.UiState == eUIShipState.Stay || StateData.UiState == eUIShipState.InBattle)
				{
					WorkerSumBtn.WokerStatus.selectedIndex = 0;
				}
				else if (StateData.UiState == eUIShipState.Navigating)
				{
					WorkerSumBtn.WokerStatus.selectedIndex = 1;
				}
				else if (StateData.UiState == eUIShipState.Mining)
				{
					WorkerSumBtn.WokerStatus.selectedIndex = ((StateData.SelectedMinerals.Count == 0) ? 2 : 3);
				}
			}
		}
		void SyncShipCollectingDetailInfo()
		{
			if (!_isInitWorkerRendered)
			{
				_isInitWorkerRendered = true;
				Singleton<GvGShipUiInfoManager>.Instance.SyncShipCollectingDetailInfo(StateData.EntityId, RenderWorkerSum);
			}
		}
	}

	private void InitShipAninmation()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		ShipAnimCacheManager = new ShipAnimCacheManager();
		GameObject cache = ShipAnimCacheManager.GetCache(Data.ShipId, Data.ShipSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "dengdai", true);
		});
		cache.transform.localScale = new Vector3(100f, 100f, 100f);
		GoWrapper val = new GoWrapper(cache);
		val.supportStencil = true;
		SpineLoader.SetNativeObject((DisplayObject)(object)val);
	}

	public void OnShipStateChange()
	{
		if (!((GObject)this).isDisposed)
		{
			UpdateArmy();
		}
	}

	public bool ConfigModified()
	{
		return false;
	}

	public void ConfirmOperationOnChangePage(Action changePage, Action revert)
	{
	}

	public void ConfirmOperationOnClose(Action endAction)
	{
	}
}
