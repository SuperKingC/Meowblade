using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.FullScreenAnimation;
using UI.MainCity;
using UI.Tips;
using UI.WorldMap;
using UnityEngine;

namespace UI.NewbieMission;

public class UI_NewbieMissionPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_MissionColumn MissionColumn;

	public GLoader Finger;

	public Transition ShowPanel;

	public const string URL = "ui://kmmwvr7ckk930";

	public static string Name = "UI_NewbieMissionPanel";

	public static bool AllRewardClaimed;

	private bool isMainCity;

	private int interval = 0;

	private const int showFingerTime = 3;

	private Coroutine showFingerTimerCoroutine;

	private bool hasFguiGrootClick;

	private bool mainCityUiIsTop;

	private bool needPlayUpdateInfoTransition;

	private string selectChestItemId;

	private const string MainChestItemId = "I40256";

	public static string GetURL()
	{
		return "ui://kmmwvr7ckk930";
	}

	public static UI_NewbieMissionPanel CreateInstance()
	{
		return (UI_NewbieMissionPanel)(object)UIPackage.CreateObject("NewbieMission", "NewbieMissionPanel");
	}

	public static UI_NewbieMissionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NewbieMissionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ckk930", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		MissionColumn = (UI_MissionColumn)(object)((GComponent)this).GetChild("MissionColumn");
		Finger = (GLoader)((GComponent)this).GetChild("Finger");
		ShowPanel = ((GComponent)this).GetTransition("ShowPanel");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager.Instance.Unregister("NewbieMission.Popup", MissionColumn.MissionDesc.GotoBtn);
		if (showFingerTimerCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(showFingerTimerCoroutine);
		}
	}

	private Mission GetCurPickedNewbieMission()
	{
		Mission mission = null;
		Mission mission2 = null;
		GameManagers.Instance.MissionManager.RefreshCurNewbieMission();
		foreach (Mission value2 in MissionManager.NewbieMissions.Values)
		{
			if (value2.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
			{
				mission = value2;
				break;
			}
		}
		if (!string.IsNullOrEmpty(GameManagers.Instance.MissionManager.CurPickedNewbieMissionid) && GameManagers.Instance.MissionManager.PickedMissions.TryGetValue(GameManagers.Instance.MissionManager.CurPickedNewbieMissionid, out var value))
		{
			mission2 = value;
		}
		if (mission == null && mission2 == null)
		{
			return null;
		}
		if (mission != null && mission2 == null)
		{
			return mission;
		}
		if (mission == null)
		{
			return mission2;
		}
		Regex regex = new Regex("\\d*$");
		int.TryParse(regex.Match(mission.Id).Value, out var result);
		int.TryParse(regex.Match(mission2.Id).Value, out var result2);
		if (result2 < result)
		{
			return mission2;
		}
		return mission;
	}

	private Mission GetCurPickedNewbieSummaryMission()
	{
		Mission mission = null;
		Mission mission2 = null;
		GameManagers.Instance.MissionManager.RefreshCurNewbieMission();
		foreach (Mission value2 in MissionManager.NewbieSummaryMissions.Values)
		{
			if (value2.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
			{
				mission = value2;
				break;
			}
		}
		if (!string.IsNullOrEmpty(GameManagers.Instance.MissionManager.CurPickedNewbieSummaryMissionid) && GameManagers.Instance.MissionManager.PickedMissions.TryGetValue(GameManagers.Instance.MissionManager.CurPickedNewbieSummaryMissionid, out var value))
		{
			mission2 = value;
		}
		if (mission == null && mission2 == null)
		{
			return null;
		}
		if (mission != null && mission2 == null)
		{
			return mission;
		}
		if (mission == null)
		{
			return mission2;
		}
		Regex regex = new Regex("\\d*$");
		int.TryParse(regex.Match(mission.Id).Value, out var result);
		int.TryParse(regex.Match(mission2.Id).Value, out var result2);
		if (result2 < result)
		{
			return mission2;
		}
		return mission;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("CurrentScene", out var value) && value.ToString() == "MainCity")
		{
			isMainCity = true;
		}
		RefreshMissionColumn();
	}

	public void OnShow()
	{
		if (UnityUiService.Instance.NewbieMissionPanel == null)
		{
			UnityUiService.Instance.NewbieMissionPanel = this;
			SetSortingOrder(UnityUiService.UiPanelSortingOrder.CommonPanelOrder);
		}
		UiTagManager.Instance.Register("NewbieMission.Popup", MissionColumn.MissionDesc.GotoBtn);
		NewGuidePanelShow();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetSummaryMissionReward(isInit: true));
		StartMainCityGuide();
	}

	private void NewGuidePanelShow()
	{
		Mission curPickedNewbieMission = GetCurPickedNewbieMission();
		if (curPickedNewbieMission != null)
		{
			if (curPickedNewbieMission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed && ((GObject)this).visible)
			{
				SharedMessenger.Broadcast("NEW_GUIDE_PANEL_SHOW", curPickedNewbieMission.Id);
			}
			if (curPickedNewbieMission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
			{
				SharedMessenger.Broadcast("NEW_GUIDE_MISSION_UNDERGOING", curPickedNewbieMission.Id);
			}
		}
	}

	private void PlayGetSummaryMissionRewardTransition(Mission mission, ModelsBonus bonus)
	{
		string value = ((GObject)MissionColumn.summaryMissionRewardIcon).data?.ToString();
		string itemId = bonus.ItemId;
		int qty = bonus.Qty;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_FullScreenAnimationPanel.Name, new Dictionary<string, object>
		{
			{ "PlayNewbieSummaryMissionTransition", true },
			{ "RewardLoader", MissionColumn.summaryMissionRewardIcon },
			{ "RewardIconUrl", value },
			{
				"SummaryMissionRewardTitleIconUrl",
				mission.Id + "RewardTitle"
			},
			{
				"RewardNumText",
				$"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, itemId)}x{qty}"
			},
			{ "ItemId", itemId }
		});
	}

	private void UpdateSummaryMissionProgress()
	{
		if (((GObject)MissionColumn.summaryMissionProgress).data != null)
		{
			int num = (int)((GObject)MissionColumn.summaryMissionProgress).data;
			((GObject)MissionColumn.summaryMissionProgress).text = $"[color=#178914]{num}/{num}[/color]";
		}
	}

	private void RefreshMissionColumn()
	{
		Mission curPickedNewbieSummaryMission = GetCurPickedNewbieSummaryMission();
		Mission curPickedNewbieMission = GetCurPickedNewbieMission();
		if (curPickedNewbieSummaryMission == null && curPickedNewbieMission == null)
		{
			SetVisible(value: false);
			return;
		}
		if (curPickedNewbieSummaryMission != null && curPickedNewbieSummaryMission.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed)
		{
			MissionColumnDisappear();
			return;
		}
		SetVisible(value: true);
		if (curPickedNewbieSummaryMission != null)
		{
			bool flag = curPickedNewbieSummaryMission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed;
			MissionColumn.SummaryMissionStatus.selectedIndex = (flag ? 1 : 0);
			if (MissionColumn.SummaryMissionStatus.selectedIndex == 0)
			{
				int num = 0;
				float num2 = 0f;
				if (AchievementManager.Achievements.TryGetValue(curPickedNewbieSummaryMission.Data.TriggerPayload, out var value))
				{
					num = value.Target.Missions.Count;
					num2 = value.CurrentValue(GameManagers.Instance);
					((GObject)MissionColumn.summaryMissionProgress).text = $"{num2}/{num}";
					((GObject)MissionColumn.summaryMissionProgress).data = num;
				}
			}
			KeyValuePair<string, string> keyValuePair = curPickedNewbieSummaryMission.DisplayBonus.First();
			MissionColumn.summaryMissionRewardIcon.url = "ui://NewbieMission/" + keyValuePair.Key;
			((GObject)MissionColumn.summaryMissionRewardIcon).data = keyValuePair.Key;
			if (curPickedNewbieSummaryMission.DisplayBonus.Count > 1)
			{
				string text = curPickedNewbieSummaryMission.DisplayBonus.Keys.ToList()?[1];
				MissionColumn.secondRewardIcon.url = "ui://NewbieMission/" + text;
			}
		}
		UpdateCurrentMission(curPickedNewbieMission);
	}

	private void UpdateCurrentMission(Mission cur_mission)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		if (cur_mission == null)
		{
			return;
		}
		if (needPlayUpdateInfoTransition)
		{
			needPlayUpdateInfoTransition = false;
			MissionColumnExpansion(0);
			((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
			{
				UpdateCurrentMissionInfo(cur_mission);
				MissionColumnExpansion(1);
			});
		}
		else
		{
			UpdateCurrentMissionInfo(cur_mission);
		}
	}

	private void UpdateCurrentMissionInfo(Mission cur_mission)
	{
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		if (cur_mission != null)
		{
			bool flag = cur_mission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed;
			MissionColumn.State.selectedIndex = (flag ? 1 : 0);
			MissionColumn.MissionDesc.GotoBtn.goNow.SetSelectedIndex((!flag) ? 1 : 0);
			((GObject)MissionColumn.MissionDesc.redNote).visible = flag;
			((GObject)MissionColumn.arrowBtn.redNote).visible = flag;
			string arg = (flag ? "#178914" : "#fe0000");
			int num = Convert.ToInt32(cur_mission.CurrentValue(GameManagers.Instance));
			int num2 = Convert.ToInt32(cur_mission.TargetValue(GameManagers.Instance));
			if (!string.IsNullOrEmpty(cur_mission.FirstTag) && cur_mission.FirstTag.Contains("MinusOne"))
			{
				num--;
				num2--;
			}
			((GObject)MissionColumn.MissionDesc.MissionDesc).text = cur_mission.Data.Desc ?? "";
			((GObject)MissionColumn.MissionDesc.MissionValue).text = $"[color={arg}]{num}/{num2}[/color]";
			KeyValuePair<string, string> keyValuePair = cur_mission.DisplayBonus.First();
			bool frameVisible = Shift.Legion.Common.Models.Item.ItemType(keyValuePair.Key) == 3;
			FGUIManager.Instance.SetItemIconAndFrame(MissionColumn.MissionDesc.missionRewardIcon, keyValuePair.Key, null, "", frameVisible);
			((GObject)MissionColumn.MissionDesc.MissionReward).text = $"x{int.Parse(keyValuePair.Value)}";
			if (!string.IsNullOrEmpty(cur_mission.BonusList?[0]?.ItemId))
			{
				((GObject)MissionColumn.MissionDesc.missionRewardIcon).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(cur_mission.BonusList?[0]?.ItemId, 1, noCheckBtn: true);
				});
			}
		}
		bool flag2 = MissionColumn.Type.selectedIndex == 1;
		((GObject)MissionColumn.MissionDesc).alpha = (flag2 ? 1f : 0f);
		((GObject)MissionColumn.MissionDesc.n9).alpha = (flag2 ? 1f : 0f);
		((GObject)MissionColumn.MissionDesc.missionRewardIcon).alpha = (flag2 ? 1f : 0f);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		SharedMessenger.AddListener<Mission>("MISSION_PICKED", OnMissionPicked);
		SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		SharedMessenger.AddListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
		SharedMessenger.AddListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		SharedMessenger.AddListener<string>("STORY_END", OnStoryEnd);
		SharedMessenger.AddListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.AddListener<string>("ENTER_STORY_MAIN_LEVEL", OnEnterBattle);
		SharedMessenger.AddListener("ENTER_REPLAY_LEVEL", OnReplayEnter);
		SharedMessenger.AddListener("GET_NEW_GUIDE_MISSION_END", OnGetSummaryMissionEnd);
		SharedMessenger.AddListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", CheckIsMainCityTop);
		SharedMessenger.AddListener<string>("MAIN_CITY_COM_UNLOCKED", OnUnlockedMainCityCom);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<bool>("ON_SCOUT_BTN_CLICK", OnScoutBtnClickHide);
		((GObject)GRoot.inst).onClick.Add(new EventCallback0(GRootInstClick));
		((GObject)MissionColumn.MissionDesc.GotoBtn).onClick.Add(new EventCallback1(MissionColumnClick));
		((GObject)MissionColumn.arrowBtn).onClick.Add(new EventCallback0(MissionColumnArrowClick));
		((GObject)MissionColumn.summaryMissionRewardIcon).onClick.Add(new EventCallback0(SummaryMissionIconClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		SharedMessenger.RemoveListener<Mission>("MISSION_PICKED", OnMissionPicked);
		SharedMessenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		SharedMessenger.RemoveListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
		SharedMessenger.RemoveListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		SharedMessenger.RemoveListener<string>("STORY_END", OnStoryEnd);
		SharedMessenger.RemoveListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.RemoveListener<string>("ENTER_STORY_MAIN_LEVEL", OnEnterBattle);
		SharedMessenger.RemoveListener("ENTER_REPLAY_LEVEL", OnReplayEnter);
		SharedMessenger.RemoveListener("GET_NEW_GUIDE_MISSION_END", OnGetSummaryMissionEnd);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", CheckIsMainCityTop);
		SharedMessenger.RemoveListener<string>("MAIN_CITY_COM_UNLOCKED", OnUnlockedMainCityCom);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<bool>("ON_SCOUT_BTN_CLICK", OnScoutBtnClickHide);
		((GObject)GRoot.inst).onClick.Remove(new EventCallback0(GRootInstClick));
		((GObject)MissionColumn.MissionDesc.GotoBtn).onClick.Remove(new EventCallback1(MissionColumnClick));
		((GObject)MissionColumn.arrowBtn).onClick.Remove(new EventCallback0(MissionColumnArrowClick));
		((GObject)MissionColumn.summaryMissionRewardIcon).onClick.Remove(new EventCallback0(SummaryMissionIconClick));
	}

	private void OnChangeMissionProgress(Mission mission)
	{
		if (mission.MissionType == MissionType.Newbie || mission.MissionType == MissionType.NewbieSummary)
		{
			Mission curPickedNewbieMission = GetCurPickedNewbieMission();
			UpdateCurrentMission(curPickedNewbieMission);
			NewGuidePanelShow();
		}
	}

	private void OnMissionCompleted(Mission mission)
	{
		if (mission.MissionType == MissionType.Newbie || mission.MissionType == MissionType.NewbieSummary)
		{
			RefreshMissionColumn();
			NewGuidePanelShow();
		}
	}

	public void OnMissionClaimed(Mission mission)
	{
		if (mission.MissionType == MissionType.Newbie)
		{
			((GObject)Finger).visible = false;
			needPlayUpdateInfoTransition = mission.MissionType == MissionType.Newbie;
			Mission curPickedNewbieMission = GetCurPickedNewbieMission();
			UpdateCurrentMission(curPickedNewbieMission);
		}
	}

	public void OnMissionPicked(Mission mission)
	{
		if (mission.MissionType == MissionType.Newbie || mission.MissionType == MissionType.NewbieSummary)
		{
			RefreshMissionColumn();
			NewGuidePanelShow();
		}
	}

	public void OnStoryEnd(string storyId)
	{
		if (string.IsNullOrEmpty(storyId))
		{
			return;
		}
		foreach (string value in NewGuideModeManager.GuideModeMissionPrefix.Values)
		{
			if (storyId.Contains(value))
			{
				NewGuidePanelShow();
				break;
			}
		}
	}

	public void OnBattleStart(Level level)
	{
		UnityUiService.Instance.HideNewbieMissionPanel();
	}

	public void OnReplayEnter()
	{
		SetVisible(value: false);
	}

	public void OnGetSummaryMissionEnd()
	{
		RefreshMissionColumn();
		NewGuidePanelShow();
	}

	private void UpdateCurMissionInfo()
	{
		RefreshMissionColumn();
		NewGuidePanelShow();
	}

	public void OnEnterBattle(string levelId)
	{
		if (!string.IsNullOrEmpty(levelId) && levelId == "Live001")
		{
			SetVisible(value: false);
		}
	}

	private void OnScoutBtnClickHide(bool showGifLoader)
	{
		Mission curPickedNewbieSummaryMission = GetCurPickedNewbieSummaryMission();
		Mission curPickedNewbieMission = GetCurPickedNewbieMission();
		if ((curPickedNewbieSummaryMission != null || curPickedNewbieMission != null) && (curPickedNewbieSummaryMission == null || curPickedNewbieSummaryMission.MissionState(GameManagers.Instance).Status != MissionStatus.Claimed))
		{
			SetVisible(showGifLoader);
		}
	}

	public void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (string.IsNullOrEmpty(itemId) || itemId != "I40256" || incr <= 0 || GameManagers.Instance.StockController.GetStock(itemId) < 1 || context.Item1 != StockInContext.Mission)
		{
			return;
		}
		selectChestItemId = itemId;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, selectChestItemId);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Items"))
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
			}
		}
		List<KeyValuePair<string, int>> value = dictionary.ToList();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems_Large.Name, new Dictionary<string, object>
		{
			{
				"Name",
				SchemaIndexHelper.GetNameById(GameManagers.Instance, selectChestItemId) ?? ""
			},
			{ "ShowSelectedReward", true },
			{ "SelectItems", value },
			{ "Parent", this },
			{ "SelectItemId", selectChestItemId },
			{ "WaitOpen", true }
		});
		selectChestItemId = string.Empty;
	}

	public void OnUnlockedMainCityCom(string componentName)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		if (!(componentName == "NewbieMission.MainCityCom"))
		{
			return;
		}
		((GObject)MissionColumn).x = 0f - ((GObject)MissionColumn).width;
		((GObject)MissionColumn.n5).alpha = 0f;
		((GObject)MissionColumn.n12).alpha = 0f;
		((GObject)MissionColumn.summaryMissionRewardIcon).alpha = 0f;
		((GObject)MissionColumn.summaryMissionProgress).alpha = 0f;
		((GObject)MissionColumn.secondRewardIcon).alpha = 0f;
		SetVisible(value: true);
		((GObject)MissionColumn).TweenMoveX(0f, 0.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			FGUIManager.Instance.AddTextSpecialEffects(MissionColumn.SfxBack, "workplaceSmoke_2", new Vector3(2.5f, 2.5f, 2.5f), "Default", 0.5f, delegate(GameObject workplaceSmoke2)
			{
				workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				UiAudioManager.Instance.LoadSoundsForSfx(workplaceSmoke2, "BalloonBlast");
			});
			((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
			{
				((GObject)MissionColumn.n5).alpha = 1f;
				((GObject)MissionColumn.n12).alpha = 1f;
				((GObject)MissionColumn.summaryMissionRewardIcon).alpha = 1f;
				((GObject)MissionColumn.summaryMissionProgress).alpha = 1f;
				((GObject)MissionColumn.secondRewardIcon).alpha = 1f;
			});
		});
	}

	public void SetVisible(bool value, int expansionState = 1)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (!GameManagers.Instance.UserArchiveManager.GetUnlockedMainCityCom().Contains("NewbieMission.MainCityCom"))
		{
			((GObject)this).visible = false;
			return;
		}
		((GObject)this).visible = value;
		if (value)
		{
			MissionColumnExpansion(expansionState);
		}
	}

	private void MissionColumnDisappear()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (AllRewardClaimed)
		{
			((GObject)this).visible = false;
			return;
		}
		((GObject)MissionColumn).TweenMoveX(0f - ((GObject)MissionColumn).width, 0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)this).visible = false;
			AllRewardClaimed = true;
		});
	}

	public void SetSortingOrder(UnityUiService.UiPanelSortingOrder order)
	{
		if (((GObject)((GObject)this).parent).parent != null && ((GObject)((GObject)this).parent).parent is Window)
		{
			GComponent parent = ((GObject)((GObject)this).parent).parent;
			Window val = (Window)(object)((parent is Window) ? parent : null);
			val.BringToFront();
			((GObject)val).sortingOrder = (int)order;
		}
	}

	public void SetMissionColumnState()
	{
		if (!((GObject)MissionColumn).isDisposed)
		{
			MissionColumn.State.selectedIndex = 0;
		}
	}

	public void MissionColumnClick(EventContext context)
	{
		((GObject)Finger).visible = false;
		Mission cur_mission = GetCurPickedNewbieMission();
		if (cur_mission == null)
		{
			return;
		}
		if (cur_mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			GDEMissionFrontEndOnlyData gDEMissionFrontEndOnlyData = MissionManager.Configs_GDEMissionFrontEndOnlyData[cur_mission.Id];
			GameManagers.Instance.NewGuideMissionManager.MonoInstance.PlayStory(cur_mission.Id, 4);
		}
		if (cur_mission.MissionState(GameManagers.Instance).Status != MissionStatus.Completed)
		{
			return;
		}
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		context.StopPropagation();
		GameManagers.Instance.NewGuideMissionManager.MonoInstance.PlayStory(cur_mission.Id, 3);
		ILRequestHelper<MissionClaimResponse>.Request((EventContext)null, (Func<Task<MissionClaimResponse>>)(() => GameController.Contexts.Service<INetworkService>().MissionClaim(cur_mission.Id)), (Action<MissionClaimResponse>)delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.BonusList != null && response.BonusList.Count > 0)
			{
				foreach (ModelsBonus bonus in response.BonusList)
				{
					bonus.StockInReason = StockInContext.Mission;
				}
				FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
				SharedMessenger.Broadcast("MISSION_CLAIMED", cur_mission);
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetSummaryMissionReward());
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
			}
		});
	}

	private void MissionColumnExpansion(int typeIndex)
	{
		MissionColumn.Type.selectedIndex = typeIndex;
		MissionColumn.arrowBtn.Type.selectedIndex = typeIndex;
		((GObject)MissionColumn.MissionDesc.missionRewardIcon).touchable = typeIndex == 1;
	}

	private void MissionColumnArrowClick()
	{
		if (MissionColumn.arrowBtn.Type.selectedIndex == 1)
		{
			MissionColumnExpansion(0);
		}
		else
		{
			MissionColumnExpansion(1);
		}
	}

	private void SummaryMissionIconClick()
	{
		Mission curPickedNewbieSummaryMission = GetCurPickedNewbieSummaryMission();
		if (curPickedNewbieSummaryMission != null && !string.IsNullOrEmpty(curPickedNewbieSummaryMission.BonusList?[0]?.ItemId))
		{
			FGUIManager.Instance.ItemTip(curPickedNewbieSummaryMission.BonusList?[0]?.ItemId, 1, noCheckBtn: true);
		}
	}

	private IEnumerator GetSummaryMissionReward(bool isInit = false)
	{
		Mission curSummaryMission = GetCurPickedNewbieSummaryMission();
		if (curSummaryMission == null || (curSummaryMission.MissionState(GameManagers.Instance).Status != MissionStatus.Completed && isInit))
		{
			yield break;
		}
		ILRequestHelper<MissionClaimResponse>.Request((EventContext)null, (Func<Task<MissionClaimResponse>>)(() => GameController.Contexts.Service<INetworkService>().MissionClaim(curSummaryMission.Id)), (Action<MissionClaimResponse>)delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				if (!isInit)
				{
					UpdateCurMissionInfo();
				}
			}
			else if (response.BonusList != null && response.BonusList.Count > 0)
			{
				foreach (ModelsBonus bonus in response.BonusList)
				{
					bonus.StockInReason = StockInContext.Mission;
				}
				FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
				SharedMessenger.Broadcast("MISSION_CLAIMED", curSummaryMission);
				UpdateSummaryMissionProgress();
				PlayGetSummaryMissionRewardTransition(curSummaryMission, response.BonusList[0]);
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
			}
		});
	}

	private void StartMainCityGuide()
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && isMainCity && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P220"))
		{
			CheckIsMainCityTop("");
			showFingerTimerCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowFingerTimer());
		}
	}

	private IEnumerator ShowFingerTimer()
	{
		while (true)
		{
			interval += 2;
			yield return (object)new WaitForSecondsRealtime(2f);
			if (!CanShowFinger())
			{
				interval = 0;
			}
			if (interval > 3)
			{
				interval = 0;
				FGUIManager.Instance.OpenIEnumerator(ShowFinger());
			}
		}
	}

	private void CheckIsMainCityTop(string uiName)
	{
		mainCityUiIsTop = UnityUiService.Instance.CheckIsMainCityShowedForNewGuideMode();
	}

	private void CheckIsMainCityTop(string uiName, Dictionary<string, object> uiData)
	{
		mainCityUiIsTop = UnityUiService.Instance.CheckIsMainCityShowedForNewGuideMode();
		if (uiName == UI_WorldMapPanel.Name)
		{
			((GObject)Finger).visible = false;
		}
	}

	private IEnumerator ShowFinger()
	{
		Mission cur_mission = GetCurPickedNewbieMission();
		if (cur_mission != null && cur_mission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			MissionColumnExpansion(1);
			yield return (object)new WaitForSecondsRealtime(0.5f);
			((GObject)Finger).visible = true;
			Vector2 showPos = UiHelper.GetGObjectPositionOnGRoot((GObject)(object)MissionColumn.MissionDesc.GotoBtn, new Vector2(((GObject)MissionColumn.MissionDesc.GotoBtn).width / 2f, ((GObject)MissionColumn.MissionDesc.GotoBtn).height / 2f));
			((GObject)Finger).xy = showPos;
		}
		else if (GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120"))
		{
			ShowFingerOnEnterBattleFieldBtn();
		}
		else if (cur_mission != null)
		{
			MissionColumnExpansion(1);
			yield return (object)new WaitForSecondsRealtime(0.5f);
			((GObject)Finger).visible = true;
			Vector2 showPos = UiHelper.GetGObjectPositionOnGRoot((GObject)(object)MissionColumn.MissionDesc.GotoBtn, new Vector2(((GObject)MissionColumn.MissionDesc.GotoBtn).width / 2f, ((GObject)MissionColumn.MissionDesc.GotoBtn).height / 2f));
			((GObject)Finger).xy = showPos;
		}
	}

	private void ShowFingerOnEnterBattleFieldBtn()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		UI_MainBattleBtn mainBattleBtn = FGUIManager.Instance.MaincityUi.MainBattleBtn;
		Vector2 zero = Vector2.zero;
		if (((GObject)mainBattleBtn).pivotAsAnchor)
		{
			((Vector2)(ref zero))._002Ector(((GObject)mainBattleBtn).pivotX * ((GObject)mainBattleBtn).width, ((GObject)mainBattleBtn).pivotY * ((GObject)mainBattleBtn).height);
		}
		Vector2 gObjectPositionOnGRoot = UiHelper.GetGObjectPositionOnGRoot((GObject)(object)mainBattleBtn, new Vector2(((GObject)mainBattleBtn).width / 2f, ((GObject)mainBattleBtn).height / 2f));
		((GObject)Finger).visible = true;
		((GObject)Finger).xy = gObjectPositionOnGRoot;
	}

	private bool CanShowFinger()
	{
		if (((GObject)Finger).visible)
		{
			return false;
		}
		if (hasFguiGrootClick)
		{
			hasFguiGrootClick = false;
			return false;
		}
		if (!mainCityUiIsTop)
		{
			return false;
		}
		if (GameManagers.Instance.NewGuideMissionManager.MonoInstance.HasStoryPlaying())
		{
			return false;
		}
		return true;
	}

	private void GRootInstClick()
	{
		((GObject)Finger).visible = false;
		hasFguiGrootClick = true;
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
