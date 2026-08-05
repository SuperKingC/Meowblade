using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PVPSeasonMissionPanel : GComponent, IUiController
{
	public struct ScoreBonus
	{
		public Dictionary<string, int> FreeBonus;

		public string PaidBonus;
	}

	public GGraph mask;

	public UI_PVPSeasonMissionDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5g21rdp1";

	public static string Name = "UI_PVPSeasonMissionPanel";

	private StoreItem _currentStoreItem;

	private int _currentScore;

	private Dictionary<int, ScoreBonus> ScoreBonusDict { get; set; }

	private List<int> ScoreList { get; set; }

	public static string GetURL()
	{
		return "ui://82mo10n5g21rdp1";
	}

	public static UI_PVPSeasonMissionPanel CreateInstance()
	{
		return (UI_PVPSeasonMissionPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PVPSeasonMissionPanel");
	}

	public static UI_PVPSeasonMissionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PVPSeasonMissionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5g21rdp1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_PVPSeasonMissionDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		RenderWeeklyMissions();
		PrepareBonusData();
		((GObject)Dialog.TurnPageUpBtn).visible = false;
		((GObject)Dialog.TurnPageDownBtn).visible = false;
		UiHelper.LoadSomeUiPublicResources(RenderDefaultBonus);
	}

	public void OnShow()
	{
		((GObject)Dialog.CurrentScore).text = $"{RankDataHelper.AllServersChampionshipInfo.Score}";
		((GObject)Dialog.RemainingTime).text = string.Format(LanguagesManager.GetDesc("SeasonRemainingTime"), (RankDataHelper.AllServersChampionshipInfo.EndAtTimestamp - DateTimeHelper.ServerNowTimestamp) / (int)TimeSpan.FromDays(7.0).TotalSeconds);
		popup.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		((GObject)Dialog.ExitButton).onClick.Set(new EventCallback0(End));
		Dialog.PageController.onChanged.Set(new EventCallback1(OnPageControllerChanged));
		((GObject)Dialog.ScoreBonusNode.GetFreeReward).onClick.Set(new EventCallback0(ClaimScoreRewards));
		((GObject)Dialog.ScoreBonusNode.GetExtraReward).onClick.Set(new EventCallback0(PurchaseScoreRewards));
		((GObject)Dialog.TurnPageUpBtn).onClick.Set(new EventCallback0(TurnScoreRewardsUp));
		((GObject)Dialog.TurnPageDownBtn).onClick.Set(new EventCallback0(TurnScoreRewardsDown));
		((GObject)Dialog.ScoreBonusNode.CardRewardIcon).onClick.Set(new EventCallback1(ShowScoreBonusTip));
		GameManagers.Instance.Messenger.AddListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ExitButton).onClick.Clear();
		Dialog.PageController.onChanged.Clear();
		((GObject)Dialog.ScoreBonusNode.GetFreeReward).onClick.Clear();
		((GObject)Dialog.ScoreBonusNode.GetExtraReward).onClick.Clear();
		((GObject)Dialog.TurnPageUpBtn).onClick.Clear();
		((GObject)Dialog.TurnPageDownBtn).onClick.Clear();
		((GObject)Dialog.ScoreBonusNode.CardRewardIcon).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiHelper.UnloadPackage();
	}

	private void OnPageControllerChanged(EventContext context)
	{
		if (Dialog.PageController.selectedIndex == 0)
		{
			RenderWeeklyMissions();
		}
		else if (Dialog.PageController.selectedIndex == 1)
		{
			RenderSeasonMissions();
		}
	}

	private void TurnScoreRewardsUp()
	{
		int num = ScoreList.IndexOf(_currentScore);
		if (num != 0)
		{
			int targetScore = ScoreList[num - 1];
			num--;
			SlideScoreBonusNode(targetScore);
			Dialog.CardRewardListState.selectedIndex = ((num > 0) ? 1 : 2);
		}
	}

	private void TurnScoreRewardsDown()
	{
		int num = ScoreList.IndexOf(_currentScore);
		if (num != ScoreList.Count - 1)
		{
			int targetScore = ScoreList[num + 1];
			num++;
			SlideScoreBonusNode(targetScore);
			Dialog.CardRewardListState.selectedIndex = ((num != ScoreList.Count - 1) ? 1 : 0);
		}
	}

	private void SlideScoreBonusNode(int targetScore)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		((GObject)Dialog.TurnPageUpBtn).onClick.Clear();
		((GObject)Dialog.TurnPageDownBtn).onClick.Clear();
		int op = ((targetScore > _currentScore) ? 1 : (-1));
		float startY = ((GObject)Dialog.ScoreBonusNode.NodeGroup).y;
		GTweenCallback val = default(GTweenCallback);
		((GObject)Dialog.ScoreBonusNode.NodeGroup).TweenMoveY(startY - (float)op * ((GObject)Dialog.ScoreBonusNode).height, 0.33f).SetEase((EaseType)4).OnComplete((GTweenCallback)delegate
		{
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_00a1: Expected O, but got Unknown
			GGroup nodeGroup = Dialog.ScoreBonusNode.NodeGroup;
			((GObject)nodeGroup).y = ((GObject)nodeGroup).y + (float)op * ((GObject)Dialog.ScoreBonusNode).height * 2f;
			UpdateBonusByScore(targetScore);
			GTweener obj = ((GObject)Dialog.ScoreBonusNode.NodeGroup).TweenMoveY(startY, 0.33f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					//IL_002c: Expected O, but got Unknown
					//IL_004e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0058: Expected O, but got Unknown
					((GObject)Dialog.TurnPageUpBtn).onClick.Set(new EventCallback0(TurnScoreRewardsUp));
					((GObject)Dialog.TurnPageDownBtn).onClick.Set(new EventCallback0(TurnScoreRewardsDown));
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private void ShowScoreBonusTip(EventContext context)
	{
		string text = $"{((GObject)Dialog.ScoreBonusNode.CardRewardIcon).data}";
		if (!string.IsNullOrEmpty(text))
		{
			FGUIManager.Instance.ItemTip(text, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void RefreshDisplayedMissionsByTypes(params eMissionType[] types)
	{
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		List<WarOfRealmMission> list = new List<WarOfRealmMission>();
		List<WarOfRealmMission> list2 = new List<WarOfRealmMission>();
		foreach (WarOfRealmMission mission in RankDataHelper.AllServersChampionshipInfo.Missions)
		{
			if (types.Contains(mission.Type))
			{
				if (!RankDataHelper.AllServersChampionshipInfo.MissionProgressDict.TryGetValue(mission.Type, out var value))
				{
					value = 0;
				}
				if (value < mission.TargetValue)
				{
					list.Add(mission);
				}
				else
				{
					list2.Add(mission);
				}
			}
		}
		list.AddRange(list2);
		Dialog.MissionList.RemoveChildrenToPool();
		foreach (WarOfRealmMission item in list)
		{
			UI_SingleSeasonMission uI_SingleSeasonMission = Dialog.MissionList.AddItemFromPool("ui://82mo10n5g21rdpf") as UI_SingleSeasonMission;
			if (!RankDataHelper.AllServersChampionshipInfo.MissionProgressDict.TryGetValue(item.Type, out var value2))
			{
				value2 = 0;
			}
			((GObject)uI_SingleSeasonMission.Desc).text = LanguagesManager.GetDesc($"PvPMissionDescType_{(int)item.Type}");
			((GObject)uI_SingleSeasonMission.Value).text = $"{value2}/{item.TargetValue}";
			((GObject)uI_SingleSeasonMission.RewardCount1).text = $"{item.Score}";
			uI_SingleSeasonMission.RewardIcon1.url = "ui://PvpSelectSoldiers/" + RankDataHelper.AllServerChampionshipSeasonMissionScore;
			((GObject)uI_SingleSeasonMission.RewardCount2).text = $"{item.LotteryCoin}";
			uI_SingleSeasonMission.RewardIcon2.url = UiHelper.GetItemIconPath(RankDataHelper.AllServerChampionshipBetCoin);
			uI_SingleSeasonMission.State.selectedIndex = ((value2 >= item.TargetValue) ? 1 : 0);
			((GObject)uI_SingleSeasonMission.RewardIcon2).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(RankDataHelper.AllServerChampionshipBetCoin, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
	}

	private void RenderWeeklyMissions()
	{
		RefreshDisplayedMissionsByTypes(eMissionType.累计参加天梯战斗次数周任务, eMissionType.累计天梯获胜次数周任务, eMissionType.入围巅峰赛战斗周任务);
	}

	private void RenderSeasonMissions()
	{
		RefreshDisplayedMissionsByTypes(eMissionType.入围巅峰赛战斗赛季任务, eMissionType.连续参与巅峰赛赛季任务, eMissionType.参与任意巅峰对决赛季任务, eMissionType.累计参加天梯战斗次数赛季任务, eMissionType.累计天梯获胜次数赛季任务, eMissionType.累计参与竞猜次数赛季任务, eMissionType.累计天梯参与轮次赛季任务);
	}

	private void PrepareBonusData()
	{
		ScoreBonusDict = new Dictionary<int, ScoreBonus>();
		foreach (KeyValuePair<int, Dictionary<string, int>> item in RankDataHelper.AllServersChampionshipInfo.FreeBonusDict)
		{
			if (!ScoreBonusDict.TryGetValue(item.Key, out var value))
			{
				value = default(ScoreBonus);
			}
			value.FreeBonus = item.Value;
			ScoreBonusDict[item.Key] = value;
		}
		foreach (KeyValuePair<int, string> item2 in RankDataHelper.AllServersChampionshipInfo.PaidBonusDict)
		{
			if (!ScoreBonusDict.TryGetValue(item2.Key, out var value2))
			{
				value2 = default(ScoreBonus);
			}
			value2.PaidBonus = item2.Value;
			ScoreBonusDict[item2.Key] = value2;
		}
		ScoreList = ScoreBonusDict.Keys.ToList();
		ScoreList.Sort();
	}

	private void RenderDefaultBonus()
	{
		((GObject)Dialog.TurnPageUpBtn).visible = true;
		((GObject)Dialog.TurnPageDownBtn).visible = true;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		StoreItem storeItem = null;
		for (int i = 0; i < ScoreList.Count - 1; i++)
		{
			num = ScoreList[i];
			if (RankDataHelper.AllServersChampionshipInfo.Score < num)
			{
				num2 = i;
				break;
			}
			ScoreBonus scoreBonus = ScoreBonusDict[num];
			if (scoreBonus.FreeBonus != null && !RankDataHelper.AllServersChampionshipInfo.Claimed.Contains(num))
			{
				num2 = i;
				num3 = 1;
				break;
			}
			if (!string.IsNullOrEmpty(scoreBonus.PaidBonus))
			{
				storeItem = StoreItem.Get(GameManagers.Instance, scoreBonus.PaidBonus);
				int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				if (storeItem.PurchaseLimit < 1 || purchaseCntAtLimitPeriod < storeItem.PurchaseLimit)
				{
					num2 = i;
					num3 = 2;
					break;
				}
			}
		}
		if (num3 != 1 && num3 != 2)
		{
			num3 = ((RankDataHelper.AllServersChampionshipInfo.Score >= num) ? 3 : 0);
		}
		switch (num3)
		{
		case 0:
		case 1:
			_renderFreeBonusByScore(num);
			break;
		case 2:
		case 3:
			_renderPaidBonusByScore(num);
			break;
		}
		if (num2 == 0)
		{
			Dialog.CardRewardListState.selectedIndex = 2;
		}
		else if (num2 == ScoreList.Count - 1)
		{
			Dialog.CardRewardListState.selectedIndex = 0;
		}
		else
		{
			Dialog.CardRewardListState.selectedIndex = 1;
		}
		Dialog.CardState.selectedIndex = num3;
		Dialog.ScoreBonusNode.CardState.selectedIndex = num3;
	}

	private void _renderFreeBonusByScore(int score)
	{
		Dictionary<string, int> dictionary = RankDataHelper.AllServersChampionshipInfo.FreeBonusDict[score];
		string text = dictionary.Keys.First();
		int num = dictionary.Values.First();
		((GObject)Dialog.ScoreBonusNode.CardRewardName).text = $"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, text)}x{num}";
		Dialog.CardRewardIcon.url = "ui://PublicResources/" + GDMgr.Get<GDEItemData>(text).Icon;
		Dialog.ScoreBonusNode.CardRewardIcon.url = "ui://PublicResources/" + GDMgr.Get<GDEItemData>(text).Icon;
		((GObject)Dialog.ScoreBonusNode.CardRewardIcon).data = text;
		((GObject)Dialog.ScoreBonusNode.CardDemandScore).text = $"{score}";
		_currentStoreItem = null;
		_currentScore = score;
	}

	private void _renderPaidBonusByScore(int score)
	{
		string storeItemId = RankDataHelper.AllServersChampionshipInfo.PaidBonusDict[score];
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, storeItemId);
		int purchaseLimit = storeItem.PurchaseLimit;
		if (purchaseLimit < 1)
		{
			((GObject)Dialog.ScoreBonusNode.LimitBuyGroup).visible = false;
		}
		else
		{
			((GObject)Dialog.ScoreBonusNode.LimitBuyGroup).visible = true;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			((GObject)Dialog.ScoreBonusNode.CardRewardName).text = storeItem.Name + "x1";
			((GObject)Dialog.ScoreBonusNode.LimitBuyCurrent).text = $"{purchaseLimit - purchaseCntAtLimitPeriod}";
			((GObject)Dialog.ScoreBonusNode.LimitBuyTotal).text = $"{purchaseLimit}";
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
		string key = priceItemId.Key;
		FGUIManager.Instance.GetCurrencySymbol(key, Dialog.ScoreBonusNode.CurrencyIcon, null);
		((GObject)Dialog.ScoreBonusNode.CardRewardPrice).text = $"{priceItemId.Value:F0}";
		if (storeItem.Discount > 0f && !Mathf.Approximately(storeItem.Discount, 1f))
		{
			((GObject)Dialog.ScoreBonusNode.DiscountIcon).visible = true;
			UiHelper.SetStoreItemDiscount(storeItem, Dialog.ScoreBonusNode.DiscountIcon, ribbonVisible: false);
		}
		else
		{
			((GObject)Dialog.ScoreBonusNode.DiscountIcon).visible = false;
		}
		Dialog.CardRewardIcon.url = "ui:" + storeItem.Icon;
		Dialog.ScoreBonusNode.CardRewardIcon.url = "ui:" + storeItem.Icon;
		((GObject)Dialog.ScoreBonusNode.CardRewardIcon).data = storeItem.Content.Keys.First();
		((GObject)Dialog.ScoreBonusNode.CardDemandScore).text = $"{score}";
		_currentStoreItem = storeItem;
		_currentScore = score;
	}

	private void UpdateBonusByScore(int score)
	{
		bool flag = true;
		if ((string.IsNullOrEmpty(ScoreBonusDict[score].PaidBonus) && ScoreBonusDict[score].FreeBonus != null) || ((string.IsNullOrEmpty(ScoreBonusDict[score].PaidBonus) || ScoreBonusDict[score].FreeBonus != null) && !RankDataHelper.AllServersChampionshipInfo.Claimed.Contains(score)))
		{
			_renderFreeBonusByScore(score);
			bool flag2 = RankDataHelper.AllServersChampionshipInfo.Score >= score && !RankDataHelper.AllServersChampionshipInfo.Claimed.Contains(score);
			Dialog.CardState.selectedIndex = (flag2 ? 1 : 0);
			Dialog.ScoreBonusNode.CardState.selectedIndex = (flag2 ? 1 : 0);
		}
		else
		{
			_renderPaidBonusByScore(score);
			string storeItemId = RankDataHelper.AllServersChampionshipInfo.PaidBonusDict[score];
			int purchaseLimit = StoreItem.Get(GameManagers.Instance, storeItemId).PurchaseLimit;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItemId);
			bool flag3 = RankDataHelper.AllServersChampionshipInfo.Score >= score && (purchaseLimit < 1 || purchaseLimit > purchaseCntAtLimitPeriod);
			Dialog.CardState.selectedIndex = (flag3 ? 2 : 3);
			Dialog.ScoreBonusNode.CardState.selectedIndex = (flag3 ? 2 : 3);
		}
	}

	private void ClaimScoreRewards()
	{
		ILRequestHelper<WarOfRealmClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ClaimWarOfRealm(_currentScore), delegate(WarOfRealmClaimResponse response)
		{
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dialog.CardState.selectedIndex = 0;
				Dialog.ScoreBonusNode.CardState.selectedIndex = 0;
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				RankDataHelper.AllServersChampionshipInfo.UpdateAllServersChampionshipClaimed(response.Claimed);
				((GObject)Dialog.CardRewardIcon).visible = true;
				((GObject)Dialog.ScoreBonusNode.CardRewardIcon).visible = false;
				((GObject)Dialog.ScoreBonusNode.BonusHaloFX).visible = false;
				Dialog.GetReward.SetHook("ChangeState", (TransitionHook)delegate
				{
					if (ScoreBonusDict[_currentScore].PaidBonus != null)
					{
						_renderPaidBonusByScore(_currentScore);
						Dialog.CardState.selectedIndex = 2;
						Dialog.ScoreBonusNode.CardState.selectedIndex = 2;
						((GObject)Dialog.ScoreBonusNode.BonusHaloFX).visible = true;
					}
					else
					{
						int num = ScoreList.IndexOf(_currentScore);
						if (num < ScoreList.Count - 1)
						{
							TurnScoreRewardsDown();
						}
						else
						{
							Dialog.CardState.selectedIndex = 0;
							Dialog.ScoreBonusNode.CardState.selectedIndex = 0;
						}
					}
				});
				Dialog.GetReward.Play((PlayCompleteCallback)delegate
				{
					((GObject)Dialog.CardRewardIcon).visible = false;
					((GObject)Dialog.ScoreBonusNode.CardRewardIcon).visible = true;
					((GObject)Dialog.ScoreBonusNode.BonusHaloFX).visible = true;
				});
			}
		}, 1f);
	}

	private void PurchaseScoreRewards()
	{
		PurchaseManager.Instance.InvokePurchase(_currentStoreItem, (ProductLocalInfo)null, 1, (Action)null, doubleCheck: true);
	}

	private void OrderShipSuccessEvent(string storeItemId)
	{
		if (storeItemId == _currentStoreItem.StoreItemId)
		{
			Dialog.CardState.selectedIndex = 3;
			Dialog.ScoreBonusNode.CardState.selectedIndex = 3;
			TurnScoreRewardsDown();
		}
	}

	private void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
