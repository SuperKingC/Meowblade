using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GameActivity;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback1 _003C_003E9__63_0;

		public static Comparison<HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig> _003C_003E9__67_0;

		public static Action<GameObject> _003C_003E9__92_0;

		internal void _003CInit_003Eb__63_0(EventContext x)
		{
			x.StopPropagation();
			ClosePanel();
		}

		internal int _003CRefreshMissionContent_003Eb__67_0(HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig a, HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig b)
		{
			Mission mission = MissionManager.Missions[a.MissionId];
			Mission mission2 = MissionManager.Missions[b.MissionId];
			Shift.Legion.Common.Models.MissionConfig missionConfig = mission.MissionState(GameManagers.Instance);
			Shift.Legion.Common.Models.MissionConfig missionConfig2 = mission2.MissionState(GameManagers.Instance);
			return missionConfig.Status.GetSortOrder() - missionConfig2.Status.GetSortOrder();
		}

		internal void _003COnStockChange_003Eb__92_0(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}
	}

	public Controller isPurchased;

	public Controller showUpArrow;

	public Controller arrowPos;

	public GLoader background;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GComponent addWorkerBtn;

	public GButton backBtn;

	public GComponent Title;

	public GImage bgLeft;

	public GList missionTabList;

	public GImage n107;

	public GImage n110;

	public GImage n111;

	public GImage n135;

	public GImage n136;

	public GImage n113;

	public GImage n127;

	public GImage n128;

	public GImage n129;

	public GImage n130;

	public UI_ProgressionMissionRewardContent rewardContent;

	public GList MissionList;

	public GImage n112;

	public GImage n116;

	public GTextField scoreTotal;

	public GImage n114;

	public UI_receiveBtn claimReward;

	public UI_NewRewards n115;

	public GTextField n85;

	public GLoader n138;

	public GImage n108;

	public GRichTextField remainTime;

	public GGroup n109;

	public GLoader icon;

	public UI_UnlockButton n122;

	public UI_ProgressionMissionPurchase purchasePopup;

	public GMovieClip n139;

	public GImage n140;

	public GImage n141;

	public GGroup scoreAddEffect;

	public GLoader flyAnim;

	public Transition t0;

	public const string URL = "ui://mapat4i5drlj86";

	public static string Name = "UI_ProgressionMissionPanel";

	private UI_ProductionNumFloating floatingNum;

	private int _currentDay;

	private int _currentTab;

	private GetMissionOf7Foreign.Response _response;

	private float _maxProgressBarLen;

	private float _advanceRewardItemHeight;

	private int _firstUnclaimedAdvanceIndex;

	private int _lastUnclaimedAdvanceIndex;

	public static MissionSerialForeignActivityPayload MissionData => ActivityManager.ProgressionMission.ProgressMissionData;

	private static StoreItem SevenDaysPackAll => StoreItem.Get(GameManagers.Instance, "NewSevenDaysPackAll");

	public UI_PanelTitle PanelTitle => (UI_PanelTitle)(object)Title;

	public static string GetURL()
	{
		return "ui://mapat4i5drlj86";
	}

	public static UI_ProgressionMissionPanel CreateInstance()
	{
		return (UI_ProgressionMissionPanel)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionPanel");
	}

	public static UI_ProgressionMissionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5drlj86", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isPurchased = ((GComponent)this).GetController("isPurchased");
		showUpArrow = ((GComponent)this).GetController("showUpArrow");
		arrowPos = ((GComponent)this).GetController("arrowPos");
		background = (GLoader)((GComponent)this).GetChild("background");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (GComponent)((GComponent)this).GetChild("Title");
		bgLeft = (GImage)((GComponent)this).GetChild("bgLeft");
		missionTabList = (GList)((GComponent)this).GetChild("missionTabList");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		rewardContent = (UI_ProgressionMissionRewardContent)(object)((GComponent)this).GetChild("rewardContent");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		scoreTotal = (GTextField)((GComponent)this).GetChild("scoreTotal");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		claimReward = (UI_receiveBtn)(object)((GComponent)this).GetChild("claimReward");
		n115 = (UI_NewRewards)(object)((GComponent)this).GetChild("n115");
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id = "ui://mapat4i5drlj86".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id);
		n138 = (GLoader)((GComponent)this).GetChild("n138");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		remainTime = (GRichTextField)((GComponent)this).GetChild("remainTime");
		string id2 = "ui://mapat4i5drlj86".Replace("ui://", "") + "-" + ((GObject)remainTime).id;
		((GObject)remainTime).text = LanguagesManager.GetDesc(id2);
		n109 = (GGroup)((GComponent)this).GetChild("n109");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n122 = (UI_UnlockButton)(object)((GComponent)this).GetChild("n122");
		purchasePopup = (UI_ProgressionMissionPurchase)(object)((GComponent)this).GetChild("purchasePopup");
		n139 = (GMovieClip)((GComponent)this).GetChild("n139");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		scoreAddEffect = (GGroup)((GComponent)this).GetChild("scoreAddEffect");
		flyAnim = (GLoader)((GComponent)this).GetChild("flyAnim");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)PanelTitle.buildingName).text = LanguagesManager.GetDesc("CsharpPanelNameProgressionMission");
		EventListener onClick = ((GObject)backBtn).onClick;
		object obj = _003C_003Ec._003C_003E9__63_0;
		if (obj == null)
		{
			EventCallback1 val = delegate(EventContext x)
			{
				x.StopPropagation();
				ClosePanel();
			};
			_003C_003Ec._003C_003E9__63_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback1)obj);
		n122.isLong.SetSelectedIndex((HotUpdateProcess.LanguageKey == "eng") ? 1 : 0);
		_maxProgressBarLen = -1f;
		InitCurrencyHeader(addCouponBtn, addDiamondBtn, addWorkerBtn, ref floatingNum);
		InitRewardView(isInit: true);
	}

	private void InitRewardView(bool isInit)
	{
		if (isInit)
		{
			RefreshUnlockAllBtn();
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		}
		Task<GetMissionOf7Foreign.Response> task = GameController.Contexts.Service<INetworkService>().GetMissionOf7ForeignRequest();
		ListItemRenderer val = default(ListItemRenderer);
		EventCallback0 val4 = default(EventCallback0);
		task.GetAwaiter().OnCompleted(delegate
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00cb: Expected O, but got Unknown
			if (isInit)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
			GetMissionOf7Foreign.Response result = task.Result;
			Dictionary<int, MissionSerialConfig> missionConfig = MissionData.MissionConfig;
			int count = missionConfig.Count;
			_response = result;
			int num = (int)GameController.Instance.GetServerRealtimeSeconds();
			_currentDay = result.GetCurrentDay();
			string arg = UiHelper.ParseTimeSpanUniversal(result.EndTime - num);
			string desc = LanguagesManager.GetDesc("CsharpProgrssionMissionTip1", "Ends In {0}");
			((GObject)remainTime).text = string.Format(desc, arg);
			GList obj = missionTabList;
			ListItemRenderer obj2 = val;
			if (obj2 == null)
			{
				ListItemRenderer val2 = delegate(int index, GObject item)
				{
					//IL_0085: Unknown result type (might be due to invalid IL or missing references)
					//IL_008f: Expected O, but got Unknown
					//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c1: Expected O, but got Unknown
					//IL_00c6: Expected O, but got Unknown
					int num3 = index + 1;
					UI_ProgressionTabBtn uI_ProgressionTabBtn = (UI_ProgressionTabBtn)(object)item;
					string desc2 = LanguagesManager.GetDesc("CsharpNewArrivalRewardName");
					((GObject)uI_ProgressionTabBtn.day).text = string.Format(desc2, num3);
					((GObject)uI_ProgressionTabBtn.dayMini).text = num3.ToString();
					if (num3 <= _currentDay)
					{
						((GObject)uI_ProgressionTabBtn).onClick.Set((EventCallback0)delegate
						{
							OnClickSelectPage(index);
						});
					}
					else
					{
						uI_ProgressionTabBtn.SelectState.selectedIndex = 0;
						EventListener onClick = ((GObject)uI_ProgressionTabBtn).onClick;
						EventCallback0 obj3 = val4;
						if (obj3 == null)
						{
							EventCallback0 val5 = delegate
							{
								List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpNeedUnlockAfterDay") };
								SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder, arg3: false);
							};
							EventCallback0 val6 = val5;
							val4 = val5;
							obj3 = val6;
						}
						onClick.Set(obj3);
					}
				};
				ListItemRenderer val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.itemRenderer = obj2;
			missionTabList.numItems = count;
			((GObject)n115).onClick.Set(new EventCallback0(OnClickJumpToAdvanceReward));
			((GComponent)rewardContent).scrollPane.onScroll.Set(new EventCallback0(OnScrollRewardList));
			RefreshTabNote();
			bool hasUnclaimedReward;
			int num2 = FindFistShowTab(_currentDay, out hasUnclaimedReward);
			OnClickSelectPage(num2);
			missionTabList.ScrollToView(num2, true);
			RefreshRewardView();
			RefreshUnlockAllBtn();
			ScrollToFocus();
		});
	}

	private void OnClickSelectPage(int index)
	{
		_currentTab = index;
		int currentDay = _currentDay;
		for (int i = 0; i < currentDay; i++)
		{
			UI_ProgressionTabBtn uI_ProgressionTabBtn = (UI_ProgressionTabBtn)(object)((GComponent)missionTabList).GetChildAt(i);
			uI_ProgressionTabBtn.SelectState.selectedIndex = ((i != index) ? 1 : 2);
		}
		RefreshMissionContent();
	}

	private void OnClickPurchaseStoreItem(EventContext eventContext, StoreItem storeItem, int score)
	{
		eventContext.StopPropagation();
		string storeItemId = storeItem.StoreItemId;
		ProductLocalInfo value = null;
		if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
		}
		PurchaseManager.Instance.InvokePurchase(StoreItem.Get(GameManagers.Instance, storeItemId), value, 1, (Action)null, doubleCheck: true);
	}

	private void RefreshMissionContent()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		if (_response == null)
		{
			return;
		}
		int key = _currentTab + 1;
		MissionSerialConfig serialData = MissionData.MissionConfig[key];
		int count = serialData.MissionSerial.Count;
		serialData.MissionSerial.Sort(delegate(HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig a, HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig b)
		{
			Mission mission = MissionManager.Missions[a.MissionId];
			Mission mission2 = MissionManager.Missions[b.MissionId];
			Shift.Legion.Common.Models.MissionConfig missionConfig = mission.MissionState(GameManagers.Instance);
			Shift.Legion.Common.Models.MissionConfig missionConfig2 = mission2.MissionState(GameManagers.Instance);
			return missionConfig.Status.GetSortOrder() - missionConfig2.Status.GetSortOrder();
		});
		MissionList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Expected O, but got Unknown
			UI_ProgressionMissionBtn btn = (UI_ProgressionMissionBtn)(object)item;
			string missionId = serialData.MissionSerial[index].MissionId;
			Mission mission = MissionManager.Missions[missionId];
			KeyValuePair<string, string> bonus = mission.DisplayBonus.First();
			((GObject)btn.title).text = mission.Data.Desc;
			((GObject)btn.rewardNum).text = bonus.Value;
			string key2 = bonus.Key;
			Controller receiveStatus = btn.ReceiveStatus;
			bool canClaim = mission.CanClaimBonus(GameManagers.Instance);
			MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
			if (status == MissionStatus.Undergoing)
			{
				receiveStatus.selectedIndex = 0;
			}
			if (status == MissionStatus.Completed)
			{
				receiveStatus.selectedIndex = 1;
			}
			if (status == MissionStatus.Claimed)
			{
				receiveStatus.selectedIndex = 2;
			}
			bool claimed = status == MissionStatus.Claimed;
			if (_maxProgressBarLen < 0f)
			{
				_maxProgressBarLen = ((GObject)btn.progressBar).width;
			}
			float num = mission.CurrentValue(GameManagers.Instance) / mission.TargetValue(GameManagers.Instance);
			num = Mathf.Clamp(num, 0f, 1f);
			((GObject)btn.progressBar).width = _maxProgressBarLen * num;
			btn.rewardIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(key2);
			((GObject)btn.clickBtn).onClick.Set((EventCallback1)delegate(EventContext context)
			{
				if (!claimed)
				{
					if (!canClaim)
					{
						UI_ActivityPanel.GoToRelativeUi(mission, (GObject)(object)this);
					}
					else
					{
						ClaimMissionReward(btn, missionId);
						context.StopPropagation();
					}
				}
			});
			((GObject)btn.rewardIcon).onClick.Set((EventCallback1)delegate(EventContext context)
			{
				if (!claimed)
				{
					if (!canClaim)
					{
						FGUIManager.Instance.ItemTip(bonus.Key, 2);
					}
					else
					{
						ClaimMissionReward(btn, missionId);
						context.StopPropagation();
					}
				}
			});
		};
		MissionList.numItems = count;
	}

	private void RefreshRewardView()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		((GObject)scoreTotal).text = _response.Score.ToString();
		RefreshFirstAdvanceUnclaimedBonus();
		GList rewardList = rewardContent.rewardList;
		GList advanceRewardList = rewardContent.AdvanceRewardList;
		bool isFirstUnclaim = false;
		rewardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig bonusConfig = MissionData.ScoreProgressBonusConfig[index];
			GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[bonusConfig.RequiredScore.ToString()];
			bool isAdvance = bonusConfig.IsAdvance;
			UI_ProgressionMissionRewardItem uI_ProgressionMissionRewardItem = (UI_ProgressionMissionRewardItem)(object)item;
			uI_ProgressionMissionRewardItem.isAdvance.selectedIndex = (isAdvance ? 1 : 0);
			((GObject)uI_ProgressionMissionRewardItem.score).text = bonusConfig.RequiredScore.ToString();
			KeyValuePair<string, int> keyValuePair = bonusConfig.Bonus.First();
			uI_ProgressionMissionRewardItem.rewardIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(keyValuePair.Key);
			uI_ProgressionMissionRewardItem.rewardIcon.InitMaterialIntroductionBtn(keyValuePair.Key);
			((GObject)uI_ProgressionMissionRewardItem.Num).text = keyValuePair.Value.ShortNumberFormat();
			bool flag = _response.Score >= bonusConfig.RequiredScore;
			bool claimed = missonOf7ForeignBonusClaimed.Bonus.Claimed;
			uI_ProgressionMissionRewardItem.Status.selectedIndex = (flag ? ((!claimed) ? 1 : 2) : 0);
			bool flag2 = false;
			if (!isFirstUnclaim && flag && !claimed)
			{
				isFirstUnclaim = true;
				flag2 = true;
			}
			uI_ProgressionMissionRewardItem.isSelect.selectedIndex = (flag2 ? 1 : 0);
		};
		int num = (rewardList.numItems = MissionData.ScoreProgressBonusConfig.Count);
		rewardContent.rewardProgressList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig bonusConfig = MissionData.ScoreProgressBonusConfig[index];
			bool flag = _response.Score >= bonusConfig.RequiredScore;
			UI_ProgressionMissionRewardBar uI_ProgressionMissionRewardBar = (UI_ProgressionMissionRewardBar)(object)item;
			uI_ProgressionMissionRewardBar.Status.selectedIndex = (flag ? 1 : 0);
		};
		rewardContent.rewardProgressList.numItems = num;
		int nextScoreReward = GetNextScoreReward();
		bool canClaimReward = nextScoreReward > 0;
		((GObject)claimReward).grayed = !canClaimReward;
		((GObject)claimReward).onClick.Set((EventCallback0)delegate
		{
			if (canClaimReward)
			{
				ClaimScoreReward(nextScoreReward, isAdvance: false);
			}
		});
		advanceRewardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Expected O, but got Unknown
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Expected O, but got Unknown
			int index2 = index * 6 + 5;
			HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig reward = MissionData.ScoreProgressBonusConfig[index2];
			KeyValuePair<string, int> keyValuePair = reward.PayBonus.First();
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, keyValuePair.Key);
			bool missionOf7UnLockBonus = GameManagers.Instance.UserArchiveManager.GetMissionOf7UnLockBonus();
			KeyValuePair<string, int> keyValuePair2 = storeItem.Content.First();
			int value = keyValuePair2.Value;
			UI_ProgressionMissionAdvanceItem uI_ProgressionMissionAdvanceItem = (UI_ProgressionMissionAdvanceItem)(object)item;
			_advanceRewardItemHeight = ((GObject)uI_ProgressionMissionAdvanceItem).height;
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(keyValuePair2.Key);
			((GObject)uI_ProgressionMissionAdvanceItem.rewardName).text = gDEItemData.Name;
			uI_ProgressionMissionAdvanceItem.rewardIconAdvance.url = storeItem.GetIconUrl();
			((GObject)uI_ProgressionMissionAdvanceItem.NumAdvance).text = value.ShortNumberFormat();
			((GObject)uI_ProgressionMissionAdvanceItem.price).text = storeItem.GetCurrentPriceDisplay();
			((GObject)uI_ProgressionMissionAdvanceItem.MtgPrice).text = storeItem.GetMtgPrice().ToString(CultureInfo.InvariantCulture);
			uI_ProgressionMissionAdvanceItem.isMtg.selectedIndex = (storeItem.CanRedeemByMtg() ? 1 : 0);
			UiHelper.SetStoreItemDiscount(storeItem, uI_ProgressionMissionAdvanceItem.discount, ribbonVisible: false, 4);
			bool scoreEnough = _response.Score >= reward.RequiredScore;
			GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[reward.RequiredScore.ToString()];
			if (missonOf7ForeignBonusClaimed.PayBonus.Claimed)
			{
				uI_ProgressionMissionAdvanceItem.Status.selectedIndex = 3;
			}
			else
			{
				uI_ProgressionMissionAdvanceItem.Status.selectedIndex = ((!missionOf7UnLockBonus) ? 1 : 2);
				((GObject)uI_ProgressionMissionAdvanceItem.purchaseBtn).enabled = scoreEnough;
				((GObject)uI_ProgressionMissionAdvanceItem.claimBtn).enabled = scoreEnough;
			}
			uI_ProgressionMissionAdvanceItem.rewardIconAdvance.InitMaterialIntroductionBtn(keyValuePair2.Key);
			((GObject)uI_ProgressionMissionAdvanceItem.purchaseBtn).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				if (scoreEnough)
				{
					OnClickPurchaseStoreItem(x, storeItem, reward.RequiredScore);
				}
			});
			((GObject)uI_ProgressionMissionAdvanceItem.claimBtn).onClick.Set((EventCallback1)delegate
			{
				if (scoreEnough)
				{
					ClaimScoreReward(reward.RequiredScore, isAdvance: true);
				}
			});
		};
		int numItems = MissionData.ScoreProgressBonusConfig.Count / 6;
		advanceRewardList.numItems = numItems;
		float num2 = ((GComponent)rewardList).GetChildAt(0).height + (float)rewardList.lineGap;
		float height = (((GObject)advanceRewardList).height = (((GObject)rewardList).height = num2 * (float)num + 140f));
		((GObject)rewardContent.rewardProgressList).height = height;
	}

	private void ScrollToFocus()
	{
		int num = Mathf.Max(_response.Score / 10 - 1, 0);
		float num2 = (float)num / (float)MissionData.ScoreProgressBonusConfig.Count;
		((GComponent)rewardContent).scrollPane.SetPercY(num2, true);
	}

	private void OnScrollRewardList()
	{
		if (_response == null)
		{
			showUpArrow.selectedIndex = 0;
			return;
		}
		float num = FindFirstUnclaimedBonusPos();
		float posY = ((GComponent)rewardContent).scrollPane.posY;
		int num2 = 0;
		if (num >= 0f)
		{
			num2 = ((num + _advanceRewardItemHeight < posY) ? 1 : 0);
		}
		if (num2 == 0)
		{
			float num3 = FindLastUnclaimedBonusPos();
			if (num3 >= 0f)
			{
				num2 = ((num3 > posY) ? 2 : 0);
			}
		}
		showUpArrow.selectedIndex = ((num2 != 0) ? 1 : 0);
		arrowPos.selectedIndex = ((num2 != 1) ? 1 : 0);
	}

	private void OnClickJumpToAdvanceReward()
	{
		bool flag = arrowPos.selectedIndex == 0;
		float num = FindFirstUnclaimedBonusPos();
		if (!flag)
		{
			num = FindLastUnclaimedBonusPos();
		}
		((GComponent)rewardContent).scrollPane.SetPosY(num, true);
	}

	private void RefreshFirstAdvanceUnclaimedBonus()
	{
		_firstUnclaimedAdvanceIndex = -1;
		_lastUnclaimedAdvanceIndex = -1;
		int num = 0;
		foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig item in MissionData.ScoreProgressBonusConfig)
		{
			if (_response.Score < item.RequiredScore)
			{
				break;
			}
			if (!item.IsAdvance)
			{
				continue;
			}
			GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[item.RequiredScore.ToString()];
			if (!missonOf7ForeignBonusClaimed.PayBonus.Claimed)
			{
				if (_firstUnclaimedAdvanceIndex < 0)
				{
					_firstUnclaimedAdvanceIndex = num;
				}
				_lastUnclaimedAdvanceIndex = num;
			}
			num++;
		}
	}

	private float FindFirstUnclaimedBonusPos()
	{
		if (_firstUnclaimedAdvanceIndex >= 0)
		{
			return (float)_firstUnclaimedAdvanceIndex * _advanceRewardItemHeight;
		}
		return -1f;
	}

	private float FindLastUnclaimedBonusPos()
	{
		if (_lastUnclaimedAdvanceIndex >= 0)
		{
			return (float)_lastUnclaimedAdvanceIndex * _advanceRewardItemHeight;
		}
		return -1f;
	}

	private void RefreshUnlockAllBtn()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		bool missionOf7UnLockBonus = GameManagers.Instance.UserArchiveManager.GetMissionOf7UnLockBonus();
		isPurchased.selectedIndex = (missionOf7UnLockBonus ? 1 : 0);
		((GObject)n122.Price).text = SevenDaysPackAll.GetOriginPriceDisplay();
		((GObject)n122.Price1).text = SevenDaysPackAll.GetCurrentPriceDisplay();
		if (!missionOf7UnLockBonus)
		{
			((GObject)n122).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				x.StopPropagation();
				((GObject)purchasePopup).visible = true;
				RefreshPurchasePopup();
			});
		}
	}

	private void ClosePurchasePop(EventContext eventContext)
	{
		eventContext.StopPropagation();
		((GObject)purchasePopup).visible = false;
	}

	private void RefreshPurchasePopup()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		((GObject)purchasePopup.closeBtn).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			ClosePurchasePop(x);
		});
		((GObject)purchasePopup.Mask).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			ClosePurchasePop(x);
		});
		List<string> list = new List<string>();
		foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig item in MissionData.ScoreProgressBonusConfig)
		{
			if (item.IsAdvance)
			{
				string key = item.PayBonus.First().Key;
				list.Add(key);
			}
		}
		int count = list.Count;
		for (int num = 0; num < count; num++)
		{
			UI_ProgressionMissionPurchaseItem uI_ProgressionMissionPurchaseItem = (UI_ProgressionMissionPurchaseItem)(object)((GComponent)purchasePopup.ContentList).GetChildAt(num);
			string storeItemId = list[num];
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, storeItemId);
			KeyValuePair<string, int> keyValuePair = storeItem.Content.First();
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(keyValuePair.Key);
			GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[((num + 1) * 60).ToString()];
			bool claimed = missonOf7ForeignBonusClaimed.PayBonus.Claimed;
			uI_ProgressionMissionPurchaseItem.rewardIconAdvance.url = storeItem.GetIconUrl();
			((GObject)uI_ProgressionMissionPurchaseItem.NumAdvance).text = keyValuePair.Value.ShortNumberFormat();
			string desc = LanguagesManager.GetDesc("CsharpProgressionMissionTip2", "Return Nuggets {0}");
			((GObject)uI_ProgressionMissionPurchaseItem.returnDes).text = string.Format(desc, storeItem.GetMtgPrice());
			uI_ProgressionMissionPurchaseItem.isPurchased.selectedIndex = (claimed ? 1 : 0);
			((GObject)uI_ProgressionMissionPurchaseItem.rewardName).text = gDEItemData.Name;
			((GObject)uI_ProgressionMissionPurchaseItem.price).text = storeItem.GetCurrentPriceDisplay();
			UiHelper.SetStoreItemDiscount(storeItem, uI_ProgressionMissionPurchaseItem.discount, ribbonVisible: false, 4);
		}
		UI_ProgressionMissionPurchaseBtn uI_ProgressionMissionPurchaseBtn = (UI_ProgressionMissionPurchaseBtn)(object)((GComponent)purchasePopup.ContentList).GetChildAt(count);
		StoreItem pack = SevenDaysPackAll;
		((GObject)uI_ProgressionMissionPurchaseBtn.TotalPrice).text = pack.GetCurrentPriceDisplay(additionFormat: false);
		((GObject)uI_ProgressionMissionPurchaseBtn.TakeAll).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			StoreItem storeItem2 = StoreItem.Get(GameManagers.Instance, pack.StoreItemId);
			OnClickPurchaseStoreItem(x, storeItem2, -1);
		});
	}

	private void ClaimMissionReward(UI_ProgressionMissionBtn btn, string missionId)
	{
		Mission mission = MissionManager.Missions[missionId];
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		GTweenCallback val2 = default(GTweenCallback);
		GTweenCallback val5 = default(GTweenCallback);
		PlayCompleteCallback val7 = default(PlayCompleteCallback);
		ILRequestHelper<MissionClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id), delegate(MissionClaimResponse response)
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Expected O, but got Unknown
			//IL_02f2: Expected O, but got Unknown
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Expected O, but got Unknown
			//IL_0318: Expected O, but got Unknown
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Expected O, but got Unknown
			//IL_034a: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				_response.Score += 10;
				ThinkingDataHelper.Instance.DailyTaskTrack(mission.Id);
				for (int i = 0; i < 10; i++)
				{
					GLoader item = new GLoader();
					UI_com_effCoinFlash clip = UI_com_effCoinFlash.CreateInstance();
					((GComponent)this).AddChild((GObject)(object)item);
					((GComponent)this).AddChild((GObject)(object)clip);
					((GObject)item).width = ((GObject)flyAnim).width;
					((GObject)item).height = ((GObject)flyAnim).height;
					item.url = btn.rewardIcon.url;
					item.fill = flyAnim.fill;
					((GObject)clip).alpha = 0f;
					Vector2 val = ((GObject)this).GlobalToLocal(((GObject)btn).LocalToGlobal(Vector2.op_Implicit(((GObject)btn.rewardIcon).position)));
					((GObject)item).position = Vector2.op_Implicit(val + ((GObject)btn.rewardIcon).size * 0.5f);
					((GObject)item).pivot = Vector2.one * 0.5f;
					((GObject)item).pivotAsAnchor = true;
					EventCallback0 val10 = default(EventCallback0);
					((GObject)item).TweenMove(Vector2.op_Implicit(((GObject)item).position) + Random.insideUnitCircle * 100f, 0.33f).SetDelay(Random.Range(0f, 0.5f)).SetEase((EaseType)8)
						.OnComplete((GTweenCallback)delegate
						{
							//IL_000f: Unknown result type (might be due to invalid IL or missing references)
							//IL_0019: Unknown result type (might be due to invalid IL or missing references)
							//IL_002e: Unknown result type (might be due to invalid IL or missing references)
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_0038: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Unknown result type (might be due to invalid IL or missing references)
							//IL_0049: Unknown result type (might be due to invalid IL or missing references)
							//IL_0065: Unknown result type (might be due to invalid IL or missing references)
							//IL_006f: Expected O, but got Unknown
							Vector2 endPos = Random.insideUnitCircle * 50f + Vector2.op_Implicit(((GObject)icon).position);
							((GObject)item).TweenMove(endPos, 0.66f).SetEase((EaseType)7).OnComplete((GTweenCallback)delegate
							{
								//IL_000d: Unknown result type (might be due to invalid IL or missing references)
								//IL_0012: Unknown result type (might be due to invalid IL or missing references)
								//IL_0083: Unknown result type (might be due to invalid IL or missing references)
								//IL_0088: Unknown result type (might be due to invalid IL or missing references)
								//IL_008a: Expected O, but got Unknown
								//IL_008f: Expected O, but got Unknown
								((GObject)clip).position = Vector2.op_Implicit(endPos);
								((GObject)clip).alpha = 1f;
								clip.n0.SetPlaySettings(0, -1, 1, -1);
								EventListener onPlayEnd = clip.n0.onPlayEnd;
								EventCallback0 obj6 = val10;
								if (obj6 == null)
								{
									EventCallback0 val11 = delegate
									{
										((GObject)clip).Dispose();
									};
									EventCallback0 val12 = val11;
									val10 = val11;
									obj6 = val12;
								}
								onPlayEnd.Add(obj6);
								t0.Play();
								((GObject)item).Dispose();
							});
						});
				}
				int num = _response.Score / 10 - 1;
				GImage n = ((UI_ProgressionMissionRewardBar)(object)((GComponent)rewardContent.rewardProgressList).GetChildAt(num)).n27;
				((GObject)n).alpha = 1f;
				float height = ((GObject)n).height;
				((GObject)n).height = 0f;
				((GObject)n).TweenResize(new Vector2(((GObject)n).width, height), 0.4f).SetDelay(1.1f).SetEase((EaseType)0);
				GTweener obj = ((GObject)this).TweenFade(1f, 1.5f);
				GTweenCallback obj2 = val2;
				if (obj2 == null)
				{
					GTweenCallback val3 = delegate
					{
						((GObject)this).InvalidateBatchingState();
					};
					GTweenCallback val4 = val3;
					val2 = val3;
					obj2 = val4;
				}
				GTweener obj3 = obj.OnUpdate(obj2);
				GTweenCallback obj4 = val5;
				if (obj4 == null)
				{
					GTweenCallback val6 = delegate
					{
						RefreshRewardView();
					};
					GTweenCallback val4 = val6;
					val5 = val6;
					obj4 = val4;
				}
				obj3.OnComplete(obj4);
				Transition disappear = btn.disappear;
				PlayCompleteCallback obj5 = val7;
				if (obj5 == null)
				{
					PlayCompleteCallback val8 = delegate
					{
						if (!((GObject)this).isDisposed)
						{
							ClaimAnim((GObject)(object)btn, delegate
							{
								if (!((GObject)this).isDisposed)
								{
									RefreshMissionContent();
									RefreshTabNote();
									InitCurrencyHeader(addCouponBtn, addDiamondBtn, addWorkerBtn, ref floatingNum);
								}
							});
						}
					};
					PlayCompleteCallback val9 = val8;
					val7 = val8;
					obj5 = val9;
				}
				disappear.Play(obj5);
			}
		}, 1f);
	}

	public static void ClaimAnim(GObject button, Action onComplete)
	{
		GComponent bParent = button.parent;
		int childIndex = bParent.GetChildIndex(button);
		bool flag = childIndex == bParent.numChildren - 1;
		float height = button.height;
		height += (float)((GObject)bParent).asList.lineGap;
		for (int i = childIndex + 1; i < bParent.numChildren; i++)
		{
			GObject childAt = bParent.GetChildAt(i);
			childAt.TweenMoveY((float)(i - 1) * height, 0.5f).SetEase((EaseType)5);
		}
		if (flag)
		{
			bParent.RemoveChild(button, true);
			onComplete();
			return;
		}
		EffectHelper.CoroutineDelay(0.5f, delegate
		{
			bParent.RemoveChild(button, true);
			onComplete();
		});
	}

	private void ClaimScoreReward(int score, bool isAdvance)
	{
		int index = score / 10 - 1;
		HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig bonusConfig = MissionData.ScoreProgressBonusConfig[index];
		string itemId = bonusConfig.Bonus.First().Key;
		int itemCount = bonusConfig.Bonus.First().Value;
		if (isAdvance)
		{
			string key = bonusConfig.PayBonus.First().Key;
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, key);
			itemId = storeItem.Content.First().Key;
			itemCount = storeItem.Content.First().Value;
		}
		Task<ClaimMissionOf7Foreign.Response> task = GameController.Contexts.Service<INetworkService>().ClaimMissionOf7Foreign(score, isAdvance);
		task.GetAwaiter().OnCompleted(delegate
		{
			ClaimMissionOf7Foreign.Response result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRuntimeDebug.LogError($"Claim Score Reward failed {result.ErrorCode}");
			}
			else
			{
				UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
				Bonus.Get(itemId, itemCount).Claim(GameManagers.Instance);
				GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[score.ToString()];
				if (!isAdvance)
				{
					missonOf7ForeignBonusClaimed.Bonus.Claimed = true;
					UI_ProgressionMissionRewardItem uI_ProgressionMissionRewardItem = (UI_ProgressionMissionRewardItem)(object)((GComponent)rewardContent.rewardList).GetChildAt(index);
					((GObject)uI_ProgressionMissionRewardItem.n35).visible = true;
					uI_ProgressionMissionRewardItem.t2.Play();
					uI_ProgressionMissionRewardItem.n35.frame = 0;
				}
				else
				{
					missonOf7ForeignBonusClaimed.PayBonus.Claimed = true;
				}
				RefreshRewardView();
			}
		});
	}

	private int GetNextScoreReward()
	{
		int score = _response.Score;
		foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.BonusConfig item in MissionData.ScoreProgressBonusConfig)
		{
			if (item.RequiredScore <= score)
			{
				GetMissionOf7Foreign.MissonOf7ForeignBonusClaimed missonOf7ForeignBonusClaimed = _response.BonusClaimedProgress[item.RequiredScore.ToString()];
				if (!missonOf7ForeignBonusClaimed.Bonus.Claimed)
				{
					return item.RequiredScore;
				}
			}
		}
		return -1;
	}

	private void RefreshTabNote()
	{
		for (int i = 0; i < _currentDay; i++)
		{
			bool visible = false;
			int key = i + 1;
			MissionSerialConfig missionSerialConfig = MissionData.MissionConfig[key];
			foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig item in missionSerialConfig.MissionSerial)
			{
				Mission mission = MissionManager.Missions[item.MissionId];
				if (mission.CanClaimBonus(GameManagers.Instance))
				{
					visible = true;
					break;
				}
			}
			UI_ProgressionTabBtn uI_ProgressionTabBtn = (UI_ProgressionTabBtn)(object)((GComponent)missionTabList).GetChildAt(i);
			((GObject)uI_ProgressionTabBtn.note).visible = visible;
		}
	}

	public static int FindFistShowTab(int currentDay, out bool hasUnclaimedReward)
	{
		int num = -1;
		int num2 = -1;
		hasUnclaimedReward = false;
		for (int i = 0; i < currentDay; i++)
		{
			int key = i + 1;
			MissionSerialConfig missionSerialConfig = MissionData.MissionConfig[key];
			foreach (HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.MissionConfig item in missionSerialConfig.MissionSerial)
			{
				Mission mission = MissionManager.Missions[item.MissionId];
				if (mission.CanClaimBonus(GameManagers.Instance))
				{
					num = i;
					hasUnclaimedReward = true;
				}
				if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
				{
					num2 = i;
				}
			}
		}
		if (num >= 0)
		{
			return num;
		}
		if (num2 >= 0)
		{
			return num2;
		}
		return currentDay - 1;
	}

	public void OnShow()
	{
	}

	private void OnMissionChanged(Mission mission)
	{
		RefreshMissionContent();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void ClosePanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public static void InitCurrencyHeader(GComponent addCouponBtn, GComponent addDiamondBtn, GComponent addWorkerBtn, ref UI_ProductionNumFloating NumFloatingGem)
	{
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
		UI_ActivityPanel.UpdateMoney(addCouponBtn);
		UI_ActivityPanel.UpdateGemstone(addDiamondBtn, ref NumFloatingGem);
		UI_ActivityPanel.UpdateManPower(addWorkerBtn);
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderSuccess);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderSuccess);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		switch (itemId)
		{
		case "Gem":
			UI_ActivityPanel.UpdateGemstone(addDiamondBtn, ref floatingNum);
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
			break;
		case "Money":
			UI_ActivityPanel.UpdateMoney(addCouponBtn);
			break;
		case "ManPower":
			UI_ActivityPanel.UpdateManPower(addWorkerBtn);
			break;
		}
	}

	private void OnOrderSuccess(List<Bonus> a, List<Bonus> b)
	{
		((GObject)purchasePopup).visible = false;
		InitRewardView(isInit: false);
	}
}
