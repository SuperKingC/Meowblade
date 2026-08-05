using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace UI.GvGBattleRecord3;

public class UI_main_IslandBattleRecordPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_IslandCampaignDialog Dialog;

	public Transition t0;

	public const string URL = "ui://b3fc6085owu50";

	public static string Name = "UI_main_IslandBattleRecordPanel";

	private int _islandId;

	private List<IslandLog> _islandLogs;

	public static string GetURL()
	{
		return "ui://b3fc6085owu50";
	}

	public static UI_main_IslandBattleRecordPanel CreateInstance()
	{
		return (UI_main_IslandBattleRecordPanel)(object)UIPackage.CreateObject("GvGBattleRecord3", "main_IslandBattleRecordPanel");
	}

	public static UI_main_IslandBattleRecordPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandBattleRecordPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu50", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_IslandCampaignDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_islandId = (parameters.TryGetValue("IslandId", out var value) ? ((int)value) : 0);
		((GObject)Dialog.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Name;
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesIslandBattleLog(_islandId, RenderCampaignRecords);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GComponent)Dialog.CampaignRecords).scrollPane.onPullUpRelease.Add(new EventCallback0(OnPullUpRefresh));
		((GComponent)Dialog.CampaignRecords).scrollPane.onPullDownRelease.Add(new EventCallback0(OnPullDownRefresh));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GComponent)Dialog.CampaignRecords).scrollPane.onPullUpRelease.Remove(new EventCallback0(OnPullUpRefresh));
		((GComponent)Dialog.CampaignRecords).scrollPane.onPullDownRelease.Remove(new EventCallback0(OnPullDownRefresh));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void CheckIslandLogDetail(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)context.sender).data;
		IslandLog islandLog = _islandLogs[num];
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandCampaignPanel.Name, new Dictionary<string, object>
		{
			{ "ProcessId", islandLog.NameId },
			{ "ReservePackageResOnClose", true },
			{ "IslandId", _islandId },
			{ "RandomEventName", islandLog.RandomEventName },
			{ "IsBossBattle", islandLog.IsBossBattle },
			{ "WinnerCampId", islandLog.WinnerCampId },
			{ "IsRunning", islandLog.IsRunning },
			{ "IslandLog", islandLog }
		});
		islandLog.Checked = true;
		GameLocalDataManager.CheckIslandLog(islandLog.NameId);
		int num2 = Dialog.CampaignRecords.ItemIndexToChildIndex(num);
		if (((GComponent)Dialog.CampaignRecords).GetChildAt(num2) is UI_com_IslandCampaign uI_com_IslandCampaign)
		{
			uI_com_IslandCampaign.IsNew.selectedIndex = 0;
		}
	}

	private void OnPullUpRefresh()
	{
		ScrollPane recordsScrollPane = ((GComponent)Dialog.CampaignRecords).scrollPane;
		ScrollPaneHeader footer = (ScrollPaneHeader)(object)recordsScrollPane.footer;
		footer.SetRefreshStatus(2);
		recordsScrollPane.LockFooter(30);
		int startId = ((_islandLogs != null && _islandLogs.Count > 0) ? _islandLogs[_islandLogs.Count - 1].Id : (-1));
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesIslandBattleLog(_islandId, UpdateCampaignRecords, startId, OnPullUpEnd);
		void OnPullUpEnd()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				footer.SetRefreshStatus(0);
				recordsScrollPane.LockFooter(0);
			});
		}
	}

	private void OnPullDownRefresh()
	{
		ScrollPane recordsScrollPane = ((GComponent)Dialog.CampaignRecords).scrollPane;
		ScrollPaneHeader header = (ScrollPaneHeader)(object)recordsScrollPane.header;
		header.SetRefreshStatus(2);
		recordsScrollPane.LockHeader(50);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesIslandBattleLog(_islandId, UpdateCampaignRecords, -1, OnPullDownEnd);
		void OnPullDownEnd()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				header.SetRefreshStatus(0);
				recordsScrollPane.LockHeader(0);
			});
		}
	}

	private void UpdateCampaignRecords(List<IslandLog> islandLogs)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		if (islandLogs != null && islandLogs.Count > 0)
		{
			CampaignRecordsAddRange(islandLogs);
			Dialog.CampaignRecords.itemRenderer = new ListItemRenderer(RenderIslandLog);
			Dialog.CampaignRecords.numItems = _islandLogs.Count;
			Dialog.State.SetSelectedIndex((_islandLogs.Count <= 0) ? 1 : 0);
		}
	}

	private void CampaignRecordsAddRange(List<IslandLog> islandLogs)
	{
		HashSet<int> hashSet = new HashSet<int>(_islandLogs.Select((IslandLog log) => log.Id));
		foreach (IslandLog islandLog in islandLogs)
		{
			if (!hashSet.Contains(islandLog.Id) && islandLog.CanBeDisplay())
			{
				_islandLogs.Add(islandLog);
				hashSet.Add(islandLog.Id);
			}
		}
		_islandLogs.Sort(IslandLogSort);
	}

	private int IslandLogSort(IslandLog a, IslandLog b)
	{
		if (a.Id > b.Id)
		{
			return -1;
		}
		return (a.Id < b.Id) ? 1 : 0;
	}

	private void RenderCampaignRecords(List<IslandLog> islandLogs)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		_islandLogs = islandLogs.Clone();
		for (int num = _islandLogs.Count - 1; num >= 0; num--)
		{
			if (!_islandLogs[num].CanBeDisplay())
			{
				_islandLogs.RemoveAt(num);
			}
		}
		_islandLogs.Sort(IslandLogSort);
		Dialog.CampaignRecords.SetVirtual();
		Dialog.CampaignRecords.itemRenderer = new ListItemRenderer(RenderIslandLog);
		Dialog.CampaignRecords.numItems = _islandLogs.Count;
		Dialog.State.SetSelectedIndex((_islandLogs.Count <= 0) ? 1 : 0);
	}

	private void RenderIslandLog(int index, GObject obj)
	{
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		if (!(obj is UI_com_IslandCampaign uI_com_IslandCampaign))
		{
			return;
		}
		IslandLog islandLog = _islandLogs[index];
		uI_com_IslandCampaign.IsNew.selectedIndex = ((!islandLog.Checked) ? 1 : 0);
		if (islandLog.IsBrawlFight())
		{
			bool flag = islandLog.GetBrawlEventType() == eGvGMode3CampMissionSubType.RE_FFA;
			GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(islandLog.BrawlEventDay);
			DateTimeOffset fightingTimeDisplay = gvGMode3BrawlEvent_BaseInfo.GetFightingTimeDisplay((int)(islandLog.IslandStartTimestamp_ms / 1000));
			DateTimeOffset dateTimeOffset = fightingTimeDisplay.AddSeconds(islandLog.BrawlEventDuration);
			uI_com_IslandCampaign.BattleState.SetSelectedIndex(flag ? 3 : 2);
			uI_com_IslandCampaign.CampAttack.Camp.selectedIndex = islandLog.WinnerCampId;
			((GObject)uI_com_IslandCampaign.EndTime).text = fightingTimeDisplay.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			((GObject)uI_com_IslandCampaign.StartTime).text = dateTimeOffset.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
		}
		else
		{
			uI_com_IslandCampaign.BattleState.SetSelectedIndex(islandLog.IsRunning ? 1 : 0);
			((GObject)uI_com_IslandCampaign.EndTime).text = DateTimeHelper.ParseMillisecondsTimeStamp(islandLog.IslandEndTimestamp_ms).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			((GObject)uI_com_IslandCampaign.StartTime).text = DateTimeHelper.ParseMillisecondsTimeStamp(islandLog.IslandStartTimestamp_ms).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			uI_com_IslandCampaign.CampAttack.Camp.selectedIndex = islandLog.ProcessStartByWhichCamp;
		}
		uI_com_IslandCampaign.HasRandomEvent.selectedIndex = ((!string.IsNullOrEmpty(islandLog.RandomEventName)) ? 1 : 0);
		((GObject)uI_com_IslandCampaign.CheckRecords).data = index;
		((GObject)uI_com_IslandCampaign.CheckRecords).onClick.Set(new EventCallback1(CheckIslandLogDetail));
		try
		{
			uI_com_IslandCampaign.CampOccupy.Camp.selectedIndex = islandLog.WinnerCampId;
		}
		catch (Exception)
		{
		}
	}
}
