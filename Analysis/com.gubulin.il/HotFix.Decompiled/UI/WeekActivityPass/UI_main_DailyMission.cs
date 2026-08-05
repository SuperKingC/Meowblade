using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.LegendItems;
using UI.UpGrade;
using UnityEngine;

namespace UI.WeekActivityPass;

public class UI_main_DailyMission : GComponent, IUiController
{
	public class ShowParam
	{
		public UI_main_WeekActivityPass Parent;
	}

	private class MissionSlot
	{
		public string Title = "";

		public int TargetValue = 0;

		public int CurValue = 0;

		public int BonusLevelNum = 0;

		public bool IsCompleted = false;

		public Mission mission = null;
	}

	public GGraph Mask;

	public UI_com_DailyrMissionDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://11dkggb8nk8f2y";

	public static string Name = "UI_main_DailyMission";

	public const string Param = "Param";

	private List<MissionSlot> MissionData = new List<MissionSlot>();

	private List<Mission> RawMissions = new List<Mission>();

	private Dictionary<string, MissionSlot> MissionMap = new Dictionary<string, MissionSlot>();

	public int DataLoadingStatus = 0;

	private ShowParam _showParam;

	private UI_main_WeekActivityPass _parentPanel;

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f2y";
	}

	public static UI_main_DailyMission CreateInstance()
	{
		return (UI_main_DailyMission)(object)UIPackage.CreateObject("WeekActivityPass", "main_DailyMission");
	}

	public static UI_main_DailyMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_DailyMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_DailyrMissionDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnChangeMissionProgress);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnChangeMissionProgress);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ShowSelf.Play();
		_showParam = (ShowParam)parameters["Param"];
		_parentPanel = _showParam.Parent;
		Dialog.MissionList.SetVirtual();
		Dialog.MissionList.itemRenderer = new ListItemRenderer(ItemRenderer);
		Dialog.MissionList.numItems = 0;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetMissionCoroutine());
	}

	private void OnAllDataLoaded()
	{
		UpdateMissionList();
	}

	private IEnumerator GetMissionCoroutine()
	{
		if (DataLoadingStatus == 1)
		{
			while (DataLoadingStatus != 2)
			{
				yield return null;
			}
		}
		if (DataLoadingStatus == 2)
		{
			OnMissionLoaded();
			OnAllDataLoaded();
			yield break;
		}
		DataLoadingStatus = 1;
		foreach (KeyValuePair<string, Mission> dailyMission in MissionManager.DailyMissions)
		{
			Mission m = dailyMission.Value;
			MissionStatus status = m.MissionState(GameManagers.Instance).Status;
			if (status != MissionStatus.Disabled && status != MissionStatus.Pending && status != MissionStatus.Failed)
			{
				RawMissions.Add(m);
			}
		}
		RawMissions.Sort((Mission a, Mission b) => a.FirstTag.CompareTo(b.FirstTag));
		OnMissionLoaded();
		yield return null;
		foreach (Mission m2 in RawMissions)
		{
			int quantity = m2.BonusList.First().Qty;
			MissionSlot data = new MissionSlot
			{
				Title = m2.Data.Desc,
				CurValue = Convert.ToInt32(m2.CurrentValue(GameManagers.Instance)),
				TargetValue = Convert.ToInt32(m2.TargetValue(GameManagers.Instance)),
				BonusLevelNum = quantity,
				mission = m2
			};
			MissionData.Add(data);
			MissionMap.Add(m2.Id, data);
		}
		DataLoadingStatus = 2;
		UpdateMissionProgress();
		OnAllDataLoaded();
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UI_com_MissionSlot uI_com_MissionSlot = (UI_com_MissionSlot)(object)obj;
		if (index >= MissionData.Count)
		{
			((GObject)uI_com_MissionSlot.Title).text = "-----";
			((GObject)uI_com_MissionSlot.Progress).text = "--/--";
			uI_com_MissionSlot.LevelIcon.url = _parentPanel.CurLevelIcon.url;
			((GObject)uI_com_MissionSlot.LevelText).text = "--";
			((GObject)uI_com_MissionSlot.GotoBtn).visible = false;
			return;
		}
		MissionSlot data = MissionData[index];
		((GObject)uI_com_MissionSlot.Title).text = data.Title;
		((GObject)uI_com_MissionSlot.Progress).text = $"{data.CurValue}/{data.TargetValue}";
		uI_com_MissionSlot.LevelIcon.url = _parentPanel.CurLevelIcon.url;
		((GObject)uI_com_MissionSlot.LevelText).text = data.BonusLevelNum.ToString();
		uI_com_MissionSlot.IsCompleted.selectedIndex = (data.IsCompleted ? 1 : 0);
		if (!string.IsNullOrEmpty(data.mission.JumpContext))
		{
			((GObject)uI_com_MissionSlot.GotoBtn).visible = true;
			((GObject)uI_com_MissionSlot.GotoBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickGotoBtn(data.mission);
			});
		}
		else
		{
			((GObject)uI_com_MissionSlot.GotoBtn).visible = false;
		}
	}

	private void OnClickGotoBtn(Mission mission)
	{
		string eventName = "";
		bool isLegendItem = false;
		bool isBuilding14 = false;
		if (mission.JumpContext.Contains("PVPEntrance"))
		{
			eventName = "OPEN_PVP_PANEL";
		}
		else if (mission.JumpContext.Contains("UI_LegendItemsPanel"))
		{
			isLegendItem = true;
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.Show, -1L);
		}
		else if (mission.JumpContext.Contains("UI_MilitaryIntelligencePanel"))
		{
			isBuilding14 = true;
		}
		if (mission.Id == "MISSION1443" || mission.Id == "MISSION1444")
		{
			isLegendItem = true;
		}
		ShowLegendItemTip();
		if (!ShowBuilding14Tip())
		{
			OpenUi();
		}
		void OpenUi()
		{
			if (string.IsNullOrEmpty(eventName))
			{
				mission.GoToRelativeUi();
			}
			else
			{
				SharedMessenger.Broadcast(eventName);
			}
		}
		bool ShowBuilding14Tip()
		{
			if (!isBuilding14)
			{
				return false;
			}
			bool flag = true;
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("14");
			if (buildingByType.Status == BuildingStatus.Banned)
			{
				List<string> arg = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				flag = false;
			}
			else if (buildingByType.Status == BuildingStatus.Ready || buildingByType.Level == 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, new Dictionary<string, object>
				{
					{ "Parent", this },
					{ "Building", buildingByType }
				});
				flag = false;
			}
			if (!flag)
			{
				return true;
			}
			return !FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true);
		}
		void ShowLegendItemTip()
		{
			if (isLegendItem && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520"))
			{
				eventName = LanguagesManager.GetDesc("CsharpCodeZhTcText636") + "5-20" + LanguagesManager.GetDesc("CsharpCodeZhTcText637");
				List<string> arg = new List<string> { eventName };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
	}

	private void OnMissionLoaded()
	{
		int num = 0;
		foreach (Mission rawMission in RawMissions)
		{
			MissionStatus status = rawMission.MissionState(GameManagers.Instance).Status;
			if (status == MissionStatus.Completed)
			{
				num++;
			}
		}
		int count = RawMissions.Count;
		Dialog.MissionList.numItems = count;
	}

	private void UpdateMissionList()
	{
		if (!((GObject)this).isDisposed)
		{
			Dialog.MissionList.numItems = MissionData.Count;
			Dialog.MissionList.RefreshVirtualList();
		}
	}

	private void OnChangeMissionProgress(Mission mission)
	{
		if (!((GObject)this).isDisposed && DataLoadingStatus == 2 && MissionManager.DailyMissions.ContainsKey(mission.Id))
		{
			UpdateMissionProgress(mission);
			UpdateMissionList();
		}
	}

	private void UpdateMissionProgress(Mission mission = null)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (mission == null)
		{
			foreach (MissionSlot missionDatum in MissionData)
			{
				missionDatum.CurValue = Convert.ToInt32(missionDatum.mission.CurrentValue(GameManagers.Instance));
			}
		}
		else
		{
			if (!MissionMap.ContainsKey(mission.Id))
			{
				return;
			}
			MissionSlot missionSlot = MissionMap[mission.Id];
			missionSlot.CurValue = Convert.ToInt32(missionSlot.mission.CurrentValue(GameManagers.Instance));
		}
		List<MissionSlot> list = new List<MissionSlot>();
		List<MissionSlot> list2 = new List<MissionSlot>();
		foreach (MissionSlot missionDatum2 in MissionData)
		{
			missionDatum2.IsCompleted = missionDatum2.CurValue >= missionDatum2.TargetValue;
			if (missionDatum2.IsCompleted)
			{
				list2.Add(missionDatum2);
				missionDatum2.CurValue = missionDatum2.TargetValue;
			}
			else
			{
				list.Add(missionDatum2);
			}
		}
		MissionData.Clear();
		MissionData.AddRange(list);
		MissionData.AddRange(list2);
		((GObject)Dialog.Progress).text = $"{list2.Count}/{MissionData.Count}";
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
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
}
