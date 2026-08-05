using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using UI.SpecialActivity;

namespace UI.WeekActivity;

public class UI_popup_weekSpinCard : GComponent, IUiController
{
	public GGraph n142;

	public UI_com_weekSpinCardDialog Content;

	public Transition t4;

	public const string URL = "ui://jl0c82y5ibyrg";

	public static string Name = "UI_popup_weekSpinCard";

	private GetWeeklyActivityResponse _info;

	public static StoreItem WeekCard => StoreItem.Get(GameManagers.Instance, "SpinWeekPass1");

	public static string GetURL()
	{
		return "ui://jl0c82y5ibyrg";
	}

	public static UI_popup_weekSpinCard CreateInstance()
	{
		return (UI_popup_weekSpinCard)(object)UIPackage.CreateObject("WeekActivity", "popup_weekSpinCard");
	}

	public static UI_popup_weekSpinCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_weekSpinCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5ibyrg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n142 = (GGraph)((GComponent)this).GetChild("n142");
		Content = (UI_com_weekSpinCardDialog)(object)((GComponent)this).GetChild("Content");
		t4 = ((GComponent)this).GetTransition("t4");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Content.BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)Content.BuyAdvanceBtn).onClick.Set(new EventCallback0(OnClickBuyWeekCard));
		GameManagers.Instance.Messenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Content.BackBtn).onClick.Clear();
		((GObject)Content.BuyAdvanceBtn).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_info = ActivityManager.SpinWeekActivity;
		bool unlockPaySource = _info.ActivityProgress.UnlockPaySource;
		Content.Mode.SetSelectedIndex(unlockPaySource ? 1 : 0);
		int time = (int)(_info.ActivityConfig.EndTime - GameController.Instance.GetServerTime());
		string arg = UiHelper.ParseTimeChinsesDH(time);
		((GObject)Content.Time).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SpinWeekCardTimeTip".ToLanguage(), arg);
		KeyValuePair<string, float> availablePriceItemId = UI_SpecialActivityPanel.GetAvailablePriceItemId(WeekCard);
		((GObject)Content.BuyAdvanceBtn.Cost).text = $"{availablePriceItemId.Value:N0}";
		Content.BuyAdvanceBtn.costIcon.url = UiHelper.GetItemIconPath(availablePriceItemId.Key);
		Content.RewardList.itemRenderer = new ListItemRenderer(RenderRewardItem);
		Refresh();
	}

	private void RenderRewardItem(int index, GObject item)
	{
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		UI_com_weekSpinCardItem btn = (UI_com_weekSpinCardItem)(object)item;
		SpinWeekActivityPayload.SpinWeekCard reward = _info.ActivityConfig.SpinWeekCards[index];
		bool hasPurchased = _info.ActivityProgress.UnlockPaySource;
		int day = _info.GetDay();
		bool flag = reward.Day <= day;
		btn.LevelState.SetSelectedIndex(flag ? 1 : 0);
		btn.TargetLevel.SetSelectedIndex(reward.Day - 1);
		btn.Stage.SetSelectedIndex((day == reward.Day) ? 1 : 0);
		if (reward.Free.Count > 0)
		{
			KeyValuePair<string, int> keyValuePair = reward.Free.First();
			btn.Normal.Icon.url = UiHelper.GetItemIconPath(keyValuePair.Key);
			bool flag2 = _info.ActivityProgress.SpinWeekCardClaimRecord.Find((SpinWeekActivityPayload.SpinWeekCard x) => x.Day == reward.Day)?.ClaimedFree ?? false;
			btn.Normal.State.SetSelectedIndex(flag ? ((!flag2) ? 1 : 2) : 0);
			((GObject)btn.Normal.Num).text = keyValuePair.Value.ToString();
			((GObject)btn.Normal).onClick.Set((EventCallback0)delegate
			{
				if (btn.Normal.State.selectedIndex == 1)
				{
					OnClickClaimReward(reward.Day, isFree: true);
				}
			});
		}
		KeyValuePair<string, int> keyValuePair2 = reward.Pay.First();
		btn.Advanced1.Icon.url = UiHelper.GetItemIconPath(keyValuePair2.Key);
		bool flag3 = _info.ActivityProgress.SpinWeekCardClaimRecord.Find((SpinWeekActivityPayload.SpinWeekCard x) => x.Day == reward.Day)?.ClaimedPay ?? false;
		btn.Advanced1.State.SetSelectedIndex(hasPurchased ? ((!flag) ? 1 : (flag3 ? 3 : 2)) : 0);
		((GObject)btn.Advanced1.Num).text = keyValuePair2.Value.ToString();
		((GObject)btn.Advanced1).onClick.Set((EventCallback0)delegate
		{
			if (!hasPurchased)
			{
				OnClickBuyWeekCard();
			}
			else if (btn.Advanced1.State.selectedIndex == 2)
			{
				OnClickClaimReward(reward.Day, isFree: false);
			}
		});
	}

	private void Refresh()
	{
		Content.RewardList.numItems = _info.ActivityConfig.SpinWeekCards.Count;
	}

	private void OnClickBuyWeekCard()
	{
		if (!_info.ActivityProgress.UnlockPaySource)
		{
			StoreItem weekCard = WeekCard;
			ProductLocalInfo value = null;
			if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(weekCard.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(weekCard.ReferenceId, out value);
			}
			PurchaseManager.Instance.InvokePurchase(weekCard, value, 1, (Action)null, doubleCheck: true);
		}
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		_info.ActivityProgress.UnlockPaySource = true;
		GameManagers.Instance.Messenger.Broadcast("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", _info);
		Content.Mode.SetSelectedIndex(1);
		Refresh();
	}

	private async void OnClickClaimReward(int day, bool isFree)
	{
		ClaimSpinWeeklyLotteryResponse result = await GameController.Contexts.Service<INetworkService>().ClaimSpinWeeklyLottery(day, isFree);
		if (result.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return;
		}
		foreach (StockChangeRecord item in result.StockChangeRecords)
		{
			if (item.Offset > 0)
			{
				ILRequestHelper.ShowMessage($"{GDMgr.Get<GDEItemData>(item.ItemId).Name}+{item.Offset}");
			}
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
		List<SpinWeekActivityPayload.SpinWeekCard> list = _info.ActivityProgress.SpinWeekCardClaimRecord;
		SpinWeekActivityPayload.SpinWeekCard record = list.Find((SpinWeekActivityPayload.SpinWeekCard x) => x.Day == day);
		if (record == null)
		{
			record = new SpinWeekActivityPayload.SpinWeekCard
			{
				Day = day
			};
			list.Add(record);
		}
		if (isFree)
		{
			record.ClaimedFree = true;
		}
		else
		{
			record.ClaimedPay = true;
		}
		GameManagers.Instance.Messenger.Broadcast("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", _info);
		Refresh();
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

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
