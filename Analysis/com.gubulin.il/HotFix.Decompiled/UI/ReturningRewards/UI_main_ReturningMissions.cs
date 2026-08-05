using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.ReturningRewards;

public class UI_main_ReturningMissions : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Missions Missions;

	public Transition ShowDialog;

	public const string URL = "ui://rx5ntv98win2b";

	public static string Name = "UI_main_ReturningMissions";

	private const string RETURNING_MISSIONS = "ReturningMissions";

	private List<IRecallWelfareMission> _missions;

	public static string GetURL()
	{
		return "ui://rx5ntv98win2b";
	}

	public static UI_main_ReturningMissions CreateInstance()
	{
		return (UI_main_ReturningMissions)(object)UIPackage.CreateObject("ReturningRewards", "main_ReturningMissions");
	}

	public static UI_main_ReturningMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ReturningMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Missions = (UI_com_Missions)(object)((GComponent)this).GetChild("Missions");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public static void Open(List<IRecallWelfareMission> missions)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "ReturningMissions", missions } });
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Missions.Close).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Missions.Close).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_missions = (parameters.TryGetValue("ReturningMissions", out var value) ? ((List<IRecallWelfareMission>)value) : new List<IRecallWelfareMission>());
	}

	public void OnShow()
	{
		RenderMissions();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderMissions()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Missions.Missions.itemRenderer = new ListItemRenderer(MissionRenderer);
		Missions.Missions.numItems = _missions.Count;
	}

	private void MissionRenderer(int index, GObject obj)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		if (!(obj is UI_com_AchievementWrapper { Achievement: var achievement }))
		{
			throw new ArgumentException("UI_main_ReturningMissions MissionRenderer obj is not UI_com_AchievementWrapper");
		}
		IRecallWelfareMission recallWelfareMission = _missions[index];
		achievement.State.SetSelectedIndex((int)recallWelfareMission.State);
		RecallWelfareMissionJumpContext jumpContext = recallWelfareMission.GetJumpContext();
		bool flag = jumpContext != null;
		achievement.HasJumpUi.SetSelectedIndex(flag ? 1 : 0);
		((GObject)achievement.Desc).text = recallWelfareMission.Description;
		((GObject)achievement.LevelCase).text = recallWelfareMission.LevelCase;
		((GObject)achievement.Value).text = $"{recallWelfareMission.CurrentValue}/{recallWelfareMission.TargetValue}";
		((GObject)achievement.RewardNum).text = recallWelfareMission.Score.ToString();
		((GObject)achievement.Jump).data = jumpContext;
		((GObject)achievement).data = index;
		((GObject)achievement.Jump).onClick.Set(new EventCallback1(TryJumpUi));
		((GObject)achievement).onClick.Set(new EventCallback1(ClaimMissionReward));
	}

	private static void TryJumpUi(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		((RecallWelfareMissionJumpContext)((GObject)context.sender).data)?.GoToRelativeUi();
	}

	private void ClaimMissionReward(EventContext context)
	{
		UI_com_Achievement uI_com_Achievement = (UI_com_Achievement)(object)context.sender;
		if (uI_com_Achievement.State.selectedIndex == 1)
		{
			int missionIndex = (int)((GObject)uI_com_Achievement).data;
			IRecallWelfareMission recallWelfareMission = _missions[missionIndex];
			GameManagers.Instance.ActivityManager.ClaimRecallWelfareMissionReward(recallWelfareMission.MissionId, delegate
			{
				OnMissionClaimed(missionIndex);
			});
		}
	}

	private void OnMissionClaimed(int index)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		if (!(((GComponent)Missions.Missions).GetChildAt(index) is UI_com_AchievementWrapper uI_com_AchievementWrapper) || ((GObject)uI_com_AchievementWrapper).isDisposed)
		{
			return;
		}
		uI_com_AchievementWrapper.RemoveTrans.Play((PlayCompleteCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				UpdateMissionOnClaim(index);
			}
		});
	}

	private void UpdateMissionOnClaim(int lastRemoveIndex)
	{
		if (!((GObject)this).isDisposed)
		{
			IRecallWelfareMission recallWelfareMission = _missions[lastRemoveIndex];
			recallWelfareMission.OnMissionRewardClaimed(recallWelfareMission.MissionId);
			MissionAppear(lastRemoveIndex);
		}
	}

	private void MissionAppear(int lastRemoveIndex)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		for (int i = 0; i < ((GComponent)Missions.Missions).numChildren; i++)
		{
			GObject childAt = ((GComponent)Missions.Missions).GetChildAt(i);
			UI_com_AchievementWrapper wrapper = childAt as UI_com_AchievementWrapper;
			if (wrapper != null)
			{
				wrapper.Disappear.Play();
				if (lastRemoveIndex == i)
				{
					((GObject)wrapper.Achievement).x = 0f;
				}
				int wrapperIndex = i;
				((GComponent)(object)this).SetTimeout((float)i * 0.1f).OnComplete((GTweenCallback)delegate
				{
					MissionRenderer(wrapperIndex, (GObject)(object)wrapper);
					wrapper.Appear.Play();
				});
			}
		}
	}
}
