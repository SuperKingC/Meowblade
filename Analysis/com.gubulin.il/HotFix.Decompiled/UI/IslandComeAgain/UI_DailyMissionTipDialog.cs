using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.IslandComeAgain;

public class UI_DailyMissionTipDialog : GComponent, IUiController
{
	public GImage n0;

	public GImage n1;

	public GList DailyMissionList;

	public GTextField n10;

	public GTextField n11;

	public const string URL = "ui://k2sprg26ke8paj";

	public static string Name = "UI_DailyMissionTipDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26ke8paj";
	}

	public static UI_DailyMissionTipDialog CreateInstance()
	{
		return (UI_DailyMissionTipDialog)(object)UIPackage.CreateObject("IslandComeAgain", "DailyMissionTipDialog");
	}

	public static UI_DailyMissionTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailyMissionTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26ke8paj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		DailyMissionList = (GList)((GComponent)this).GetChild("DailyMissionList");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://k2sprg26ke8paj".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://k2sprg26ke8paj".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
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

	public void RefreshPanel()
	{
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		if (dynamicIslandComeAgainActivity == null)
		{
			ILRuntimeDebug.LogError("[UI_DailyMissionTipDialog]RefreshPanel: IslandComeAgainActivities[0] is null");
			End();
			return;
		}
		DateTimeOffset serverNow = DateTimeHelper.ServerNow;
		GameManagers.Instance.UserArchiveManager.EnsureIslandComeAgainDailyRecord(serverNow, out var _);
		List<int> todayIZIDClaimRecord = GameManagers.Instance.UserArchiveManager.GetTodayIZIDClaimRecord();
		int count = GameManagers.Instance.UserArchiveManager.GetTodayIZIDRecord().Count;
		DailyMissionList.RemoveChildrenToPool();
		if (dynamicIslandComeAgainActivity.DailyMissions != null && dynamicIslandComeAgainActivity.DailyMissions.Count > 0)
		{
			for (int i = 0; i < dynamicIslandComeAgainActivity.DailyMissions.Count; i++)
			{
				UI_DailyMissionCom uI_DailyMissionCom = DailyMissionList.AddItemFromPool("ui://k2sprg26ke8pai") as UI_DailyMissionCom;
				DailyMission mission = dynamicIslandComeAgainActivity.DailyMissions[i];
				string firstRewardId = mission.Reward.Keys.First();
				((GObject)uI_DailyMissionCom.desc).text = string.Format(LanguagesManager.GetDesc("IslandComeAgainDailyMissionDesc"), mission.OnComplete);
				((GObject)uI_DailyMissionCom.reward.rewardCnt).text = $"x{mission.Reward[firstRewardId]}";
				FGUIManager.Instance.SetItemIconAndFrame(uI_DailyMissionCom.reward.rewardIcon, firstRewardId, null, "", frameVisible: false);
				((GObject)uI_DailyMissionCom.progressTip).text = $"{count}/{mission.OnComplete}";
				if (todayIZIDClaimRecord.Contains(mission.MissionId))
				{
					uI_DailyMissionCom.state.selectedIndex = 2;
					uI_DailyMissionCom.reward.state.selectedIndex = 2;
					((GObject)uI_DailyMissionCom.reward).onClick.Set((EventCallback0)delegate
					{
						firstRewardId.DisplayItemTip();
					});
				}
				else if (mission.OnComplete > count)
				{
					uI_DailyMissionCom.state.selectedIndex = 1;
					uI_DailyMissionCom.reward.state.selectedIndex = 1;
					((GObject)uI_DailyMissionCom.reward).onClick.Set((EventCallback0)delegate
					{
						firstRewardId.DisplayItemTip();
					});
				}
				else
				{
					uI_DailyMissionCom.state.selectedIndex = 0;
					uI_DailyMissionCom.reward.state.selectedIndex = 0;
					((GObject)uI_DailyMissionCom).onClick.Set((EventCallback0)delegate
					{
						OnClickDailyMission(mission);
					});
				}
			}
		}
		else
		{
			End();
		}
	}

	private async void OnClickDailyMission(DailyMission mission)
	{
		ClaimIslandComeAgainDailyMissionBonusResponse response = await GameController.Contexts.Service<INetworkService>().ClaimIslandComeAgainDailyMissionBonus(mission.MissionId);
		if (response == null)
		{
			ILRuntimeDebug.LogError("[UI_DailyMissionTipDialog]OnClickDailyMission response is null");
			ILRequestHelper.ShowErrorCode(-1);
			return;
		}
		if (response.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		foreach (KeyValuePair<string, int> bonusKv in mission.Reward)
		{
			Bonus.Get(bonusKv.Key, bonusKv.Value).Claim(GameManagers.Instance);
		}
		GameManagers.Instance.UserArchiveManager.AddTodayIZIDClaimRecord(mission.MissionId);
		CacheManager.Instance.Get<Cache_IslandComeAgainDailyMissionRedDot>().ForceUpdate();
		RefreshPanel();
	}

	private void End()
	{
	}
}
