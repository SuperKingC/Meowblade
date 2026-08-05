using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.LegendItems;
using UnityEngine;

namespace UI.WarOrder;

public class UI_WarOrderMissionPanel : GComponent, IUiController
{
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

	public UI_WarOrderMissionDialog Dialog;

	public Transition ShowSelf_old;

	public Transition ShowSelf;

	public const string URL = "ui://ax280w58okbc26";

	public static string Name = "UI_WarOrderMissionPanel";

	private const int MissionType = 1;

	private static List<MissionSlot> MissionData = new List<MissionSlot>();

	private static List<Mission> RawMissions = new List<Mission>();

	private static Dictionary<string, MissionSlot> MissionMap = new Dictionary<string, MissionSlot>();

	public static int DataLoadingStatus = 0;

	private UI_WarOrderPanel ParentPanel;

	private int TotalMissionNum = 0;

	private bool IsUpdatingProgress = false;

	private bool IsStartGoto = false;

	private string CurGotoUIName = "";

	public static string GetURL()
	{
		return "ui://ax280w58okbc26";
	}

	public static UI_WarOrderMissionPanel CreateInstance()
	{
		return (UI_WarOrderMissionPanel)(object)UIPackage.CreateObject("WarOrder", "WarOrderMissionPanel");
	}

	public static UI_WarOrderMissionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarOrderMissionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc26", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_WarOrderMissionDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf_old = ((GComponent)this).GetTransition("ShowSelf_old");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnChangeMissionProgress);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUIClose);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnUIOpened);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_PROGRESS_CHANGED", OnChangeMissionProgress);
		GameManagers.Instance.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnChangeMissionProgress);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUIClose);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnUIOpened);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		ParentPanel = (UI_WarOrderPanel)parameters["Parent"];
		ParentPanel.PageController.selectedIndex = 1;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShowSelf.Play();
		Dialog.MissionList.SetVirtual();
		Dialog.MissionList.itemRenderer = new ListItemRenderer(ItemRenderer);
		Dialog.MissionList.numItems = 0;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetMissionCoroutine());
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
		TotalMissionNum = RawMissions.Count;
		((GObject)Dialog.Progress).text = $"{num}/{TotalMissionNum}";
		Dialog.MissionList.numItems = TotalMissionNum;
	}

	private void OnAllDataLoaded()
	{
		UpdateMissionProgress();
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
		foreach (KeyValuePair<string, Mission> weeklyMission in MissionManager.WeeklyMissions)
		{
			Mission m = weeklyMission.Value;
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
			List<Bonus>.Enumerator enumerator3 = m2.BonusList.GetEnumerator();
			enumerator3.MoveNext();
			int quantity = enumerator3.Current.Qty;
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
		OnAllDataLoaded();
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UI_MissionSlot uI_MissionSlot = (UI_MissionSlot)(object)obj;
		if (index >= MissionData.Count)
		{
			((GObject)uI_MissionSlot.Title).text = "-----";
			((GObject)uI_MissionSlot.Progress).text = "--/--";
			uI_MissionSlot.LevelIcon.url = ParentPanel.CurLevelIcon.url;
			((GObject)uI_MissionSlot.LevelText).text = "--";
			((GObject)uI_MissionSlot.GotoBtn).visible = false;
			return;
		}
		MissionSlot data = MissionData[index];
		((GObject)uI_MissionSlot.Title).text = data.Title;
		((GObject)uI_MissionSlot.Progress).text = $"{data.CurValue}/{data.TargetValue}";
		uI_MissionSlot.LevelIcon.url = ParentPanel.CurLevelIcon.url;
		((GObject)uI_MissionSlot.LevelText).text = data.BonusLevelNum.ToString();
		uI_MissionSlot.IsCompleted.selectedIndex = (data.IsCompleted ? 1 : 0);
		if (!string.IsNullOrEmpty(data.mission.JumpContext))
		{
			((GObject)uI_MissionSlot.GotoBtn).visible = true;
			((GObject)uI_MissionSlot.GotoBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickGotoBtn(data.mission);
			});
		}
		else
		{
			((GObject)uI_MissionSlot.GotoBtn).visible = false;
		}
	}

	private void UpdateMissionProgress(Mission mission = null)
	{
		if (((GObject)this).isDisposed || IsUpdatingProgress)
		{
			return;
		}
		IsUpdatingProgress = true;
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
		((GObject)Dialog.Progress).text = $"{list2.Count}/{TotalMissionNum}";
		IsUpdatingProgress = false;
	}

	private void UpdateMissionList()
	{
		if (!((GObject)this).isDisposed && !IsUpdatingProgress)
		{
			Dialog.MissionList.numItems = MissionData.Count;
			Dialog.MissionList.RefreshVirtualList();
		}
	}

	private void OnChangeMissionProgress(Mission mission)
	{
		if (!((GObject)this).isDisposed && DataLoadingStatus == 2 && MissionManager.WeeklyMissions.ContainsKey(mission.Id))
		{
			UpdateMissionProgress(mission);
			UpdateMissionList();
		}
	}

	private void OnClickGotoBtn(Mission mission)
	{
		string text = "";
		bool flag = false;
		if (mission.JumpContext.Contains("PVPEntrance"))
		{
			text = "OPEN_PVP_PANEL";
		}
		else if (mission.JumpContext.Contains("UI_LegendItemsPanel"))
		{
			flag = true;
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.Show, -1L);
		}
		if (mission.Id == "MISSION1443" || mission.Id == "MISSION1444")
		{
			flag = true;
		}
		if (flag && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520"))
		{
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText636") + "5-20" + LanguagesManager.GetDesc("CsharpCodeZhTcText637");
			List<string> arg = new List<string> { text };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		if (string.IsNullOrEmpty(text))
		{
			mission.GoToRelativeUi();
		}
		else
		{
			SharedMessenger.Broadcast(text);
		}
		IsStartGoto = true;
	}

	private void OnUIOpened(string uiName, Dictionary<string, object> parameters)
	{
		if (!((GObject)this).isDisposed && string.IsNullOrEmpty(CurGotoUIName) && IsStartGoto && !uiName.Contains("UI_WarOrder") && !uiName.Contains("UI_SomeTipPanel"))
		{
			CurGotoUIName = uiName;
			((GObject)ParentPanel).visible = false;
			((GObject)this).visible = false;
		}
	}

	private void OnUIClose(string uiName)
	{
		if (!((GObject)this).isDisposed && IsStartGoto && !uiName.Contains("UI_WarOrder") && !uiName.Contains("UI_SomeTipPanel") && !string.IsNullOrEmpty(CurGotoUIName) && CurGotoUIName == uiName)
		{
			CurGotoUIName = "";
			((GObject)ParentPanel).visible = true;
			((GObject)this).visible = true;
			IsStartGoto = false;
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void Destroy()
	{
		if (ParentPanel != null && !((GObject)ParentPanel).isDisposed)
		{
			ParentPanel.PageController.selectedIndex = 0;
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}
}
