using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Battle;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBattleLogPanel : GComponent, IUiController
{
	private class StageTabGroup
	{
		public string DisplayName;

		public List<int> StageKeys;
	}

	private enum LogFilter
	{
		All,
		Win,
		Fail
	}

	public class BattleLogUserInfo
	{
		public int RedUserId;

		public bool RedIsUser;

		public string RedNpcUrl;

		public bool BlueIsUser;

		public string BlueNpcUrl;

		public int BlueUserId;

		public string BattleId;
	}

	public GGraph Mask;

	public UI_ServerWideBattleLogDialog Dialog;

	public const string URL = "ui://82mo10n5m5cgjdv3";

	public static string Name = "UI_ServerWideBattleLogPanel";

	public const string ParamKeyUserId = "UserId";

	public const string ParamKeyBattleRecords = "BattleRecords";

	public const string ParamKeyBattleRecordGroups = "BattleRecordGroups";

	private int _userId;

	private List<RankChangeRecord> _battleRecords;

	private Dictionary<int, List<RankChangeRecord>> _battleRecordGroups;

	private List<StageTabGroup> _tabGroups;

	public const string StateKeySelectedTabIndex = "SelectedTabIndex";

	private int _selectedTabIndex = 0;

	private int _retryTimes = 0;

	private int _totalDownloadCnt = 0;

	private Coroutine _downloadReplayDataCoroutine;

	private LogFilter _curLogFilterType;

	private readonly List<UI_LogFilterBtn> _logFilters = new List<UI_LogFilterBtn>(2);

	public static string GetURL()
	{
		return "ui://82mo10n5m5cgjdv3";
	}

	public static UI_ServerWideBattleLogPanel CreateInstance()
	{
		return (UI_ServerWideBattleLogPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBattleLogPanel");
	}

	public static UI_ServerWideBattleLogPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBattleLogPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5m5cgjdv3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ServerWideBattleLogDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener("BACKUP_PANEL_EXTRA_STATE", OnBackupPanelExtraState);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener("BACKUP_PANEL_EXTRA_STATE", OnBackupPanelExtraState);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters != null)
		{
			if (parameters.TryGetValue("UserId", out var value))
			{
				_userId = (int)value;
			}
			if (parameters.TryGetValue("BattleRecords", out var value2))
			{
				_battleRecords = value2 as List<RankChangeRecord>;
			}
			if (parameters.TryGetValue("BattleRecordGroups", out var value3))
			{
				_battleRecordGroups = value3 as Dictionary<int, List<RankChangeRecord>>;
			}
		}
		if (_battleRecordGroups != null && _battleRecordGroups.Count > 0)
		{
			InitRoundTabs();
			((GObject)Dialog.RoundTabList).visible = true;
		}
		else
		{
			((GObject)Dialog.RoundTabList).visible = false;
		}
		if (parameters != null && parameters.TryGetValue("SelectedTabIndex", out var value4))
		{
			_selectedTabIndex = (int)value4;
		}
		FilterInit();
		RenderAll();
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

	private Dictionary<string, object> GetCurrentState()
	{
		return new Dictionary<string, object> { { "SelectedTabIndex", _selectedTabIndex } };
	}

	private void OnBackupPanelExtraState()
	{
		RankDataHelper.SetPanelExtraState(Name, GetCurrentState());
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void FilterInit()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		_logFilters.Add(Dialog.Filter.Win);
		_logFilters.Add(Dialog.Filter.Fail);
		for (int i = 0; i < _logFilters.Count; i++)
		{
			UI_LogFilterBtn uI_LogFilterBtn = _logFilters[i];
			((GButton)uI_LogFilterBtn).selected = false;
			if (i == 0)
			{
				((GObject)uI_LogFilterBtn).data = 1;
			}
			if (i == 1)
			{
				((GObject)uI_LogFilterBtn).data = 2;
			}
			((GObject)uI_LogFilterBtn).onClick.Set(new EventCallback1(ChangeFilter));
		}
		_curLogFilterType = LogFilter.All;
	}

	private void ChangeFilter(EventContext context)
	{
		UI_LogFilterBtn uI_LogFilterBtn = (UI_LogFilterBtn)(object)context.sender;
		if (((GObject)uI_LogFilterBtn).data != null)
		{
			if (uI_LogFilterBtn.Checked.selectedIndex == 1)
			{
				ChangeLogFilter(LogFilter.All);
				RenderBattleLogList();
			}
			else
			{
				ChangeLogFilter((LogFilter)(int)((GObject)uI_LogFilterBtn).data);
				RenderBattleLogList();
			}
		}
	}

	private void ChangeLogFilter(LogFilter type)
	{
		_curLogFilterType = type;
		if (_curLogFilterType == LogFilter.All)
		{
			foreach (UI_LogFilterBtn logFilter2 in _logFilters)
			{
				logFilter2.Checked.SetSelectedIndex(0);
			}
			return;
		}
		foreach (UI_LogFilterBtn logFilter3 in _logFilters)
		{
			LogFilter logFilter = (LogFilter)(int)((GObject)logFilter3).data;
			logFilter3.Checked.SetSelectedIndex((logFilter == _curLogFilterType) ? 1 : 0);
		}
	}

	private bool CanFilterBattleLog(RankChangeRecord data)
	{
		if (_curLogFilterType == LogFilter.Win && data.ChallengerId == _userId && data.Winner == 100)
		{
			return true;
		}
		if (_curLogFilterType == LogFilter.Win && data.HostId == _userId && data.Winner == 200)
		{
			return true;
		}
		if (_curLogFilterType == LogFilter.Fail && data.ChallengerId == _userId && data.Winner == 200)
		{
			return true;
		}
		if (_curLogFilterType == LogFilter.Fail && data.HostId == _userId && data.Winner == 100)
		{
			return true;
		}
		return false;
	}

	private void InitRoundTabs()
	{
		List<int> list = new List<int>(_battleRecordGroups.Keys);
		for (int i = 0; i < list.Count - 1; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				if (list[i] < list[j])
				{
					int value = list[i];
					list[i] = list[j];
					list[j] = value;
				}
			}
		}
		_tabGroups = new List<StageTabGroup>();
		for (int k = 0; k < list.Count; k++)
		{
			int num = list[k];
			string stageTitle = RankDataHelper.GetStageTitle((StageStatus)num);
			if (_tabGroups.Count > 0 && _tabGroups[_tabGroups.Count - 1].DisplayName == stageTitle)
			{
				_tabGroups[_tabGroups.Count - 1].StageKeys.Add(num);
				continue;
			}
			_tabGroups.Add(new StageTabGroup
			{
				DisplayName = stageTitle,
				StageKeys = new List<int> { num }
			});
		}
		_selectedTabIndex = 0;
	}

	private void RenderRoundTabs()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		GList roundTabList = Dialog.RoundTabList;
		roundTabList.itemRenderer = new ListItemRenderer(RenderRoundTabItem);
		roundTabList.numItems = _tabGroups.Count;
	}

	private void RenderRoundTabItem(int index, GObject gObject)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		if (gObject is UI_btn_PeakBattleTab uI_btn_PeakBattleTab)
		{
			StageTabGroup stageTabGroup = _tabGroups[index];
			((GObject)uI_btn_PeakBattleTab.title).text = stageTabGroup.DisplayName;
			((GObject)uI_btn_PeakBattleTab).data = index;
			((GObject)uI_btn_PeakBattleTab).onClick.Set(new EventCallback1(OnRoundTabClick));
			uI_btn_PeakBattleTab.button.selectedIndex = ((index == _selectedTabIndex) ? 1 : 0);
		}
	}

	private void OnRoundTabClick(EventContext context)
	{
		if (context.sender is UI_btn_PeakBattleTab { data: not null } uI_btn_PeakBattleTab)
		{
			int selectedTabIndex = (int)((GObject)uI_btn_PeakBattleTab).data;
			_selectedTabIndex = selectedTabIndex;
			RenderAll();
		}
	}

	private void RenderAll()
	{
		if (_battleRecordGroups != null && _battleRecordGroups.Count > 0)
		{
			RenderRoundTabs();
		}
		RenderBattleLogList();
	}

	private void RenderBattleLogList()
	{
		GList battleLogList = Dialog.BattleLogList;
		battleLogList.RemoveChildrenToPool();
		List<RankChangeRecord> list;
		if (_battleRecordGroups != null && _battleRecordGroups.Count > 0)
		{
			StageTabGroup stageTabGroup = _tabGroups[_selectedTabIndex];
			list = new List<RankChangeRecord>();
			foreach (int stageKey in stageTabGroup.StageKeys)
			{
				if (_battleRecordGroups.TryGetValue(stageKey, out var value) && value != null)
				{
					list.AddRange(value);
				}
			}
		}
		else
		{
			list = _battleRecords;
		}
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			RankChangeRecord rankChangeRecord = list[i];
			if ((rankChangeRecord.ChallengerId == _userId || rankChangeRecord.HostId == _userId) && !CanFilterBattleLog(rankChangeRecord))
			{
				RenderOneRecord(rankChangeRecord);
			}
		}
	}

	private void RenderOneRecord(RankChangeRecord data)
	{
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		if (((GObject)this).isDisposed || ((GObject)Dialog).isDisposed)
		{
			return;
		}
		bool flag = data.ChallengerId == _userId;
		bool flag2 = data.HostId == _userId;
		int userId = _userId;
		int userId2 = (flag ? data.HostId : data.ChallengerId);
		int selectedIndex = (flag ? 1 : 0);
		int selectedIndex2 = (((!flag) ? (data.Winner == 100) : (data.Winner == 200)) ? 1 : 0);
		GList battleLogList = Dialog.BattleLogList;
		if (battleLogList.AddItemFromPool() is UI_PvpBattleLogInfoResources uI_PvpBattleLogInfoResources)
		{
			uI_PvpBattleLogInfoResources.Type.selectedIndex = 1;
			uI_PvpBattleLogInfoResources.Status.selectedIndex = selectedIndex2;
			uI_PvpBattleLogInfoResources.AttackAndDefense.selectedIndex = selectedIndex;
			((GObject)uI_PvpBattleLogInfoResources.MyRank).visible = false;
			((GObject)uI_PvpBattleLogInfoResources.EnemyRank).visible = false;
			((GObject)uI_PvpBattleLogInfoResources.RedUserHpBar).visible = false;
			((GObject)uI_PvpBattleLogInfoResources.BlueUserHpBar).visible = false;
			uI_PvpBattleLogInfoResources.isShowMedalLeft.selectedIndex = 0;
			uI_PvpBattleLogInfoResources.isShowMedalRight.selectedIndex = 0;
			UI_ShowLevelChange levelChangeContent = uI_PvpBattleLogInfoResources.LevelChangeContent;
			if (levelChangeContent != null)
			{
				((GObject)levelChangeContent).visible = false;
			}
			uI_PvpBattleLogInfoResources.Attaches.selectedIndex = 0;
			LoadAvatarAndName(userId, uI_PvpBattleLogInfoResources.MyAvatar, uI_PvpBattleLogInfoResources.MyName);
			LoadAvatarAndName(userId2, uI_PvpBattleLogInfoResources.EnemyAvatar, uI_PvpBattleLogInfoResources.EnemyName);
			BattleLogUserInfo logInfo = new BattleLogUserInfo
			{
				RedUserId = data.ChallengerId,
				BlueUserId = data.HostId,
				BattleId = data.BattleId,
				RedIsUser = (data.ChallengerId > 0),
				BlueIsUser = (data.HostId > 0)
			};
			((GObject)uI_PvpBattleLogInfoResources.PlayBtn).data = logInfo;
			((GObject)uI_PvpBattleLogInfoResources.PlayBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickPlayBtn(logInfo);
			});
		}
	}

	private void LoadAvatarAndName(int userId, UI_RankingListAvatar avatar, GTextField nameText)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (userId <= 0)
		{
			avatar.Update(isUser: false);
			((GObject)nameText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			nameText.color = Color32.op_Implicit(new Color32((byte)60, (byte)179, (byte)113, byte.MaxValue));
		}
		else
		{
			avatar.Update(isUser: true);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, userId, avatar.HeadPortrait.icon, nameText));
		}
	}

	private async void OnClickPlayBtn(BattleLogUserInfo logInfo)
	{
		WarOfRealmReplayResponse replayResponse = await GameController.Contexts.Service<INetworkService>().WarOfRealmReplay(logInfo.BattleId);
		if (replayResponse == null || replayResponse.ErrorCode != 0 || replayResponse.Replay == null)
		{
			ILRequestHelper.ShowErrorCode(replayResponse?.ErrorCode ?? 0);
			return;
		}
		LevelBattleReplay replayData = replayResponse.Replay;
		BattleRecordDetail detail = replayData.Detail;
		if (detail == null || detail.PvP_ReplaySegments == null || detail.PvP_ReplaySegments.Count == 0)
		{
			ILRuntimeDebug.LogError("录像详情或分段信息为空");
			return;
		}
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo
		{
			UserId = logInfo.BlueUserId,
			IsUser = logInfo.BlueIsUser,
			NpcUrl = logInfo.BlueNpcUrl
		};
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			UserId = logInfo.RedUserId,
			IsUser = logInfo.RedIsUser,
			NpcUrl = logInfo.RedNpcUrl
		};
		GameLocalDataManager.SetLastReplayUserInfo(replayData.Nickname, replayData.Avatar);
		List<string> file_names = new List<string> { "ret.bin" };
		for (int idx = 0; idx < detail.PvP_ReplaySegments.Count; idx++)
		{
			for (int i = idx * 10000; i < detail.PvP_ReplaySegments[idx]; i++)
			{
				file_names.Add(i.ToString());
			}
		}
		RankDataHelper.info = new RankBattleInfo(replayData.BattleId);
		RankDataHelper.info.RealLegionSize = detail.PvP_ReplaySegments.Count;
		RankDataHelper.info.NeedLegionSize = detail.PvP_ReplaySegments.Count;
		RankDataHelper.UpdateRankBattleReplayResult(replayData.BattleId, replayData.Result, new Dictionary<Team, BattleResultStats>());
		_totalDownloadCnt = file_names.Count;
		RankDataHelper.BackupOpenPanelsForReplay();
		GameController.Contexts.Service<INetworkService>().InformWatchingReplay(logInfo.BattleId);
		GameManagers.Instance.Messenger.Broadcast("WATCHING_REPLAY");
		_retryTimes = 0;
		if (_downloadReplayDataCoroutine == null)
		{
			_downloadReplayDataCoroutine = FGUIManager.Instance.OpenIEnumerator(DownloadReplayData(replayData, file_names));
		}
	}

	public IEnumerator DownloadReplayData(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(replay.BattleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return PlayBattleReplay(replay, queue);
		_downloadReplayDataCoroutine = null;
	}

	public IEnumerator PlayBattleReplay(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		if (queue.Count == 0)
		{
			yield break;
		}
		if (string.IsNullOrEmpty(downloading))
		{
			downloading = queue[0];
			queue.RemoveAt(0);
		}
		ReplayDownloadManager.DownloadReplay(replay.BattleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (_retryTimes > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					_retryTimes++;
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, queue, downloading, 0.2f));
				}
			}
			else
			{
				_retryTimes = 0;
				float num = 1f * (float)(_totalDownloadCnt - queue.Count) / (float)_totalDownloadCnt;
				float barValue = num * 35f + 65f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue);
				if (queue.Count == 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
					{
						BattleId = replay.BattleId,
						TargetFrame = replay.ReplayFrames - 1,
						LevelId = replay.LevelId,
						LocalSource = true,
						ReplayMode = 3,
						MaskDuration = 0
					};
					GameLocalDataManager.SetLastReplay(playBattleReplayData);
					GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
				}
				else
				{
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, queue));
				}
			}
		});
	}
}
