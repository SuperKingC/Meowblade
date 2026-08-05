using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.Activities;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GameActivity;
using UI.MainCity;
using UI.PublicResources;
using UnityEngine;

namespace UI.ProgressionMission;

public class UI_ChallengeMissionPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback1 _003C_003E9__53_0;

		public static Comparison<Mission> _003C_003E9__59_0;

		public static Action<GameObject> _003C_003E9__67_0;

		internal void _003CInit_003Eb__53_0(EventContext x)
		{
			x.StopPropagation();
			ClosePanel();
		}

		internal int _003CRefreshMissionList_003Eb__59_0(Mission a, Mission b)
		{
			MissionConfig missionConfig = a.MissionState(GameManagers.Instance);
			MissionConfig missionConfig2 = b.MissionState(GameManagers.Instance);
			return missionConfig.Status.GetSortOrder() - missionConfig2.Status.GetSortOrder();
		}

		internal void _003COnStockChange_003Eb__67_0(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}
	}

	public Controller ClaimStatus;

	public Controller index;

	public GLoader background;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GComponent addWorkerBtn;

	public GButton backBtn;

	public GComponent Title;

	public GImage n114;

	public GImage n115;

	public GImage n125;

	public GList missionTabList;

	public GList missionList;

	public GImage n109;

	public GImage n116;

	public GTextField decs;

	public GTextField progressDesc;

	public GTextField progressText;

	public GMovieClip n137;

	public GImage n133;

	public GImage n134;

	public GGroup n136;

	public GImage n148;

	public GLoader rewardIcon;

	public UI_receiveBtn receiveBtn;

	public GTextField rewardNum;

	public GImage progressBar;

	public GLoader n141;

	public GLoader n142;

	public GLoader n143;

	public GLoader n144;

	public GLoader n145;

	public GLoader n146;

	public GLoader n147;

	public GGroup summaryReward;

	public GImage n139;

	public GRichTextField countDownText;

	public GGroup n140;

	public GGroup n138;

	public Transition t1;

	public const string URL = "ui://mapat4i5pjcu8e";

	public static string Name = "UI_ChallengeMissionPanel";

	private UI_ProductionNumFloating floatingNum;

	private int _currentTab;

	private float _progressBarMaxLen;

	public UI_PanelTitle PanelTitle => (UI_PanelTitle)(object)Title;

	public static ChallengeMissionPayload MissionData => ActivityManager.ChallengeMission.ChallengeMissionData;

	public static string GetURL()
	{
		return "ui://mapat4i5pjcu8e";
	}

	public static UI_ChallengeMissionPanel CreateInstance()
	{
		return (UI_ChallengeMissionPanel)(object)UIPackage.CreateObject("ProgressionMission", "ChallengeMissionPanel");
	}

	public static UI_ChallengeMissionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChallengeMissionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5pjcu8e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
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
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ClaimStatus = ((GComponent)this).GetController("ClaimStatus");
		index = ((GComponent)this).GetController("index");
		background = (GLoader)((GComponent)this).GetChild("background");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (GComponent)((GComponent)this).GetChild("Title");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		missionTabList = (GList)((GComponent)this).GetChild("missionTabList");
		missionList = (GList)((GComponent)this).GetChild("missionList");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		decs = (GTextField)((GComponent)this).GetChild("decs");
		string id = "ui://mapat4i5pjcu8e".Replace("ui://", "") + "-" + ((GObject)decs).id;
		((GObject)decs).text = LanguagesManager.GetDesc(id);
		progressDesc = (GTextField)((GComponent)this).GetChild("progressDesc");
		progressText = (GTextField)((GComponent)this).GetChild("progressText");
		n137 = (GMovieClip)((GComponent)this).GetChild("n137");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n136 = (GGroup)((GComponent)this).GetChild("n136");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		progressBar = (GImage)((GComponent)this).GetChild("progressBar");
		n141 = (GLoader)((GComponent)this).GetChild("n141");
		n142 = (GLoader)((GComponent)this).GetChild("n142");
		n143 = (GLoader)((GComponent)this).GetChild("n143");
		n144 = (GLoader)((GComponent)this).GetChild("n144");
		n145 = (GLoader)((GComponent)this).GetChild("n145");
		n146 = (GLoader)((GComponent)this).GetChild("n146");
		n147 = (GLoader)((GComponent)this).GetChild("n147");
		summaryReward = (GGroup)((GComponent)this).GetChild("summaryReward");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		countDownText = (GRichTextField)((GComponent)this).GetChild("countDownText");
		string id2 = "ui://mapat4i5pjcu8e".Replace("ui://", "") + "-" + ((GObject)countDownText).id;
		((GObject)countDownText).text = LanguagesManager.GetDesc(id2);
		n140 = (GGroup)((GComponent)this).GetChild("n140");
		n138 = (GGroup)((GComponent)this).GetChild("n138");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)PanelTitle.buildingName).text = LanguagesManager.GetDesc("CsharpPanelNameChallengeMission");
		EventListener onClick = ((GObject)backBtn).onClick;
		object obj = _003C_003Ec._003C_003E9__53_0;
		if (obj == null)
		{
			EventCallback1 val = delegate(EventContext x)
			{
				x.StopPropagation();
				ClosePanel();
			};
			_003C_003Ec._003C_003E9__53_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback1)obj);
		UI_ProgressionMissionPanel.InitCurrencyHeader(addCouponBtn, addDiamondBtn, addWorkerBtn, ref floatingNum);
		_currentTab = 0;
		_progressBarMaxLen = ((GObject)progressBar).width;
		missionTabList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			UI_ChallengeTabBtn uI_ChallengeTabBtn = (UI_ChallengeTabBtn)(object)item;
			uI_ChallengeTabBtn.Index.selectedIndex = index;
			((GObject)uI_ChallengeTabBtn).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				x.StopPropagation();
				OnClickTab(index);
			});
		};
		missionTabList.numItems = MissionData.MissionConfig.Count;
		bool hasUnclaimedReward;
		int selectIndex = FindDefaultOpenTab(out hasUnclaimedReward);
		OnClickTab(selectIndex);
		RefreshTabNote();
	}

	public static int FindDefaultOpenTab(out bool hasUnclaimedReward)
	{
		int num = -1;
		int num2 = -1;
		hasUnclaimedReward = false;
		int count = MissionData.MissionConfig.Count;
		for (int i = 0; i < count; i++)
		{
			ChallengeMissionSerial challengeMissionSerial = MissionData.MissionConfig[i];
			GDEMissionSerialData gDEMissionSerialData = GDMgr.Get<GDEMissionSerialData>(challengeMissionSerial.MissionSerial);
			foreach (string mission3 in gDEMissionSerialData.Missions)
			{
				Mission mission = MissionManager.Missions[mission3];
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
			Mission mission2 = MissionManager.Missions[challengeMissionSerial.MissionSummary];
			if (mission2.CanClaimBonus(GameManagers.Instance))
			{
				num = i;
				hasUnclaimedReward = true;
			}
			if (mission2.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
			{
				num2 = i;
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
		return count - 1;
	}

	private void OnClickTab(int selectIndex)
	{
		_currentTab = selectIndex;
		index.selectedIndex = selectIndex;
		for (int i = 0; i < missionTabList.numItems; i++)
		{
			UI_ChallengeTabBtn uI_ChallengeTabBtn = (UI_ChallengeTabBtn)(object)((GComponent)missionTabList).GetChildAt(i);
			uI_ChallengeTabBtn.SelectState.selectedIndex = ((_currentTab != i) ? 1 : 2);
		}
		RefreshMissionContent();
	}

	private void RefreshMissionContent()
	{
		int currentTab = _currentTab;
		ChallengeMissionSerial challengeMissionSerial = MissionData.MissionConfig[currentTab];
		RefreshMissionSummary(challengeMissionSerial.MissionSummary);
		RefreshMissionList(challengeMissionSerial.MissionSerial);
	}

	private void RefreshTabNote()
	{
		int count = MissionData.MissionConfig.Count;
		for (int i = 0; i < count; i++)
		{
			bool flag = false;
			ChallengeMissionSerial challengeMissionSerial = MissionData.MissionConfig[i];
			GDEMissionSerialData gDEMissionSerialData = GDMgr.Get<GDEMissionSerialData>(challengeMissionSerial.MissionSerial);
			foreach (string mission3 in gDEMissionSerialData.Missions)
			{
				Mission mission = MissionManager.Missions[mission3];
				if (mission.CanClaimBonus(GameManagers.Instance))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Mission mission2 = MissionManager.Missions[challengeMissionSerial.MissionSummary];
				if (mission2.CanClaimBonus(GameManagers.Instance))
				{
					flag = true;
				}
			}
			UI_ChallengeTabBtn uI_ChallengeTabBtn = (UI_ChallengeTabBtn)(object)((GComponent)missionTabList).GetChildAt(i);
			((GObject)uI_ChallengeTabBtn.note).visible = flag;
		}
	}

	private void RefreshMissionSummary(string missionId)
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		Mission mission = MissionManager.Missions[missionId];
		UI_MainCity.IsChallengeOpen(out var endTimeStamp, out var _);
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		int second = (int)((double)endTimeStamp - serverRealtimeSeconds);
		string desc = LanguagesManager.GetDesc("CsharpChallengeMissionTip1", "Activity Ends In {0}");
		((GObject)countDownText).text = string.Format(desc, UiHelper.ParseTimeSpanUniversal(second));
		bool canClaim = mission.CanClaimBonus(GameManagers.Instance);
		float num = mission.CurrentValue(GameManagers.Instance);
		float num2 = mission.TargetValue(GameManagers.Instance);
		((GObject)progressBar).width = num / num2 * _progressBarMaxLen;
		((GObject)progressText).text = $"{num}/{num2}";
		Bonus bonus = mission.BonusList[0];
		((GObject)rewardNum).text = bonus.Qty.ShortNumberFormat() ?? "";
		string itemId = bonus.ItemId;
		rewardIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)rewardIcon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonus.ItemId, 2);
		});
		MissionStatus status = mission.MissionState(GameManagers.Instance).Status;
		ClaimStatus.selectedIndex = ((status == MissionStatus.Claimed) ? 2 : (canClaim ? 1 : 0));
		((GObject)receiveBtn).onClick.Set((EventCallback0)delegate
		{
			if (canClaim)
			{
				OnClickClaimMissionReward(null, missionId);
			}
		});
	}

	private void RefreshMissionList(string serialId)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		GDEMissionSerialData gDEMissionSerialData = GDMgr.Get<GDEMissionSerialData>(serialId);
		List<Mission> missions = new List<Mission>();
		foreach (string mission2 in gDEMissionSerialData.Missions)
		{
			missions.Add(MissionManager.Missions[mission2]);
		}
		missions.Sort(delegate(Mission a, Mission b)
		{
			MissionConfig missionConfig = a.MissionState(GameManagers.Instance);
			MissionConfig missionConfig2 = b.MissionState(GameManagers.Instance);
			return missionConfig.Status.GetSortOrder() - missionConfig2.Status.GetSortOrder();
		});
		missionList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			UI_ChallengeMissionBtn button = (UI_ChallengeMissionBtn)(object)item;
			Mission mission = missions[index];
			Bonus bonus = mission.BonusList.First();
			((GObject)button.title).text = mission.Data.Desc;
			((GObject)((GObject)button.rewardNum).asTextField).text = bonus.Qty.ShortNumberFormat() ?? "";
			string itemId = bonus.ItemId;
			bool canClaim = mission.CanClaimBonus(GameManagers.Instance);
			Controller receiveStatus = button.ReceiveStatus;
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
			bool enableClick = status != MissionStatus.Claimed;
			((GObject)button.num).text = $"{(int)mission.CurrentValue(GameManagers.Instance)}/{(int)mission.TargetValue(GameManagers.Instance)}";
			button.rewardIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GObject)button.clickBtn).onClick.Set((EventCallback0)delegate
			{
				if (enableClick)
				{
					if (!canClaim)
					{
						UI_ActivityPanel.GoToRelativeUi(mission, (GObject)(object)this);
					}
					else
					{
						OnClickClaimMissionReward(button, mission.Id);
					}
				}
			});
			((GObject)button.rewardIcon).onClick.Set((EventCallback0)delegate
			{
				if (enableClick)
				{
					if (canClaim)
					{
						OnClickClaimMissionReward(button, mission.Id);
					}
					else
					{
						FGUIManager.Instance.ItemTip(bonus.ItemId, 2);
					}
				}
			});
		};
		missionList.numItems = missions.Count;
	}

	private void OnClickClaimMissionReward(UI_ChallengeMissionBtn btn, string missionId)
	{
		Mission mission = MissionManager.Missions[missionId];
		ILRequestHelper<MissionClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().MissionClaim(missionId), delegate(MissionClaimResponse response)
		{
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				foreach (ModelsBonus bonus2 in response.BonusList)
				{
					Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
					bonus.Claim(GameManagers.Instance);
				}
				ThinkingDataHelper.Instance.DailyTaskTrack(mission.Id);
				Action onComplete = delegate
				{
					RefreshMissionContent();
					RefreshTabNote();
					UI_ProgressionMissionPanel.InitCurrencyHeader(addCouponBtn, addDiamondBtn, addWorkerBtn, ref floatingNum);
				};
				if (btn != null)
				{
					btn.disappear.Play((PlayCompleteCallback)delegate
					{
						UI_ProgressionMissionPanel.ClaimAnim((GObject)(object)btn, onComplete);
					});
				}
				else
				{
					onComplete();
				}
			}
		}, 1f);
	}

	public void OnShow()
	{
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

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
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

	private void OnMissionChanged(Mission mission)
	{
		RefreshMissionContent();
	}
}
