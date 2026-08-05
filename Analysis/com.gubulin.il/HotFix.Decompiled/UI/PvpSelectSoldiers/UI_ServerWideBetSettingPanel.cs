using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBetSettingPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_ServerWideBetSettingDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5rnlpjdtl";

	public static string Name = "UI_ServerWideBetSettingPanel";

	public const string ParamKeyActivityId = "ActivityId";

	public const string ParamKeyStageStatus = "StageStatus";

	public const string ParamKeyGroupIndex = "GroupIndex";

	private List<int> _groupPlayerIds;

	private Dictionary<int, int> _betDict = new Dictionary<int, int>();

	private int _originalTotalBets;

	private int _selectedUserId;

	private int _selectedBetAmount;

	private string _activityId;

	private StageStatus _stageStatus;

	private int _groupIndex;

	private List<int> _betAmountOptions;

	private string _lotteryTokenItemId;

	private Dictionary<string, int> _bonus;

	private float _winRate;

	private float _lossRate;

	private int _maxLotteryUser;

	private const int ListCountThreshold = 2;

	private int ActiveBetCount
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in _betDict)
			{
				if (item.Value > 0)
				{
					num++;
				}
			}
			return num;
		}
	}

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtl";
	}

	public static UI_ServerWideBetSettingPanel CreateInstance()
	{
		return (UI_ServerWideBetSettingPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBetSettingPanel");
	}

	public static UI_ServerWideBetSettingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBetSettingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ServerWideBetSettingDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters != null)
		{
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
		}
		if (string.IsNullOrEmpty(_activityId) && RankDataHelper.AllServersChampionshipInfo != null)
		{
			_activityId = RankDataHelper.AllServersChampionshipInfo.ActivityId;
		}
		LoadLotteryConfig();
		((GObject)Dialog.BattleGroupTitle.title).text = GetStageGroupTitle();
		bool flag = _stageStatus == StageStatus.Round1_Final || _stageStatus == StageStatus.Round2_Final;
		Dialog.IsFinalMatch.selectedIndex = (flag ? 1 : 0);
		string text = "ui://82mo10n5rnlpjdtq".Replace("ui://", "");
		string text2 = text + "-" + ((GObject)Dialog.TipTitle).id;
		string text3 = (flag ? "-texts_0" : "-texts_def");
		((GObject)Dialog.TipTitle).text = LanguagesManager.GetDesc(text2 + text3);
		LoadGroupDataAndBets();
		popup.Play();
	}

	private async void LoadGroupDataAndBets()
	{
		if (string.IsNullOrEmpty(_activityId))
		{
			return;
		}
		MatchInfo matchInfo = await RankDataHelper.GetMatchGroupInfo(_activityId, _stageStatus);
		if (matchInfo == null || matchInfo.WarGroupPlayers == null)
		{
			RenderPlayerBetList();
			UpdateBetCountDisplay();
			return;
		}
		if (!matchInfo.WarGroupPlayers.TryGetValue(_groupIndex, out var item))
		{
			_groupPlayerIds = new List<int>();
		}
		else
		{
			_groupPlayerIds = item;
		}
		RenderPlayerBetList();
		UpdateBetCountDisplay();
		LotteryInfo lotteryInfo = await RankDataHelper.GetLotteryGroupInfo(_activityId, _stageStatus);
		if (lotteryInfo?.WarGroupLotteried != null)
		{
			foreach (WarGroupLottery groupLottery in lotteryInfo.WarGroupLotteried)
			{
				if (groupLottery.WarLotteries == null || groupLottery.GroupIndex != _groupIndex)
				{
					continue;
				}
				foreach (WarLottery lottery in groupLottery.WarLotteries)
				{
					if (_betDict.ContainsKey(lottery.UserId))
					{
						_betDict[lottery.UserId] += lottery.Amount;
					}
					else
					{
						_betDict[lottery.UserId] = lottery.Amount;
					}
				}
			}
		}
		_originalTotalBets = 0;
		foreach (KeyValuePair<int, int> kv in _betDict)
		{
			if (kv.Value > 0)
			{
				_originalTotalBets += kv.Value;
			}
		}
		UpdatePlayerBetStates();
		UpdateBetCountDisplay();
	}

	private void LoadLotteryConfig()
	{
		WarOfRealmLotteryConfigEntry matchedLotteryConfig = RankDataHelper.GetMatchedLotteryConfig(_stageStatus);
		if (matchedLotteryConfig != null)
		{
			_betAmountOptions = matchedLotteryConfig.LotteryTokenLevel ?? new List<int>();
			_lotteryTokenItemId = matchedLotteryConfig.LotteryTokenItemId;
			_bonus = matchedLotteryConfig.Bonus;
			_winRate = matchedLotteryConfig.WinRate;
			_lossRate = matchedLotteryConfig.LossRate;
			_maxLotteryUser = matchedLotteryConfig.MaxLotteryUser;
		}
		else
		{
			_betAmountOptions = new List<int>();
			_lotteryTokenItemId = null;
			_bonus = null;
			_winRate = 0f;
			_lossRate = 0f;
			_maxLotteryUser = 0;
		}
		RenderBetBingoDisplay();
	}

	private void RenderBetBingoDisplay()
	{
		if (!string.IsNullOrEmpty(_lotteryTokenItemId))
		{
			Dialog.BetBingoItemIcon1.url = UiHelper.GetItemIconPath(_lotteryTokenItemId);
		}
		if (_bonus != null && _bonus.Count > 0)
		{
			KeyValuePair<string, int> keyValuePair = _bonus.First();
			string key = keyValuePair.Key;
			int value = keyValuePair.Value;
			Dialog.BetBingoItemIcon2.url = UiHelper.GetItemIconPath(key);
			((GObject)Dialog.BetBingoCount2).text = $"{_winRate * (float)value}";
		}
		if (!string.IsNullOrEmpty(_lotteryTokenItemId))
		{
			Dialog.BetFailedItemIcon1.url = UiHelper.GetItemIconPath(_lotteryTokenItemId);
		}
		if (_bonus != null && _bonus.Count > 0)
		{
			int value2 = _bonus.First().Value;
			((GObject)Dialog.BetFailedCount2).text = $"{_lossRate * (float)value2}";
		}
	}

	private string GetStageGroupTitle()
	{
		return RankDataHelper.GetStageGroupTitle(_stageStatus, _groupIndex);
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GObject)Dialog.ExitButton).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(OnConfirmBet));
		Dialog.PlayerBetList1.onClickItem.Add(new EventCallback1(OnPlayerBetListItemClick));
		Dialog.PlayerBetList2.onClickItem.Add(new EventCallback1(OnPlayerBetListItemClick));
		((GObject)Dialog.clickMask).onClick.Add(new EventCallback0(OnClickMask));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ExitButton).onClick.Clear();
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		Dialog.PlayerBetList1.onClickItem.Clear();
		Dialog.PlayerBetList2.onClickItem.Clear();
		((GObject)Dialog.clickMask).onClick.Clear();
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
		if (_groupPlayerIds == null || index >= _groupPlayerIds.Count)
		{
			return;
		}
		int num = _groupPlayerIds[index];
		if (!(gObject is UI_btn_PlayerBetAndReport uI_btn_PlayerBetAndReport))
		{
			return;
		}
		((GObject)uI_btn_PlayerBetAndReport.PlayerName).text = $"{num}";
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, num, uI_btn_PlayerBetAndReport.PlayerAvatar.HeadPortrait.PlayerIcon, uI_btn_PlayerBetAndReport.PlayerName));
		int value = 0;
		bool flag = _betDict.TryGetValue(num, out value) && value > 0;
		uI_btn_PlayerBetAndReport.HasBet.selectedIndex = (flag ? 1 : 0);
		uI_btn_PlayerBetAndReport.ShowMode.selectedIndex = 1;
		if (!string.IsNullOrEmpty(_lotteryTokenItemId))
		{
			uI_btn_PlayerBetAndReport.ItemIcon.url = UiHelper.GetItemIconPath(_lotteryTokenItemId);
			int value2 = 0;
			if (_betDict.TryGetValue(num, out value2))
			{
				((GObject)uI_btn_PlayerBetAndReport.ItemCountText).text = $"{value2}";
			}
			else
			{
				((GObject)uI_btn_PlayerBetAndReport.ItemCountText).text = "0";
			}
		}
	}

	private void OnPlayerBetListItemClick(EventContext context)
	{
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		object data = context.data;
		GObject val = (GObject)((data is GObject) ? data : null);
		if (val == null || !(val is UI_btn_PlayerBetAndReport))
		{
			return;
		}
		if (_groupPlayerIds == null || _groupPlayerIds.Count == 0)
		{
			ILRuntimeDebug.LogError("[BetSetting] _groupPlayerIds 为空，无法响应点击");
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
		int num = _groupPlayerIds[childIndex];
		int value = 0;
		bool flag = _betDict.TryGetValue(num, out value) && value > 0;
		int activeBetCount = ActiveBetCount;
		if (!flag && _maxLotteryUser > 0 && activeBetCount >= _maxLotteryUser)
		{
			if (Dialog.CountAlert.playing)
			{
				Dialog.CountAlert.Stop();
			}
			Dialog.CountAlert.Play();
			"ServerWideBetTip3".ToShowLanguageTip();
			return;
		}
		_selectedUserId = num;
		_selectedBetAmount = value;
		Vector2 val2 = val.TransformPoint(Vector2.zero, (GObject)(object)Dialog);
		float num2 = val2.x + val.actualWidth * 0.5f;
		float num3 = val2.y + val.actualHeight;
		float num4 = 260f;
		if (num2 < num4)
		{
			num2 = num4;
		}
		if (num2 > ((GObject)Dialog).actualWidth - num4)
		{
			num2 = ((GObject)Dialog).actualWidth - num4;
		}
		if (num3 < 0f)
		{
			num3 = 0f;
		}
		if (num3 > ((GObject)Dialog).actualHeight - 116f)
		{
			num3 = ((GObject)Dialog).actualHeight - 116f;
		}
		((GObject)Dialog.BetSelectTipDialog).SetXY(num2, num3);
		Dialog.OpenTipDialog.selectedIndex = 1;
		RenderBetSelectList();
	}

	private int GetAvailableTokensForPlayer(int userId)
	{
		int num = 0;
		foreach (KeyValuePair<int, int> item in _betDict)
		{
			if (item.Key != userId)
			{
				num += item.Value;
			}
		}
		if (string.IsNullOrEmpty(_lotteryTokenItemId))
		{
			return 0;
		}
		int stock = GameManagers.Instance.StockController.GetStock(_lotteryTokenItemId);
		return stock + _originalTotalBets - num;
	}

	private void RenderBetSelectList()
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		int availableTokensForPlayer = GetAvailableTokensForPlayer(_selectedUserId);
		Dialog.BetSelectTipDialog.BetSelectList.RemoveChildrenToPool();
		foreach (int amount in _betAmountOptions)
		{
			if (Dialog.BetSelectTipDialog.BetSelectList.AddItemFromPool("ui://82mo10n5rnlpjdtr") is UI_btn_BetSelect uI_btn_BetSelect)
			{
				((GObject)uI_btn_BetSelect.title).text = $"{amount}";
				if (amount == _selectedBetAmount)
				{
					uI_btn_BetSelect.Status.selectedIndex = 1;
					((GObject)uI_btn_BetSelect).touchable = true;
				}
				else if (amount > availableTokensForPlayer)
				{
					uI_btn_BetSelect.Status.selectedIndex = 2;
					((GObject)uI_btn_BetSelect).touchable = false;
				}
				else
				{
					uI_btn_BetSelect.Status.selectedIndex = 0;
					((GObject)uI_btn_BetSelect).touchable = true;
				}
				((GObject)uI_btn_BetSelect).onClick.Set((EventCallback0)delegate
				{
					OnBetAmountSelected(amount);
				});
			}
		}
	}

	private void OnBetAmountSelected(int amount)
	{
		int value = 0;
		_betDict.TryGetValue(_selectedUserId, out value);
		bool flag = value > 0;
		int activeBetCount = ActiveBetCount;
		if (!flag && _maxLotteryUser > 0 && activeBetCount >= _maxLotteryUser)
		{
			if (Dialog.CountAlert != null)
			{
				if (Dialog.CountAlert.playing)
				{
					Dialog.CountAlert.Stop();
				}
				Dialog.CountAlert.Play();
			}
			return;
		}
		if (amount == _selectedBetAmount)
		{
			_betDict[_selectedUserId] = 0;
			_selectedBetAmount = 0;
		}
		else
		{
			_betDict[_selectedUserId] = amount;
			_selectedBetAmount = amount;
		}
		RenderBetSelectList();
		UpdatePlayerBetStates();
		UpdateBetCountDisplay();
	}

	private void UpdateBetCountDisplay()
	{
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<int, int> item in _betDict)
		{
			if (item.Value > 0)
			{
				num += item.Value;
				num2++;
			}
		}
		((GObject)Dialog.CountText).text = $"{num2}/{_maxLotteryUser}";
		((GObject)Dialog.BetItemTotallyCount).text = $"{num}";
	}

	private void UpdatePlayerBetStates()
	{
		int activeBetCount = ActiveBetCount;
		ApplyState(Dialog.PlayerBetList1);
		ApplyState(Dialog.PlayerBetList2);
		void ApplyState(GList list)
		{
			for (int i = 0; i < list.numItems; i++)
			{
				if (((GComponent)list).GetChildAt(i) is UI_btn_PlayerBetAndReport uI_btn_PlayerBetAndReport && i < _groupPlayerIds.Count)
				{
					int key = _groupPlayerIds[i];
					int value = 0;
					bool flag = _betDict.TryGetValue(key, out value) && value > 0;
					uI_btn_PlayerBetAndReport.HasBet.selectedIndex = (flag ? 1 : 0);
					((GObject)uI_btn_PlayerBetAndReport.ItemCountText).text = (flag ? $"{value}" : "0");
				}
			}
		}
	}

	private void OnClickMask()
	{
		Dialog.OpenTipDialog.selectedIndex = 0;
	}

	private void OnConfirmBet()
	{
		List<WarLottery> lotteries = new List<WarLottery>();
		foreach (KeyValuePair<int, int> item in _betDict)
		{
			if (item.Value > 0)
			{
				lotteries.Add(new WarLottery
				{
					UserId = item.Key,
					Amount = item.Value
				});
			}
		}
		int num = 0;
		foreach (WarLottery item2 in lotteries)
		{
			num += item2.Amount;
		}
		int num2 = num - _originalTotalBets;
		if (num2 > 0)
		{
			int stock = GameManagers.Instance.StockController.GetStock(_lotteryTokenItemId);
			if (stock < num2)
			{
				"ServerWideBetTip2".ToShowLanguageTip();
				return;
			}
		}
		int stageStatusVal = (int)_stageStatus;
		if (stageStatusVal <= 0)
		{
			stageStatusVal = 1;
		}
		ILRequestHelper<WarOfRealmLotteryResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().LotteryWarOfRealm(stageStatusVal, _groupIndex, lotteries), delegate(WarOfRealmLotteryResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRuntimeDebug.LogError($"投注失败, ErrorCode={response.ErrorCode}");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (lotteries.Count > 0)
				{
					"ServerWideBetTip1".ToShowLanguageTip();
				}
				if (RankDataHelper.AllServersChampionshipInfo?.LotteryInfoDict != null)
				{
					RankDataHelper.AllServersChampionshipInfo.LotteryInfoDict.Remove(_stageStatus);
				}
			}
			GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
			End();
		}, 1f);
	}

	public static void Open(string activityId, StageStatus stageStatus, int groupIndex)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			["ActivityId"] = activityId,
			["StageStatus"] = stageStatus,
			["GroupIndex"] = groupIndex
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, parameters);
	}
}
