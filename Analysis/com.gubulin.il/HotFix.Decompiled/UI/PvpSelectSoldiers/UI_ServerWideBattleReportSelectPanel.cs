using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBattleReportSelectPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_ServerWideBattleReportSelectDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5rnlpjdtx";

	public static string Name = "UI_ServerWideBattleReportSelectPanel";

	public const string ParamKeyActivityId = "ActivityId";

	public const string ParamKeyStageStatus = "StageStatus";

	public const string ParamKeyGroupIndex = "GroupIndex";

	private string _activityId;

	private StageStatus _stageStatus;

	private int _groupIndex;

	private List<int> _groupPlayerIds;

	private string _rewardItemId;

	private int _rewardAmount;

	private float _winRate;

	private float _lossRate;

	private int _bonusValue;

	private HashSet<int> _bingoPlayerIds;

	private HashSet<int> _winPlayerIds;

	private HashSet<int> _lossPlayerIds;

	private Dictionary<string, List<RankChangeRecord>> _stageUserBattleRecord;

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtx";
	}

	public static UI_ServerWideBattleReportSelectPanel CreateInstance()
	{
		return (UI_ServerWideBattleReportSelectPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBattleReportSelectPanel");
	}

	public static UI_ServerWideBattleReportSelectPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBattleReportSelectPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ServerWideBattleReportSelectDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.ContainsKey("ActivityId"))
		{
			_activityId = parameters["ActivityId"] as string;
		}
		if (parameters.ContainsKey("StageStatus"))
		{
			_stageStatus = (StageStatus)parameters["StageStatus"];
		}
		if (parameters.ContainsKey("GroupIndex"))
		{
			_groupIndex = (int)parameters["GroupIndex"];
		}
		if (string.IsNullOrEmpty(_activityId) && RankDataHelper.AllServersChampionshipInfo != null)
		{
			_activityId = RankDataHelper.AllServersChampionshipInfo.ActivityId;
		}
		((GObject)Dialog.BattleGroupTitle.title).text = GetStageGroupTitle();
		LoadLotteryConfig();
		LoadGroupDataAndReward();
		popup.Play();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Dialog.ExitButton).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(OnConfirmClick));
		Dialog.PlayerBetList1.onClickItem.Add(new EventCallback1(OnPlayerBetListItemClick));
		Dialog.PlayerBetList2.onClickItem.Add(new EventCallback1(OnPlayerBetListItemClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ExitButton).onClick.Clear();
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		Dialog.PlayerBetList1.onClickItem.Clear();
		Dialog.PlayerBetList2.onClickItem.Clear();
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

	private async void LoadGroupDataAndReward()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RankDataHelper.TryLoadGroupResultFromCDN(_activityId, (int)_stageStatus, _groupIndex, delegate(WarOfRealmGroupResultReport report)
		{
			if (report?.StageUserBattleRecord != null)
			{
				_stageUserBattleRecord = report.StageUserBattleRecord;
			}
		}));
		MatchInfo matchInfo = await RankDataHelper.GetMatchGroupInfo(_activityId, _stageStatus);
		if (matchInfo?.WarGroupPlayers != null && matchInfo.WarGroupPlayers.TryGetValue(_groupIndex, out var playerIds))
		{
			_groupPlayerIds = playerIds;
		}
		else
		{
			_groupPlayerIds = new List<int>();
		}
		_rewardAmount = 0;
		LotteryInfo lotteryInfo = await RankDataHelper.GetLotteryGroupInfo(_activityId, _stageStatus);
		if (lotteryInfo?.WarGroupLotteried != null)
		{
			WarGroupLottery groupLottery = lotteryInfo.WarGroupLotteried.FirstOrDefault((WarGroupLottery g) => g.GroupIndex == _groupIndex);
			if (groupLottery?.WarLotteries != null && _bonusValue > 0)
			{
				List<int> winUserIds = groupLottery.WinUserId ?? new List<int>();
				foreach (WarLottery lottery in groupLottery.WarLotteries)
				{
					if (lottery.Amount > 0)
					{
						float rate = (winUserIds.Contains(lottery.UserId) ? _winRate : _lossRate);
						_rewardAmount += (int)((float)lottery.Amount * rate * (float)_bonusValue);
					}
				}
			}
		}
		ExtractSettlementData(matchInfo, lotteryInfo);
		RenderPlayerBetList();
		UpdateRewardDisplay();
	}

	private void LoadLotteryConfig()
	{
		WarOfRealmLotteryConfigEntry matchedLotteryConfig = RankDataHelper.GetMatchedLotteryConfig(_stageStatus);
		if (matchedLotteryConfig?.Bonus != null && matchedLotteryConfig.Bonus.Count > 0)
		{
			KeyValuePair<string, int> keyValuePair = matchedLotteryConfig.Bonus.First();
			_rewardItemId = keyValuePair.Key;
			_bonusValue = keyValuePair.Value;
		}
		else
		{
			_rewardItemId = null;
			_bonusValue = 0;
		}
		_winRate = matchedLotteryConfig?.WinRate ?? 0f;
		_lossRate = matchedLotteryConfig?.LossRate ?? 0f;
	}

	private void UpdateRewardDisplay()
	{
		if (!string.IsNullOrEmpty(_rewardItemId))
		{
			Dialog.BetRewardCountLabel.RewardItemIcon.url = UiHelper.GetItemIconPath(_rewardItemId);
			((GObject)Dialog.BetRewardCountLabel.CountText).text = $"x{_rewardAmount}";
		}
	}

	private void ExtractSettlementData(MatchInfo matchInfo, LotteryInfo lotteryInfo)
	{
		_bingoPlayerIds = new HashSet<int>();
		_winPlayerIds = new HashSet<int>();
		_lossPlayerIds = new HashSet<int>();
		int advanceCutoffRank = GetAdvanceCutoffRank(_stageStatus);
		if (advanceCutoffRank > 0 && matchInfo?.SettlementInfoList != null && matchInfo.SettlementInfoList.TryGetValue(_groupIndex, out var value) && value != null)
		{
			foreach (WarRankData item in value)
			{
				if (item.Rank >= 1 && item.Rank <= advanceCutoffRank)
				{
					_winPlayerIds.Add(item.UserId);
				}
				else
				{
					_lossPlayerIds.Add(item.UserId);
				}
			}
		}
		HashSet<int> hashSet = new HashSet<int>();
		if (lotteryInfo?.WarGroupLotteried != null)
		{
			foreach (WarGroupLottery item2 in lotteryInfo.WarGroupLotteried)
			{
				if (item2.GroupIndex != _groupIndex || item2.WarLotteries == null)
				{
					continue;
				}
				foreach (WarLottery warLottery in item2.WarLotteries)
				{
					if (warLottery.Amount > 0)
					{
						hashSet.Add(warLottery.UserId);
					}
				}
				break;
			}
		}
		foreach (int winPlayerId in _winPlayerIds)
		{
			if (hashSet.Contains(winPlayerId))
			{
				_bingoPlayerIds.Add(winPlayerId);
			}
		}
	}

	private static int GetAdvanceCutoffRank(StageStatus status)
	{
		switch (status)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round1_Stage64:
		case StageStatus.Round1_Stage32:
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage128:
		case StageStatus.Round2_Stage64:
		case StageStatus.Round2_Stage32:
		case StageStatus.Round2_Stage16:
			return 4;
		case StageStatus.Round1_Stage8FirstRound:
		case StageStatus.Round2_Stage8FirstRound:
			return 6;
		case StageStatus.Round1_Stage8SecondRound:
		case StageStatus.Round2_Stage8SecondRound:
			return 4;
		case StageStatus.Round1_SemiFinal:
		case StageStatus.Round2_SemiFinal:
			return 2;
		case StageStatus.Round1_Final:
		case StageStatus.Round2_Final:
			return 1;
		default:
			return 0;
		}
	}

	private void RenderPlayerBetList()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		if (_groupPlayerIds == null || _groupPlayerIds.Count == 0)
		{
			Dialog.PlayerBetList1.numItems = 0;
			Dialog.PlayerBetList2.numItems = 0;
			return;
		}
		int count = _groupPlayerIds.Count;
		if (count <= 2)
		{
			Dialog.ListCount.selectedIndex = 1;
			Dialog.PlayerBetList2.itemRenderer = new ListItemRenderer(PlayerBetListRenderer);
			Dialog.PlayerBetList2.numItems = count;
			Dialog.PlayerBetList1.numItems = 0;
		}
		else
		{
			Dialog.ListCount.selectedIndex = 0;
			Dialog.PlayerBetList1.itemRenderer = new ListItemRenderer(PlayerBetListRenderer);
			Dialog.PlayerBetList1.numItems = count;
			Dialog.PlayerBetList2.numItems = 0;
		}
	}

	private void PlayerBetListRenderer(int index, GObject gObject)
	{
		if (_groupPlayerIds != null && index < _groupPlayerIds.Count)
		{
			int num = _groupPlayerIds[index];
			if (gObject is UI_btn_PlayerBetAndReport uI_btn_PlayerBetAndReport)
			{
				((GObject)uI_btn_PlayerBetAndReport.PlayerName).text = $"{num}";
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, num, uI_btn_PlayerBetAndReport.PlayerAvatar.HeadPortrait.PlayerIcon, uI_btn_PlayerBetAndReport.PlayerName));
				uI_btn_PlayerBetAndReport.Usage.selectedIndex = 0;
				bool flag = _bingoPlayerIds != null && _bingoPlayerIds.Contains(num);
				bool grayed = _lossPlayerIds != null && _lossPlayerIds.Contains(num);
				uI_btn_PlayerBetAndReport.IsBingo.selectedIndex = (flag ? 1 : 0);
				((GObject)uI_btn_PlayerBetAndReport).grayed = grayed;
			}
		}
	}

	private void OnPlayerBetListItemClick(EventContext context)
	{
		object data = context.data;
		GObject val = (GObject)((data is GObject) ? data : null);
		if (val == null)
		{
			return;
		}
		if (_groupPlayerIds == null || _groupPlayerIds.Count == 0)
		{
			ILRuntimeDebug.LogError("[BattleReportSelect] _groupPlayerIds 为空，无法响应点击");
			return;
		}
		int childIndex = ((GComponent)Dialog.PlayerBetList1).GetChildIndex(val);
		if (childIndex < 0)
		{
			childIndex = ((GComponent)Dialog.PlayerBetList2).GetChildIndex(val);
		}
		if (childIndex < 0 || childIndex >= _groupPlayerIds.Count)
		{
			return;
		}
		int userId = _groupPlayerIds[childIndex];
		if (!string.IsNullOrEmpty(_activityId))
		{
			if (_stageUserBattleRecord != null && _stageUserBattleRecord.TryGetValue(userId.ToString(), out var value))
			{
				ShowPlayerBattleRecords(userId, value);
			}
			else
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryLoadPlayerRecordsFromCDN(userId));
			}
		}
	}

	private IEnumerator TryLoadPlayerRecordsFromCDN(int userId)
	{
		bool gotFromCDN = false;
		List<RankChangeRecord> records = null;
		yield return RankDataHelper.TryLoadGroupResultFromCDN(_activityId, (int)_stageStatus, _groupIndex, delegate(WarOfRealmGroupResultReport report)
		{
			if (report?.StageUserBattleRecord != null)
			{
				_stageUserBattleRecord = report.StageUserBattleRecord;
				if (_stageUserBattleRecord.TryGetValue(userId.ToString(), out records))
				{
					gotFromCDN = true;
				}
			}
		});
		if (gotFromCDN && records != null)
		{
			ShowPlayerBattleRecords(userId, records);
		}
		else
		{
			LoadPlayerRecordsFromAPI(userId);
		}
	}

	private void LoadPlayerRecordsFromAPI(int userId)
	{
		ILRequestHelper<WarOfRealmGetWarBattleRecordResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().GetWarOfRealmWarBattleRecord((int)_stageStatus, userId), delegate(WarOfRealmGetWarBattleRecordResponse response)
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

	private void OnConfirmClick()
	{
		OpenGroupReportPanel();
	}

	private void OpenGroupReportPanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			["StageStatus"] = (int)_stageStatus,
			["GroupId"] = _groupIndex,
			["ActivityId"] = _activityId ?? ""
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideGroupReportPanel.Name, parameters);
	}

	private string GetStageGroupTitle()
	{
		return RankDataHelper.GetStageGroupTitle(_stageStatus, _groupIndex);
	}
}
