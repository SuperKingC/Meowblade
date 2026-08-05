using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideGroupReportPanel : GComponent, IUiController
{
	private class FlatBattleRecordEntry
	{
		public int Rank;

		public float WinRate;

		public int UserId;

		public int Score;

		public int PlayerOffScore;
	}

	public GGraph mask;

	public UI_ServerWideGroupReportDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5hrekjdue";

	public static string Name = "UI_ServerWideGroupReportPanel";

	public const string ParamKeyStageStatus = "StageStatus";

	public const string ParamKeyGroupId = "GroupId";

	public const string ParamKeyActivityId = "ActivityId";

	private int _stageStatus;

	private int _groupId;

	private string _activityId;

	private List<WarOfRealmGroupBattleRecordGroup> _groupBattleRecords;

	private Dictionary<string, List<RankChangeRecord>> _stageUserBattleRecord;

	private List<FlatBattleRecordEntry> _flatList;

	private Dictionary<int, int> _userIdToRoundScore;

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdue";
	}

	public static UI_ServerWideGroupReportPanel CreateInstance()
	{
		return (UI_ServerWideGroupReportPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideGroupReportPanel");
	}

	public static UI_ServerWideGroupReportPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideGroupReportPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdue", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ServerWideGroupReportDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters != null)
		{
			if (parameters.ContainsKey("StageStatus"))
			{
				_stageStatus = (int)parameters["StageStatus"];
			}
			if (parameters.ContainsKey("GroupId"))
			{
				_groupId = (int)parameters["GroupId"];
			}
			if (parameters.ContainsKey("ActivityId"))
			{
				_activityId = parameters["ActivityId"] as string;
			}
		}
		if (string.IsNullOrEmpty(_activityId) && RankDataHelper.AllServersChampionshipInfo != null)
		{
			_activityId = RankDataHelper.AllServersChampionshipInfo.ActivityId;
		}
		if (_stageStatus <= 0 && RankDataHelper.AllServersChampionshipInfo?.WarRankDataInfo != null)
		{
			_stageStatus = RankDataHelper.AllServersChampionshipInfo.WarRankDataInfo.StageStatus;
		}
		((GObject)Dialog.BattleGroupTitle.title).text = GetStageGroupTitle();
		LoadGroupBattleRecords();
		popup.Play();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
		Dialog.List.onClickItem.Add(new EventCallback1(OnListItemClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
		Dialog.List.onClickItem.Clear();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void LoadGroupBattleRecords()
	{
		_stageUserBattleRecord = null;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryLoadGroupFromCDN());
	}

	private IEnumerator TryLoadGroupFromCDN()
	{
		yield return RankDataHelper.TryLoadGroupResultFromCDN(_activityId, _stageStatus, _groupId, delegate(WarOfRealmGroupResultReport report)
		{
			if (report?.StageGroupBattleRecord != null)
			{
				_groupBattleRecords = ConvertDictToGroupRecords(report.StageGroupBattleRecord);
				_stageUserBattleRecord = report.StageUserBattleRecord;
				BuildFlatList();
				RenderGroupBattleList();
			}
			else
			{
				LoadFromAPI();
			}
		});
	}

	private List<WarOfRealmGroupBattleRecordGroup> ConvertDictToGroupRecords(Dictionary<string, List<WarOfRealmPersonalBattleRecord>> dict)
	{
		if (dict == null || dict.Count == 0)
		{
			return new List<WarOfRealmGroupBattleRecordGroup>();
		}
		List<WarOfRealmGroupBattleRecordGroup> list = new List<WarOfRealmGroupBattleRecordGroup>();
		foreach (KeyValuePair<string, List<WarOfRealmPersonalBattleRecord>> item in dict)
		{
			if (float.TryParse(item.Key, out var result))
			{
				list.Add(new WarOfRealmGroupBattleRecordGroup
				{
					WinRate = result,
					Records = item.Value
				});
			}
		}
		return list;
	}

	private void LoadFromAPI()
	{
		ILRequestHelper<WarOfRealmGetStageBattleRecordResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().GetWarOfRealmStageBattleRecord(_groupId, _stageStatus), delegate(WarOfRealmGetStageBattleRecordResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRuntimeDebug.LogError($"获取分组战报失败, ErrorCode={response.ErrorCode}");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				End();
			}
			else
			{
				_groupBattleRecords = response.GetGroupBattleRecord;
				_stageUserBattleRecord = null;
				BuildFlatList();
				RenderGroupBattleList();
			}
		}, 1f);
	}

	private void BuildFlatList()
	{
		_flatList = new List<FlatBattleRecordEntry>();
		if (_groupBattleRecords == null || _groupBattleRecords.Count == 0)
		{
			return;
		}
		LoadSettlementScores();
		List<WarOfRealmGroupBattleRecordGroup> list = _groupBattleRecords.OrderByDescending((WarOfRealmGroupBattleRecordGroup g) => g.WinRate).ToList();
		int num = 0;
		foreach (WarOfRealmGroupBattleRecordGroup item in list)
		{
			List<WarOfRealmPersonalBattleRecord> list2 = item.Records.OrderByDescending((WarOfRealmPersonalBattleRecord p) => p.Score + p.PlayerOffScore).ToList();
			foreach (WarOfRealmPersonalBattleRecord item2 in list2)
			{
				num++;
				_flatList.Add(new FlatBattleRecordEntry
				{
					Rank = num,
					WinRate = item.WinRate,
					UserId = item2.UserId,
					Score = item2.Score,
					PlayerOffScore = item2.PlayerOffScore
				});
			}
		}
	}

	private void LoadSettlementScores()
	{
		_userIdToRoundScore = new Dictionary<int, int>();
		StageStatus stageStatus = (StageStatus)_stageStatus;
		if (RankDataHelper.AllServersChampionshipInfo?.MatchInfoDict == null || !RankDataHelper.AllServersChampionshipInfo.MatchInfoDict.TryGetValue(stageStatus, out var value) || value?.SettlementInfoList == null || !value.SettlementInfoList.TryGetValue(_groupId, out var value2))
		{
			return;
		}
		foreach (WarRankData item in value2)
		{
			_userIdToRoundScore[item.UserId] = item.Score;
		}
	}

	private void RenderGroupBattleList()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (_flatList == null || _flatList.Count == 0)
		{
			Dialog.List.numItems = 0;
			return;
		}
		Dialog.List.SetVirtual();
		Dialog.List.itemRenderer = new ListItemRenderer(GroupBattleListItemRenderer);
		Dialog.List.numItems = _flatList.Count;
	}

	private void GroupBattleListItemRenderer(int index, GObject gObject)
	{
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		UI_GroupReportListItem item = gObject as UI_GroupReportListItem;
		if (item == null || _flatList == null || index >= _flatList.Count)
		{
			return;
		}
		FlatBattleRecordEntry entry = _flatList[index];
		((GObject)item.title).text = $"{entry.Rank}";
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, entry.UserId, item.PlayerAvatar.HeadPortrait.PlayerIcon, item.PlayerName));
		((GObject)item.PlayerName).text = $"{entry.UserId}";
		FGUIManager.Instance.GetUserMedal(entry.UserId, item.MedalList, item.HasMedal);
		((GObject)item.GroupScore).text = $"{entry.Score + entry.PlayerOffScore}";
		((GObject)item.Rate).text = $"{entry.WinRate * 100f:F1}%";
		if (entry.PlayerOffScore > 0)
		{
			item.ShowTipBtn.selectedIndex = 1;
			((GObject)item.SimpleTipBtn).onClick.Set((EventCallback0)delegate
			{
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0034: Unknown result type (might be due to invalid IL or missing references)
				FairyGUITip.ShowTip((GObject)(object)item.SimpleTipBtn, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip tip)
				{
					((GObject)tip.title).text = string.Format(LanguagesManager.GetDesc("ServerWideGroupReportTip1"), entry.PlayerOffScore);
				});
			});
		}
		else
		{
			item.ShowTipBtn.selectedIndex = 0;
			((GObject)item.SimpleTipBtn).onClick.Clear();
		}
		_userIdToRoundScore.TryGetValue(entry.UserId, out var value);
		((GObject)item.RoundScore).text = $"{value}";
		((GObject)item.BattleReportBtn).onClick.Set((EventCallback0)delegate
		{
			OnPlayerBattleReportClick(entry.UserId);
		});
	}

	private void OnListItemClick(EventContext context)
	{
	}

	private void OnPlayerBattleReportClick(int userId)
	{
		if (_stageUserBattleRecord != null && _stageUserBattleRecord.TryGetValue(userId.ToString(), out var value))
		{
			ShowPlayerBattleRecords(userId, value);
		}
		else
		{
			if (string.IsNullOrEmpty(_activityId))
			{
				return;
			}
			ILRequestHelper<WarOfRealmGetWarBattleRecordResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().GetWarOfRealmWarBattleRecord(_stageStatus, userId), delegate(WarOfRealmGetWarBattleRecordResponse response)
			{
				if (response == null)
				{
					ILRuntimeDebug.LogError("获取玩家战报失败：响应为空");
					ILRequestHelper.ShowMessage("获取战报失败，请稍后重试");
				}
				else if (response.ErrorCode != 0)
				{
					ILRuntimeDebug.LogError($"获取玩家战报失败, ErrorCode={response.ErrorCode}");
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					ShowPlayerBattleRecords(userId, response.GetBattleRecordsList);
				}
			}, 1f);
		}
	}

	private void ShowPlayerBattleRecords(int userId, List<RankChangeRecord> battleRecords)
	{
		if (battleRecords != null && battleRecords.Count != 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideBattleLogPanel.Name, new Dictionary<string, object>
			{
				{ "UserId", userId },
				{ "BattleRecords", battleRecords }
			});
		}
	}

	private string GetStageGroupTitle()
	{
		return RankDataHelper.GetStageGroupTitle((StageStatus)_stageStatus, _groupId);
	}
}
