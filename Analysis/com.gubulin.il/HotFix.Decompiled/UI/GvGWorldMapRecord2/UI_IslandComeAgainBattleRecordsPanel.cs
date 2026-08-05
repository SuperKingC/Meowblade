using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGWorldMapRecord2;

public class UI_IslandComeAgainBattleRecordsPanel : GComponent, IUiController
{
	public Controller Status;

	public GGraph Mask;

	public UI_GvGBattleRecordsDialog RecordsDialog;

	public UI_GvGBattleRecordDialog RecordDialog;

	public Transition ShowRecordDialog;

	public const string URL = "ui://5xc1njmujjrn2w";

	public static string Name = "UI_IslandComeAgainBattleRecordsPanel";

	private List<UserIslandEntityBattleRecordSummary> battleRecordSummary = new List<UserIslandEntityBattleRecordSummary>();

	public LoadWebImageTaskQueue loadAvatarQueue;

	private int currentSummaryIndex;

	private LogFilter curLogFilterType;

	private int CurUserId;

	private bool isInZone;

	private const string LevelId = "Eventisland3";

	private int SelectedIndex = -1;

	private Coroutine ReplayDetialCoroutine;

	private string RecordDay => LanguagesManager.GetDesc("CsharpCodeZhTcText263");

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn2w";
	}

	public static UI_IslandComeAgainBattleRecordsPanel CreateInstance()
	{
		return (UI_IslandComeAgainBattleRecordsPanel)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "IslandComeAgainBattleRecordsPanel");
	}

	public static UI_IslandComeAgainBattleRecordsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainBattleRecordsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		RecordsDialog = (UI_GvGBattleRecordsDialog)(object)((GComponent)this).GetChild("RecordsDialog");
		RecordDialog = (UI_GvGBattleRecordDialog)(object)((GComponent)this).GetChild("RecordDialog");
		ShowRecordDialog = ((GComponent)this).GetTransition("ShowRecordDialog");
	}

	public void ClearLoadAvatarQueue()
	{
		loadAvatarQueue?.Clear();
	}

	public void CreateLoadAvatarQueue()
	{
		if (loadAvatarQueue == null)
		{
			loadAvatarQueue = new LoadWebImageTaskQueue();
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		battleRecordSummary = (parameters.TryGetValue("BattleRecordSummary", out var value) ? (value as List<UserIslandEntityBattleRecordSummary>) : new List<UserIslandEntityBattleRecordSummary>());
		if (parameters.TryGetValue("IsInZone", out var value2))
		{
			isInZone = (bool)value2;
		}
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
		FilterInit();
		RenderBattleRecordSummary();
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
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GComponent)RecordsDialog.BattleLogList).scrollPane.onScrollEnd.Add(new EventCallback0(UpdateAllSummaryOnListTouch));
		((GObject)RecordsDialog.BattleLogList).onTouchEnd.Add(new EventCallback0(UpdateAllSummaryOnListTouch));
		SharedMessenger.AddListener("ON_GVG2_INSTANCE_END", End);
		SharedMessenger.AddListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.AddListener("ON_GVG2_INSTANCE_START", End);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GComponent)RecordsDialog.BattleLogList).scrollPane.onScrollEnd.Remove(new EventCallback0(UpdateAllSummaryOnListTouch));
		((GObject)RecordsDialog.BattleLogList).onTouchEnd.Remove(new EventCallback0(UpdateAllSummaryOnListTouch));
		SharedMessenger.RemoveListener("ON_GVG2_INSTANCE_END", End);
		SharedMessenger.RemoveListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.RemoveListener("ON_GVG2_INSTANCE_START", End);
	}

	private void RenderBattleRecordSummary()
	{
		ClearLoadAvatarQueue();
		CreateLoadAvatarQueue();
		RenderAllSummary();
		loadAvatarQueue?.Start();
	}

	private void RenderAllSummary()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		ClearLoadAvatarQueue();
		CreateLoadAvatarQueue();
		RecordsDialog.BattleLogList.SetVirtual();
		RecordsDialog.BattleLogList.itemRenderer = new ListItemRenderer(RenderBattleSummary);
		RecordsDialog.BattleLogList.numItems = battleRecordSummary.Count;
		UpdateAllSummary();
		loadAvatarQueue?.Start();
	}

	private void RenderBattleSummary(int index, GObject obj)
	{
		UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig = obj as UI_GvGBattleLogInfoResourcesBig;
		UserIslandEntityBattleRecordSummary userIslandEntityBattleRecordSummary = battleRecordSummary[index];
		if (uI_GvGBattleLogInfoResourcesBig != null && !((GObject)uI_GvGBattleLogInfoResourcesBig).isDisposed && userIslandEntityBattleRecordSummary != null)
		{
			((GObject)uI_GvGBattleLogInfoResourcesBig).onClick.Clear();
			((GObject)uI_GvGBattleLogInfoResourcesBig).data = null;
			((GObject)uI_GvGBattleLogInfoResourcesBig).x = 0f;
			uI_GvGBattleLogInfoResourcesBig.Type.selectedIndex = ((userIslandEntityBattleRecordSummary.SummaryType != SummaryType.IZId) ? 1 : 0);
		}
	}

	private void UpdateAllSummaryOnListTouch()
	{
		ClearLoadAvatarQueue();
		CreateLoadAvatarQueue();
		UpdateAllSummary();
		loadAvatarQueue?.Start();
	}

	private void UpdateAllSummary()
	{
		for (int i = 0; i < ((GComponent)RecordsDialog.BattleLogList).numChildren; i++)
		{
			UpdateBattleSummary(i);
		}
	}

	private void UpdateBattleSummary(int index)
	{
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		int num = RecordsDialog.BattleLogList.ChildIndexToItemIndex(index);
		UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig = ((GComponent)RecordsDialog.BattleLogList).GetChildAt(index) as UI_GvGBattleLogInfoResourcesBig;
		UserIslandEntityBattleRecordSummary userIslandEntityBattleRecordSummary = battleRecordSummary[num];
		if (uI_GvGBattleLogInfoResourcesBig != null && !((GObject)uI_GvGBattleLogInfoResourcesBig).isDisposed && userIslandEntityBattleRecordSummary != null)
		{
			((GObject)uI_GvGBattleLogInfoResourcesBig).onClick.Clear();
			((GObject)uI_GvGBattleLogInfoResourcesBig).data = null;
			((GObject)uI_GvGBattleLogInfoResourcesBig).x = 0f;
			uI_GvGBattleLogInfoResourcesBig.Type.selectedIndex = ((userIslandEntityBattleRecordSummary.SummaryType != SummaryType.IZId) ? 1 : 0);
			uI_GvGBattleLogInfoResourcesBig.SelectController.selectedIndex = 0;
			if (uI_GvGBattleLogInfoResourcesBig.Type.selectedIndex == 0)
			{
				((GObject)uI_GvGBattleLogInfoResourcesBig.Day).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText264"), userIslandEntityBattleRecordSummary.IZId);
				return;
			}
			uI_GvGBattleLogInfoResourcesBig.SelectController.selectedIndex = ((num == currentSummaryIndex) ? 1 : 0);
			uI_GvGBattleLogInfoResourcesBig.Status.selectedIndex = 1;
			uI_GvGBattleLogInfoResourcesBig.AttackAndDefense.selectedIndex = 0;
			((GObject)uI_GvGBattleLogInfoResourcesBig.KillValue).text = $"{userIslandEntityBattleRecordSummary.TotalKill}";
			((GObject)uI_GvGBattleLogInfoResourcesBig.LossValue).text = $"{userIslandEntityBattleRecordSummary.TotalLoss}";
			UI_RankingListAvatar myAvatar = uI_GvGBattleLogInfoResourcesBig.MyAvatar;
			GTextField myName = uI_GvGBattleLogInfoResourcesBig.MyName;
			myAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadAvatarQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, CurUserId, myAvatar.AvatarLoader.icon, myName));
			UI_RankingListAvatar enemyAvatar = uI_GvGBattleLogInfoResourcesBig.EnemyAvatar;
			GTextField enemyName = uI_GvGBattleLogInfoResourcesBig.EnemyName;
			enemyAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadAvatarQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userIslandEntityBattleRecordSummary.EnemyUserId, enemyAvatar.AvatarLoader.icon, enemyName));
			((GObject)uI_GvGBattleLogInfoResourcesBig).data = num;
			((GObject)uI_GvGBattleLogInfoResourcesBig).onClick.Set(new EventCallback1(OpenBattleRecordsDialog));
		}
	}

	private void FilterInit()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		for (int i = 0; i < RecordDialog.Filter.SwitchList.numItems; i++)
		{
			GButton asButton = ((GComponent)RecordDialog.Filter.SwitchList).GetChildAt(i).asButton;
			asButton.selected = false;
			if (i == 0)
			{
				((GObject)asButton).data = 1;
			}
			if (i == 1)
			{
				((GObject)asButton).data = 2;
			}
			((GObject)asButton).onClick.Set(new EventCallback1(ChangeFilter));
		}
	}

	private void ChangeFilter(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		if (((GObject)val).data == null)
		{
			return;
		}
		if (val.selected)
		{
			val.selected = false;
			curLogFilterType = LogFilter.All;
			UpdateBattleRecordsDialog();
			return;
		}
		for (int i = 0; i < RecordDialog.Filter.SwitchList.numItems; i++)
		{
			GButton asButton = ((GComponent)RecordDialog.Filter.SwitchList).GetChildAt(i).asButton;
			asButton.selected = false;
			((GComponent)asButton).GetChild("switcj").asButton.selected = false;
		}
		val.selected = true;
		((GComponent)val).GetChild("switcj").asButton.selected = true;
		curLogFilterType = (LogFilter)(int)((GObject)val).data;
		UpdateBattleRecordsDialog();
	}

	private List<GvGMode2BattleReportBattleRecord> FilterRankChangeRecords(ref List<GvGMode2BattleReportBattleRecord> summariesInit)
	{
		if (curLogFilterType == LogFilter.All)
		{
			return summariesInit;
		}
		for (int num = summariesInit.Count - 1; num >= 0; num--)
		{
			if (CanFilterBattleLog(summariesInit[num]))
			{
				summariesInit.RemoveAt(num);
			}
		}
		return summariesInit;
	}

	private bool CanFilterBattleLog(GvGMode2BattleReportBattleRecord data)
	{
		LogFilter logFilter = curLogFilterType;
		LogFilter logFilter2 = logFilter;
		if (logFilter2 != LogFilter.Win)
		{
			if (logFilter2 == LogFilter.Fail && ((CurUserId == data.RedUserId && data.Winner == 200) || (CurUserId == data.BlueUserId && data.Winner == 100)))
			{
				goto IL_0084;
			}
		}
		else if ((CurUserId == data.RedUserId && data.Winner == 100) || (CurUserId == data.BlueUserId && data.Winner == 200))
		{
			goto IL_0084;
		}
		return false;
		IL_0084:
		return true;
	}

	private void OpenBattleRecordsDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data == null)
		{
			return;
		}
		currentSummaryIndex = (int)data;
		curLogFilterType = LogFilter.All;
		if (Status.selectedIndex != 1)
		{
			Status.selectedIndex = 1;
		}
		UpdateBattleRecordsDialog();
		SelectedIndex = RecordsDialog.BattleLogList.ItemIndexToChildIndex(currentSummaryIndex);
		for (int i = 0; i < ((GComponent)RecordsDialog.BattleLogList).numChildren; i++)
		{
			UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig = (UI_GvGBattleLogInfoResourcesBig)(object)((GComponent)RecordsDialog.BattleLogList).GetChildAt(i);
			if (uI_GvGBattleLogInfoResourcesBig != null)
			{
				uI_GvGBattleLogInfoResourcesBig.SelectController.selectedIndex = ((i == SelectedIndex) ? 1 : 0);
			}
		}
	}

	private void UpdateBattleRecordsDialog()
	{
		UserIslandEntityBattleRecordSummary summary = battleRecordSummary[currentSummaryIndex];
		Singleton<GvGInstanceZone>.Instance.GetAllBattleRecords(summary, ShowBattleRecordsDialog);
	}

	private void ShowBattleRecordsDialog(List<GvGMode2BattleReportBattleRecord> records)
	{
		UserIslandEntityBattleRecordSummary userIslandEntityBattleRecordSummary = battleRecordSummary[currentSummaryIndex];
		if (userIslandEntityBattleRecordSummary.Records == null || userIslandEntityBattleRecordSummary.Records.Count <= 0)
		{
			userIslandEntityBattleRecordSummary.Records = new List<GvGMode2BattleReportBattleRecord>(records);
		}
		List<GvGMode2BattleReportBattleRecord> summariesInit = new List<GvGMode2BattleReportBattleRecord>(records);
		FilterRankChangeRecords(ref summariesInit);
		ClearLoadAvatarQueue();
		CreateLoadAvatarQueue();
		RenderBattleRecords(summariesInit);
		loadAvatarQueue?.Start();
	}

	private void RenderBattleRecords(List<GvGMode2BattleReportBattleRecord> records)
	{
		RecordDialog.BattleLogList.RemoveChildrenToPool();
		if (records != null && records.Count != 0)
		{
			UI_GvGBattleLogInfoResources uI_GvGBattleLogInfoResources = RecordDialog.BattleLogList.AddItemFromPool() as UI_GvGBattleLogInfoResources;
			((GComponent)uI_GvGBattleLogInfoResources).GetChild("Day").text = RecordDay;
			uI_GvGBattleLogInfoResources.Style.selectedIndex = 1;
			uI_GvGBattleLogInfoResources.SetControllerPageText();
			uI_GvGBattleLogInfoResources.Type.selectedIndex = 0;
			((GObject)uI_GvGBattleLogInfoResources).x = 0f;
			((GObject)uI_GvGBattleLogInfoResources).data = null;
			((GObject)uI_GvGBattleLogInfoResources).onClick.Clear();
			for (int i = 0; i < records.Count; i++)
			{
				UI_GvGBattleLogInfoResources btn = RecordDialog.BattleLogList.AddItemFromPool() as UI_GvGBattleLogInfoResources;
				RenderBattleRecord(records[i], btn);
			}
		}
	}

	private void RenderBattleRecord(GvGMode2BattleReportBattleRecord record, UI_GvGBattleLogInfoResources btn)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		if (record != null && btn != null && !((GObject)btn).isDisposed)
		{
			btn.Style.selectedIndex = 1;
			btn.SetControllerPageText();
			btn.Type.selectedIndex = 1;
			((GObject)btn).x = 0f;
			btn.AttackAndDefense.selectedIndex = ((CurUserId != record.RedUserId) ? 1 : 0);
			bool flag = false;
			if (CurUserId == record.RedUserId && record.Winner == 200)
			{
				flag = true;
			}
			else if (CurUserId == record.BlueUserId && record.Winner == 100)
			{
				flag = true;
			}
			btn.Status.selectedIndex = (flag ? 1 : 0);
			UI_RankingListAvatar myAvatar = btn.MyAvatar;
			GTextField myName = btn.MyName;
			myAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadAvatarQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, CurUserId, myAvatar.AvatarLoader.icon, myName), 0.1f);
			int userId = ((CurUserId == record.RedUserId) ? record.BlueUserId : record.RedUserId);
			UI_RankingListAvatar enemyAvatar = btn.EnemyAvatar;
			GTextField enemyName = btn.EnemyName;
			enemyAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadAvatarQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, enemyAvatar.AvatarLoader.icon, enemyName), 0.1f);
			((GObject)btn).data = record;
			((GObject)btn).onClick.Set(new EventCallback1(OpenBattleRecordDetailPanel));
		}
	}

	private void OpenBattleRecordDetailPanel(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data == null)
		{
			return;
		}
		GvGMode2BattleReportBattleRecord record = data as GvGMode2BattleReportBattleRecord;
		if (record != null)
		{
			Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = delegate(BattleRecordDetail recordRedDetailData, BattleRecordDetail recordBlueDetailData, GetGvGBattleResultResponse recordResultData)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainBattleRecordDetailPanel.Name, new Dictionary<string, object>
				{
					{ "UserInfo", record },
					{ "BattleRecordRedDetail", recordRedDetailData },
					{ "BattleRecordBlueDetail", recordBlueDetailData },
					{ "BattleRecordResultData", recordResultData },
					{ "LevelId", "Eventisland3" },
					{ "IsInZone", isInZone }
				});
			};
			if (ReplayDetialCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(ReplayDetialCoroutine);
				ReplayDetialCoroutine = null;
			}
			ReplayDetialCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.DownloadGvG2ZipReplay(record.BattleId, action));
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
